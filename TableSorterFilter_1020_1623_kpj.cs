// 代码生成时间: 2025-10-20 16:23:10
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to perform sorting and filtering on a table-like data structure.
/// </summary>
public class TableSorterFilter
# NOTE: 重要实现细节
{
    /// <summary>
    /// Sorts the provided list of items based on the specified property.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="items">The list of items to sort.</param>
    /// <param name="sortProperty">The property of the items to sort by.</param>
# FIXME: 处理边界情况
    /// <param name="order">The sorting order (ascending or descending).</param>
# TODO: 优化性能
    public void Sort<T>(List<T> items, string sortProperty, bool order = true) where T : class
    {
        if (items == null)
        {
            Debug.LogError("Cannot sort null list.");
            return;
        }
# 改进用户体验

        // Perform sorting using reflection to dynamically access the property.
        try
        {
            var propertyInfo = typeof(T).GetProperty(sortProperty);
            if (propertyInfo == null)
# 添加错误处理
            {
                Debug.LogError($"Property '{sortProperty}' not found.");
                return;
            }

            items.Sort((a, b) => order ? Comparer.Default.Compare(propertyInfo.GetValue(a), propertyInfo.GetValue(b)) : Comparer.Default.Compare(propertyInfo.GetValue(b), propertyInfo.GetValue(a)));
        }
        catch (Exception e)
        {
# TODO: 优化性能
            Debug.LogError($"Error sorting list: {e.Message}");
        }
    }

    /// <summary>
    /// Filters the provided list of items based on the specified property and value.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    /// <param name="items">The list of items to filter.</param>
    /// <param name="filterProperty">The property of the items to filter by.</param>
    /// <param name="filterValue">The value to filter the items against.</param>
    public void Filter<T>(List<T> items, string filterProperty, object filterValue) where T : class
# 增强安全性
    {
        if (items == null)
# 增强安全性
        {
            Debug.LogError("Cannot filter null list.");
            return;
        }

        // Perform filtering using reflection to dynamically access the property.
        try
        {
            var propertyInfo = typeof(T).GetProperty(filterProperty);
            if (propertyInfo == null)
            {
                Debug.LogError($"Property '{filterProperty}' not found.");
# 改进用户体验
                return;
            }

            var filteredItems = new List<T>();
            foreach (var item in items)
            {
# 优化算法效率
                if (propertyInfo.GetValue(item)?.Equals(filterValue) == true)
                {
                    filteredItems.Add(item);
                }
            }

            items.Clear();
# TODO: 优化性能
            items.AddRange(filteredItems);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error filtering list: {e.Message}");
        }
    }
}
# FIXME: 处理边界情况
