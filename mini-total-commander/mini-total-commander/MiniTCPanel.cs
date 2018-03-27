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

namespace mini_total_commander
{
    public partial class MiniTCPanel : UserControl//, IPanel
    {
        public MiniTCPanel()
        {
            InitializeComponent();
            textBoxPath.Text = "F:\\cszar";
        }

        private string[] files;
        private string[] dir;
        private string[] drives;

        public string[] Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        public string[] Files
        {
            get { return files; }
            set { files = value; }
        }
        public string[] Drives
        {
            get { return drives; }
            set { drives = value; }
        }
        public string CurrentPath
        {
            get { return textBoxPath.Text; }
            set { textBoxPath.Text = value; }
        }

        public event Func<object, EventArgs, string[]> PanelEventLoadDir;
        public void PathChanged(object sender, EventArgs e)
        {
            if (PanelEventLoadDir != null)
            {
                Dir = PanelEventLoadDir(this.CurrentPath, e);
                foreach (String d in Dir)
                {

                    listBox.Items.Add(d);

                }
            }
               
        }
        public event Func<object, EventArgs, string[]> PanelEventLoadDrives;
        private void loadDrives(object sender, EventArgs e)
        {
            if (PanelEventLoadDrives != null)
            {
                Drives = PanelEventLoadDrives(sender, e);
                comboBoxDrives.Items.Clear();

                foreach (string d in Drives)
                {
                        comboBoxDrives.Items.Add(d);
  
                }
                
            }

        }

        private void changeDrive(object sender, EventArgs e)
        {
            ComboBox drives = sender as ComboBox;
            textBoxPath.Text = drives.SelectedItem.ToString();
        }

        private void SelectedItem(object sender, EventArgs e)
        {

            if (this.CanFocus)
            {
                this.Focus();
            }

        }
    }
}
