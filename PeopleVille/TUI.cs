using Terminal.Gui.App;
using Terminal.Gui.Drivers;
using Terminal.Gui.Views;

namespace PeopleVille
{
    public class TUI
    {
        public TextView LogView;
        public void StartApp()
        {
            using IApplication app = Application.Create().Init();

            Window top = new Window()
            {
                Title = "PeopleVille"
            };

            LogView = new()
            {
                Title = "Log View",
                ReadOnly = true
            };

            top.Add(LogView);

            top.KeyDown += (s, k) =>
            {
                // FOR THE LOVE OF GOD, NEVER REMOVE THESE LINES # START
                if (k.KeyCode == (KeyCode)'q' || k.KeyCode == (KeyCode)'Q')
                {
                    app.RequestStop();
                    k.Handled = true;
                }
                // NEVER DELETE THESE LINES # END
            };

            app.Run(top);
        }
    }
}