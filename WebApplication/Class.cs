using System;
using System.IO;

namespace systemLog
{
    public class Log
    {
        public void WriteLog(string row)
        {
            string filePath = "file_CS.txt";

            try
            {
                bool fileExists = File.Exists(filePath);

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string strTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");

                    if (fileExists && new FileInfo(filePath).Length > 0)
                    {
                        writer.WriteLine();
                        writer.Write(strTime + " - " + row);
                    }
                    else
                    {
                        writer.Write(strTime + " :Hello file!");
                    }
                }

                Console.WriteLine("Wrote to file: " + Path.GetFullPath(filePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
