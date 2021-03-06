using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillfulClothes
{
    static class Logger
    {
        static IMonitor monitor;

        public static void Init(IMonitor _monitor)
        {
            monitor = _monitor;
        }

        public static void Info(String message)
        {
            monitor?.Log(message, LogLevel.Info);
        }

        public static void Debug(String message)
        {
            monitor?.Log(message, LogLevel.Debug);
        }

        public static void Warn(String message)
        {
            monitor?.Log(message, LogLevel.Warn);
        }

        public static void Error(String message)
        {
            monitor?.Log(message, LogLevel.Error);
        }
    }
}
