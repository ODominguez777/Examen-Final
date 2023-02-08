using ExamenEasyShop.Configuration;
using ExamenEasyShop.Models;

namespace ExamenEasyShop.CommandHandler
{

    public class UpdateProductCommandHandler : ICommandHandler<Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public CommandResult Execute(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Product updated succesfully" };
        }
    }
}
