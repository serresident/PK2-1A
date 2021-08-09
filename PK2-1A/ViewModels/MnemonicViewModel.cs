using NLog;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using belofor.Helpers;
using belofor.Models;
using belofor.Repositories;
using belofor.Services;
using Xceed.Wpf.Toolkit;

namespace belofor.ViewModels
{
    public class MnemonicViewModel : BindableBase
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private bool initVM;
        private PeriodicalTaskStarter chartUpdater;
        private PeriodicalTaskStarter internalUpdater;

        private readonly ArchivRepository archivRepository;

        public DelegateCommand WaterLoadingStartCommand { get; private set; }
        public DelegateCommand WaterLoadingStopCommand { get; private set; }     
        
        public DelegateCommand HotWaterLoadingStartCommand { get; private set; }
        public DelegateCommand HotWaterLoadingStopCommand { get; private set; }      

        public DelegateCommand Hot480WaterLoadingStartCommand { get; private set; }
        public DelegateCommand Hot480WaterLoadingStopCommand { get; private set; }

        public DelegateCommand UnloadFromR422StartCommand { get; private set; }
        public DelegateCommand UnloadFromR422StopCommand { get; private set; }


        public DelegateCommand Ohlagd480StartCommand { get; private set; }
        public DelegateCommand Ohlagd480StopCommand { get; private set; }


        private ObservableRangeCollection<ThermoChartPoint> points;
        public ObservableRangeCollection<ThermoChartPoint> Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }

        private WindowState waterLoadingWndStatus = WindowState.Closed;
        public WindowState WaterLoadingWndStatus
        {
            get { return waterLoadingWndStatus; }
            set { SetProperty(ref waterLoadingWndStatus, value); }
        }

        private WindowState hotwaterLoadingWndStatus = WindowState.Closed;
        public WindowState HotWaterLoadingWndStatus
        {
            get { return hotwaterLoadingWndStatus; }
            set { SetProperty(ref hotwaterLoadingWndStatus, value); }

        }

        private WindowState hot480waterLoadingWndStatus = WindowState.Closed;

        public WindowState Hot480WaterLoadingWndStatus
        {
            get { return hot480waterLoadingWndStatus; }
            set { SetProperty(ref hot480waterLoadingWndStatus, value); }
        }
        // выгрузка r422
        private WindowState unloadFromR422WndStatus = WindowState.Closed;
        public WindowState UnloadFromR422WndStatus
        {
            get { return unloadFromR422WndStatus; }
            set { SetProperty(ref unloadFromR422WndStatus, value); }
        }

                    // охлаждение 480
        private WindowState ohlagd480WndStatus = WindowState.Closed;
        public WindowState Ohlagd480WndStatus
        {
            get { return ohlagd480WndStatus; }
            set { SetProperty(ref ohlagd480WndStatus, value); }
        }

        //термоцикл
        private WindowState thermoCycl_1AWndStatus = WindowState.Closed;
        public WindowState ThermoCycl_1AWndStatus
        {
            get { return thermoCycl_1AWndStatus; }
            set { SetProperty(ref thermoCycl_1AWndStatus, value); }
        }

        private ProcessDataTcp _pd;
        public ProcessDataTcp PD
        {
            get { return _pd; }
            set { SetProperty(ref _pd, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        public MnemonicViewModel(ProcessDataTcp pd, ArchivRepository archivRepository)
        {
            PD = pd;
            this.archivRepository = archivRepository;

            WaterLoadingStartCommand = new DelegateCommand(waterLoadingStart, canWaterLoadingStart);
            WaterLoadingStopCommand = new DelegateCommand(waterLoadingStop, canWaterLoadingStop);

            HotWaterLoadingStartCommand = new DelegateCommand(hotwaterLoadingStart, canHotWaterLoadingStart);
            HotWaterLoadingStopCommand = new DelegateCommand(hotwaterLoadingStop, canHotWaterLoadingStop);

            Hot480WaterLoadingStartCommand = new DelegateCommand(hot480waterLoadingStart, canHot480WaterLoadingStart);
            Hot480WaterLoadingStopCommand = new DelegateCommand(hot480waterLoadingStop, canHot480WaterLoadingStop);

            UnloadFromR422StartCommand = new DelegateCommand(unloadFromR422Start, canUnloadFromR422Start);
            UnloadFromR422StopCommand = new DelegateCommand(unloadFromR422stop, canUnloadFromR422Stop);

            Ohlagd480StartCommand = new DelegateCommand(Ohlagd480Start, canOhlagd480Start);
            Ohlagd480StopCommand = new DelegateCommand(Ohlagd480stop, canOhlagd480Stop);


            //   chartUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(10));
            internalUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
        }

        private bool canWaterLoadingStart() {return !PD.ZagrVodaComm_Start ; }
        private void waterLoadingStart() =>  PD.ZagrVodaComm_Start = true;
        private bool canWaterLoadingStop() { return PD.ZagrVodaComm_Start; }
        private void waterLoadingStop() => PD.ZagrVodaComm_Start = false;

        private bool canHotWaterLoadingStart() { return !PD.ZagrKond460Comm_Start; }
        private void hotwaterLoadingStart() =>  PD.ZagrKond460Comm_Start = true;
        private bool canHotWaterLoadingStop() {return PD.ZagrKond460Comm_Start; } 
        private void hotwaterLoadingStop() => PD.ZagrKond460Comm_Start = false;

        private bool canHot480WaterLoadingStart() { return !PD.ZagrKond480Comm_Start; }
        private void hot480waterLoadingStart() =>  PD.ZagrKond480Comm_Start = true;
        private bool canHot480WaterLoadingStop() {return PD.ZagrKond480Comm_Start; } 
        private void hot480waterLoadingStop() => PD.ZagrKond480Comm_Start = false;

        private bool canUnloadFromR422Start() { return !PD.fromR422_xStart; }
        private void unloadFromR422Start() =>  PD.fromR422_xStart = true;
        private bool canUnloadFromR422Stop() {return PD.fromR422_xStart; } 
        private void unloadFromR422stop() => PD.fromR422_xStart = false;

        private bool canOhlagd480Start() { return !PD.Ohlagd480_Start; }
        private void Ohlagd480Start() => PD.Ohlagd480_Start = true;
        private bool canOhlagd480Stop() { return PD.Ohlagd480_Start; }
        private void Ohlagd480stop() => PD.Ohlagd480_Start = false;


        public void OnLoading()
        {
            if (!initVM)
            {
                var t = new Thread(() =>
                {
                    IsBusy = true;
                    
                    internalUpdater.Start(() => internalUpdate(), null);

                    List<ThermoChartPoint> _points = new List<ThermoChartPoint>();
                    DateTime dt = DateTime.MinValue;

                    var dataPoints = archivRepository.GetMeasurements(DateTime.Now.AddHours(-5), DateTime.Now);
                    if (dataPoints == null) // повторяем запрос если возникло исключение
                    dataPoints = archivRepository.GetMeasurements(DateTime.Now.AddHours(-5), DateTime.Now);


                    //foreach (KeyValuePair<DateTime, Dictionary<string, string>> entry in dataPoints)
                    //{
                    //    try
                    //    {
                    //        _points.Add(new ThermoChartPoint()
                    //        {
                    //            DTS = entry.Key,
                    //            TE_1_1A = entry.Value.ContainsKey("TE_1_1A") ? float.Parse(entry.Value["TE_1_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_1_1A = entry.Value.ContainsKey("TE_1_1A") ? float.Parse(entry.Value["TE_1_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_2_1A = entry.Value.ContainsKey("TE_2_1A") ? float.Parse(entry.Value["TE_2_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_3_1A = entry.Value.ContainsKey("TE_3_1A") ? float.Parse(entry.Value["TE_3_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_4_1A = entry.Value.ContainsKey("TE_4_1A") ? float.Parse(entry.Value["TE_4_1A"], CultureInfo.InvariantCulture) : float.NaN
                    //        });
                    //        dt = entry.Key;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                    //    }

                    //}

                    Points = new ObservableRangeCollection<ThermoChartPoint>(_points);

                  //  chartUpdater.Start(() => updateChart(), null);
                    
                    IsBusy = false;
                });

                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();

                t = null;
                initVM = true;
            }

        }

        private void updateChart()
        {
            //App.Current.Dispatcher?.Invoke(() =>
            //{
            //    Points.Add(new ThermoChartPoint()
            //    {
            //        DTS = DateTime.Now,
            //        TE_1_1A = PD.TE_1_1A,
            //        TE_2_1A = PD.TE_2_1A,
            //        TE_3_1A = PD.TE_3_1A,
            //        TE_4_1A = PD.TE_4_1A
            //    });

            //    IEnumerable<ThermoChartPoint> deletedItem = (from p in Points where p.DTS < DateTime.Now.AddHours(-5) select p).ToList();
            //    if (deletedItem.Count() > 0)
            //        Points.RemoveRange(deletedItem);

            //});
        }

        private void internalUpdate()
        {
            WaterLoadingStartCommand.RaiseCanExecuteChanged();
            WaterLoadingStopCommand.RaiseCanExecuteChanged(); 

            HotWaterLoadingStartCommand.RaiseCanExecuteChanged();
            HotWaterLoadingStopCommand.RaiseCanExecuteChanged();  

            Hot480WaterLoadingStartCommand.RaiseCanExecuteChanged();
            Hot480WaterLoadingStopCommand.RaiseCanExecuteChanged();

            UnloadFromR422StartCommand.RaiseCanExecuteChanged();
            UnloadFromR422StopCommand.RaiseCanExecuteChanged();

            Ohlagd480StartCommand.RaiseCanExecuteChanged();
            Ohlagd480StopCommand.RaiseCanExecuteChanged();
        }

        ~MnemonicViewModel()
        {
            internalUpdater.Stop();
           // chartUpdater.Stop();
        }
    }
}
