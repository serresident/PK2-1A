using PK2_1A.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK2_1A.Models
{
    // для цветов
    //https://chir.ag/projects/name-that-color/#BF788B 
    public class ProcessDataTcp : ProcessData
    {
        // Inputs
        #region inputs

        //public bool In_ER_W59B { get { return getValue<bool>(); } }
        //public bool In_ER_W67X { get { return getValue<bool>(); } }
        //public bool In_ER_W67Z { get { return getValue<bool>(); } }
        //public bool In_ER_W59A { get { return getValue<bool>(); } }

        //public bool In_ER_W41D { get { return getValue<bool>(); } }

        ///* MDS DIO-16BD A2 **********************************/
        //// клапан V75
        //public bool In_SOST_OTS_KL_V75_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V75_SQL { get { return getValue<bool>(); } }

        //// клапан V64A
        //public bool In_SOST_OTS_KL_V64A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V64A_SQL { get { return getValue<bool>(); } }

        //// клапан VP53
        //public bool In_SOST_OTS_KL_VP53_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_VP53_SQL { get { return getValue<bool>(); } }

        //// клапан VP51
        //public bool In_SOST_OTS_KL_VP51_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_VP51_SQL { get { return getValue<bool>(); } }

        //// клапан TV1_41D
        //public bool In_SOST_OTS_KL_TV1_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_TV1_41D_SQL { get { return getValue<bool>(); } }

        //// клапан TV2_41D
        //public bool In_SOST_OTS_KL_TV2_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_TV2_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV1_41D
        //public bool In_SOST_OTS_KL_WV1_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV1_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV2_41D
        //public bool In_SOST_OTS_KL_WV2_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV2_41D_SQL { get { return getValue<bool>(); } }

        ///* MDS DIO-16BD A3 **********************************/
        //// клапан WV5 41D 
        //public bool In_SOST_OTS_KL_WV5_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV5_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV3 41D 
        //public bool In_SOST_OTS_KL_WV3_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV3_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV4 41D 
        //public bool In_SOST_OTS_KL_WV4_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV4_41D_SQL { get { return getValue<bool>(); } }

        //// клапан FV 41D 
        //public bool In_SOST_OTS_KL_FV_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_FV_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV6 41D 
        //public bool In_SOST_OTS_KL_WV6_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV6_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV_4 P59B 
        //public bool In_SOST_OTS_KL_WV_4_P59B_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_4_P59B_SQL { get { return getValue<bool>(); } }

        //// клапан V 59A-3 
        //public bool In_SOST_OTS_KL_V_59A_3_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_59A_3_SQL { get { return getValue<bool>(); } }

        //// клапан V 59A-2 
        //public bool In_SOST_OTS_KL_V_59A_2_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_59A_2_SQL { get { return getValue<bool>(); } }

        ///* MDS DIO-16BD A4 **********************************/
        //// клапан V 59A-4 
        //public bool In_SOST_OTS_KL_V_59A_4_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_59A_4_SQL { get { return getValue<bool>(); } }

        //// клапан V 59A-1 
        //public bool In_SOST_OTS_KL_V_59A_1_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_59A_1_SQL { get { return getValue<bool>(); } }

        //// клапан V 59A-5 
        //public bool In_SOST_OTS_KL_V_59A_5_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_59A_5_SQL { get { return getValue<bool>(); } }

        //// клапан V P41D 
        //public bool In_SOST_OTS_KL_V_P41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_P41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV 67L 
        //public bool In_SOST_OTS_KL_WV_67L_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_67L_SQL { get { return getValue<bool>(); } }

        //// клапан V 14 
        //public bool In_SOST_OTS_KL_V_14_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_14_SQL { get { return getValue<bool>(); } }

        //// клапан V 62H 
        ////public bool In_SOST_OTS_KL_V_62H_SQH { get { return getValue<bool>(); } }
        ////public bool In_SOST_OTS_KL_V_62H_SQL { get { return getValue<bool>(); } }

        //// клапан V 41D 
        //public bool In_SOST_OTS_KL_V_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_41D_SQL { get { return getValue<bool>(); } }

        ///* MDS DIO-16BD A5 **********************************/
        //// клапан V2 41D 
        //public bool In_SOST_OTS_KL_V2_41D_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V2_41D_SQL { get { return getValue<bool>(); } }

        //// клапан WV-2 P59B
        //public bool In_SOST_OTS_KL_WV_2_P59B_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_2_P59B_SQL { get { return getValue<bool>(); } }

        //// Двигатель насоса поз. 48
        //public bool In_SOST_NASOS_48 { get { return getValue<bool>(); } }

        //// Max уровень в расшир. баке поз. 62н
        //public bool In_MAX_LEVEL_LSA_62H { get { return getValue<bool>(); } }

        //public bool In_SOST_MESHALKI_KV_59B { get { return getValue<bool>(); } }
        //public bool In_SOST_MESHALKI_KV_67X { get { return getValue<bool>(); } }
        //public bool In_SOST_MESHALKI_KV_67Z { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_1_P59B_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_1_P59B_SQL { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_67Z_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_67Z_SQL { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_67X_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_67X_SQL { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_2_67X_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_2_67X_SQL { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_2_67Z_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_2_67Z_SQL { get { return getValue<bool>(); } }

        //public bool In_SOST_OTS_KL_WV_59A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_59A_SQL { get { return getValue<bool>(); } }
        //public bool In_MIN_LEVEL_ZAPOR_JIDKOSTI { get { return getValue<bool>(); } }


        ////Дозреватель

        //// клапан VP59B__2
        //public bool In_SOST_OTS_KL_VP59B__2_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_VP59B__2_SQL { get { return getValue<bool>(); } }

        //// клапан QVP59B__2
        //public bool In_SOST_OTS_KL_QVP59B__2_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_QVP59B__2_SQL { get { return getValue<bool>(); } }

        //// клапан V_2_41A
        //public bool In_SOST_OTS_KL_V_2_41A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_2_41A_SQL { get { return getValue<bool>(); } }

        //// клапан V_1_41A
        //public bool In_SOST_OTS_KL_V_1_41A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_1_41A_SQL { get { return getValue<bool>(); } }

        //// клапан FV_41A
        //public bool In_SOST_OTS_KL_FV_41A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_FV_41A_SQL { get { return getValue<bool>(); } }

        //// клапан V_P41A
        //public bool In_SOST_OTS_KL_V_P41A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_V_P41A_SQL { get { return getValue<bool>(); } }

        //// клапан TE_41A
        //public bool In_SOST_OTS_KL_TV_41A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_TV_41A_SQL { get { return getValue<bool>(); } }

        //// 1A
        //// клапан WV p59a 
        //public bool In_SOST_OTS_KL_WV_P59A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_P59A_SQL { get { return getValue<bool>(); } }

        //// клапан WV-1 p59a 
        //public bool In_SOST_OTS_KL_WV_1_P59A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_1_P59A_SQL { get { return getValue<bool>(); } }

        //// клапан WV 1A
        //public bool In_SOST_OTS_KL_WV_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_1A_SQL { get { return getValue<bool>(); } }

        //// клапан WV-1 1A
        //public bool In_SOST_OTS_KL_WV_1_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_1_1A_SQL { get { return getValue<bool>(); } }


        //// клапан WV-2 1A
        //public bool In_SOST_OTS_KL_WV_2_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_2_1A_SQL { get { return getValue<bool>(); } }

        //// клапан WV3-1A
        //public bool In_SOST_OTS_KL_WV_3_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_3_1A_SQL { get { return getValue<bool>(); } }

        //// клапан WV5-1A
        //public bool In_SOST_OTS_KL_WV_5_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_5_1A_SQL { get { return getValue<bool>(); } }

        //// клапан WV P59B/2
        //public bool In_SOST_OTS_KL_WV_P59B_2_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_P59B_2_SQL { get { return getValue<bool>(); } }

        //// клапан WV4-1A
        //public bool In_SOST_OTS_KL_WV_4_1A_SQH { get { return getValue<bool>(); } }
        //public bool In_SOST_OTS_KL_WV_4_1A_SQL { get { return getValue<bool>(); } }


        #endregion

        //Coils
        #region Coils


        //line1_1  (ttyS2)       
        //owen mv110 16r ad=2      
        public bool NS_VodaArt_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 1 line1_1 owen mv110 16r ad=2 _ch 1
        public bool NS_VodaArt_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 2 line1_1 owen mv110 16r ad=2 _ch 2
        public bool NS_VodaGor_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 3 line1_1 owen mv110 16r ad=2 _ch 3
        public bool NS_VodaGor_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 4 line1_1 owen mv110 16r ad=2 _ch 4
        public bool valve_PromivkaPH_610 { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 5 line1_1 owen mv110 16r ad=2 _ch 5
        public bool valve_PromivkaPH_450A { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 6 line1_1 owen mv110 16r ad=2 _ch 6

        //line2_1  (ttyS4)       
        // mu 110 16r ad=9       
        public bool TV_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 7  line2_2 mu 110 16r ad=9  _ch 1
        public bool V_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 8  line2_2 mu 110 16r ad=9  _ch 2
        public bool promiv_ph_K480a { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 9  line2_2 mu 110 16r ad=9  _ch 3
        public bool V_E461A_1_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 10  line2_2 mu 110 16r ad=9  _ch 4
        public bool V_E461A_2_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 11  line2_2 mu 110 16r ad=9  _ch 5
        public bool V_E461A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 12  line2_2 mu 110 16r ad=9  _ch 6
        public bool NC_K450A_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 13  line2_2 mu 110 16r ad=9  _ch 7
        public bool NC_K450A_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad= 14  line2_2 mu 110 16r ad=9  _ch 8

        // HMI
        public bool NS_P470_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=15 // нас
        public bool NS_P470_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=16
        public bool NS_P470_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=17

        public bool Logging  { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad 18

public bool Pmin_P461 { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad 19

public bool FV_R631A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=20 do1
public bool FV_R603_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 21  do 2
public bool FV_R521_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 22  do 3
public bool LV_R422_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 23  do 4
public bool TV_K610_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 24  do 5
public bool FV_K480A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 25  do 6
public bool FV_K480B_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 26  do 7
public bool FV_K460A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 27  do 8
public bool FV_K460B_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 28  do 9
public bool FV_K460C_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 29  do 10
public bool FV_R471_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 30  do 11
public bool FV_K450A_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 31  do 12
public bool V_K610_dout { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 32  do 13
public bool empty { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 33  do 14
public bool NS_P470_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 34  do 15
public bool NS_P470_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 35  do 16
public bool NS_P603_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 36  do 17
public bool NS_P521_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 37  do 18
public bool NS_P631A_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 38  do 19
public bool NS_P461_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 39  do 20
public bool NC_P412_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 40  do 21
public bool NC_P412_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 41  do 22
public bool NC_610M_pusk { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 42  do 23
public bool NC_610M_stop { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad= 43  do 24

//********************** Dvigateli
public bool NS_P603_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=44  Управление насосом соды P603
public bool NS_P521_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=45   Управление насосом соды P521
public bool NS_P631A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=46   Управление насосом соды P631A
public bool NS_P461_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=47   Управление насосом соды P461

public bool NS_VodaArt_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=48 управление насосом арт воды
public bool NS_VodaArt_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=49 авт
public bool NS_VodaArt_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=50 ручн 

public bool NS_VodaGor_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=51  управление насосом гор воды
public bool NS_VodaGor_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=52
public bool NS_VodaGor_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=53

public bool NC_M610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=54 управ меш реактора
public bool NC_M610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=55
public bool NC_M610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=56

public bool NC_P412_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=57 управ меш реактора
public bool NC_P412_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=58
public bool NC_P412_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=59

//***************************KLAPAN*******************

public bool FV_R631A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=60
public bool FV_R631A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=61
public bool FV_R631A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=62

public bool FV_R603_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=63
public bool FV_R603_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=64
public bool FV_R603_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=65

public bool FV_R521_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=66
public bool FV_R521_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=67
public bool FV_R521_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=68

public bool LV_R422_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=69
public bool LV_R422_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=70
public bool LV_R422_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=71

public bool TV_K610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=72
public bool TV_K610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=73
public bool TV_K610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=74

public bool FV_K480A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=75
public bool FV_K480A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=76
public bool FV_K480A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=77

public bool FV_K480B_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=78
public bool FV_K480B_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=79
public bool FV_K480B_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=80

public bool FV_K460A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=81
public bool FV_K460A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=82
public bool FV_K460A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=83

public bool FV_K460B_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=84
public bool FV_K460B_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=85
public bool FV_K460B_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=86

public bool FV_K460C_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=87
public bool FV_K460C_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=88
public bool FV_K460C_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=89

public bool FV_R471_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=90
public bool FV_R471_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=91
public bool FV_R471_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=92

public bool FV_K450A_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=90
public bool FV_K450A_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=91
public bool FV_K450A_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=92

public bool V_K610_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=93
public bool V_K610_control_auto { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=94
public bool V_K610_control_man { get { return getValue<bool>(); } set { setValue<bool>(value); } } // ad=95

public bool FV_K480B_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }// ad=96
public bool FV_K480A_reg_mode { get { return getValue<bool>(); } set { setValue<bool>(value); } }//ad=97

public bool ZagrVodaComm_Start { get { return getValue<bool>(); } set { setValue<bool>(value); } } //ad=98

        //public bool LoadingWater_in_59A_59B_67Z_67X_41D_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool LoadingComponents_from_59A_67Z_67X_TO_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool isPaused_Mass_loading_from_59A_to_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool isPaused_Mass_loading_from_59B_to_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool isPaused_Mass_loading_from_67Z_to_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool isPaused_Mass_loading_from_67X_to_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_V_P53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_P51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool IsMAN_OTS_KL_V_P53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool IsMAN_OTS_KL_V_P51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_P53_in_75 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_P51_in_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool Zagruzka_Over_P53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_P51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool Zagruzka_Over_P41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_P41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_31 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Zagruzka_Over_48 { get { return getValue<bool>(); } set { setValue<bool>(value); } }


        ///* MDS DIO-16BD A6 **********************************/
        //public bool UPRAV_OTS_KL_V75 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V64A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_VP53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_VP51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_TV1_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_TV2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV1_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        ///* MDS DIO-16BD A7 **********************************/
        //public bool UPRAV_OTS_KL_WV5_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV3_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV4_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_FV_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV6_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_2_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_4_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_59A_3 { get { return getValue<bool>(); } set { setValue<bool>(value); } }


        ///* MDS DIO-16BD A8 **********************************/
        //public bool UPRAV_OTS_KL_V_59A_2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_59A_4 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_59A_1 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_59A_5 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_P41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_67L { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_14 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_525 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_V2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Nitrogen_Purge_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_PV6 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool NASOS_34H_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Thermo_PV5_In_Mass { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_TV35H { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Thermo_41D_START_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool NASOS_48_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MESHAL_59A_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MESHAL_41D_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool KV_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool KV_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool KV_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_1_P59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_2_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool UPRAV_OTS_KL_WV_2_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool Loading_from_67L_to_59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool Thermo_59A_START_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool ExternControlP41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_P41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool ExternControlP51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool ExternControlP53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_OTS_KL_WV_4_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV6_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        ////
        //public bool MAN_UPRAV_KL_PV5 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_PV6 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_KL_WV_1_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_WV_1_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_WV_3_P59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_INV_P59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_FV_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_OTS_KL_V_59A_3 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_1_P59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV1_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_2_67Z { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV4_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_2_67X { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV3_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_14 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_67L { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_59A_4 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_VP53 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V75 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_59A_2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_OTS_KL_VP51 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV5_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_2_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_59A_1 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_OTS_KL_TV1_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_TV2_41D { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_UPRAV_KL_V62H { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_NASOS_48_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_59A_5 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MAN_NASOS_34H_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_VP59B__2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_VP59B__2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_QVP59B__2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_QVP59B__2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_V_2_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_2_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_V_1_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_1_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_FV_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_FV_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_V_P41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_P41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool ExternControlP41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_TE_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_TE_41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool MESHAL_41A_PUSK_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool Thermo_41A_START_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool IS_LOAD_FROM_41D_TO41A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool Discharge_59B { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_P59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_P59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_1_P59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_1_P59A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_1_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_1_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_2_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_2_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_3_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_3_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //public bool UPRAV_OTS_KL_WV_5_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_5_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //// клапан WV P59B/2
        //public bool UPRAV_OTS_KL_WV_P59B_2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_P59B_2 { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //// клапан WV4-1A
        //public bool UPRAV_OTS_KL_WV_4_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_WV_4_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //// клапан V-P1A
        //public bool UPRAV_OTS_KL_V_P1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_OTS_KL_V_P1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        //[JournalAttribute("Изменение состояния термоцикла реактора 1A >> [{0}] --> [{1}]")]
        //public bool Thermo_1A_START_STOP { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_9A { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool MAN_UPRAV_KL_10A { get { return getValue<bool>(); } set { setValue<bool>(value); } }


        //public bool Thermo_1A_In_Mass { get { return getValue<bool>(); } set { setValue<bool>(value); } }
        //public bool LoadingWater_in_1A { get { return getValue<bool>(); } set { setValue<bool>(value); } }

        #endregion

        // Inputs Registers
        #region Inputs Registers

        //line1_1       
        //owen mv 8as ad=3      
        public Single WE_D470 { get { return getValue<Single>(); } }// ad= 1 _ch 1
        public Single LT_R137 { get { return getValue<Single>(); } }// ad= 3 _ch 2
        public Single WE_R422 { get { return getValue<Single>(); } }// ad= 5 _ch 3
        public Single LT_R461 { get { return getValue<Single>(); } }// ad= 7 _ch 4
        public Single TE_K610 { get { return getValue<Single>(); } }// ad= 9 _ch 5
        public Single PIT_P603 { get { return getValue<Single>(); } }// ad= 11 _ch 6
        public Single PIT_P521 { get { return getValue<Single>(); } }// ad= 13 _ch 7
        public Single PIT_P631A { get { return getValue<Single>(); } }// ad= 15 _ch 8
                                                                      //owen mv 8as ad=4      
        public Single QE_K610 { get { return getValue<Single>(); } }// ad= 17 _ch 1
        public Single GE_pHV_K610 { get { return getValue<Single>(); } }// ad= 19 _ch 2
        public Single TE_482 { get { return getValue<Single>(); } }// ad= 21 _ch 6
        public Single TE_E481_Distil { get { return getValue<Single>(); } }// ad= 23 _ch 7
        public Single PIT_P461 { get { return getValue<Single>(); } }// ad= 25 _ch 8
                                                                     //line2_1       
                                                                     // owen  8as ad 2      
        public Single QIY_K480A { get { return getValue<Single>(); } }// ad= 27 _ch 1
        public Single QIY_K480B { get { return getValue<Single>(); } }// ad= 29 _ch 2
        public Single QIY_K460A { get { return getValue<Single>(); } }// ad= 31 _ch 3
        public Single QIY_K460B { get { return getValue<Single>(); } }// ad= 33 _ch 4
        public Single TE_K480A_2 { get { return getValue<Single>(); } }// ad= 35 _ch 5
        public Single TE_K480B_2 { get { return getValue<Single>(); } }// ad= 37 _ch 6
        public Single TE_E482 { get { return getValue<Single>(); } }// ad= 39 _ch 7
                                                                    // owen  8as ad 3      
        public Single PT_480A { get { return getValue<Single>(); } }// ad= 41 _ch 1
        public Single PT_480B { get { return getValue<Single>(); } }// ad= 43 _ch 2
        public Single GE_VK480A_7 { get { return getValue<Single>(); } }// ad= 45 _ch 3
        public Single GE_VK480B_7 { get { return getValue<Single>(); } }// ad= 47 _ch 4
        public Single WE_R402B { get { return getValue<Single>(); } }// ad= 49 _ch 5
        public Single WE_R201B { get { return getValue<Single>(); } }// ad= 51 _ch 6
        public Single WE_R404A { get { return getValue<Single>(); } }// ad= 53 _ch 7
        public Single WE_R403 { get { return getValue<Single>(); } }// ad= 55 _ch 8
                                                                    // owen  8as ad 4      
        public Single LE_R481 { get { return getValue<Single>(); } }// ad= 57 _ch 1
        public Single WE_D460A { get { return getValue<Single>(); } }// ad= 59 _ch 2
        public Single TE_K460A { get { return getValue<Single>(); } }// ad= 61 _ch 3
        public Single TE_K460B { get { return getValue<Single>(); } }// ad= 63 _ch 4
        public Single FQI_MEK_K480B_MOMENT { get { return getValue<Single>(); } }// ad= 65 _ch 5
                                                                                 //mv1108as ad=10      
        public Single QE_K450A { get { return getValue<Single>(); } }// ad= 67 _ch 1
        public Single TE_K450A { get { return getValue<Single>(); } }// ad= 69 _ch 2
        public Single WE_K450A { get { return getValue<Single>(); } }// ad= 71 _ch 3

        public UInt16 FQ_R521_in_count { get { return getValue<UInt16>(); } } //ad= 72 fast di1
        public UInt16 FQ_K480_in_count { get { return getValue<UInt16>(); } } //ad=73 fast di2
        public UInt16 FQ_K460_in_count { get { return getValue<UInt16>(); } } //ad=74 fast di3
        public UInt16 FQ_K450A_MEK_in_count { get { return getValue<UInt16>(); } } //ad=75 fast di4

        //public Single WE_59B { get { return getValue<Single>(); } }
        //public Single WE_67X { get { return getValue<Single>(); } }
        //public Single WE_67Z { get { return getValue<Single>(); } }
        //public Single WE_59A { get { return getValue<Single>(); } }
        //public Single WE_41D { get { return getValue<Single>(); } }

        //public Single WE_67L { get { return getValue<Single>(); } }
        //public Single Fluid_flow_rate_59B { get { return getValue<Single>(); } }
        //public Single Fluid_flow_rate_67X { get { return getValue<Single>(); } }
        //public Single Fluid_flow_rate_67Z { get { return getValue<Single>(); } }
        //public Single Fluid_flow_rate_59A { get { return getValue<Single>(); } }

        //public Single Fakt_Weight_WaterLoading_in_59A { get { return getValue<Single>(); } }
        //public Single Fakt_Weight_WaterLoading_in_59B { get { return getValue<Single>(); } }
        //public Single Fakt_Weight_WaterLoading_in_67Z { get { return getValue<Single>(); } }
        //public Single Fakt_Weight_WaterLoading_in_67X { get { return getValue<Single>(); } }
        //public Single Fakt_Weight_WaterLoading_in_41D { get { return getValue<Single>(); } }


        //public UInt16 Fakt_Time_loading_from_59A_to_41D { get { return getValue<UInt16>(); } }
        //public UInt16 Fakt_Time_loading_from_59B_to_41D { get { return getValue<UInt16>(); } }
        //public UInt16 Fakt_Time_loading_from_67Z_to_41D { get { return getValue<UInt16>(); } }
        //public UInt16 Fakt_Time_loading_from_67X_to_41D { get { return getValue<UInt16>(); } }

        //public Single Fakt_Mass_loading_from_59A_to_41D { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_from_59B_to_41D { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_from_67Z_to_41D { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_from_67X_to_41D { get { return getValue<Single>(); } }

        //public Single Fakt_Mass_loading_from_67L_to_59A { get { return getValue<Single>(); } }

        //public Single SP_loading_from_59A { get { return getValue<Single>(); } }
        //public Single SP_loading_from_59B { get { return getValue<Single>(); } }
        //public Single SP_loading_from_67Z { get { return getValue<Single>(); } }
        //public Single SP_loading_from_67X { get { return getValue<Single>(); } }

        //public Single Fakt_Mass_loading_over_P53 { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_over_P51 { get { return getValue<Single>(); } }

        //public Single Fakt_Mass_loading_over_P41D { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_over_31 { get { return getValue<Single>(); } }
        //public Single Fakt_Mass_loading_over_48 { get { return getValue<Single>(); } }


        ///* MDS AI-8UI A10 **********************************/
        //public Single TE_75 { get { return getValue<Single>(); } }
        //public Single TE_63 { get { return getValue<Single>(); } }
        //public Single TE_2_35H { get { return getValue<Single>(); } }
        //public Single TIT_41D { get { return getValue<Single>(); } }
        //public Single TT_1_41D { get { return getValue<Single>(); } }
        //public Single TE_2_41D { get { return getValue<Single>(); } }
        //public Single TE_3_41D { get { return getValue<Single>(); } }
        //public Single TT_1 { get { return getValue<Single>(); } }

        ///* MDS AI-8UI A11 **********************************/
        //public Single TE_59A { get { return getValue<Single>(); } }
        //public Single TE_67L { get { return getValue<Single>(); } }
        //public Single TE_14 { get { return getValue<Single>(); } }

        ///* MDS AI-8UI A12 **********************************/
        //public Single PITSA_48 { get { return getValue<Single>(); } }
        //public Single PITSA_31 { get { return getValue<Single>(); } }
        //public Single PIT_6 { get { return getValue<Single>(); } }
        //public Single PIT_3 { get { return getValue<Single>(); } }
        //public Single PIT_41D { get { return getValue<Single>(); } }
        //public Single PIT_P59A { get { return getValue<Single>(); } }
        //public Single PIT1_41D { get { return getValue<Single>(); } }
        //public Single PIT_7 { get { return getValue<Single>(); } }

        ///* MDS AI-8UI A13 **********************************/
        //public Single LVL_LT_75 { get { return getValue<Single>(); } }
        //public Single LVL_LT_63 { get { return getValue<Single>(); } }
        //public Single GE_PV6 { get { return getValue<Single>(); } }
        //public Single GE_PV5 { get { return getValue<Single>(); } }
        //public Single GE_TV35H { get { return getValue<Single>(); } }
        //public Single GE_V62H { get { return getValue<Single>(); } }
        //public Single GE_WV_3_P59B { get { return getValue<Single>(); } }
        //public Single TE_59B { get { return getValue<Single>(); } }
        //public Single TE_67X { get { return getValue<Single>(); } }
        //public Single FeedbackOUT_P67X { get { return getValue<Single>(); } }
        //public Single FeedbackOUT_P67Z { get { return getValue<Single>(); } }
        //// inpros
        //public UInt16 NS64_status_net { get { return getValue<UInt16>(); } }
        //public UInt16 NS31_status_net { get { return getValue<UInt16>(); } }
        //public UInt16 Fakt_Time_Nitrogen_Purge_41D { get { return getValue<UInt16>(); } }
        //public UInt16 FRQ_MESH_41D { get { return getValue<UInt16>(); } }
        //public UInt16 I_MESH_41D { get { return getValue<UInt16>(); } }
        //public UInt16 STATUS_MESH_41D { get { return getValue<UInt16>(); } }
        //public UInt16 FRQ_MESH_59A { get { return getValue<UInt16>(); } }
        //public UInt16 I_MESH_59A { get { return getValue<UInt16>(); } }
        //public UInt16 STATUS_MESH_59A { get { return getValue<UInt16>(); } }
        //public UInt16 FRQ_NASOS_34H { get { return getValue<UInt16>(); } }
        //public UInt16 I_NASOS_34H { get { return getValue<UInt16>(); } }
        //public UInt16 STATUS_NASOS_34H { get { return getValue<UInt16>(); } }
        //public UInt16 INPROS_LOCK_V67L { get { return getValue<UInt16>(); } }
        //public Single TE_41A { get { return getValue<Single>(); } }
        //public UInt16 FRQ_MESH_41A { get { return getValue<UInt16>(); } }
        //public Single COUNT_WATER_63 { get { return getValue<Single>(); } }
        //public Single Fakt_Weight_WaterLoading_in_41A { get { return getValue<Single>(); } }
        //public UInt16 I_MESH_41A { get { return getValue<UInt16>(); } }
        //public UInt16 STATUS_MESH_41A { get { return getValue<UInt16>(); } }

        //[ArchivAttribute("Температура TE-1 1A", 150, "Температуры 1A")]
        //public Single TE_1_1A { get { return getValue<Single>(); } }

        //[ArchivAttribute("Температура TE-2 1A", 150, "Температуры 1A")]
        //public Single TE_2_1A { get { return getValue<Single>(); } }

        //[ArchivAttribute("Температура TE-3 1A", 150, "Температуры 1A")]
        //public Single TE_3_1A { get { return getValue<Single>(); } }

        //[ArchivAttribute("Температура TE-4 1A", 150, "Температуры 1A")]
        //public Single TE_4_1A { get { return getValue<Single>(); } }

        //public Single GE_WY_1_67D { get { return getValue<Single>(); } }
        //public Single GE_WY_1_67E { get { return getValue<Single>(); } }

        //[ArchivAttribute("Вес мерника 67D", 4000, "Веса мерников", "MediumSlateBlue")]
        //public Single WE_67D { get { return getValue<Single>(); } }
        //[ArchivAttribute("Вес мерника 67E", 4000, "Веса мерников")]
        //public Single WE_67E { get { return getValue<Single>(); } }

        //public Single FeedbackOUT_9A { get { return getValue<Single>(); } }
        //public Single FeedbackOUT_10A { get { return getValue<Single>(); } }

        //public Single Fakt_Weight_WaterLoading_in_1A { get { return getValue<Single>(); } }
        public UInt16 JOURNAL { get { return getValue<UInt16>(); } } // должен быть последний

        #endregion

        // Holdings Registers
        #region Holdings Registers
        //******************line1_1 ********************      
        //mu 110 8i ad=5       
        public UInt16 NC_P412_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 1 _ch 1 
        public UInt16 NC_610M_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 2 _ch 2 
        public UInt16 pHV_K610_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 3 _ch 3 
        public UInt16 FV_K480A_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 4 _ch 4 
        public UInt16 FV_K480B_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 5 _ch 5 
                                                                                                           // ************************line2_1   ***************************    
                                                                                                           //mu 110 8i ad=5       
        public UInt16 VK480A_7_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 6 _ch 1 
        public UInt16 VK480B_7_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 7 _ch 2 
        public UInt16 TVK480A_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 8 _ch 3 
        public UInt16 TVK480B_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 9 _ch 4 
        public UInt16 VK480A_1_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 10 _ch 5 
        public UInt16 VK480B_1_reg_aout_ { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 11 _ch 6 
                                                                                                           //mu 110 8i ad=11       
        public UInt16 pHV_K450A_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 12 _ch 1 
        public UInt16 V_K480A_8_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 13 _ch 2 
        public UInt16 V_K480B_8_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 14 _ch 3 
        public UInt16 V_K480A_9_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 15 _ch 4 
        public UInt16 V_K480B_9_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 16 _ch 5 
        public UInt16 V_K480A_11_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 17 _ch 6 
        public UInt16 V_K480B_11_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 18 _ch 7 
        public UInt16 V_K480A_10_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 19 _ch 8 
                                                                                                        //mu 110 8i ad=12       
        public UInt16 V_K480B_10_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 20 _ch 1 
        public UInt16 NC_K450A_aout { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }// ad= 21 _ch 2 
                                                                                                      //public UInt16 FV_K480B_reg_aout_{ get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//ad=22 _ch3
        public UInt16 viravni1 { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//ad=22

        public Single NC_M610_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=23 частота мешалки в авто
        public Single NC_M610_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=25 частота мешалки в руч

        public Single NC_P412_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=27 частота мешалки в авто
        public Single NC_P412_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=29 частота мешалки в руч



        public Single FV_K480B_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=31
        public Single FV_K480B_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=33

        public Single FV_K480A_reg_ain_auto { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=35
        public Single FV_K480A_reg_ain_man { get { return getValue<Single>(); } set { setValue<Single>(value); } }//ad=37

        public UInt16 ZagrVodaComm_Nemk { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //38
        public UInt16 ZagrVodaComm_DozaZad { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } } //39
        public UInt16 ZagrVodaComm_doza { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }//40


        //public Single Weight_water_for_loading_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Weight_water_for_loading_59B { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Weight_water_for_loading_67Z { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Weight_water_for_loading_67X { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Weight_water_for_loading_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_loading_from_59A_to_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_loading_from_59B_to_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_loading_from_67Z_to_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_loading_from_67X_to_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_loading_from_67L_to_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public UInt16 Time_loading_from_59A_to_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 Time_loading_from_59B_to_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 Time_loading_from_67Z_to_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 Time_loading_from_67X_to_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 UPRAV_P59A { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 UPRAV_WV_3_P59B { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 UPRAV_WV_1_67Z { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 UPRAV_WV_1_67X { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public Single KP_loading_from_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KI_loading_from_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Dead_weight_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KP_loading_from_59B { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KI_loading_from_59B { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Dead_weight_59B { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KP_loading_from_67Z { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KI_loading_from_67Z { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Dead_weight_67Z { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KP_loading_from_67X { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KI_loading_from_67X { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Dead_weight_67X { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_zagruzki_over_P53 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_zagruzki_over_P51 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_zagruzki_over_31 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Mass_zagruzki_over_48 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public UInt16 Time_Nitrogen_Purge_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public Single SP_Thermo_PV6 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KP_Thermo_PV6 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KI_Thermo_PV6 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single KD_Thermo_PV6 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public UInt16 SP_FRQ_34H { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public Single SP_Thermo_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Delta_Thermo_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public UInt16 SP_FRQ_59A { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 SP_FRQ_41D { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public Single SP_Thermo_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MAX_TT_1 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MIN_PIT_7 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MAX_TE2_35H { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MIN_TE_67L { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MAX_TE_67L { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MAX_TE_59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MAX_TE_75 { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single ALARM_MIN_PIT3 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAX_TT_1_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAX_WE_67L { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAX_PIT_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single ALARM_MIN_LT_63 { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        ////
        //public Single MAN_OUT_PV5 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_PV6 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_TV35H { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_WV_1_67X { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_WV_1_67Z { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_WV_3_P59B { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single MAN_OUT_P59A { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single MIN_NYST_LVL_63 { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAX_NYST_LVL_63 { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single MAN_OUT_V62H { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Weight_water_for_loading_41A { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public UInt16 Nitrogen_Purge_Tank { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }
        //public UInt16 SP_FRQ_41A { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }

        //public Single SP_Thermo_41A { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public UInt16 Water_Loading_Tank_Selector { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }

        //public UInt16 Discharge_59B_Tank_Selector { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }

        //public UInt16 Zagruzka_Over_P51_in_Tank { get { return getValue<UInt16>(); } set { setValue<UInt16>(value); } }

        //public Single dead_weight_41D { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single MAN_OUT_KL_9A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single MAN_OUT_KL_10A { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single SP_Thermo_1A { get { return getValue<Single>(); } set { setValue<Single>(value); } }
        //public Single Delta_Thermo_1A { get { return getValue<Single>(); } set { setValue<Single>(value); } }

        //public Single Weight_water_for_loading_1A { get { return getValue<Single>(); } set { setValue<Single>(value); } }


        #endregion
    }

}
