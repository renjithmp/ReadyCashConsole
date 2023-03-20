using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCore.Actions;
using CustomerCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerActions customerActions;
        [HttpPost(Name = "CreateCustomer")]
        public void Create(Customer customer)
        {
            customerActions.Add(customer);

        }
    }
}
