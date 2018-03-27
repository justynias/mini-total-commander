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
            return Directory.GetDirectories(path);
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
            // return DriveInfo.GetDrives();
            return readyDrives.ToArray();
        }

    }


}
