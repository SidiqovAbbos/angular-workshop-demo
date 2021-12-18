using DemoBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public CustomerController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return appDbContext.Set<Customer>().Include(d => d.Company);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = appDbContext.Set<Customer>().SingleOrDefault(x => x.Id == id);
            return Ok(item);
        }

        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            appDbContext.Add(customer);
            appDbContext.SaveChanges();
            return customer;
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Customer customer)
        {
            var existingCustomer = appDbContext.Set<Customer>().FirstOrDefault(s => s.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                existingCustomer.Phone = customer.Phone;
                var company = appDbContext.Set<Company>().FirstOrDefault(s => s.Id == customer.CompanyId);
                if (company != null)
                {
                    existingCustomer.Company = company;
                }
                appDbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(existingCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomer = appDbContext.Set<Customer>().FirstOrDefault(s => s.Id == id);
            if (existingCustomer != null)
            {
                appDbContext.Remove(existingCustomer);
                appDbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
