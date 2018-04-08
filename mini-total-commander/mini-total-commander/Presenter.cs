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
            view.ViewEventLoadReturnPath += View_ViewEventLoadReturnPath;

        }
        private void View_ButtonClicked(string button)
        {
            switch (button)
            {
                case "Copy":
                    model.CopyFile(view.SourcePath + view.SelectedItem, view.TargetPath + view.SelectedItem);
                    

                    break;
                case "Remove":
                    model.RemoveFile(view.SourcePath + view.SelectedItem);
                    break;
                case "Move":
                    model.MoveFile(view.SourcePath + view.SelectedItem, view.TargetPath + view.SelectedItem);
                    break;
                default:
                    break;

            }

        }
        private string[] View_ViewEventLoadDir(object path, EventArgs arg2)
        {

            return model.LoadPath(path.ToString());

        }

        private string[] View_ViewEventLoadDrives(object arg1, EventArgs arg2)
        {
            return model.LoadDrives();
        }

        private string View_ViewEventLoadReturnPath(object path, EventArgs e)
        {
            return model.ReturnPath(path.ToString());
        }
    }
}

