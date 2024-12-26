using Microsoft.EntityFrameworkCore;
using Entity_FrameWork_1.Models;

namespace Entity_FrameWork_1.Data
{
    public class WorkerContext :    DbContext
    {

        public WorkerContext(DbContextOptions<WorkerContext> options) : base(options) { }


        public DbSet<Worker> Workers { get; set; }


    }
}
