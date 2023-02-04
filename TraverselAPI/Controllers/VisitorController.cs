using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraverselAPI.DAL.Context;
using TraverselAPI.DAL.Entities;

namespace TraverselAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        //private readonly VisitorContext _context;

        //public VisitorController(VisitorContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            using (var _context = new VisitorContext())
            {
                var model = _context.Visitors.ToList();
                return Ok(model);
            }
        }
        [HttpPost]
        public IActionResult Post(Visitor visitor)
        {
            using (var _context = new VisitorContext())
            {
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Find(Guid id)
        {
            using (var _context = new VisitorContext())
            {
                var model = _context.Visitors.Find(id);
                if (model!=null)
                {
                    return Ok(model);
                }
                else
                {
                   return NotFound();
                    
                }
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Visitor visitor)
        {
            using (var _context = new VisitorContext())
            {
                _context.Visitors.Update(visitor);
                _context.SaveChanges();
                return NoContent();
            }
            
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            using (var _context = new VisitorContext())
            {
                var model = _context.Visitors.Find(id);
                if (model!=null)
                {
                    _context.Visitors.Remove(model);
                    _context.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return BadRequest();
                }
            }
            //var kayit = _service.Find(id);
            //if (kayit == null)
            //{
            //    return BadRequest();
            //}
            //_service.Delete(kayit);
            //_service.SaveChanges();
            //return StatusCode(StatusCodes.Status200OK);
        }
    }
}
