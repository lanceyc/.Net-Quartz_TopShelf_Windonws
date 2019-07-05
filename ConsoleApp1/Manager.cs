using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace ConsoleApp1
{
    public class Manager
    {
        //创建调度器工厂
        ISchedulerFactory factory = new StdSchedulerFactory();
        //创建调度器
        IScheduler scheduler = null;
        public Manager()
        {
            Init();
        }

        private async void Init()
        {
            scheduler = await factory.GetScheduler();
            //创建一个任务
            IJobDetail job = JobBuilder.Create<TimeJob>().WithIdentity("myJob1", "group1").Build();
            //创建一个触发器
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("myTrigger1", "group1").StartNow().
                WithSimpleSchedule(a => a.WithIntervalInSeconds(10).RepeatForever()).Build();
            //将任务和触发器添加到调度器里
            await scheduler.ScheduleJob(job, trigger);
        }

        public async void Start()
        {
            //开始执行
            await scheduler.Start();
        }

        public async void Stop()
        {
            //停止
            await scheduler.Shutdown(false);
        }

        public async void Pause()
        {
            //暂停
            await scheduler.PauseAll();
        }

        public async void Continue()
        {
            //继续
            await scheduler.ResumeAll();
        }
    }
}
