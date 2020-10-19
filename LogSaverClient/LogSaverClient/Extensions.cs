using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSaverClient
{
    static class Extensions
    {
        public static bool IsIPv4Format(this string value)
        {
            string[] parts = value.Split('.');
            if (parts.Length != 4) return false;
            foreach (string part in parts)
            {
                for (int i = 0; i < part.Length; i++)
                {
                    if (!char.IsDigit(part[i])) return false;
                }
            }
            return true;
        }
    }
}
