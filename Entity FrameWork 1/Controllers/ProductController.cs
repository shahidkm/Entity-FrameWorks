using Entity_FrameWork_1.Data;
using Entity_FrameWork_1.DTO;
using Entity_FrameWork_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_FrameWork_1.Controllers
{
    [Route("controller")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }


        [HttpPost("add_new")]
        public async Task<ActionResult<string>> AddProduct(Product product)
        {
             _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok("success");
        }


        [HttpGet("products")]

        public ActionResult GetProducts()
        {
            var x = _context.Products.ToList();
            return Ok(x);
        }

        [HttpGet("{Id}")]

        public ActionResult FilterProduct(int Id)
        {
            var c = _context.Products.Where(n => n.Id == Id).ToList();
            return Ok(c);
        }

        [HttpPatch("updatae")]

        public  ActionResult UpdateData(int Id,Product product)
        {
         var exixtingProduct=_context.Products.FirstOrDefault(n => n.Id == Id);
            if (exixtingProduct==null)
            {
                return BadRequest("there is no Product");
            }
            if (!String.IsNullOrEmpty(product.Name))
            {
                exixtingProduct.Name = product.Name;
            }

            if (product.Price != 0)
            {
                exixtingProduct.Price = product.Price;
            }
                

                

            try
            {
                _context.SaveChanges();
                return Ok("SUCCESS");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }
        [HttpDelete("delete")]
        public ActionResult DeleteData(int Id)
        {
            var g = _context.Products.FirstOrDefault(n => n.Id == Id);
            _context.Products.Remove(g);
            _context.SaveChanges();
            return Ok("SUCESS");
            

        }

        [HttpGet("DTO")]

        public ActionResult Get(int Id)
        {

            var product = _context.Products.FirstOrDefault(n => n.Id == Id);
            var productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(productDto);
        }


    }
}
