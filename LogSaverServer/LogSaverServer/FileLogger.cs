using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;

namespace LogSaverServer
{
    static class FileLogger
    {
        private static readonly string logsDirectory = AppSettings.LSLogsPath;
        private static readonly object logLockObject = new object();

        private static readonly ConcurrentQueue<string> messageQueue =
            new ConcurrentQueue<string>();

        static FileLogger()
        {
            ThreadPool.QueueUserWorkItem(LoggerThreadWork);
        }

        public static void Log(string message)
        {
            LogLines(message);
        }

        public static void LogLines(params string[] lines)
        {
            foreach (string line in lines)
            {
                messageQueue.Enqueue(line);
            }
        }

        public static void ClearLog()
        {
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            lock (logLockObject)
            {
                File.WriteAllText(logsPath, "");
            }
        }

        private static void LoggerThreadWork(object stateInfo)
        {
            ClearLog();
            List<string> messagesToLog = new List<string>();
            string logsPath = Path.Combine(logsDirectory, "ls_logs.txt");
            while (true)
            {
                // Clear out queue and add to a list
                while (!messageQueue.IsEmpty)
                {
                    if (messageQueue.TryDequeue(out string nextMessage))
                    {
                        messagesToLog.Add(nextMessage);
                    }
                }
                // write all lines at once
                if (messagesToLog.Count > 0)
                {
                    lock (logLockObject)
                    {
                        File.AppendAllLines(logsPath, messagesToLog.ToArray());
                    }
                    messagesToLog.Clear();
                }
                // wait to prevent overloading file
                Thread.Sleep(500);
            }
        }
    }
}
