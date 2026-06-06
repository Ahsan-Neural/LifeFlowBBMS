using System;
using System.IO;
using System.Text;

namespace LifeFlowBBMS.DAL
{
    /// <summary>
    /// Security and audit logging system for tracking sensitive operations
    /// </summary>
    public static class SecurityLogger
    {
        private static readonly string LogPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Logs");

        private static readonly object LockObject = new object();

        static SecurityLogger()
        {
            // Create Logs directory if it doesn't exist
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
        }

        // ─────────────────────────────────────────────────
        //  LOG AUDIT EVENTS
        // ─────────────────────────────────────────────────
        public static void LogAudit(string username, string action, string details = "")
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [AUDIT] User: {username} | Action: {action}";
            if (!string.IsNullOrEmpty(details))
                message += $" | Details: {details}";

            WriteToLog("AuditLog", message);
        }

        // ─────────────────────────────────────────────────
        //  LOG SECURITY EVENTS
        // ─────────────────────────────────────────────────
        public static void LogSecurity(string eventType, string details)
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [SECURITY] Event: {eventType} | Details: {details}";
            WriteToLog("SecurityLog", message);
        }

        // ─────────────────────────────────────────────────
        //  LOG FAILED LOGIN ATTEMPTS
        // ─────────────────────────────────────────────────
        public static void LogFailedLogin(string username, string reason = "Invalid credentials")
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [FAILED_LOGIN] Username: {username} | Reason: {reason}";
            WriteToLog("FailedLoginLog", message);
        }

        // ─────────────────────────────────────────────────
        //  LOG SUCCESSFUL LOGIN
        // ─────────────────────────────────────────────────
        public static void LogSuccessfulLogin(string username)
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [LOGIN_SUCCESS] Username: {username}";
            WriteToLog("AuditLog", message);
        }

        // ─────────────────────────────────────────────────
        //  LOG DATA MODIFICATION
        // ─────────────────────────────────────────────────
        public static void LogDataModification(string username, string tableName, string operation, 
            int recordId, string fieldName, string oldValue, string newValue)
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [DATA_CHANGE] " +
                $"User: {username} | Table: {tableName} | Operation: {operation} | " +
                $"RecordID: {recordId} | Field: {fieldName} | " +
                $"Old: {oldValue ?? "NULL"} | New: {newValue ?? "NULL"}";

            WriteToLog("DataModificationLog", message);
        }

        // ─────────────────────────────────────────────────
        //  LOG ERRORS
        // ─────────────────────────────────────────────────
        public static void LogError(string source, string errorMessage, Exception ex = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [ERROR] Source: {source}");
            sb.AppendLine($"Message: {errorMessage}");

            if (ex != null)
            {
                sb.AppendLine($"Exception Type: {ex.GetType().Name}");
                sb.AppendLine($"Exception Message: {ex.Message}");
                sb.AppendLine($"Stack Trace: {ex.StackTrace}");
                
                if (ex.InnerException != null)
                {
                    sb.AppendLine($"Inner Exception: {ex.InnerException.Message}");
                }
            }

            WriteToLog("ErrorLog", sb.ToString());
        }

        // ─────────────────────────────────────────────────
        //  LOG DATABASE OPERATIONS
        // ─────────────────────────────────────────────────
        public static void LogDatabaseOperation(string username, string operation, string query, 
            bool success, string errorMessage = "")
        {
            string message = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [DB_OPERATION] " +
                $"User: {username} | Operation: {operation} | Success: {success}";

            if (!success)
                message += $" | Error: {errorMessage}";

            WriteToLog("DatabaseLog", message);
        }

        // ─────────────────────────────────────────────────
        //  WRITE TO LOG FILE
        // ─────────────────────────────────────────────────
        private static void WriteToLog(string logType, string message)
        {
            try
            {
                lock (LockObject)
                {
                    string fileName = Path.Combine(LogPath, 
                        $"{logType}_{DateTime.Now:yyyy-MM-dd}.log");

                    // Append to log file with thread-safe write
                    using (var writer = new StreamWriter(fileName, true, Encoding.UTF8))
                    {
                        writer.WriteLine(message);
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                // If logging fails, write to debug output
                System.Diagnostics.Debug.WriteLine($"[LOGGING_ERROR] Failed to write to {logType}: {ex.Message}");
            }
        }

        // ─────────────────────────────────────────────────
        //  CLEANUP OLD LOGS (30 days retention)
        // ─────────────────────────────────────────────────
        public static void CleanupOldLogs(int daysToKeep = 30)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(LogPath);
                FileInfo[] files = di.GetFiles("*.log");

                foreach (FileInfo file in files)
                {
                    if (file.CreationTime < DateTime.Now.AddDays(-daysToKeep))
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CLEANUP_ERROR] Failed to cleanup logs: {ex.Message}");
            }
        }
    }
}
