using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MiniTotalCommander
{
    public partial class MiniTCPanel : UserControl
    {
        public MiniTCPanel()
        {
            InitializeComponent();
        }

        private string[] files;
        private string[] dir;
        
        public string[] Dir
        {
            get { return dir; }
            set { dir=value; }
        }
        public string[] Files
        {
            get { return files; }
            set { files = value; }
        }
        public string CurrentPath
        {
            get { return textBoxPath.Text; }
            set { textBoxPath.Text = value; }
        }

        private void returnButtonClick(object sender, EventArgs e) 
        {
            if(Path.GetDirectoryName(CurrentPath)!=null)
            {
                textBoxPath.Text = Path.GetDirectoryName(CurrentPath);
                LoadPath();
            }
              
        }

       

        private void loadDrives(object sender, EventArgs e)
        {
            comboBoxDrives.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {

                if (d.IsReady)
                {
                    comboBoxDrives.Items.Add(d.Name);
                }

            }
        }

        private void changeDrive(object sender, EventArgs e)
        {
            ComboBox drives = sender as ComboBox;
            textBoxPath.Text = drives.SelectedItem.ToString();
            LoadPath();

        }



        private void executePath(object sender, EventArgs e)
        {
            ListBox list = sender as ListBox;
            if(list.SelectedItem!=null)
            {
                if (Directory.Exists(CurrentPath + list.SelectedItem.ToString().Substring(3, list.SelectedItem.ToString().Length - 3)))
                {
                    textBoxPath.Text = CurrentPath + list.SelectedItem.ToString().Substring(3, list.SelectedItem.ToString().Length - 3);
                    LoadPath();

                }
                else
                {
                    Process.Start(CurrentPath + list.SelectedItem.ToString().Substring(3, list.SelectedItem.ToString().Length - 3));
                }
            }
            
        }
        private void LoadPath()   // avoid system catalogs, hidden folders, check if there is an acces!!
        {
            listBox.Items.Clear();
            Dir = Directory.GetDirectories(CurrentPath);

            foreach (String d in Dir)
            {

                listBox.Items.Add("<D>" + d.Remove(0, Path.GetDirectoryName(d).Length));

            }
            Files = Directory.GetFiles(CurrentPath);


            foreach (String f in Files)
            {

                listBox.Items.Add("<F>" + f.Remove(0, Path.GetDirectoryName(f).Length));

            }
        }
    }
}
