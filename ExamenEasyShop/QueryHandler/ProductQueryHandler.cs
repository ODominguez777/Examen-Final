using ExamenEasyShop.Commands;
using ExamenEasyShop.Configuration;
using ExamenEasyShop.Models;

namespace ExamenEasyShop.QueryHandler
{
    public class ProductQueryHandler: IQueryHandler<Product, QueryByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetOne(QueryByIdCommand query)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(query.Id);
        }
    }
}
