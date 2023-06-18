using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Cike.Scheduler.EntityFrameworkCore.Convertions;

public class JsonValueConverter<T> : ValueConverter<T, string> where T : class, new()
{
    public JsonValueConverter()
        : base(x => SerializeObject(x), x => DeserializeObject(x))
    {

    }

    private static string SerializeObject(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    private static T DeserializeObject(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return new T();
        }

        return JsonSerializer.Deserialize<T>(json)!;
    }
}
