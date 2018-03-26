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
    public partial class View : Form 
    {
        
        public View()
        {
            InitializeComponent();
            miniTCPanel1.PanelEvent += VEvent;
            miniTCPanel2.PanelEvent += VEvent;
            miniTCPanel1.PanelEventDrives += VEventDrive;
            miniTCPanel2.PanelEventDrives += VEventDrive;

        }

        public string CurrentPath { get; set; }

        public event Func<object, EventArgs, DriveInfo[]> ViewEventDrive;
        public DriveInfo[] VEventDrive(object arg1, EventArgs arg2)
        {
            
            return ViewEventDrive(arg1, arg2);

        }

        public event Func<object, EventArgs,string[]> ViewEvent;
        
       public string[] VEvent(object arg1, EventArgs arg2)
        {
            CurrentPath = arg1.ToString();
            return ViewEvent(arg1, arg2);

        }
       
       private void RemoveButton(object sender, EventArgs e)
        {
            //MessageBox.Show(); //delegate selected item
        }


    }
}
