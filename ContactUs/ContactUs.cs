using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;

namespace ContactUs
{
    public static class ContactUs
    {
        [FunctionName("contact-us")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req, 
            [DocumentDB("hackfest", "contact-us")] IAsyncCollector<dynamic> document,
            [SendGrid] IAsyncCollector<Mail> message,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");



            var form = await req.Content.ReadAsAsync<Form>();
            var email = new Mail(new Email("no-reply@captechconsulting.com"), "Test", new Email(form.Email), 
                new Content("text/plain", $"{form.FirstName} {form.LastName}, thank you for your submission"));
            await message.AddAsync(email);

            await document.AddAsync(form);
            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
