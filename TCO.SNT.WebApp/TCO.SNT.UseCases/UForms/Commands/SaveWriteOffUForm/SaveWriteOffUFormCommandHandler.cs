using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveWriteOffUForm
{
    internal class SaveWriteOffUFormCommandHandler : SaveUFormCommandHandlerBase, IRequestHandler<SaveWriteOffUFormCommand, int>
    {
        public SaveWriteOffUFormCommandHandler(IDbContext context, IMapper mapper,
            IOptions<CompanyOptions> companyOptions, UserAccessService userAccessService) : base(context, mapper, companyOptions, userAccessService)
        {
        }

        public Task<int> Handle(SaveWriteOffUFormCommand request, CancellationToken cancellationToken)
        {
            return HandleBase(request.Form, cancellationToken);
        }

        protected override Task MapUFormProductAsync(UForm form, UFormProductDtoBase productDtoBase,
            UFormProduct formProduct, CancellationToken cancellationToken)
        {
            var productDto = (WriteOffUFormProductDto)productDtoBase;
            return MapBalanceAsync(form, productDto.BalanceId, formProduct, cancellationToken);
        }
    }
}
