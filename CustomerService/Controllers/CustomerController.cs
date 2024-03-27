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
    /// <summary>
    /// Represents a controller for managing customer-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerActions _customerActions;

        public CustomerController(CustomerActions customerActions)
        {
            _customerActions = customerActions;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="customer">The customer object to be created.</param>
        [HttpPost(Name = "CreateCustomer")]
        public void Create(Customer customer)
        {
            _customerActions.Add(customer);
        }
    }
}
