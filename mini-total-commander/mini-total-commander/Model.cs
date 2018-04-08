using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace mini_total_commander
{
    public class Model
    {

        public Model()
        { }
        internal string[] LoadPath(string path)
        {
            if(Directory.Exists(path))
            {
                string[] dir = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                List<string> allItems = new List<string>();

                foreach (String d in dir)
                {

                    allItems.Add("<D>" + d.Remove(0, Path.GetDirectoryName(d).Length));

                }
                foreach (String f in files)
                {

                    allItems.Add(f.Remove(0, Path.GetDirectoryName(f).Length));

                }
                return allItems.ToArray();
            }
            else
            {
                Process.Start(path);
                return null;
            }
            
        }

        internal string[] LoadDrives()
        {
            List<string> readyDrives = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {

                if (d.IsReady)
                {
                    readyDrives.Add(d.ToString());
                }

            }
            return readyDrives.ToArray();
        }

        internal void CopyFile(string currentDir, string targetDir)   // update lists!!
        {
            File.Copy(currentDir, targetDir);
        }
        internal void MoveFile(string currentDir, string targetDir)
        {
            File.Move(currentDir, targetDir);
        }
        internal void RemoveFile(string item, string curremtPath)
        {
            File.Delete(item);
        }

    }


}
