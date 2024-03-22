using System.Text.Json;

namespace WrapperDivinePride.Extensions;

public static class JsonExtension
{
    private static JsonSerializerOptions SerializerOptions => new() { PropertyNameCaseInsensitive = true };

    public static string ToJson(this object value) => JsonSerializer.Serialize(value);

    public static T FromJson<T>(this string value) where T : class => JsonSerializer.Deserialize<T>(value, SerializerOptions);
}