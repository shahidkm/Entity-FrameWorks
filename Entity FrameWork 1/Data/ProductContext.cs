using Microsoft.EntityFrameworkCore;
using Entity_FrameWork_1.Models;

namespace Entity_FrameWork_1.Data
{
    public class ProductContext : DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }


}
