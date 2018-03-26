using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_total_commander
{
    public interface IPanel
    {
        string[] Files {get; set; }
        string[] Dir { get; set; }
        string[] Drives { get; set; }
        string CurrentPath { get; set; }
        //public event Action<object, EventArgs> VEvent;
    }
}
