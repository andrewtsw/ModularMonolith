using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.UForms.Extentions;

namespace TCO.SNT.UseCases.UForms.Queries.GetAllUForms
{
    internal class GetAllUFormsQueryHandler : IRequestHandler<GetAllUFormsQuery, UFormListResponseDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly ErrorHelper _errorHelper;

        public GetAllUFormsQueryHandler(IDbContext context, IMapper mapper, ErrorHelper errorHelper)
        {
            _context = context;
            _mapper = mapper;
            _errorHelper = errorHelper;
        }

        public async Task<UFormListResponseDto> Handle(GetAllUFormsQuery request, CancellationToken cancellationToken)
        {
            var paging = new PagingModel(request.Dto.Paging);

            var query = await _context.UForms
                .ApplyFilter(request.Dto.Filter)
                .ApplySorting(request.Dto.Sorting)
                .ApplyPagingAsync(paging, cancellationToken);

            var forms = await query
                .ProjectTo<UFormSimpleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            await _errorHelper.FillErrorDescriptionAsync(forms, cancellationToken);

            return new UFormListResponseDto
            {
                Paging = paging,
                Uforms = forms
            };
        }
    }
}
