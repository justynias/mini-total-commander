using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mini_total_commander
{
    public partial class View : Form  // to do :
                                      // handle exception, test, working with folders, Iview, user interface + disable view form properties
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
            miniTCPanel1.PanelEventReturnPath += VEventLoadReturnPath;
            miniTCPanel2.PanelEventReturnPath += VEventLoadReturnPath;
        }


        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string SelectedItem { get; set; }

        
        public event Func<object, EventArgs, string[]> ViewEventLoadDrives;
        public string[] VEventLoadDrives(object arg1, EventArgs arg2)
        {

            return ViewEventLoadDrives(arg1, arg2);

        }

        public event Func<object, EventArgs, string[]> ViewEventLoadDir;

        public string[] VEventLoadDir(object path, EventArgs arg2)
        {
            return ViewEventLoadDir(path, arg2);

        }

        public event Func<object, EventArgs, string> ViewEventLoadReturnPath;
        public string VEventLoadReturnPath(object path, EventArgs arg2)
        {
            return ViewEventLoadReturnPath(path, arg2);
        }

        private void ChangeSelected(object sender, EventArgs e)
        {
            MiniTCPanel miniTCPanel = sender as MiniTCPanel;

            if (miniTCPanel.Name == "miniTCPanel1")
            {
                miniTCPanel2.ClearSelected();
                SourcePath=miniTCPanel1.CurrentPath;
                TargetPath = miniTCPanel2.CurrentPath;
                SelectedItem = miniTCPanel1.SelectedDir;
                //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

            }
            else if (miniTCPanel.Name == "miniTCPanel2")
            {
                miniTCPanel1.ClearSelected();
                SourcePath = miniTCPanel2.CurrentPath;
                TargetPath = miniTCPanel1.CurrentPath;
                SelectedItem = miniTCPanel2.SelectedDir;
                //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

            }
        }
        public event Action<string> ViewButtonnClicked;
        
        
        public void buttonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
           
            ViewButtonnClicked(button.Text);
            miniTCPanel1.Refresh(sender, e); 
            miniTCPanel2.Refresh(sender, e);


        }
       


    }
}
