using System.Collections.Generic;
using System.Threading.Tasks;
using crud_product_api.Dto;
using crud_product_api.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace crud_product_api.Controllers
{
    [EnableCors]
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var result = await _productPresenter.GetAllProducts();
            if (result.Count() > 0)
                return Ok(result);

            return NotFound("No datas have been founded");
        }

        [HttpGet("{code:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ProductDto>> GetProductByCode(int code)
        {
            var result = await _productPresenter.GetProductByCode(code);
            if (result != null)
                return Ok(result);

            return NotFound("No datas have been founded");
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto product)
        {
            await _productPresenter.CreateProduct(product);
            return CreatedAtAction("CreateProduct", product);
        }

        [HttpDelete("{code:int}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteProduct(int code)
        {
            await _productPresenter.DeleteProduct(code);
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
