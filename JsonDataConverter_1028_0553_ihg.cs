// 代码生成时间: 2025-10-28 05:53:48
using System;
using UnityEngine;
using Newtonsoft.Json;

// JsonDataConverter 类负责将 JSON 数据格式进行转换
public class JsonDataConverter
{
    // 使用 Newtonsoft.Json 库进行 JSON 数据的转换
    private readonly JsonSerializerSettings _settings;

    // 构造函数，设置 JSON 序列化和反序列化的默认配置
    public JsonDataConverter()
    {
        _settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented, // 设置格式化输出
            NullValueHandling = NullValueHandling.Ignore // 忽略空值
        };
    }

    // 将对象转换为 JSON 字符串
    public string ConvertToJson(object data)
    {
        try
        {
            return JsonConvert.SerializeObject(data, _settings);
        }
        catch (JsonSerializationException e)
        {
            Debug.LogError($"Failed to serialize to JSON: {e.Message}");
            return null;
        }
    }

    // 将 JSON 字符串转换为指定类型的对象
    public T ConvertFromJson<T>(string jsonData)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(jsonData, _settings);
        }
        catch (JsonSerializationException e)
        {
            Debug.LogError($"Failed to deserialize from JSON: {e.Message}");
            return default;
        }
    }

    // 示例：使用 JsonDataConverter 将对象转换为 JSON 字符串
    public void ExampleUsage()
    {
        // 创建一个示例对象
        var exampleObject = new
        {
            Name = "John Doe",
            Age = 30
        };

        // 将对象转换为 JSON 字符串
        var jsonString = ConvertToJson(exampleObject);

        // 输出 JSON 字符串
        Debug.Log(jsonString);

        // 将 JSON 字符串转换回对象
        var deserializedObject = ConvertFromJson<dynamic>(jsonString);

        // 输出反序列化后的对象属性
        Debug.Log(deserializedObject.Name);
        Debug.Log(deserializedObject.Age);
    }
}
