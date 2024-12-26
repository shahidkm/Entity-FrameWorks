using Entity_FrameWork_1.Data;
using Microsoft.AspNetCore.Mvc;
using Entity_FrameWork_1.Models;

namespace Entity_FrameWork_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {

        private readonly WorkerContext _workerContext;
        public WorkerController(WorkerContext workerContext)
        {
            _workerContext = workerContext;
        }


        [HttpPost("Add")]
        public ActionResult Add(Worker worker)
        {
            _workerContext.Workers.Add(worker);
            _workerContext.SaveChanges();
            return Ok("SUCCESSFULL");
        }

        [HttpGet("get")]
          
        public ActionResult Get(int Id)
        {
            var x = _workerContext.Workers.FirstOrDefault(x => x.Id == Id);
            return Ok(x);
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var all = _workerContext.Workers.ToList();
            return Ok(all);
        }


        [HttpDelete("Id")]

        public ActionResult Delete(int Id)
        {
            var d = _workerContext.Workers.FirstOrDefault(n => n.Id == Id);
            _workerContext.Workers.Remove(d);
            _workerContext.SaveChanges();
            return Ok("Successfully deleted");
        }


        [HttpPatch("update")]

        public ActionResult Update(Worker worker,int Id)
        {
            var Z = _workerContext.Workers.FirstOrDefault(n => n.Id == Id);
            Z.Name = worker.Name;
            Z.Wage = worker.Wage;
            _workerContext.SaveChanges();
            return Ok(Z);
        }
    }
}
