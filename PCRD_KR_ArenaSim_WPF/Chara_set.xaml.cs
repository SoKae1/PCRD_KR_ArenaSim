using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PCRD_KR_ArenaSim
{
    /// <summary>
    /// Chara_set.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chara_set : Window
    {
        public Chara_set()
        {
            InitializeComponent();
            InitializeSet();
        }

        public static bool hiyori, yui, rei, misogi, matsuri, akari, miyako, yuki, anna, maho = false;
        public static bool rino, hatsune, nanaka, kasumi, misato, suzuna, kaori, io, mimi, kurumi = false;
        public static bool yori, ayane, suzume, rin, eriko, saren, nozomi, ninon, sinobu, akino = false;
        public static bool mahiru, yukari, kyouka, tomo, siori, aoi, chika, makoto, iriya, kuuka = false;
        public static bool tamaki, zyun, mihuyu, sizuru, misaki, mitsuki, rima, monika, tsumugi, ayumi = false;
        public static bool ruka, zita, pekorinnu, kotkoro, kyaru, muimi, arisa, kaya, inori, labyrista = false;
        public static bool neneka, kristina, pekorinnu_summer, kotkoro_summer, suzume_summer = false;
        public static bool kyaru_summer, tamaki_summer, mihuyu_summer, sinobu_halloween, miyako_halloween = false;
        public static bool misaki_halloween, chika_christmas, kurumi_christmas, ayane_christmas, hiyori_newyear = false;
        public static bool yui_newyear, rei_newyear, eriko_valentine, sizuru_valentine, anne = false;
        public static bool lou, grea, kuuka_ooedo, ninon_ooedo, rem = false;


        public static bool ram, emilia, suzuna_summer, io_summer, saren_summer = false;
        public static bool makoto_summer, kaori_summer, maho_summer, aoi_nakayosi, chloe = false;
        public static bool chieru, yuni, kyouka_halloween, misogi_halloween, mimi_halloween = false;
        public static bool runa, kristina_christmas, nozomi_christmas, iriya_christmas, kotkoro_newyear = false;
        public static bool kyaru_newyear, suzume_newyear, kasumi_magical, siori_magical, uzuki_deremas = false;
        public static bool rin_deremas, mio_deremas, rin_ranger, mahiru_ranger, rino_wonder = false;
        public static bool ayumi_wonder, ruka_summer, anna_summer, nanaka_summer, hatsune_summer = false;
        public static bool misato_summer, zyun_summer, akari_angel, yui_princess, pekorinnu_princess = false;
        public static bool kotkoro_princess = false;

        public static bool yori_angel, tsumugi_halloween, rei_halloween, matsuri_halloween = false;
        public static bool monika_magical, tomo_magical = false;
        public static bool shepi, hiyori_princess, kyaru_princess = false;
        public static bool akino_christmas, saren_christmas, yukari_christmas = false;
        public static bool muimi_newyear, neneka_newyear, pekorinnu_newyear = false;
        public static bool kotkoro_maiden, yui_maiden = false;
        public static bool kasumi_summer = false;
        public static bool rima_cinderella, makoto_cinderella, maho_cinderella = false;
        public static bool chloe_nakayosi2, chieru_nakayosi2, yuni_nakayosi2 = false;
        public static bool inori_timetravel, kaya_timetravel = false;
        public static bool aoi_worker, tamaki_worker, mihuyu_worker = false;
        //작후유까지 

        public string Chara_Selected_EN;
        public string Chara_Selected_KR;
        public int isCharaEnabled;



        private void Window_ContentRendered(object sender, EventArgs e)
        {
            WindowToMousePosition();
        }
        private void WindowToMousePosition()
        {
            Debug.WriteLine(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width);
            Debug.WriteLine(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);

            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            var dpiX = (int)dpiXProperty.GetValue(null, null);
            var dpiY = (int)dpiYProperty.GetValue(null, null);
            int scaleX = dpiX / 96;
            int scaleY = dpiY / 96;

            int width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / scaleX;
            int height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / scaleY;

            Debug.WriteLine("width = " + width);
            Debug.WriteLine("height = " + height);

            Debug.WriteLine("dpiX = " + dpiX); 
            Debug.WriteLine("dpiY = " + dpiY);
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var mouse = transform.Transform(GetMousePosition());
            
            Debug.WriteLine("mouseX = " + mouse.X);
            Debug.WriteLine("mouseY = " + mouse.Y);
            Left = (mouse.X - ActualWidth /2 >0) ? ((mouse.X + ActualWidth / 2 > width) ? (width - ActualWidth) : (mouse.X - ActualWidth / 2)) : 0;
            Top = (mouse.Y - ActualHeight/2>0) ? ((mouse.Y + ActualHeight / 2 > height) ? (height - ActualHeight) : (mouse.Y - ActualHeight / 2)) : 0;
        }

        public System.Windows.Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MouseDown += delegate (object sender1, MouseButtonEventArgs ee) { if (ee.ChangedButton == MouseButton.Left) DragMove(); };
        }
        private void bt_chara_set_exit_Click(object sender, RoutedEventArgs e)
        {
            False_All();
            this.Close();
        }

        private void Chara_Set_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Escape))
            {
                False_All();
                this.Close();
            }
        }

        private void LoadOffCharaSetting(string SelectedCharaKR, string SelectedCharaEN)
        {
            //원래 구현 12   내가 한것 61
            //         34            52
            //         56            43
            //

            //캐릭터 정보 불러오기
            StreamReader sr = new StreamReader("character_offence.txt");

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                int pos = Array.IndexOf(temp, SelectedCharaKR);
                if (pos > -1)
                {
                    isCharaEnabled = Convert.ToInt32(temp[pos + 1]);
                    if (isCharaEnabled == 1)
                        cb_enable_set.IsChecked = true;
                    else
                        cb_enable_set.IsChecked = false;

                    Level_variable.star_temp = Convert.ToInt32(temp[pos + 2]);
                    Level_variable.Lv_temp = Convert.ToInt32(temp[pos + 3]);
                    Level_variable.Rank_temp = Convert.ToInt32(temp[pos + 4]);

                    //pos + 4 : 전용장비 0~160
                    Level_variable.equip_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 5]));
                    Debug.WriteLine(Level_variable.equip_temp);
                    Level_variable.UE_Lv_temp = Convert.ToInt32(temp[pos + 5]);
#if DEBUG
                    Debug.WriteLine(Convert.ToString(temp[pos + 2]) + "," + Convert.ToString(temp[pos + 3]) + "," + Convert.ToString(temp[pos + 4])
                        + "," + Convert.ToString(temp[pos + 5]) + "," + Convert.ToString(temp[pos + 6]) + "," + Convert.ToString(temp[pos + 7])
                        + "," + Convert.ToString(temp[pos + 8]) + "," + Convert.ToString(temp[pos + 9]) + "," + Convert.ToString(temp[pos + 10]) + "," + Convert.ToString(temp[pos + 11]));
#else
#endif
                    //pos + 5~ 10: 1~6템
                    //원래 구현 -> 내가 한것
                    // 1=6
                    // 2=1
                    // 3=5
                    // 4=2
                    // 5=4
                    // 6=3
                    //1템

                    Debug.WriteLine("3545 IsItemEnabled?");

                    if (Convert.ToInt32(temp[pos + 6]) > 0)
                    { Level_variable.equip2_temp = true; bt_item1.IsEnabled = true; }
                    else
                    {
                        Level_variable.equip2_temp = false;
                    }

                    if (Convert.ToInt32(temp[pos + 7]) > 0)
                    { Level_variable.equip4_temp = true; bt_item2.IsEnabled = true; }
                    else
                    {
                        Level_variable.equip4_temp = false;
                    }
                    if (Convert.ToInt32(temp[pos + 8]) > 0)
                    { Level_variable.equip6_temp = true; bt_item3.IsEnabled = true; }
                    else
                    {
                        Level_variable.equip6_temp = false;
                    }
                    if (Convert.ToInt32(temp[pos + 9]) > 0)
                    { Level_variable.equip5_temp = true; bt_item4.IsEnabled = true; }
                    else
                    {
                        Level_variable.equip5_temp = false;
                    }
                    if (Convert.ToInt32(temp[pos + 10]) > 0)
                    {
                        Level_variable.equip3_temp = true;
                        bt_item5.IsEnabled = true;
                    }
                    else
                    {
                        Level_variable.equip3_temp = false;
                    }
                    if (Convert.ToInt32(temp[pos + 11]) > 0)
                    { Level_variable.equip1_temp = true; bt_item6.IsEnabled = true; }
                    else
                    {
                        Level_variable.equip1_temp = false;
                    }

                    //강화

                    Debug.WriteLine("3545 item ");

                    Level_variable.rf2_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 6])) ? Convert.ToInt32(temp[pos + 6]) : 0;
                    Level_variable.rf4_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 7])) ? Convert.ToInt32(temp[pos + 7]) : 0;
                    Level_variable.rf6_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 8])) ? Convert.ToInt32(temp[pos + 8]) : 0;
                    Level_variable.rf5_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 9])) ? Convert.ToInt32(temp[pos + 9]) : 0;
                    Level_variable.rf3_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 10])) ? Convert.ToInt32(temp[pos + 10]) : 0;
                    Level_variable.rf1_temp = Convert.ToBoolean(Convert.ToInt32(temp[pos + 11])) ? Convert.ToInt32(temp[pos + 11]) : 0;


                    break;
                }
            }
            sr.Close();

            #region UI_Setting

            Debug.WriteLine("3545 Initialize level star unique");

            Initialize_chara_level(Level_variable.Lv_temp);
            Initialize_chara_star(Level_variable.star_temp);
            Initialize_item_unique(Level_variable.UE_Lv_temp);

            Initialize_item1_rf_star(Level_variable.rf2_temp);
            Initialize_item2_rf_star(Level_variable.rf4_temp);
            Initialize_item3_rf_star(Level_variable.rf6_temp);
            Initialize_item4_rf_star(Level_variable.rf5_temp);
            Initialize_item5_rf_star(Level_variable.rf3_temp);
            Initialize_item6_rf_star(Level_variable.rf1_temp);

            if (Level_variable.Rank_temp == 11) { cB_set_rank.SelectedIndex = 0; }
            if (Level_variable.Rank_temp == 12) { cB_set_rank.SelectedIndex = 1; }
            if (Level_variable.Rank_temp == 13) { cB_set_rank.SelectedIndex = 2; }
            if (Level_variable.Rank_temp == 14) { cB_set_rank.SelectedIndex = 3; }
            if (Level_variable.Rank_temp == 15) { cB_set_rank.SelectedIndex = 4; }
            if (Level_variable.Rank_temp == 16) { cB_set_rank.SelectedIndex = 5; }
            if (Level_variable.Rank_temp == 17) { cB_set_rank.SelectedIndex = 6; }
            if (Level_variable.Rank_temp == 18) { cB_set_rank.SelectedIndex = 7; }
            if (Level_variable.Rank_temp == 19) { cB_set_rank.SelectedIndex = 8; }
            if (Level_variable.Rank_temp == 20) { cB_set_rank.SelectedIndex = 9; }
            if (Level_variable.Rank_temp == 21) { cB_set_rank.SelectedIndex = 10; }
            if (Level_variable.Rank_temp == 22) { cB_set_rank.SelectedIndex = 11; }

            string uriString = "pack://application:,,,/res/icon_equipment/";
            string UniqueItem = "999999";

            if (Level_variable.equip_temp)
            {
                if (rima == true) { UniqueItem = "130521"; }
                else if (miyako == true) { UniqueItem = "130071"; }
                else if (kuuka == true) { UniqueItem = "130451"; }
                else if (zyun == true) { UniqueItem = "130471"; }
                else if (kuuka_ooedo == true) { UniqueItem = "130951"; }
                else if (kaori == true) { UniqueItem = "130171"; }
                else if (rei_newyear == true) { UniqueItem = "130891"; }
                else if (pekorinnu == true) { UniqueItem = "130581"; }
                else if (pekorinnu_princess == true) { UniqueItem = "999999"; }
                else if (ruka == true) { UniqueItem = "130561"; }
                else if (kotkoro_newyear == true) { UniqueItem = "131191"; }
                else if (nozomi == true) { UniqueItem = "130291"; }
                else if (muimi == true) { UniqueItem = "130051"; }
                else if (makoto == true) { UniqueItem = "130431"; }
                else if (kaya == true) { UniqueItem = "130651"; }
                else if (hiyori_newyear == true) { UniqueItem = "130871"; }
                else if (ninon_ooedo == true) { UniqueItem = "130961"; }
                else if (akino == true) { UniqueItem = "130321"; }
                else if (makoto_summer == true) { UniqueItem = "131041"; }
                else if (matsuri == true) { UniqueItem = "130021"; }
                else if (chloe == true) { UniqueItem = "131081"; }
                else if (chieru == true) { UniqueItem = "131091"; }
                else if (yuni == true) { UniqueItem = "131101"; }
                else if (eriko_valentine == true) { UniqueItem = "130901"; }
                else if (ayane_christmas == true) { UniqueItem = "130861"; }
                else if (tsumugi == true) { UniqueItem = "130541"; }
                else if (hiyori == true) { UniqueItem = "130011"; }
                else if (misogi == true) { UniqueItem = "130041"; }
                else if (ayane == true) { UniqueItem = "130231"; }
                else if (misogi_halloween == true) { UniqueItem = "131121"; }
                else if (tamaki == true) { UniqueItem = "130461"; }
                else if (tomo == true) { UniqueItem = "130371"; }
                else if (tamaki_summer == true) { UniqueItem = "130791"; }
                else if (eriko == true) { UniqueItem = "130271"; }
                else if (pekorinnu_summer == true) { UniqueItem = "130751"; }
                else if (kurumi == true) { UniqueItem = "130211"; }
                else if (zita == true) { UniqueItem = "130571"; }
                else if (rei == true) { UniqueItem = "130031"; }
                else if (iriya_christmas == true) { UniqueItem = "131171"; }
                else if (kristina_christmas == true) { UniqueItem = "131151"; }
                else if (sizuru == true) { UniqueItem = "130711"; }
                else if (kristina == true) { UniqueItem = "131151"; }
                else if (kurumi_christmas == true) { UniqueItem = "130851"; }
                else if (mimi == true) { UniqueItem = "130201"; }
                else if (sinobu == true) { UniqueItem = "130311"; }
                else if (mimi_halloween == true) { UniqueItem = "131131"; }
                else if (sizuru_valentine == true) { UniqueItem = "130921"; }
                else if (mahiru == true) { UniqueItem = "130331"; }
                else if (yukari == true) { UniqueItem = "130341"; }
                else if (monika == true) { UniqueItem = "130531"; }
                else if (ninon == true) { UniqueItem = "130301"; }
                else if (nozomi_christmas == true) { UniqueItem = "131161"; }
                else if (mihuyu == true) { UniqueItem = "130481"; }
                else if (iriya == true) { UniqueItem = "130441"; }
                else if (kaori_summer == true) { UniqueItem = "131051"; }
                else if (saren == true) { UniqueItem = "130281"; }
                else if (anna == true) { UniqueItem = "130091"; }
                else if (sinobu_halloween == true) { UniqueItem = "130811"; }
                else if (mihuyu_summer == true) { UniqueItem = "130801"; }
                else if (kotkoro == true) { UniqueItem = "130591"; }
                else if (ayumi == true) { UniqueItem = "130551"; }
                else if (grea == true) { UniqueItem = "130941"; }
                else if (kotkoro_summer == true) { UniqueItem = "130761"; }
                else if (rem == true) { UniqueItem = "130971"; }
                else if (ram == true) { UniqueItem = "130981"; }
                else if (rin == true) { UniqueItem = "130261"; }
                else if (mitsuki == true) { UniqueItem = "130511"; }
                else if (akari == true) { UniqueItem = "130061"; }
                else if (yori == true) { UniqueItem = "130221"; }
                else if (saren_summer == true) { UniqueItem = "131031"; }
                else if (miyako_halloween == true) { UniqueItem = "130821"; }
                else if (arisa == true) { UniqueItem = "130631"; }
                else if (anne == true) { UniqueItem = "130921"; }
                else if (lou == true) { UniqueItem = "130931"; }
                else if (neneka == true) { UniqueItem = "999999"; }
                else if (aoi_nakayosi == true) { UniqueItem = "131071"; }
                else if (kyaru_newyear == true) { UniqueItem = "131201"; }
                else if (rino == true) { UniqueItem = "130111"; }
                else if (suzuna == true) { UniqueItem = "130161"; }
                else if (suzuna_summer == true) { UniqueItem = "131001"; }
                else if (siori == true) { UniqueItem = "130381"; }
                else if (siori_magical == true) { UniqueItem = "131231"; }
                else if (io == true) { UniqueItem = "130181"; }
                else if (io_summer == true) { UniqueItem = "131011"; }
                else if (suzume == true) { UniqueItem = "130251"; }
                else if (suzume_newyear == true) { UniqueItem = "131211"; }
                else if (emilia == true) { UniqueItem = "130991"; }
                else if (kasumi == true) { UniqueItem = "130141"; }
                else if (kasumi_magical == true) { UniqueItem = "131221"; }
                else if (misato == true) { UniqueItem = "130151"; }
                else if (nanaka == true) { UniqueItem = "130131"; }
                else if (yui_newyear == true) { UniqueItem = "130881"; }
                else if (kyaru == true) { UniqueItem = "130601"; }
                else if (hatsune == true) { UniqueItem = "130121"; }
                else if (misaki == true) { UniqueItem = "130501"; }
                else if (runa == true) { UniqueItem = "131141"; }
                else if (chika_christmas == true) { UniqueItem = "130841"; }
                else if (suzume_summer == true) { UniqueItem = "130771"; }
                else if (kyaru_summer == true) { UniqueItem = "130781"; }
                else if (aoi == true) { UniqueItem = "130401"; }
                else if (chika == true) { UniqueItem = "130421"; }
                else if (maho_summer == true) { UniqueItem = "131061"; }
                else if (maho == true) { UniqueItem = "130101"; }
                else if (yui == true) { UniqueItem = "130021"; }
                else if (yuki == true) { UniqueItem = "130081"; }
                else if (kyouka == true) { UniqueItem = "130361"; }
                else if (misaki_halloween == true) { UniqueItem = "130831"; }
                else if (kyouka_halloween == true) { UniqueItem = "131111"; }
                else if (uzuki_deremas == true) { UniqueItem = "131241"; }
                else if (mio_deremas == true) { UniqueItem = "131261"; }
                else if (rin_deremas == true) { UniqueItem = "131251"; }
                else if (rin_ranger == true) { UniqueItem = "131271"; }
                else if (mahiru_ranger == true) { UniqueItem = "131281"; }
                else if (rino_wonder == true) { UniqueItem = "131291"; }
                else if (ayumi_wonder == true) { UniqueItem = "131301"; }
                else if (ruka_summer == true) { UniqueItem = "999999"; }
                else if (anna_summer == true) { UniqueItem = "999999"; }
                else if (nanaka_summer == true) { UniqueItem = "999999"; }
                else if (hatsune_summer == true) { UniqueItem = "999999"; }
                else if (misato_summer == true) { UniqueItem = "999999"; }
                else if (zyun_summer == true) { UniqueItem = "999999"; }
                else if (akari_angel == true) { UniqueItem = "999999"; }
                else { UniqueItem = "999999"; }

                var uriSource1 = new Uri(uriString + UniqueItem + ".png", UriKind.Absolute);
                BitmapImage bmi1 = new BitmapImage(uriSource1);
                img_item_unique.Source = bmi1;

                #endregion


            }

            #region ApplyStat
            //스탯 적용

            status_cal_temp(SelectedCharaEN, Level_variable.star_temp, Level_variable.Lv_temp, Level_variable.Rank_temp, 15);

            status_equip_temp(SelectedCharaEN, Level_variable.Rank_temp,
                Level_variable.equip1_temp, Level_variable.equip2_temp, Level_variable.equip3_temp,
                Level_variable.equip4_temp, Level_variable.equip5_temp, Level_variable.equip6_temp,
                Level_variable.rf1_temp, Level_variable.rf2_temp, Level_variable.rf3_temp,
                Level_variable.rf4_temp, Level_variable.rf5_temp, Level_variable.rf6_temp, 15);

            status_unique_equip_temp(SelectedCharaEN, ref Level_variable.equip_temp, Level_variable.UE_Lv_temp, 15);
            status_destiny_temp(SelectedCharaEN, 15);


            //전투력 적용

            Level_variable.power_temp = Stat_variable.HP_temp * 0.1 + Stat_variable.PA_temp * 1 + Stat_variable.MA_temp * 1
                + Stat_variable.PD_temp * 4.5 + Stat_variable.MD_temp * 4.5
                + Stat_variable.PC_temp * 0.5 + Stat_variable.MC_temp * 0.5 + Stat_variable.HPauto_temp * 0.1
                + Stat_variable.TPauto_temp * 0.3 + Stat_variable.Dodge_temp * 6 + Stat_variable.HPabs_temp * 4.5 + Stat_variable.HPup_temp * 1
                + Stat_variable.TPup_temp * 1.5 + Stat_variable.TPdec_temp * 3 + Stat_variable.acc_temp * 2;

            Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10;

            if (Level_variable.equip_temp == true)
            {
                Level_variable.power_temp += Level_variable.Lv_temp * 1.2 * 10 + 100;
            }
            else
            {
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10;
            }

            if (Level_variable.star_temp >= 6)
            {
                Level_variable.power_temp += Level_variable.Lv_temp * 1.5 * 10 + 2000;
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10 + 150;
            }
            else if (Level_variable.star_temp >= 5)
            {
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10;
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10 + 150;
            }
            else
            {
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10;
                Level_variable.power_temp += Level_variable.Lv_temp * 1 * 10;
            }


#if DEBUG
            Debug.WriteLine("3545 Stat");
            Debug.WriteLine(String.Format("{0}", Stat_variable.HP_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.PA_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.MA_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.PD_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.MD_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.PC_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.MC_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.Dodge_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.acc_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.HPauto_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.TPauto_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.HPabs_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.HPup_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.TPup_temp));
            Debug.WriteLine(String.Format("{0}", Stat_variable.TPdec_temp));
            Debug.WriteLine(String.Format("{0:F2}", Level_variable.power_temp));
#else
#endif
            tB_HP.Text = String.Format("{0}", Stat_variable.HP_temp);
            tB_PA.Text = String.Format("{0}", Stat_variable.PA_temp);
            tB_MA.Text = String.Format("{0}", Stat_variable.MA_temp);
            tB_PD.Text = String.Format("{0}", Stat_variable.PD_temp);
            tB_MD.Text = String.Format("{0}", Stat_variable.MD_temp);
            tB_PC.Text = String.Format("{0}", Stat_variable.PC_temp);
            tB_MC.Text = String.Format("{0}", Stat_variable.MC_temp);
            tB_Dodge.Text = String.Format("{0}", Stat_variable.Dodge_temp);
            tB_Acc.Text = String.Format("{0}", Stat_variable.acc_temp);
            tB_HPauto.Text = String.Format("{0}", Stat_variable.HPauto_temp);
            tB_TPauto.Text = String.Format("{0}", Stat_variable.TPauto_temp);
            tB_HPabs.Text = String.Format("{0}", Stat_variable.HPabs_temp);
            tB_HPup.Text = String.Format("{0}", Stat_variable.HPup_temp);
            tB_TPup.Text = String.Format("{0}", Stat_variable.TPup_temp);
            tB_TPdec.Text = String.Format("{0}", Stat_variable.TPdec_temp);
            tB_Power.Text = String.Format("{0:F2}", Level_variable.power_temp);
            #endregion
        }
        private void bt_chara_save_off_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("character_offence.txt");
            int row = 0;

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                int pos = Array.IndexOf(temp, Chara_Selected_KR);
                if (pos > -1)
                {
                    break;
                }
                else
                {
                    row++;
                }
            }
            sr.Close();

            string newString = Chara_Selected_KR + "," + Convert.ToString(isCharaEnabled) + "," + Level_variable.star_temp + "," + Level_variable.Lv_temp + "," + Level_variable.Rank_temp
                + "," + Level_variable.UE_Lv_temp + "," + Level_variable.rf2_temp + "," + Level_variable.rf4_temp + "," + Level_variable.rf6_temp
               + "," + Level_variable.rf5_temp + "," + Level_variable.rf3_temp + "," + Level_variable.rf1_temp;

            if (ReplaceStringInFile("character_offence.txt", row, newString))
            {
                LoadOffCharaSetting(Chara_Selected_KR, Chara_Selected_EN);
                MessageBox.Show("저장했어!", "알림");
            }
            else
                Debug.WriteLine("Error.");


            //pos + 5~ 10: 1~6템
            //원래 구현 -> 내가 한것
            // 1=>6
            // 2=>1
            // 3=>5
            // 4=>2
            // 5=>4
            // 6=>3
            //1템
            //
        }

        private void bt_chara_save_def_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("character_defence.txt");
            int row = 0;

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                int pos = Array.IndexOf(temp, Chara_Selected_KR);
                if (pos > -1)
                {
                    break;
                }
                else
                {
                    row++;
                }
            }
            sr.Close();

            string newString = Chara_Selected_KR + "," + Convert.ToString(isCharaEnabled) + "," + Level_variable.star_temp + "," + Level_variable.Lv_temp + "," + Level_variable.Rank_temp
                + "," + Level_variable.UE_Lv_temp + "," + Level_variable.rf2_temp + "," + Level_variable.rf4_temp + "," + Level_variable.rf6_temp
               + "," + Level_variable.rf5_temp + "," + Level_variable.rf3_temp + "," + Level_variable.rf1_temp;

            if (ReplaceStringInFile("character_defence.txt", row, newString))
            {
                LoadOffCharaSetting(Chara_Selected_KR, Chara_Selected_EN);
                MessageBox.Show("저장했어!", "알림");
            }
            else
                Debug.WriteLine("Error.");

            //pos + 5~ 10: 1~6템
            //원래 구현 -> 내가 한것
            // 1=>6
            // 2=>1
            // 3=>5
            // 4=>2
            // 5=>4
            // 6=>3
            //1템
            //
        }        
        private void cb_enable_set_Checked(object sender, RoutedEventArgs e) { isCharaEnabled = 1; }

        private void cb_enable_set_Unchecked(object sender, RoutedEventArgs e) { isCharaEnabled = 0; }

        private void tB_unique_level_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;

            if (int.TryParse(tB_unique_level.Text.Replace(",", ""), out i))
            {
                // textBox1의 값이 숫자이면 textBox1에 값 입력
                tB_unique_level.Text = i.ToString();

                Level_variable.UE_Lv_temp = Convert.ToInt32(tB_unique_level.Text);
            }
            else
            {
                // textBox1의 값이 숫자가 아니면 0으로 변경
                tB_unique_level.Text = "0";
            }
        }

        private void tB_chara_level_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i;

            if (int.TryParse(tB_chara_level.Text.Replace(",", ""), out i))
            {
                // textBox1의 값이 숫자이면 textBox1에 값 입력
                tB_chara_level.Text = i.ToString();
            }
            else
            {
                // textBox1의 값이 숫자가 아니면 1로 변경
                tB_chara_level.Text = "1";
            }
            Level_variable.Lv_temp = Convert.ToInt32(tB_chara_level.Text);
        }

        public static bool ReplaceStringInFile(string filename, int position, string str)
        {
            // 1. Verify that file exists.
            // Is used static function Exists().
            if (!File.Exists(filename)) return false;

            // 2. Get data from a file as an array of strings.
            // To do this, use the ReadAllLines () method.
            string[] arrayS = File.ReadAllLines(filename);

            // 3. Check if row position value is correct
            if ((position < 0) || (position >= arrayS.Length))
                return false;

            // 4. Replace the string
            arrayS[position] = str;

            // 5. Write the array of strings to the file
            File.WriteAllLines(filename, arrayS);

            // 6. Return the result
            return true;
        }

        private void bt_item_unique_set_Click(object sender, RoutedEventArgs e)
        {
            if (Level_variable.equip_temp)
            {
                Level_variable.equip_temp = false;
                Level_variable.UE_Lv_temp = 0;
                tB_unique_level.IsEnabled = false;
                img_item_unique.Opacity = 0.25;
            }
            else
            {
                Level_variable.equip_temp = true;
                Level_variable.UE_Lv_temp = Convert.ToInt32(tB_unique_level.Text);
                tB_unique_level.IsEnabled = true;
                img_item_unique.Opacity = 1.0;
            }
        }

        private void bt_chara_star_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_chara.png", UriKind.Absolute);
            var uriStar_down = new Uri("pack://application:,,,/res/star_chara_down.png", UriKind.Absolute);
            var uriStar_6 = new Uri("pack://application:,,,/res/star_chara_6.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_down = new BitmapImage(uriStar_down);
            BitmapImage bmi_Star_6 = new BitmapImage(uriStar_6);

            switch (Level_variable.star_temp)
            {
                case 3:
                    Level_variable.star_temp = 5;
                    img_star_chara6.Opacity = 0.0;
                    img_star_chara5.Source = bmi_Star;
                    img_star_chara4.Source = bmi_Star;
                    break;
                case 4:
                    Level_variable.star_temp = 3;
                    img_star_chara6.Opacity = 0.0;
                    img_star_chara5.Source = bmi_Star_down;
                    img_star_chara4.Source = bmi_Star_down;
                    break;
                case 5:
                    Level_variable.star_temp = 4;
                    img_star_chara6.Opacity = 0.0;
                    img_star_chara5.Source = bmi_Star_down;
                    img_star_chara4.Source = bmi_Star;
                    break;
                case 6:
                    break;

                default:
                    break;
            }
        }

        //원래 구현 12   내가 한것 61
        //         34            52
        //         56            43
        //

        #region itemSet
        private void bt_item1_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip2_temp == true)
            {
                switch (Level_variable.rf2_temp)
                {
                    case 0:
                        img_item1.Opacity = 0.25;
                        Level_variable.equip2_temp = false;
                        Level_variable.rf2_temp = -1;
                        img_star_item1_rf1.Source = bmi_Star_empty;
                        img_star_item1_rf2.Source = bmi_Star_empty;
                        img_star_item1_rf3.Source = bmi_Star_empty;
                        img_star_item1_rf4.Source = bmi_Star_empty;
                        img_star_item1_rf5.Source = bmi_Star_empty;
                        img_star_item1_rf1.Opacity = 0.0;
                        img_star_item1_rf5.Opacity = 0.0;
                        img_star_item1_rf4.Opacity = 0.0;
                        img_star_item1_rf3.Opacity = 0.0;
                        img_star_item1_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf2_temp = 0;
                        img_star_item1_rf1.Source = bmi_Star_empty;
                        img_star_item1_rf2.Source = bmi_Star_empty;
                        img_star_item1_rf3.Source = bmi_Star_empty;
                        img_star_item1_rf4.Source = bmi_Star_empty;
                        img_star_item1_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:
                        Level_variable.rf2_temp = 1;
                        img_star_item1_rf2.Source = bmi_Star_empty;
                        img_star_item1_rf3.Source = bmi_Star_empty;
                        img_star_item1_rf4.Source = bmi_Star_empty;
                        img_star_item1_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf2_temp = 2;
                        img_star_item1_rf3.Source = bmi_Star_empty;
                        img_star_item1_rf4.Source = bmi_Star_empty;
                        img_star_item1_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf2_temp = 3;
                        img_star_item1_rf4.Source = bmi_Star_empty;
                        img_star_item1_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf2_temp = 4;
                        img_star_item1_rf5.Source = bmi_Star_empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                img_item1.Opacity = 1;
                Level_variable.equip2_temp = true;
                Level_variable.rf2_temp = 5;
                img_star_item1_rf1.Source = bmi_Star;
                img_star_item1_rf2.Source = bmi_Star;
                img_star_item1_rf3.Source = bmi_Star;
                img_star_item1_rf4.Source = bmi_Star;
                img_star_item1_rf5.Source = bmi_Star;
                img_star_item1_rf1.Opacity = 1.0;
                img_star_item1_rf5.Opacity = 1.0;
                img_star_item1_rf4.Opacity = 1.0;
                img_star_item1_rf3.Opacity = 1.0;
                img_star_item1_rf2.Opacity = 1.0;
            }


        }
        private void bt_item2_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip4_temp == true)
            {
                switch (Level_variable.rf4_temp)
                {
                    case 0:
                        img_item2.Opacity = 0.25;
                        Level_variable.equip4_temp = false;
                        Level_variable.rf4_temp = -1;
                        img_star_item2_rf1.Source = bmi_Star_empty;
                        img_star_item2_rf2.Source = bmi_Star_empty;
                        img_star_item2_rf3.Source = bmi_Star_empty;
                        img_star_item2_rf4.Source = bmi_Star_empty;
                        img_star_item2_rf5.Source = bmi_Star_empty;
                        img_star_item2_rf1.Opacity = 0.0;
                        img_star_item2_rf5.Opacity = 0.0;
                        img_star_item2_rf4.Opacity = 0.0;
                        img_star_item2_rf3.Opacity = 0.0;
                        img_star_item2_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf4_temp = 0;
                        img_star_item2_rf1.Source = bmi_Star_empty;
                        img_star_item2_rf2.Source = bmi_Star_empty;
                        img_star_item2_rf3.Source = bmi_Star_empty;
                        img_star_item2_rf4.Source = bmi_Star_empty;
                        img_star_item2_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:

                        Level_variable.rf4_temp = 1;
                        img_star_item2_rf2.Source = bmi_Star_empty;
                        img_star_item2_rf3.Source = bmi_Star_empty;
                        img_star_item2_rf4.Source = bmi_Star_empty;
                        img_star_item2_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf4_temp = 2;
                        img_star_item2_rf3.Source = bmi_Star_empty;
                        img_star_item2_rf4.Source = bmi_Star_empty;
                        img_star_item2_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf4_temp = 3;
                        img_star_item2_rf4.Source = bmi_Star_empty;
                        img_star_item2_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf4_temp = 4;
                        img_star_item2_rf5.Source = bmi_Star_empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                img_item2.Opacity = 1;
                Level_variable.equip4_temp = true;
                Level_variable.rf4_temp = 5;
                img_star_item2_rf1.Source = bmi_Star;
                img_star_item2_rf2.Source = bmi_Star;
                img_star_item2_rf3.Source = bmi_Star;
                img_star_item2_rf4.Source = bmi_Star;
                img_star_item2_rf5.Source = bmi_Star;
                img_star_item2_rf1.Opacity = 1.0;
                img_star_item2_rf5.Opacity = 1.0;
                img_star_item2_rf4.Opacity = 1.0;
                img_star_item2_rf3.Opacity = 1.0;
                img_star_item2_rf2.Opacity = 1.0;
            }


        }
        private void bt_item3_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip6_temp == true)
            {
                switch (Level_variable.rf6_temp)
                {
                    case 0:
                        img_item3.Opacity = 0.25;
                        Level_variable.equip6_temp = false;
                        Level_variable.rf6_temp = -1;
                        img_star_item3_rf1.Source = bmi_Star_empty;
                        img_star_item3_rf2.Source = bmi_Star_empty;
                        img_star_item3_rf3.Source = bmi_Star_empty;
                        img_star_item3_rf4.Source = bmi_Star_empty;
                        img_star_item3_rf5.Source = bmi_Star_empty;
                        img_star_item3_rf1.Opacity = 0.0;
                        img_star_item3_rf5.Opacity = 0.0;
                        img_star_item3_rf4.Opacity = 0.0;
                        img_star_item3_rf3.Opacity = 0.0;
                        img_star_item3_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf6_temp = 0;
                        img_star_item3_rf1.Source = bmi_Star_empty;
                        img_star_item3_rf2.Source = bmi_Star_empty;
                        img_star_item3_rf3.Source = bmi_Star_empty;
                        img_star_item3_rf4.Source = bmi_Star_empty;
                        img_star_item3_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:

                        Level_variable.rf6_temp = 1;
                        img_star_item3_rf2.Source = bmi_Star_empty;
                        img_star_item3_rf3.Source = bmi_Star_empty;
                        img_star_item3_rf4.Source = bmi_Star_empty;
                        img_star_item3_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf6_temp = 2;
                        img_star_item3_rf3.Source = bmi_Star_empty;
                        img_star_item3_rf4.Source = bmi_Star_empty;
                        img_star_item3_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf6_temp = 3;
                        img_star_item3_rf4.Source = bmi_Star_empty;
                        img_star_item3_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf6_temp = 4;
                        img_star_item3_rf5.Source = bmi_Star_empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                img_item3.Opacity = 1;
                Level_variable.equip6_temp = true;
                Level_variable.rf6_temp = 5;
                img_star_item3_rf1.Source = bmi_Star;
                img_star_item3_rf2.Source = bmi_Star;
                img_star_item3_rf3.Source = bmi_Star;
                img_star_item3_rf4.Source = bmi_Star;
                img_star_item3_rf5.Source = bmi_Star;
                img_star_item3_rf1.Opacity = 1.0;
                img_star_item3_rf5.Opacity = 1.0;
                img_star_item3_rf4.Opacity = 1.0;
                img_star_item3_rf3.Opacity = 1.0;
                img_star_item3_rf2.Opacity = 1.0;
            }


        }        
        private void bt_item4_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip5_temp == true)
            {
                switch (Level_variable.rf5_temp)
                {
                    case 0:
                        img_item4.Opacity = 0.25;
                        Level_variable.equip5_temp = false;
                        Level_variable.rf5_temp = -1;
                        img_star_item4_rf1.Source = bmi_Star_empty;
                        img_star_item4_rf2.Source = bmi_Star_empty;
                        img_star_item4_rf3.Source = bmi_Star_empty;
                        img_star_item4_rf4.Source = bmi_Star_empty;
                        img_star_item4_rf5.Source = bmi_Star_empty;

                        img_star_item4_rf1.Opacity = 0.0;
                        img_star_item4_rf5.Opacity = 0.0;
                        img_star_item4_rf4.Opacity = 0.0;
                        img_star_item4_rf3.Opacity = 0.0;
                        img_star_item4_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf5_temp = 0;
                        img_star_item4_rf1.Source = bmi_Star_empty;
                        img_star_item4_rf2.Source = bmi_Star_empty;
                        img_star_item4_rf3.Source = bmi_Star_empty;
                        img_star_item4_rf4.Source = bmi_Star_empty;
                        img_star_item4_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:

                        Level_variable.rf5_temp = 1;
                        img_star_item4_rf2.Source = bmi_Star_empty;
                        img_star_item4_rf3.Source = bmi_Star_empty;
                        img_star_item4_rf4.Source = bmi_Star_empty;
                        img_star_item4_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf5_temp = 2;
                        img_star_item4_rf3.Source = bmi_Star_empty;
                        img_star_item4_rf4.Source = bmi_Star_empty;
                        img_star_item4_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf5_temp = 3;
                        img_star_item4_rf4.Source = bmi_Star_empty;
                        img_star_item4_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf5_temp = 4;
                        img_star_item4_rf5.Source = bmi_Star_empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                img_item4.Opacity = 1;
                Level_variable.equip5_temp = true;
                Level_variable.rf5_temp = 5;
                img_star_item4_rf1.Source = bmi_Star;
                img_star_item4_rf2.Source = bmi_Star;
                img_star_item4_rf3.Source = bmi_Star;
                img_star_item4_rf4.Source = bmi_Star;
                img_star_item4_rf5.Source = bmi_Star;
                img_star_item4_rf1.Opacity = 1.0;
                img_star_item4_rf5.Opacity = 1.0;
                img_star_item4_rf4.Opacity = 1.0;
                img_star_item4_rf3.Opacity = 1.0;
                img_star_item4_rf2.Opacity = 1.0;
            }


        }
        private void bt_item5_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip3_temp == true)
            {
                switch (Level_variable.rf3_temp)
                {
                    case 0:
                        img_item5.Opacity = 0.25;
                        Level_variable.equip3_temp = false;
                        Level_variable.rf3_temp = -1;
                        img_star_item5_rf1.Source = bmi_Star_empty;
                        img_star_item5_rf2.Source = bmi_Star_empty;
                        img_star_item5_rf3.Source = bmi_Star_empty;
                        img_star_item5_rf4.Source = bmi_Star_empty;
                        img_star_item5_rf5.Source = bmi_Star_empty;
                        img_star_item5_rf1.Opacity = 0.0;
                        img_star_item5_rf5.Opacity = 0.0;
                        img_star_item5_rf4.Opacity = 0.0;
                        img_star_item5_rf3.Opacity = 0.0;
                        img_star_item5_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf3_temp = 0;
                        img_star_item5_rf1.Source = bmi_Star_empty;
                        img_star_item5_rf2.Source = bmi_Star_empty;
                        img_star_item5_rf3.Source = bmi_Star_empty;
                        img_star_item5_rf4.Source = bmi_Star_empty;
                        img_star_item5_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:

                        Level_variable.rf3_temp = 1;
                        img_star_item5_rf2.Source = bmi_Star_empty;
                        img_star_item5_rf3.Source = bmi_Star_empty;
                        img_star_item5_rf4.Source = bmi_Star_empty;
                        img_star_item5_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf3_temp = 2;
                        img_star_item5_rf3.Source = bmi_Star_empty;
                        img_star_item5_rf4.Source = bmi_Star_empty;
                        img_star_item5_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf3_temp = 3;
                        img_star_item5_rf4.Source = bmi_Star_empty;
                        img_star_item5_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf3_temp = 4;
                        img_star_item5_rf5.Source = bmi_Star_empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                img_item5.Opacity = 1;
                Level_variable.equip3_temp = true;
                Level_variable.rf3_temp = 5;
                img_star_item5_rf1.Source = bmi_Star;
                img_star_item5_rf2.Source = bmi_Star;
                img_star_item5_rf3.Source = bmi_Star;
                img_star_item5_rf4.Source = bmi_Star;
                img_star_item5_rf5.Source = bmi_Star;
                img_star_item5_rf1.Opacity = 1.0;
                img_star_item5_rf5.Opacity = 1.0;
                img_star_item5_rf4.Opacity = 1.0;
                img_star_item5_rf3.Opacity = 1.0;
                img_star_item5_rf2.Opacity = 1.0;
            }


        }
        private void bt_item6_set_Click(object sender, RoutedEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            if (Level_variable.equip1_temp == true)
            {
                switch (Level_variable.rf1_temp)
                {
                    case 0:
                        img_item6.Opacity = 0.25;
                        Level_variable.equip1_temp = false;
                        Level_variable.rf1_temp = -1;
                        img_star_item6_rf1.Source = bmi_Star_empty;
                        img_star_item6_rf2.Source = bmi_Star_empty;
                        img_star_item6_rf3.Source = bmi_Star_empty;
                        img_star_item6_rf4.Source = bmi_Star_empty;
                        img_star_item6_rf5.Source = bmi_Star_empty;
                        img_star_item6_rf1.Opacity = 0.0;
                        img_star_item6_rf5.Opacity = 0.0;
                        img_star_item6_rf4.Opacity = 0.0;
                        img_star_item6_rf3.Opacity = 0.0;
                        img_star_item6_rf2.Opacity = 0.0;
                        break;
                    case 1:
                        Level_variable.rf1_temp = 0;
                        img_star_item6_rf1.Source = bmi_Star_empty;
                        img_star_item6_rf2.Source = bmi_Star_empty;
                        img_star_item6_rf3.Source = bmi_Star_empty;
                        img_star_item6_rf4.Source = bmi_Star_empty;
                        img_star_item6_rf5.Source = bmi_Star_empty;

                        break;
                    case 2:

                        Level_variable.rf1_temp = 1;
                        img_star_item6_rf2.Source = bmi_Star_empty;
                        img_star_item6_rf3.Source = bmi_Star_empty;
                        img_star_item6_rf4.Source = bmi_Star_empty;
                        img_star_item6_rf5.Source = bmi_Star_empty;
                        break;
                    case 3:
                        Level_variable.rf1_temp = 2;
                        img_star_item6_rf3.Source = bmi_Star_empty;
                        img_star_item6_rf4.Source = bmi_Star_empty;
                        img_star_item6_rf5.Source = bmi_Star_empty;

                        break;
                    case 4:
                        Level_variable.rf1_temp = 3;
                        img_star_item6_rf4.Source = bmi_Star_empty;
                        img_star_item6_rf5.Source = bmi_Star_empty;

                        break;
                    case 5:
                        Level_variable.rf1_temp = 4;
                        img_star_item6_rf5.Source = bmi_Star_empty;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                img_item6.Opacity = 1;
                Level_variable.equip1_temp = true;
                Level_variable.rf1_temp = 5;
                img_star_item6_rf1.Opacity = 1.0;
                img_star_item6_rf5.Opacity = 1.0;
                img_star_item6_rf4.Opacity = 1.0;
                img_star_item6_rf3.Opacity = 1.0;
                img_star_item6_rf2.Opacity = 1.0;
                img_star_item6_rf1.Source = bmi_Star;
                img_star_item6_rf2.Source = bmi_Star;
                img_star_item6_rf3.Source = bmi_Star;
                img_star_item6_rf4.Source = bmi_Star;
                img_star_item6_rf5.Source = bmi_Star;
            }


        }

        private void bt_item1_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip4_temp == true)
            {
                img_item1.Opacity = 0.25;
                Level_variable.equip4_temp = false;
                Level_variable.rf4_temp = -1;
                img_star_item1_rf1.Source = bmi_Star_empty;
                img_star_item1_rf2.Source = bmi_Star_empty;
                img_star_item1_rf3.Source = bmi_Star_empty;
                img_star_item1_rf4.Source = bmi_Star_empty;
                img_star_item1_rf5.Source = bmi_Star_empty;
                img_star_item1_rf1.Opacity = 0.0;
                img_star_item1_rf5.Opacity = 0.0;
                img_star_item1_rf4.Opacity = 0.0;
                img_star_item1_rf3.Opacity = 0.0;
                img_star_item1_rf2.Opacity = 0.0;
            }
            else
            {

            }
        }
        private void bt_item2_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip2_temp == true)
            {
                img_item2.Opacity = 0.25;
                Level_variable.equip2_temp = false;
                Level_variable.rf2_temp = -1;
                img_star_item2_rf1.Source = bmi_Star_empty;
                img_star_item2_rf2.Source = bmi_Star_empty;
                img_star_item2_rf3.Source = bmi_Star_empty;
                img_star_item2_rf4.Source = bmi_Star_empty;
                img_star_item2_rf5.Source = bmi_Star_empty;
                img_star_item2_rf1.Opacity = 0.0;
                img_star_item2_rf5.Opacity = 0.0;
                img_star_item2_rf4.Opacity = 0.0;
                img_star_item2_rf3.Opacity = 0.0;
                img_star_item2_rf2.Opacity = 0.0;
            }
            else
            {

            }
        }
        private void bt_item3_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip6_temp == true)
            {
                img_item3.Opacity = 0.25;
                Level_variable.equip6_temp = false;
                Level_variable.rf6_temp = -1;
                img_star_item3_rf1.Source = bmi_Star_empty;
                img_star_item3_rf2.Source = bmi_Star_empty;
                img_star_item3_rf3.Source = bmi_Star_empty;
                img_star_item3_rf4.Source = bmi_Star_empty;
                img_star_item3_rf5.Source = bmi_Star_empty;
                img_star_item3_rf1.Opacity = 0.0;
                img_star_item3_rf5.Opacity = 0.0;
                img_star_item3_rf4.Opacity = 0.0;
                img_star_item3_rf3.Opacity = 0.0;
                img_star_item3_rf2.Opacity = 0.0;
            }
        }
        private void bt_item4_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip5_temp == true)
            {
                img_item4.Opacity = 0.25;
                Level_variable.equip5_temp = false;
                Level_variable.rf5_temp = -1;
                img_star_item4_rf1.Source = bmi_Star_empty;
                img_star_item4_rf2.Source = bmi_Star_empty;
                img_star_item4_rf3.Source = bmi_Star_empty;
                img_star_item4_rf4.Source = bmi_Star_empty;
                img_star_item4_rf5.Source = bmi_Star_empty;
                img_star_item4_rf1.Opacity = 0.0;
                img_star_item4_rf5.Opacity = 0.0;
                img_star_item4_rf4.Opacity = 0.0;
                img_star_item4_rf3.Opacity = 0.0;
                img_star_item4_rf2.Opacity = 0.0;
            }
        }
        private void bt_item5_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip3_temp == true)
            {
                img_item5.Opacity = 0.25;
                Level_variable.equip3_temp = false;
                Level_variable.rf3_temp = -1;
                img_star_item5_rf1.Source = bmi_Star_empty;
                img_star_item5_rf2.Source = bmi_Star_empty;
                img_star_item5_rf3.Source = bmi_Star_empty;
                img_star_item5_rf4.Source = bmi_Star_empty;
                img_star_item5_rf5.Source = bmi_Star_empty;
                img_star_item5_rf1.Opacity = 0.0;
                img_star_item5_rf5.Opacity = 0.0;
                img_star_item5_rf4.Opacity = 0.0;
                img_star_item5_rf3.Opacity = 0.0;
                img_star_item5_rf2.Opacity = 0.0;
            }
        }
        private void bt_item6_set_ClickR(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            if (Level_variable.equip1_temp == true)
            {
                img_item6.Opacity = 0.25;
                Level_variable.equip1_temp = false;
                Level_variable.rf1_temp = -1;
                img_star_item6_rf1.Source = bmi_Star_empty;
                img_star_item6_rf2.Source = bmi_Star_empty;
                img_star_item6_rf3.Source = bmi_Star_empty;
                img_star_item6_rf4.Source = bmi_Star_empty;
                img_star_item6_rf5.Source = bmi_Star_empty;
                img_star_item6_rf1.Opacity = 0.0;
                img_star_item6_rf5.Opacity = 0.0;
                img_star_item6_rf4.Opacity = 0.0;
                img_star_item6_rf3.Opacity = 0.0;
                img_star_item6_rf2.Opacity = 0.0;
            }
        }

        #endregion
        //의유이까지
        private void InitializeSet()
        {
            #region SelectedCharaString
            if (rima == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rima";
                Chara_Selected_KR = "리마";
            }
            else if (miyako == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "miyako";
                Chara_Selected_KR = "미야코";
            }
            else if (kuuka == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kuuka";
                Chara_Selected_KR = "쿠우카";
            }
            else if (zyun == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "zyun";
                Chara_Selected_KR = "쥰";
            }
            else if (kuuka_ooedo == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kuuka_ooedo";
                Chara_Selected_KR = "오우카";
            }
            else if (kaori == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kaori";
                Chara_Selected_KR = "카오리";
            }
            else if (rei_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rei_newyear";
                Chara_Selected_KR = "신레이";
            }
            else if (pekorinnu == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "pekorinnu";
                Chara_Selected_KR = "페코린느";
            }
            else if (pekorinnu_princess == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "pekorinnu_princess";
                Chara_Selected_KR = "프페코";
            }
            else if (ruka == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ruka";
                Chara_Selected_KR = "루카";
            }
            else if (kotkoro_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kotkoro_newyear";
                Chara_Selected_KR = "뉴코로";
            }
            else if (rima == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rima";
                Chara_Selected_KR = "리마";
            }
            else if (nozomi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "nozomi";
                Chara_Selected_KR = "노조미";
            }
            else if (inori == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "inori";
                Chara_Selected_KR = "이노리";
            }
            else if (muimi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "muimi";
                Chara_Selected_KR = "무이미";
            }
            else if (makoto == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "makoto";
                Chara_Selected_KR = "마코토";
            }
            else if (kaya == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kaya";
                Chara_Selected_KR = "카야";
            }
            else if (hiyori_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "hiyori_newyear";
                Chara_Selected_KR = "뉴요리";
            }
            else if (ninon_ooedo == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ninon_ooedo";
                Chara_Selected_KR = "오니논";
            }
            else if (akino == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "akino";
                Chara_Selected_KR = "아키노";
            }
            else if (makoto_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "makoto_summer";
                Chara_Selected_KR = "수코토";
            }
            else if (matsuri == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "matsuri";
                Chara_Selected_KR = "마츠리";
            }
            else if (chloe == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "chloe";
                Chara_Selected_KR = "클로에";
            }
            else if (chieru == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "chieru";
                Chara_Selected_KR = "치에루";
            }
            else if (eriko_valentine == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "eriko_valentine";
                Chara_Selected_KR = "발리코";
            }
            else if (ayane_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ayane_christmas";
                Chara_Selected_KR = "성야네";
            }
            else if (tsumugi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tsumugi";
                Chara_Selected_KR = "츠무기";
            }
            else if (hiyori == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "hiyori";
                Chara_Selected_KR = "히요리";
            }
            else if (misogi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misogi";
                Chara_Selected_KR = "미소기";
            }
            else if (ayane == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ayane";
                Chara_Selected_KR = "아야네";
            }
            else if (misogi_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misogi_halloween";
                Chara_Selected_KR = "할소기";
            }
            else if (misaki_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misaki_halloween";
                Chara_Selected_KR = "할사키";
            }
            else if (tamaki == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tamaki";
                Chara_Selected_KR = "타마키";
            }
            else if (tomo == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tomo";
                Chara_Selected_KR = "토모";
            }
            else if (tamaki_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tamaki_summer";
                Chara_Selected_KR = "수마키";
            }
            else if (eriko == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "eriko";
                Chara_Selected_KR = "에리코";
            }
            else if (pekorinnu_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "pekorinnu_summer";
                Chara_Selected_KR = "수페코";
            }
            else if (kurumi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kurumi";
                Chara_Selected_KR = "쿠루미";
            }
            else if (zita == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "zita";
                Chara_Selected_KR = "지타";
            }
            else if (rei == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rei";
                Chara_Selected_KR = "레이";
            }
            else if (iriya_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "iriya_christmas";
                Chara_Selected_KR = "성리야";
            }
            else if (kristina_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kristina_christmas";
                Chara_Selected_KR = "성리스";
            }
            else if (sizuru == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "sizuru";
                Chara_Selected_KR = "시즈루";
            }
            else if (kristina == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kristina";
                Chara_Selected_KR = "크리스티나";
            }
            else if (kurumi_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kurumi_christmas";
                Chara_Selected_KR = "성루미";
            }
            else if (mimi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mimi";
                Chara_Selected_KR = "미미";
            }
            else if (sinobu == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "sinobu";
                Chara_Selected_KR = "시노부";
            }
            else if (sizuru_valentine == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "sizuru_valentine";
                Chara_Selected_KR = "발즈루";
            }
            else if (mahiru == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mahiru";
                Chara_Selected_KR = "마히루";
            }
            else if (yukari == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yukari";
                Chara_Selected_KR = "유카리";
            }
            else if (monika == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "monika";
                Chara_Selected_KR = "모니카";
            }
            else if (ninon == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ninon";
                Chara_Selected_KR = "니논";
            }
            else if (nozomi_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "nozomi_christmas";
                Chara_Selected_KR = "성조미";
            }
            else if (mihuyu == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mihuyu";
                Chara_Selected_KR = "미후유";
            }
            else if (iriya == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "iriya";
                Chara_Selected_KR = "이리야";
            }
            else if (kaori_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kaori_summer";
                Chara_Selected_KR = "수오리";
            }
            else if (saren == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "saren";
                Chara_Selected_KR = "사렌";
            }
            else if (anna == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "anna";
                Chara_Selected_KR = "안나";
            }
            else if (sinobu_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "sinobu_halloween";
                Chara_Selected_KR = "할노부";
            }
            else if (mihuyu_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mihuyu_summer";
                Chara_Selected_KR = "수후유";
            }
            else if (kotkoro == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kotkoro";
                Chara_Selected_KR = "콧코로";
            }
            else if (ayumi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ayumi";
                Chara_Selected_KR = "아유미";
            }
            else if (grea == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "grea";
                Chara_Selected_KR = "글레어";
            }
            else if (kotkoro_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kotkoro_summer";
                Chara_Selected_KR = "수코로";
            }
            else if (rem == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rem";
                Chara_Selected_KR = "렘";
            }
            else if (ram == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ram";
                Chara_Selected_KR = "람";
            }
            else if (rin == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rin";
                Chara_Selected_KR = "린";
            }
            else if (mitsuki == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mitsuki";
                Chara_Selected_KR = "미츠키";
            }
            else if (akari == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "akari";
                Chara_Selected_KR = "아카리";
            }
            else if (yori == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yori";
                Chara_Selected_KR = "요리";
            }
            else if (saren_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "saren_summer";
                Chara_Selected_KR = "수사렌";
            }
            else if (miyako_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "miyako_halloween";
                Chara_Selected_KR = "할푸딩";
            }
            else if (arisa == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "arisa";
                Chara_Selected_KR = "아리사";
            }
            else if (mimi_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mimi_halloween";
                Chara_Selected_KR = "할미미";
            }
            else if (anne == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "anne";
                Chara_Selected_KR = "앤";
            }
            else if (lou == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "lou";
                Chara_Selected_KR = "루";
            }
            else if (neneka == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "neneka";
                Chara_Selected_KR = "네네카";
            }
            else if (aoi_nakayosi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "aoi_nakayosi";
                Chara_Selected_KR = "편오이";
            }
            else if (kyaru_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kyaru_newyear";
                Chara_Selected_KR = "냐루";
            }
            else if (rino == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rino";
                Chara_Selected_KR = "리노";
            }
            else if (suzuna == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "suzuna";
                Chara_Selected_KR = "스즈나";
            }
            else if (suzuna_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "suzuna_summer";
                Chara_Selected_KR = "수즈나";
            }
            else if (siori == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "siori";
                Chara_Selected_KR = "시오리";
            }
            else if (siori_magical == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "siori_magical";
                Chara_Selected_KR = "마오리";
            }
            else if (io == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "io";
                Chara_Selected_KR = "이오";
            }
            else if (io_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "io_summer";
                Chara_Selected_KR = "수이오";
            }
            else if (suzume == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "suzume";
                Chara_Selected_KR = "스즈메";
            }
            else if (suzume_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "suzume_newyear";
                Chara_Selected_KR = "뉴즈메";
            }
            else if (emilia == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "emilia";
                Chara_Selected_KR = "에밀리아";
            }
            else if (kasumi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kasumi";
                Chara_Selected_KR = "카스미";
            }
            else if (kasumi_magical == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kasumi_magical";
                Chara_Selected_KR = "마스미";
            }
            else if (misato == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misato";
                Chara_Selected_KR = "미사토";
            }
            else if (nanaka == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "nanaka";
                Chara_Selected_KR = "나나카";
            }
            else if (yui_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yui_newyear";
                Chara_Selected_KR = "뉴이";
            }
            else if (kyaru == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kyaru";
                Chara_Selected_KR = "캬루";
            }
            else if (hatsune == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "hatsune";
                Chara_Selected_KR = "하츠네";
            }
            else if (misaki == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misaki";
                Chara_Selected_KR = "미사키";
            }
            else if (runa == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "runa";
                Chara_Selected_KR = "루나";
            }
            else if (chika_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "chika_christmas";
                Chara_Selected_KR = "성치카";
            }
            else if (suzume_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "suzume_summer";
                Chara_Selected_KR = "수즈메";
            }
            else if (kyaru_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kyaru_summer";
                Chara_Selected_KR = "수캬루";
            }
            else if (aoi == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "aoi";
                Chara_Selected_KR = "아오이";
            }
            else if (chika == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "chika";
                Chara_Selected_KR = "치카";
            }
            else if (maho_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "maho_summer";
                Chara_Selected_KR = "수마호";
            }
            else if (maho == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "maho";
                Chara_Selected_KR = "마호";
            }
            else if (yui == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yui";
                Chara_Selected_KR = "유이";
            }
            else if (yuki == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yuki";
                Chara_Selected_KR = "유키";
            }
            else if (kyouka == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kyouka";
                Chara_Selected_KR = "쿄우카";
            }
            else if (misaki == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misaki";
                Chara_Selected_KR = "미사키";
            }
            else if (kyouka_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kyouka_halloween";
                Chara_Selected_KR = "할쿄카";
            }
            else if (uzuki_deremas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "uzuki_deremas";
                Chara_Selected_KR = "우즈키";
            }
            else if (mio_deremas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mio_deremas";
                Chara_Selected_KR = "미오";
            }
            else if (rin_deremas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rin_deremas";
                Chara_Selected_KR = "시부린";
            }
            else if (rin_ranger == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rin_ranger";
                Chara_Selected_KR = "레린";
            }
            else if (mahiru_ranger == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "mahiru_ranger";
                Chara_Selected_KR = "레히루";
            }
            else if (rino_wonder == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rino_wonder";
                Chara_Selected_KR = "앨리노";
            }
            else if (ayumi_wonder == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ayumi_wonder";
                Chara_Selected_KR = "앨유미";
            }
            else if (ruka_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "ruka_summer";
                Chara_Selected_KR = "수루카";
            }
            else if (nanaka_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "nanaka_summer";
                Chara_Selected_KR = "수나카";
            }
            else if (anna_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "anna_summer";
                Chara_Selected_KR = "수안나";
            }
            else if (zyun_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "zyun_summer";
                Chara_Selected_KR = "수쥰";
            }
            else if (hatsune_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "hatsune_summer";
                Chara_Selected_KR = "수츠네";
            }
            else if (misato_summer == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "misato_summer";
                Chara_Selected_KR = "수사토";
            }
            else if (akari_angel == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "akari_angel";
                Chara_Selected_KR = "엔카리";
            }
            else if (yori_angel == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yori_angel";
                Chara_Selected_KR = "엔요리";
            }
            else if (yui_princess == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yui_princess";
                Chara_Selected_KR = "프유이";
            }
            else if (kotkoro_princess == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kotkoro_princess";
                Chara_Selected_KR = "프코로";
            }
            else if (yuni == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yuni";
                Chara_Selected_KR = "유니";
            }
            else if (labyrista == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "labyrista";
                Chara_Selected_KR = "라비리스타";
            }
            else if (tsumugi_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tsumugi_halloween";
                Chara_Selected_KR = "할무기";
            }
            else if (matsuri_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "matsuri_halloween";
                Chara_Selected_KR = "할츠리";
            }
            else if (rei_halloween == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "rei_halloween";
                Chara_Selected_KR = "할레이";
            }
            else if (monika_magical == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "monika_magical";
                Chara_Selected_KR = "마니카";
            }
            else if (tomo_magical == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "tomo_magical";
                Chara_Selected_KR = "마토모";
            }
            else if (akino_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "akino_christmas";
                Chara_Selected_KR = "성키노";
            }
            else if (saren_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "saren_christmas";
                Chara_Selected_KR = "성사렌";
            }
            else if (yukari_christmas == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yukari_christmas";
                Chara_Selected_KR = "성카리";
            }
            else if (pekorinnu_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "pekorinnu_newyear";
                Chara_Selected_KR = "뉴페코";
            }
            else if (neneka_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "neneka_newyear";
                Chara_Selected_KR = "뉴네카";
            }
            else if (muimi_newyear == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "muimi_newyear";
                Chara_Selected_KR = "뉴이미";
            }
            else if (kotkoro_maiden == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "kotkoro_maiden";
                Chara_Selected_KR = "의코로";
            }
            else if (yui_maiden == true)
            {
                cb_enable_set.IsChecked = true;
                Chara_Selected_EN = "yui_maiden";
                Chara_Selected_KR = "의유이";
            }
            else
            {
                MessageBox.Show("오잉", "알림");
            }
            #endregion
            LoadOffCharaSetting(Chara_Selected_KR, Chara_Selected_EN);
        }

        private void False_All()
        {
            hiyori = false; yui = false; rei = false; misogi = false; matsuri = false; akari = false; miyako = false; yuki = false; anna = false; maho = false;
            rino = false; hatsune = false; nanaka = false; kasumi = false; misato = false; suzuna = false; kaori = false; io = false; mimi = false; kurumi = false;
            yori = false; ayane = false; suzume = false; rin = false; eriko = false; saren = false; nozomi = false; ninon = false; sinobu = false; akino = false;
            mahiru = false; yukari = false; kyouka = false; tomo = false; siori = false; aoi = false; chika = false; makoto = false; iriya = false; kuuka = false;
            tamaki = false; zyun = false; mihuyu = false; sizuru = false; misaki = false; mitsuki = false; rima = false; monika = false; tsumugi = false; ayumi = false;
            ruka = false; zita = false; pekorinnu = false; kotkoro = false; kyaru = false; muimi = false; arisa = false; kaya = false; inori = false; labyrista = false;
            neneka = false; kristina = false; pekorinnu_summer = false; kotkoro_summer = false; suzume_summer = false;
            kyaru_summer = false; tamaki_summer = false; mihuyu_summer = false; sinobu_halloween = false; miyako_halloween = false;
            misaki_halloween = false; chika_christmas = false; kurumi_christmas = false; ayane_christmas = false; hiyori_newyear = false;
            yui_newyear = false; rei_newyear = false; eriko_valentine = false; sizuru_valentine = false; anne = false;
            lou = false; grea = false; kuuka_ooedo = false; ninon_ooedo = false; rem = false;
            ram = false; emilia = false; suzuna_summer = false; io_summer = false; saren_summer = false;
            makoto_summer = false; kaori_summer = false; maho_summer = false; aoi_nakayosi = false; chloe = false;
            chieru = false; yuni = false; kyouka_halloween = false; misogi_halloween = false; mimi_halloween = false;
            runa = false; kristina_christmas = false; nozomi_christmas = false; iriya_christmas = false; kotkoro_newyear = false;
            kyaru_newyear = false; suzume_newyear = false; kasumi_magical = false; siori_magical = false; uzuki_deremas = false;
            rin_deremas = false; mio_deremas = false; rin_ranger = false; mahiru_ranger = false; rino_wonder = false;
            ayumi_wonder = false; ruka_summer = false; anna_summer = false; nanaka_summer = false; hatsune_summer = false;
            misato_summer = false; zyun_summer = false; akari_angel = false; yui_princess = false; pekorinnu_princess = false;
            kotkoro_princess = false;
             yori_angel= false; tsumugi_halloween= false; rei_halloween= false; matsuri_halloween = false;
          monika_magical= false; tomo_magical = false;
          shepi= false; hiyori_princess= false; kyaru_princess = false;
          akino_christmas= false; saren_christmas= false; yukari_christmas = false;
          muimi_newyear= false; neneka_newyear= false; pekorinnu_newyear = false;
          kotkoro_maiden= false; yui_maiden = false;
          kasumi_summer = false;
          rima_cinderella= false; makoto_cinderella= false; maho_cinderella = false;
          chloe_nakayosi2= false; chieru_nakayosi2= false; yuni_nakayosi2 = false;
          inori_timetravel= false; kaya_timetravel = false;
          aoi_worker= false; tamaki_worker= false; mihuyu_worker = false;
    }

        private void Initialize_item_unique(int ue_level)
        {
            tB_unique_level.Text = Convert.ToString(ue_level);
            if (ue_level > 0)
            {
                img_item_unique.Opacity = 1.0;
            }
            else
                img_item_unique.Opacity = 0.25;
        }
        private void Initialize_chara_star(int star)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_chara.png", UriKind.Absolute);
            var uriStar_down = new Uri("pack://application:,,,/res/star_chara_down.png", UriKind.Absolute);
            var uriStar_6 = new Uri("pack://application:,,,/res/star_chara_6.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_down = new BitmapImage(uriStar_down);
            BitmapImage bmi_Star_6 = new BitmapImage(uriStar_6);

            switch (star)
            {
                case 3:
                    img_star_chara6.Opacity = 0.0;
                    img_star_chara5.Source = bmi_Star_down;
                    img_star_chara4.Source = bmi_Star_down;
                    break;
                case 4:
                    img_star_chara6.Opacity = 0.0;
                    img_star_chara5.Source = bmi_Star_down;

                    break;
                case 5:
                    img_star_chara6.Opacity = 0.0;

                    break;
                case 6:
                    img_star_chara6.Opacity = 1.0;
                    img_star_chara5.Source = bmi_Star;
                    img_star_chara4.Source = bmi_Star;
                    break;

                default:
                    break;

            }
        }
        private void Initialize_chara_level(int level)
        {
            tB_chara_level.Text = Convert.ToString(level);
        }


        private void bt_chara_save_autoRein_unique_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_chara_save_autoRein_item_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_chara_save_autoRein_Level_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cB_set_rank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unit_equip Ue = new Unit_equip();
            string uriString = "pack://application:,,,/res/icon_equipment/";
            string[] uriStringSpecific = new string[6];
            string[] ItemSet = new string[6];

            //랭크 설정 성카리까지
            try
            {
                //11랭크부터
                if (cB_set_rank.SelectedIndex == 0)
                {
                    Level_variable.Rank_temp = 11;
                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_11[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //12랭크
                else if (cB_set_rank.SelectedIndex == 1)
                {
                    Level_variable.Rank_temp = 12; 
                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_12[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //13랭크
                else if (cB_set_rank.SelectedIndex == 2)
                {
                    Level_variable.Rank_temp = 13;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        ItemSet[i] = Convert.ToString(Ue.yui_princess_13[i]);
                        uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_13[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //
                //14랭크            
                //
                else if (cB_set_rank.SelectedIndex == 3)
                {
                    Level_variable.Rank_temp = 14;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_14[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //
                //15랭크
                //
                else if (cB_set_rank.SelectedIndex == 4)
                {
                    Level_variable.Rank_temp = 15;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_15[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //
                //16랭크
                //
                else if (cB_set_rank.SelectedIndex == 5)
                {
                    Level_variable.Rank_temp = 16;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_16[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //
                //17랭크
                //
                else if (cB_set_rank.SelectedIndex == 6)
                {
                    Level_variable.Rank_temp = 17;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_17[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //
                //18랭크
                //
                else if (cB_set_rank.SelectedIndex == 7)
                {
                    Level_variable.Rank_temp = 18;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_18[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //19랭
                else if (cB_set_rank.SelectedIndex == 8) 
                {
                    Level_variable.Rank_temp = 19;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }

                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_19[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //20랭
                else if (cB_set_rank.SelectedIndex == 9) 
                {
                    Level_variable.Rank_temp = 20;

                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //21랭
                else if (cB_set_rank.SelectedIndex == 10)
                {
                    Level_variable.Rank_temp = 21;
                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_21[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                //22랭
                else if (cB_set_rank.SelectedIndex == 11)
                {
                    Level_variable.Rank_temp = 22;
                    if (hiyori_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_princess_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (neneka_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.neneka_newyear_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_newyear_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_newyear_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_christmas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_christmas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_christmas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_magical_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_magical_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yori_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yori_angel_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (labyrista == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.labyrista_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_princess_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (inori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.inori_20[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kotkoro_princess == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kotkoro_princess_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rima == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rima_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hiyori == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hiyori_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yui == true || kuuka_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yui_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misogi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misogi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (matsuri == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.matsuri_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜탱
                    if (akari == true || kasumi == true || kasumi_magical == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako == true || kotkoro_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuki_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜1
                    if (anna == true || yori == true || kyouka == true || iriya == true || misaki == true || kyaru == true || neneka == true || kyaru_summer == true ||
                        anne == true || lou == true || grea == true || maho_summer == true || runa == true || iriya_christmas == true || kyaru_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러1
                    if (maho == true || chika || suzume_summer || chika_christmas || yui_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.maho_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //활쟁이
                    if (rino == true || suzuna || siori || arisa || suzuna_summer || aoi_nakayosi || siori_magical)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //마딜2 15랭마딜
                    if (hatsune == true || nanaka || emilia)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //힐러2
                    if (misato == true || suzume_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    //5성권캐
                    if (kaori == true || kaya || hiyori_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (suzume == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.suzume_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin == true || kotkoro || kotkoro_newyear)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (eriko == true || eriko_valentine)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.eriko_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren == true || mitsuki)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nozomi == true || nozomi_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nozomi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akino == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akino_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yukari == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yukari_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (makoto == true || makoto_summer)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.makoto_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kuuka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kuuka_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zyun == true || sizuru)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zyun_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (monika == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.monika_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tsumugi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tsumugi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (zita == true || kristina || kristina_christmas)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.zita_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu == true || pekorinnu_princess)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (muimi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.muimi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (pekorinnu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.pekorinnu_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tamaki_summer == true || chloe)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tamaki_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (tomo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.tomo_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (chieru == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.chieru_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mihuyu_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mihuyu_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (aoi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.aoi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sinobu_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sinobu_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (miyako_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.miyako_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misaki_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misaki_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kurumi_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kurumi_christmas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayane_christmas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayane_christmas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (sizuru_valentine == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.sizuru_valentine_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rei_newyear == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rei_newyear_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ninon_ooedo == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ninon_ooedo_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rem == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rem_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ram == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ram_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (io_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.io_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (saren_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.saren_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kaori_summer == true || misogi_halloween)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kaori_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (kyouka_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.kyouka_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mimi_halloween == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mimi_halloween_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (uzuki_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.uzuki_deremas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mio_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mio_deremas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_deremas == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_deremas_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rin_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rin_ranger_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (mahiru_ranger == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.mahiru_ranger_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (rino_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.rino_wonder_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi_wonder == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_wonder_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ayumi == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ayumi_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (ruka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.ruka_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (anna_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.anna_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (nanaka_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.nanaka_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (hatsune_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.hatsune_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (misato_summer == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.misato_summer_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (akari_angel == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.akari_angel_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                    if (yuni == true)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            ItemSet[i] = Convert.ToString(Ue.yuni_22[i]);
                            uriStringSpecific[i] = uriString + ItemSet[i] + ".png";
                        }
                    }
                }
                var uriSource1 = new Uri(uriStringSpecific[0], UriKind.Absolute);
                BitmapImage bmi1 = new BitmapImage(uriSource1);
                var uriSource2 = new Uri(uriStringSpecific[1], UriKind.Absolute);
                BitmapImage bmi2 = new BitmapImage(uriSource2);
                var uriSource3 = new Uri(uriStringSpecific[2], UriKind.Absolute);
                BitmapImage bmi3 = new BitmapImage(uriSource3);
                var uriSource4 = new Uri(uriStringSpecific[3], UriKind.Absolute);
                BitmapImage bmi4 = new BitmapImage(uriSource4);
                var uriSource5 = new Uri(uriStringSpecific[4], UriKind.Absolute);
                BitmapImage bmi5 = new BitmapImage(uriSource5);
                var uriSource6 = new Uri(uriStringSpecific[5], UriKind.Absolute);
                BitmapImage bmi6 = new BitmapImage(uriSource6);
                img_item1.Source = bmi2;
                img_item2.Source = bmi4;
                img_item3.Source = bmi6;
                img_item4.Source = bmi5;
                img_item5.Source = bmi3;
                img_item6.Source = bmi1;
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.Message);
            }
        }

        #region Item_sTar
        private void Initialize_item1_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);
            switch (rf)
            {
                case 0:
                    img_star_item1_rf5.Source = bmi_Star_empty;
                    img_star_item1_rf4.Source = bmi_Star_empty;
                    img_star_item1_rf3.Source = bmi_Star_empty;
                    img_star_item1_rf2.Source = bmi_Star_empty;
                    img_star_item1_rf1.Source = bmi_Star_empty;
                    break;
                case 1:
                    img_star_item1_rf5.Source = bmi_Star_empty;
                    img_star_item1_rf4.Source = bmi_Star_empty;
                    img_star_item1_rf3.Source = bmi_Star_empty;
                    img_star_item1_rf2.Source = bmi_Star_empty;
                    img_star_item1_rf1.Source = bmi_Star;
                    break;
                case 2:
                    img_star_item1_rf5.Source = bmi_Star_empty;
                    img_star_item1_rf4.Source = bmi_Star_empty;
                    img_star_item1_rf3.Source = bmi_Star_empty;
                    img_star_item1_rf2.Source = bmi_Star;
                    img_star_item1_rf1.Source = bmi_Star;
                    break;
                case 3:
                    img_star_item1_rf5.Source = bmi_Star_empty;
                    img_star_item1_rf4.Source = bmi_Star_empty;
                    img_star_item1_rf3.Source = bmi_Star;
                    img_star_item1_rf2.Source = bmi_Star;
                    img_star_item1_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item1_rf5.Source = bmi_Star_empty;
                    img_star_item1_rf4.Source = bmi_Star;
                    img_star_item1_rf3.Source = bmi_Star;
                    img_star_item1_rf2.Source = bmi_Star;
                    img_star_item1_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item1_rf5.Source = bmi_Star;
                    img_star_item1_rf4.Source = bmi_Star;
                    img_star_item1_rf3.Source = bmi_Star;
                    img_star_item1_rf2.Source = bmi_Star;
                    img_star_item1_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item1_rf5.Opacity = 0.0;
                    img_star_item1_rf4.Opacity = 0.0;
                    img_star_item1_rf3.Opacity = 0.0;
                    img_star_item1_rf2.Opacity = 0.0;
                    img_star_item1_rf1.Opacity = 0.0;
                    img_item1.Opacity = 0.25;
                    break;
            }
        }
        private void Initialize_item2_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            switch (rf)
            {
                case 0:
                    img_star_item2_rf5.Source = bmi_Star_empty;
                    img_star_item2_rf4.Source = bmi_Star_empty;
                    img_star_item2_rf3.Source = bmi_Star_empty;
                    img_star_item2_rf2.Source = bmi_Star_empty;
                    img_star_item2_rf1.Source = bmi_Star_empty;
                    break;
                case 1:

                    img_star_item2_rf5.Source = bmi_Star_empty;
                    img_star_item2_rf4.Source = bmi_Star_empty;
                    img_star_item2_rf3.Source = bmi_Star_empty;
                    img_star_item2_rf2.Source = bmi_Star_empty;
                    img_star_item2_rf1.Source = bmi_Star;

                    break;
                case 2:
                    img_star_item2_rf5.Source = bmi_Star_empty;
                    img_star_item2_rf4.Source = bmi_Star_empty;
                    img_star_item2_rf3.Source = bmi_Star_empty;
                    img_star_item2_rf2.Source = bmi_Star;
                    img_star_item2_rf1.Source = bmi_Star;

                    break;
                case 3:

                    img_star_item2_rf5.Source = bmi_Star_empty;
                    img_star_item2_rf4.Source = bmi_Star_empty;
                    img_star_item2_rf3.Source = bmi_Star;
                    img_star_item2_rf2.Source = bmi_Star;
                    img_star_item2_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item2_rf5.Source = bmi_Star_empty;
                    img_star_item2_rf4.Source = bmi_Star;
                    img_star_item2_rf3.Source = bmi_Star;
                    img_star_item2_rf2.Source = bmi_Star;
                    img_star_item2_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item2_rf5.Source = bmi_Star;
                    img_star_item2_rf4.Source = bmi_Star;
                    img_star_item2_rf3.Source = bmi_Star;
                    img_star_item2_rf2.Source = bmi_Star;
                    img_star_item2_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item2_rf5.Opacity = 0.0;
                    img_star_item2_rf4.Opacity = 0.0;
                    img_star_item2_rf3.Opacity = 0.0;
                    img_star_item2_rf2.Opacity = 0.0;
                    img_star_item2_rf1.Opacity = 0.0;
                    img_item2.Opacity = 0.25;
                    break;
            }

        }

        private void Initialize_item3_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            switch (rf)
            {
                case 0:
                    img_star_item3_rf5.Source = bmi_Star_empty;
                    img_star_item3_rf4.Source = bmi_Star_empty;
                    img_star_item3_rf3.Source = bmi_Star_empty;
                    img_star_item3_rf2.Source = bmi_Star_empty;
                    img_star_item3_rf1.Source = bmi_Star_empty;
                    break;
                case 1:

                    img_star_item3_rf5.Source = bmi_Star_empty;
                    img_star_item3_rf4.Source = bmi_Star_empty;
                    img_star_item3_rf3.Source = bmi_Star_empty;
                    img_star_item3_rf2.Source = bmi_Star_empty;
                    img_star_item3_rf1.Source = bmi_Star;

                    break;
                case 2:
                    img_star_item3_rf5.Source = bmi_Star_empty;
                    img_star_item3_rf4.Source = bmi_Star_empty;
                    img_star_item3_rf3.Source = bmi_Star_empty;
                    img_star_item3_rf2.Source = bmi_Star;
                    img_star_item3_rf1.Source = bmi_Star;

                    break;
                case 3:

                    img_star_item3_rf5.Source = bmi_Star_empty;
                    img_star_item3_rf4.Source = bmi_Star_empty;
                    img_star_item3_rf3.Source = bmi_Star;
                    img_star_item3_rf2.Source = bmi_Star;
                    img_star_item3_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item3_rf5.Source = bmi_Star_empty;
                    img_star_item3_rf4.Source = bmi_Star;
                    img_star_item3_rf3.Source = bmi_Star;
                    img_star_item3_rf2.Source = bmi_Star;
                    img_star_item3_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item3_rf5.Source = bmi_Star;
                    img_star_item3_rf4.Source = bmi_Star;
                    img_star_item3_rf3.Source = bmi_Star;
                    img_star_item3_rf2.Source = bmi_Star;
                    img_star_item3_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item3_rf5.Opacity = 0.0;
                    img_star_item3_rf4.Opacity = 0.0;
                    img_star_item3_rf3.Opacity = 0.0;
                    img_star_item3_rf2.Opacity = 0.0;
                    img_star_item3_rf1.Opacity = 0.0;
                    img_item3.Opacity = 0.25;
                    break;
            }

        }

        private void Initialize_item4_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            switch (rf)
            {
                case 0:
                    img_star_item4_rf5.Source = bmi_Star_empty;
                    img_star_item4_rf4.Source = bmi_Star_empty;
                    img_star_item4_rf3.Source = bmi_Star_empty;
                    img_star_item4_rf2.Source = bmi_Star_empty;
                    img_star_item4_rf1.Source = bmi_Star_empty;
                    break;
                case 1:

                    img_star_item4_rf5.Source = bmi_Star_empty;
                    img_star_item4_rf4.Source = bmi_Star_empty;
                    img_star_item4_rf3.Source = bmi_Star_empty;
                    img_star_item4_rf2.Source = bmi_Star_empty;
                    img_star_item4_rf1.Source = bmi_Star;

                    break;
                case 2:
                    img_star_item4_rf5.Source = bmi_Star_empty;
                    img_star_item4_rf4.Source = bmi_Star_empty;
                    img_star_item4_rf3.Source = bmi_Star_empty;
                    img_star_item4_rf2.Source = bmi_Star;
                    img_star_item4_rf1.Source = bmi_Star;

                    break;
                case 3:

                    img_star_item4_rf5.Source = bmi_Star_empty;
                    img_star_item4_rf4.Source = bmi_Star_empty;
                    img_star_item4_rf3.Source = bmi_Star;
                    img_star_item4_rf2.Source = bmi_Star;
                    img_star_item4_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item4_rf5.Source = bmi_Star_empty;
                    img_star_item4_rf4.Source = bmi_Star;
                    img_star_item4_rf3.Source = bmi_Star;
                    img_star_item4_rf2.Source = bmi_Star;
                    img_star_item4_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item4_rf5.Source = bmi_Star;
                    img_star_item4_rf4.Source = bmi_Star;
                    img_star_item4_rf3.Source = bmi_Star;
                    img_star_item4_rf2.Source = bmi_Star;
                    img_star_item4_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item4_rf5.Opacity = 0.0;
                    img_star_item4_rf4.Opacity = 0.0;
                    img_star_item4_rf3.Opacity = 0.0;
                    img_star_item4_rf2.Opacity = 0.0;
                    img_star_item4_rf1.Opacity = 0.0;
                    img_item4.Opacity = 0.25;
                    break;
            }

        }

        private void Initialize_item5_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            switch (rf)
            {
                case 0:
                    img_star_item5_rf5.Source = bmi_Star_empty;
                    img_star_item5_rf4.Source = bmi_Star_empty;
                    img_star_item5_rf3.Source = bmi_Star_empty;
                    img_star_item5_rf2.Source = bmi_Star_empty;
                    img_star_item5_rf1.Source = bmi_Star_empty;
                    break;
                case 1:

                    img_star_item5_rf5.Source = bmi_Star_empty;
                    img_star_item5_rf4.Source = bmi_Star_empty;
                    img_star_item5_rf3.Source = bmi_Star_empty;
                    img_star_item5_rf2.Source = bmi_Star_empty;
                    img_star_item5_rf1.Source = bmi_Star;

                    break;
                case 2:
                    img_star_item5_rf5.Source = bmi_Star_empty;
                    img_star_item5_rf4.Source = bmi_Star_empty;
                    img_star_item5_rf3.Source = bmi_Star_empty;
                    img_star_item5_rf2.Source = bmi_Star;
                    img_star_item5_rf1.Source = bmi_Star;

                    break;
                case 3:

                    img_star_item5_rf5.Source = bmi_Star_empty;
                    img_star_item5_rf4.Source = bmi_Star_empty;
                    img_star_item5_rf3.Source = bmi_Star;
                    img_star_item5_rf2.Source = bmi_Star;
                    img_star_item5_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item5_rf5.Source = bmi_Star_empty;
                    img_star_item5_rf4.Source = bmi_Star;
                    img_star_item5_rf3.Source = bmi_Star;
                    img_star_item5_rf2.Source = bmi_Star;
                    img_star_item5_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item5_rf5.Source = bmi_Star;
                    img_star_item5_rf4.Source = bmi_Star;
                    img_star_item5_rf3.Source = bmi_Star;
                    img_star_item5_rf2.Source = bmi_Star;
                    img_star_item5_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item5_rf5.Opacity = 0.0;
                    img_star_item5_rf4.Opacity = 0.0;
                    img_star_item5_rf3.Opacity = 0.0;
                    img_star_item5_rf2.Opacity = 0.0;
                    img_star_item5_rf1.Opacity = 0.0;
                    img_item5.Opacity = 0.25;
                    break;
            }

        }

        private void Initialize_item6_rf_star(int rf)
        {
            var uriStar = new Uri("pack://application:,,,/res/star_item.png", UriKind.Absolute);
            var uriStar_empty = new Uri("pack://application:,,,/res/star_item_empty.png", UriKind.Absolute);
            BitmapImage bmi_Star = new BitmapImage(uriStar);
            BitmapImage bmi_Star_empty = new BitmapImage(uriStar_empty);

            switch (rf)
            {
                case 0:
                    img_star_item6_rf5.Source = bmi_Star_empty;
                    img_star_item6_rf4.Source = bmi_Star_empty;
                    img_star_item6_rf3.Source = bmi_Star_empty;
                    img_star_item6_rf2.Source = bmi_Star_empty;
                    img_star_item6_rf1.Source = bmi_Star_empty;
                    break;
                case 1:
                    img_star_item6_rf5.Source = bmi_Star_empty;
                    img_star_item6_rf4.Source = bmi_Star_empty;
                    img_star_item6_rf3.Source = bmi_Star_empty;
                    img_star_item6_rf2.Source = bmi_Star_empty;
                    img_star_item6_rf1.Source = bmi_Star;
                    break;
                case 2:
                    img_star_item6_rf5.Source = bmi_Star_empty;
                    img_star_item6_rf4.Source = bmi_Star_empty;
                    img_star_item6_rf3.Source = bmi_Star_empty;
                    img_star_item6_rf2.Source = bmi_Star;
                    img_star_item6_rf1.Source = bmi_Star;

                    break;
                case 3:
                    img_star_item6_rf5.Source = bmi_Star_empty;
                    img_star_item6_rf4.Source = bmi_Star_empty;
                    img_star_item6_rf3.Source = bmi_Star;
                    img_star_item6_rf2.Source = bmi_Star;
                    img_star_item6_rf1.Source = bmi_Star;
                    break;
                case 4:
                    img_star_item6_rf5.Source = bmi_Star_empty;
                    img_star_item6_rf4.Source = bmi_Star;
                    img_star_item6_rf3.Source = bmi_Star;
                    img_star_item6_rf2.Source = bmi_Star;
                    img_star_item6_rf1.Source = bmi_Star;
                    break;
                case 5:
                    img_star_item6_rf5.Source = bmi_Star;
                    img_star_item6_rf4.Source = bmi_Star;
                    img_star_item6_rf3.Source = bmi_Star;
                    img_star_item6_rf2.Source = bmi_Star;
                    img_star_item6_rf1.Source = bmi_Star;
                    break;
                default:
                    img_star_item6_rf5.Opacity = 0.0;
                    img_star_item6_rf4.Opacity = 0.0;
                    img_star_item6_rf3.Opacity = 0.0;
                    img_star_item6_rf2.Opacity = 0.0;
                    img_star_item6_rf1.Opacity = 0.0;
                    img_item6.Opacity = 0.25;
                    break;
            }

        }



        #endregion

        #region StatusCal
        public static void status_cal(string character, int star, int level, int rank, int array_order)
        {
            Growth growth_stat = new Growth();
            Rank rank_stat = new Rank();

            FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("{0}_{1}", character, star), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            double[] array1 = (double[])dummy1.GetValue(growth_stat);
            double[] array2;

            if (rank == 1)
            {
                array2 = Enumerable.Repeat<double>(0, 17).ToArray<double>();
            }
            else
            {
                FieldInfo dummy2 = rank_stat.GetType().GetField(string.Format("{0}_{1:D2}", character, rank), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                array2 = (double[])dummy2.GetValue(rank_stat);
            }

            double stat_HP = array1[0] + array1[1] * (double)level + array2[0] + array1[1] * (double)rank;
            double stat_PA = array1[2] + array1[3] * (double)level + array2[1] + array1[3] * (double)rank;
            double stat_MA = array1[4] + array1[5] * (double)level + array2[2] + array1[5] * (double)rank;
            double stat_PD = array1[6] + array1[7] * (double)level + array2[3] + array1[7] * (double)rank;
            double stat_MD = array1[8] + array1[9] * (double)level + array2[4] + array1[9] * (double)rank;
            double stat_PC = array1[10] + array2[5];
            double stat_MC = array1[11] + array2[6];
            double stat_HPauto = array2[7];
            double stat_TPauto = array2[8];
            double stat_Dodge = array2[9] + array1[16];
            double stat_HPabs = array1[12] + array2[10];
            double stat_HPup = array1[13] + array2[11];
            double stat_TPup = array1[14] + array2[12];
            double stat_TPdec = array2[13];
            double stat_acc = array1[15] + array2[14];

            Stat_variable.HP[array_order] = stat_HP;
            Stat_variable.PA[array_order] = stat_PA;
            Stat_variable.MA[array_order] = stat_MA;
            Stat_variable.PD[array_order] = stat_PD;
            Stat_variable.MD[array_order] = stat_MD;
            Stat_variable.PC[array_order] = stat_PC;
            Stat_variable.MC[array_order] = stat_MC;
            Stat_variable.HPauto[array_order] = stat_HPauto;
            Stat_variable.TPauto[array_order] = stat_TPauto;
            Stat_variable.Dodge[array_order] = stat_Dodge;
            Stat_variable.HPabs[array_order] = stat_HPabs;
            Stat_variable.HPup[array_order] = stat_HPup;
            Stat_variable.TPup[array_order] = stat_TPup;
            Stat_variable.TPdec[array_order] = stat_TPdec;
            Stat_variable.acc[array_order] = stat_acc;
        }

        public static void status_equip(string character, int rank, bool equip1, bool equip2, bool equip3, bool equip4, bool equip5, bool equip6, int rf1, int rf2, int rf3, int rf4, int rf5, int rf6, int array_order)
        {
            Equipment Eq = new Equipment();
            Unit_equip Ue = new Unit_equip();
            double[] array1;
            double[] eq1, eq2, eq3, eq4, eq5, eq6;
            double[] status_array = new double[15];


            FieldInfo dummy1 = Ue.GetType().GetField(string.Format("{0}_{1:D2}", character, rank), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            array1 = (double[])dummy1.GetValue(Ue);

            if (equip1 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[0]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq1 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1 / 5);
                    }
                }
            }
            else
            {
                eq1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip2 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[1]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq2 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2 / 5);
                    }
                }
            }
            else
            {
                eq2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip3 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[2]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq3 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3 / 5);
                    }
                }
            }
            else
            {
                eq3 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip4 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[3]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq4 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4 / 5);
                    }
                }
            }
            else
            {
                eq4 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip5 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[4]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq5 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5 / 5);
                    }
                }
            }
            else
            {
                eq5 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip6 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[5]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq6 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6 / 3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6 / 5);
                    }
                }
            }
            else
            {
                eq6 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }

            for (int i = 0; i < 15; i++)
            {
                status_array[i] = eq1[i] + eq2[i] + eq3[i] + eq4[i] + eq5[i] + eq6[i];
            }

            /* HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 */
            double stat_HP = status_array[0];
            double stat_PA = status_array[1];
            double stat_MA = status_array[2];
            double stat_PD = status_array[3];
            double stat_MD = status_array[4];
            double stat_PC = status_array[5];
            double stat_MC = status_array[6];
            double stat_HPauto = status_array[7];
            double stat_TPauto = status_array[8];
            double stat_Dodge = status_array[9];
            double stat_HPabs = status_array[10];
            double stat_HPup = status_array[11];
            double stat_TPup = status_array[12];
            double stat_TPdec = status_array[13];
            double stat_acc = status_array[14];

            Stat_variable.HP[array_order] += stat_HP;
            Stat_variable.PA[array_order] += stat_PA;
            Stat_variable.MA[array_order] += stat_MA;
            Stat_variable.PD[array_order] += stat_PD;
            Stat_variable.MD[array_order] += stat_MD;
            Stat_variable.PC[array_order] += stat_PC;
            Stat_variable.MC[array_order] += stat_MC;
            Stat_variable.HPauto[array_order] += stat_HPauto;
            Stat_variable.TPauto[array_order] += stat_TPauto;
            Stat_variable.Dodge[array_order] += stat_Dodge;
            Stat_variable.HPabs[array_order] += stat_HPabs;
            Stat_variable.HPup[array_order] += stat_HPup;
            Stat_variable.TPup[array_order] += stat_TPup;
            Stat_variable.TPdec[array_order] += stat_TPdec;
            Stat_variable.acc[array_order] += stat_acc;
        }

        public static void status_unique_equip(string character, ref bool equip, int equip_level, int array_order)
        {
            Unique_equipment Unieq = new Unique_equipment();

            FieldInfo dummy1 = Unieq.GetType().GetField(string.Format("{0}", character), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            double[] array1, array2;
            if (dummy1 != null && equip == true)
            {
                array1 = (double[])dummy1.GetValue(Unieq);

                FieldInfo dummy2 = Unieq.GetType().GetField(string.Format("{0}_reinforce", character), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                array2 = (double[])dummy2.GetValue(Unieq);
            }
            else
            {
                equip = false;
                array1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
                array2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }

            /* HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 */
            /* HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 */
            double stat_HP = array1[0] + array2[0] * ((double)equip_level - 1);
            double stat_PA = array1[1] + array2[1] * ((double)equip_level - 1);
            double stat_MA = array1[2] + array2[2] * ((double)equip_level - 1);
            double stat_PD = array1[3] + array2[3] * ((double)equip_level - 1);
            double stat_MD = array1[4] + array2[4] * ((double)equip_level - 1);
            double stat_PC = array1[5] + array2[5] * ((double)equip_level - 1);
            double stat_MC = array1[6] + array2[6] * ((double)equip_level - 1);
            double stat_HPauto = array1[7] + array2[7] * ((double)equip_level - 1);
            double stat_TPauto = array1[8] + array2[8] * ((double)equip_level - 1);
            double stat_Dodge = array1[9] + array2[9] * ((double)equip_level - 1);
            double stat_HPabs = array1[10] + array2[10] * ((double)equip_level - 1);
            double stat_HPup = array1[11] + array2[11] * ((double)equip_level - 1);
            double stat_TPup = array1[12] + array2[12] * ((double)equip_level - 1);
            double stat_TPdec = array1[13] + array2[13] * ((double)equip_level - 1);
            double stat_acc = array1[14] + array2[14] * ((double)equip_level - 1);

            Stat_variable.HP[array_order] += stat_HP;
            Stat_variable.PA[array_order] += stat_PA;
            Stat_variable.MA[array_order] += stat_MA;
            Stat_variable.PD[array_order] += stat_PD;
            Stat_variable.MD[array_order] += stat_MD;
            Stat_variable.PC[array_order] += stat_PC;
            Stat_variable.MC[array_order] += stat_MC;
            Stat_variable.HPauto[array_order] += stat_HPauto;
            Stat_variable.TPauto[array_order] += stat_TPauto;
            Stat_variable.Dodge[array_order] += stat_Dodge;
            Stat_variable.HPabs[array_order] += stat_HPabs;
            Stat_variable.HPup[array_order] += stat_HPup;
            Stat_variable.TPup[array_order] += stat_TPup;
            Stat_variable.TPdec[array_order] += stat_TPdec;
            Stat_variable.acc[array_order] += stat_acc;
        }

        public static void status_destiny(string character, int array_order)
        {
            double[] array1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array3 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array4 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array5 = Enumerable.Repeat<double>(0, 15).ToArray<double>();

            #region Destiny

            Destiny dt = new Destiny();
            if (character == "hiyori" || character == "hiyori_newyear" || character == "hiyori_princess")
            {
                array1 = dt.hiyori_12;
                array2 = dt.hiyori_newyear_08;
                array3 = dt.hiyori_princess_08;
            }
            else if (character == "yui" || character == "yui_newyear" || character == "yui_princess" || character == "yui_maiden")
            {
                array1 = dt.yui_12;
                array2 = dt.yui_newyear_08;
                array3 = dt.yui_princess_08;
                array4 = dt.yui_maiden_08;
            }
            else if (character == "rei" || character == "rei_newyear" || character == "rei_halloween")
            {
                array1 = dt.rei_12;
                array2 = dt.rei_newyear_08;
                array3 = dt.rei_halloween_08;
            }
            else if (character == "misogi" || character == "misogi_halloween")
            {
                array1 = dt.misogi_08;
                array2 = dt.misogi_halloween_08;
            }
            else if (character == "matsuri" || character == "matsuri_halloween")
            {
                array1 = dt.matsuri_08;
                array2 = dt.matsuri_halloween_08;
            }
            else if (character == "akari" || character == "akari_angel")
            {
                array1 = dt.akari_08;
                array2 = dt.akari_angel_08;
            }
            else if (character == "miyako" || character == "miyako_halloween")
            {
                array1 = dt.miyako_08;
                array2 = dt.miyako_halloween_08;
            }
            else if (character == "yuki")
            {
                array1 = dt.yuki_08;
            }
            else if (character == "anna" || character == "anna_summer")
            {
                array1 = dt.anna_08;
                array2 = dt.anna_summer_08;
            }
            else if (character == "maho" || character == "maho_summer")
            {
                array1 = dt.maho_12;
                array2 = dt.maho_summer_08;
            }
            else if (character == "rino" || character == "rino_wonder")
            {
                array1 = dt.rino_12;
                array2 = dt.rino_wonder_08;
            }
            else if (character == "hatsune" || character == "hatsune_summer")
            {
                array1 = dt.hatsune_12;
                array2 = dt.hatsune_summer_08;
            }
            else if (character == "nanaka" || character == "nanaka_summer")
            {
                array1 = dt.nanaka_08;
                array2 = dt.nanaka_summer_08;
            }
            else if (character == "kasumi" || character == "kasumi_magical")
            {
                array1 = dt.kasumi_08;
                array2 = dt.kasumi_magical_08;
            }
            else if (character == "misato" || character == "misato_summer")
            {
                array1 = dt.misato_08;
                array2 = dt.misato_summer_08;
            }
            else if (character == "suzuna" || character == "suzuna_summer")
            {
                array1 = dt.suzuna_08;
                array2 = dt.suzuna_summer_08;
            }
            else if (character == "kaori" || character == "kaori_summer")
            {
                array1 = dt.kaori_08;
                array2 = dt.kaori_summer_08;
            }
            else if (character == "io" || character == "io_summer")
            {
                array1 = dt.io_12;
                array2 = dt.io_summer_08;
            }
            else if (character == "mimi" || character == "mimi_halloween")
            {
                array1 = dt.mimi_08;
                array2 = dt.mimi_halloween_08;
            }
            else if (character == "kurumi" || character == "kurumi_christmas")
            {
                array1 = dt.kurumi_08;
                array2 = dt.kurumi_christmas_08;
            }
            else if (character == "yori" || character == "yori_angel")
            {
                array1 = dt.yori_08;
                array2 = dt.yori_angel_08;
            }
            else if (character == "ayane" || character == "ayane_christmas")
            {
                array1 = dt.ayane_12;
                array2 = dt.ayane_christmas_08;
            }
            else if (character == "suzume" || character == "suzume_summer" || character == "suzume_newyear")
            {
                array1 = dt.suzume_08;
                array2 = dt.suzume_summer_08;
                array3 = dt.suzume_newyear_08;
            }
            else if (character == "rin" || character == "rin_ranger")
            {
                array1 = dt.rin_08;
                array2 = dt.rin_ranger_08;
            }
            else if (character == "eriko" || character == "eriko_valentine")
            {
                array1 = dt.eriko_08;
                array2 = dt.eriko_valentine_08;
            }
            else if (character == "saren" || character == "saren_summer" || character == "saren_christmas")
            {
                array1 = dt.saren_12;
                array2 = dt.saren_summer_08;
                array3 = dt.saren_christmas_08;
            }
            else if (character == "nozomi" || character == "nozomi_christmas")
            {
                array1 = dt.nozomi_08;
                array2 = dt.nozomi_christmas_08;
            }
            else if (character == "ninon" || character == "ninon_ooedo")
            {
                array1 = dt.ninon_08;
                array2 = dt.ninon_ooedo_08;
            }
            else if (character == "sinobu" || character == "sinobu_halloween")
            {
                array1 = dt.sinobu_08;
                array2 = dt.sinobu_halloween_08;
            }
            else if (character == "akino" || character == "akino_christmas")
            {
                array1 = dt.akino_12;
                array2 = dt.akino_christmas_08;
            }
            else if (character == "mahiru" || character == "mahiru_ranger")
            {
                array1 = dt.mahiru_08;
                array2 = dt.mahiru_ranger_08;
            }
            else if (character == "yukari" || character == "yukari_christmas")
            {
                array1 = dt.yukari_12;
                array2 = dt.yukari_christmas_08;
            }
            else if (character == "kyouka" || character == "kyouka_halloween")
            {
                array1 = dt.kyouka_08;
                array2 = dt.kyouka_halloween_08;
            }
            else if (character == "tomo" || character == "tomo_magical")
            {
                array1 = dt.tomo_08;
                array2 = dt.tomo_magical_08;
            }
            else if (character == "siori" || character == "siori_magical")
            {
                array1 = dt.siori_08;
                array2 = dt.siori_magical_08;
            }
            else if (character == "aoi" || character == "aoi_nakayosi")
            {
                array1 = dt.aoi_08;
                array2 = dt.aoi_nakayosi_08;
            }
            else if (character == "chika" || character == "chika_christmas")
            {
                array1 = dt.chika_08;
                array2 = dt.chika_christmas_08;
            }
            else if (character == "makoto" || character == "makoto_summer")
            {
                array1 = dt.makoto_08;
                array2 = dt.makoto_summer_08;
            }
            else if (character == "iriya" || character == "iriya_christmas")
            {
                array1 = dt.iriya_08;
                array2 = dt.iriya_christmas_08;
            }
            else if (character == "kuuka" || character == "kuuka_ooedo")
            {
                array1 = dt.kuuka_08;
                array2 = dt.kuuka_ooedo_08;
            }
            else if (character == "tamaki" || character == "tamaki_summer")
            {
                array1 = dt.tamaki_12;
                array2 = dt.tamaki_summer_08;
            }
            else if (character == "zyun" || character == "zyun_summer")
            {
                array1 = dt.zyun_08;
                array2 = dt.zyun_summer_08;
            }
            else if (character == "mihuyu" || character == "mihuyu_summer")
            {
                array1 = dt.mihuyu_12;
                array2 = dt.mihuyu_summer_08;
            }
            else if (character == "sizuru" || character == "sizuru_valentine")
            {
                array1 = dt.sizuru_12;
                array2 = dt.sizuru_valentine_08;
            }
            else if (character == "misaki" || character == "misaki_halloween")
            {
                array1 = dt.misaki_08;
                array2 = dt.misaki_halloween_08;
            }
            else if (character == "mitsuki")
            {
                array1 = dt.mitsuki_08;
            }
            else if (character == "rima")
            {
                array1 = dt.rima_12;
            }
            else if (character == "monika" || character == "monika_magical")
            {
                array1 = dt.monika_08;
                //array2 = dt.monika_magical_08;
            }
            else if (character == "tsumugi" || character == "tsumugi_halloween")
            {
                array1 = dt.tsumugi_08;
                array2 = dt.tsumugi_halloween_08;
            }
            else if (character == "ayumi" || character == "ayumi_wonder")
            {
                array1 = dt.ayumi_08;
                array2 = dt.ayumi_wonder_08;
            }
            else if (character == "ruka" || character == "ruka_summer")
            {
                array1 = dt.ruka_08;
                array2 = dt.ruka_summer_08;
            }
            else if (character == "zita")
            {
                array1 = dt.zita_08;
            }
            else if (character == "pekorinnu" || character == "pekorinnu_summer" || character == "pekorinnu_princess" || character == "pekorinnu_newyear")
            {
                array1 = dt.pekorinnu_12;
                array2 = dt.pekorinnu_summer_08;
                array3 = dt.pekorinnu_princess_08;
                array4 = dt.pekorinnu_newyear_08;
            }
            else if (character == "kotkoro" || character == "kotkoro_summer" || character == "kotkoro_newyear" || character == "kotkoro_princess" || character == "kotkoro_maiden")
            {
                array1 = dt.kotkoro_12;
                array2 = dt.kotkoro_summer_08;
                array3 = dt.kotkoro_newyear_08;
                array4 = dt.kotkoro_princess_08;
                array5 = dt.kotkoro_maiden_08;
            }
            else if (character == "kyaru" || character == "kyaru_summer" || character == "kyaru_newyear" || character == "kyaru_princess")
            {
                array1 = dt.kyaru_12;
                array2 = dt.kyaru_summer_08;
                array3 = dt.kyaru_newyear_08;
                array4 = dt.kyaru_princess_08;
            }
            else if (character == "muimi" || character == "muimi_newyear")
            {
                array1 = dt.muimi_08;
                array2 = dt.muimi_newyear_08;
            }
            else if (character == "arisa")
            {
                array1 = dt.arisa_08;
            }
            else if (character == "kaya")
            {
                array1 = dt.kaya_08;
            }
            else if (character == "inori")
            {
                array1 = dt.inori_08;
            }
            else if (character == "labyrista")
            {
                array1 = dt.labyrista_08;
            }
            else if (character == "neneka" || character == "neneka_newyear")
            {
                array1 = dt.neneka_08;
                array2 = dt.neneka_newyear_08;
            }
            else if (character == "kristina" || character == "kristina_christmas")
            {
                array1 = dt.kristina_08;
                array2 = dt.kristina_christmas_08;
            }
            else if (character == "anne")
            {
                array1 = dt.anne_08;
            }
            else if (character == "lou")
            {
                array1 = dt.lou_08;
            }
            else if (character == "grea")
            {
                array1 = dt.grea_08;
            }
            else if (character == "rem")
            {
                array1 = dt.rem_08;
            }
            else if (character == "ram")
            {
                array1 = dt.ram_08;
            }
            else if (character == "emilia")
            {
                array1 = dt.emilia_08;
            }
            else if (character == "chloe")
            {
                array1 = dt.chloe_08;
            }
            else if (character == "chieru")
            {
                array1 = dt.chieru_08;
            }
            else if (character == "yuni")
            {
                array1 = dt.yuni_08;
            }
            else if (character == "runa")
            {
                array1 = dt.runa_08;
            }
            else if (character == "uzuki_deremas")
            {
                array1 = dt.uzuki_deremas_08;
            }
            else if (character == "rin_deremas")
            {
                array1 = dt.rin_deremas_08;
            }
            else if (character == "mio_deremas")
            {
                array1 = dt.mio_deremas_08;
            }

            #endregion
            double stat_HP = array1[0] + array2[0] + array3[0] + array4[0] + array5[0];
            double stat_PA = array1[1] + array2[1] + array3[1] + array4[1] + array5[1];
            double stat_MA = array1[2] + array2[2] + array3[2] + array4[2] + array5[2];
            double stat_PD = array1[3] + array2[3] + array3[3] + array4[3] + array5[3];
            double stat_MD = array1[4] + array2[4] + array3[4] + array4[4] + array5[4];
            double stat_PC = array1[5] + array2[5] + array3[5] + array4[5] + array5[5];
            double stat_MC = array1[6] + array2[6] + array3[6] + array4[6] + array5[6];
            double stat_HPauto = array1[7] + array2[7] + array3[7] + array4[7] + array5[7];
            double stat_TPauto = array1[8] + array2[8] + array3[8] + array4[8] + array5[8];
            double stat_Dodge = array1[9] + array2[9] + array3[9] + array4[9] + array5[9];
            double stat_HPabs = array1[10] + array2[10] + array3[10] + array4[10] + array5[10];
            double stat_HPup = array1[11] + array2[11] + array3[11] + array4[11] + array5[11];
            double stat_TPup = array1[12] + array2[12] + array3[12] + array4[12] + array5[12];
            double stat_TPdec = array1[13] + array2[13] + array3[13] + array4[13] + array5[13];
            double stat_acc = array1[14] + array2[14] + array3[14] + array4[14] + array5[14];

            Stat_variable.HP[array_order] += stat_HP;
            Stat_variable.PA[array_order] += stat_PA;
            Stat_variable.MA[array_order] += stat_MA;
            Stat_variable.PD[array_order] += stat_PD;
            Stat_variable.MD[array_order] += stat_MD;
            Stat_variable.PC[array_order] += stat_PC;
            Stat_variable.MC[array_order] += stat_MC;
            Stat_variable.HPauto[array_order] += stat_HPauto;
            Stat_variable.TPauto[array_order] += stat_TPauto;
            Stat_variable.Dodge[array_order] += stat_Dodge;
            Stat_variable.HPabs[array_order] += stat_HPabs;
            Stat_variable.HPup[array_order] += stat_HPup;
            Stat_variable.TPup[array_order] += stat_TPup;
            Stat_variable.TPdec[array_order] += stat_TPdec;
            Stat_variable.acc[array_order] += stat_acc;
        }

        public static void status_cal_temp(string character, int star, int level, int rank, int array_order)
        {
            Growth growth_stat = new Growth();
            Rank rank_stat = new Rank();

            FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("{0}_{1}", character, star), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            double[] array1 = (double[])dummy1.GetValue(growth_stat);

            double[] array2;

            Debug.WriteLine("status_cal_temp");
            if (rank == 1)
            {
                array2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            else
            {
                FieldInfo dummy2 = rank_stat.GetType().GetField(string.Format("{0}_{1:D2}", character, rank), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                array2 = (double[])dummy2.GetValue(rank_stat);
            }
            Debug.WriteLine("array1");
            for (int xx = 0; xx < array1.Length; xx++)
            {
                Debug.WriteLine(string.Format("array1[{0}] = {1}", xx, array1[xx]));
            }
            Debug.WriteLine("array2");
            for(int xx= 0;xx<array2.Length; xx++)
            {
                Debug.WriteLine(string.Format("array2[{0}] = {1}", xx, array2[xx]));
            }
            //array1 성장보너스 Growth.cs
            //array2 랭크보너스 Rank.cs
            /* Growth 0초기HP, 1성장HP, 2초기 물공, 3성장 물공, 4초기 마공, 5성장 마공, 6물방, 7성장 물방, 8마방, 9성장 마방, 10물크, 11마크, 12HP흡수, 13회복량 상승, 14TP 상승, 15명중, 16회피 */
            /* Rank 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 */

            double stat_HP = array1[0] + array1[1] * (double)level + array2[0] + array1[1] * (double)rank;
            double stat_PA = array1[2] + array1[3] * (double)level + array2[1] + array1[3] * (double)rank;
            double stat_MA = array1[4] + array1[5] * (double)level + array2[2] + array1[5] * (double)rank;
            double stat_PD = array1[6] + array1[7] * (double)level + array2[3] + array1[7] * (double)rank;
            double stat_MD = array1[8] + array1[9] * (double)level + array2[4] + array1[9] * (double)rank;
            double stat_PC = array1[10] + array2[5];
            double stat_MC = array1[11] + array2[6];
            double stat_HPauto = array2[7];
            double stat_TPauto = array2[8];
            double stat_Dodge = array2[9] + array1[16]; 
            double stat_HPabs = array1[12] + array2[10];
            double stat_HPup = array1[13] + array2[11];
            double stat_TPup = array1[14] + array2[12];
            double stat_TPdec = array2[13];
            double stat_acc = array1[15] + array2[14];
            Debug.WriteLine("status_cal_temp stat_HPup");
            Debug.WriteLine(string.Format("array1[13] = {0},array2[11] = {1}", array1[13], array2[11]));
                

            Stat_variable.HP_temp = stat_HP;
            Stat_variable.PA_temp = stat_PA;
            Stat_variable.MA_temp = stat_MA;
            Stat_variable.PD_temp = stat_PD;
            Stat_variable.MD_temp = stat_MD;
            Stat_variable.PC_temp = stat_PC;
            Stat_variable.MC_temp = stat_MC;
            Stat_variable.HPauto_temp = stat_HPauto;
            Stat_variable.TPauto_temp = stat_TPauto;
            Stat_variable.Dodge_temp = stat_Dodge;
            Stat_variable.HPabs_temp = stat_HPabs;
            Stat_variable.HPup_temp = stat_HPup;
            Stat_variable.TPup_temp = stat_TPup;
            Stat_variable.TPdec_temp = stat_TPdec;
            Stat_variable.acc_temp = stat_acc;

            Debug.Write("status_cal_temp Stat_variable.HPabs_temp = ");
            Debug.WriteLine(Stat_variable.HPabs_temp);
        }

        public static void status_equip_temp(string character, int rank, bool equip1, bool equip2, bool equip3, bool equip4, bool equip5, bool equip6, int rf1, int rf2, int rf3, int rf4, int rf5, int rf6, int array_order)
        {
            Equipment Eq = new Equipment();
            Unit_equip Ue = new Unit_equip();
            double[] array1;
            double[] eq1, eq2, eq3, eq4, eq5, eq6;
            double[] status_array = new double[15];


            FieldInfo dummy1 = Ue.GetType().GetField(string.Format("{0}_{1:D2}", character, rank), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            array1 = (double[])dummy1.GetValue(Ue);

            Debug.WriteLine("status_equip_temp");
            for(int tt=0; tt<array1.Length;tt++)
            {
                Debug.Write(string.Format("array1[{0}] = ", tt));
                Debug.WriteLine(array1[tt]);
            }
            Debug.WriteLine(string.Format("E{0}", array1[0]));
            if (equip1 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[0]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq1 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1 / 3.0);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[0]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq1[i] = eq1[i] * (1 + (double)rf1 / 5.0);
                        Debug.WriteLine(string.Format("eq1[{0}] = {1}, rein5", i, eq1[i]));
                    }
                }
            }
            else
            {
                eq1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }


            Debug.WriteLine(string.Format("E{0}", array1[1]));
            if (equip2 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[1]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq2 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2 / 3.0);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[1]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq2[i] = eq2[i] * (1 + (double)rf2 / 5.0);
                        Debug.WriteLine(string.Format("eq2[{0}] = {1}, rein5", i, eq2[i]));
                    }
                }
            }
            else
            {
                eq2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip3 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[2]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq3 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3 / 3.0);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[2]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq3[i] = eq3[i] * (1 + (double)rf3 / 5.0);
                        Debug.WriteLine(string.Format("eq3[{0}] = {1}, rein5", i, eq3[i]));
                    }
                }
            }
            else
            {
                eq3 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip4 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[3]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq4 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4 / 3.0);
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[3]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq4[i] = eq4[i] * (1 + (double)rf4 / 5.0);
                        Debug.WriteLine(string.Format("eq4[{0}] = {1}, rein5", i, eq4[i]));
                    }
                }
            }
            else
            {
                eq4 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip5 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[4]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq5 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5);
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5 / 3.0);
                        Debug.WriteLine(string.Format("eq5[{0}] = {1}, rein3", i, eq5[i]));
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[4]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq5[i] = eq5[i] * (1 + (double)rf5 / 5.0);
                        Debug.WriteLine(string.Format("eq5[{0}] = {1}, rein5", i, eq5[i]));
                    }
                }
            }
            else
            {
                eq5 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }
            if (equip6 == true)
            {
                FieldInfo dummy2 = Eq.GetType().GetField(string.Format("E{0}", array1[5]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                eq6 = (double[])dummy2.GetValue(Eq);
                if (Array.Exists(Eq.reinforce_0, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    ;
                }
                else if (Array.Exists(Eq.reinforce_1, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6);
                        Debug.WriteLine(string.Format("eq6[{0}] = {1}, rein1", i, eq6[i]));
                    }
                }
                else if (Array.Exists(Eq.reinforce_3, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6 / 3.0);
                        Debug.WriteLine(string.Format("eq6[{0}] = {1}, rein3", i, eq6[i]));
                    }
                }
                else if (Array.Exists(Eq.reinforce_5, i => i.Equals(string.Format("E{0}", array1[5]))) == true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        eq6[i] = eq6[i] * (1 + (double)rf6 / 5.0);
                        Debug.WriteLine(string.Format("eq6[{0}] = {1}, rein5", i, eq6[i]));
                    }
                }
            }
            else
            {
                eq6 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }

            for (int i = 0; i < 15; i++)
            {
                status_array[i] = eq1[i] + eq2[i] + eq3[i] + eq4[i] + eq5[i] + eq6[i];
            }

            /* 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승,12 TP 상승, 13TP 소비 감소, 14명중 */
            double stat_HP = status_array[0];
            double stat_PA = status_array[1];
            double stat_MA = status_array[2];
            double stat_PD = status_array[3];
            double stat_MD = status_array[4];
            double stat_PC = status_array[5];
            double stat_MC = status_array[6];
            double stat_HPauto = status_array[7];
            double stat_TPauto = status_array[8];
            double stat_Dodge = status_array[9];
            double stat_HPabs = status_array[10];
            double stat_HPup = status_array[11];
            double stat_TPup = status_array[12];
            double stat_TPdec = status_array[13];
            double stat_acc = status_array[14];

            Debug.WriteLine("status_equip_temp stat_HPup");
            Debug.WriteLine(string.Format("status_array[11] = {0}", status_array[11]));
            Stat_variable.HP_temp += stat_HP;
            Stat_variable.PA_temp += stat_PA;
            Stat_variable.MA_temp += stat_MA;
            Stat_variable.PD_temp += stat_PD;
            Stat_variable.MD_temp += stat_MD;
            Stat_variable.PC_temp += stat_PC;
            Stat_variable.MC_temp += stat_MC;
            Stat_variable.HPauto_temp += stat_HPauto;
            Stat_variable.TPauto_temp += stat_TPauto;
            Stat_variable.Dodge_temp += stat_Dodge;
            Stat_variable.HPabs_temp += stat_HPabs;
            Stat_variable.HPup_temp += stat_HPup;
            Stat_variable.TPup_temp += stat_TPup;
            Stat_variable.TPdec_temp += stat_TPdec;
            Stat_variable.acc_temp += stat_acc;

            Debug.Write("status_equip_temp Stat_variable.HPabs_temp = ");
            Debug.WriteLine(Stat_variable.HPabs_temp);
        }        
        public static void status_unique_equip_temp(string character, ref bool equip, int equip_level, int array_order)
        {
            Unique_equipment Unieq = new Unique_equipment();

            Debug.WriteLine("status_unique_equip_temp");
            FieldInfo dummy1 = Unieq.GetType().GetField(string.Format("{0}", character), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            double[] array1, array2;

            if (dummy1 != null && equip == true)
            {
                array1 = (double[])dummy1.GetValue(Unieq);

                FieldInfo dummy2 = Unieq.GetType().GetField(string.Format("{0}_reinforce", character), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                array2 = (double[])dummy2.GetValue(Unieq);
            }
            else
            {
                equip = false;
                array1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
                array2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            }

            /* 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 */
            /* HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 */
            double stat_HP = array1[0] + array2[0] * ((double)equip_level - 1);
            double stat_PA = array1[1] + array2[1] * ((double)equip_level - 1);
            double stat_MA = array1[2] + array2[2] * ((double)equip_level - 1);
            double stat_PD = array1[3] + array2[3] * ((double)equip_level - 1);
            double stat_MD = array1[4] + array2[4] * ((double)equip_level - 1);
            double stat_PC = array1[5] + array2[5] * ((double)equip_level - 1);
            double stat_MC = array1[6] + array2[6] * ((double)equip_level - 1);
            double stat_HPauto = array1[7] + array2[7] * ((double)equip_level - 1);
            double stat_TPauto = array1[8] + array2[8] * ((double)equip_level - 1);
            double stat_Dodge = array1[9] + array2[9] * ((double)equip_level - 1);
            double stat_HPabs = array1[10] + array2[10] * ((double)equip_level - 1);
            double stat_HPup = array1[11] + array2[11] * ((double)equip_level - 1);
            double stat_TPup = array1[12] + array2[12] * ((double)equip_level - 1);
            double stat_TPdec = array1[13] + array2[13] * ((double)equip_level - 1);
            double stat_acc = array1[14] + array2[14] * ((double)equip_level - 1);

            Debug.WriteLine("status_unique_equip_temp stat_HPup");
            Debug.WriteLine(string.Format("array1[11] = {0}, array2[11] = {1}, equip_level = {2}", array1[11], array2[11], equip_level));
            Stat_variable.HP_temp += stat_HP;
            Stat_variable.PA_temp += stat_PA;
            Stat_variable.MA_temp += stat_MA;
            Stat_variable.PD_temp += stat_PD;
            Stat_variable.MD_temp += stat_MD;
            Stat_variable.PC_temp += stat_PC;
            Stat_variable.MC_temp += stat_MC;
            Stat_variable.HPauto_temp += stat_HPauto;
            Stat_variable.TPauto_temp += stat_TPauto;
            Stat_variable.Dodge_temp += stat_Dodge;
            Stat_variable.HPabs_temp += stat_HPabs;
            Stat_variable.HPup_temp += stat_HPup;
            Stat_variable.TPup_temp += stat_TPup;
            Stat_variable.TPdec_temp += stat_TPdec;
            Stat_variable.acc_temp += stat_acc;
            Debug.Write("status_unique_equip_temp Stat_variable.HPabs_temp = ");
            Debug.WriteLine(Stat_variable.HPabs_temp);

            for (int i = 0; i < 15; i++)
            {
                Debug.Write(i + " = ");
                Debug.WriteLine(Convert.ToString(array1[i]), ", ", Convert.ToString(array2[i]));
            }
        }

        public static void status_destiny_temp(string character, int array_order)
        {
            double[] array1 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array2 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array3 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array4 = Enumerable.Repeat<double>(0, 15).ToArray<double>();
            double[] array5 = Enumerable.Repeat<double>(0, 15).ToArray<double>();

            #region Destiny_temp
            Destiny dt = new Destiny();
            if (character == "hiyori" || character == "hiyori_newyear" || character == "hiyori_princess")
            {
                array1 = dt.hiyori_12;
                array2 = dt.hiyori_newyear_08;
                //array3 = dt.hiyori_princess_08;
            }
            else if (character == "yui" || character == "yui_newyear" || character == "yui_princess" || character == "yui_maiden")
            {
                array1 = dt.yui_12;
                array2 = dt.yui_newyear_08;
                array3 = dt.yui_princess_08;
                array4 = dt.yui_maiden_08;
            }
            else if (character == "rei" || character == "rei_newyear" || character == "rei_halloween")
            {
                array1 = dt.rei_12;
                array2 = dt.rei_newyear_08;
                array3 = dt.rei_halloween_08;
            }
            else if (character == "misogi" || character == "misogi_halloween")
            {
                array1 = dt.misogi_08;
                array2 = dt.misogi_halloween_08;
            }
            else if (character == "matsuri" || character == "matsuri_halloween")
            {
                array1 = dt.matsuri_08;
                array2 = dt.matsuri_halloween_08;
            }
            else if (character == "akari" || character == "akari_angel")
            {
                array1 = dt.akari_08;
                array2 = dt.akari_angel_08;
            }
            else if (character == "miyako" || character == "miyako_halloween")
            {
                array1 = dt.miyako_08;
                array2 = dt.miyako_halloween_08;
            }
            else if (character == "yuki")
            {
                array1 = dt.yuki_08;
            }
            else if (character == "anna" || character == "anna_summer")
            {
                array1 = dt.anna_08;
                array2 = dt.anna_summer_08;
            }
            else if (character == "maho" || character == "maho_summer")
            {
                array1 = dt.maho_12;
                array2 = dt.maho_summer_08;
            }
            else if (character == "rino" || character == "rino_wonder")
            {
                array1 = dt.rino_12;
                array2 = dt.rino_wonder_08;
            }
            else if (character == "hatsune" || character == "hatsune_summer")
            {
                array1 = dt.hatsune_12;
                array2 = dt.hatsune_summer_08;
            }
            else if (character == "nanaka" || character == "nanaka_summer")
            {
                array1 = dt.nanaka_08;
                array2 = dt.nanaka_summer_08;
            }
            else if (character == "kasumi" || character == "kasumi_magical")
            {
                array1 = dt.kasumi_08;
                array2 = dt.kasumi_magical_08;
            }
            else if (character == "misato" || character == "misato_summer")
            {
                array1 = dt.misato_08;
                array2 = dt.misato_summer_08;
            }
            else if (character == "suzuna" || character == "suzuna_summer")
            {
                array1 = dt.suzuna_08;
                array2 = dt.suzuna_summer_08;
            }
            else if (character == "kaori" || character == "kaori_summer")
            {
                array1 = dt.kaori_08;
                array2 = dt.kaori_summer_08;
            }
            else if (character == "io" || character == "io_summer")
            {
                array1 = dt.io_12;
                array2 = dt.io_summer_08;
            }
            else if (character == "mimi" || character == "mimi_halloween")
            {
                array1 = dt.mimi_08;
                array2 = dt.mimi_halloween_08;
            }
            else if (character == "kurumi" || character == "kurumi_christmas")
            {
                array1 = dt.kurumi_08;
                array2 = dt.kurumi_christmas_08;
            }
            else if (character == "yori" || character == "yori_angel")
            {
                array1 = dt.yori_08;
                array2 = dt.yori_angel_08;
            }
            else if (character == "ayane" || character == "ayane_christmas")
            {
                array1 = dt.ayane_12;
                array2 = dt.ayane_christmas_08;
            }
            else if (character == "suzume" || character == "suzume_summer" || character == "suzume_newyear")
            {
                array1 = dt.suzume_08;
                array2 = dt.suzume_summer_08;
                array3 = dt.suzume_newyear_08;
            }
            else if (character == "rin" || character == "rin_ranger")
            {
                array1 = dt.rin_08;
                array2 = dt.rin_ranger_08;
            }
            else if (character == "eriko" || character == "eriko_valentine")
            {
                array1 = dt.eriko_08;
                array2 = dt.eriko_valentine_08;
            }
            else if (character == "saren" || character == "saren_summer" || character == "saren_christmas")
            {
                array1 = dt.saren_12;
                array2 = dt.saren_summer_08;
                array3 = dt.saren_christmas_08;
            }
            else if (character == "nozomi" || character == "nozomi_christmas")
            {
                array1 = dt.nozomi_08;
                array2 = dt.nozomi_christmas_08;
            }
            else if (character == "ninon" || character == "ninon_ooedo")
            {
                array1 = dt.ninon_08;
                array2 = dt.ninon_ooedo_08;
            }
            else if (character == "sinobu" || character == "sinobu_halloween")
            {
                array1 = dt.sinobu_08;
                array2 = dt.sinobu_halloween_08;
            }
            else if (character == "akino" || character == "akino_christmas")
            {
                array1 = dt.akino_12;
                array2 = dt.akino_christmas_08;
            }
            else if (character == "mahiru" || character == "mahiru_ranger")
            {
                array1 = dt.mahiru_08;
                array2 = dt.mahiru_ranger_08;
            }
            else if (character == "yukari" || character == "yukari_christmas")
            {
                array1 = dt.yukari_12;
               array2 = dt.yukari_christmas_08;
            }
            else if (character == "kyouka" || character == "kyouka_halloween")
            {
                array1 = dt.kyouka_08;
                array2 = dt.kyouka_halloween_08;
            }
            else if (character == "tomo" || character == "tomo_magical")
            {
                array1 = dt.tomo_08;
                array2 = dt.tomo_magical_08;
            }
            else if (character == "siori" || character == "siori_magical")
            {
                array1 = dt.siori_08;
                array2 = dt.siori_magical_08;
            }
            else if (character == "aoi" || character == "aoi_nakayosi")
            {
                array1 = dt.aoi_08;
                array2 = dt.aoi_nakayosi_08;
            }
            else if (character == "chika" || character == "chika_christmas")
            {
                array1 = dt.chika_08;
                array2 = dt.chika_christmas_08;
            }
            else if (character == "makoto" || character == "makoto_summer")
            {
                array1 = dt.makoto_08;
                array2 = dt.makoto_summer_08;
            }
            else if (character == "iriya" || character == "iriya_christmas")
            {
                array1 = dt.iriya_08;
                array2 = dt.iriya_christmas_08;
            }
            else if (character == "kuuka" || character == "kuuka_ooedo")
            {
                array1 = dt.kuuka_08;
                array2 = dt.kuuka_ooedo_08;
            }
            else if (character == "tamaki" || character == "tamaki_summer")
            {
                array1 = dt.tamaki_12;
                array2 = dt.tamaki_summer_08;
            }
            else if (character == "zyun" || character == "zyun_summer")
            {
                array1 = dt.zyun_08;
                array2 = dt.zyun_summer_08;
            }
            else if (character == "mihuyu" || character == "mihuyu_summer")
            {
                array1 = dt.mihuyu_12;
                array2 = dt.mihuyu_summer_08;
            }
            else if (character == "sizuru" || character == "sizuru_valentine")
            {
                array1 = dt.sizuru_12;
                array2 = dt.sizuru_valentine_08;
            }
            else if (character == "misaki" || character == "misaki_halloween")
            {
                array1 = dt.misaki_08;
                array2 = dt.misaki_halloween_08;
            }
            else if (character == "mitsuki")
            {
                array1 = dt.mitsuki_08;
            }
            else if (character == "rima")
            {
                array1 = dt.rima_12;
            }
            else if (character == "monika" || character == "monika_magical")
            {
                array1 = dt.monika_08;
                //array2 = dt.monika_magical_08;
            }
            else if (character == "tsumugi" || character == "tsumugi_halloween")
            {
                array1 = dt.tsumugi_08;
                array2 = dt.tsumugi_halloween_08;
            }
            else if (character == "ayumi" || character == "ayumi_wonder")
            {
                array1 = dt.ayumi_08;
                array2 = dt.ayumi_wonder_08;
            }
            else if (character == "ruka" || character == "ruka_summer")
            {
                array1 = dt.ruka_08;
                array2 = dt.ruka_summer_08;
            }
            else if (character == "zita")
            {
                array1 = dt.zita_08;
            }
            else if (character == "pekorinnu" || character == "pekorinnu_summer" || character == "pekorinnu_princess" || character == "pekorinnu_newyear")
            {
                array1 = dt.pekorinnu_12;
                array2 = dt.pekorinnu_summer_08;
                array3 = dt.pekorinnu_princess_08;
                array4 = dt.pekorinnu_newyear_08;
            }
            else if (character == "kotkoro" || character == "kotkoro_summer" || character == "kotkoro_newyear" || character == "kotkoro_princess" || character == "kotkoro_maiden")
            {
                array1 = dt.kotkoro_12;
                array2 = dt.kotkoro_summer_08;
                array3 = dt.kotkoro_newyear_08;
                array4 = dt.kotkoro_princess_08;
                array5 = dt.kotkoro_maiden_08;
            }
            else if (character == "kyaru" || character == "kyaru_summer" || character == "kyaru_newyear" || character == "kyaru_princess")
            {
                array1 = dt.kyaru_12;
                array2 = dt.kyaru_summer_08;
                array3 = dt.kyaru_newyear_08;
                array4 = dt.kyaru_princess_08;
            }
            else if (character == "muimi" || character == "muimi_newyear")
            {
                array1 = dt.muimi_08;
                array2 = dt.muimi_newyear_08;
            }
            else if (character == "arisa")
            {
                array1 = dt.arisa_08;
            }
            else if (character == "kaya")
            {
                array1 = dt.kaya_08;
            }
            else if (character == "inori")
            {
                array1 = dt.inori_08;
            }
            else if (character == "labyrista")
            {
                array1 = dt.labyrista_08;
            }
            else if (character == "neneka" || character == "neneka_newyear")
            {
                array1 = dt.neneka_08;
                array2 = dt.neneka_newyear_08;
            }
            else if (character == "kristina" || character == "kristina_christmas")
            {
                array1 = dt.kristina_08;
                array2 = dt.kristina_christmas_08;
            }
            else if (character == "anne")
            {
                array1 = dt.anne_08;
            }
            else if (character == "lou")
            {
                array1 = dt.lou_08;
            }
            else if (character == "grea")
            {
                array1 = dt.grea_08;
            }
            else if (character == "rem")
            {
                array1 = dt.rem_08;
            }
            else if (character == "ram")
            {
                array1 = dt.ram_08;
            }
            else if (character == "emilia")
            {
                array1 = dt.emilia_08;
            }
            else if (character == "chloe")
            {
                array1 = dt.chloe_08;
            }
            else if (character == "chieru")
            {
                array1 = dt.chieru_08;
            }
            else if (character == "yuni")
            {
                array1 = dt.yuni_08;
            }
            else if (character == "runa")
            {
                array1 = dt.runa_08;
            }
            else if (character == "uzuki_deremas")
            {
                array1 = dt.uzuki_deremas_08;
            }
            else if (character == "rin_deremas")
            {
                array1 = dt.rin_deremas_08;
            }
            else if (character == "mio_deremas")
            {
                array1 = dt.mio_deremas_08;
            }

            #endregion

            /* 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 */
            double stat_HP = array1[0] + array2[0] + array3[0] + array4[0] + array5[0];
            double stat_PA = array1[1] + array2[1] + array3[1] + array4[1] + array5[1];
            double stat_MA = array1[2] + array2[2] + array3[2] + array4[2] + array5[2];
            double stat_PD = array1[3] + array2[3] + array3[3] + array4[3] + array5[3];
            double stat_MD = array1[4] + array2[4] + array3[4] + array4[4] + array5[4];
            double stat_PC = array1[5] + array2[5] + array3[5] + array4[5] + array5[5];
            double stat_MC = array1[6] + array2[6] + array3[6] + array4[6] + array5[6];
            double stat_HPauto = array1[7] + array2[7] + array3[7] + array4[7] + array5[7];
            double stat_TPauto = array1[8] + array2[8] + array3[8] + array4[8] + array5[8];
            double stat_Dodge = array1[9] + array2[9] + array3[9] + array4[9] + array5[9];
            double stat_HPabs = array1[10] + array2[10] + array3[10] + array4[10] + array5[10];
            double stat_HPup = array1[11] + array2[11] + array3[11] + array4[11] + array5[11];
            double stat_TPup = array1[12] + array2[12] + array3[12] + array4[12] + array5[12];
            double stat_TPdec = array1[13] + array2[13] + array3[13] + array4[13] + array5[13];
            double stat_acc = array1[14] + array2[14] + array3[14] + array4[14] + array5[14];

            Stat_variable.HP_temp += stat_HP;
            Stat_variable.PA_temp += stat_PA;
            Stat_variable.MA_temp += stat_MA;
            Stat_variable.PD_temp += stat_PD;
            Stat_variable.MD_temp += stat_MD;
            Stat_variable.PC_temp += stat_PC;
            Stat_variable.MC_temp += stat_MC;
            Stat_variable.HPauto_temp += stat_HPauto;
            Stat_variable.TPauto_temp += stat_TPauto;
            Stat_variable.Dodge_temp += stat_Dodge;
            Stat_variable.HPabs_temp += stat_HPabs;
            Stat_variable.HPup_temp += stat_HPup;
            Stat_variable.TPup_temp += stat_TPup;
            Stat_variable.TPdec_temp += stat_TPdec;
            Stat_variable.acc_temp += stat_acc;
            Debug.Write("status_destiny_temp Stat_variable.HPabs_temp = ");
            Debug.WriteLine(Stat_variable.HPabs_temp);
        }

        #endregion
    }
}
