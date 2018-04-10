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

        public Model()   // yes/no to delete, exception when drive was removed
        { }
        internal string[] LoadPath(string path)
        {
            //DriveInfo drive = new DriveInfo(Directory.GetDirectoryRoot(path));
            //if(drive.IsReady)
            //{
                if (Directory.Exists(path)) //check if drive exists!! after removing pendrive, better solution than throwing an exception?
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

        internal bool CopyDir( string sourceDir, string targetDir)  
        {
            if (Directory.Exists(sourceDir)) //copy folder 
            {
                Console.WriteLine(sourceDir + " target: " + targetDir);
                DirectoryCopy(sourceDir, targetDir, true);
            }
            else
            {
                //copy only files
                    Console.WriteLine(sourceDir + " target: " + targetDir);
                    File.Copy(sourceDir, targetDir); //the same name for the destination file 
            }
            return true;          

       }

        internal bool MoveDir(string sourceDir, string targetDir) 
        {

            if (Directory.Exists(sourceDir)) //copy folder 
            {
                Console.WriteLine(sourceDir + " target: " + targetDir);

                if (Directory.GetDirectoryRoot(sou­rceDir) == Directory.GetDirectoryRoot(targetDir)) // if its the same volumin, biuld in method
                {
                    Directory.Move(sourceDir, targetDir);
                }
                else
                {
                    DirectoryCopy(sourceDir, targetDir, true);
                    Directory.Delete(sourceDir,true);
                }
               
            }
            else File.Move(sourceDir, targetDir);
            return true;

        }
        internal  bool RemoveDir(string dir) // check if user is sure to remove file, update list     
        {
            if (Directory.Exists(dir)) //delete folder recursively 
            {
                Directory.Delete(dir, true);
            }
            else
            {
                    File.Delete(dir);

            }
            return true;

        }

        internal string ReturnPath(string path)
        {
                if (Path.GetDirectoryName(path) == null) return "";
                else return Path.GetDirectoryName(path);

        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            //if (!dir.Exists)
            //{
            //    throw new DirectoryNotFoundException(
            //        "Source directory does not exist or could not be found: "
            //        + sourceDirName);
            //}

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name); //'System.IO.IOException -> when the filename exist!!
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }


}
