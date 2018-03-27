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
            view.ViewEventLoadDir += View_ViewEventLoadDir;
            view.ViewEventLoadDrives += View_ViewEventLoadDrives;

        }

        //public event Action<object, EventArgs> VEvent;

        private string[] View_ViewEventLoadDir(object arg1, EventArgs arg2)
        {
           // view.Test = "dupa";
           return model.LoadPath(view.CurrentPath);
            //view.Dir = model.LoadPath(view.CurrentPath);
            // view.NewUser = model.CreateNewUser(view.FirstName, view.LastName, view.Age);
        }

        private string[] View_ViewEventLoadDrives(object arg1, EventArgs arg2)
        {
            return model.LoadDrives();
        }

    }
}

