using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;
using log4net.Config;

namespace WebApplication2.Helpers
{
    public interface ILog4NetHelper
    {
        void Warn(string message);
        void Error(string message, Exception ex);
    }

    public class Log4NetHelper : ILog4NetHelper
    {
        private readonly ILog _log = LogManager.GetLogger(Assembly.GetExecutingAssembly().FullName);

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }
    }


    //public static class Log4NetHelper
    //{
    //    private static ILog log = LogManager.GetLogger("Log4NetHelper");  

    //    public static ILog Log
    //    {
    //        get { return log; }
    //    }

    //    public static void InitLogger()
    //    {
    //        XmlConfigurator.Configure();
    //    }
    //}
}