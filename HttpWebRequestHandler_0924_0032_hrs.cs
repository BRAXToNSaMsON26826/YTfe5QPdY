// 代码生成时间: 2025-09-24 00:32:39
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Handles HTTP requests and responses using Unity and C#.
/// </summary>
public class HttpWebRequestHandler
{
    /// <summary>
    /// Sends an HTTP GET request to the specified URL.
    /// </summary>
    /// <param name="url">The URL to send the request to.</param>
    /// <returns>A string containing the response from the server.</returns>
    public async Task<string> GetAsync(string url)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        catch (WebException e)
        {
            Debug.LogError($"WebRequestException: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// Sends an HTTP POST request to the specified URL with JSON data.
    /// </summary>
    /// <param name="url">The URL to send the request to.</param>
    /// <param name="jsonData">The JSON data to send in the request body.</param>
    /// <returns>A string containing the response from the server.</returns>
    public async Task<string> PostAsync(string url, string jsonData)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                await streamWriter.WriteAsync(jsonData);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        catch (WebException e)
        {
            Debug.LogError($"WebRequestException: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// Example usage of the HttpWebRequestHandler class.
    /// </summary>
    public void ExampleUsage()
    {
        HttpWebRequestHandler handler = new HttpWebRequestHandler();
        string url = "http://example.com/api/data";
        string jsonData = "{"key": "value"}";

        // Send a GET request
        handler.GetAsync(url).ContinueWith(t =>
        {
            string response = t.Result;
            Debug.Log($"GET Response: {response}");
        });

        // Send a POST request
        handler.PostAsync(url, jsonData).ContinueWith(t =>
        {
            string response = t.Result;
            Debug.Log($"POST Response: {response}");
        });
    }
}
