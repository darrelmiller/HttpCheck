using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace HttpCheckApi
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return new ResponseMessageResult(new HttpResponseMessage()
            {
                Content = new StringContent("Hello World v2", Encoding.UTF8,"text/plain")
            });
        }
    }

 public class EchoController : ApiController
    {
        public async Task<HttpResponseMessage> Post()
        {
            await Request.Content.LoadIntoBufferAsync();

            return new HttpResponseMessage() {Content = Request.Content};
        }
    }

public class AuthController : ApiController
{
    public async Task<HttpResponseMessage> Get()
    {
            string body = "Security info: " + Environment.NewLine;
            if (Request.Headers.Authorization != null)
            {
                body = Request.Headers?.Authorization.ToString() + Environment.NewLine;
            }
            if (this.User != null)
            {
                body += JsonConvert.SerializeObject(User);

                var claims = this.User.Identity as ClaimsIdentity;

                if (claims != null)
                {
                    body += JsonConvert.SerializeObject(claims);
                }
            }

        return new HttpResponseMessage() { Content = new StringContent(body) };
    }
}

}
