using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ServiceBusDemo.Controllers
{

    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Note { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBusController : ControllerBase
    {
        readonly IConfiguration _configuration;
        public ServiceBusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync([FromBody] EmployeeModel employee)
        {
            string connectionString = _configuration.GetValue<string>("ServiceBusSettings:ConnectionString");
            string queueName = _configuration.GetValue<string>("ServiceBusSettings:QueueName");
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            string body = JsonConvert.SerializeObject(employee); 
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);
            return Ok("Message sent to the Service Bus queue successfully");
        }


    }
}