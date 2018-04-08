using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_total_commander
{
    public partial class MiniTCPanel : UserControl//, IPanel
    {
        public MiniTCPanel()
        {
            
            InitializeComponent();
            

        }

        //ivate string[] files;
        private string[] dir;
        private string[] drives;

       // public string Selected { get; set; }
        public string[] Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        //public string[] Files
        //{
        //    get { return files; }
        //    set { files = value; }
        //}
        public string[] Drives
        {
            get { return drives; }
            set { drives = value; }
        }
        public string CurrentPath
        {
            get { return textBoxPath.Text; }
            set {
                if (value.Contains("<D>"))
                {
                    int index = value.IndexOf("<");
                    textBoxPath.Text = value.Remove(index, 3);
                } 
                else textBoxPath.Text = value;
            }
                        
        }
        
        public string SelectedDir
        {
            get {
                if (listBox.SelectedItem.ToString().Contains("<D>"))
                {
                    int index = listBox.SelectedItem.ToString().IndexOf("<");
                    return listBox.SelectedItem.ToString().Remove(index, 3);
                }

                else return listBox.SelectedItem.ToString();
            }
            set { }
        }


        public event Func<object, EventArgs, string[]> PanelEventLoadDir;
        public void PathChanged(object sender, EventArgs e)
        {
            if (PanelEventLoadDir != null)
            {
                listBox.Items.Clear();
                Dir = PanelEventLoadDir(this.CurrentPath, e);
                if(Dir!= null)
                {
                    
                    foreach (String d in Dir)
                    {

                        listBox.Items.Add(d);

                    }

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



        public event Action<object, EventArgs> PanelSelectedItem;

        public void SelectedItem(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if(listBox.SelectedItem != null)
            {
              
                PanelSelectedItem(this, e);
            }
            

        }
        public void ClearSelected()
        {
            
            listBox.ClearSelected();
        }

        private void ExecutePath(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if(listBox.SelectedItem!=null)
            {
                CurrentPath = CurrentPath+listBox.SelectedItem.ToString();
            }
        }

        public event Func<object, EventArgs, string> PanelEventReturnPath;
        private void ReturnButtonClick(object sender, EventArgs e)
        {
            CurrentPath = PanelEventReturnPath(this.CurrentPath, e);
        }

        public void Refresh(object sender, EventArgs e)
        {
            PathChanged(sender, e);
        }
    }
}
