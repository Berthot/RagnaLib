using WrapperDivinePride.Extensions;

namespace WrapperDivinePride.Wrappers;

public class DivinePrideRepository
{
    private readonly HttpClient _client;
    private const string ApiKey = "a7b51c0e03758da5942c71076cb2b46b";
    private const string BaseUrl = "https://www.divine-pride.net/api/database/";
    // private const string BaseUrl = "--header 'Cookie: ASP.NET_SessionId=tsade0k4bv52wotxyghvi5hk'";

    public DivinePrideRepository()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("pt-BR");
    }

    public async Task<T> GetById<T>(int id, ESearchType type = ESearchType.Monster) where T : class
    {
        var uri = RequestUri(id, type);
        _client.DefaultRequestHeaders.Add("Cookie", "ASP.NET_SessionId=tsade0k4bv52wotxyghvi5hk");
        _client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR");
        var response = await _client.GetAsync(uri);
        var content = await response.Content.ReadAsStringAsync();
        return content.FromJson<T>();
    }

    private static string RequestUri(int id, ESearchType type)
    {
        return $"{BaseUrl}{type.ToString("G")}/{id}?apiKey={ApiKey}&server=bRO";
    }
}

public enum ESearchType
{
    Monster = 1,
    Item = 2
}