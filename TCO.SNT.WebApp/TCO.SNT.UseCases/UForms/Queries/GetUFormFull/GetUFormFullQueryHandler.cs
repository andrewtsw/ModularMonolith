using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Extentions;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormFull
{
    internal class GetUFormFullQueryHandler : IRequestHandler<GetUFormFullQuery, UFormFullDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetUFormFullQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UFormFullDto> Handle(GetUFormFullQuery request, CancellationToken cancellationToken)
        {
            var form = await _context.LoadUFormByIdAsync(request.UFormId, cancellationToken);

            return _mapper.Map<UFormFullDto>(form);
        }
    }
}
