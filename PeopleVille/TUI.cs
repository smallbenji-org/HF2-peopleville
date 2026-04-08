using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using PeopleVille.WorldBuilder;
using Terminal.Gui.App;
using Terminal.Gui.Drivers;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace PeopleVille
{
    public class TUI
    {
        private const string AllCharactersOption = "All";

        private readonly World world;
        private TableView logView;

        private readonly DataTable allLogs;
        private readonly DataTable dt;
        private ListView _characterList;

        public TUI(World world)
        {
            this.world = world;
            allLogs = CreateLogTable();
            dt = CreateLogTable();
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
            ObservableCollection<string> characterNames = new ([AllCharactersOption, .. characters.Select(x => x.Name)]);
            _characterList = new()
            {
                Width = Dim.Percent(30),
                Height = Dim.Fill(),
                Source = new ListWrapper<string>(characterNames),
                SelectedItem = 0
            };
            _characterList.ValueChanged += (s, e) => ApplyCharacterFilter();

            var dts = new DataTableSource(dt);

            logView = new()
            {
                Title = "Log View",
                X = Pos.Right(_characterList),
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                Table = dts
            };
            top.Add(_characterList);
            top.Add(logView);

            ApplyCharacterFilter();

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
            allLogs.Rows.Add(logEvent.EventTime, logEvent.Person?.Name, logEvent.EventText);
            ApplyCharacterFilter();
        }

        private void ApplyCharacterFilter()
        {
            if (_characterList == null || dt == null)
            {
                return;
            }

            dt.Rows.Clear();

            int? selectedIndex = _characterList.SelectedItem;
            if (!selectedIndex.HasValue || selectedIndex.Value <= 0)
            {
                foreach (DataRow row in allLogs.Rows)
                {
                    dt.ImportRow(row);
                }
                RefreshLogView();
                return;
            }

            int personIndex = selectedIndex.Value - 1;
            if (personIndex < 0 || personIndex >= world.People.Count)
            {
                RefreshLogView();
                return;
            }

            string selectedName = world.People[personIndex].Name;
            foreach (DataRow row in allLogs.Rows)
            {
                string rowPerson = row["Person"] as string;
                if (string.Equals(rowPerson, selectedName, StringComparison.Ordinal))
                {
                    dt.ImportRow(row);
                }
            }

            RefreshLogView();
        }

        private void RefreshLogView()
        {
            if (logView == null)
            {
                return;
            }

            logView.RefreshContentSize();
            logView.Update();
        }

        private static DataTable CreateLogTable()
        {
            DataTable table = new();
            table.Columns.Add("Time");
            table.Columns.Add("Person");
            table.Columns.Add("Event");
            return table;
        }
    }
}