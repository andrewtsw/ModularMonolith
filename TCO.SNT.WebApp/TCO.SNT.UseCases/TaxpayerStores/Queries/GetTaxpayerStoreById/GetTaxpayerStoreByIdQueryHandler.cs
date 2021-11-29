using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.Finportal.Framework.UseCases.Extensions;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetTaxpayerStoreById
{
    internal class GetTaxpayerStoreByIdQueryHandler : IRequestHandler<GetTaxpayerStoreByIdQuery, TaxpayerStoreDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly TaxpayerStoreUserValidator _taxpareStoreValidator;

        public GetTaxpayerStoreByIdQueryHandler(IDbContext context, IMapper mapper, TaxpayerStoreUserValidator taxpareStoreValidator)
        {
            _context = context;
            _mapper = mapper;
            _taxpareStoreValidator = taxpareStoreValidator;
        }

        public async Task<TaxpayerStoreDto> Handle(GetTaxpayerStoreByIdQuery request, CancellationToken cancellationToken)
        {
            await _taxpareStoreValidator.ThrowExceptionIfTaxpayerStoreForbiddenForUserAsync(request.Id, cancellationToken);

            return await _context.TaxpayerStores
                .ProjectTo<TaxpayerStoreDto>(_mapper.ConfigurationProvider)
                .SingleOrExceptionAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
