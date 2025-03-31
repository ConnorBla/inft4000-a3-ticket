using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using TicketHub.Models;

namespace TicketHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IConfiguration _configuration;

        public PurchaseController(ILogger<PurchaseController> logger, IConfiguration configuration)
        {
            Console.WriteLine("Got here");
            _logger = logger;
            _configuration = configuration;
        }


        /// <summary>
        /// Adds a message to the purchase queue.
        /// </summary>
        /// <returns>A confirmation message.</returns>
        [HttpPost]
        //public async Task<IActionResult> Post()
        public async Task<IActionResult> Post(CustomerPurchase purchase)
        {
            if (purchase == null)
            {
                return BadRequest("Payload is missing.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            string queueName = "purchase";
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (String.IsNullOrEmpty(connectionString))
            {
                return BadRequest("Bad Connection String");
            }

            QueueClient qc = new QueueClient(connectionString, queueName);

            string message = JsonSerializer.Serialize(purchase);

            await qc.SendMessageAsync(message);

            return Ok("Thanks " + purchase.Name.Split(' ')[0] + ", your purchase has been added to the queue!");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from the PurchaseController!");
        }
    }
}
