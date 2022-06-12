using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Util
{
    /**
     *  Helper to read a file from relative path
     */
    public class FileHelper
    {

        public static string[] ReadFileLines(string fileName) 
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (File.Exists(path))
            {
                return File.ReadAllLines(path);
            }
            throw new Exception("RPG Story configuration not found!");
        }
    }
}
