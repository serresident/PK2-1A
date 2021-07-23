﻿using NLog;
using NLog.Config;
using NLog.Targets;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using belofor.Dialogs;
using belofor.Models;
using belofor.Repositories;
using belofor.Services;
using belofor.ViewModels;
using belofor.Views;

namespace belofor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App() : base()
        {
            string CultureName = Thread.CurrentThread.CurrentCulture.Name;
            CultureInfo ci = new CultureInfo(CultureName);
            if (ci.NumberFormat.NumberDecimalSeparator != ".")
            {
                // Forcing use of decimal separator for numerical values

                ci.NumberFormat.CurrencyDecimalSeparator = ".";
                ci.NumberFormat.NumberDecimalSeparator = ".";
                ci.NumberFormat.PercentDecimalSeparator = ".";

                Thread.CurrentThread.CurrentCulture = ci;
            }

            AppDomain.CurrentDomain.UnhandledException += (s, a) => showErrorAndExit((a.ExceptionObject as Exception).Message, "Exception");
            //AppDomain.CurrentDomain.FirstChanceException += (s, a) => showErrorAndExit(a.Exception.Message, "AppDomain FirstChanceException");

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Xceed.Wpf.Toolkit.Licenser.LicenseKey = "WTK41-3WXJD-LTZKN-SZ6A";

            base.OnStartup(e);


            const string appId = "C800DFAE-E7BE-4AB1-895B-26DA9662EA92";
            bool createdNew;

            var mutex = new Mutex(true, appId, out createdNew);

            if (!createdNew)
            {
                showErrorAndExit("App is already running! Exiting the application", "Error");
            }


            var config = new LoggingConfiguration();

            var target = new FileTarget()
            {
                FileName = @"${basedir}\logs\" + typeof(App).FullName.Replace(".App", "_") + "${date:format=yyyy.MM.dd}.log",
                CreateDirs = true,
                Layout = "${longdate}|${level}|${message}",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveEvery = FileArchivePeriod.Day,
            };

            config.AddTarget("logfile", target);
            var rule = new LoggingRule("*", LogLevel.Info, target);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;

        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<User>();
            containerRegistry.RegisterSingleton<ProcessDataTcp>();

            containerRegistry.Register<ArchivRepository>();
            containerRegistry.Register<JournalRepository>();

            // Services
            containerRegistry.RegisterSingleton<ModbusTcpService>();
            containerRegistry.RegisterSingleton<ArchivService>();
            containerRegistry.RegisterSingleton<JournalService>();

            // Shared View Model
            containerRegistry.RegisterSingleton<MnemonicViewModel>();
            containerRegistry.RegisterSingleton<ArchivViewModel>();
            containerRegistry.RegisterSingleton<JournalViewModel>();

            // Navigation
            containerRegistry.RegisterForNavigation<MnemonicView>("MnemonicView");
            containerRegistry.RegisterForNavigation<MnemonicToolView>("MnemonicToolView");

            containerRegistry.RegisterForNavigation<ArchivView>("ArchivView");
            containerRegistry.RegisterForNavigation<ArchivToolView>("ArchivToolView");

            containerRegistry.RegisterForNavigation<JournalView>("JournalView");
            containerRegistry.RegisterForNavigation<JournalToolView>("JournalToolView");

            // Dialog
            //containerRegistry.RegisterDialog<SettingsDialog, SettingsDialogViewModel>("settings");
            containerRegistry.RegisterDialog<PasswordDialog, PasswordDialogViewModel>("password");

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MnemonicView>(() => Container.Resolve<MnemonicViewModel>());
            ViewModelLocationProvider.Register<MnemonicToolView>(() => Container.Resolve<MnemonicViewModel>());

            ViewModelLocationProvider.Register<ArchivView>(() => Container.Resolve<ArchivViewModel>());
            ViewModelLocationProvider.Register<ArchivToolView>(() => Container.Resolve<ArchivViewModel>());

            ViewModelLocationProvider.Register<JournalView>(() => Container.Resolve<JournalViewModel>());
            ViewModelLocationProvider.Register<JournalToolView>(() => Container.Resolve<JournalViewModel>());

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = Container.Resolve<IRegionManager>();
            var nav = Container.Resolve<Func<string, string, string, NavigationItemView>>();

            regionManager.RegisterViewWithRegion("NavigationRegion", () => nav("MnemonicView", "MnemonicToolView", "Мнемосхема"));
            regionManager.RegisterViewWithRegion("NavigationRegion", () => nav("ArchivView", "ArchivToolView", "Архив"));
            regionManager.RegisterViewWithRegion("NavigationRegion", () => nav("JournalView", "JournalToolView", "Журнал"));
            //regionManager.RegisterViewWithRegion("NavigationRegion", () => nav("SettingView", "SettingToolView", "Настройки" ));

            regionManager.RequestNavigate("ContentRegion", "MnemonicView");

        }


        private void showErrorAndExit(string msg, string title)
        {
            Xceed.Wpf.Toolkit.MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            Application.Current.Shutdown();
        }

    }
}
