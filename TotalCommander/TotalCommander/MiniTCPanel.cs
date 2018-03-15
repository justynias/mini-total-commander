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
namespace TotalCommander
{
    public partial class MiniTCPanel : UserControl
    {

        public MiniTCPanel()
        {

            InitializeComponent();
        }
        public string[] dir;
        public string[] files;

        

        public string CurrentPath
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;

            }
        }

        


        private void comboBoxLoad(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                comboBox1.Items.Add(d.Name);
                if (d.IsReady)
                {
                    
                }

            }
        }

        private void setTextBoxPath(object sender, EventArgs e)
        {
           
          ComboBox combobox = sender as ComboBox;
            textBox1.Text = combobox.SelectedItem.ToString();
            listBox1.Items.Clear();

            dir = Directory.GetDirectories(combobox.SelectedItem.ToString());
            files = Directory.GetFiles(combobox.SelectedItem.ToString());
            foreach(String d in dir)
            {
              
                listBox1.Items.Add("<D>  "+ d.Remove(0, Path.GetDirectoryName(d).Length));
            }
            foreach (String f in files)
            {

                listBox1.Items.Add("<F>  " + f.Remove(0, Path.GetDirectoryName(f).Length));
            }

        }

        private void changePath(object sender, EventArgs e)
        {
            ListBox list = sender as ListBox;

            
            textBox1.Text = dir[list.Items.IndexOf(list.SelectedItem)];
             
            dir=Directory.GetDirectories(dir[list.Items.IndexOf(list.SelectedItem)]);

            list.Items.Clear();
            foreach (String d in dir)
            {

                listBox1.Items.Add("<D>  " + d.Remove(0, Path.GetDirectoryName(d).Length));
            }


        }
    }
}
