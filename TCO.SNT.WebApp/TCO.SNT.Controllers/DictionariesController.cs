using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Controllers;
using TCO.SNT.Common.Roles;
using TCO.SNT.UseCases.Country.GetCountry;
using TCO.SNT.UseCases.Country.GetFavouriteCountry;
using TCO.SNT.UseCases.Country.Shared;
using TCO.SNT.UseCases.Currency.Commands.ImportExchangeRates;
using TCO.SNT.UseCases.Currency.GetCurrency;
using TCO.SNT.UseCases.Currency.GetFavouriteCurrency;
using TCO.SNT.UseCases.Currency.Shared.Dto;
using TCO.SNT.UseCases.ErrorCode.Commands.ImportErrorCodes;
using TCO.SNT.UseCases.Products.Commands.AddFavoriteProduct;
using TCO.SNT.UseCases.Products.Commands.ImportGsvs;
using TCO.SNT.UseCases.Products.Queries.GetChildrenProducts;
using TCO.SNT.UseCases.Products.Queries.GetFavoriteProducts;
using TCO.SNT.UseCases.Products.Queries.SearchProducts;
using TCO.SNT.UseCases.Products.Queries.Shared;

namespace TCO.SNT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private readonly ISender _sender;

        public DictionariesController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get favorite gsvs items
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("gsvs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<FavoriteProductDto>> GetFavoriteProducts(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetFavoriteProductsQuery(), cancellationToken);
        }

        /// <summary>
        /// Add gsvs item to favorite
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("gsvs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task AddFavoriteProduct([Required] string code, CancellationToken cancellationToken)
        {
            return _sender.Send(new AddFavoriteProductCommand(code), cancellationToken);
        }

        /// <summary>
        /// Import gsvs
        /// </summary>
        // [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-gsvs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<int> ImportGsvs(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportGsvsCommand(), cancellationToken);
        }

        /// <summary>
        /// Get countries
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<CountryDto>> GetCountries(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetCountryQuery(), cancellationToken);
        }

        /// <summary>
        /// Get favourite countries
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("favourite-countries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<CountryDto>> GetFavouriteCountries(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetFavouriteCountryQuery(), cancellationToken);
        }

        /// <summary>
        /// Get currencies
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("currencies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<List<CurrencyDto>> GetCurrencies(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetCurrencyQuery(), cancellationToken);
        }

        /// <summary>
        /// Get favourite currencies
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("favourite-currencies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<CurrencyDto>> GetFavouriteCurrencies(CancellationToken cancellationToken)
        {
            return _sender.Send(new GetFavouriteCurrencyQuery(), cancellationToken);
        }

        /// <summary>
        /// Import exchange rates
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-exchange-rates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<ImportExchangeRatesResultDto> ImportExchangeRates(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportExchangeRatesCommand(), cancellationToken);
        }

        /// <summary>
        /// Import error codes
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.Admin })]
        [HttpPost("import-error-codes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public Task<ImportErrorCodesResultDto> ImportErrorCodes(CancellationToken cancellationToken)
        {
            return _sender.Send(new ImportErrorCodesCommand(), cancellationToken);
        }

        /// <summary>
        /// Get child products by parent id
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpPost("get-children-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<ProductDto>> GetChildrenProducts(long fixedId, CancellationToken cancellationToken)
        {
            return _sender.Send(new GetChildrenProductsQuery(fixedId), cancellationToken);
        }

        /// <summary>
        /// Search products
        /// </summary>
        [RoleAuthorize(RoleTypes = new RoleType[] { RoleType.SntOperator, RoleType.SntReadOnly, RoleType.TCOWarehouse })]
        [HttpGet("search-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public Task<IReadOnlyList<ProductDto>> SearchProducts([FromQuery] ProductFilter filter, CancellationToken cancellationToken)
        {
            return _sender.Send(new SearchProductsQuery(filter), cancellationToken);
        }
    }
}