// 代码生成时间: 2025-10-27 15:44:31
using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// A helper class to analyze memory usage in a Unity application.
/// </summary>
public class MemoryAnalysis
{
    /// <summary>
    /// Logs the current memory usage of the application.
    /// </summary>
    public static void LogMemoryUsage()
    {
        try
        {
            // Get the process of the current application
            Process process = Process.GetCurrentProcess();

            // Log the non-managed memory size
            Debug.Log($"Non-managed memory size: {process.PrivateMemorySize64 / (1024.0 * 1024.0)} MB");

            // Log the managed memory size
            Debug.Log($"Managed memory size: {GC.GetTotalMemory(false) / (1024.0 * 1024.0)} MB");

            // Log the amount of memory currently in use
            Debug.Log($"Memory in use: {process.WorkingSet64 / (1024.0 * 1024.0)} MB");
        }
        catch (Exception ex)
        {
            // Handle exceptions that might occur during memory analysis
            Debug.LogError($"An error occurred while analyzing memory usage: {ex.Message}");
        }
    }

    /// <summary>
    /// Triggers a full garbage collection to clear unnecessary memory.
    /// </summary>
    public static void ForceGarbageCollection()
    {
        try
        {
            // Force a garbage collection to clean up unused objects
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Log the memory usage after garbage collection
            LogMemoryUsage();
        }
        catch (Exception ex)
        {
            // Handle exceptions that might occur during garbage collection
            Debug.LogError($"An error occurred while forcing garbage collection: {ex.Message}");
        }
    }
}
