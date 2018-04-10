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
    public partial class View : Form, IView  
                                      
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
        public bool Panel1Active { get; set; }
        public bool Panel2Active { get; set; }

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

        private void ChangeSelected(object sender, EventArgs e, bool nullPath)
        {
            MiniTCPanel miniTCPanel = sender as MiniTCPanel;

            if (nullPath) SelectedItem = null;
            else
            {
                if (miniTCPanel.Name == "miniTCPanel1")
                {
                    miniTCPanel2.ClearSelected();
                    Panel1Active = true;
                    Panel2Active = false;
                    //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

                }
                else if (miniTCPanel.Name == "miniTCPanel2")
                {
                    miniTCPanel1.ClearSelected();
                    Panel2Active = true;
                    Panel1Active = false;
                    //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

                }
            }
  
                

                //if(nullPath)
                //{
                //    SourcePath = "";
                //    TargetPath = "";
                //    SelectedItem = "";
                //    //MessageBox.Show("null");
                //}
                //else
                //{
                //    if (miniTCPanel.Name == "miniTCPanel1")
                //    {
                //        miniTCPanel2.ClearSelected();
                //        SourcePath = miniTCPanel1.CurrentPath;
                //        TargetPath = miniTCPanel2.CurrentPath;
                //        SelectedItem = miniTCPanel1.SelectedDir;
                //        //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

                //    }
                //    else if (miniTCPanel.Name == "miniTCPanel2")
                //    {
                //        miniTCPanel1.ClearSelected();
                //        SourcePath = miniTCPanel2.CurrentPath;
                //        TargetPath = miniTCPanel1.CurrentPath;
                //        SelectedItem = miniTCPanel2.SelectedDir;
                //        //MessageBox.Show(SelectedItem + " source: " + SourcePath + " target: " + TargetPath);

                //    }

            


    }
        public event Func<string, bool> ViewButtonnClicked;
        
        
        public void buttonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

          if(Panel1Active)
            {
                SourcePath = miniTCPanel1.CurrentPath;
                TargetPath = miniTCPanel2.CurrentPath;
                SelectedItem = miniTCPanel1.SelectedDir;
            }
          else if (Panel2Active)
            {
                SourcePath = miniTCPanel2.CurrentPath;
                TargetPath = miniTCPanel1.CurrentPath;
                SelectedItem = miniTCPanel2.SelectedDir;
            }

            if(SelectedItem!=null)
            {
                if (button.Text == "Remove")
                {
                    if (ViewButtonnClicked(button.Text))  // need better solution, more objective with these panels 
                    {
                        if (Panel1Active)
                        {
                            miniTCPanel1.Refresh(sender, e);
                        }
                        else if (Panel2Active)
                        {
                            miniTCPanel2.Refresh(sender, e);
                        }
                    }
                }
                else if (TargetPath != "")
                {
                    if(ViewButtonnClicked(button.Text))
                    {
                        miniTCPanel1.Refresh(sender, e);
                        miniTCPanel2.Refresh(sender, e);
                    }
                }
            }
        }
       
        public void ErrorMessage (string message)
        {
            MessageBox.Show(message);
        }
        


    }
}
