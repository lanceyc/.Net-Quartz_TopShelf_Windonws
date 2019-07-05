using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            string filePath=@"E:\\Demos\\Quartz_TopShelf_Windonws\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
           // var dailyReportFullPath = string.Format("{0}text_{1}.txt", filePath, DateTime.Now.Day);
            var dailyReportFullPath = $@"{filePath}\\text_{DateTime.Now.Day}.txt";
            // string filePath = @"D:\\log.txt";
            File.AppendAllText(dailyReportFullPath, DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + Environment.NewLine+ "   - Quartz定时作业执行，今天你跑步了吗？   \r\n 来自 本地服务/QuartzTopShelf服务Demo的提醒..."+ Environment.NewLine );

            Console.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + Environment.NewLine);
            return Task.FromResult(true);
        }
    }
}
