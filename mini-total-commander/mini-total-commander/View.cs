using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mini_total_commander
{
    public partial class View : Form  //communication between UC and presenter?? 
                                      //execute path, retrning, exceptions
    {

        public View()
        {
            InitializeComponent();
            miniTCPanel1.PanelEventLoadDir += VEventLoadDir;
            miniTCPanel2.PanelEventLoadDir += VEventLoadDir;
            miniTCPanel1.PanelEventLoadDrives += VEventLoadDrives;
            miniTCPanel2.PanelEventLoadDrives += VEventLoadDrives;
            miniTCPanel1.PanelSelectedItem += ChangeSelected;
            miniTCPanel2.PanelSelectedItem += ChangeSelected;

        }


        public string CurrentPath { get; set; }
        public string TargetPath { get; set; }
        public string SelectedItem { get; set; }


        public event Func<object, EventArgs, string[]> ViewEventLoadDrives;
        public string[] VEventLoadDrives(object arg1, EventArgs arg2)
        {

            return ViewEventLoadDrives(arg1, arg2);

        }

        public event Func<object, EventArgs, string[]> ViewEventLoadDir;

        public string[] VEventLoadDir(object arg1, EventArgs arg2)
        {
            CurrentPath = arg1.ToString();
            return ViewEventLoadDir(arg1, arg2);

        }

        private void ChangeSelected(object sender, EventArgs e)
        {
            MiniTCPanel miniTCPanel = sender as MiniTCPanel;

            if (miniTCPanel.Name == "miniTCPanel1")
            {
                miniTCPanel2.ClearSelected();
                CurrentPath=miniTCPanel1.CurrentPath;
                TargetPath = miniTCPanel2.CurrentPath;
                SelectedItem = miniTCPanel1.SelectedDir;
               
            }
            else if (miniTCPanel.Name == "miniTCPanel2")
            {
                miniTCPanel1.ClearSelected();
                CurrentPath = miniTCPanel2.CurrentPath;
                TargetPath = miniTCPanel1.CurrentPath;
                SelectedItem = miniTCPanel2.SelectedDir;
            }
        }
        public event Action<string> ViewButtonnClicked;
        public void buttonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ViewButtonnClicked(button.Text);
            //Button button = sender as Button;  //only test, Move it to the model!! + refresh lists
            //if (!Directory.Exists(SelectedItem)) //only working with file
            //{
            //    switch (button.Text)
            //    {
            //        case "Copy":

            //            File.Copy(SelectedItem, TargetPath + SelectedItem.Remove(0, Path.GetDirectoryName(SelectedItem).Length));
            //            break;
            //        case "Remove":
            //            File.Delete(SelectedItem);
            //            break;
            //        case "Move":
            //            File.Move(SelectedItem, TargetPath + SelectedItem.Remove(0, Path.GetDirectoryName(SelectedItem).Length));
            //            break;
            //        default:
            //            break;



            //    }
            //}
            
                
        }


    }
}
