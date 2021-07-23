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

         //   chartUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(10));
            internalUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
        }

        private bool canWaterLoadingStart()
        {
            // return !PD.LoadingWater_in_59A_59B_67Z_67X_41D_41A & !PD.In_SOST_OTS_KL_WV_4_1A_SQH & PD.NS64_status_net != 1 & PD.NS64_status_net != 2;
             return !PD.ZagrVodaComm_Start ;
           // return true;
        }

        private void waterLoadingStart() =>  PD.ZagrVodaComm_Start = true;

        private bool canWaterLoadingStop()
        {
            return PD.ZagrVodaComm_Start;
        }

        private void waterLoadingStop() => PD.ZagrVodaComm_Start = false;

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
        }

        ~MnemonicViewModel()
        {
            internalUpdater.Stop();
           // chartUpdater.Stop();
        }
    }
}
