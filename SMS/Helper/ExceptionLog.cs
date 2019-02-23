using SMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Web;

namespace SMS.Helper
{
    public static partial  class ExceptionLog
    {
       
        /// <summary>
        /// Saves the exception details to ErrorLogging db with Low Priority
        /// </summary>
        /// <param name="ex">The exception.</param>
        public static void Save(this Exception ex)
        {
            Save(ex, ImpactLevel.Low, "");
        }

        /// <summary>
        /// Saves the exception details to ErrorLogging db with specified ImpactLevel
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="impactLevel">The Impact level.</param>
        public static void Save(this Exception ex, ImpactLevel impactLevel)
        {
            Save(ex, impactLevel, "");
        }
        /// <summary>
        /// Saves the exception details to ErrorLogging db with specified ImpactLevel and user message
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="impactLevel">The impact level.</param>
        /// <param name="errorDescription">The error Description.</param>
        public static void Save(this Exception ex, ImpactLevel impactLevel, string errorDescription)
        {
            using (var db = new SMS.Models.SMSDbContext())
            {
                Log log = new Log();

                if (errorDescription != null && errorDescription != "")
                {
                    log.ErrorShortDescription = errorDescription;
                }
                log.ExceptionType = ex.GetType().FullName;
                var stackTrace = new StackTrace(ex, true);
                var allFrames = stackTrace.GetFrames().ToList();
                foreach (var frame in allFrames)
                {
                    log.FileName = frame.GetFileName();
                    log.LineNumber = frame.GetFileLineNumber();
                    var method = frame.GetMethod();
                    log.MethodName = method.Name;
                    log.ClassName = frame.GetMethod().DeclaringType.ToString();
                }

                log.ImpactLevel = impactLevel.ToString();
                try
                {
                    log.ApplicationName = Assembly.GetCallingAssembly().GetName().Name;
                }
                catch
                {
                    log.ApplicationName = "";
                }

                log.ErrorMessage = ex.Message;
                log.StackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    log.InnerException = ex.InnerException.ToString();
                    log.InnerExceptionMessage = ex.InnerException.Message;
                }
                log.IpAddress = HttpContext.Current.Request.UserHostAddress; //get the ip address
                                                                             //log.HostName = HttpContext.Current.Request; //get the host name
                try
                {
                    IPHostEntry host = Dns.GetHostEntry(log.IpAddress);
                    log.HostName = host.HostName;
                }
                catch(SocketException se)
                {
                    log.HostName = "Mobile/Unknown Host";
                }
                log.ErrorDate = DateTime.Now;

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    log.IsProduction = false;
                }

                try
                {
                    db.Logs.Add(log);
                    db.SaveChanges();
                }
                catch (Exception eex)
                {
                    
                }
                finally
                {
                    log.Dispose();
                    
                }
            }
        }
        public enum ImpactLevel
        {
            High = 0,
            Medium = 1,
            Low = 2,
        }
    }
}
