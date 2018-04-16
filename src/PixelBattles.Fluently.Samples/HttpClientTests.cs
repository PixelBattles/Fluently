using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace PixelBattles.Fluently.Samples
{
    public class HttpClientTests : FlowTest
    {
        public HttpClientTests()
        {
            Context
                .Setup(new HttpClient())
                .With(c => c.BaseAddress = new Uri("http://example.com/"))
                .With(c => c.Timeout = TimeSpan.FromSeconds(30))
                .Save()
                .Continue();
        }

        [Fact]
        public void HttpGetRequest_To_ExampleCom_Return_OK()
        {
            Context
                .Get<HttpClient>()
                .Transform(client => client.GetAsync(String.Empty).Result)
                .Save()
                .Continue()
                .Assert().Equals(c => c.Get<HttpResponseMessage>().Value.IsSuccessStatusCode, true)
                .Assert().Equals(c => c.Get<HttpResponseMessage>().Value.StatusCode, HttpStatusCode.OK);
        }

        [Fact]
        public void HttpPostRequest_To_ExampleCom_Return_OK()
        {
            Context
                .Get<HttpClient>()
                .Transform(client => client.PostAsync(String.Empty, new StringContent("test")).Result)
                .Save()
                .Continue()
                .Assert().Equals(c => c.Get<HttpResponseMessage>().Value.IsSuccessStatusCode, true)
                .Assert().Equals(c => c.Get<HttpResponseMessage>().Value.StatusCode, HttpStatusCode.OK);
        }
    }
}
