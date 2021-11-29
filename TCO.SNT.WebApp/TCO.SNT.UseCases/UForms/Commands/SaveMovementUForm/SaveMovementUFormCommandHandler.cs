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

namespace TCO.SNT.UseCases.UForms.Commands.SaveMovementUForm
{
    internal class SaveMovementUFormCommandHandler : SaveUFormCommandHandlerBase, IRequestHandler<SaveMovementUFormCommand, int>
    {
        public SaveMovementUFormCommandHandler(IDbContext context, IMapper mapper,
            IOptions<CompanyOptions> companyOptions, UserAccessService userAccessService) : base(context, mapper, companyOptions, userAccessService)
        {
        }

        public Task<int> Handle(SaveMovementUFormCommand request, CancellationToken cancellationToken)
        {
            return HandleBase(request.Form, cancellationToken);
        }

        protected override Task MapUFormProductAsync(UForm form, UFormProductDtoBase productDtoBase,
            UFormProduct formProduct, CancellationToken cancellationToken)
        {
            var productDto = (MovementUFormProductDto)productDtoBase;
            return MapBalanceAsync(form, productDto.BalanceId, formProduct, cancellationToken);
        }

        protected override async Task MapUFormFieldsAsync(UFormDtoBase dto, UForm form, CancellationToken cancellationToken)
        {
            await base.MapUFormFieldsAsync(dto, form, cancellationToken);

            var formDto = (MovementUFormDto)dto;
            form.CreateRecipientIfNotExists();
            await MapUFormParticipantAsync(formDto.RecipientTaxpayerStoreId, form.Recipient, cancellationToken);
        }
    }
}
