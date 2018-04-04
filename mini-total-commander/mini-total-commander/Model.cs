using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mini_total_commander
{
    public class Model
    {

        public Model()
        { }
        internal string[] LoadPath(string path)
        {
            //return Directory.GetDirectories(path);
            return Directory.GetFiles(path);

            
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
