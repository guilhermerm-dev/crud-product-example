using System.Collections.Generic;
using crud_product_api.Dto;
using crud_product_api.Presenters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_product_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ProductPresenter _productPresenter;

        public ProductController(ProductPresenter productPresenter)
        {
            _productPresenter = productPresenter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(_productPresenter.GetAllProducts());
        }

        [HttpGet("{code:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ProductDto GetProductByCode(int code)
        {
            return _productPresenter.GetProductByCode(code);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateProduct([FromBody] ProductDto product)
        {
            _productPresenter.CreateProduct(product);
            return CreatedAtAction("CreateProduct - Post", product);
        }

        [HttpDelete("{code:int}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteProduct(int code)
        {
            _productPresenter.DeleteProduct(code);
            return Ok($"Product code: {code} has been deleted");
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult EditProduct([FromBody] ProductDto product)
        {
            _productPresenter.EditProduct(product);
            return Ok($"Product {product.Name} has been updated");
        }
    }
}
