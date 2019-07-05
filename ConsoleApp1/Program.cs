using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //星期五
            var fac = HostFactory.New(x =>
            {
                x.Service<Manager>(s =>
                {
                    s.ConstructUsing(name => new Manager());
                    s.WhenStarted(m => m.Start());
                    s.WhenStopped(m => m.Stop());
                    s.WhenPaused(m => m.Pause());
                    s.WhenContinued(m => m.Continue());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Quartz配合TopShelf创建Windows服务的小demo");
                x.SetDisplayName("QuartzTopShelf服务Demo");
                x.SetServiceName("QuartzTopShelfDemoService");
            });

            fac.Run();

            Console.ReadKey();
        }
    }
}
