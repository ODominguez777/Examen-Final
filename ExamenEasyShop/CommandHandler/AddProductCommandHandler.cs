using ExamenEasyShop.Configuration;
using ExamenEasyShop.DTOs;
using ExamenEasyShop.Models;

namespace ExamenEasyShop.CommandHandler
{
    public class AddProductCommandHandler : ICommandHandler<ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Execute(ProductDTO product)
        {
            var newProduct = new Product()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                CountInStock = product.CountInStock,
                ImageURL = product.ImageURL,
                Rating = product.Rating,
            };
            _unitOfWork.ProductRepository.Add(newProduct);
            _unitOfWork.Commit();
            return new CommandResult { Status = true, Message = "Product added succesfully" };
        }


    }
}
