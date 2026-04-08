using System.Collections.ObjectModel;
using PeopleVille.WorldBuilder;
using Terminal.Gui.App;
using Terminal.Gui.Drivers;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace PeopleVille
{
    public class TUI
    {
        private readonly World world;
        private TextView logView;

        public TUI(World world)
        {
            this.world = world;
        }

        public void StartApp()
        {
            using IApplication app = Application.Create().Init();

            app.Keyboard.KeyDown += (s, k) =>
            {
                // FOR THE LOVE OF GOD, NEVER REMOVE THESE LINES # START
                if (k.KeyCode == (KeyCode)'q' || k.KeyCode == (KeyCode)'Q')
                {
                    app.RequestStop();
                    k.Handled = true;
                }
                // NEVER DELETE THESE LINES # END
            };

            Window top = new Window()
            {
                Title = "PeopleVille"
            };

            var characters = world.People;
            ObservableCollection<string> characterNames = new (characters.Select(x => x.Name));
            ListView _characterList = new()
            {
                Width = Dim.Percent(30),
                Height = Dim.Fill(),
                Source = new ListWrapper<string>(characterNames)
            };


            logView = new()
            {
                Title = "Log View",
                ReadOnly = true,
                X = Pos.Right(_characterList),
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                WordWrap = false
            };
            top.Add(_characterList);
            top.Add(logView);

            world.globalLogger.LogAdded += logEvent => app.Invoke(() => AppendLog(logEvent));

            _ = Task.Run(() => world.manager.StartClock());

            app.Run(top);
        }

        private void AppendLog(LogEvent logEvent)
        {
            if (logView == null)
            {
                return;
            }

            var personName = logEvent.Person?.Name ?? "System";
            var entry = $"[{logEvent.EventTime:HH:mm:ss}] {personName}: {logEvent.EventText}";

            logView.Text = string.IsNullOrWhiteSpace(logView.Text)
                ? entry
                : $"{logView.Text}\n{entry}";

            logView.MoveEnd();
        }
    }
}