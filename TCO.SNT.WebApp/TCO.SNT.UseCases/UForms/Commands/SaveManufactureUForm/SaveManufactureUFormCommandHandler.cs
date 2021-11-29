using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.UForms.Commands.Dto;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;

namespace TCO.SNT.UseCases.UForms.Commands.SaveManufactureUForm
{
    internal class SaveManufactureUFormCommandHandler : SaveUFormCommandHandlerBase,
        IRequestHandler<SaveManufactureUFormCommand, int>
    {
        private readonly ISharedModuleContract _sharedModuleContract;

        public SaveManufactureUFormCommandHandler(IDbContext context, IMapper mapper, IOptions<CompanyOptions> companyOptions, 
            UserAccessService userAccessService, ISharedModuleContract sharedModuleContract) 
            : base(context, mapper, companyOptions, userAccessService)
        {
            _sharedModuleContract = sharedModuleContract;
        }

        public Task<int> Handle(SaveManufactureUFormCommand request, CancellationToken cancellationToken)
        {
            return HandleBase(request.Form, cancellationToken);
        }

        protected override async Task MapUFormProductAsync(UForm form, UFormProductDtoBase productDtoBase, UFormProduct formProduct, CancellationToken cancellationToken)
        {
            var productDto = (ManufactureUFormProductDto)productDtoBase;

            formProduct.Name = productDto.Name;

            var product = await _context.Products
                .SingleOrExceptionAsync(x => x.Id == productDto.ProductId, cancellationToken);
            formProduct.FillProduct(product);
            await FillGsvsCodeAsync(formProduct, cancellationToken);

            var measureUnit = await _sharedModuleContract.GetMeasureUnitByIdAsync(productDto.MeasureUnitId, cancellationToken);
            formProduct.FillMeasureUnit(measureUnit);
        }
    }
}
