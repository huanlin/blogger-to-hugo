using System;
using BloggerToHugo.Bll.Process;

namespace BloggerToHugo
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new XmlBackupProcess();
            process.StartProcess(args);
        }
    }
}
