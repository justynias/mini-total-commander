using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_total_commander
{
    public interface IView
    {
        string SourcePath { get; set; }
        string TargetPath { get; set; }
        string SelectedItem { get; set; }

        event Func<object, EventArgs, string[]> ViewEventLoadDrives;
        event Func<object, EventArgs, string[]> ViewEventLoadDir;
        event Func<object, EventArgs, string> ViewEventLoadReturnPath;
        event Action<string> ViewButtonnClicked;
    }
}
