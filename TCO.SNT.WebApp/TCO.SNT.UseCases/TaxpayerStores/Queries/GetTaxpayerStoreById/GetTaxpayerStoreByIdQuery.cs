using MediatR;

namespace TCO.SNT.UseCases.TaxpayerStores.Queries.GetTaxpayerStoreById
{
    public class GetTaxpayerStoreByIdQuery : IRequest<TaxpayerStoreDto>
    {
        public GetTaxpayerStoreByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
