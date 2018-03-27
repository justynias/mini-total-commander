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
            miniTCPanel1.PanelEventLoadDir += VEventLoadDir;
            miniTCPanel2.PanelEventLoadDir += VEventLoadDir;
            miniTCPanel1.PanelEventLoadDrives += VEventLoadDrives;
            miniTCPanel2.PanelEventLoadDrives += VEventLoadDrives;
            //miniTCPanel1.PathChanged += VEventLoadDir;

        }

        public string CurrentPath { get; set; }

        public event Func<object, EventArgs, string[]> ViewEventLoadDrives;
        public string[] VEventLoadDrives(object arg1, EventArgs arg2)
        {
            
            return ViewEventLoadDrives(arg1, arg2);

        }

        public event Func<object, EventArgs,string[]> ViewEventLoadDir;
        
       public string[] VEventLoadDir(object arg1, EventArgs arg2)
        {
            CurrentPath = arg1.ToString();
            return ViewEventLoadDir(arg1, arg2);

        }
        
       private void RemoveButton(object sender, EventArgs e)
        {
           
        }


    }
}
