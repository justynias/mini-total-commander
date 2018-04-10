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

        private string[] dir;
        private string[] drives;

        public string[] Dir
        {
            get { return dir; }
            set
            { dir = value;
                if (dir != null)
                {  
                    foreach (String d in dir)
                    {
                        listBox.Items.Add(d);
                    }
                }
            }
        }

        public string[] Drives
        {
            get { return drives; }
            set { drives = value;
                comboBoxDrives.Items.Clear();
                if(drives!=null)
                {
                    foreach (string d in drives)
                    {
                        comboBoxDrives.Items.Add(d);
                    }
                }
            }
        }
        public string CurrentPath
        {
            get { return textBoxPath.Text; }
            set {
                if (value !=null && value.Contains("<D>"))
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
                if (listBox.SelectedItem != null)
                {
                    if (listBox.SelectedItem.ToString().StartsWith("<D>"))    // to remove symbol <D> from the selected item
                                                                              //to avoid lack of backslash in the path (with root dir)
                    {
                        if (!listBox.SelectedItem.ToString().Contains("\\")) return "\\" + listBox.SelectedItem.ToString().Remove(0, 3);

                        else return listBox.SelectedItem.ToString().Remove(0, 3);
                    }
                    else if (!listBox.SelectedItem.ToString().Contains("\\")) return "\\" + listBox.SelectedItem.ToString();
                    else return listBox.SelectedItem.ToString();
                }
                else return null;


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
                
            }


        }
        public event Func<object, EventArgs, string[]> PanelEventLoadDrives;
        private void loadDrives(object sender, EventArgs e)
        {
            if (PanelEventLoadDrives != null)
            {
                Drives = PanelEventLoadDrives(sender, e);

            }


        }

        private void changeDrive(object sender, EventArgs e)
        {
            ComboBox drives = sender as ComboBox;
            textBoxPath.Text = drives.SelectedItem.ToString();
        }



        public event Action<object, EventArgs, bool> PanelSelectedItem;

        public void SelectedItem(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if(listBox!=null)
            {
                if (listBox.SelectedItem != null)
                {

                    PanelSelectedItem(this, e, false);
                }
                else
                {
                    PanelSelectedItem(this, e, true); //change selected item to ""
                }
            } 
            else PanelSelectedItem(this, e, true); //change selected item to ""

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
            SelectedItem(sender, e); //clear selected!
        }

        public event Func<object, EventArgs, string> PanelEventReturnPath;
        private void ReturnButtonClick(object sender, EventArgs e)
        {
            CurrentPath = PanelEventReturnPath(this.CurrentPath, e);
            SelectedItem(sender, e); //clear selected!
        }

        public void Refresh(object sender, EventArgs e)
        {
            PathChanged(sender, e);
        }
    }
}
