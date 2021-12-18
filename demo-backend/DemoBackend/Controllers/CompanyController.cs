using DemoBackend.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DemoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public CompanyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return appDbContext.Set<Company>();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = appDbContext.Set<Company>().SingleOrDefault(x => x.Id == id);
            return Ok(item);
        }

        [HttpPost]
        public Company Post([FromBody] Company company)
        {
            appDbContext.Add(company);
            appDbContext.SaveChanges();
            return company;
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Company company)
        {
            var existingCompany = appDbContext.Set<Company>().FirstOrDefault(s => s.Id == id);
            if (existingCompany != null)
            {
                existingCompany.Name = company.Name;
                existingCompany.Website = company.Website;
                appDbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(existingCompany);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCompany = appDbContext.Set<Company>().FirstOrDefault(s => s.Id == id);
            if (existingCompany != null)
            {
                appDbContext.Remove(existingCompany);
                appDbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
