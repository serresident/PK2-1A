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
    public class LogicViewModel : BindableBase
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

        public DelegateCommand RegPhK480aStartCommand { get; private set; }
        public DelegateCommand RegPhK480aStopCommand { get; private set; }

        public DelegateCommand RegPhK480bStartCommand { get; private set; }
        public DelegateCommand RegPhK480bStopCommand { get; private set; }

        public DelegateCommand ZagrMorfolin480StartCommand { get; private set; }
        public DelegateCommand ZagrMorfolin480StopCommand { get; private set; }

        public DelegateCommand ZagrDietil480StartCommand { get; private set; }
        public DelegateCommand ZagrDietil480StopCommand { get; private set; }

        public DelegateCommand ZagrDietilAmin480StartCommand { get; private set; }
        public DelegateCommand ZagrDietilAmin480StopCommand { get; private set; }



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


        // PH 480a
        private WindowState regPh480aWndStatus = WindowState.Closed;
        public WindowState RegPh480aWndStatus
        {
            get { return regPh480aWndStatus; }
            set { SetProperty(ref regPh480aWndStatus, value); }
        }


        // PH 480b
        private WindowState regPh480bWndStatus = WindowState.Closed;
        public WindowState RegPh480bWndStatus
        {
            get { return regPh480bWndStatus; }
            set { SetProperty(ref regPh480bWndStatus, value); }
        }

        //Морфолин в 480

        private WindowState zagrMorfolin480WndStatus = WindowState.Closed;
        public WindowState ZagrMorfolin480WndStatus
        {
            get { return zagrMorfolin480WndStatus; }
            set { SetProperty(ref zagrMorfolin480WndStatus, value); }
        }

        //Диэтил в 480

        private WindowState zagrDietil480WndStatus = WindowState.Closed;
        public WindowState ZagrDietil480WndStatus
        {
            get { return zagrDietil480WndStatus; }
            set { SetProperty(ref zagrDietil480WndStatus, value); }
        }

        //ДиэтилАмин в 480

        private WindowState zagrDietilAmin480WndStatus = WindowState.Closed;
        public WindowState ZagrDietilAmin480WndStatus
        {
            get { return zagrDietilAmin480WndStatus; }
            set { SetProperty(ref zagrDietilAmin480WndStatus, value); }
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
        public LogicViewModel(ProcessDataTcp pd, ArchivRepository archivRepository)
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

            RegPhK480aStartCommand = new DelegateCommand(RegPh480aStart, canRegPh480aStart);
            RegPhK480aStopCommand = new DelegateCommand(RegPh480astop, canRegPh480aStop);

            RegPhK480bStartCommand = new DelegateCommand(RegPh480bStart, canRegPh480bStart);
            RegPhK480bStopCommand = new DelegateCommand(RegPh480bstop, canRegPh480bStop);


            ZagrMorfolin480StartCommand = new DelegateCommand(ZagrMorfolin480Start, canZagrMorfolin480Start);
            ZagrMorfolin480StopCommand = new DelegateCommand(ZagrMorfolin480stop, canZagrMorfolin480Stop);

            ZagrDietil480StartCommand = new DelegateCommand(ZagrDietil480Start, canZagrDietil480Start);
            ZagrDietil480StopCommand = new DelegateCommand(ZagrDietil480stop, canZagrDietil480Stop);


            ZagrDietilAmin480StartCommand = new DelegateCommand(ZagrDietilAmin480Start, canZagrDietilAmin480Start);
            ZagrDietilAmin480StopCommand = new DelegateCommand(ZagrDietilAmin480stop, canZagrDietilAmin480Stop);



             chartUpdater = new PeriodicalTaskStarter(TimeSpan.FromMilliseconds(50));
            internalUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
        }
        //команды на кнопким
        private bool canWaterLoadingStart() {return !PD.ZagrVodaComm_Start ; }// проверяем доступность кнопким
        private void waterLoadingStart() =>  PD.ZagrVodaComm_Start = true; // предаем старт  на плк
        private bool canWaterLoadingStop() { return PD.ZagrVodaComm_Start; } // проверяем доступность кнопким
        private void waterLoadingStop() => PD.ZagrVodaComm_Start = false;// предаем стоп  на плк

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


        private bool canRegPh480aStart() { return !PD.RegPH480A_Start; }
        private void RegPh480aStart() => PD.RegPH480A_Start = true;
        private bool canRegPh480aStop() { return PD.RegPH480A_Start; }
        private void RegPh480astop() => PD.RegPH480A_Start = false;

        private bool canRegPh480bStart() { return !PD.RegPH480B_Start; }
        private void RegPh480bStart() => PD.RegPH480B_Start = true;
        private bool canRegPh480bStop() { return PD.RegPH480B_Start; }
        private void RegPh480bstop() => PD.RegPH480B_Start = false;

        private bool canZagrMorfolin480Start() { return !PD.ZagrMorfolinK480_Start; }
        private void ZagrMorfolin480Start() => PD.ZagrMorfolinK480_Start = true;
        private bool canZagrMorfolin480Stop() { return PD.ZagrMorfolinK480_Start; }
        private void ZagrMorfolin480stop() => PD.ZagrMorfolinK480_Start = false;


        private bool canZagrDietil480Start() { return !PD.ZagrDietilK480_Start; }
        private void ZagrDietil480Start() => PD.ZagrDietilK480_Start = true;
        private bool canZagrDietil480Stop() { return PD.ZagrDietilK480_Start; }
        private void ZagrDietil480stop() => PD.ZagrDietilK480_Start = false;


        private bool canZagrDietilAmin480Start() { return !PD.ZagrDietilAminK480_Start; }
        private void ZagrDietilAmin480Start() => PD.ZagrDietilAminK480_Start = true;
        private bool canZagrDietilAmin480Stop() { return PD.ZagrDietilAminK480_Start; }
        private void ZagrDietilAmin480stop() => PD.ZagrDietilAminK480_Start = false;


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

                  chartUpdater.Start(() => updateChart(), null);
                    
                    IsBusy = false;
                });

                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();

                t = null;
                initVM = true;
            }

        }

        private bool start_recept;
        public bool Start_recept
        {
            get { return start_recept; }
            set { SetProperty(ref start_recept, value); }
        }
       
        private int state;
        public int State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

        private float setPh_st1_1_A=7.5f;
        public float SetPh_st1_1_A
        {
            get { return setPh_st1_1_A; }
            set { SetProperty(ref setPh_st1_1_A, value); }
        }

        private float setPh_zadDdoza_st1_1_A=500;
        public float SetPh_zadDoza_st1_1_A
        {
            get { return setPh_zadDdoza_st1_1_A; }
            set { SetProperty(ref setPh_zadDdoza_st1_1_A, value); }
        }

        private float set_time_Ph_st1_A=1;
        public float Set_time_Ph_st1_A 
        {
            get { return set_time_Ph_st1_A; }
            set { SetProperty(ref set_time_Ph_st1_A, value); }
        }

        private String statusOut ;

        public String StatusOut
        {
            get { return statusOut; }
            set { SetProperty(ref statusOut, value); }
        }
        int n;
        DateTime time_last;
        DateTime exposur_time;

        private void updateChart()
        {
            switch (n)
            {
                case 0:
                    if (Start_recept)
                    {
                        // PD.NC_K480A_mode = true;
                        // PD.NC_K480BA_ain_auto = 50;
                        PD.RegPH480A_pH_zad = SetPh_st1_1_A;
                        PD.RegPH480A_DozaZad = SetPh_zadDoza_st1_1_A;
                        RegPh480aStart();

                        n = 1;
                        State = 1;
                        time_last = DateTime.Now;
                        StatusOut = "Запущен алгорит белофор оцд апп.K480А";


                    }
                       
                    break;

                case 1 :

                    PD.RegPH480A_pH_zad = SetPh_st1_1_A;
                    PD.RegPH480A_DozaZad = SetPh_zadDoza_st1_1_A;

                    

                    if (!(SetPh_st1_1_A - 0.5f <= PD.QIY_K480A && PD.QIY_K480A <= SetPh_st1_1_A + 0.5f))
                        time_last = DateTime.Now;

                    if ((DateTime.Now - time_last).TotalSeconds >= Set_time_Ph_st1_A* 60)
                    {
                        if((DateTime.Now-exposur_time).TotalSeconds > 60)
                        n = 2;
                    }
                    else
                    {
                        exposur_time = DateTime.Now;
                    }

                    break;
              

                
            }
            if (!Start_recept && n != 0)
            {
                PD.RegPH480A_Start = false;
                // PD.NC_K480A_mode = true;
                // PD.NC_K480BA_ain_auto = 0;
                n = 0;
                State = 0;
            }
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

            RegPhK480aStartCommand.RaiseCanExecuteChanged();
            RegPhK480aStopCommand.RaiseCanExecuteChanged();


            RegPhK480bStartCommand.RaiseCanExecuteChanged();
            RegPhK480bStopCommand.RaiseCanExecuteChanged();

            ZagrMorfolin480StartCommand.RaiseCanExecuteChanged();
            ZagrMorfolin480StopCommand.RaiseCanExecuteChanged();

            ZagrDietil480StartCommand.RaiseCanExecuteChanged();
            ZagrDietil480StopCommand.RaiseCanExecuteChanged();

            ZagrDietilAmin480StartCommand.RaiseCanExecuteChanged();
            ZagrDietilAmin480StopCommand.RaiseCanExecuteChanged();

        }

        ~LogicViewModel()
        {
            internalUpdater.Stop();
           // chartUpdater.Stop();
        }
    }


}
