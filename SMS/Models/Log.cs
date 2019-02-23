using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SMS.Models
{
    public class Log:IDisposable
    {
        /*
        [LogId] [INT] IDENTITY(1,1) NOT NULL,
        [ErrorDate] [DATETIME] NOT NULL CONSTRAINT [DF_Log_Date]  DEFAULT (GETDATE()),
        [ErrorShortDescription] [VARCHAR](1000) NULL,
        [ExceptionType] [VARCHAR](255) NULL,
        [FileName] [VARCHAR](1000) NULL,
        [LineNumber] [INT] NULL,
        [MethodName] [VARCHAR](255) NULL,
        [ClassName] [VARCHAR](150) NULL,
        [ImpactLevel] [VARCHAR](50) NOT NULL,
        [ApplicationName] [VARCHAR](255) NULL,
        [ErrorMessage] [VARCHAR](4000) NULL,
        [StackTrace] [VARCHAR](MAX) NULL,
        [InnerException] [VARCHAR](2000) NULL,
        [InnerExceptionMessage] [VARCHAR](2000) NULL,
        [IpAddress] [VARCHAR](150) NULL,
        [IsProduction] [BIT] NOT NULL CONSTRAINT [DF_Log_IsProduction]  DEFAULT ((1)),
        [LastModified] [DATETIME] NOT NULL CONSTRAINT [DF_Log_LastModified]  DEFAULT (GETDATE()),
       */
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        [Required]
        public DateTime? ErrorDate { get; set; }
        [MaxLength(1000)]
        public string  ErrorShortDescription { get; set; }
        [MaxLength(250)]
        public string ExceptionType { get; set; }
        [MaxLength(1000)]
        public string FileName { get; set; }
        public int? LineNumber { get; set; }
        [MaxLength(255)]
        public string MethodName { get; set; }
        [MaxLength(150)]
        public string ClassName { get; set; }
        [MaxLength(50)]
        public string ImpactLevel { get; set; }
        [MaxLength(255)]
        public string ApplicationName { get; set; }
        [MaxLength(4000)]
        public string ErrorMessage { get; set; }
        [MaxLength]
        public string StackTrace { get; set; }
        [MaxLength(2000)]
        public string InnerException { get; set; }
        [MaxLength(2000)]
        public string InnerExceptionMessage { get; set; }
        [MaxLength(150)]
        public string IpAddress { get; set; }
        [MaxLength(150)]
        public string HostName { get; set; }
        [Required]
        public bool IsProduction { get; set; }
        public DateTime? LastModified { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Log() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}