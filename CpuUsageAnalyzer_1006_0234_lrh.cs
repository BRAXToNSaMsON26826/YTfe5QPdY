// 代码生成时间: 2025-10-06 02:34:21
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// CPU Usage Analyzer for Unity applications.
/// </summary>
public class CpuUsageAnalyzer : MonoBehaviour
{
    /// <summary>
    /// The interval in seconds between CPU usage checks.
    /// </summary>
    private float checkInterval = 1.0f;

    /// <summary>
    /// The last CPU usage percentage.
    /// </summary>
    private float lastCpuUsage = 0.0f;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        // Initialize the CPU usage analysis.
        StartCoroutine(UpdateCpuUsage());
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Display the CPU usage in the Unity editor console.
        // This is for demonstration purposes only.
        // In a real application, you might want to display this in the UI.
        Debug.Log("Current CPU Usage: " + lastCpuUsage + "%");
    }

    /// <summary>
    /// Coroutine to update CPU usage at regular intervals.
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateCpuUsage()
    {
        while (true)
        {
            // Wait for the specified interval before checking CPU usage again.
            yield return new WaitForSeconds(checkInterval);

            try
            {
                // Get the current CPU usage from the system.
                lastCpuUsage = GetSystemCpuUsage();
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur while trying to get CPU usage.
                Debug.LogError("Failed to get CPU usage: " + ex.Message);
            }
        }
    }

    /// <summary>
    /// Gets the current CPU usage percentage.
    /// </summary>
    /// <returns>The current CPU usage percentage.</returns>
    private float GetSystemCpuUsage()
    {
        // This is a simplified example. In a real application,
        // you would need to calculate CPU usage based on actual system metrics.
        // For demonstration purposes, we are just returning a dummy value.
        float cpuUsage = Process.GetCurrentProcess().TotalProcessorTime.TotalMilliseconds / 1000.0f;
        // Normalize the value to a percentage.
        return cpuUsage / Environment.ProcessorCount * 100.0f;
    }
}
