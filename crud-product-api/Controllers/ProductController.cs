using System.Collections.Generic;
using AutoMapper;
using crud_product_api.Dto;
using crud_product_domain.Entities;
using crud_product_domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace crud_product_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly GetAllProducts _getAllProducts;
        private readonly GetProductByCode _getProductByCode;
        private readonly CreateProduct _createProduct;
        private readonly DeleteProduct _deleteProduct;
        private readonly EditProduct _editProduct;
        private readonly IMapper _mapper;

        public ProductController(GetAllProducts getAllProducts, GetProductByCode getProductByCode,
            CreateProduct createProduct, DeleteProduct deleteProduct, EditProduct editProduct, IMapper mapper)
        {
            _getAllProducts = getAllProducts;
            _getProductByCode = getProductByCode;
            _createProduct = createProduct;
            _deleteProduct = deleteProduct;
            _editProduct = editProduct;
            _mapper = mapper;
        }

        [HttpGet]
        public IList<ProductDto> GetAllProducts()
        {
            return _mapper.Map<IList<Product>, IList<ProductDto>>(_getAllProducts.Execute());
        }

        [HttpGet("{code}")]
        public ProductDto GetProductByCode(int code)
        {
            return _mapper.Map<Product, ProductDto>(_getProductByCode.Execute(code));
        }

        [HttpPost]
        public void CreateProduct([FromBody] ProductDto product)
        {
            _createProduct.Execute(_mapper.Map<ProductDto, Product>(product));
        }

        [HttpDelete("{code}")]
        public void DeleteProduct(int code)
        {
            _deleteProduct.Execute(code);
        }

        [HttpPut]
        public void EditProduct([FromBody] ProductDto product)
        {
            _editProduct.Execute(_mapper.Map<ProductDto, Product>(product));
        }
    }
}
