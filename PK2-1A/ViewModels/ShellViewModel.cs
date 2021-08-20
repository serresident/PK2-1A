using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using belofor.Models;
using belofor.Services;

namespace belofor.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private PeriodicalTaskStarter modbusTask = new PeriodicalTaskStarter(TimeSpan.FromMilliseconds(50));
        private readonly ModbusTcpService modbusTcpService;

        private PeriodicalTaskStarter journalTask = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
        private readonly JournalService journalService;

        private PeriodicalTaskStarter archivTask = new PeriodicalTaskStarter(TimeSpan.FromSeconds(10));
        private readonly ArchivService archivService;

        public User User { get; set; }

        const string title = "Схема производства Белофоров";
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, title + value); }
        }


        public void ConnectedChanged(bool status) => PlcStatus = status;
        private bool plcStatus = false;
        public bool PlcStatus
        {
            get { return plcStatus; }
            set { SetProperty(ref plcStatus, value); }
        }

        public DelegateCommand ShowSettingsDialogCommand { get; private set; }

        public ShellViewModel(IDialogService dialogService, IEventAggregator eventAggregator, User user, ModbusTcpService modbusTcpService, ArchivService archivService, JournalService journalService)
        {
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.User = user;
            this.modbusTcpService = modbusTcpService;
            this.archivService = archivService;
            this.journalService = journalService;

            ShowSettingsDialogCommand = new DelegateCommand(ShowSettingsDialog, () => User.IsAuthorized).ObservesProperty(() => User.IsAuthorized); ;

        }

        private void ShowSettingsDialog()
        {

            dialogService.ShowDialog("settings");
        }

        internal void InputPassword()
        {
            dialogService.ShowDialog("password", r =>
            {
                if (r.Parameters.ContainsKey("password"))
                {
                    if (r.Parameters.GetValue<string>("password") == "2020")
                        User.IsAuthorized = true;
                }
            });
        }

        internal void OnLoad()
        {
            modbusTcpService.ConnectedChangedHandler += ConnectedChanged;
            modbusTask.Start(() => modbusTcpService.Worker(), () => modbusTcpService.AfterStop());
            archivTask.Start(() => archivService.Worker(), null);
            journalTask.Start(() => journalService.Worker(), null);
        }

        internal void OnClosing()
        {
            journalTask.Stop();
            archivTask.Stop();

            modbusTcpService.ConnectedChangedHandler -= ConnectedChanged;
            modbusTask.Stop();
        }
    }

}

