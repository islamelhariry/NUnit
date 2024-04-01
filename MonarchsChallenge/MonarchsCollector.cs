using System.Text.Json;

namespace MonarchsChallenge;

/// TODO: There should be some interface that this class is implementing
/// and the implementation would defer according to the database
/// This are needs to be tested more because it's dealing with the interface of the API
internal class MonarchsCollector
{
    private readonly IHttpClient _client;
    
    //TODO: This is better be passed instead of being hardcoded here
    private const string Url =
        "https://gist.githubusercontent.com/christianpanton/10d65ccef9f29de3acd49d97ed423736/raw/b09563bc0c4b318132c7a738e679d4f984ef0048/kings";

    public MonarchsCollector(IHttpClient client)
    {
        _client = client;
    }

    public async Task<Monarch[]> GetMonarchs()
    {
        using var responseMessage = await _client.GetAsync(Url);

        if (responseMessage.IsSuccessStatusCode is false)
        {
            throw new Exception("failed to collect data");
        }

        var response = await responseMessage.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Monarch[]>(response);

        if (result is null)
        {
            throw new ArgumentNullException(response);
        }

        return result;
    }
}