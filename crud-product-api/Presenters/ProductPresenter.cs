using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using crud_product_api.Dto;
using crud_product_domain.Entities;
using crud_product_domain.UseCases;

namespace crud_product_api.Presenters
{
    public class ProductPresenter
    {
        private readonly GetAllProducts _getAllProducts;
        private readonly GetProductByCode _getProductByCode;
        private readonly CreateProduct _createProduct;
        private readonly DeleteProduct _deleteProduct;
        private readonly EditProduct _editProduct;
        private readonly IMapper _mapper;

        public ProductPresenter(GetAllProducts getAllProducts, GetProductByCode getProductByCode,
            CreateProduct createProduct, DeleteProduct deleteProduct, EditProduct editProduct, IMapper mapper)
        {
            _getAllProducts = getAllProducts;
            _getProductByCode = getProductByCode;
            _createProduct = createProduct;
            _deleteProduct = deleteProduct;
            _editProduct = editProduct;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            IEnumerable<Product> products = await _getAllProducts.Execute();
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetProductByCode(int code)
        {
            Product product = await _getProductByCode.Execute(code);
            ProductDto productDto = _mapper.Map<Product, ProductDto>(product);
            return productDto;
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            await _createProduct.Execute(product);
        }

        public Task DeleteProduct(int code)
        {
            return _deleteProduct.Execute(code);
        }

        public void EditProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _editProduct.Execute(product);
        }
    }
}
