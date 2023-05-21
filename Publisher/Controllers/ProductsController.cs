using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        private readonly ILogger<ProductsController> _logger;
        private const string ProductTopic = "product-topic";

        public ProductsController(IAmazonSimpleNotificationService snsClient, ILogger<ProductsController> logger)
        {
            _snsClient = snsClient;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            //perform product request validation
            //save incoming product to database

            //create message
            var message = new ProductCreatedNotification(request.Id, request.Name, request.Description);

            //check if product topic already exists
            var topicArnExists = await _snsClient.FindTopicAsync(ProductTopic);

            //extract the topic arn of the sns topic
            //if the topic is not found, create a new topic
            string topicArn = "";
            if (topicArnExists == null)
            {
                var createTopicResponse = await _snsClient.CreateTopicAsync(ProductTopic);
                topicArn = createTopicResponse.TopicArn;
            }
            else
            {
                topicArn = topicArnExists.TopicArn;
            }

            //create and publish a new message to the sns topic arn
            var publishRequest = new PublishRequest()
            {
                TopicArn = topicArn,
                Message = JsonSerializer.Serialize(message),
                Subject = "ProductCreated"
            };
            _logger.LogInformation("Publish Request with the subject : " +
                "{subject}' and message: {message}", publishRequest.Subject, publishRequest.Message);

            //publishRequest.MessageAttributes.Add("Scope", new MessageAttributeValue()
            //{
            //    DataType = "String",
            //    StringValue = "Email"
            //});

            await _snsClient.PublishAsync(publishRequest);
            return Ok();
        }
    }
}
