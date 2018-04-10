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

        public Model()   //exception with messages, yes/no to delete, pendrive?
        { }
        internal string[] LoadPath(string path)
        {
            try {

                if (Directory.Exists(path)) 
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
                    try
                    {
                        Process.Start(path);
                    }
                    catch (System.InvalidOperationException) { }
                    return null;
                }


            } catch (System.UnauthorizedAccessException) { return null; } // anauthorized acces 
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

        internal void CopyDir(string selectedItem, string sourceDir, string targetDir)  
        {
            sourceDir += selectedItem; //full path to the directory
            targetDir += selectedItem;
            if (Directory.Exists(sourceDir)) //copy folder , throw exception when target is the source folder!!
            {

                DirectoryCopy(sourceDir, targetDir, true);
                Console.WriteLine(sourceDir + " target: " + targetDir);
            }
            else
            {
                try   //copy only files
                {
                    File.Copy(sourceDir, targetDir); //the same name for the destination file 
                    Console.WriteLine(sourceDir + " target: " + targetDir);
                }
                catch (IOException) { } //handle it in the messagebox, filename already exist, or sourcefile does not exist
                catch (System.UnauthorizedAccessException) { } // anauthorized acces 
                catch (System.ArgumentException) { } 
            }
               

            }
        internal void MoveDir(string selectedItem, string sourceDir, string targetDir) 
        {
            sourceDir += selectedItem; //full path to the directory
            targetDir += selectedItem;
            if (Directory.Exists(sourceDir)) //copy folder , throw exception when target is in the folder!! TO DO
            {
                if (Directory.GetDirectoryRoot(sou­rceDir) == Directory.GetDirectoryRoot(targetDir))
                {
                    Directory.Move(sourceDir, targetDir);
                }
                else
                {
                    DirectoryCopy(sourceDir, targetDir, true);
                    Directory.Delete(sourceDir,true);
                }
               
                Console.WriteLine(sourceDir + " target: " + targetDir);
            }
            else

                
                try
                {
                    File.Move(sourceDir, targetDir);
                }
                catch (IOException) { } //handle it in the messagebox, file does not exist?
            catch (System.UnauthorizedAccessException) { } // anauthorized acces 
                catch (System.ArgumentException) { }

        }
        internal void RemoveDir(string dir) // check if user is sure to remove file, update list     
        {
            if (Directory.Exists(dir)) //delete folder recursively 
            {
                Directory.Delete(dir, true);
            }
            else
            {

                try
                {
                    File.Delete(dir);
                }
                catch (IOException) { } //handle it in the messagebox, files does not exist?
                catch (System.UnauthorizedAccessException) { } // anauthorized acces 
                catch (System.ArgumentException) { }

            }

        }

        internal string ReturnPath(string path)
        {
            try
            {
                if (Path.GetDirectoryName(path) == null) return "";
                else return Path.GetDirectoryName(path);
            }
            catch (System.ArgumentException) { return ""; }
            catch (System.UnauthorizedAccessException) { return ""; } // anauthorized acces

        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

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
