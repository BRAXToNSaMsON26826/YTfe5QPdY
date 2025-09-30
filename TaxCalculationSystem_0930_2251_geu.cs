// 代码生成时间: 2025-09-30 22:51:08
 * 作者: [你的名字]
 * 日期: [创建日期]
 */

using System;

namespace TaxCalculationSystem
{
    // 定义一个接口，用于定义税务计算的具体方法
    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal income);
    }

    // 实现ITaxCalculator接口的具体税务计算类
    public class SimpleTaxCalculator : ITaxCalculator
    {
        private readonly decimal taxRate;

        // 构造函数，初始化税率
        public SimpleTaxCalculator(decimal taxRate)
        {
            this.taxRate = taxRate;
        }

        // 计算税款
        public decimal CalculateTax(decimal income)
        {
            if (income < 0)
            {
                throw new ArgumentException("收入不能为负数。");
            }
            return income * taxRate;
        }
    }

    // 客户端使用税务计算系统的类
    public class TaxCalculationClient
    {
        private ITaxCalculator taxCalculator;

        public TaxCalculationClient(ITaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        // 计算并返回税款
        public decimal ComputeTax(decimal income)
        {
            try
            {
                return taxCalculator.CalculateTax(income);
            }
            catch (ArgumentException ex)
            {
                // 处理错误情况，例如负收入
                Console.WriteLine($"错误：{ex.Message}");
                return 0;
            }
        }
    }

    // 应用程序入口点
    class Program
    {
        static void Main(string[] args)
        {
            // 创建税务计算器实例，假设税率为10%
            ITaxCalculator taxCalculator = new SimpleTaxCalculator(0.10m);

            // 创建税务计算客户端
            TaxCalculationClient client = new TaxCalculationClient(taxCalculator);

            // 计算税款，假设收入为5000
            decimal taxAmount = client.ComputeTax(5000);

            // 输出税款计算结果
            Console.WriteLine($"税款金额为：{taxAmount}");
        }
    }
}