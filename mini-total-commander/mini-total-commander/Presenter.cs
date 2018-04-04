using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            view.ViewButtonnClicked += View_ButtonClicked;

        }
        private void View_ButtonClicked(string button)
        {
            switch (button)
            {
                case "Copy":
                    
                    break;
                case "Remove":
                    model.RemoveFile(view.SelectedItem, view.CurrentPath);
                    break;
                case "Move":

                    break;
                default:
                    break;

            }

        }
        private string[] View_ViewEventLoadDir(object arg1, EventArgs arg2)
        {

           return model.LoadPath(view.CurrentPath);
          
        }

        private string[] View_ViewEventLoadDrives(object arg1, EventArgs arg2)
        {
            return model.LoadDrives();
        }

    }
}

