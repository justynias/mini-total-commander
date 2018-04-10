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

        Model model;
        IView view;
        
        public Presenter(Model model, View view)
        {
            this.model = model;
            this.view = view;
           
            view.ViewEventLoadDir += View_ViewEventLoadDir;
            view.ViewEventLoadDrives += View_ViewEventLoadDrives;
            view.ViewButtonnClicked += View_ButtonClicked;
            view.ViewEventLoadReturnPath += View_ViewEventLoadReturnPath;

        }
        private bool View_ButtonClicked(string button)
        {
            try
            {
                switch (button)
            {
                case "Copy":
                    return model.CopyDir(view.SourcePath + view.SelectedItem, view.TargetPath + view.SelectedItem);
                case "Remove":
                    return model.RemoveDir(view.SourcePath + view.SelectedItem);
                case "Move":
                    return model.MoveDir(view.SourcePath + view.SelectedItem, view.TargetPath + view.SelectedItem);
                default:
                    return false;

            }
            }
            catch (IOException ioexc) { view.ErrorMessage(ioexc.Message); }
            catch (System.UnauthorizedAccessException accesexc) { view.ErrorMessage(accesexc.Message); } 
            catch (System.ArgumentException argexc) { view.ErrorMessage(argexc.Message); }
            return false;
            
        }
        private string[] View_ViewEventLoadDir(object path, EventArgs arg2)
        {
            try
            {
                return model.LoadPath(path.ToString());
            }
            catch (System.ComponentModel.Win32Exception winexc) { view.ErrorMessage(winexc.Message); }
            catch (System.InvalidOperationException invalidexc) { view.ErrorMessage(invalidexc.Message); }
            catch (System.UnauthorizedAccessException accesexc) { view.ErrorMessage(accesexc.Message); } 
            return null;
        }

        private string[] View_ViewEventLoadDrives(object arg1, EventArgs arg2)
        {
            return model.LoadDrives();
        }

        private string View_ViewEventLoadReturnPath(object path, EventArgs e)
        {
            try
            {
                return model.ReturnPath(path.ToString());
            }
            catch (System.ArgumentException argexc) { view.ErrorMessage(argexc.Message); }
            catch (System.UnauthorizedAccessException accesexc) { view.ErrorMessage(accesexc.Message); }
            return null;
        }
    }
}

