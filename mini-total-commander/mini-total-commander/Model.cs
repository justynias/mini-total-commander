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

        internal DriveInfo[] LoadDrives()
        {
           
            return DriveInfo.GetDrives();
        }

    }


}
