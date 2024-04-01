namespace MonarchsChallenge;

internal interface IHttpClient
{
    public Task<HttpResponseMessage> GetAsync(string url);
}

internal class CustomClient : IHttpClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    //TODO: This function needs to implement exception handling
    public Task<HttpResponseMessage> GetAsync(string url) => _httpClient.GetAsync(url);
}