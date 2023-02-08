using ExamenEasyShop.Commands;
using ExamenEasyShop.Configuration;

namespace ExamenEasyShop.CommandHandler
{
    public class RemoveProductCommandHandler: ICommandHandler<RemoveByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Execute(RemoveByIdCommand product)
        {
            _unitOfWork.ProductRepository.Delete(product.Id);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Product removed succesfully" };
        }
    }
}
