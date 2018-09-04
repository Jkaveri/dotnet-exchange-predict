namespace ExchangePredict.Tests.Helpers
{
    using Moq;
    using Moq.Protected;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HttpClientMockHelper
    {
        public static HttpClient CreateHttpClient(string content)
        {
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content)
            };

            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            var httpClient = new HttpClient(mockHandler.Object);

            return httpClient;
        }
    }
}
