using MediatR;

namespace TCO.SNT.UseCases.Products.Commands.AddFavoriteProduct
{
    public class AddFavoriteProductCommand : IRequest
    {
        public AddFavoriteProductCommand(string code)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
