using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TaskManagerPC.Pages
{
    public partial class NotesPage : Page
    {
        private ModelTaskManager _model;
        public NotesPage()
        {
            InitializeComponent();
            _model = new ModelTaskManager(this);
        }
         private void ButtonKill_OnClick(object sender, RoutedEventArgs e)
        {
            if (ProcessesListView.SelectedItem != null)
            {
                _model.KillProcess();
            }
        }

        private void ButtonOpen_OnClick(object sender, RoutedEventArgs e)
        {
            _model.StartProcess();
        }

     
    }

    internal class ModelTaskManager
    {
            private List<Process> _processes;
            private NotesPage _view;
            private DispatcherTimer _timer;
            private Process _selectedProcess;

            public ModelTaskManager(NotesPage view)
            {
                _view = view;
                Processes = Process.GetProcesses().ToList();

                _timer = new DispatcherTimer();

                _timer.Tick += TimerOnTick;

                _timer.Interval = new TimeSpan(0, 0, 1);

                _timer.Start();
            }

            private void TimerOnTick(object sender, EventArgs eventArgs)
            {
                _selectedProcess = (Process)_view.ProcessesListView.SelectedItem;
                LoadProcesses();
                if (_selectedProcess != null)
                {
                    Process selectedProcess = _processes.Where(p => p.Id == _selectedProcess.Id).DefaultIfEmpty(null).Single();
                    _view.ProcessesListView.SelectedItem = selectedProcess;
                }
            }

            public List<Process> Processes
            {
                get
                {
                    return _processes;
                }
                set
                {
                    _processes = value;
                    _view.ProcessesListView.ItemsSource = Processes;
                }
            }

            public void LoadProcesses()
            {
                if (_view.FindTextBox.Text.Length > 0)
                {
                    List<Process> processesByName = null, processesById = null;
                    var listProcesses = Process.GetProcesses().ToList();
                    processesByName = listProcesses.Where(p => p.ProcessName.Contains(_view.FindTextBox.Text))
                        .DefaultIfEmpty(null).Select(p => p).ToList();
                    if (processesByName.Count == 1)
                    {
                        if (processesByName[0] == null)
                        {
                            processesByName = null;
                        }
                    }
                    if (Int32.TryParse(_view.FindTextBox.Text, out int res))
                    {
                        processesById = listProcesses.Where(p => p.Id.ToString().Contains(res.ToString())).DefaultIfEmpty(null).Select(p => p).ToList();
                    }

                    if (processesByName != null && processesById != null)
                    {
                        Processes = processesByName.Union(processesById).ToList();
                    }
                    else if (processesByName == null && processesById != null)
                    {
                        Processes = processesById.ToList();
                    }
                    else if (processesByName != null && processesById == null)
                    {
                        Processes = processesByName.ToList();
                    }
                }
                else
                {
                    Processes = Process.GetProcesses().ToList();
                }
            }

            public void KillProcess()
            {
                try
                {
                    var deletedProcess = Process.GetProcessById(_selectedProcess.Id);
                    deletedProcess.Kill();
                    LoadProcesses();
                    _selectedProcess = null;
                    MessageBox.Show("Process successfully closed!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, " Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            public void StartProcess()
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.ReadOnlyChecked = true;
                fileDialog.ShowDialog();
                string path = fileDialog.FileName;
                try
                {
                    Process.Start(path);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, " Ooops", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
