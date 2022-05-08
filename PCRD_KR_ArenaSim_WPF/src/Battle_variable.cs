using System;
using System.Linq;

namespace PCRD_KR_ArenaSim
{

    class Battle_variable
    {
        public static string[] name = Enumerable.Repeat<string>("", 30).ToArray<string>();
        public static string[] name_eng = Enumerable.Repeat<string>("", 30).ToArray<string>();

        public static double[] max_HP = Enumerable.Repeat<double>(0, 30).ToArray<double>();



        public static double[] HP = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] TP = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] PA = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] MA = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] PD = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] MD = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] PC = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] MC = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] HPauto = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] TPauto = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] Dodge = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] HPabs = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] HPup = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] TPup = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] TPdec = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] acc = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[,] buff_HP = new bool[100, 30];
        public static double[,] buff_HP_coef = new double[100, 30];
        public static double[,] buff_HP_time = new double[100, 30];
        public static bool[,] buff_PA = new bool[100, 30];
        public static double[,] buff_PA_coef = new double[100, 30];
        public static double[,] buff_PA_time = new double[100, 30];
        public static bool[,] buff_MA = new bool[100, 30];
        public static double[,] buff_MA_coef = new double[100, 30];
        public static double[,] buff_MA_time = new double[100, 30];
        public static bool[,] buff_PD = new bool[100, 30];
        public static double[,] buff_PD_coef = new double[100, 30];
        public static double[,] buff_PD_time = new double[100, 30];
        public static bool[,] buff_MD = new bool[100, 30];
        public static double[,] buff_MD_coef = new double[100, 30];
        public static double[,] buff_MD_time = new double[100, 30];
        public static bool[,] buff_PC = new bool[100, 30];
        public static double[,] buff_PC_coef = new double[100, 30];
        public static double[,] buff_PC_time = new double[100, 30];
        public static bool[,] buff_MC = new bool[100, 30];
        public static double[,] buff_MC_coef = new double[100, 30];
        public static double[,] buff_MC_time = new double[100, 30];

        public static bool[,] buff_dodge = new bool[100, 30];
        public static double[,] buff_dodge_coef = new double[100, 30];
        public static double[,] buff_dodge_time = new double[100, 30];

        public static bool[,] buff_TPup = new bool[100, 30];
        public static double[,] buff_TPup_coef = new double[100, 30];
        public static double[,] buff_TPup_time = new double[100, 30];

        public static bool[,] buff_acc = new bool[100, 30];
        public static double[,] buff_acc_coef = new double[100, 30];
        public static double[,] buff_acc_time = new double[100, 30];

        public static bool[,] PCdamage = new bool[100, 30];
        public static double[] PCdamage_coef = Enumerable.Repeat<double>(2, 30).ToArray<double>();
        public static double[,] PCdamage_save = new double[100, 30];
        public static double[,] PCdamage_time = new double[100, 30];

        public static bool[,] MCdamage = new bool[100, 30];
        public static double[] MCdamage_coef = Enumerable.Repeat<double>(2, 30).ToArray<double>();
        public static double[,] MCdamage_save = new double[100, 30];
        public static double[,] MCdamage_time = new double[100, 30];

        public static bool[,] RCdamage = new bool[100, 30];
        public static double[] RCdamage_coef = Enumerable.Repeat<double>(1, 30).ToArray<double>();
        public static double[,] RCdamage_save = new double[100, 30];
        public static double[,] RCdamage_time = new double[100, 30];

        public static bool[] Pbarrier = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] Mbarrier = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] Allbarrier = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] Pbarrier_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Mbarrier_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Allbarrier_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Pbarrier_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Mbarrier_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Allbarrier_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] Pabsorb = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] Mabsorb = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] Allabsorb = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] Pabsorb_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Mabsorb_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Allabsorb_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Pabsorb_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Mabsorb_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] Allabsorb_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();



        public static bool[] ConHP = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] ConHP_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] ConHP_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] ConTP = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] ConTP_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] ConTP_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] Aspeed = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] Aspeed_coef = Enumerable.Repeat<double>(1, 30).ToArray<double>();
        public static double[] Aspeed_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] Mspeed = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] Mspeed_coef = Enumerable.Repeat<double>(450, 30).ToArray<double>();
        public static double[] Mspeed_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();



        public static bool[] provoke = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] provoke_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] invincible = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] invincible_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] physical_dodge = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] physical_dodge_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] poison = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] poison_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] poison_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] toxic = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] toxic_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] toxic_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] curse = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] curse_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] curse_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] burn = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] burn_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] burn_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] blind = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] blind_coef = Enumerable.Repeat<double>(100, 30).ToArray<double>();
        public static double[] blind_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();





        public static bool[] enchant = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] enchant_break = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] enchant_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] confuse = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] confuse_break = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] confuse_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] stun = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] stun_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] paralyze = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] paralyze_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] bind = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] bind_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] knockback = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] knockback_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] freeze = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] freeze_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] timestop = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] timestop_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();
       
        public static bool[] delay = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] delay_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();



        public static bool[] charge = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] charge_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] charge_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] counterattack = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] counterattack_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] counterattack_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] absorb = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] absorb_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static int[] absorb_count = Enumerable.Repeat<int>(0, 30).ToArray<int>();

        public static bool[] clairvoyance = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static bool[] clairvoyance_active = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();


        public static bool[] damage_add = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] damage_add_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static int[] damage_add_count = Enumerable.Repeat<int>(0, 30).ToArray<int>();

        public static int[] intimidated_stack = Enumerable.Repeat<int>(0, 30).ToArray<int>();

        public static int[] chieru_stack = Enumerable.Repeat<int>(0, 30).ToArray<int>();
        public static int[] chieru_terefes_stack = Enumerable.Repeat<int>(0, 30).ToArray<int>();
        public static int[] chloe_terefes_stack = Enumerable.Repeat<int>(0, 30).ToArray<int>();

        public static bool[] panic = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] panic_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] spirit = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] spirit_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] blade = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] blade_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[] resurrection = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] resurrection_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] resurrection_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] sleep = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] sleep_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] poison_aoi = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] poison_aoi_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] field_P = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] field_P_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] field_P_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] field_M = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();
        public static double[] field_M_coef = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] field_M_time = Enumerable.Repeat<double>(0, 30).ToArray<double>();


        public static bool[,] bomb = new bool[10, 30];
        public static double[,] bomb_coef = new double[10, 30];
        public static double[,] bomb_time = new double[10, 30];
        public static int[,] bomb_index = new int[10, 30];



        public static double[] Range = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static double[] position = new double[30] { -1560, -1360, -1160, -960, -760, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, 1360, 1160, 960, 760, 560, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000 };
        public static double[] position_front = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double[] position_rear = Enumerable.Repeat<double>(0, 30).ToArray<double>();

        public static bool[] death = Enumerable.Repeat<bool>(false, 30).ToArray<bool>();

        public static bool[,] field = new bool[100, 1];
        public static double[,] field_double = new double[100, 4];
        public static string[,] field_string = new string[100, 1];
        public static int[,] field_int = new int[100, 2];

        public static void battle_initialize()
        {
            for (int i = 0; i < 30; i++)
            {
                if (i < 15)
                {
                    name[i] = MainWindow.select_defence[i];
                    name_eng[i] = MainWindow.select_defence_eng[i];
                }
                else
                {
                    name[i] = MainWindow.select_offence[i - 15];
                    name_eng[i] = MainWindow.select_offence_eng[i - 15];
                }

                max_HP[i] = Stat_variable.HP[i];
                HP[i] = Stat_variable.HP[i];
                //HP[i] = 3;
                TP[i] = 0;
                PA[i] = Stat_variable.PA[i];
                MA[i] = Stat_variable.MA[i];
                PD[i] = Stat_variable.PD[i];
                MD[i] = Stat_variable.MD[i];
                PC[i] = Stat_variable.PC[i];
                MC[i] = Stat_variable.MC[i];
                HPauto[i] = Stat_variable.HPauto[i];
                TPauto[i] = Stat_variable.TPauto[i];
                Dodge[i] = Stat_variable.Dodge[i];
                HPabs[i] = Stat_variable.HPabs[i];
                HPup[i] = Stat_variable.HPup[i];
                TPup[i] = Stat_variable.TPup[i];
                TPdec[i] = Stat_variable.TPdec[i];
                acc[i] = Stat_variable.acc[i];

                Pbarrier[i] = false;
                Pbarrier_coef[i] = 0;
                Pbarrier_time[i] = 0;
                Mbarrier[i] = false;
                Mbarrier_coef[i] = 0;
                Mbarrier_time[i] = 0;
                Allbarrier[i] = false;
                Allbarrier_coef[i] = 0;
                Allbarrier_time[i] = 0;
                Pabsorb[i] = false;
                Pabsorb_coef[i] = 0;
                Pabsorb_time[i] = 0;
                Mabsorb[i] = false;
                Mabsorb_coef[i] = 0;
                Mabsorb_time[i] = 0;
                Allabsorb[i] = false;
                Allabsorb_coef[i] = 0;
                Allabsorb_time[i] = 0;

                ConHP[i] = false;
                ConHP_coef[i] = 0;
                ConHP_time[i] = 0;
                ConTP[i] = false;
                ConTP_coef[i] = 0;
                ConTP_time[i] = 0;
                Aspeed[i] = false;
                Aspeed_coef[i] = 1;
                Aspeed_time[i] = 0;
                Mspeed[i] = false;
                Mspeed_coef[i] = 450;
                Mspeed_time[i] = 0;

                PCdamage_coef[i] = 2;
                MCdamage_coef[i] = 2;

                RCdamage_coef[i] = 1;//받는 크리티컬배율

                provoke[i] = false;
                provoke_time[i] = 0;
                invincible[i] = false;
                invincible_time[i] = 0;
                physical_dodge[i] = false;
                physical_dodge_time[i] = 0;

                poison[i] = false;
                poison_coef[i] = 0;
                poison_time[i] = 0;
                toxic[i] = false;
                toxic_coef[i] = 0;
                toxic_time[i] = 0;


                curse[i] = false;
                curse_coef[i] = 0;
                curse_time[i] = 0;
                burn[i] = false;
                burn_coef[i] = 0;
                burn_time[i] = 0;

                blind[i] = false;
                blind_coef[i] = 100;
                blind_time[i] = 0;

                enchant[i] = false;
                enchant_break[i] = false;
                enchant_time[i] = 0;
                confuse[i] = false;
                confuse_break[i] = false;
                confuse_time[i] = 0;

                stun[i] = false;
                stun_time[i] = 0;
                paralyze[i] = false;
                paralyze_time[i] = 0;
                bind[i] = false;
                bind_time[i] = 0;
                knockback[i] = false;
                knockback_time[i] = 0;
                freeze[i] = false;
                freeze_time[i] = 0;
                timestop[i] = false;
                timestop_time[i] = 0;

                delay[i] = false;
                delay_time[i] = 0;

                charge[i] = false;
                charge_coef[i] = 0;
                charge_time[i] = 0;

                counterattack[i] = false;
                counterattack_coef[i] = 0;
                counterattack_time[i] = 0;

                absorb[i] = false;
                absorb_coef[i] = 0;
                absorb_count[i] = 0;

                clairvoyance[i] = false;
                clairvoyance_active[i] = false;

                damage_add[i] = false;
                damage_add_coef[i] = 0;
                damage_add_count[i] = 0;

                intimidated_stack[i] = 0;
                chieru_stack[i] = 0;
                chieru_terefes_stack[i] = 0;
                chloe_terefes_stack[i] = 0;

                panic[i] = false;
                panic_time[i] = 0;

                spirit[i] = false;
                spirit_time[i] = 0;

                blade[i] = false;
                blade_time[i] = 0;

                resurrection[i] = false;
                resurrection_coef[i] = 0;
                resurrection_time[i] = 0;

                sleep[i] = false;
                sleep_time[i] = 0;
                
                poison_aoi[i]= false;
                poison_aoi_time[i]= 0;

                field_P[i] = false;
                field_P_coef[i] = 0;
                field_P_time[i] = 0;
                field_M[i] = false;
                field_M_coef[i] = 0;
                field_M_time[i] = 0;

            }
            for (int i = 0; i < 100; i++)
            {
                Battle_variable.field[i, 0] = false;
                Battle_variable.field_double[i, 0] = 0;
                Battle_variable.field_double[i, 1] = 0;
                Battle_variable.field_double[i, 2] = 0;
                Battle_variable.field_double[i, 3] = 0;
                Battle_variable.field_string[i, 0] = "";
                Battle_variable.field_int[i, 0] = 0;
                Battle_variable.field_int[i, 1] = 0;

                for (int j = 0; j < 30; j++)
                {
                    buff_HP[i, j] = false;
                    buff_HP_coef[i, j] = 0;
                    buff_HP_time[i, j] = 0;
                    buff_PA[i, j] = false;
                    buff_PA_coef[i, j] = 0;
                    buff_PA_time[i, j] = 0;
                    buff_MA[i, j] = false;
                    buff_MA_coef[i, j] = 0;
                    buff_MA_time[i, j] = 0;
                    buff_PD[i, j] = false;
                    buff_PD_coef[i, j] = 0;
                    buff_PD_time[i, j] = 0;
                    buff_MD[i, j] = false;
                    buff_MD_coef[i, j] = 0;
                    buff_MD_time[i, j] = 0;
                    buff_PC[i, j] = false;
                    buff_PC_coef[i, j] = 0;
                    buff_PC_time[i, j] = 0;
                    buff_MC[i, j] = false;
                    buff_MC_coef[i, j] = 0;
                    buff_MC_time[i, j] = 0;

                    buff_dodge[i, j] = false;
                    buff_dodge_coef[i, j] = 0;
                    buff_dodge_time[i, j] = 0;

                    buff_acc[i, j] = false;
                    buff_acc_coef[i, j] = 0;
                    buff_acc_time[i, j] = 0;

                    buff_TPup[i, j] = false;
                    buff_TPup_coef[i, j] = 0;
                    buff_TPup_time[i, j] = 0;

                    PCdamage[i, j] = false;
                    PCdamage_save[i, j] = 2;
                    PCdamage_time[i, j] = 0;
                    MCdamage[i, j] = false;
                    MCdamage_save[i, j] = 2;
                    MCdamage_time[i, j] = 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    bomb[i, j] = false;
                    bomb_coef[i, j] = 0;
                    bomb_time[i, j] = 0;
                    bomb_index[i, j] = -1;
                }

            }

            Character_skill.arisa_opponent_counter = 0;
            Character_skill.arisa_opponent_counter_est = 0;
            Character_skill.kaya_opponent_counter = 0;
            Character_skill.kaya_opponent_counter_est = 0;
            Character_skill.kaya_opponent_counter2 = 0;
            Character_skill.kaya_opponent_counter2_est = 0;
            Character_skill.lou_opponent_omeme = 0;
            Character_skill.lou_opponent_omeme_est = 0;
            Character_skill.suzuna_summer_opponent_counter = 0;
            Character_skill.suzuna_summer_opponent_counter_est = 0;
            Character_skill.chloe_opponent_twilight = false;
            Character_skill.chloe_opponent_twilight_est = false;
            Character_skill.chieru_opponent_dance = false;
            Character_skill.chieru_opponent_dance_est = false;
            Character_skill.runa_opponent_friend = 0;
            Character_skill.runa_opponent_friend_est = 0;
            Character_skill.runa_opponent_action = false;
            Character_skill.runa_opponent_action_est = false;
            Character_skill.kristina_christmas_opponent_coin = false;
            Character_skill.kristina_christmas_opponent_coin_est = false;

            Character_skill.ruka_summer_opponent_action = false;
            Character_skill.ruka_summer_opponent_action_est = false;
            Character_skill.ruka_summer_opponent_stack = 0;
            Character_skill.ruka_summer_opponent_stack_est = 0;

            Character_skill.matsuri_halloween_opponent_stack = 0;
            Character_skill.matsuri_halloween_opponent_stack_est = 0;

            Character_skill.saren_christmas_opponent_shield = 0;
            Character_skill.saren_christmas_opponent_shield_est = 0;

            Character_skill.akino_christmas_opponent_glitter = 0;
            Character_skill.akino_christmas_opponent_glitter_est = 0;
            Character_skill.akino_christmas_opponent_holyprize = false;
            Character_skill.akino_christmas_opponent_holyprize_est = false;

            Character_skill.shepi_opponent_icedragon = 0;
            Character_skill.shepi_opponent_icedragon_est = 0;
            Character_skill.shepi_opponent_UBstack = 0;
            Character_skill.shepi_opponent_UBstack_est = 0;

            Character_skill.chieru_terefes_opponent_chieru= false;
            Character_skill.chieru_terefes_opponent_chieru_est = false;

            Character_skill.chloe_terefes_opponent_counter = 0;
            Character_skill.chloe_terefes_opponent_counter_est = 0;

            position = new double[30] { -1560, -1360, -1160, -960, -760, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, 1360, 1160, 960, 760, 560, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000 };
            
            if (Array.IndexOf(Battle_variable.name_eng, "rima") != -1)
            {
                int a = Array.IndexOf(MainWindow.select_defence_eng, "rima");
                if (a < 15 && a >= 0)
                {
                    //position[4] = -2480;
                    position[4] = -2480;
                }
                int b = Array.IndexOf(MainWindow.select_offence_eng, "rima");
                if (b < 15 && b >= 0)
                {
                    position[19] = 2080;
                }
            }
            if (Array.IndexOf(Battle_variable.name_eng, "muimi_newyear") != -1)
            {
                int a = Array.IndexOf(MainWindow.select_defence_eng, "muimi_newyear");
                if (a < 15 && a >= 0)
                {
                    //position[4] = -2480;
                    position[4] = -2480;
                }
                int b = Array.IndexOf(MainWindow.select_offence_eng, "muimi_newyear");
                if (b < 15 && b >= 0)
                {
                    position[19] = 2080;
                }
            }
            //position = new double[30] { -1560, -1360, -1160, -960, -760, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -1000000, -60, -260, -460, -660, -860, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000, 1000000 };

            death = new bool[30] { false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true };

            battle_positionset();
        }

        public static void battle_unit_initialize(int array_order)
        {
            int i = array_order;

            Pbarrier[i] = false;
            Pbarrier_coef[i] = 0;
            Pbarrier_time[i] = 0;
            Mbarrier[i] = false;
            Mbarrier_coef[i] = 0;
            Mbarrier_time[i] = 0;
            Allbarrier[i] = false;
            Allbarrier_coef[i] = 0;
            Allbarrier_time[i] = 0;
            Pabsorb[i] = false;
            Pabsorb_coef[i] = 0;
            Pabsorb_time[i] = 0;
            Mabsorb[i] = false;
            Mabsorb_coef[i] = 0;
            Mabsorb_time[i] = 0;
            Allabsorb[i] = false;
            Allabsorb_coef[i] = 0;
            Allabsorb_time[i] = 0;

            ConHP[i] = false;
            ConHP_coef[i] = 0;
            ConHP_time[i] = 0;
            ConTP[i] = false;
            ConTP_coef[i] = 0;
            ConTP_time[i] = 0;
            Aspeed[i] = false;
            Aspeed_coef[i] = 1;
            Aspeed_time[i] = 0;
            Mspeed[i] = false;
            Mspeed_coef[i] = 450;
            Mspeed_time[i] = 0;

            PCdamage_coef[i] = 2;
            MCdamage_coef[i] = 2;

            RCdamage_coef[i] = 1;

            provoke[i] = false;
            provoke_time[i] = 0;
            invincible[i] = false;
            invincible_time[i] = 0;
            physical_dodge[i] = false;
            physical_dodge_time[i] = 0;

            poison[i] = false;
            poison_coef[i] = 0;
            poison_time[i] = 0;
            toxic[i] = false;
            toxic_coef[i] = 0;
            toxic_time[i] = 0;


            curse[i] = false;
            curse_coef[i] = 0;
            curse_time[i] = 0;
            burn[i] = false;
            burn_coef[i] = 0;
            burn_time[i] = 0;

            blind[i] = false;
            blind_coef[i] = 100;
            blind_time[i] = 0;

            enchant[i] = false;
            enchant_break[i] = false;
            enchant_time[i] = 0;
            confuse[i] = false;
            confuse_break[i] = false;
            confuse_time[i] = 0;

            stun[i] = false;
            stun_time[i] = 0;
            paralyze[i] = false;
            paralyze_time[i] = 0;
            bind[i] = false;
            bind_time[i] = 0;
            knockback[i] = false;
            knockback_time[i] = 0;
            freeze[i] = false;
            freeze_time[i] = 0;
            timestop[i] = false;
            timestop_time[i] = 0;

            delay[i] = false;
            delay_time[i] = 0;

            charge[i] = false;
            charge_coef[i] = 0;
            charge_time[i] = 0;

            counterattack[i] = false;
            counterattack_coef[i] = 0;
            counterattack_time[i] = 0;

            absorb[i] = false;
            absorb_coef[i] = 0;
            absorb_count[i] = 0;

            clairvoyance[i] = false;
            clairvoyance_active[i] = false;

            damage_add[i] = false;
            damage_add_coef[i] = 0;
            damage_add_count[i] = 0;

            intimidated_stack[i] = 0;
            chieru_stack[i] = 0;
            chieru_terefes_stack[i] = 0;
            chloe_terefes_stack[i] = 0;

            panic[i] = false;
            panic_time[i] = 0;

            spirit[i] = false;
            spirit_time[i] = 0;

            blade[i] = false;
            blade_time[i] = 0;

            resurrection[i] = false;
            resurrection_coef[i] = 0;
            resurrection_time[i] = 0;

            sleep[i] = false;
            sleep_time[i] = 0;

            poison_aoi[i] = false;
            poison_aoi_time[i] = 0;

            for (i = 0; i < 100; i++)
            {
                int j = array_order;

                buff_HP[i, j] = false;
                buff_HP_coef[i, j] = 0;
                buff_HP_time[i, j] = 0;
                buff_PA[i, j] = false;
                buff_PA_coef[i, j] = 0;
                buff_PA_time[i, j] = 0;
                buff_MA[i, j] = false;
                buff_MA_coef[i, j] = 0;
                buff_MA_time[i, j] = 0;
                buff_PD[i, j] = false;
                buff_PD_coef[i, j] = 0;
                buff_PD_time[i, j] = 0;
                buff_MD[i, j] = false;
                buff_MD_coef[i, j] = 0;
                buff_MD_time[i, j] = 0;
                buff_PC[i, j] = false;
                buff_PC_coef[i, j] = 0;
                buff_PC_time[i, j] = 0;
                buff_MC[i, j] = false;
                buff_MC_coef[i, j] = 0;
                buff_MC_time[i, j] = 0;

                buff_dodge[i, j] = false;
                buff_dodge_coef[i, j] = 0;
                buff_dodge_time[i, j] = 0;
                buff_acc[i, j] = false;
                buff_acc_coef[i, j] = 0;
                buff_acc_time[i, j] = 0;
                buff_TPup[i, j] = false;
                buff_TPup_coef[i, j] = 0;
                buff_TPup_time[i, j] = 0;

                PCdamage[i, j] = false;
                PCdamage_save[i, j] = 2;
                PCdamage_time[i, j] = 0;
                MCdamage[i, j] = false;
                MCdamage_save[i, j] = 2;
                MCdamage_time[i, j] = 0;
            }
        }


        public static void battle_positionset()
        {
            for (int i = 0; i < 15; i++)
            {
                if (Battle_variable.death[i] == false)
                {
                    Battle_variable.position_front[i] = Battle_variable.position[i] + 107.5;
                    Battle_variable.position_rear[i] = Battle_variable.position[i] - 107.5;
                }
            }
            for (int i = 15; i < 30; i++)
            {
                if (Battle_variable.death[i] == false)
                {
                    Battle_variable.position_front[i] = Battle_variable.position[i] - 107.5;
                    Battle_variable.position_rear[i] = Battle_variable.position[i] + 107.5;
                }
            }
        }
    }

}
