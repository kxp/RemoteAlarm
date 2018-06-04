using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RemoteAlarm
{
    public static class Helper
    {

        public static string GetResource()
        {
            string readedStuff = string.Empty;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var list = assembly.GetManifestResourceNames();

                foreach (string name in list)
                {
                    Stream source = assembly.GetManifestResourceStream(name);
                    using (StreamReader reader = new StreamReader(source))
                    {
                        readedStuff = reader.ReadToEnd();
                    }
                    source.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return readedStuff;
        }
    }
}