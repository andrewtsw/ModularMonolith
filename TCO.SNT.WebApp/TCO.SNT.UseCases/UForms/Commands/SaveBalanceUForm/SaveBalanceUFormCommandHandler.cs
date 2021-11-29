using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveBalanceUForm
{
    internal class SaveBalanceUFormCommandHandler : SaveUFormCommandHandlerBase, IRequestHandler<SaveBalanceUFormCommand, int>
    {
        private readonly ISharedModuleContract _sharedModuleContract;

        public SaveBalanceUFormCommandHandler(IDbContext context, 
            IMapper mapper,
            IOptions<CompanyOptions> companyOptions, 
            UserAccessService userAccessService,
            ISharedModuleContract sharedModuleContract) : base(context, mapper, companyOptions, userAccessService)
        {
            _sharedModuleContract = sharedModuleContract;
        }

        public Task<int> Handle(SaveBalanceUFormCommand request, CancellationToken cancellationToken)
        {
            return HandleBase(request.Form, cancellationToken);
        }

        protected override async Task MapUFormProductAsync(UForm form, UFormProductDtoBase productDtoBase, UFormProduct formProduct, CancellationToken cancellationToken)
        {
            var productDto = (BalanceUFormProductDto)productDtoBase;

            formProduct.Name = productDto.Name;
            formProduct.DutyTypeCode = productDto.DutyTypeCode;
            formProduct.ManufactureOrImportCountry = productDto.ManufactureOrImportCountry;
            formProduct.ManufactureOrImportDocNumber = productDto.ManufactureOrImportDocNumber;
            formProduct.OriginCode = productDto.OriginCode.ToString();
            formProduct.ProductNumberInImportDoc = productDto.ProductNumberInImportDoc;
            formProduct.ProductNameInImportDoc = productDto.ProductNameInImportDoc;
            formProduct.PinCode = productDto.PinCode;
            // We do not have enough information fo fill the CanExport property correctly.
            // // But it will be equals to true for most of cases. So we always set it to true.
            formProduct.CanExport = true;

            var product = await _context.Products
                .SingleOrExceptionAsync(x => x.Id == productDto.GsvsId, cancellationToken);
            formProduct.FillProduct(product);
            await FillGsvsCodeAsync(formProduct, cancellationToken);

            var measureUnit = await _sharedModuleContract.GetMeasureUnitByIdAsync(productDto.MeasureUnitId, cancellationToken);
            formProduct.FillMeasureUnit(measureUnit);
        }
    }
}
