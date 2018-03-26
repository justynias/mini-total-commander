using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace mini_total_commander
{
    public class Presenter
    {


        //IPanel panel;
        Model model;
        View view;

        public Presenter(Model model, View view)
        {
            this.model = model;
            this.view = view;
            view.ViewEvent += View_VEvent;
            view.ViewEventDrive += View_VeventDrive;

        }

        //public event Action<object, EventArgs> VEvent;

        private string[] View_VEvent(object arg1, EventArgs arg2)
        {
           // view.Test = "dupa";
           return model.LoadPath(view.CurrentPath);
            //view.Dir = model.LoadPath(view.CurrentPath);
            // view.NewUser = model.CreateNewUser(view.FirstName, view.LastName, view.Age);
        }

        private DriveInfo[] View_VeventDrive(object arg1, EventArgs arg2)
        {
            return model.LoadDrives();
        }

    }
}

