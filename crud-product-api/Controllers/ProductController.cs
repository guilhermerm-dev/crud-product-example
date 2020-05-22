using System.Collections.Generic;
using crud_product_api.Dto;
using crud_product_api.Presenters;
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
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(_productPresenter.GetAllProducts());
        }

        [HttpGet("{code:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<ProductDto> GetProductByCode(int code)
        {
            return Ok(_productPresenter.GetProductByCode(code));
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult CreateProduct([FromBody] ProductDto product)
        {
            _productPresenter.CreateProduct(product);
            return CreatedAtAction("CreateProduct", product);
        }

        [HttpDelete("{code:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public ActionResult DeleteProduct(int code)
        {
            _productPresenter.DeleteProduct(code);
            return Ok($"Product code: {code} has been deleted");
        }

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public ActionResult EditProduct([FromBody] ProductDto product)
        {
            _productPresenter.EditProduct(product);
            return NoContent();
        }
    }
}
