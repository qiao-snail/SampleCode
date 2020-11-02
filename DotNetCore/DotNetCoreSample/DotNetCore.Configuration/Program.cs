using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace DotNetCore.Configuration
{
    /*
     * DotNetCore的配置，主要对象就是ConfigurationBuilder，该对象通过Add方法添加数据源，通过Build方法创建IConfiguration对象，将数据和对象关联
     */
    class Program
    {
        static void Main(string[] args)
        {
            //使用“:”作为路径分割，产生树形关系(key：大小写不敏感)
            var source = new Dictionary<string, string>
            {
                ["Format:dateTime:longDatePattern"] = "dddd, MMMM d, yyyy",
                ["format:dateTime:longTimePattern"] = "h:mm:ss tt",
                ["format:dateTime:shortDatePattern"] = "M/d/yyyy",
                ["format:dateTime:shortTimePattern"] = "h:mm tt",

                ["format:currencyDecimal:digits"] = "2",
                ["format:currencyDecimal:symbol"] = "$",
            };
            #region 方式一
            /*
             * 通过构造函数的方式来实现，需要在构造函数中获取Section和Key。需要手动实现一一对应关系
             */
            //var configuration = new ConfigurationBuilder()
            //        .Add(new MemoryConfigurationSource { InitialData = source })
            //        .Build();
            ////获取一级节点（不区分大小写）
            //var options = new FormatOptions(configuration.GetSection("Format"));
            //var dateTime = options.DateTime;
            //var currencyDecimal = options.CurrencyDecimal; 
            #endregion

            #region  方式二
            /*
             * 在ConfiguationBuilder实例上调用GetSection获取转换的路径，调用Get泛型方法实现。避免了在构造函数中手动一一对应（注意：属性名称需和配置项中的节点名称保持一致，否则无法转换）
             */
            //var options = new ConfigurationBuilder().Add(new MemoryConfigurationSource { InitialData = source }).Build().GetSection("format").Get<FormatOptions>();
            //var dateTime = options.DateTime;
            //var currencyDecimal = options.CurrencyDecimal;
            #endregion

            #region 方式三 使用Json
            //var options = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("format").Get<FormatOptions>();
            //var dateTime = options.DateTime;
            //var currencyDecimal = options.CurrencyDecimal;
            #endregion

            #region 动态加载配置文件
            //输入：/env staging  /env production
            //var index = Array.IndexOf(args, "/env");
            //var environment = index > -1
            //    ? args[index + 1]
            //    : "Development";

            ////可以使用SetBasePath()显式指定文件路径
            //var options = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).AddJsonFile($"appsettings.{environment}.json", true).Build().GetSection("format").Get<FormatOptions>();
            //var dateTime = options.DateTime;
            //var currencyDecimal = options.CurrencyDecimal;
            #endregion
            //Console.WriteLine("DateTime:");
            //Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
            //Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
            //Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
            //Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

            //Console.WriteLine("CurrencyDecimal:");
            //Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
            //Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}");

            #region 同步配置文件修改
            var config = new ConfigurationBuilder()
              .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
              .Build();
            ChangeToken.OnChange(() => config.GetReloadToken(), () =>
            {
                var options = config.GetSection("format").Get<FormatOptions>();
                var dateTime = options.DateTime;
                var currencyDecimal = options.CurrencyDecimal;

                Console.WriteLine("DateTime:");
                Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
                Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
                Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
                Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

                Console.WriteLine("CurrencyDecimal:");
                Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
                Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}\n\n");
            });

            Console.Read();
            #endregion
        }
    }
    public class FormatOptions
    {
        public DateTimeFormatOptions DateTime { get; set; }
        public CurrencyDecimalFormatOptions CurrencyDecimal { get; set; }

        //方法一：使用构造函数，手动指定节点
        //public FormatOptions(IConfiguration config)
        //{
        //    //获取二级节点GetSection
        //    DateTime = new DateTimeFormatOptions(config.GetSection("DateTime"));
        //    CurrencyDecimal = new CurrencyDecimalFormatOptions(config.GetSection("CurrencyDecimal"));
        //}
    }
    public class CurrencyDecimalFormatOptions
    {
        public int Digits { get; set; }
        public string Symbol { get; set; }

        //public CurrencyDecimalFormatOptions(IConfiguration config)
        //{
        //    //获取Key
        //    Digits = int.Parse(config["Digits"]);
        //    Symbol = config["Symbol"];
        //}
    }
    public class DateTimeFormatOptions
    {
        //public DateTimeFormatOptions(IConfiguration config)
        //{
        //    //获取Key
        //    LongDatePattern = config["LongDatePattern"];
        //    LongTimePattern = config["LongTimePattern"];
        //    ShortDatePattern = config["ShortDatePattern"];
        //    ShortTimePattern = config["ShortTimePattern"];
        //}
        public string LongDatePattern { get; set; }
        public string LongTimePattern { get; set; }
        public string ShortDatePattern { get; set; }
        public string ShortTimePattern { get; set; }
    }
}
