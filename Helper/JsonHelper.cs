using System.Text.Json;

namespace Lesson_6.Helper;

public static class JsonHelper
{
    public static JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
    };

    public static void SaveToJson<T>(List<T> data, string filePath)
    {
        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, json);
    }

    public static List<T> LoadFromJson<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}
