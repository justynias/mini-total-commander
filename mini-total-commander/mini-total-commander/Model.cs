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

        internal void CopyFile(string sourceDir, string targetDir)  
        {

          
                try   //copy only files
                {
                    File.Copy(sourceDir, targetDir);
                }
                catch (IOException) { } //handle it in the messagebox, filename already exist, or sourcefile does not exist
                catch (System.UnauthorizedAccessException) { } // anauthorized acces 

            }
        internal void MoveFile(string sourceDir, string targetDir) 
        {
            

                try
                {
                    File.Move(sourceDir, targetDir);
                }
                catch (IOException) { } //handle it in the messagebox, file does not exist?
            catch (System.UnauthorizedAccessException) { } // anauthorized acces 

        }
        internal void RemoveFile(string fileDir) // check if user is sure to remove file, update list     
        {
            try
            {
                File.Delete(fileDir);
            }
            catch (IOException) { } //handle it in the messagebox, files does not exist?
            catch (System.UnauthorizedAccessException) { } // anauthorized acces 

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
    }


}
