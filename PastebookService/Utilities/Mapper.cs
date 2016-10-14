using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PastebookService
{
    public static class Mapper
    {
        public static byte[] GetBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public static string GetString(byte[] resultBytes)
        {
            return Encoding.ASCII.GetString(resultBytes);
        }
    }
}