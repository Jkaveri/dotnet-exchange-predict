namespace System.Net.Http
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient client, string url, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await client.GetAsync(url, cancellationToken).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

           
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
