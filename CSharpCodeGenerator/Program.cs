using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NameConversion;
using System.Reflection;
using System.Text;

namespace CSharpCodeGenerator
{
    internal class Program
    {
        public static IDNameConversion idnc = new IDNameConversion();
        static void Main(string[] args)
        {
            Download();
            //chara_story_status();
            //unit_promotion_status();
            //equipment_data();
            //unit_rarity();
            //unit_promotion();
            //unique_equipment_data();
            //unique_equipment_enhance_rate();
            character_range_and_cast();
            Console.ReadKey();
        }
        static void Download()
        {
            WebClient mywebClient = new WebClient();

            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unique_equipment_enhance_rate.sql", 
                Environment.CurrentDirectory + @"/unique_equipment_enhance_rate.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unique_equipment_data.sql",
                Environment.CurrentDirectory + @"/unique_equipment_data.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/chara_story_status.sql", 
                Environment.CurrentDirectory + @"/chara_story_status.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unit_promotion_status.sql", 
                Environment.CurrentDirectory + @"/unit_promotion_status.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/equipment_data.sql", 
                Environment.CurrentDirectory + @"/equipment_data.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unit_rarity.sql",
                Environment.CurrentDirectory + @"/unit_rarity.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unit_promotion.sql",
                Environment.CurrentDirectory + @"/unit_promotion.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/skill_data.sql",
                Environment.CurrentDirectory + @"/skill_data.csv");
            mywebClient.DownloadFile("https://raw.githubusercontent.com/esterTion/redive_master_db_diff/master/unit_data.sql",
                Environment.CurrentDirectory + @"/unit_data.csv");




            Console.WriteLine("done");
        }
        static void chara_story_status()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName+ ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();
            List<string> status = new List<string>();


            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);

            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Destiny");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[15];
                for (int i = 0; i < 15; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 7, 7);
                string  name = idnc.IDtoCharaEngName(id,7);

                string story = id.Substring(id.Length-2, 2);
                //Console.WriteLine(Convert.ToInt32(story));

                //Console.WriteLine(string.Format("{0}_{1}", name, story));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));

                for (int i = 0; i < 5; i++)
                {
                    string strValue1 = values[2 + i * 2].Substring(18);
                    string strValue2 = values[3 + i * 2].Substring(18);

                    //Console.WriteLine(strValue1);
                    //Console.WriteLine(strValue2);

                    int intValue1 = Convert.ToInt32(strValue1);
                    int intValue2 = Convert.ToInt32(strValue2);

                    if (intValue1 < 8 && intValue1 > 0)
                        temp[intValue1 - 1] = strValue2;
                    else if (intValue1 == 9)
                        temp[11 - 1] = strValue2;
                    else if (intValue1 == 10)
                        temp[9 - 1] = strValue2;
                    else if (intValue1 == 14)
                        temp[13 - 1] = strValue2;
                    else if (intValue1 == 15)
                        temp[12 - 1] = strValue2;
                }
                string temps = idnc.StringArrayToCommaString(temp);
                string result = string.Format("public double[] {0}_{1} = new double[{2}] {{{3}}};", name, story,temp.Length, temps);
                Console.WriteLine(result);
                sw.WriteLine(result);

            }
sw.WriteLine("#endregion");
            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }

        static void unit_promotion_status()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv");
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();
            List<string> status = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);

            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Rank");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[15];
                for (int i = 0; i < 15; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                string name = idnc.IDtoCharaEngName(id, 6);
                //Console.WriteLine(values.Length);

                string promotion = values[1].Substring(values[1].LastIndexOf("*/") + 2);
                int intPromotion = int.Parse(promotion);
                //Console.WriteLine(promotion);

                //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));

                //          0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 
             
                // db상 데이터 2HP, 3물공, 4마공, 5물방, 6마방, 7물크, 8마크, 9HP 자동 회복, 10TP 자동 회복, 11회피,12,13,14HP흡수,15회복량상승,16TP 상승,17 TP 소비감소, 18명중
             
                
                for(int i = 0; i<10;i++)
                {
                    temp[i] = values[i + 2];
                }
                for (int j = 10; j <= 14; j++)
                {
                    temp[j] = values[j + 2 + 2];
                }
                temp[14]= temp[14].Remove(temp[14].Length - 2, 2);
                
                //Console.WriteLine(temp[14]);
                string temps = idnc.StringArrayToCommaString(temp);

                string result = string.Format("public double[] {0}_{1:D2} = new double[{2}] {{{3}}};", name, intPromotion,temp.Length, temps);

                Console.WriteLine(result);
                sw.WriteLine(result);

            }
            sw.WriteLine("#endregion");
            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }


        static void equipment_data()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);

            List<string> rein0 = new List<string>();
            List<string> rein1 = new List<string>();
            List<string> rein3 = new List<string>();
            List<string> rein5 = new List<string>();
            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Equipment");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[15];
                for (int i = 0; i < 15; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                int intID = int.Parse(id);
                if(intID < 109999)
                {
                    if (intID < 102000)
                        rein0.Add(String.Format("\"E{0}\"",id));
                    if (intID > 102000 && intID < 103000)
                        rein1.Add(String.Format("\"E{0}\"", id));
                    if (intID > 103000 && intID < 104000)
                        rein3.Add(String.Format("\"E{0}\"", id));
                    if (intID > 104000)
                        rein5.Add(String.Format("\"E{0}\"", id));
                    string name = values[1];
                    //Console.WriteLine(values.Length);


                    //int intPromotion = int.Parse(promotion);
                    //Console.WriteLine(promotion);

                    //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                    //sw.WriteLine(string.Format("{0}_{1}", name, story));

                    //          0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 
                    //
                    //             0hp, 1atk, 2magic_str, 3def, 4magic_def, 5physical_critical, 6magic_critical,7wave_hp_recovery, 
                    // 8wave_energy_recovery, 9dodge, 10life_steal, 11hp_recovery_rate, 12energy_recovery_rate, 13energy_reduce_rate,  14accuracy };
                    // db상 데이터 8HP, 9물공, 10마공, 11물방, 12마방, 13물크, 14마크, 15HP 자동 회복, 16TP 자동 회복, 17회피,18,19,20HP흡수,21회복량상승,22TP 상승,23 TP 소비감소, 25명중


                    for (int i = 0; i < 10; i++)
                    {
                        temp[i] = values[i + 8];
                    }
                    for (int j = 10; j <= 13; j++)
                    {
                        temp[j] = values[j + 8 + 2];
                    }
                    temp[14] = values[25];

                    //Console.WriteLine(temp[14]);
                    string temps = idnc.StringArrayToCommaString(temp);

                    string result = string.Format("public double[] E{0} = new double[{1}] {{{2}}};", id,temp.Length, temps);

                    Console.WriteLine(result);
                    sw.WriteLine(result);
                }
            }
            rein0.Add("\"E999999\"");
            string result0 = string.Format("public string[] reinforce_0 = new string[{0}] {{{1}}};", rein0.Count, idnc.StringListToCommaString(rein0));
            string result1 = string.Format("public string[] reinforce_1 = new string[{0}] {{{1}}};", rein1.Count, idnc.StringListToCommaString(rein1));
            string result3 = string.Format("public string[] reinforce_3 = new string[{0}] {{{1}}};", rein3.Count, idnc.StringListToCommaString(rein3));
            string result5= string.Format("public string[] reinforce_5 = new string[{0}] {{{1}}};", rein5.Count, idnc.StringListToCommaString(rein5));
            Console.WriteLine(result0);
            Console.WriteLine(result1);
            Console.WriteLine(result3);
            Console.WriteLine(result5);
            sw.WriteLine();
            sw.WriteLine(result0);
            sw.WriteLine();
            sw.WriteLine(result1);
            sw.WriteLine();
            sw.WriteLine(result3);
            sw.WriteLine();
            sw.WriteLine(result5);
            sw.WriteLine();
            sw.WriteLine("#endregion");
            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }
        static void unit_rarity()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();
            List<string> status = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);
            listA.RemoveAt(listA.Count - 1);
            listA.RemoveAt(listA.Count - 1);
            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Growth");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[17];
                for (int i = 0; i < 17; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                string name = idnc.IDtoCharaEngName(id, 6);
                //Console.WriteLine(values.Length);

                string star = values[1].Substring(values[1].LastIndexOf("*/") + 2);
                int intStar = int.Parse(star);
                //Console.WriteLine(promotion);

                //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));

                //0초기HP, 1성장HP, 2초기 물공, 3성장 물공, 4초기 마공, 5성장 마공, 6물방, 7성장 물방, 8마방, 9성장 마방, 10물크, 11마크, 12HP흡수, 13회복량 상승, 14TP 상승, 15명중, 16회피
                //0id,1성급
                // db상 데이터 2HP, 3성장HP, 4물공, 5성장 물공, 6마공, 7성장 마공, 8물방, 9HP 성장 물방, 10마방, 11성장 마방,12물크,13,14마크,15,16HP자동회복,17,
                // 18TP 자동회복,19,20회피,21,22,23,24,25,26HP 흡수,27,28회복량 상승,29, 30TP상승,31,32TP소비 감소33,37명중,38
                

                for (int i = 0; i <= 10; i++)
                {
                    temp[i] = values[i + 2];
                }
                temp[11] = values[14];
                temp[12] = values[26];
                temp[13] = values[28];
                temp[14] = values[30];
                temp[15] = values[37];
                temp[16] = values[20];

                //Console.WriteLine(temp[14]);
                string temps = idnc.StringArrayToCommaString(temp);

                string result = string.Format("public double[] {0}_{1} = new double[{2}] {{{3}}};", name, star,temp.Length, temps);

                Console.WriteLine(result);
                sw.WriteLine(result);

            }
            sw.WriteLine("#endregion");
            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }
        static void unit_promotion()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();
            List<string> status = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);
            listA.RemoveAt(listA.Count - 1);

            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Unit_equip");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[6];
                for (int i = 0; i < 6; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                string name = idnc.IDtoCharaEngName(id, 6);
                //Console.WriteLine(values.Length);

                string rank = values[1].Substring(values[1].LastIndexOf("*/") + 2);
                int intRank = int.Parse(rank);
                Console.WriteLine(rank);

                //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));


                for (int i = 0; i < 6; i++)
                {
                    temp[i] = values[i + 2];
                }
                temp[5] = temp[5].Remove(temp[5].Length - 2, 2);
                //Console.WriteLine(temp[14]);
                string temps = idnc.StringArrayToCommaString(temp);

                string result = string.Format("public double[] {0}_{1:D2} = new double[{2}] {{{3}}};", name, intRank, temp.Length, temps);

                Console.WriteLine(result);
                sw.WriteLine(result);

            }
            sw.WriteLine("#endregion");
            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }
        static void unique_equipment_data()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);

            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Unique_equipment");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[15];
                for (int i = 0; i < 15; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                string strID = id.Remove(1, 1);
                string name = idnc.IDtoCharaEngName(strID, 5);


                //Console.WriteLine(values.Length);


                //int intPromotion = int.Parse(promotion);
                //Console.WriteLine(promotion);

                //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));

                //          0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 
                //
                //             0hp, 1atk, 2magic_str, 3def, 4magic_def, 5physical_critical, 6magic_critical,7wave_hp_recovery, 
                // 8wave_energy_recovery, 9dodge, 10life_steal, 11hp_recovery_rate, 12energy_recovery_rate, 13energy_reduce_rate,  14accuracy };
                // db상 데이터 8HP, 9물공, 10마공, 11물방, 12마방, 13물크, 14마크, 15HP 자동 회복, 16TP 자동 회복, 17회피,18,19,20HP흡수,21회복량상승,22TP 상승,23 TP 소비감소, 25명중
                //

                for (int i = 0; i < 10; i++)
                {
                    temp[i] = values[i + 8];
                }
                for (int j = 10; j <= 13; j++)
                {
                    temp[j] = values[j + 8 + 2];
                }
                temp[14] = values[25];

                temp[14] = temp[14].Remove(temp[14].Length - 2, 2);

                //Console.WriteLine(temp[14]);
                string temps = idnc.StringArrayToCommaString(temp);
                Console.WriteLine(strID);

                string result = string.Format("public double[] {0} = new double[{1}] {{{2}}};", name, temp.Length, temps);

                Console.WriteLine(result);
                sw.WriteLine(result);
                
            }

            sw.WriteLine("#endregion");

            Console.WriteLine("Finished");

            //            1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
            // db상 데이터 1HP, 2물공, 3물방, 4마공, 5마방, 6물크,7 마크,8,9HP 흡수,10HP 자동 회복,11 TP 자동회복,12,13,14TP상승,15회복량 상승 
            sw.Close();
        }
        static void unique_equipment_enhance_rate()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr = new StreamReader(methodName + ".csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                listA.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);

            int numofComma = r.Split(',').Length;
            sw.WriteLine("#region Unique_equipment_reinforce");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);
                string[] temp = new string[15];
                for (int i = 0; i < 15; i++)
                    temp[i] = "0";

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                string strID = id.Remove(1, 1);
                string name = idnc.IDtoCharaEngName(strID, 5);


                //Console.WriteLine(values.Length);


                //int intPromotion = int.Parse(promotion);
                //Console.WriteLine(promotion);

                //Console.WriteLine(string.Format("{0}_{1:D2}", name, intPromotion));
                //sw.WriteLine(string.Format("{0}_{1}", name, story));

                //          0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 
                //
                //             0hp, 1atk, 2magic_str, 3def, 4magic_def, 5physical_critical, 6magic_critical,7wave_hp_recovery, 
                // 8wave_energy_recovery, 9dodge, 10life_steal, 11hp_recovery_rate, 12energy_recovery_rate, 13energy_reduce_rate,  14accuracy };
                // db상 데이터 4HP, 9물공, 10마공, 11물방, 12마방, 13물크, 14마크, 15HP 자동 회복, 16TP 자동 회복, 17회피,18,19,20HP흡수,21회복량상승,22TP 상승,23 TP 소비감소, 24명중

                //98,  /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*physical_penetrate*/0.0, /*magic_penetrate*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0);


                for (int i = 0; i < 10; i++)
                {
                    temp[i] = values[i + 4];
                }
                for (int j = 10; j <= 14; j++)
                {
                    temp[j] = values[j + 4 + 2];
                }
                temp[14] = temp[14].Remove(temp[14].Length - 2, 2);

                //Console.WriteLine(temp[14]);
                string temps = idnc.StringArrayToCommaString(temp);
                Console.WriteLine(strID);

                string result = string.Format("public double[] {0}_reinforce = new double[{1}] {{{2}}};", name, temp.Length, temps);

                Console.WriteLine(result);
                sw.WriteLine(result);

            }

            sw.WriteLine("#endregion");

            Console.WriteLine("Finished");

           
            sw.Close();
        }


        static void character_range_and_cast()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

            StreamReader sr2 = new StreamReader("skill_data.csv");
            StreamReader sr1 = new StreamReader("unit_data.csv"); ;
            StreamWriter sw = new StreamWriter(methodName + ".txt");
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> Pos = new List<string>();
            List<string> NormalAtkCastTime = new List<string>();
            List<string> CastTime1 = new List<string>();
            List<string> CastTime2 = new List<string>();
            List<string> CastTime1P = new List<string>();
            List<string> AtkType = new List<string>();
            while (!sr1.EndOfStream)
            {
                var line = sr1.ReadLine();
                listA.Add(line);

            } 
            while (!sr2.EndOfStream)
            {
                var line = sr2.ReadLine();
                listB.Add(line);

            }
            string r = listA[1];
            listA.RemoveAt(0);
            listB.RemoveAt(0);

            sw.WriteLine("#region character_range_and_cast");
            foreach (var row in listA)
            {
                //Console.WriteLine(row);

                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 6, 6);
                if(int.Parse(id) < 169999 || (int.Parse(id) > 180000 && int.Parse(id) < 189999))
                {
                    string name = idnc.IDtoCharaEngName(id, 6);

                    string position = values[10].Substring(values[10].LastIndexOf("*/") + 2);
                    Pos.Add(position);
                    string atk_type = values[11].Substring(values[11].LastIndexOf("*/") + 2);
                    AtkType.Add(atk_type);
                    string normal_atk_cast_time = values[12].Substring(values[12].LastIndexOf("*/") + 2);
                    NormalAtkCastTime.Add(normal_atk_cast_time);


                    Console.WriteLine(id);
                    Console.WriteLine(position);
                    Console.WriteLine(normal_atk_cast_time);
                }
                
                //sw.WriteLine(result);

            }
            foreach (var row in listB)
            {
                //Console.WriteLine(row); 
                string[] values = row.Split(',');
                string id = values[0].Substring(values[0].Length - 7, 7);
                if(int.Parse(id) < 1699999 || (int.Parse(id) > 1800000 && int.Parse(id)< 1899999))
                {
                    string id1 = id.Substring(0, 4);
                    string id2 = id.Substring(4, 3);

                    string skill_cast_time = values[4].Substring(values[4].LastIndexOf("*/") + 2);
                    if(id2 == "002")
                    {
                        CastTime1.Add(skill_cast_time);
                    }
                    else if(id2 == "003")
                    {

                        CastTime2.Add(skill_cast_time);

                    }
                    else if (id2 == "012")
                    {

                        CastTime1P.Add(skill_cast_time);
                    }
                    Console.WriteLine(string.Format("{0}, {1}", id, skill_cast_time));
                    Console.WriteLine(string.Format("{0}, {1}", id1, id2));

                }

            }

            Console.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}",AtkType.Count,Pos.Count, NormalAtkCastTime.Count,CastTime1.Count,CastTime2.Count,CastTime1P.Count));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            sw.WriteLine("#endregion");


            Console.WriteLine("Finished");




            sw.Close();
        }
    }
}
