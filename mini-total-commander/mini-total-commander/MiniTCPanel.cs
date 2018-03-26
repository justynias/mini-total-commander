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

        public event Func<object, EventArgs, string[]> PanelEvent;
        protected void PathChanged(object sender, EventArgs e)
        {
            if (PanelEvent != null)
            {
                Dir = PanelEvent(this.CurrentPath, e);
                foreach (String d in Dir)
                {

                    listBox.Items.Add(d);

                }
            }
               
        }
        public event Func<object, EventArgs, DriveInfo[]> PanelEventDrives;
        private void loadDrives(object sender, EventArgs e)
        {
            if (PanelEventDrives != null)
            {
                DriveInfo[] allDrives = PanelEventDrives(sender, e);
                comboBoxDrives.Items.Clear();

                foreach (DriveInfo d in allDrives)
                {

                        comboBoxDrives.Items.Add(d.Name);
                   

                }
            }

        }

        private void changeDrive(object sender, EventArgs e)
        {
            ComboBox drives = sender as ComboBox;
            textBoxPath.Text = drives.SelectedItem.ToString();
        }
    }
}
