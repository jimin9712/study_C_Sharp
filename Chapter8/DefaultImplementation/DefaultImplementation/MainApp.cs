using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultImplementation
{
    interface ILogger
    {
        void WriteLog(string message);

        void WriteError(string error) // 새로운 메소드 추가
        {
            WriteLog($"Error: {error}");
        }
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("System Up");
            logger.WriteError("System Fail");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.WriteLog("System Up"); //  OK
            // clogger.WriteError("System Fail"); // 컴파일 에러
        }
    }
}
// 대상 런타임이 기본 인터페이스 구현을 지원하지 않음