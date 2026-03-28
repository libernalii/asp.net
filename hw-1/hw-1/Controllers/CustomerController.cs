using Microsoft.AspNetCore.Mvc;
namespace hw_1.Controllers
{


    [ApiController]
    [Route("api/v1/customers")]
    public class CustomersController : ControllerBase
    {
        private static Customer[] _customers = new Customer[]
        {
            new Customer { Id = 1, Name = "Anna", BirthDate = new DateTime(1999, 5, 10) },
            new Customer { Id = 2, Name = "Oleh", BirthDate = new DateTime(2002, 3, 15) },
            new Customer { Id = 3, Name = "Maria", BirthDate = new DateTime(2005, 7, 1) }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customers.OrderBy(c => c.Name);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("after2000")]
        public IActionResult GetAfter2000()
        {
            var result = _customers
                .Where(c => c.BirthDate.Year > 2000);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            var list = _customers.ToList();
            customer.Id = list.Max(c => c.Id) + 1;

            list.Add(customer);
            _customers = list.ToArray();

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customersList = _customers.ToList();

            var customer = customersList.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customersList.Remove(customer);
            _customers = customersList.ToArray();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var customersList = _customers.ToList();

            var customer = customersList.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customer.Name = updatedCustomer.Name;
            customer.BirthDate = updatedCustomer.BirthDate;

            _customers = customersList.ToArray();

            return Ok(customer);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}


