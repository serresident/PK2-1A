﻿using NLog;
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
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;

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

        public DelegateCommand ZagrAnilin480StartCommand { get; private set; }
        public DelegateCommand ZagrAnilin480StopCommand { get; private set; }



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

        //анилин в 480

        private WindowState zagrAnilin480WndStatus = WindowState.Closed;
        public WindowState ZagrAnilin480WndStatus
        {
            get { return zagrAnilin480WndStatus; }
            set { SetProperty(ref zagrAnilin480WndStatus, value); }
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

            ZagrAnilin480StartCommand = new DelegateCommand(ZagrAnilin480Start, canZagrAnilin480Start);
            ZagrAnilin480StopCommand = new DelegateCommand(ZagrAnilin480stop, canZagrAnilin480Stop);



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

        private bool canZagrAnilin480Start() { return !PD.ZagrAnilin480_Start; }
        private void ZagrAnilin480Start() => PD.ZagrAnilin480_Start = true;
        private bool canZagrAnilin480Stop() { return PD.ZagrAnilin480_Start; }
        private void ZagrAnilin480stop() => PD.ZagrAnilin480_Start = false;


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
        // ph уставка на 1 шаге
        private float setPh_st1_1_A=7.5f;
        public float SetPh_st1_1_A
        {
            get { return setPh_st1_1_A; }
            set { SetProperty(ref setPh_st1_1_A, value); }
        }
        // доза на всю стадию
        private float setPh_zadDdoza_st1_1_A=500;
        public float SetPh_zadDoza_st1_1_A
        {
            get { return setPh_zadDdoza_st1_1_A; }
            set { SetProperty(ref setPh_zadDdoza_st1_1_A, value); }
        }


        // таймаут стабилизации ph
        private float set_time_Ph_st1_A=1;
        public float Set_time_Ph_st1_A 
        {
            get { return set_time_Ph_st1_A; }
            set { SetProperty(ref set_time_Ph_st1_A, value); }
        }



        // ph уставка на 2 шаге
        private float setPh_st2_1_A = 7.5f;
        public float SetPh_st2_1_A
        {
            get { return setPh_st2_1_A; }
            set { SetProperty(ref setPh_st2_1_A, value); }
        }

        // доза анилина
        private float doza_anilin_st2_A = 462;
        public float Doza_anilin_st2_A
        {
            get { return doza_anilin_st2_A; }
            set { SetProperty(ref doza_anilin_st2_A, value); }
        }

        // % откр клапана анилина
        private float percent_valve_Anilin  = 80;
        public float Percent_valve_Anilin
        {
            get { return percent_valve_Anilin; }
            set { SetProperty(ref percent_valve_Anilin, value); }
        }

        // ph уставка на 3 шаге
        private float setPh_st3_1_A =7.5f;
        public float SetPh_st3_1_A
        {
            get { return setPh_st3_1_A; }
            set { SetProperty(ref setPh_st3_1_A, value); }
        }

        //  доза1 диэтиламин на 3 шаге
        private float dietilAmin_doza1 = 807f;
        public float DietilAmin_doza1
        {
            get { return dietilAmin_doza1; }
            set { SetProperty(ref dietilAmin_doza1, value); }
        }


        // доза2 диэтиламин на 3 шаге
        private float dietilAmin_doza2 = 200f;
        public float DietilAmin_doza2
        {
            get { return dietilAmin_doza2; }
            set { SetProperty(ref dietilAmin_doza2, value); }
        }

        //  Температура диэтиламин для дозы2 на 3 шаге
        private float dietilAmin_Tnagr = 60f;
        public float DietilAmin_Tnagr
        {
            get { return dietilAmin_Tnagr; }
            set { SetProperty(ref dietilAmin_Tnagr, value); }
        }

        // ph уставка на 4 шаге
        private float setPh_st4_1_A = 8f;
        public float SetPh_st4_1_A
        {
            get { return setPh_st4_1_A; }
            set { SetProperty(ref setPh_st4_1_A, value); }
        }


        // ph уставка на 2,1 шаге
        private float setPh_st5_1_A = 8.5f;
        public float SetPh_st5_1_A
        {
            get { return setPh_st5_1_A; }
            set { SetProperty(ref setPh_st5_1_A, value); }
        }

        // % прикрытия клапана шаг 2,1
        private float set_ValveSteam = 40f;
        public float Set_ValveSteam
        {
            get { return set_ValveSteam; }
            set { SetProperty(ref set_ValveSteam, value); }
        }

        // Тдегазации шаг 2.1
        private float t_degaz = 67f;
        public float T_degaz
        {
            get { return t_degaz; }
            set { SetProperty(ref t_degaz, value); }
        }

        // объем воды на перегонку A
        private float volume_water_A  = 67f;
        public float Volume_water_A
        {
            get { return volume_water_A; }
            set { SetProperty(ref volume_water_A, value); }
        }

        // время  на перегонку A
        private float time_per_A = 67f;
        public float Time_per_A
        {
            get { return time_per_A; }
            set { SetProperty(ref time_per_A, value); }
        }


        //  T  перегона А
        private float t_per_A = 67f;
        public float T_per_A
        {
            get { return t_per_A; }
            set { SetProperty(ref t_per_A, value); }
        }

        //  подтверждение перевода r481
        private bool  next = false;
        public bool Next
        {
            get { return next; }
            set { SetProperty(ref next, value); }
        }





        private String statusOut ;
        // текущий статус
        public String StatusOut
        {
            get { return statusOut; }
            set { if(statusOut!= value) SetProperty(ref statusOut, value); }
        }
        int n;
        DateTime time_last;
        DateTime exposur_time;

        #region Logging
        // You can generate a Token from the "Tokens Tab" in the UI
        const string token = "mHucveNRwLyyPprDcHlGTjtXAE3B6aV3hRGW61Q3UfvT0_G6plFQvpJwS62jFrNK2g4fGEEDNU1HCAJzKoajlQ==";
        const string bucket_journal = "belofor_detail";
        const string bucket_serias = "belofor";
        const string org = "belofor";
        string mem;
        InfluxDBClient client = InfluxDBClientFactory.Create("http://192.168.120.143:8086", token.ToCharArray());
        void Send_Log (string msg)
        {
            if(!(mem==msg))
            try
            {
                string data_journal = "Log_Action,title=belofor_hmi_LogState Statelog=" + "\"" + msg + "\"";

                string data_serias = "belofor,title=mnemonic_seria_10s ";
                var writeApi = client.GetWriteApiAsync();

                // writeApi.WriteRecord(bucket_journal, org, WritePrecision.Ns, data_journal);

             
                    writeApi.WriteRecordAsync(bucket_journal, org, WritePrecision.Ns, data_journal);

                mem = msg;

            }
            catch(Exception ex)
            {

            }
            

        }
       
    #endregion

    private void updateChart()
        {
            switch (n)
            {
                case 0:
                    if (Start_recept)
                    {
                        stop_recept();
                         PD.NC_K480A_mode = false;
                         PD.NC_K480BA_ain_auto = 50;
                      
                        PD.RegPH480A_pH_zad = SetPh_st1_1_A;
                        PD.RegPH480A_DozaZad = SetPh_zadDoza_st1_1_A;
                        RegPh480aStart();

                        n = 1;
                        State = 1;
                        time_last = DateTime.Now;
                         Send_Log(StatusOut = "Запущен алгорит белофор оцд апп.K480А");
                       

                    }
                       
                    break;

                case 1 :

                    if (PD.RegPH480A_pH_zad != SetPh_st1_1_A) PD.RegPH480A_pH_zad = SetPh_st1_1_A;
                    if (PD.RegPH480A_DozaZad != SetPh_zadDoza_st1_1_A) PD.RegPH480A_DozaZad = SetPh_zadDoza_st1_1_A;



                    if (!(SetPh_st1_1_A - 0.5f <= PD.QIY_K480A && PD.QIY_K480A <= SetPh_st1_1_A + 0.5f))

                    {
                        time_last = DateTime.Now;
                        Send_Log(StatusOut = "ШАГ 1.Выполняется  доведение ph");
                    }
                    else
                    {
                        
                        if ((DateTime.Now - time_last).TotalSeconds >= Set_time_Ph_st1_A * 60)
                        {
                            StatusOut = "ШАГ 1.1 Завершение, по истечению " + ((DateTime.Now - exposur_time).TotalSeconds).ToString(" 0 ") + " секунд переход к шагу 2";
                            if ((DateTime.Now - exposur_time).TotalSeconds > 0)
                            {
                                n = 2;
                                Send_Log(StatusOut = "ШАГ 1.1 Завершение переход к шагу 2");


                                // предварительные дествия для перехода
                                if (PD.ZagrAnilin480_Nemk != 0) PD.ZagrAnilin480_Nemk = 0;
                                if (PD.ZagrAnilin480_DozaZad != Doza_anilin_st2_A) PD.ZagrAnilin480_DozaZad = Doza_anilin_st2_A;
                                if (PD.ZagrAnilin480_Xnom != Percent_valve_Anilin) PD.ZagrAnilin480_Xnom = Percent_valve_Anilin;
                                if (PD.ZagrAnilin480_Start != true) PD.ZagrAnilin480_Start = true;





                                State = 2;
                                Send_Log(StatusOut = "ШАГ 1.2 Загрузка Анилина. Ожидание окончания");
                            }
                        }
                        else
                        {
                            StatusOut = "ШАГ 1.1 Фиксация стабилизации ph, осталось" + ((Set_time_Ph_st1_A * 60) - (DateTime.Now - time_last).TotalSeconds).ToString(" 0 ") + "секунд";
                            Send_Log("ШАГ 1.1 Фиксация стабилизации ph");
                           exposur_time = DateTime.Now;
                        }
                    }
                       

                   

                    break;
                case 2:
                   
                    if (PD.ZagrAnilin480_DozaZad != Doza_anilin_st2_A) PD.ZagrAnilin480_DozaZad = Doza_anilin_st2_A;
                    if (PD.ZagrAnilin480_Xnom != Percent_valve_Anilin) PD.ZagrAnilin480_Xnom = Percent_valve_Anilin;

                    if (PD.RegPH480A_pH_zad != SetPh_st2_1_A) PD.RegPH480A_pH_zad = SetPh_st2_1_A;

                    if (!(SetPh_st2_1_A - 0.5f <= PD.QIY_K480A && PD.QIY_K480A <= SetPh_st2_1_A + 0.5f) || PD.ZagrAnilin480_Start)
                    {
                        time_last = DateTime.Now;
                        if(!PD.ZagrAnilin480_Start)
                         Send_Log(StatusOut = "ШАГ 1.2 Ожидание фиксация стабилизации ph");
                    }
                    else
                        if (!PD.ZagrAnilin480_Start)
                    {
                        Send_Log(StatusOut = "ШАГ 1.2 Фиксация стабилизации ph");
                        StatusOut = "ШАГ 1.2 Фиксация стабилизации ph, осталось" + ((Set_time_Ph_st1_A * 60) - (DateTime.Now - time_last).TotalSeconds).ToString(" 0 ") + "секунд";
                    }
                        
                   
                        

                    if ((DateTime.Now - time_last).TotalSeconds >= Set_time_Ph_st1_A * 60 && !PD.ZagrAnilin480_Start)
                    {
                         Send_Log(StatusOut = "ШАГ 1.2 Завершение, идет выстой, по истечению " + ((60-(DateTime.Now - exposur_time).TotalSeconds)).ToString(" 0 ") + " секунд переход к шагу 3");
                        if ((DateTime.Now - exposur_time).TotalSeconds > 0)
                        {
                            n = 3;
                            State = 3;

                            // предварительные дествия для перехода
                            if (PD.RegPH480A_pH_zad != SetPh_st3_1_A) PD.RegPH480A_pH_zad = SetPh_st3_1_A;
                            if (PD.ZagrDietilAminK480_Nemk != 0) PD.ZagrDietilAminK480_Nemk = 0;
                            if (PD.ZagrDietilAminK480_DozaZad1 != DietilAmin_doza1) PD.ZagrDietilAminK480_DozaZad1 = DietilAmin_doza1;
                            if (PD.ZagrDietilAminK480_DozaZad2 != DietilAmin_doza2) PD.ZagrDietilAminK480_DozaZad2 = DietilAmin_doza2;
                            if (PD.ZagrDietilAminK480_Tnagr != 60) PD.ZagrDietilAminK480_Tnagr = 60;
                            if (PD.ZagrDietilAminK480_Start != true) PD.ZagrDietilAminK480_Start = true;

                        }
                    }
                    else
                    exposur_time = DateTime.Now;

                    break;

                case 3:
                     Send_Log(StatusOut = "ШАГ 1.3 Загр. первой дозы ДиэтилАмина.");
                    if (PD.RegPH480A_pH_zad != SetPh_st3_1_A) PD.RegPH480A_pH_zad = SetPh_st3_1_A;
                    if (PD.ZagrDietilAminK480_DozaZad1 != DietilAmin_doza1) PD.ZagrDietilAminK480_DozaZad1 = DietilAmin_doza1;

                    if (PD.ZagrDietilAminK480_status == 3)
                    {
                        if (PD.ZagrDietilAminK480_Start != false) PD.ZagrDietilAminK480_Start = false;

                    }
                    
                    if (!PD.ZagrDietilAminK480_Start)
                            {
                             Send_Log(StatusOut = "ШАГ 1.4 Нагрев ,ожидание достижения уставки.");
                                n = 4;
                                State = 4;
                            // переход на следущий шаг
                            PD.VK480A_2_mode = false;           // открытие слива  конденсата
                            PD.VK480A_2_control_auto = true;

                            PD.TVK480A_mode = false;
                            PD.TVK480A_ain_auto = 100;

                             }
                         
                    break;
                case 4: // ожидание 60гр. после первой дозы ДЭА

                    //if(PD.TE_K480A_1>= DietilAmin_Tnagr)
                    //{

                    //    n = 5;
                    //    State = 5;
                    //}
                    //else
                    if (PD.RegPH480A_pH_zad != SetPh_st4_1_A) PD.RegPH480A_pH_zad = SetPh_st4_1_A;
                    if (PD.ZagrDietilAminK480_Tnagr != DietilAmin_Tnagr) PD.ZagrDietilAminK480_Tnagr = 60;
                     Send_Log(StatusOut = "ШАГ 1.4. Нагрев ,ожидание достижения уставки.");

                  

                   // if ( PD.TE_K480A_1 >= DietilAmin_Tnagr)
                        if (PD.TE_K480A_1 >= DietilAmin_Tnagr)
                        {
                      
                           
                            n = 5;
                            State = 5;
                            // предварительные дествия для перехода
                            if (PD.RegPH480A_pH_zad != SetPh_st5_1_A) PD.RegPH480A_pH_zad = SetPh_st5_1_A;
                            if (PD.ZagrDietilAminK480_Nemk != 0) PD.ZagrDietilAminK480_Nemk = 0;
                            if (PD.ZagrDietilAminK480_DozaZad1 != DietilAmin_doza2) PD.ZagrDietilAminK480_DozaZad1 = DietilAmin_doza2;
                            //if (PD.ZagrDietilAminK480_DozaZad2 != DietilAmin_doza2) PD.ZagrDietilAminK480_DozaZad2 = DietilAmin_doza2;
                          //  if (PD.ZagrDietilAminK480_Tnagr != DietilAmin_Tnagr) PD.ZagrDietilAminK480_Tnagr = DietilAmin_Tnagr;
                            if (PD.ZagrDietilAminK480_Start != true) PD.ZagrDietilAminK480_Start = true;

                        
                    }


                    break;
                   
                case 5:// загр второй дозы ДЭА

                    if (PD.ZagrDietilAminK480_DozaZad1 != DietilAmin_doza2) PD.ZagrDietilAminK480_DozaZad1 = DietilAmin_doza2;

                    

                    if (PD.RegPH480A_pH_zad != SetPh_st5_1_A) PD.RegPH480A_pH_zad = SetPh_st5_1_A;

                    if (PD.ZagrDietilAminK480_status == 3)
                    {
                        if (PD.ZagrDietilAminK480_Start != false) PD.ZagrDietilAminK480_Start = false;
                    }

                    if (PD.TE_K480A_1 >= 72 && !PD.ZagrDietilAminK480_Start)
                    {

                        if (!PD.ZagrDietilAminK480_Start)
                        {
                             Send_Log(StatusOut = "ШАГ 2.2 Нагрев ,ожидание достижения уставки.");
                            n = 6;
                            State = 6;

                            // переход на следущий шаг
                            PD.PID_ON_Tperegon_A = true;
                            PD.start_LoadWater_perA = true;

                        }
                    }
                    else
                    {
                        StatusOut = PD.ZagrDietilAminK480_Start ? "ШАГ 2.1 Ожидание заверш. загрузки ДЭА доза2" :
                           "ШАГ 2.1 Ожидание  нагрева до 72 гр.";
                       if (!(PD.TE_K480A_1 >= T_degaz)) Send_Log(StatusOut);

                    }
                        

                    
                        // PD.TVK480A_ain_auto = (PD.TE_K480A_1 >= 67)? set_ValveSteam: 100f;

                    if(PD.TE_K480A_1 >= T_degaz)
                    {
                        if (PD.TVK480A_ain_auto != Set_ValveSteam)
                            PD.TVK480A_ain_auto = Set_ValveSteam;
                        Send_Log(StatusOut = " ШАГ 2.1 Ожидание  нагрева до 72 гр. Дегазация. клапана пара " + Set_ValveSteam+"%");
                    }
                    else
                    {
                        if (PD.TVK480A_ain_auto != 100)
                            PD.TVK480A_ain_auto = 100;

                    }






                    break;

                case 6:

                    if (PD.TE_K480A_2 >= PD.TE_480A_1 + 0.5f)
                    {
                        PD.PID_ON_Tperegon_A = false;
                        Send_Log(StatusOut = " ШАГ 2.2 Превышение Темп. паров, отключение подачи пара ");
                    }
                    else PD.PID_ON_Tperegon_A = true;

                    if (PD.QIY_K480A < 7.8)
                        Start_recept=false;

                    if(PD.TE_480A_1>=97)
                    {
                      
                        PD.PID_ON_Tperegon_A = false;
                        PD.start_LoadWater_perA = false;
                        Send_Log(StatusOut = " ШАГ 2.2 Достижение темп. 97гр, оповещение оператора о НЕОБХОДИМОСТИ перевода отгона в емкость промфракции R481 ");
                        n = 7;
                    }
                    break;
                case 7:


                    break;



            }

            //if (Start_recept && n != 0)
            //{
            //    PD.RegPH480A_DozaZad = SetPh_zadDoza_st1_1_A;
            //}
                if (!Start_recept && n != 0)
            {
                PD.RegPH480A_Start = false;    // шаг1
                PD.NC_K480A_mode = false;
                PD.NC_K480BA_ain_auto = 0;

                PD.ZagrAnilin480_Start = false;// шаг2
                PD.ZagrDietilAminK480_Start = false; // шаг3


                PD.VK480A_2_mode = false;           // шаг4
                PD.VK480A_2_control_auto = false;
                PD.TVK480A_mode = false;
                PD.TVK480A_ain_auto = 0;

                PD.PID_ON_Tperegon_A = false;
                PD.start_LoadWater_perA = false;

             
                State = 0;
                 Send_Log(StatusOut = "Алгорит белофор оцд апп.K480А  прерван оператором");
                if(n==6)
                    Send_Log(StatusOut = "Алгорит белофор оцд апп.K480А, аварийное завершение, падение ph ниже 7,8");

                n = 0;
            }
            // аварийные блокировки
            //if (Start_recept)
            //{
            //    if ((PD.TE_K480A_2 - PD.TE_K480A_1) >= 0.5)
            //       if (PD.TVK480A_ain_auto !=0) PD.TVK480A_ain_auto = 0;
            //}
          
        }
      public  void stop_recept()
        {
         


                PD.RegPH480A_Start = false;    // шаг1
                PD.NC_K480A_mode = false;
                PD.NC_K480BA_ain_auto = 0;

                PD.ZagrAnilin480_Start = false;// шаг2
                PD.ZagrDietilAminK480_Start = false; // шаг3


                PD.VK480A_2_mode = false;           // шаг4
                PD.VK480A_2_control_auto = false;
                PD.TVK480A_mode = false;
                PD.TVK480A_ain_auto = 0;

                n = 0;
                State = 0;
                 Send_Log(StatusOut = "Алгорит белофор оцд апп.K480А авт.сброс");
                Thread.Sleep(500);
            
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

            ZagrAnilin480StartCommand.RaiseCanExecuteChanged();
            ZagrAnilin480StopCommand.RaiseCanExecuteChanged();

        }

        ~LogicViewModel()
        {
            internalUpdater.Stop();
          chartUpdater.Stop();
            stop_recept();
        }
    }


}
