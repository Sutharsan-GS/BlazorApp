
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }


       
        [HttpGet]
        [Route("api/Get")]
        public async Task<ActionResult<List<People>>> Get()
        {

            return (await _db.People.ToListAsync()).OrderBy(a => a.Id).ToList();
        }


        [HttpPost]
        [Route("api/Add")]
        public  void AddPeople([FromBody] People NewObj)
        {
            _db.People.Add(NewObj);
             _db.SaveChanges();
        }


        [HttpPut]
        [Route("api/Update")]
        public void UpdatePeople([FromBody] People Obj)
        {
             _db.People.Update(Obj);
             _db.SaveChanges();
        }


        [HttpDelete]
        [Route("api/Delete/{id}")]
        public  void DeletePeople(int id)
        {
            var entity = _db.People.First(t => t.Id == id);
            _db.People.Remove(entity);
             _db.SaveChanges();
        }
    }
}