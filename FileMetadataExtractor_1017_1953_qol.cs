// 代码生成时间: 2025-10-17 19:53:42
using System;
using System.IO;
using UnityEngine;

/// <summary>
/// 文件元数据提取器 - 提取文件的元数据信息
/// </summary>
public class FileMetadataExtractor : MonoBehaviour 
{

    /// <summary>
    /// 提取文件的元数据信息
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns>文件元数据信息，如果文件不存在或有其他错误，则返回null</returns>
    public FileInfo ExtractMetadata(string filePath) 
    {
        try 
        {
            // 检查文件是否存在
            if (!File.Exists(filePath)) 
            {
                Debug.LogError("File does not exist: " + filePath); 
                return null; 
            }

            // 创建FileInfo对象
            FileInfo fileInfo = new FileInfo(filePath);

            // 返回文件信息
            return fileInfo; 
        } 
        catch (Exception e) 
        {
            // 错误处理
            Debug.LogError("Error extracting metadata: " + e.Message); 
            return null; 
        } 
    }

    /// <summary>
    /// 打印文件的元数据信息
    /// </summary>
    /// <param name="filePath">文件路径</param>
    public void PrintMetadata(string filePath) 
    {
        FileInfo fileInfo = ExtractMetadata(filePath);
        if (fileInfo != null) 
        {
            Debug.Log("File Name: " + fileInfo.Name); 
            Debug.Log("File Size: " + fileInfo.Length + " bytes"); 
            Debug.Log("File Creation Time: " + fileInfo.CreationTime); 
            Debug.Log("File Last Access Time: " + fileInfo.LastAccessTime); 
            Debug.Log("File Last Write Time: " + fileInfo.LastWriteTime); 
        } 
    }

    // 可以在Unity编辑器中调用此方法进行测试
    private void Start() 
    {
        string testFilePath = "Assets/UnityProject.txt"; // 替换为实际测试文件路径
        PrintMetadata(testFilePath); 
    }
}
