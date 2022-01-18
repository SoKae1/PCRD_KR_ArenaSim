using Microsoft.VisualBasic.CompilerServices;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using AutoUpdaterDotNET;
using System.Xml;
using System.Net;
using HtmlAgilityPack;

namespace PCRD_KR_ArenaSim
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "프리코네 아레나 시뮬레이터 "+System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            InitialText();
            WriteUpdateInfoXml();
            DeleteOldFile();
            //UpdateCheck();
            //InitialAvaliabilty();
            InitWorkerThread();
            InitializeAbbr();
            InitialMaxText();
            Debug.WriteLine(AgilityTest());
            Debug.WriteLine(maxUnique);
        }

        
        public static int select_count = 0;
        public static string[] select_defence = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static string[] select_defence_eng = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static int select_count2 = 0;
        public static string[] select_offence = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public static string[] select_offence_eng = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        public static int select_count2_temp = 0;

        public static double[] timing = Enumerable.Repeat<double>(0, 30).ToArray<double>();
        public static double flow_time = 0;
        public const double end_time = 90;//2.467초 대기시간.

        public static bool isDefDeckReady = false;
        public static bool isOffDeckReady = false;
        public static bool isFindOffReady = false;

        public static int select_count_temp = 0;
        public static string[] select_defence_temp = select_defence;
        public static string[] select_defence_temp_eng = select_defence_eng;

        public static string[] select_offence_temp = select_offence;
        public static string[] select_offence_temp_eng = select_offence_eng;

        Character_select cs = new Character_select();

        public static bool[] IsPicked = new bool[150];

        public static Random rand = new Random(); // 매우 중요

        public static int mX = 0;
        public static int mY = 0;
        public static int mWidth = 0;
        public static int mHeigt = 0;

        public static string LogString;
        public string Filename;

        double power_sum_def = 0.0;
        double power_sum_off = 0.0;

        public bool isImageprepared = false;
        public static readonly int MaxLoopCount = 365;
        public Uri[] uriSource = new Uri[MaxLoopCount];
        public Mat[] UnitIcon = new Mat[MaxLoopCount];
        public string[] uriString = new string[MaxLoopCount];

        string[] DeckIndex = new string[5];

        public static string[] AvailableCharaList = new string[MaxLoopCount];
        public static string[] AlreadySelectedCharaList;

        FlowDocument myFlowDoc = new FlowDocument();
        public static bool isSimOK = false;
        public int max_repeat = 0;

        public int off_count = 0;
        public int def_count = 0;
        public int def_timecount = 0;

        private BackgroundWorker worker;

        private int highestPercentageReached = 0;
        public List<string> FindPick_temp = new List<string>();
        public List<string> FindPick = new List<string>();
        public static string[][] FoundPick_KR;
        public static string[][] FoundPick_EN;
        public static int numParty;


        //메인 탭
        #region MainTab

        #region Checked
        public void tb_hiyori_Checked(object sender, RoutedEventArgs args) { cs.hiyori = true; select_count++; }
        public void tb_hiyori_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori = false; select_count--; }
        public void tb_rei_Checked(object sender, RoutedEventArgs args) { cs.rei = true; select_count++; }
        public void tb_rei_UnChecked(object sender, RoutedEventArgs args) { cs.rei = false; select_count--; }
        public void tb_yui_Checked(object sender, RoutedEventArgs args) { cs.yui = true; select_count++; }
        public void tb_yui_UnChecked(object sender, RoutedEventArgs args) { cs.yui = false; select_count--; }
        public void tb_misogi_Checked(object sender, RoutedEventArgs args) { cs.misogi = true; select_count++; }
        public void tb_misogi_UnChecked(object sender, RoutedEventArgs args) { cs.misogi = false; select_count--; }

        public void tb_matsuri_Checked(object sender, RoutedEventArgs args) { cs.matsuri = true; select_count++; }
        public void tb_matsuri_UnChecked(object sender, RoutedEventArgs args) { cs.matsuri = false; select_count--; }

        public void tb_akari_Checked(object sender, RoutedEventArgs args) { cs.akari = true; select_count++; }
        public void tb_akari_UnChecked(object sender, RoutedEventArgs args) { cs.akari = false; select_count--; }

        public void tb_miyako_Checked(object sender, RoutedEventArgs args) { cs.miyako = true; select_count++; }
        public void tb_miyako_UnChecked(object sender, RoutedEventArgs args) { cs.miyako = false; select_count--; }

        public void tb_yuki_Checked(object sender, RoutedEventArgs args) { cs.yuki = true; select_count++; }
        public void tb_yuki_UnChecked(object sender, RoutedEventArgs args) { cs.yuki = false; select_count--; }

        public void tb_anna_Checked(object sender, RoutedEventArgs args) { cs.anna = true; select_count++; }
        public void tb_anna_UnChecked(object sender, RoutedEventArgs args) { cs.anna = false; select_count--; }
        public void tb_maho_Checked(object sender, RoutedEventArgs args) { cs.maho = true; select_count++; }
        public void tb_maho_UnChecked(object sender, RoutedEventArgs args) { cs.maho = false; select_count--; }
        public void tb_rino_Checked(object sender, RoutedEventArgs args) { cs.rino = true; select_count++; }
        public void tb_rino_UnChecked(object sender, RoutedEventArgs args) { cs.rino = false; select_count--; }
        public void tb_hatsune_Checked(object sender, RoutedEventArgs args) { cs.hatsune = true; select_count++; }
        public void tb_hatsune_UnChecked(object sender, RoutedEventArgs args) { cs.hatsune = false; select_count--; }
        public void tb_nanaka_Checked(object sender, RoutedEventArgs args) { cs.nanaka = true; select_count++; }
        public void tb_nanaka_UnChecked(object sender, RoutedEventArgs args) { cs.nanaka = false; select_count--; }
        public void tb_kasumi_Checked(object sender, RoutedEventArgs args) { cs.kasumi = true; select_count++; }
        public void tb_kasumi_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi = false; select_count--; }
        public void tb_misato_Checked(object sender, RoutedEventArgs args) { cs.misato = true; select_count++; }
        public void tb_misato_UnChecked(object sender, RoutedEventArgs args) { cs.misato = false; select_count--; }
        public void tb_suzuna_Checked(object sender, RoutedEventArgs args) { cs.suzuna = true; select_count++; }
        public void tb_suzuna_UnChecked(object sender, RoutedEventArgs args) { cs.suzuna = false; select_count--; }
        public void tb_kaori_Checked(object sender, RoutedEventArgs args) { cs.kaori = true; select_count++; }
        public void tb_kaori_UnChecked(object sender, RoutedEventArgs args) { cs.kaori = false; select_count--; }
        public void tb_io_Checked(object sender, RoutedEventArgs args) { cs.io = true; select_count++; }
        public void tb_io_UnChecked(object sender, RoutedEventArgs args) { cs.io = false; select_count--; }
        public void tb_mimi_Checked(object sender, RoutedEventArgs args) { cs.mimi = true; select_count++; }
        public void tb_mimi_UnChecked(object sender, RoutedEventArgs args) { cs.mimi = false; select_count--; }
        public void tb_kurumi_Checked(object sender, RoutedEventArgs args) { cs.kurumi = true; select_count++; }
        public void tb_kurumi_UnChecked(object sender, RoutedEventArgs args) { cs.kurumi = false; select_count--; }
        public void tb_yori_Checked(object sender, RoutedEventArgs args) { cs.yori = true; select_count++; }
        public void tb_yori_UnChecked(object sender, RoutedEventArgs args) { cs.yori = false; select_count--; }
        public void tb_ayane_Checked(object sender, RoutedEventArgs args) { cs.ayane = true; select_count++; }
        public void tb_ayane_UnChecked(object sender, RoutedEventArgs args) { cs.ayane = false; select_count--; }
        public void tb_suzume_Checked(object sender, RoutedEventArgs args) { cs.suzume = true; select_count++; }
        public void tb_suzume_UnChecked(object sender, RoutedEventArgs args) { cs.suzume = false; select_count--; }
        public void tb_rin_Checked(object sender, RoutedEventArgs args) { cs.rin = true; select_count++; }
        public void tb_rin_UnChecked(object sender, RoutedEventArgs args) { cs.rin = false; select_count--; }
        public void tb_eriko_Checked(object sender, RoutedEventArgs args) { cs.eriko = true; select_count++; }
        public void tb_eriko_UnChecked(object sender, RoutedEventArgs args) { cs.eriko = false; select_count--; }
        public void tb_saren_Checked(object sender, RoutedEventArgs args) { cs.saren = true; select_count++; }
        public void tb_saren_UnChecked(object sender, RoutedEventArgs args) { cs.saren = false; select_count--; }
        public void tb_nozomi_Checked(object sender, RoutedEventArgs args) { cs.nozomi = true; select_count++; }
        public void tb_nozomi_UnChecked(object sender, RoutedEventArgs args) { cs.nozomi = false; select_count--; }
        public void tb_ninon_Checked(object sender, RoutedEventArgs args) { cs.ninon = true; select_count++; }
        public void tb_ninon_UnChecked(object sender, RoutedEventArgs args) { cs.ninon = false; select_count--; }
        public void tb_sinobu_Checked(object sender, RoutedEventArgs args) { cs.sinobu = true; select_count++; }
        public void tb_sinobu_UnChecked(object sender, RoutedEventArgs args) { cs.sinobu = false; select_count--; }
        public void tb_akino_Checked(object sender, RoutedEventArgs args) { cs.akino = true; select_count++; }
        public void tb_akino_UnChecked(object sender, RoutedEventArgs args) { cs.akino = false; select_count--; }
        public void tb_mahiru_Checked(object sender, RoutedEventArgs args) { cs.mahiru = true; select_count++; }
        public void tb_mahiru_UnChecked(object sender, RoutedEventArgs args) { cs.mahiru = false; select_count--; }
        public void tb_yukari_Checked(object sender, RoutedEventArgs args) { cs.yukari = true; select_count++; }
        public void tb_yukari_UnChecked(object sender, RoutedEventArgs args) { cs.yukari = false; select_count--; }
        public void tb_kyouka_Checked(object sender, RoutedEventArgs args) { cs.kyouka = true; select_count++; }
        public void tb_kyouka_UnChecked(object sender, RoutedEventArgs args) { cs.kyouka = false; select_count--; }
        public void tb_tomo_Checked(object sender, RoutedEventArgs args) { cs.tomo = true; select_count++; }
        public void tb_tomo_UnChecked(object sender, RoutedEventArgs args) { cs.tomo = false; select_count--; }
        public void tb_siori_Checked(object sender, RoutedEventArgs args) { cs.siori = true; select_count++; }
        public void tb_siori_UnChecked(object sender, RoutedEventArgs args) { cs.siori = false; select_count--; }
        public void tb_aoi_Checked(object sender, RoutedEventArgs args) { cs.aoi = true; select_count++; }
        public void tb_aoi_UnChecked(object sender, RoutedEventArgs args) { cs.aoi = false; select_count--; }
        public void tb_chika_Checked(object sender, RoutedEventArgs args) { cs.chika = true; select_count++; }
        public void tb_chika_UnChecked(object sender, RoutedEventArgs args) { cs.chika = false; select_count--; }
        public void tb_makoto_Checked(object sender, RoutedEventArgs args) { cs.makoto = true; select_count++; }
        public void tb_makoto_UnChecked(object sender, RoutedEventArgs args) { cs.makoto = false; select_count--; }
        public void tb_iriya_Checked(object sender, RoutedEventArgs args) { cs.iriya = true; select_count++; }
        public void tb_iriya_UnChecked(object sender, RoutedEventArgs args) { cs.iriya = false; select_count--; }
        public void tb_kuuka_Checked(object sender, RoutedEventArgs args) { cs.kuuka = true; select_count++; }
        public void tb_kuuka_UnChecked(object sender, RoutedEventArgs args) { cs.kuuka = false; select_count--; }
        public void tb_tamaki_Checked(object sender, RoutedEventArgs args) { cs.tamaki = true; select_count++; }
        public void tb_tamaki_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki = false; select_count--; }
        public void tb_zyun_Checked(object sender, RoutedEventArgs args) { cs.zyun = true; select_count++; }
        public void tb_zyun_UnChecked(object sender, RoutedEventArgs args) { cs.zyun = false; select_count--; }
        public void tb_mihuyu_Checked(object sender, RoutedEventArgs args) { cs.mihuyu = true; select_count++; }
        public void tb_mihuyu_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu = false; select_count--; }
        public void tb_sizuru_Checked(object sender, RoutedEventArgs args) { cs.sizuru = true; select_count++; }
        public void tb_sizuru_UnChecked(object sender, RoutedEventArgs args) { cs.sizuru = false; select_count--; }
        public void tb_misaki_Checked(object sender, RoutedEventArgs args) { cs.misaki = true; select_count++; }
        public void tb_misaki_UnChecked(object sender, RoutedEventArgs args) { cs.misaki = false; select_count--; }
        public void tb_mitsuki_Checked(object sender, RoutedEventArgs args) { cs.mitsuki = true; select_count++; }
        public void tb_mitsuki_UnChecked(object sender, RoutedEventArgs args) { cs.mitsuki = false; select_count--; }
        public void tb_rima_Checked(object sender, RoutedEventArgs args) { cs.rima = true; select_count++; }
        public void rima_Checked() { cs.rima = true; select_count++; }
        public void tb_rima_UnChecked(object sender, RoutedEventArgs args) { cs.rima = false; select_count--; }
        public void tb_monika_Checked(object sender, RoutedEventArgs args) { cs.monika = true; select_count++; }
        public void tb_monika_UnChecked(object sender, RoutedEventArgs args) { cs.monika = false; select_count--; }
        public void tb_tsumugi_Checked(object sender, RoutedEventArgs args) { cs.tsumugi = true; select_count++; }
        public void tb_tsumugi_UnChecked(object sender, RoutedEventArgs args) { cs.tsumugi = false; select_count--; }
        public void tb_ayumi_Checked(object sender, RoutedEventArgs args) { cs.ayumi = true; select_count++; }
        public void tb_ayumi_UnChecked(object sender, RoutedEventArgs args) { cs.ayumi = false; select_count--; }
        public void tb_ruka_Checked(object sender, RoutedEventArgs args) { cs.ruka = true; select_count++; }
        public void tb_ruka_UnChecked(object sender, RoutedEventArgs args) { cs.ruka = false; select_count--; }
        public void tb_zita_Checked(object sender, RoutedEventArgs args) { cs.zita = true; select_count++; }
        public void tb_zita_UnChecked(object sender, RoutedEventArgs args) { cs.zita = false; select_count--; }
        public void tb_pekorinnu_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu = true; select_count++; }
        public void tb_pekorinnu_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu = false; select_count--; }
        public void tb_kotkoro_Checked(object sender, RoutedEventArgs args) { cs.kotkoro = true; select_count++; }
        public void tb_kotkoro_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro = false; select_count--; }
        public void tb_kyaru_Checked(object sender, RoutedEventArgs args) { cs.kyaru = true; select_count++; }
        public void tb_kyaru_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru = false; select_count--; }
        public void tb_muimi_Checked(object sender, RoutedEventArgs args) { cs.muimi = true; select_count++; }
        public void tb_muimi_UnChecked(object sender, RoutedEventArgs args) { cs.muimi = false; select_count--; }
        public void tb_arisa_Checked(object sender, RoutedEventArgs args) { cs.arisa = true; select_count++; }
        public void tb_arisa_UnChecked(object sender, RoutedEventArgs args) { cs.arisa = false; select_count--; }
        public void tb_kaya_Checked(object sender, RoutedEventArgs args) { cs.kaya = true; select_count++; }
        public void tb_kaya_UnChecked(object sender, RoutedEventArgs args) { cs.kaya = false; select_count--; }
        public void tb_neneka_Checked(object sender, RoutedEventArgs args) { cs.neneka = true; select_count++; }
        public void tb_neneka_UnChecked(object sender, RoutedEventArgs args) { cs.neneka = false; select_count--; }
        public void tb_kristina_Checked(object sender, RoutedEventArgs args) { cs.kristina = true; select_count++; }
        public void tb_kristina_UnChecked(object sender, RoutedEventArgs args) { cs.kristina = false; select_count--; }
        public void tb_pekorinnu_summer_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu_summer = true; select_count++; }
        public void tb_pekorinnu_summer_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_summer = false; select_count--; }
        public void tb_kotkoro_summer_Checked(object sender, RoutedEventArgs args) { cs.kotkoro_summer = true; select_count++; }
        public void tb_kotkoro_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_summer = false; select_count--; }
        public void tb_suzume_summer_Checked(object sender, RoutedEventArgs args) { cs.suzume_summer = true; select_count++; }
        public void tb_suzume_summer_UnChecked(object sender, RoutedEventArgs args) { cs.suzume_summer = false; select_count--; }
        public void tb_kyaru_summer_Checked(object sender, RoutedEventArgs args) { cs.kyaru_summer = true; select_count++; }
        public void tb_kyaru_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_summer = false; select_count--; }
        public void tb_tamaki_summer_Checked(object sender, RoutedEventArgs args) { cs.tamaki_summer = true; select_count++; }
        public void tb_tamaki_summer_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki_summer = false; select_count--; }
        public void tb_mihuyu_summer_Checked(object sender, RoutedEventArgs args) { cs.mihuyu_summer = true; select_count++; }
        public void tb_mihuyu_summer_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu_summer = false; select_count--; }
        public void tb_sinobu_halloween_Checked(object sender, RoutedEventArgs args) { cs.sinobu_halloween = true; select_count++; }
        public void tb_sinobu_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.sinobu_halloween = false; select_count--; }
        public void tb_miyako_halloween_Checked(object sender, RoutedEventArgs args) { cs.miyako_halloween = true; select_count++; }
        public void tb_miyako_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.miyako_halloween = false; select_count--; }
        public void tb_misaki_halloween_Checked(object sender, RoutedEventArgs args) { cs.misaki_halloween = true; select_count++; }
        public void tb_misaki_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.misaki_halloween = false; select_count--; }
        public void tb_chika_christmas_Checked(object sender, RoutedEventArgs args) { cs.chika_christmas = true; select_count++; }
        public void tb_chika_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.chika_christmas = false; select_count--; }
        public void tb_kurumi_christmas_Checked(object sender, RoutedEventArgs args) { cs.kurumi_christmas = true; select_count++; }
        public void tb_kurumi_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.kurumi_christmas = false; select_count--; }
        public void tb_ayane_christmas_Checked(object sender, RoutedEventArgs args) { cs.ayane_christmas = true; select_count++; }
        public void tb_ayane_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.ayane_christmas = false; select_count--; }
        public void tb_hiyori_newyear_Checked(object sender, RoutedEventArgs args) { cs.hiyori_newyear = true; select_count++; }
        public void tb_hiyori_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori_newyear = false; select_count--; }
        public void tb_yui_newyear_Checked(object sender, RoutedEventArgs args) { cs.yui_newyear = true; select_count++; }
        public void tb_yui_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.yui_newyear = false; select_count--; }
        public void tb_rei_newyear_Checked(object sender, RoutedEventArgs args) { cs.rei_newyear = true; select_count++; }
        public void tb_rei_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.rei_newyear = false; select_count--; }
        public void tb_eriko_valentine_Checked(object sender, RoutedEventArgs args) { cs.eriko_valentine = true; select_count++; }
        public void tb_eriko_valentine_UnChecked(object sender, RoutedEventArgs args) { cs.eriko_valentine = false; select_count--; }
        public void tb_sizuru_valentine_Checked(object sender, RoutedEventArgs args) { cs.sizuru_valentine = true; select_count++; }
        public void tb_sizuru_valentine_UnChecked(object sender, RoutedEventArgs args) { cs.sizuru_valentine = false; select_count--; }
        public void tb_anne_Checked(object sender, RoutedEventArgs args) { cs.anne = true; select_count++; }
        public void tb_anne_UnChecked(object sender, RoutedEventArgs args) { cs.anne = false; select_count--; }
        public void tb_lou_Checked(object sender, RoutedEventArgs args) { cs.lou = true; select_count++; }
        public void tb_lou_UnChecked(object sender, RoutedEventArgs args) { cs.lou = false; select_count--; }
        public void tb_grea_Checked(object sender, RoutedEventArgs args) { cs.grea = true; select_count++; }
        public void tb_grea_UnChecked(object sender, RoutedEventArgs args) { cs.grea = false; select_count--; }
        public void tb_kuuka_ooedo_Checked(object sender, RoutedEventArgs args) { cs.kuuka_ooedo = true; select_count++; }
        public void tb_kuuka_ooedo_UnChecked(object sender, RoutedEventArgs args) { cs.kuuka_ooedo = false; select_count--; }
        public void tb_ninon_ooedo_Checked(object sender, RoutedEventArgs args) { cs.ninon_ooedo = true; select_count++; }
        public void tb_ninon_ooedo_UnChecked(object sender, RoutedEventArgs args) { cs.ninon_ooedo = false; select_count--; }
        public void tb_rem_Checked(object sender, RoutedEventArgs args) { cs.rem = true; select_count++; }
        public void tb_rem_UnChecked(object sender, RoutedEventArgs args) { cs.rem = false; select_count--; }
        public void tb_ram_Checked(object sender, RoutedEventArgs args) { cs.ram = true; select_count++; }
        public void tb_ram_UnChecked(object sender, RoutedEventArgs args) { cs.ram = false; select_count--; }
        public void tb_emilia_Checked(object sender, RoutedEventArgs args) { cs.emilia = true; select_count++; }
        public void tb_emilia_UnChecked(object sender, RoutedEventArgs args) { cs.emilia = false; select_count--; }
        public void tb_suzuna_summer_Checked(object sender, RoutedEventArgs args) { cs.suzuna_summer = true; select_count++; }
        public void tb_suzuna_summer_UnChecked(object sender, RoutedEventArgs args) { cs.suzuna_summer = false; select_count--; }
        public void tb_io_summer_Checked(object sender, RoutedEventArgs args) { cs.io_summer = true; select_count++; }
        public void tb_io_summer_UnChecked(object sender, RoutedEventArgs args) { cs.io_summer = false; select_count--; }
        public void tb_saren_summer_Checked(object sender, RoutedEventArgs args) { cs.saren_summer = true; select_count++; }
        public void tb_saren_summer_UnChecked(object sender, RoutedEventArgs args) { cs.saren_summer = false; select_count--; }
        public void tb_makoto_summer_Checked(object sender, RoutedEventArgs args) { cs.makoto_summer = true; select_count++; }
        public void tb_makoto_summer_UnChecked(object sender, RoutedEventArgs args) { cs.makoto_summer = false; select_count--; }
        public void tb_kaori_summer_Checked(object sender, RoutedEventArgs args) { cs.kaori_summer = true; select_count++; }
        public void tb_kaori_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kaori_summer = false; select_count--; }
        public void tb_maho_summer_Checked(object sender, RoutedEventArgs args) { cs.maho_summer = true; select_count++; }
        public void tb_maho_summer_UnChecked(object sender, RoutedEventArgs args) { cs.maho_summer = false; select_count--; }
        public void tb_aoi_nakayosi_Checked(object sender, RoutedEventArgs args) { cs.aoi_nakayosi = true; select_count++; }
        public void tb_aoi_nakayosi_UnChecked(object sender, RoutedEventArgs args) { cs.aoi_nakayosi = false; select_count--; }
        public void tb_chloe_Checked(object sender, RoutedEventArgs args) { cs.chloe = true; select_count++; }
        public void tb_chloe_UnChecked(object sender, RoutedEventArgs args) { cs.chloe = false; select_count--; }
        public void tb_chieru_Checked(object sender, RoutedEventArgs args) { cs.chieru = true; select_count++; }
        public void tb_chieru_UnChecked(object sender, RoutedEventArgs args) { cs.chieru = false; select_count--; }
        public void tb_kyouka_halloween_Checked(object sender, RoutedEventArgs args) { cs.kyouka_halloween = true; select_count++; }
        public void tb_kyouka_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.kyouka_halloween = false; select_count--; }
        public void tb_misogi_halloween_Checked(object sender, RoutedEventArgs args) { cs.misogi_halloween = true; select_count++; }
        public void tb_misogi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.misogi_halloween = false; select_count--; }
        public void tb_mimi_halloween_Checked(object sender, RoutedEventArgs args) { cs.mimi_halloween = true; select_count++; }
        public void tb_mimi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.mimi_halloween = false; select_count--; }
        public void tb_runa_Checked(object sender, RoutedEventArgs args) { cs.runa = true; select_count++; }
        public void tb_runa_UnChecked(object sender, RoutedEventArgs args) { cs.runa = false; select_count--; }
        public void tb_kristina_christmas_Checked(object sender, RoutedEventArgs args) { cs.kristina_christmas = true; select_count++; }
        public void tb_kristina_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.kristina_christmas = false; select_count--; }
        public void tb_nozomi_christmas_Checked(object sender, RoutedEventArgs args) { cs.nozomi_christmas = true; select_count++; }
        public void tb_nozomi_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.nozomi_christmas = false; select_count--; }
        public void tb_iriya_christmas_Checked(object sender, RoutedEventArgs args) { cs.iriya_christmas = true; select_count++; }
        public void tb_iriya_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.iriya_christmas = false; select_count--; }
        public void tb_kotkoro_newyear_Checked(object sender, RoutedEventArgs args) { cs.kotkoro_newyear = true; select_count++; }
        public void tb_kotkoro_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_newyear = false; select_count--; }
        public void tb_kyaru_newyear_Checked(object sender, RoutedEventArgs args) { cs.kyaru_newyear = true; select_count++; }
        public void tb_kyaru_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_newyear = false; select_count--; }
        public void tb_suzume_newyear_Checked(object sender, RoutedEventArgs args) { cs.suzume_newyear = true; select_count++; }
        public void tb_suzume_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.suzume_newyear = false; select_count--; }
        public void tb_kasumi_magical_Checked(object sender, RoutedEventArgs args) { cs.kasumi_magical = true; select_count++; }
        public void tb_kasumi_magical_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi_magical = false; select_count--; }
        public void tb_siori_magical_Checked(object sender, RoutedEventArgs args) { cs.siori_magical = true; select_count++; }
        public void tb_siori_magical_UnChecked(object sender, RoutedEventArgs args) { cs.siori_magical = false; select_count--; }

        private void tb_uzuki_deremas_Checked(object sender, RoutedEventArgs e) { cs.uzuki_deremas = true; select_count++; }
        public void tb_uzuki_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.uzuki_deremas = false; select_count--; }
        private void tb_mio_deremas_Checked(object sender, RoutedEventArgs e) { cs.mio_deremas = true; select_count++; }
        public void tb_mio_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.mio_deremas = false; select_count--; }
        private void tb_rin_deremas_Checked(object sender, RoutedEventArgs e) { cs.rin_deremas = true; select_count++; }
        public void tb_rin_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.rin_deremas = false; select_count--; }


        private void tb_rin_ranger_Checked(object sender, RoutedEventArgs e) { cs.rin_ranger = true; select_count++; }
        public void tb_rin_ranger_UnChecked(object sender, RoutedEventArgs args) { cs.rin_ranger = false; select_count--; }

        private void tb_mahiru_ranger_Checked(object sender, RoutedEventArgs e) { cs.mahiru_ranger = true; select_count++; }
        public void tb_mahiru_ranger_UnChecked(object sender, RoutedEventArgs args) { cs.mahiru_ranger = false; select_count--; }

        private void tb_rino_wonder_Checked(object sender, RoutedEventArgs e) { cs.rino_wonder = true; select_count++; }
        public void tb_rino_wonder_UnChecked(object sender, RoutedEventArgs args) { cs.rino_wonder = false; select_count--; }

        private void tb_ayumi_wonder_Checked(object sender, RoutedEventArgs e) { cs.ayumi_wonder = true; select_count++; }
        public void tb_ayumi_wonder_UnChecked(object sender, RoutedEventArgs args) { cs.ayumi_wonder = false; select_count--; }

        private void tb_ruka_summer_Checked(object sender, RoutedEventArgs e) { cs.ruka_summer = true; select_count++; }
        public void tb_ruka_summer_UnChecked(object sender, RoutedEventArgs args) { cs.ruka_summer = false; select_count--; }
        private void tb_anna_summer_Checked(object sender, RoutedEventArgs e) { cs.anna_summer = true; select_count++; }
        public void tb_anna_summer_UnChecked(object sender, RoutedEventArgs args) { cs.anna_summer = false; select_count--; }
        private void tb_nanaka_summer_Checked(object sender, RoutedEventArgs e) { cs.nanaka_summer = true; select_count++; }
        public void tb_nanaka_summer_UnChecked(object sender, RoutedEventArgs args) { cs.nanaka_summer = false; select_count--; }
        private void tb_hatsune_summer_Checked(object sender, RoutedEventArgs e) { cs.hatsune_summer = true; select_count++; }
        public void tb_hatsune_summer_UnChecked(object sender, RoutedEventArgs args) { cs.hatsune_summer = false; select_count--; }
        private void tb_misato_summer_Checked(object sender, RoutedEventArgs e) { cs.misato_summer = true; select_count++; }
        public void tb_misato_summer_UnChecked(object sender, RoutedEventArgs args) { cs.misato_summer = false; select_count--; }
        private void tb_zyun_summer_Checked(object sender, RoutedEventArgs e) { cs.zyun_summer = true; select_count++; }
        public void tb_zyun_summer_UnChecked(object sender, RoutedEventArgs args) { cs.zyun_summer = false; select_count--; }
        private void tb_akari_angel_Checked(object sender, RoutedEventArgs e) { cs.akari_angel = true; select_count++; }
        public void tb_akari_angel_UnChecked(object sender, RoutedEventArgs args) { cs.akari_angel = false; select_count--; }
        private void tb_yori_angel_Checked(object sender, RoutedEventArgs e) { cs.yori_angel = true; select_count++; }
        public void tb_yori_angel_UnChecked(object sender, RoutedEventArgs args) { cs.yori_angel = false; select_count--; }

        private void tb_yui_princess_Checked(object sender, RoutedEventArgs e) { cs.yui_princess = true; select_count++; }
        public void tb_yui_princess_UnChecked(object sender, RoutedEventArgs args) { cs.yui_princess = false; select_count--; }
        public void tb_pekorinnu_princess_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu_princess = true; select_count++; }
        public void tb_pekorinnu_princess_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_princess = false; select_count--; }

        public void tb_kotkoro_princess_Checked(object sender, RoutedEventArgs e) { cs.kotkoro_princess = true; select_count++; }
        public void tb_kotkoro_princess_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_princess = false; select_count--; }

        public void tb_yuni_Checked(object sender, RoutedEventArgs e) { cs.yuni = true; select_count++; }
        public void tb_yuni_UnChecked(object sender, RoutedEventArgs args) { cs.yuni = false; select_count--; }

        public void tb_inori_Checked(object sender, RoutedEventArgs e) { cs.inori = true; select_count++; }
        public void tb_inori_UnChecked(object sender, RoutedEventArgs args) { cs.inori = false; select_count--; }
        public void tb_labyrista_Checked(object sender, RoutedEventArgs e) { cs.labyrista = true; select_count++; }
        public void tb_labyrista_UnChecked(object sender, RoutedEventArgs args) { cs.labyrista = false; select_count--; }


        public void tb_tsumugi_halloween_Checked(object sender, RoutedEventArgs e) { cs.tsumugi_halloween = true; select_count++; }
        public void tb_tsumugi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.tsumugi_halloween = false; select_count--; }
        public void tb_rei_halloween_Checked(object sender, RoutedEventArgs e) { cs.rei_halloween = true; select_count++; }
        public void tb_rei_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.rei_halloween = false; select_count--; }
        public void tb_matsuri_halloween_Checked(object sender, RoutedEventArgs e) { cs.matsuri_halloween = true; select_count++; }
        public void tb_matsuri_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.matsuri_halloween = false; select_count--; }
        public void tb_monika_magical_Checked(object sender, RoutedEventArgs e) { cs.monika_magical = true; select_count++; }
        public void tb_monika_magical_UnChecked(object sender, RoutedEventArgs args) { cs.monika_magical = false; select_count--; }
        public void tb_tomo_magical_Checked(object sender, RoutedEventArgs e) { cs.tomo_magical = true; select_count++; }
        public void tb_tomo_magical_UnChecked(object sender, RoutedEventArgs args) { cs.tomo_magical = false; select_count--; }
        public void tb_shepi_Checked(object sender, RoutedEventArgs e) { cs.shepi = true; select_count++; }
        public void tb_shepi_UnChecked(object sender, RoutedEventArgs args) { cs.shepi = false; select_count--; }
        public void tb_akino_christmas_Checked(object sender, RoutedEventArgs e) { cs.akino_christmas = true; select_count++; }
        public void tb_akino_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.akino_christmas = false; select_count--; }
        public void tb_saren_christmas_Checked(object sender, RoutedEventArgs e) { cs.saren_christmas = true; select_count++; }
        public void tb_saren_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.saren_christmas = false; select_count--; }
        public void tb_yukari_christmas_Checked(object sender, RoutedEventArgs e) { cs.yukari_christmas = true; select_count++; }
        public void tb_yukari_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.yukari_christmas = false; select_count--; }
        public void tb_muimi_newyear_Checked(object sender, RoutedEventArgs e) { cs.muimi_newyear = true; select_count++; }
        public void tb_muimi_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.muimi_newyear = false; select_count--; }
        public void tb_neneka_newyear_Checked(object sender, RoutedEventArgs e) { cs.neneka_newyear = true; select_count++; }
        public void tb_neneka_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.neneka_newyear = false; select_count--; }
        public void tb_pekorinnu_newyear_Checked(object sender, RoutedEventArgs e) { cs.pekorinnu_newyear = true; select_count++; }
        public void tb_pekorinnu_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_newyear = false; select_count--; }
        public void tb_kotkoro_maiden_Checked(object sender, RoutedEventArgs e) { cs.kotkoro_maiden = true; select_count++; }
        public void tb_kotkoro_maiden_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_maiden = false; select_count--; }
        public void tb_yui_maiden_Checked(object sender, RoutedEventArgs e) { cs.yui_maiden = true; select_count++; }
        public void tb_yui_maiden_UnChecked(object sender, RoutedEventArgs args) { cs.yui_maiden = false; select_count--; }
        public void tb_kasumi_summer_Checked(object sender, RoutedEventArgs e) { cs.kasumi_summer = true; select_count++; }
        public void tb_kasumi_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi_summer = false; select_count--; }
        public void tb_rima_cinderella_Checked(object sender, RoutedEventArgs e) { cs.rima_cinderella = true; select_count++; }
        public void tb_rima_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.rima_cinderella = false; select_count--; }
        public void tb_makoto_cinderella_Checked(object sender, RoutedEventArgs e) { cs.makoto_cinderella = true; select_count++; }
        public void tb_makoto_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.makoto_cinderella = false; select_count--; }
        public void tb_maho_cinderella_Checked(object sender, RoutedEventArgs e) { cs.maho_cinderella = true; select_count++; }
        public void tb_maho_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.maho_cinderella = false; select_count--; }
        public void tb_chloe_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.chloe_nakayosi2 = true; select_count++; }
        public void tb_chloe_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.chloe_nakayosi2 = false; select_count--; }
        public void tb_chieru_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.chieru_nakayosi2 = true; select_count++; }
        public void tb_chieru_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.chieru_nakayosi2 = false; select_count--; }
        public void tb_yuni_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.yuni_nakayosi2 = true; select_count++; }
        public void tb_yuni_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.yuni_nakayosi2 = false; select_count--; }
        public void tb_inori_timetravel_Checked(object sender, RoutedEventArgs e) { cs.inori_timetravel = true; select_count++; }
        public void tb_inori_timetravel_UnChecked(object sender, RoutedEventArgs args) { cs.inori_timetravel = false; select_count--; }
        public void tb_kaya_timetravel_Checked(object sender, RoutedEventArgs e) { cs.kaya_timetravel = true; select_count++; }
        public void tb_kaya_timetravel_UnChecked(object sender, RoutedEventArgs args) { cs.kaya_timetravel = false; select_count--; }
        public void tb_aoi_worker_Checked(object sender, RoutedEventArgs e) { cs.aoi_worker = true; select_count++; }
        public void tb_aoi_worker_UnChecked(object sender, RoutedEventArgs args) { cs.aoi_worker = false; select_count--; }
        public void tb_tamaki_worker_Checked(object sender, RoutedEventArgs e) { cs.tamaki_worker = true; select_count++; }
        public void tb_tamaki_worker_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki_worker = false; select_count--; }
        public void tb_mihuyu_worker_Checked(object sender, RoutedEventArgs e) { cs.mihuyu_worker = true; select_count++; }
        public void tb_mihuyu_worker_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu_worker = false; select_count--; }
        public void tb_hiyori_princess_Checked(object sender, RoutedEventArgs e) { cs.hiyori_princess = true; select_count++; }
        public void tb_hiyori_princess_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori_princess = false; select_count--; }
        public void tb_kyaru_princess_Checked(object sender, RoutedEventArgs e) { cs.kyaru_princess = true; select_count++; }
        public void tb_kyaru_princess_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_princess = false; select_count--; }

        #endregion
        private void UnCheckAll()
        {            
            tb_akari.IsChecked = false;
            tb_akino.IsChecked = false;
            tb_anna.IsChecked = false;
            tb_anne.IsChecked = false;
            tb_aoi.IsChecked = false;
            tb_aoi_nakayosi.IsChecked = false;
            tb_arisa.IsChecked = false;
            tb_ayane.IsChecked = false;
            tb_ayane_christmas.IsChecked = false;
            tb_ayumi.IsChecked = false;
            tb_chika.IsChecked = false;
            tb_chika_christmas.IsChecked = false;
            tb_chloe.IsChecked = false;
            tb_chieru.IsChecked = false;
            tb_emilia.IsChecked = false;
            tb_eriko.IsChecked = false;
            tb_eriko_valentine.IsChecked = false;
            tb_grea.IsChecked = false;
            tb_hatsune.IsChecked = false;
            tb_hiyori.IsChecked = false;
            tb_hiyori_newyear.IsChecked = false;
            tb_io.IsChecked = false;
            tb_io_summer.IsChecked = false;
            tb_iriya.IsChecked = false;
            tb_iriya_christmas.IsChecked = false;
            tb_kaori.IsChecked = false;
            tb_kaori_summer.IsChecked = false;
            tb_kasumi.IsChecked = false;
            tb_kasumi_magical.IsChecked = false;
            tb_kaya.IsChecked = false;
            tb_kotkoro.IsChecked = false;
            tb_kotkoro_newyear.IsChecked = false;
            tb_kotkoro_summer.IsChecked = false;
            tb_kristina.IsChecked = false;
            tb_kristina_christmas.IsChecked = false;
            tb_kurumi.IsChecked = false;
            tb_kurumi_christmas.IsChecked = false;
            tb_kuuka.IsChecked = false;
            tb_kuuka_ooedo.IsChecked = false;
            tb_kyaru.IsChecked = false;
            tb_kyaru_newyear.IsChecked = false;
            tb_kyaru_summer.IsChecked = false;
            tb_kyouka.IsChecked = false;
            tb_kyouka_halloween.IsChecked = false;
            tb_lou.IsChecked = false;
            tb_mahiru.IsChecked = false;
            tb_maho.IsChecked = false;
            tb_maho_summer.IsChecked = false;
            tb_makoto.IsChecked = false;
            tb_makoto_summer.IsChecked = false;
            tb_matsuri.IsChecked = false;
            tb_mihuyu.IsChecked = false;
            tb_mihuyu_summer.IsChecked = false;
            tb_mimi.IsChecked = false;
            tb_mimi_halloween.IsChecked = false;
            tb_misaki.IsChecked = false;
            tb_misaki_halloween.IsChecked = false;
            tb_misato.IsChecked = false;
            tb_misogi.IsChecked = false;
            tb_misogi_halloween.IsChecked = false;
            tb_mitsuki.IsChecked = false;
            tb_miyako.IsChecked = false;
            tb_miyako_halloween.IsChecked = false;
            tb_monika.IsChecked = false;
            tb_muimi.IsChecked = false;
            tb_nanaka.IsChecked = false;
            tb_neneka.IsChecked = false;
            tb_ninon.IsChecked = false;
            tb_ninon_ooedo.IsChecked = false;
            tb_nozomi.IsChecked = false;
            tb_nozomi_christmas.IsChecked = false;
            tb_pekorinnu.IsChecked = false;
            tb_pekorinnu_princess.IsChecked = false;
            tb_pekorinnu_summer.IsChecked = false;
            tb_ram.IsChecked = false;
            tb_rei.IsChecked = false;
            tb_rei_newyear.IsChecked = false;
            tb_rem.IsChecked = false;
            tb_rima.IsChecked = false;
            tb_rin.IsChecked = false;
            tb_rino.IsChecked = false;
            tb_ruka.IsChecked = false;
            tb_runa.IsChecked = false;
            tb_saren.IsChecked = false;
            tb_saren_summer.IsChecked = false;
            tb_sinobu.IsChecked = false;
            tb_sinobu_halloween.IsChecked = false;
            tb_siori.IsChecked = false;
            tb_siori_magical.IsChecked = false;
            tb_sizuru.IsChecked = false;
            tb_sizuru_valentine.IsChecked = false;
            tb_suzume.IsChecked = false;
            tb_suzume_newyear.IsChecked = false;
            tb_suzume_summer.IsChecked = false;
            tb_suzuna.IsChecked = false;
            tb_suzuna_summer.IsChecked = false;
            tb_tamaki.IsChecked = false;
            tb_tamaki_summer.IsChecked = false;
            tb_tomo.IsChecked = false;
            tb_tsumugi.IsChecked = false;
            tb_yori.IsChecked = false;
            tb_yui.IsChecked = false;
            tb_yui_newyear.IsChecked = false;
            tb_yukari.IsChecked = false;
            tb_yuki.IsChecked = false;
            tb_zita.IsChecked = false;
            tb_zyun.IsChecked = false;

            tb_mio_deremas.IsChecked = false;
            tb_uzuki_deremas.IsChecked = false;
            tb_rin_deremas.IsChecked = false;
            tb_rin_ranger.IsChecked = false;
            tb_mahiru_ranger.IsChecked = false;
            tb_rino_wonder.IsChecked = false;
            tb_ayumi_wonder.IsChecked = false;
            tb_ruka_summer.IsChecked = false;
            tb_anna_summer.IsChecked = false;
            tb_zyun_summer.IsChecked = false;
            tb_hatsune_summer.IsChecked = false;
            tb_kotkoro_princess.IsChecked = false;
            tb_nanaka_summer.IsChecked = false;
            tb_misato_summer.IsChecked = false;
            tb_kotkoro_princess.IsChecked = false;
            tb_yui_princess.IsChecked = false;
            tb_akari_angel.IsChecked = false;
            tb_yori_angel.IsChecked = false;
            tb_yuni.IsChecked = false;
            tb_inori.IsChecked = false;
            tb_yori_angel.IsChecked = false;
            tb_tsumugi_halloween.IsChecked = false;
            tb_rei_halloween.IsChecked = false;
            tb_matsuri_halloween.IsChecked = false;
            tb_monika_magical.IsChecked = false;
            tb_tomo_magical.IsChecked = false;
            tb_shepi.IsChecked = false;
            tb_labyrista.IsChecked = false;
            tb_hiyori_princess.IsChecked = false;
            tb_kyaru_princess.IsChecked = false;
            tb_akino_christmas.IsChecked = false;
            tb_saren_christmas.IsChecked = false;
            tb_yukari_christmas.IsChecked = false;
            tb_muimi_newyear.IsChecked = false;
            tb_neneka_newyear.IsChecked = false;
            tb_pekorinnu_newyear.IsChecked = false;
            tb_kotkoro_maiden.IsChecked = false;
            tb_yui_maiden.IsChecked = false;
            tb_kasumi_summer.IsChecked = false;
            tb_rima_cinderella.IsChecked = false;
            tb_maho_cinderella.IsChecked = false;
            tb_makoto_cinderella.IsChecked = false;
            tb_chloe_nakayosi2.IsChecked = false;
            tb_chieru_nakayosi2.IsChecked = false;
            //tb_yuni_nakayosi2.IsChecked = false;
            tb_inori_timetravel.IsChecked = false;
            tb_kaya_timetravel.IsChecked = false;
            tb_aoi_worker.IsChecked = false;
            tb_tamaki_worker.IsChecked = false;
            //tb_mihuyu_worker.IsChecked = false;
            //tb_.IsChecked = false;

            tb_CharaAbbr.Text = "";
        }
        private void bt_set_Def_Click(object sender, RoutedEventArgs e)
        {
            if (tb_CharaAbbr.Text == "")
            {

                select_count_temp = 0;

                Debug.Write("select_count = ");
                Debug.WriteLine(select_count);
                isFindOffReady = false;
                if (select_count <= 5)
                {
                    CharacterSelectCount(1);

                    #region save

                    if (select_count_temp == 5)
                    {

                        Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                        Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                        Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                        Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();


                        string[] temp = new string[10];
                        temp = CharaSort(select_defence_temp_eng, select_defence_temp);

                        #endregion

                        /*
                        select_count = select_count_temp;
                        select_defence = select_defence_temp;
                        select_defence_eng = select_defence_temp_eng;
                                            */
                        select_count = select_count_temp;

                        for (int i = 0; i < 5; i++)
                        {
                            select_defence[i] = temp[i + 5];
                            select_defence_eng[i] = temp[i];
                            Debug.Write(select_defence[i] + ",");
                            Debug.WriteLine(select_defence_eng[i] + ",");
                        }
                        LoadDefDeck();

                        isDefDeckReady = true;

                        MessageBox.Show("방덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp[0], select_defence_temp[1], select_defence_temp[2], select_defence_temp[3], select_defence_temp[4]);
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp_eng[0], select_defence_temp_eng[1], select_defence_temp_eng[2], select_defence_temp_eng[3], select_defence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_defence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[4 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[4 - i]));
                            Debug.WriteLine(" ");
                        }
                        Debug.WriteLine(string.Format("{0:F2}", power_sum_def));

#endif
                        ShowDefCharas(select_defence_temp_eng);
                        SetDefPower((int)power_sum_def);

                        UnCheckAll();
                    }
                    else if (select_count_temp != 5)
                    {
                        //Debug.WriteLine("\n덱을 5명으로 구성해야 합니다");
                        MessageBox.Show("5명으로 구성해야 합니다", "알림");
                    }
                }

                else
                {
                    // Debug.WriteLine("\n덱에 5명 이상 넣을 수 없습니다");
                    MessageBox.Show("5명 이상 넣을 수 없습니다", "알림");
                }
            }
            else
            {
                SetDeckWithAbbr(tb_CharaAbbr.Text, 1);
                
                /*
                try
                {
                    string s = tb_CharaAbbr.Text;

                    int numCharacter = 0;
                    int numCharaAbbr = 0;
                    char[] charArr = s.ToCharArray();

                    foreach (char c in charArr)
                    {
                        if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                        {
                            Debug.WriteLine("한글입니다");
                            numCharacter++;
                        }
                    }                    
                    if (numCharacter == 5)
                    {
                        Debug.WriteLine(tb_CharaAbbr.Text.Length);
                        Debug.WriteLine(tb_CharaAbbr.Text);
                        Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                        Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                        Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                        Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();
                        string tempAbbr = tb_CharaAbbr.Text;

                        string[] temp = new string[5];
                        string[] temp2 = new string[5];
                        string[] temp3 = new string[10];
                        for (int i = 0; i < 5; i++)
                        {
                            temp[i] = AbbrToChara(Convert.ToString(tempAbbr[i]));
                            Debug.WriteLine(string.Format("temp[{0}] = {1}", i, temp[i]));
                            if (temp[i] != "")
                                numCharaAbbr++;
                            temp2[i] = IDtoCharaKorName(CharaNameToID(temp[i]));
                            Debug.WriteLine(string.Format("temp2[{0}] = {1}", i, temp2[i]));
                        }

                        if(numCharaAbbr == 5)
                        {
                            temp3 = CharaSort(temp, temp2);
#if DEBUG
                            for (int i = 0; i < 10; i++)
                                Debug.WriteLine(temp3[i]);
#endif

                            select_count = select_count_temp;

                            for (int i = 0; i < 5; i++)
                            {
                                select_defence[i] = temp3[i + 5];
                                select_defence_temp[i] = temp3[i + 5];
                                select_defence_eng[i] = temp3[i];
                                select_defence_temp_eng[i] = temp3[i];
                            }
                            LoadDefDeck();

                            isDefDeckReady = true;

                            MessageBox.Show("방덱이 저장되었습니다", "알림");
#if DEBUG
                            Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp[0], select_defence_temp[1], select_defence_temp[2], select_defence_temp[3], select_defence_temp[4]);
                            Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp_eng[0], select_defence_temp_eng[1], select_defence_temp_eng[2], select_defence_temp_eng[3], select_defence_temp_eng[4]);

                            for (int i = 0; i < 5; i++)
                            {
                                Debug.WriteLine(select_defence[4 - i]);
                                Debug.WriteLine(string.Format("{0}", Level_variable.Lv[4 - i]));
                                Debug.WriteLine(string.Format("{0}", Level_variable.star[4 - i]));
                                Debug.WriteLine(string.Format("{0}", Level_variable.Rank[4 - i]));
                                Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[4 - i]));
                                Debug.WriteLine(" ");
                            }
                            Debug.WriteLine(string.Format("{0:F2}", power_sum_def));
#endif
                            SetDefPower((int)power_sum_def);
                            ShowDefCharas(select_defence_temp_eng);

                            UnCheckAll();
                        }
                        else
                        {
                            MessageBox.Show("다시 입력하세요", "알림");
                            tb_CharaAbbr.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("5명으로 입력하세요", "알림");
                        tb_CharaAbbr.Text = "";
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message, "알림");
                }
                */
            }
        }
        private string[] CharaSort(string[] deckEN, string[] deckKR)
        {
            Character_range_and_cast crc = new Character_range_and_cast();
            string[] result = new string[10];

            for (int i = 0; i < 4; i++)
            {
                double sort1 = 0;
                double sort2 = 0;

                FieldInfo dummy1 = crc.GetType().GetField(deckEN[i], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(crc);
                sort1 = array1[1];

                FieldInfo dummy2 = crc.GetType().GetField(deckEN[i + 1], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if(dummy2 != null)
                {
                    double[] array2 = (double[])dummy2.GetValue(crc);
                    sort2 = array2[1];
                }
                else
                {
                    //MessageBox.Show("ㅈ망", "알림");
                    return null;
                }                

                if (sort1 < sort2)
                {
                    string dummy, dummy_eng;
                    dummy = deckKR[i];
                    deckKR[i] = deckKR[i + 1];
                    deckKR[i + 1] = dummy;

                    dummy_eng = deckEN[i];
                    deckEN[i] = deckEN[i + 1];
                    deckEN[i + 1] = dummy_eng;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                double sort1 = 0;
                double sort2 = 0;

                FieldInfo dummy1 = crc.GetType().GetField(deckEN[i], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(crc);
                sort1 = array1[1];

                FieldInfo dummy2 = crc.GetType().GetField(deckEN[i + 1], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (dummy2 != null)
                {
                    double[] array2 = (double[])dummy2.GetValue(crc);
                    sort2 = array2[1];
                }
                else
                {
                    //MessageBox.Show("ㅈ망", "알림");
                    return null;
                }
                if (sort1 < sort2)
                {
                    string dummy, dummy_eng;
                    dummy = deckKR[i];
                    deckKR[i] = deckKR[i + 1];
                    deckKR[i + 1] = dummy;

                    dummy_eng = deckEN[i];
                    deckEN[i] = deckEN[i + 1];
                    deckEN[i + 1] = dummy_eng;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                double sort1 = 0;
                double sort2 = 0;

                FieldInfo dummy1 = crc.GetType().GetField(deckEN[i], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(crc);
                sort1 = array1[1];

                FieldInfo dummy2 = crc.GetType().GetField(deckEN[i + 1], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (dummy2 != null)
                {
                    double[] array2 = (double[])dummy2.GetValue(crc);
                    sort2 = array2[1];
                }
                else
                {
                    //MessageBox.Show("ㅈ망", "알림");
                    return null;
                }
                if (sort1 < sort2)
                {
                    string dummy, dummy_eng;
                    dummy = deckKR[i];
                    deckKR[i] = deckKR[i + 1];
                    deckKR[i + 1] = dummy;

                    dummy_eng = deckEN[i];
                    deckEN[i] = deckEN[i + 1];
                    deckEN[i + 1] = dummy_eng;
                }
            }
            for (int i = 0; i < 1; i++)
            {
                double sort1 = 0;
                double sort2 = 0;

                FieldInfo dummy1 = crc.GetType().GetField(deckEN[i], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(crc);
                sort1 = array1[1];

                FieldInfo dummy2 = crc.GetType().GetField(deckEN[i + 1], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                
                if (dummy2 != null)
                {
                    double[] array2 = (double[])dummy2.GetValue(crc);
                    sort2 = array2[1];
                }
                else
                {
                   // MessageBox.Show("ㅈ망", "알림");
                    return null;
                }
                if (sort1 < sort2)
                {
                    string dummy, dummy_eng;
                    dummy = deckKR[i];
                    deckKR[i] = deckKR[i + 1];
                    deckKR[i + 1] = dummy;

                    dummy_eng = deckEN[i];
                    deckEN[i] = deckEN[i + 1];
                    deckEN[i + 1] = dummy_eng;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                result[i] = deckEN[i];
                result[i + 5] = deckKR[i];
            }
            return result;
        }
        private void bt_reset_Def_Click(object sender, RoutedEventArgs e)
        {
            select_count_temp = 0;
            //select_count = 0;
            select_defence_temp = new string[15]{ "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            select_defence_temp_eng = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            tb_CharaAbbr.Text = "";
            isFindOffReady = false;
            isDefDeckReady = false;
            ib_defChara1.Opacity = 0.0;
            ib_defChara2.Opacity = 0.0;
            ib_defChara3.Opacity = 0.0;
            ib_defChara4.Opacity = 0.0;
            ib_defChara5.Opacity = 0.0;
            tB_def_power.Text = "";
            UnCheckAll();
            MessageBox.Show("방덱을 초기화했습니다", "알림");
#if DEBUG
            Debug.WriteLine("현재 선택된 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp[0], select_defence_temp[1], select_defence_temp[2], select_defence_temp[3], select_defence_temp[4]);
#endif

        }

        private void bt_set_Off_Click(object sender, RoutedEventArgs e)
        {
            if(tb_CharaAbbr.Text == "")
            {
                select_count_temp = 0;
                Debug.Write("select_count = ");
                Debug.WriteLine(select_count);
                isFindOffReady = false;
                if (select_count <= 5)
                {
                    CharacterSelectCount(0);

                    #region save

                    if (select_count_temp == 5)
                    {
                        Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                        Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                        Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                        Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                        Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                        Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();

                        #region SortCharacter

                        string[] temp = new string[10];
                        temp = CharaSort(select_offence_temp_eng, select_offence_temp);

#if DEBUG
                        for (int i = 0; i < 10; i++)
                            Debug.WriteLine(temp[i]);
#endif

                        select_count = select_count_temp;

                        for (int i = 0; i < 5; i++)
                        {
                            select_offence[i] = temp[i + 5];
                            select_offence_eng[i] = temp[i];
                        }
                        LoadOffDeck();
                        #endregion

                        #endregion

                        isOffDeckReady = true;

                        MessageBox.Show("공덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp[0], select_offence_temp[1], select_offence_temp[2], select_offence_temp[3], select_offence_temp[4]);
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp_eng[0], select_offence_temp_eng[1], select_offence_temp_eng[2], select_offence_temp_eng[3], select_offence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_offence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[19 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[19 - i]));
                            Debug.WriteLine(" ");
                        }
                        Debug.WriteLine(string.Format("{0:F2}", power_sum_off));
#endif
                        SetOffPower((int)power_sum_off);
                        ShowOffCharas(select_offence_temp_eng);

                        UnCheckAll();
                    }
                    else if (select_count_temp != 5)
                    {
                        //Debug.WriteLine("\n덱을 5명으로 구성해야 합니다");
                        MessageBox.Show("5명으로 구성해야 합니다", "알림");
                    }
                }
                else
                {
                    // Debug.WriteLine("\n덱에 5명 이상 넣을 수 없습니다");
                    MessageBox.Show("5명 이상 넣을 수 없습니다", "알림");
                }
            }
            else
            {
                SetDeckWithAbbr(tb_CharaAbbr.Text, 0);
            }
        }
        private void bt_reset_Off_Click(object sender, RoutedEventArgs e)
        {
            select_count_temp = 0;
            select_count = 0;
            select_offence_temp = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            select_offence_temp_eng = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            tb_CharaAbbr.Text = "";
            isFindOffReady = false;
            isOffDeckReady = false;
            tB_off_power.Text = "";
            ib_offChara1.Opacity = 0.0;
            ib_offChara2.Opacity = 0.0;
            ib_offChara3.Opacity = 0.0;
            ib_offChara4.Opacity = 0.0;
            ib_offChara5.Opacity = 0.0;
            UnCheckAll();
            MessageBox.Show("공덱을 초기화했습니다", "알림");
#if DEBUG
            Debug.WriteLine("현재 선택된 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp[0], select_offence_temp[1], select_offence_temp[2], select_offence_temp[3], select_offence_temp[4]);
#endif
        }

        /*
        private void bt_Find_Off_Click(object sender, RoutedEventArgs e)
        {
            select_count_temp = 0;
            //MessageBox.Show("준비중이야!", "알림");

            if (isDefDeckReady)
            {
                Debug.WriteLine("0-select_count = {0} ", select_count);
                Debug.WriteLine("0-select_count_temp = {0}", select_count_temp);
                if (select_count >= 3 && select_count < 5)
                {
                    CharacterSelectCount(0);

                    myFlowDoc.Blocks.Add(new Paragraph(new Run("")));
                    myFlowDoc.Blocks.Clear();
                    RTxtbox_Logbox.Document = myFlowDoc;

                    Debug.WriteLine("1-select_count = {0} ", select_count);
                    Debug.WriteLine("1-select_count_temp = {0}", select_count_temp);

                    string[] tempX = select_offence_temp;

                    FindPick.Clear();
                    FindPick_temp.Clear();

                    Debug.WriteLine("선택된 캐릭터");
                    for (int x = 0; x < select_count_temp; x++)
                    {
                        FindPick.Add(select_offence_temp[x]);
                        FindPick_temp.Add(select_offence_temp[x]);
                        Debug.WriteLine("{0} : {1} ", x, FindPick_temp[x]);
                    }

                    //select_offence_temp [0] [1] [2] ([3]) 에 들어가있음 
                    int i = 0;
                    List<int> AlreadySelectedCharaIndexList = new List<int>();

                    //Debug.WriteLine("available Characters List");
                    i = 0;
                    while (AvailableCharaList[i] != null)
                    {
                        //사용가능한 캐릭터들 중 선택되지 않은 캐릭터들의 인덱스를 저장
                        if (FindPick_temp.Contains(AvailableCharaList[i]) == false)
                            AlreadySelectedCharaIndexList.Add(i);

                        i++;
                    }

                    i = 0;

                    Debug.WriteLine("AlreadySelectedCharaIndexList");
                    for (int ix = 0; ix < AlreadySelectedCharaIndexList.Count; ix++)
                        Debug.WriteLine(AlreadySelectedCharaIndexList[ix]);


                    numParty = Convert.ToInt32(Combination.Choose(AlreadySelectedCharaIndexList.Count, 5 - select_count));
                    FoundPick_KR = new string[numParty][];
                    FoundPick_EN = new string[numParty][];

                    for (int j = 0; j < numParty; j++)
                    {
                        //Debug.WriteLine(AlreadySelectedCharaIndexList[j]);
                        FoundPick_KR[j] = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                        FoundPick_EN[j] = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    }

                    if (select_count_temp == 3)
                    {
                        Combination c = new Combination(AlreadySelectedCharaIndexList.Count, 5 - select_count_temp);

                        while (c != null)
                        {
                            //Debug.WriteLine(c.ToString());
                            string cs = c.ToString();
                            string[] numStr = cs.Split(' ');
                            Debug.WriteLine("{0}, {1}", numStr[0], numStr[1]);
                            Debug.WriteLine("{0}, {1}", AvailableCharaList[Convert.ToInt32(numStr[0])], AvailableCharaList[Convert.ToInt32(numStr[1])]);

                            //System.Collections.Generic.List<string> tempList = new System.Collections.Generic.List<string>();
                            //tempList.Add(AvailableCharaList[Convert.ToInt32(numStr[0])]);
                            //tempList.Add(AvailableCharaList[Convert.ToInt32(numStr[1])]);
                            FoundPick_KR[i][0] = select_offence_temp[0];
                            FoundPick_KR[i][1] = select_offence_temp[1];
                            FoundPick_KR[i][2] = select_offence_temp[2];
                            FoundPick_KR[i][3] = AvailableCharaList[AlreadySelectedCharaIndexList[Convert.ToInt32(numStr[0])]];
                            FoundPick_KR[i][4] = AvailableCharaList[AlreadySelectedCharaIndexList[Convert.ToInt32(numStr[1])]];

                            FoundPick_EN[i][0] = CharaName_KRtoEN(select_offence_temp[0]);
                            FoundPick_EN[i][1] = CharaName_KRtoEN(select_offence_temp[1]);
                            FoundPick_EN[i][2] = CharaName_KRtoEN(select_offence_temp[2]);
                            FoundPick_EN[i][3] = CharaName_KRtoEN(FoundPick_KR[i][3]);
                            FoundPick_EN[i][4] = CharaName_KRtoEN(FoundPick_KR[i][4]);

                            string[] tempY = new string[10];

                            tempY = CharaSort(FoundPick_EN[i], FoundPick_KR[i]);

                            for (int z = 0; z < 5; z++)
                            {
                                FoundPick_KR[i][z] = tempY[z + 5];
                                FoundPick_EN[i][z] = tempY[z];
                            }

                            //Debug.Write("찾은 캐릭터: ");
                            for (int l = 0; l < 5; l++)
                            {
                                Debug.Write("{0} ", FoundPick_KR[i][l]);
                                WriteLog(string.Format("{0} ", FoundPick_KR[i][l]));
                            }

                            for (int l = 0; l < 5; l++)
                            {
                                Debug.Write("{0} ", FoundPick_EN[i][l]);
                                //WriteLog(string.Format("{0} ", FoundPick_KR[i][l]));
                            }
                            //Debug.WriteLine("");
                            WriteLog("\n");
                            c = c.Successor();

                            i++;

                        }
                        i = 0;

                        Debug.WriteLine("파티 수 : {0}", FoundPick_KR.Length);
                        myFlowDoc.Blocks.Add(new Paragraph(new Run(LogString)));
                        RTxtbox_Logbox.Document = myFlowDoc;

                        LogString = "";
                        isOffDeckReady = true;
                        isFindOffReady = true;

                    }

                    else if (select_count_temp == 4)
                    {
                        Combination c = new Combination(AlreadySelectedCharaIndexList.Count, 5 - select_count_temp);

                        while (c != null)
                        {
                            string cs = c.ToString();

                            Debug.WriteLine(String.Format("cs = {0}", cs));
                            Debug.WriteLine(String.Format("AvailableCharaList[{0}] = {1}", cs, AvailableCharaList[Convert.ToInt32(cs)]));
                            Debug.WriteLine(String.Format("AvailableCharaList[AlreadySelectedCharaIndexList[{0}]] = {1}", cs, AvailableCharaList[AlreadySelectedCharaIndexList[Convert.ToInt32(cs)]]));
                            //string[] numStr = cs.Split(' ');
                            //Debug.WriteLine("{0}, {1}", numStr[0], numStr[1]);
                            //Debug.WriteLine("{0}, {1}", AvailableCharaList[Convert.ToInt32(numStr[0])], AvailableCharaList[Convert.ToInt32(numStr[1])]);

                            //System.Collections.Generic.List<string> tempList = new System.Collections.Generic.List<string>();
                            //tempList.Add(AvailableCharaList[Convert.ToInt32(numStr[0])]);
                            //tempList.Add(AvailableCharaList[Convert.ToInt32(numStr[1])]);
                            FoundPick_KR[i][0] = select_offence_temp[0];
                            FoundPick_KR[i][1] = select_offence_temp[1];
                            FoundPick_KR[i][2] = select_offence_temp[2];
                            FoundPick_KR[i][3] = select_offence_temp[3];
                            FoundPick_KR[i][4] = AvailableCharaList[AlreadySelectedCharaIndexList[Convert.ToInt32(cs)]];

                            FoundPick_EN[i][0] = CharaName_KRtoEN(select_offence_temp[0]);
                            FoundPick_EN[i][1] = CharaName_KRtoEN(select_offence_temp[1]);
                            FoundPick_EN[i][2] = CharaName_KRtoEN(select_offence_temp[2]);
                            FoundPick_EN[i][3] = CharaName_KRtoEN(select_offence_temp[3]);
                            FoundPick_EN[i][4] = CharaName_KRtoEN(FoundPick_KR[i][4]);

                            string[] tempZ = new string[10];

                            tempZ = CharaSort(FoundPick_EN[i], FoundPick_KR[i]);

                            for (int z = 0; z < 5; z++)
                            {
                                FoundPick_KR[i][z] = tempZ[z + 5];
                                FoundPick_EN[i][z] = tempZ[z];
                            }

                            //Debug.Write("찾은 캐릭터: ");
                            for (int l = 0; l < 5; l++)
                            {
                                Debug.Write(string.Format("{0},", FoundPick_KR[i][l]));
                                MainWindow.WriteLog(string.Format("{0},", FoundPick_KR[i][l]));
                            }
                            Debug.WriteLine(""); for (int l = 0; l < 5; l++)
                            {
                                // Debug.Write(string.Format("{0},", FoundPick_EN[i][l]));
                                //MainWindow.WriteLog(string.Format("{0},", FoundPick_KR[i][l]));
                            }
                            Debug.WriteLine("");
                            MainWindow.WriteLog(string.Format("\n"));
                            c = c.Successor();
                            i++;
                        }
                        i = 0;

                        //Debug.WriteLine("파티 수 : {0}", FoundPick_KR.Length);

                        myFlowDoc.Blocks.Add(new Paragraph(new Run(LogString)));
                        RTxtbox_Logbox.Document = myFlowDoc;

                        LogString = "";

                    }
                    else
                        MessageBox.Show("<", "알림");


                    isOffDeckReady = true;
                    isFindOffReady = true;



                    ShowOffCharas(select_offence_temp_eng);
                    SetOffPower(1);

                    //select_count = select_count_temp;
                    UnCheckAll();

                    Debug.WriteLine("z-select_count = {0} ", select_count);
                    Debug.WriteLine("z-select_count_temp = {0}", select_count_temp);

                    MessageBox.Show(string.Format("파티 목록이 생성되었습니다\n 파티 수: {0}", FoundPick_KR.Length), "알림");

                    Debug.WriteLine(string.Format("파티 목록이 생성되었습니다\n 파티 수: {0}", FoundPick_KR.Length));

                    int __max_repeat = FoundPick_KR.Length;


                    int def_count2 = 0, off_count2 = 0, def_timecount2 = 0;

                    int[] result3 = new int[__max_repeat];

                    Debug.WriteLine("ProcessorCount = {0}", Environment.ProcessorCount);

                    //ConcurrentBag 사용
                    var parallelOptions = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = Environment.ProcessorCount - 1
                    };

                    string[][] RealFindParty = new string[__max_repeat][];

                    for (int ix3 = 0; ix3 < __max_repeat; ix3++)
                    {
                        RealFindParty[ix3] = new string[5];
                    }

                    Sim[] simul2 = new Sim[__max_repeat];
                    int[] resultx = new int[__max_repeat];

                    for (int idx2 = 0; idx2 < __max_repeat; idx2++)
                    {
                        Debug.WriteLine(String.Format("idx2 = {0}", idx2));

                        simul2[idx2] = new Sim();
                        Debug.WriteLine("Sim OK");

                        LoadOffDeckFind(FoundPick_KR[idx2], FoundPick_EN[idx2]);
                        Debug.WriteLine("Find OK");

                        simul2[idx2].Bv_battle_initialize(FoundPick_KR[idx2], FoundPick_EN[idx2]);
                        Debug.WriteLine("BV battle initialize OK");
                    }

                    Debug.WriteLine("Sim classes Initialize OK");

                    System.Collections.Concurrent.ConcurrentBag<int> resultCollection = new System.Collections.Concurrent.ConcurrentBag<int>();
                    ParallelLoopResult result = Parallel.For(0, __max_repeat, parallelOptions, (ix) =>
                    {
                        //resultx[ix] = simul[ix]._Sim_Start(__max_repeat);
                        //resultCollection.Add(resultx[ix]);
                        //resultCollection.Add(simul2[ix]._Sim_Start(__max_repeat));
                        resultCollection.Add(simul2[ix]._Sim_Start(__max_repeat));
                        //Debug.WriteLine("{0}: {1}, result = {2} ", System.Threading.Thread.CurrentThread.ManagedThreadId, ix, resultx[ix]);

                    });
#if DEBUG
                    Debug.WriteLine("IsCompleted: {0}", result.IsCompleted);
#endif
                    result3 = resultCollection.ToArray();

                    Debug.WriteLine(resultCollection);
                    Debug.WriteLine(result3);

                    for (int idx = 0; idx < __max_repeat; idx++)
                    {
                        switch (result3[idx])
                        {
                            case 0:
                                RealFindParty[off_count2] = FoundPick_KR[idx];
                                off_count2++;
                                break;
                            case 1:
                                def_count2++;
                                break;
                            case 2:
                                def_timecount2++;
                                break;
                            default:
                                break;
                        }
#if DEBUG
                        Debug.WriteLine(result3[idx]);
#endif
                    }
                    for (int xxx = 0; xxx < off_count2; xxx++)
                    {
                        MainWindow.WriteLog(String.Format("파티 {0} : {1}, {2}, {3}, {4}, {5} ", xxx, RealFindParty[xxx][0], RealFindParty[xxx][1], RealFindParty[xxx][2], RealFindParty[xxx][3], RealFindParty[xxx][4]));
                        MainWindow.WriteLog("\n");
                        Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}, {4} ", RealFindParty[xxx][0], RealFindParty[xxx][1], RealFindParty[xxx][2], RealFindParty[xxx][3], RealFindParty[xxx][4]));
                    }
                    myFlowDoc.Blocks.Add(new Paragraph(new Run(LogString)));
                    RTxtbox_Logbox.Document = myFlowDoc;

                }

                else if (select_count < 3)
                {
                    Debug.WriteLine("\n3명 이상 골라야 해");
                    MessageBox.Show("3명 이상 골라야 해", "알림");
                }
                else
                {
                    Debug.WriteLine("\n덱에 5명 이상 넣을 수 없습니다");
                    MessageBox.Show("5명 이상 넣을 수 없습니다", "알림");
                }
            }
            else
                MessageBox.Show("방덱을 먼저 설정하세요", "알림");          
            
        }

        */
        private void InitWorkerThread()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true; //작업의 진행률이 바뀔때 ProgressChanged 이벤트 발생여부 체크
            worker.WorkerSupportsCancellation = true; //작업 취소 가능 여부 true 로 설정
            worker.DoWork += new DoWorkEventHandler(worker_DoWork); //해야할 작업을 실행할 메서드 정의
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged); //UI쪽에 진행사항을 보여줌, WorkerReportsProgress 속성값이 true 일때만 이벤트 발생
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);//작업이 완료되었을 때 실행할 콜백메서드 정의
            Debug.WriteLine("InitWorkerThread");
        }
               
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("시작!");
            int result = 0;

            off_count = 0;
            def_count = 0;
            def_timecount = 0;

            for (int idx = 0; idx < max_repeat; idx++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    Debug.WriteLine("취소!");
                    return; //about work, if it's cancelled;
                }
                e.Result = Sim_Start(max_repeat);
                result = (int)e.Result;
                switch (result)
                {
                    case 0:
                        off_count++;
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate {
                            lb_WinCount.Content = String.Format("{0} 승", off_count);
                        }));
                        break;
                    case 1:
                        def_count++;
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { lb_LoseCount.Content = String.Format("{0} 패", def_count+ def_timecount); }));

                        break;
                    case 2:
                        def_timecount++;
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { lb_LoseCount.Content = String.Format("{0} 패", def_count+ def_timecount); }));

                        break;
                    default:
                        break;
                }
                Debug.WriteLine(result);
                int percentComplete =
                     (int)((float)(idx + 1) / (float)max_repeat * 100);
                if (percentComplete > highestPercentageReached)
                {

                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { lb_CurrentProgress.Content = String.Format("{0} / {1}", idx + 1, max_repeat); }));
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { lb_WinRate.Content = String.Format("{0:0.#} %", (float)off_count / (float)(idx + 1) * 100.0) ; }));

                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //에러가 있는지 체크
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error");
                return;
            }
            if (isSimOK)
            {
                WriteLog(String.Format("\n공격덱 승률: {0:0.#}%", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100));
                WriteLog(String.Format("\n방어덱 일반 승률: {0:0.#}%", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100));
                WriteLog(String.Format("\n방어덱 시간 승률: {0:0.#}%", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100));

                myFlowDoc.Blocks.Add(new Paragraph(new Run(LogString)));
                RTxtbox_Logbox.Document = myFlowDoc;

                /*
                MessageBox.Show(String.Format("공격덱 승률: {0:0.#}%\n", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                + String.Format("방어덱 일반 승률: {0:0.#}%\n", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                    + String.Format("방어덱 시간 승률: {0:0.#}%\n", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100), "알림");
                */
            }

            Debug.WriteLine("\n공격덱 승률: {0:0.#}%", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
            Debug.WriteLine("\n방어덱 일반 승률: {0:0.#}%", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
            Debug.WriteLine("\n방어덱 시간 승률: {0:0.#}%", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
            sw.Stop();
            Debug.WriteLine("시뮬레이션 시간 : {0} ms", sw.ElapsedMilliseconds);

            bt_sim_start.Content = "시작";
            bt_sim_start_multi.IsEnabled = true;

            MessageBox.Show(String.Format("공격덱 승률: {0:0.#}%\n", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                   + String.Format("방어덱 일반 승률: {0:0.#}%\n", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                       + String.Format("방어덱 시간 승률: {0:0.#}%\n", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100), "알림");
            Debug.WriteLine("끝났어!");

        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        DateTime SimTime;
        Stopwatch sw = new Stopwatch();

        private void bt_sim_start_Click(object sender, RoutedEventArgs e)
        {
            if((string) bt_sim_start.Content == "시작")
            {
                if (isDefDeckReady && isOffDeckReady)
                {
                    bt_sim_start.Content = "정지";
                    bt_sim_start_multi.IsEnabled = false;

                    string s = tB_Sim_Iter.GetLineText(0);
                    //Debug.WriteLine(s);
                    max_repeat = Convert.ToInt32(s);

                    myFlowDoc.Blocks.Add(new Paragraph(new Run("")));
                    myFlowDoc.Blocks.Clear();

                    RTxtbox_Logbox.Document = myFlowDoc;
                    LogString = "";
                    SimTime = DateTime.Now;

                    lb_LoseCount.Content = "0 패";
                    lb_WinCount.Content = "0 승";
                    lb_WinRate.Content = "0 %"; 
                    lb_CurrentProgress.Content = "0 / 0";
                    Filename = "Log_" + SimTime.ToString("yyyyMMdd_HHmmss");
                    sw.Restart();
                    

                    LoadDefDeck();
                    LoadOffDeck();

                    WriteLog(string.Format("공덱 : {0}, {1}, {2}, {3}, {4}  |  ", select_offence_temp[4], select_offence_temp[3], select_offence_temp[2], select_offence_temp[1], select_offence_temp[0]));
                    WriteLog(string.Format("방덱 : {0}, {1}, {2}, {3}, {4}", select_defence_temp[4], select_defence_temp[3], select_defence_temp[2], select_defence_temp[1], select_defence_temp[0]));
                    WriteLog(Environment.NewLine);
                    WriteLog(Environment.NewLine);
                    for (int i = 0; i < 5; i++)
                    {
                        WriteLog(string.Format("이름  : {0,-25}\t{1,27} ", select_offence[4 - i], select_defence[4 - i]));
                        WriteLog(Environment.NewLine);

                        WriteLog(string.Format("성급  : {0,-25}\t{1,25} ", Level_variable.star[19 - i], Level_variable.star[4 - i]));
                        WriteLog(Environment.NewLine);

                        int NumItemOff = 0;
                        int NumItemDef = 0;

                        if (Level_variable.equip1[19 - i])
                            NumItemOff++;
                        if (Level_variable.equip2[19 - i])
                            NumItemOff++;
                        if (Level_variable.equip3[19 - i])
                            NumItemOff++;
                        if (Level_variable.equip4[19 - i])
                            NumItemOff++;
                        if (Level_variable.equip5[19 - i])
                            NumItemOff++;
                        if (Level_variable.equip6[19 - i])
                            NumItemOff++;

                        if (Level_variable.equip1[4 - i])
                            NumItemDef++;
                        if (Level_variable.equip2[4 - i])
                            NumItemDef++;
                        if (Level_variable.equip3[4 - i])
                            NumItemDef++;
                        if (Level_variable.equip4[4 - i])
                            NumItemDef++;
                        if (Level_variable.equip5[4 - i])
                            NumItemDef++;
                        if (Level_variable.equip6[4 - i])
                            NumItemDef++;

                        WriteLog(string.Format("랭크,템  : {0}랭 {1}템 \t{2,25}랭 {3}템 ", Level_variable.Rank[19 - i], NumItemOff, Level_variable.Rank[4 - i], NumItemDef));
                        WriteLog(Environment.NewLine);

                        WriteLog(string.Format("전장  : {0,-25}\t{1,25} ", Level_variable.UE_Lv[19 - i], Level_variable.UE_Lv[4 - i]));
                        WriteLog(Environment.NewLine);

                        WriteLog(string.Format("전투력: {0,-25:F2}\t{1,30:F2} ", Level_variable.power[19 - i], Level_variable.power[4 - i]));
                        WriteLog(Environment.NewLine);
                        WriteLog(Environment.NewLine);

                    }

                    /*
                    int def_count = 0, off_count = 0, def_timecount = 0;

                    int[] result2 = new int[max_repeat];


                    for (int idx = 0; idx < max_repeat; idx++)
                    {
                        int result = Sim_Start(max_repeat);

                        switch (result)
                        {
                            case 0:
                                off_count++;
                                break;
                            case 1:
                                def_count++;
                                break;
                            case 2:
                                def_timecount++;
                                break;
                            default:
                                break;
                        }
                        Debug.WriteLine(result);
                    }

                    */
                    highestPercentageReached = 0;
                    //max_repeat1 = MainWindow.max_repeat;
                    worker.RunWorkerAsync();

                    for (int i = 0; i < 30; i++)
                    {
                        // Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}",  Level_variable.Lv[i], Level_variable.star[i], Level_variable.Rank[i], Battle_variable.name_eng[i]));
                    }

#if DEBUG
                    if (max_repeat == 1)
                    {
                        //Debug.WriteLine("현재 방덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[0], Battle_variable.position[1], Battle_variable.position[2], Battle_variable.position[3], Battle_variable.position[4]);
                        //Debug.WriteLine("현재 공덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[15], Battle_variable.position[16], Battle_variable.position[17], Battle_variable.position[18], Battle_variable.position[19]);
                        // Debug.WriteLine("\n현재 방덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[0], Battle_variable.HP[1], Battle_variable.HP[2], Battle_variable.HP[3], Battle_variable.HP[4]);
                        //Debug.WriteLine("현재 공덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[15], Battle_variable.HP[16], Battle_variable.HP[17], Battle_variable.HP[18], Battle_variable.HP[19]);
                        //Debug.WriteLine("남은 시간: {0:0.0}", end_time - flow_time);
                    }

#endif
                }
                else
                    MessageBox.Show("덱 구성이 완전히 되지 않았습니다", "알림");
            }
            else if((string)bt_sim_start.Content == "정지")
            {

                this.worker.CancelAsync();
                bt_sim_start.Content = "시작";
                bt_sim_start_multi.IsEnabled = true;

                Debug.WriteLine("정지했어");

            }
            


        }
        private void bt_sim_start_multi_Click(object sender, RoutedEventArgs e)
        {
            if (isDefDeckReady && isOffDeckReady)
            {
                //Debug.WriteLine("\n시뮬레이션 반복 횟수를 입력해주세요 (매 반복마다 최대 5~6초 정도 소요)");

                string s = tB_Sim_Iter.GetLineText(0);
                //Debug.WriteLine(s);
                int max_repeat = Convert.ToInt32(s);


                myFlowDoc.Blocks.Add(new Paragraph(new Run("")));
                myFlowDoc.Blocks.Clear();

                RTxtbox_Logbox.Document = myFlowDoc;
                LogString = "";

                DateTime SimTime = DateTime.Now;

                Filename = "Log_" + SimTime.ToString("yyyyMMdd_HHmmss");
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                LoadDefDeck();
                LoadOffDeck();

                WriteLog(string.Format("공덱 : {0}, {1}, {2}, {3}, {4}  |  ", select_offence_temp[4], select_offence_temp[3], select_offence_temp[2], select_offence_temp[1], select_offence_temp[0]));
                WriteLog(string.Format("방덱 : {0}, {1}, {2}, {3}, {4}", select_defence_temp[4], select_defence_temp[3], select_defence_temp[2], select_defence_temp[1], select_defence_temp[0]));
                WriteLog(Environment.NewLine);
                WriteLog(Environment.NewLine);
                for (int i = 0; i < 5; i++)
                {
                    WriteLog(string.Format("이름  : {0,-25}{1,25} ", select_offence[4 - i], select_defence[4 - i]));
                    WriteLog(Environment.NewLine);

                    WriteLog(string.Format("성급  : {0,-27}{1,27} ", Level_variable.star[19 - i], Level_variable.star[4 - i]));
                    WriteLog(Environment.NewLine);

                    int NumItemOff = 0;
                    int NumItemDef = 0;

                    if (Level_variable.equip1[19 - i])
                        NumItemOff++;
                    if (Level_variable.equip2[19 - i])
                        NumItemOff++;
                    if (Level_variable.equip3[19 - i])
                        NumItemOff++;
                    if (Level_variable.equip4[19 - i])
                        NumItemOff++;
                    if (Level_variable.equip5[19 - i])
                        NumItemOff++;
                    if (Level_variable.equip6[19 - i])
                        NumItemOff++;

                    if (Level_variable.equip1[4 - i])
                        NumItemDef++;
                    if (Level_variable.equip2[4 - i])
                        NumItemDef++;
                    if (Level_variable.equip3[4 - i])
                        NumItemDef++;
                    if (Level_variable.equip4[4 - i])
                        NumItemDef++;
                    if (Level_variable.equip5[4 - i])
                        NumItemDef++;
                    if (Level_variable.equip6[4 - i])
                        NumItemDef++;

                    WriteLog(string.Format("랭크,템  : {0}랭 {1}템 {2,32}랭 {3}템 ", Level_variable.Rank[19 - i], NumItemOff, Level_variable.Rank[4 - i], NumItemDef));
                    WriteLog(Environment.NewLine);

                    WriteLog(string.Format("전장  : {0,-25}{1,25} ", Level_variable.UE_Lv[19 - i], Level_variable.UE_Lv[4 - i]));
                    WriteLog(Environment.NewLine);

                    WriteLog(string.Format("전투력: {0,-25:F2}{1,25:F2} ", Level_variable.power[19 - i], Level_variable.power[4 - i]));
                    WriteLog(Environment.NewLine);
                    WriteLog(Environment.NewLine);

                }

                int def_count = 0, off_count = 0, def_timecount = 0;

                int[] result2 = new int[max_repeat];

                Debug.WriteLine("ProcessorCount = {0}" ,Environment.ProcessorCount);

                //ConcurrentBag 사용
                var parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount - 1 
                };


                Sim[] simul = new Sim[max_repeat];
                int[] resultx = new int[max_repeat];
                for (int i = 0; i < max_repeat; i++)
                {
                    simul[i] = new Sim();
                    simul[i].Bv_battle_initialize();
                }

                System.Collections.Concurrent.ConcurrentBag<int> resultCollection = new System.Collections.Concurrent.ConcurrentBag<int>();
                ParallelLoopResult result = Parallel.For(0, max_repeat, parallelOptions,(i) =>
                {
                    //resultx[i] = simul[i]._Sim_Start(max_repeat);
                    //resultCollection.Add(resultx[i]);
                    //resultCollection.Add(simul[i]._Sim_Start(max_repeat));
                    resultCollection.Add(simul[i]._Sim_Start(max_repeat));
                    //Debug.WriteLine("{0}: {1}, result = {2} ", System.Threading.Thread.CurrentThread.ManagedThreadId, i, resultx[i]);

                });
#if DEBUG
                Debug.WriteLine("IsCompleted: {0}", result.IsCompleted);
#endif
                result2 = resultCollection.ToArray();

                Debug.WriteLine(resultCollection);
                Debug.WriteLine(result2);

                for (int idx = 0; idx < max_repeat; idx++)
                {
                    switch (result2[idx])
                    {
                        case 0:
                            off_count++;
                            break;
                        case 1:
                            def_count++;
                            break;
                        case 2:
                            def_timecount++;
                            break;
                        default:
                            break;
                    }
#if DEBUG
                    //Debug.WriteLine(result2[idx]);
#endif
                }

                for (int i = 0; i < 30; i++)
                {
                    // Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}",  Level_variable.Lv[i], Level_variable.star[i], Level_variable.Rank[i], Battle_variable.name_eng[i]));
                }


#if DEBUG
                if (max_repeat == 1)
                {
                    //Debug.WriteLine("현재 방덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[0], Battle_variable.position[1], Battle_variable.position[2], Battle_variable.position[3], Battle_variable.position[4]);
                    //Debug.WriteLine("현재 공덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[15], Battle_variable.position[16], Battle_variable.position[17], Battle_variable.position[18], Battle_variable.position[19]);
                    // Debug.WriteLine("\n현재 방덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[0], Battle_variable.HP[1], Battle_variable.HP[2], Battle_variable.HP[3], Battle_variable.HP[4]);
                    //Debug.WriteLine("현재 공덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[15], Battle_variable.HP[16], Battle_variable.HP[17], Battle_variable.HP[18], Battle_variable.HP[19]);
                    //Debug.WriteLine("남은 시간: {0:0.0}", end_time - flow_time);
                }

                Debug.WriteLine("\n공격덱 승률: {0:0.#}%", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
                Debug.WriteLine("\n방어덱 일반 승률: {0:0.#}%", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
                Debug.WriteLine("\n방어덱 시간 승률: {0:0.#}%", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100);
#endif
                sw.Stop();
                Debug.WriteLine("시뮬레이션 시간 : {0} ms", sw.ElapsedMilliseconds);

                if (isSimOK)
                {
                    WriteLog(String.Format("\n공격덱 승률: {0:0.#}%", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100));
                    WriteLog(String.Format("\n방어덱 일반 승률: {0:0.#}%", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100));
                    WriteLog(String.Format("\n방어덱 시간 승률: {0:0.#}%", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100));

                    myFlowDoc.Blocks.Add(new Paragraph(new Run(LogString)));
                    RTxtbox_Logbox.Document = myFlowDoc;


                    MessageBox.Show(String.Format("공격덱 승률: {0:0.#}%\n", (double)off_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                    + String.Format("방어덱 일반 승률: {0:0.#}%\n", (double)def_count / ((double)off_count + (double)def_count + (double)def_timecount) * 100)
                        + String.Format("방어덱 시간 승률: {0:0.#}%\n", (double)def_timecount / ((double)off_count + (double)def_count + (double)def_timecount) * 100), "알림");
                }

            }
            else
                MessageBox.Show("덱 구성이 완전히 되지 않았습니다", "알림");
        }
        private int Sim_Start(int _max_repeat)
        {
            int i = 0;

            Character_skill Cs = new Character_skill();
            Character_range_and_cast crc = new Character_range_and_cast();
            Character_pattern Cp = new Character_pattern();

            Character_skill.simulation_count = Convert.ToInt32(_max_repeat);
            Battle_variable.battle_initialize();

            isSimOK = true;

            double[] W_timing = Enumerable.Repeat<double>(0, 30).ToArray<double>();
            double[] C_timing = Enumerable.Repeat<double>(-1, 30).ToArray<double>();
            double[] C_next_timing = Enumerable.Repeat<double>(-1, 30).ToArray<double>();
            double[] A_timing = Enumerable.Repeat<double>(-1, 30).ToArray<double>();
            double[] UB_timing = Enumerable.Repeat<double>(-1, 30).ToArray<double>();
            double[] UB_ending = Enumerable.Repeat<double>(-1, 30).ToArray<double>();
            string[] state = Enumerable.Repeat<string>("FM", 30).ToArray<string>();
            int[] Action_seq = Enumerable.Repeat<int>(1, 30).ToArray<int>();
            int[] Action_next_seq = Enumerable.Repeat<int>(2, 30).ToArray<int>();

            //FM 상태: 가장 초기에 아레나 양측에서 자리잡는 상태. 사거리에 들어올시 W 상태로 전환됨
            //M 상태: 사거리를 벗어난 상태로, 다시 사거리에 들어가기 위해 이동하는 상태. 사거리에 들어오면 C 상태로 전환됨. C 상태에서 M 상태가 되었을 경우 C 상태의 타이밍은 그대로 유지됨
            //C 상태: A 상태로 이행하기 위해 캐스팅하는 시간. 이 상태에서는 상태이상, M 상태 등으로 전환되어도 타이밍이 그대로 유지되며 처음으로 돌아가지 않음. 또한 UB 상태로 전환할 수 있는 상태
            //A 상태: C 상태나 W 상태를 거치고 실제로 공격을 이행하는 상태. 이 상태에서 상태이상으로 행동이 끊길경우 A 상태가 해제되고 C 상태로 바로 이동함.
            //UB 상태: C 상태에서만 이행가능한 특수 상태. TP가 1000일 경우 TP를 소비하여 이행. 약간의 딜레이 후에 다시 C 상태의 타이밍으로 돌아옴.
            //W 상태: FM 상태에서 이행되는 상태. 2.467초동안 대기. 그리고 A 상태로 전환됨

            bool anna_bomb = false;//안나 자폭상태 스위치
            bool anna_bomb_est = false;//안나 자폭상태 스위치

            //MethodInfo dummy = Cs.GetType().GetMethod(string.Format("{0}_passive", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            //패시브 스킬 적용

            for (i = 0; i < 30; i++)
            {
                if (Battle_variable.death[i] == false)
                {
                    MethodInfo dummy1 = Cs.GetType().GetMethod(string.Format("{0}_passive", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                    if (dummy1 != null)
                    {
                        dummy1.Invoke(Cs, new Object[] { i });
                    }
                    else
                    {
                        MessageBox.Show("ㅈ망", "알림");
                        isSimOK = false;
                        return -1;
                    }
                }
            }

            //실제 전투 시작
            flow_time = 0;
            while (true)
            {
                if (flow_time > 5.6665 && flow_time < 5.6675)
                {
                    //공덱
                    if (Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15) != -1)
                    {
                        //자신의 물리방어력 증가
                        string buff_type = "buff_PD";
                        double coefficient;
                        if (Level_variable.equip[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)] == true)
                        {
                            coefficient = 1 + 1 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)];
                        }
                        else
                        {
                            coefficient = 0.8 + 0.8 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)];
                        }
                        double duration = 16;
                        Battle_fomular.buff_process(buff_type, coefficient, duration, Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15));

                        if (max_repeat == 1)
                        {
                            MainWindow.WriteLog(string.Format("\n({5:F2}) {0}{1}의 1스킬로 인해 자신 {2}{3}의 물리방어력 {4} 증가\n", Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)], Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)], coefficient, MainWindow.end_time - MainWindow.flow_time));
                            MainWindow.WriteLog(string.Format("{0}{1}의 물리방어력: {2}\n", Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)], Battle_variable.PD[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)]));
                        }


                        //아군 전체에게 물리무효배리어 전개(전장)
                        if (Level_variable.equip[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)] == true)
                        {
                            int ii = 0;
                            while (Character_skill.rima_opponent_array_order2[ii] != -1)
                            {
                                buff_type = "Pbarrier";
                                coefficient = 36 + 36 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)];
                                duration = 16;
                                Battle_fomular.buff_process(buff_type, coefficient, duration, Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Character_skill.rima_opponent_array_order2[ii]);

                                if (max_repeat == 1)
                                {
                                    MainWindow.WriteLog(string.Format("\n({4:F2}) {0}{1}의 1스킬로 인해 아군 전체 {2}{3}에게 물리무효배리어 전개\n", Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 0, 15)], Character_skill.rima_opponent_array_order2[ii], Battle_variable.name[Character_skill.rima_opponent_array_order2[ii]], MainWindow.end_time - MainWindow.flow_time));
                                    MainWindow.WriteLog(string.Format("{0}{1}의 물리무효배리어: {2}\n", Character_skill.rima_opponent_array_order2[ii], Battle_variable.name[Character_skill.rima_opponent_array_order2[ii]], coefficient));
                                }

                                ii++;
                            }
                        }
                    }
                    //방덱
                    if (Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15) != -1)
                    {
                        //자신의 물리방어력 증가
                        string buff_type = "buff_PD";
                        double coefficient;
                        if (Level_variable.equip[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)] == true)
                        {
                            coefficient = 1 + 1 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)];
                        }
                        else
                        {
                            coefficient = 0.8 + 0.8 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)];
                        }
                        double duration = 16;
                        Battle_fomular.buff_process(buff_type, coefficient, duration, Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15));

                        if (max_repeat == 1)
                        {
                            MainWindow.WriteLog(string.Format("\n({5:F2}) {0}{1}의 1스킬로 인해 자신 {2}{3}의 물리방어력 {4} 증가\n", Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)], Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)], coefficient, MainWindow.end_time - MainWindow.flow_time));
                            MainWindow.WriteLog(string.Format("{0}{1}의 물리방어력: {2}\n", Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)], Battle_variable.PD[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)]));
                        }


                        //아군 전체에게 물리무효배리어 전개(전장)
                        if (Level_variable.equip[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)] == true)
                        {
                            int ii = 0;
                            while (Character_skill.rima_opponent_array_order2_est[ii] != -1)
                            {
                                buff_type = "Pbarrier";
                                coefficient = 36 + 36 * Level_variable.Lv[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)];
                                duration = 16;
                                Battle_fomular.buff_process(buff_type, coefficient, duration, Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Character_skill.rima_opponent_array_order2_est[ii]);

                                if (max_repeat == 1)
                                {
                                    MainWindow.WriteLog(string.Format("\n({4:F2}) {0}{1}의 1스킬로 인해 아군 전체 {2}{3}에게 물리무효배리어 전개\n", Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15), Battle_variable.name[Array.IndexOf(Battle_variable.name_eng, "rima", 15, 15)], Character_skill.rima_opponent_array_order2_est[ii], Battle_variable.name[Character_skill.rima_opponent_array_order2_est[ii]], MainWindow.end_time - MainWindow.flow_time));
                                    MainWindow.WriteLog(string.Format("{0}{1}의 물리무효배리어: {2}\n", Character_skill.rima_opponent_array_order2_est[ii], Battle_variable.name[Character_skill.rima_opponent_array_order2_est[ii]], coefficient));
                                }

                                ii++;
                            }
                        }
                    }
                }

                //버프 시간 처리
                for (i = 0; i < 30; i++)
                {
                    if (Battle_variable.death[i] == false)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            if (Battle_variable.buff_HP[j, i] == true)
                            {
                                Battle_variable.buff_HP_time[j, i] -= 0.001;

                                if (Battle_variable.buff_HP_time[j, i] < 0)
                                {
                                    Battle_variable.HP[i] -= Battle_variable.buff_HP_coef[j, i];
                                    Battle_variable.max_HP[i] -= Battle_variable.buff_HP_coef[j, i];
                                    //Debug.WriteLine("{0}의 HP 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_HP_coef[j, i]);
                                    //Debug.WriteLine("{0} HP: {1}\n", Battle_variable.name[i], Battle_variable.HP[i]);

                                    Battle_variable.buff_HP[j, i] = false;
                                    Battle_variable.buff_HP_time[j, i] = 0;
                                    Battle_variable.buff_HP_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_PA[j, i] == true)
                            {
                                Battle_variable.buff_PA_time[j, i] -= 0.001;

                                if (Battle_variable.buff_PA_time[j, i] < 0)
                                {
                                    Battle_variable.PA[i] -= Battle_variable.buff_PA_coef[j, i];
                                    //Debug.WriteLine("{0}의 물리공격력 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_PA_coef[j, i]);
                                    //Debug.WriteLine("{0} 물리공격력: {1}\n", Battle_variable.name[i], Battle_variable.PA[i]);

                                    Battle_variable.buff_PA[j, i] = false;
                                    Battle_variable.buff_PA_time[j, i] = 0;
                                    Battle_variable.buff_PA_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_MA[j, i] == true)
                            {
                                Battle_variable.buff_MA_time[j, i] -= 0.001;

                                if (Battle_variable.buff_MA_time[j, i] < 0)
                                {
                                    Battle_variable.MA[i] -= Battle_variable.buff_MA_coef[j, i];
                                    //Debug.WriteLine("{0}의 마법공격력 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_MA_coef[j, i]);
                                    //Debug.WriteLine("{0} 마법공격력: {1}\n", Battle_variable.name[i], Battle_variable.MA[i]);

                                    Battle_variable.buff_MA[j, i] = false;
                                    Battle_variable.buff_MA_time[j, i] = 0;
                                    Battle_variable.buff_MA_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_PD[j, i] == true)
                            {
                                Battle_variable.buff_PD_time[j, i] -= 0.001;

                                if (Battle_variable.buff_PD_time[j, i] < 0)
                                {
                                    Battle_variable.PD[i] -= Battle_variable.buff_PD_coef[j, i];
                                    //Debug.WriteLine("{0}의 물리방어력 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_PD_coef[j, i]);
                                    //Debug.WriteLine("{0} 물리방어력: {1}\n", Battle_variable.name[i], Battle_variable.PD[i]);

                                    Battle_variable.buff_PD[j, i] = false;
                                    Battle_variable.buff_PD_time[j, i] = 0;
                                    Battle_variable.buff_PD_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_MD[j, i] == true)
                            {
                                Battle_variable.buff_MD_time[j, i] -= 0.001;

                                if (Battle_variable.buff_MD_time[j, i] < 0)
                                {
                                    Battle_variable.MD[i] -= Battle_variable.buff_MD_coef[j, i];
                                    //Debug.WriteLine("{0}의 마법방어력 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_MD_coef[j, i]);
                                    //Debug.WriteLine("{0} 마법방어력: {1}\n", Battle_variable.name[i], Battle_variable.MD[i]);

                                    Battle_variable.buff_MD[j, i] = false;
                                    Battle_variable.buff_MD_time[j, i] = 0;
                                    Battle_variable.buff_MD_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_PC[j, i] == true)
                            {
                                Battle_variable.buff_PC_time[j, i] -= 0.001;

                                if (Battle_variable.buff_PC_time[j, i] < 0)
                                {
                                    Battle_variable.PC[i] -= Battle_variable.buff_PC_coef[j, i];
                                    //Debug.WriteLine("{0}의 물리크리티컬 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_PC_coef[j, i]);
                                    //Debug.WriteLine("{0} 물리크리티컬: {1}\n", Battle_variable.name[i], Battle_variable.PC[i]);

                                    Battle_variable.buff_PC[j, i] = false;
                                    Battle_variable.buff_PC_time[j, i] = 0;
                                    Battle_variable.buff_PC_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_MC[j, i] == true)
                            {
                                Battle_variable.buff_MC_time[j, i] -= 0.001;

                                if (Battle_variable.buff_MC_time[j, i] < 0)
                                {
                                    Battle_variable.MC[i] -= Battle_variable.buff_MC_coef[j, i];
                                    //Debug.WriteLine("{0}의 마법크리티컬 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_MC_coef[j, i]);
                                    //Debug.WriteLine("{0} 마법크리티컬: {1}\n", Battle_variable.name[i], Battle_variable.MC[i]);

                                    Battle_variable.buff_MC[j, i] = false;
                                    Battle_variable.buff_MC_time[j, i] = 0;
                                    Battle_variable.buff_MC_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_dodge[j, i] == true)
                            {
                                Battle_variable.buff_dodge_time[j, i] -= 0.001;

                                if (Battle_variable.buff_dodge_time[j, i] < 0)
                                {
                                    Battle_variable.Dodge[i] -= Battle_variable.buff_dodge_coef[j, i];
                                    //Debug.WriteLine("{0}의 회피 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_dodge_coef[j, i]);
                                    //Debug.WriteLine("{0} 회피: {1}\n", Battle_variable.name[i], Battle_variable.Dodge[i]);

                                    Battle_variable.buff_dodge[j, i] = false;
                                    Battle_variable.buff_dodge_time[j, i] = 0;
                                    Battle_variable.buff_dodge_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_acc[j, i] == true)
                            {
                                Battle_variable.buff_acc_time[j, i] -= 0.001;

                                if (Battle_variable.buff_acc_time[j, i] < 0)
                                {
                                    Battle_variable.acc[i] -= Battle_variable.buff_acc_coef[j, i];
                                    //Debug.WriteLine("{0}의 명중 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_acc_coef[j, i]);
                                    //Debug.WriteLine("{0} 명중: {1}\n", Battle_variable.name[i], Battle_variable.Dodge[i]);

                                    Battle_variable.buff_acc[j, i] = false;
                                    Battle_variable.buff_acc_time[j, i] = 0;
                                    Battle_variable.buff_acc_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.buff_TPup[j, i] == true)
                            {
                                Battle_variable.buff_TPup_time[j, i] -= 0.001;

                                if (Battle_variable.buff_TPup_time[j, i] < 0)
                                {
                                    Battle_variable.TPup[i] -= Battle_variable.buff_TPup_coef[j, i];
                                    //Debug.WriteLine("{0}의 TP상승 버프 {1} 해제", Battle_variable.name[i], Battle_variable.buff_TPup_coef[j, i]);
                                    //Debug.WriteLine("{0} TP상승: {1}\n", Battle_variable.name[i], Battle_variable.TPup[i]);

                                    Battle_variable.buff_TPup[j, i] = false;
                                    Battle_variable.buff_TPup_time[j, i] = 0;
                                    Battle_variable.buff_TPup_coef[j, i] = 0;
                                }
                            }
                            if (Battle_variable.PCdamage[j, i] == true)
                            {
                                Battle_variable.PCdamage_time[j, i] -= 0.001;

                                if (Battle_variable.PCdamage_time[j, i] < 0)
                                {
                                    Battle_variable.PCdamage_coef[i] -= Battle_variable.PCdamage_save[j, i];
                                    //Debug.WriteLine("{0}의 크리티컬 배율 버프 {1} 해제", Battle_variable.name[i], Battle_variable.PCdamage_coef[i]);

                                    Battle_variable.PCdamage[j, i] = false;
                                    Battle_variable.PCdamage_time[j, i] = 0;
                                    Battle_variable.PCdamage_save[j, i] = 2;
                                }
                            }
                            if (Battle_variable.MCdamage[j, i] == true)
                            {
                                Battle_variable.MCdamage_time[j, i] -= 0.001;

                                if (Battle_variable.MCdamage_time[j, i] < 0)
                                {
                                    Battle_variable.MCdamage_coef[i] -= Battle_variable.MCdamage_save[j, i];
                                    //Debug.WriteLine("{0}의 크리티컬 배율 버프 {1} 해제", Battle_variable.name[i], Battle_variable.MCdamage_coef[i]);

                                    Battle_variable.MCdamage[j, i] = false;
                                    Battle_variable.MCdamage_time[j, i] = 0;
                                    Battle_variable.MCdamage_save[j, i] = 2;
                                }
                            }
                        }
                        if (Battle_variable.Pbarrier[i] == true)
                        {
                            Battle_variable.Pbarrier_time[i] -= 0.001;

                            if (Battle_variable.Pbarrier_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 물리배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Pbarrier_coef[i]);

                                Battle_variable.Pbarrier[i] = false;
                                Battle_variable.Pbarrier_time[i] = 0;
                                Battle_variable.Pbarrier_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.Mbarrier[i] == true)
                        {
                            Battle_variable.Mbarrier_time[i] -= 0.001;

                            if (Battle_variable.Mbarrier_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 마법배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Mbarrier_coef[i]);

                                Battle_variable.Mbarrier[i] = false;
                                Battle_variable.Mbarrier_time[i] = 0;
                                Battle_variable.Mbarrier_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.Allbarrier[i] == true)
                        {
                            Battle_variable.Allbarrier_time[i] -= 0.001;

                            if (Battle_variable.Allbarrier_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 물리마법배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Allbarrier_coef[i]);

                                Battle_variable.Allbarrier[i] = false;
                                Battle_variable.Allbarrier_time[i] = 0;
                                Battle_variable.Allbarrier_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.Pabsorb[i] == true)
                        {
                            Battle_variable.Pabsorb_time[i] -= 0.001;

                            if (Battle_variable.Pabsorb_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 물리흡수배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Pabsorb_coef[i]);

                                Battle_variable.Pabsorb[i] = false;
                                Battle_variable.Pabsorb_time[i] = 0;
                                Battle_variable.Pabsorb_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.Mabsorb[i] == true)
                        {
                            Battle_variable.Mabsorb_time[i] -= 0.001;

                            if (Battle_variable.Mabsorb_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 마법흡수배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Mabsorb_coef[i]);

                                Battle_variable.Mabsorb[i] = false;
                                Battle_variable.Mabsorb_time[i] = 0;
                                Battle_variable.Mabsorb_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.Allabsorb[i] == true)
                        {
                            Battle_variable.Allabsorb_time[i] -= 0.001;

                            if (Battle_variable.Allabsorb_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 물리마법흡수배리어 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Allabsorb_coef[i]);

                                Battle_variable.Allabsorb[i] = false;
                                Battle_variable.Allabsorb_time[i] = 0;
                                Battle_variable.Allabsorb_coef[i] = 0;
                            }
                        }

                        if (Battle_variable.ConHP[i] == true)
                        {
                            Battle_variable.ConHP_time[i] -= 0.001;

                            if (Battle_variable.ConHP_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 지속HP회복 버프 {1} 해제", Battle_variable.name[i], Battle_variable.ConHP_coef[i]);

                                Battle_variable.ConHP[i] = false;
                                Battle_variable.ConHP_time[i] = 0;
                                Battle_variable.ConHP_coef[i] = 0;
                            }
                            else if (Battle_variable.ConHP_time[i] % 1 > 0.4995 && Battle_variable.ConHP_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 지속HP회복 버프로 인해 {1} 회복", Battle_variable.name[i], Battle_variable.ConHP_coef[i]);
                                Battle_variable.HP[i] += Battle_variable.ConHP_coef[i];
                                Battle_fomular.max_HP_Process();
                            }
                        }
                        if (Battle_variable.ConTP[i] == true)
                        {
                            Battle_variable.ConTP_time[i] -= 0.001;

                            if (Battle_variable.ConTP_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 지속TP회복 버프 {1} 해제", Battle_variable.name[i], Battle_variable.ConTP_coef[i]);

                                Battle_variable.ConTP[i] = false;
                                Battle_variable.ConTP_time[i] = 0;
                                Battle_variable.ConTP_coef[i] = 0;
                            }
                            else if (Battle_variable.ConTP_time[i] % 1 > 0.4995 && Battle_variable.ConTP_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 지속TP회복 버프로 인해 {1} 회복", Battle_variable.name[i], Battle_variable.ConTP_coef[i] * (100 + Math.Max(0, Battle_variable.TPup[i])) / 100);
                                Battle_variable.TP[i] += Battle_variable.ConTP_coef[i] * (100 + Math.Max(0, Battle_variable.TPup[i])) / 100;
                                Battle_fomular.max_TP_Process();
                            }
                        }

                        if (Battle_variable.Aspeed[i] == true)
                        {
                            Battle_variable.Aspeed_time[i] -= 0.001;

                            if (Battle_variable.Aspeed_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 행동속도 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Aspeed_coef[i]);

                                Battle_variable.Aspeed[i] = false;
                                Battle_variable.Aspeed_time[i] = 0;
                                Battle_variable.Aspeed_coef[i] = 1;
                            }
                        }
                        if (Battle_variable.Mspeed[i] == true)
                        {
                            Battle_variable.Mspeed_time[i] -= 0.001;

                            if (Battle_variable.Mspeed_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 이동속도 버프 {1} 해제", Battle_variable.name[i], Battle_variable.Mspeed_coef[i]);

                                Battle_variable.Mspeed[i] = false;
                                Battle_variable.Mspeed_time[i] = 0;
                                Battle_variable.Mspeed_coef[i] = 450;
                            }
                        }

                        if (Battle_variable.provoke[i] == true)
                        {
                            Battle_variable.provoke_time[i] -= 0.001;

                            if (Battle_variable.provoke_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 도발 해제", Battle_variable.name[i]);

                                Battle_variable.provoke[i] = false;
                                Battle_variable.provoke_time[i] = 0;
                            }
                        }
                        if (Battle_variable.invincible[i] == true)
                        {
                            Battle_variable.invincible_time[i] -= 0.001;

                            if (Battle_variable.invincible_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 무적 해제", Battle_variable.name[i]);

                                Battle_variable.invincible[i] = false;
                                Battle_variable.invincible_time[i] = 0;
                            }
                        }
                        if (Battle_variable.physical_dodge[i] == true)
                        {
                            Battle_variable.physical_dodge_time[i] -= 0.001;

                            if (Battle_variable.physical_dodge_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 물리회피 해제", Battle_variable.name[i]);

                                Battle_variable.physical_dodge[i] = false;
                                Battle_variable.physical_dodge_time[i] = 0;
                            }
                        }
                        if (Battle_variable.paralyze[i] == true)
                        {
                            Battle_variable.paralyze_time[i] -= 0.001;

                            if (Battle_variable.paralyze_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 마비 해제", Battle_variable.name[i]);

                                Battle_variable.paralyze[i] = false;
                                Battle_variable.paralyze_time[i] = 0;


                                //딜레이 0.333초 부여
                                Battle_fomular.buff_process("delay", 0, 0.333, i, i);
                            }
                        }
                        if (Battle_variable.stun[i] == true)
                        {
                            Battle_variable.stun_time[i] -= 0.001;

                            if (Battle_variable.stun_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 스턴 해제", Battle_variable.name[i]);

                                Battle_variable.stun[i] = false;
                                Battle_variable.stun_time[i] = 0;


                                //딜레이 0.333초 부여
                                Battle_fomular.buff_process("delay", 0, 0.333, i, i);
                            }
                        }
                        if (Battle_variable.bind[i] == true)
                        {
                            Battle_variable.bind_time[i] -= 0.001;

                            if (Battle_variable.bind_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 속박 해제", Battle_variable.name[i]);

                                Battle_variable.bind[i] = false;
                                Battle_variable.bind_time[i] = 0;


                                //딜레이 0.333초 부여
                                Battle_fomular.buff_process("delay", 0, 0.333, i, i);
                            }
                        }
                        if (Battle_variable.knockback[i] == true)
                        {
                            Battle_variable.knockback_time[i] -= 0.001;

                            if (Battle_variable.knockback_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 넉백 해제", Battle_variable.name[i]);

                                Battle_variable.knockback[i] = false;
                                Battle_variable.knockback_time[i] = 0;


                                //딜레이 0.333초 부여
                                Battle_fomular.buff_process("delay", 0, 0.333, i, i);
                            }
                        }
                        if (Battle_variable.freeze[i] == true)
                        {
                            Battle_variable.freeze_time[i] -= 0.001;

                            if (Battle_variable.freeze_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 동결 해제", Battle_variable.name[i]);

                                Battle_variable.freeze[i] = false;
                                Battle_variable.freeze_time[i] = 0;


                                //딜레이 0.333초 부여
                                Battle_fomular.buff_process("delay", 0, 0.333, i, i);
                            }
                        }
                        if (Battle_variable.timestop[i] == true)
                        {
                            Battle_variable.timestop_time[i] -= 0.001;

                            if (Battle_variable.timestop_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 시간정지 해제", Battle_variable.name[i]);

                                Battle_variable.timestop[i] = false;
                                Battle_variable.timestop_time[i] = 0;
                            }
                        }
                        if (Battle_variable.delay[i] == true)
                        {
                            Battle_variable.delay_time[i] -= 0.001;

                            if (Battle_variable.delay_time[i] < 0)
                            {
                                Battle_variable.delay[i] = false;
                                Battle_variable.delay_time[i] = 0;
                            }
                        }
                        if (Battle_variable.enchant[i] == true)
                        {
                            Battle_variable.enchant_time[i] -= 0.001;

                            if (Battle_variable.enchant_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 유혹 해제", Battle_variable.name[i]);

                                Battle_variable.enchant[i] = false;
                                Battle_variable.enchant_time[i] = 0;
                            }
                        }
                        if (Battle_variable.confuse[i] == true)
                        {
                            Battle_variable.confuse_time[i] -= 0.001;

                            if (Battle_variable.confuse_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 혼란 해제", Battle_variable.name[i]);

                                Battle_variable.confuse[i] = false;
                                Battle_variable.confuse_time[i] = 0;
                            }
                        }

                        if (Battle_variable.poison[i] == true)
                        {
                            Battle_variable.poison_time[i] -= 0.001;

                            if (Battle_variable.poison_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 독 해제", Battle_variable.name[i]);

                                Battle_variable.poison[i] = false;
                                Battle_variable.poison_time[i] = 0;
                                Battle_variable.poison_coef[i] = 0;
                            }
                            else if (Battle_variable.poison_time[i] % 1 > 0.4995 && Battle_variable.poison_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 독으로 인해 {1} 대미지", Battle_variable.name[i], Battle_variable.poison_coef[i]);
                                Battle_fomular.damage_process("99", Battle_variable.poison_coef[i], i, i);
                            }
                        }
                        if (Battle_variable.toxic[i] == true)
                        {
                            Battle_variable.toxic_time[i] -= 0.001;

                            if (Battle_variable.toxic_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 맹독 해제", Battle_variable.name[i]);

                                Battle_variable.toxic[i] = false;
                                Battle_variable.toxic_time[i] = 0;
                                Battle_variable.toxic_coef[i] = 0;
                            }
                            else if (Battle_variable.toxic_time[i] % 1 > 0.4995 && Battle_variable.toxic_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 맹독으로 인해 {1} 대미지", Battle_variable.name[i], Battle_variable.toxic_coef[i]);
                                Battle_fomular.damage_process("99", Battle_variable.toxic_coef[i], i, i);
                            }
                        }
                        if (Battle_variable.curse[i] == true)
                        {
                            Battle_variable.curse_time[i] -= 0.001;

                            if (Battle_variable.curse_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 저주 해제", Battle_variable.name[i]);

                                Battle_variable.curse[i] = false;
                                Battle_variable.curse_time[i] = 0;
                                Battle_variable.curse_coef[i] = 0;
                            }
                            else if (Battle_variable.curse_time[i] % 1 > 0.4995 && Battle_variable.curse_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 저주로 인해 {1} 대미지", Battle_variable.name[i], Battle_variable.curse_coef[i]);
                                Battle_fomular.damage_process("99", Battle_variable.curse_coef[i], i, i);
                            }
                        }
                        if (Battle_variable.burn[i] == true)
                        {
                            Battle_variable.burn_time[i] -= 0.001;

                            if (Battle_variable.burn_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 화상 해제", Battle_variable.name[i]);

                                Battle_variable.burn[i] = false;
                                Battle_variable.burn_time[i] = 0;
                                Battle_variable.burn_coef[i] = 0;
                            }
                            else if (Battle_variable.burn_time[i] % 1 > 0.4995 && Battle_variable.burn_time[i] % 1 < 0.5005)
                            {
                                //Debug.WriteLine("{0}가 화상으로 인해 {1} 대미지", Battle_variable.name[i], Battle_variable.burn_coef[i]);
                                Battle_fomular.damage_process("99", Battle_variable.burn_coef[i], i, i);
                            }
                        }
                        if (Battle_variable.blind[i] == true)
                        {
                            Battle_variable.blind_time[i] -= 0.001;

                            if (Battle_variable.blind_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 암흑 {1} 해제", Battle_variable.name[i], Battle_variable.blind_coef[i]);

                                Battle_variable.blind[i] = false;
                                Battle_variable.blind_time[i] = 0;
                                Battle_variable.blind_coef[i] = 100;
                            }
                        }

                        if (Battle_variable.charge[i] == true)
                        {
                            Battle_variable.charge_time[i] -= 0.001;

                            if (Battle_variable.charge_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 차지 해제", Battle_variable.name[i]);

                                Battle_variable.charge[i] = false;
                                Battle_variable.charge_time[i] = 0;//coef는 나중에 쓰이므로 0으로 초기화안됨
                            }
                        }
                        if (Battle_variable.counterattack[i] == true)
                        {
                            Battle_variable.counterattack_time[i] -= 0.001;

                            if (Battle_variable.counterattack_time[i] < 0)
                            {
                                //Console.WriteLine("{0}의 차지 해제", Battle_variable.name[i]);

                                Battle_variable.counterattack[i] = false;
                                Battle_variable.counterattack_time[i] = 0;//coef는 나중에 쓰이므로 0으로 초기화안됨
                            }
                        }
                        if (Battle_variable.panic[i] == true)
                        {
                            Battle_variable.panic_time[i] -= 0.001;

                            if (Battle_variable.panic_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 공황 해제", Battle_variable.name[i]);

                                Battle_variable.panic[i] = false;
                                Battle_variable.panic_time[i] = 0;
                            }
                        }

                        if (Battle_variable.spirit[i] == true)
                        {
                            Battle_variable.spirit_time[i] -= 0.001;

                            if (Battle_variable.spirit_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 영령의 가호 해제", Battle_variable.name[i]);

                                Battle_variable.spirit[i] = false;
                                Battle_variable.spirit_time[i] = 0;
                            }
                        }

                        if (Battle_variable.blade[i] == true)
                        {
                            Battle_variable.blade_time[i] -= 0.001;

                            if (Battle_variable.blade_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 바람의 칼날 해제", Battle_variable.name[i]);

                                Battle_variable.blade[i] = false;
                                Battle_variable.blade_time[i] = 0;
                            }
                        }

                        if (Battle_variable.resurrection[i] == true)
                        {
                            Battle_variable.resurrection_time[i] -= 0.001;

                            if (Battle_variable.resurrection_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 기사의 가호 해제", Battle_variable.name[i]);

                                Battle_variable.resurrection[i] = false;
                                Battle_variable.resurrection_time[i] = 0;
                                Battle_variable.resurrection_coef[i] = 0;
                            }
                        }
                        if (Battle_variable.sleep[i] == true)
                        {
                            Battle_variable.sleep_time[i] -= 0.001;

                            if (Battle_variable.sleep_time[i] < 0)
                            {
                                //Debug.WriteLine("{0}의 수면 해제", Battle_variable.name[i]);

                                Battle_variable.sleep[i] = false;
                                Battle_variable.sleep_time[i] = 0;
                            }
                        }
                        if (Battle_variable.name_eng[i] == "muimi_ub")
                        {
                            //자신의 TP 감소
                            double TPheal = -100 * 0.001;
                            Battle_variable.TP[i] += TPheal;
                            Battle_fomular.max_TP_Process();
                        }
                    }
                }

                //폭탄: 내가 죽어도 대미지를 입힘
                for (i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Battle_variable.bomb[j, i] == true)
                        {
                            Battle_variable.bomb_time[j, i] -= 0.001;

                            if (Battle_variable.bomb_time[j, i] < 0)
                            {
                                if (Battle_variable.death[Battle_variable.bomb_index[j, i]] == false)
                                {
                                    Battle_variable.bomb_coef[j, i] = 12 + 12 * Level_variable.Lv[Battle_variable.bomb_index[j, i]] + 1 * Math.Max(0, Battle_variable.PA[Battle_variable.bomb_index[j, i]]);
                                }
                                else
                                {
                                    if (Level_variable.star[i] >= 5)
                                    {
                                        Battle_variable.bomb_coef[j, i] = 12 + 12 * Level_variable.Lv[Battle_variable.bomb_index[j, i]] + 1 * Math.Max(0, Battle_variable.PA[Battle_variable.bomb_index[j, i]] + 240 + 15 * Level_variable.Lv[Battle_variable.bomb_index[j, i]]);
                                    }
                                    else
                                    {
                                        Battle_variable.bomb_coef[j, i] = 12 + 12 * Level_variable.Lv[Battle_variable.bomb_index[j, i]] + 1 * Math.Max(0, Battle_variable.PA[Battle_variable.bomb_index[j, i]] + 15 + 15 * Level_variable.Lv[Battle_variable.bomb_index[j, i]]);
                                    }
                                }

                                if (Battle_variable.enchant[Battle_variable.bomb_index[j, i]] == true || Battle_variable.confuse[Battle_variable.bomb_index[j, i]] == true)
                                {
                                    Battle_variable.bomb_coef[j, i] = 0;
                                }


                                //Debug.WriteLine("{0}의 폭탄 {1} 폭발", Battle_variable.name[i], Battle_variable.bomb_coef[j, i]);

                                if (Battle_variable.bomb_index[j, i] < 15)
                                {
                                    for (int k = 15; k < 30; k++)
                                    {
                                        if (Battle_variable.death[k] == false)
                                        {
                                            Battle_theorem.damage_step("11", Battle_variable.bomb_coef[j, i], 1, 0, Battle_variable.bomb_index[j, i], k);

                                            if (max_repeat == 1)
                                            {
                                                MainWindow.WriteLog(string.Format("\n({5:F2}) {0}{1}의 폭탄이 폭발하여 적 전체 {2}{3}에게 {4:F2} 물리 대미지\n", i, Battle_variable.name[i], k, Battle_variable.name[k], Character_skill._damage, MainWindow.end_time - MainWindow.flow_time));
                                                MainWindow.WriteLog(string.Format("{0}{1}의 남은 HP: {2}\n", k, Battle_variable.name[k], Battle_variable.HP[k]));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int k = 0; k < 15; k++)
                                    {
                                        if (Battle_variable.death[k] == false)
                                        {
                                            Battle_theorem.damage_step("11", Battle_variable.bomb_coef[j, i], 1, 0, Battle_variable.bomb_index[j, i], k);

                                            if (max_repeat == 1)
                                            {
                                                MainWindow.WriteLog(string.Format("\n({5:F2}) {0}{1}의 폭탄이 폭발하여 적 전체 {2}{3}에게 {4:F2} 물리 대미지\n", i, Battle_variable.name[i], k, Battle_variable.name[k], Character_skill._damage, MainWindow.end_time - MainWindow.flow_time));
                                                MainWindow.WriteLog(string.Format("{0}{1}의 남은 HP: {2}\n", k, Battle_variable.name[k], Battle_variable.HP[k]));
                                            }
                                        }
                                    }
                                }

                                Battle_variable.bomb[j, i] = false;
                                Battle_variable.bomb_time[j, i] = 0;
                                Battle_variable.bomb_coef[j, i] = 0;
                                Battle_variable.bomb_index[j, i] = -1;
                            }
                        }
                    }
                }

                //필드형 버프
                for (i = 0; i < 100; i++)
                {
                    // field[i,0]은 필드의 생성여부, field_double[i,0]은 좌측 끝, field_double[i,1]은 우측 끝, field_double[i,2]는 필드 지속시간, field_double[i,3]은 필드 버프 계수를 나타냄
                    // field_string[i,0]은 필드 버프 종류, field_int[i,0]은 필드 시전자의 인덱스, field_int[i,1]은 필드의 효과가 아군인가 적군인가를 나타냄
                    if (Battle_variable.field[i, 0] == true)
                    {
                        if ((Battle_variable.field_int[i, 0] < 15 && Battle_variable.field_int[i, 1] == 1) || (Battle_variable.field_int[i, 0] >= 15 && Battle_variable.field_int[i, 1] == 2))
                        {
                            for (int j = 15; j < 30; j++)
                            {
                                if (Battle_variable.death[j] == false)
                                {
                                    if (Battle_variable.position[j] > Battle_variable.field_double[i, 0] && Battle_variable.position[j] < Battle_variable.field_double[i, 1])
                                    {
                                        if (Battle_variable.field_string[i, 0] != "poison" && Battle_variable.field_string[i, 0] != "toxic" && Battle_variable.field_string[i, 0] != "curse" && Battle_variable.field_string[i, 0] != "burn" && Battle_variable.field_string[i, 0] != "ConHP" && Battle_variable.field_string[i, 0] != "ConTP" && Battle_variable.field_string[i, 0] != "field_M")
                                        {
                                            Battle_fomular.buff_process(Battle_variable.field_string[i, 0], Battle_variable.field_double[i, 3], -1, j, j);
                                        }
                                        else if ((Battle_variable.field_string[i, 0] == "poison" || Battle_variable.field_string[i, 0] == "toxic" || Battle_variable.field_string[i, 0] == "curse" || Battle_variable.field_string[i, 0] == "burn") && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            double damage = Battle_fomular.damage_process("99", Battle_variable.field_double[i, 3], j, j);
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "ConHP" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 지속HP회복 버프로 인해 {1} 회복", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            Battle_variable.HP[j] += Battle_variable.field_double[i, 3];
                                            Battle_fomular.max_HP_Process();
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "ConTP" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 지속TP회복 버프로 인해 {1} 회복", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            Battle_variable.TP[j] += Battle_variable.field_double[i, 3] * (100 + Math.Max(0, Battle_variable.TPup[j])) / 100;
                                            Battle_fomular.max_TP_Process();
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "field_P" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            //Battle_theorem.damage_step("1", Battle_variable.field_double[i, 3], 1, 0, j, j);
                                            double damage = Battle_variable.field_double[i, 3] / (1 + Math.Max(0, Battle_variable.PD[j]) / 100);
                                            Battle_fomular.damage_process("1", damage, j, j);
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "field_M" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            //Battle_theorem.damage_step("2", Battle_variable.field_double[i, 3], 1, 0, j, j);
                                            double damage = Battle_variable.field_double[i, 3] / (1 + Math.Max(0, Battle_variable.MD[j]) / 100);
                                            Battle_fomular.damage_process("2", damage, j, j);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if (Battle_variable.death[j] == false)
                                {
                                    if (Battle_variable.position[j] > Battle_variable.field_double[i, 0] && Battle_variable.position[j] < Battle_variable.field_double[i, 1])
                                    {
                                        if (Battle_variable.field_string[i, 0] != "poison" && Battle_variable.field_string[i, 0] != "toxic" && Battle_variable.field_string[i, 0] != "curse" && Battle_variable.field_string[i, 0] != "burn" && Battle_variable.field_string[i, 0] != "ConHP" && Battle_variable.field_string[i, 0] != "ConTP" && Battle_variable.field_string[i, 0] != "field_M")
                                        {
                                            Battle_fomular.buff_process(Battle_variable.field_string[i, 0], Battle_variable.field_double[i, 3], -1, j, j);
                                        }
                                        else if ((Battle_variable.field_string[i, 0] == "poison" || Battle_variable.field_string[i, 0] == "toxic" || Battle_variable.field_string[i, 0] == "curse" || Battle_variable.field_string[i, 0] == "burn") && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            double damage = Battle_fomular.damage_process("99", Battle_variable.field_double[i, 3], j, j);
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "ConHP" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 지속HP회복 버프로 인해 {1} 회복", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            Battle_variable.HP[j] += Battle_variable.field_double[i, 3];
                                            Battle_fomular.max_HP_Process();
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "ConTP" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 지속TP회복 버프로 인해 {1} 회복", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            Battle_variable.TP[j] += Battle_variable.field_double[i, 3] * (100 + Math.Max(0, Battle_variable.TPup[j])) / 100;
                                            Battle_fomular.max_TP_Process();
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "field_P" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            Battle_theorem.damage_step("1", Battle_variable.field_double[i, 3], 1, 0, j, j);
                                            double damage = Battle_variable.field_double[i, 3] / (1 + Math.Max(0, Battle_variable.PD[j]) / 100);
                                            Battle_fomular.damage_process("1", damage, j, j);
                                        }
                                        else if (Battle_variable.field_string[i, 0] == "field_M" && Battle_variable.field_double[i, 2] % 1 > 0.4995 && Battle_variable.field_double[i, 2] % 1 < 0.5005)
                                        {
                                            //Debug.WriteLine("{0}가 필드로 인해 {1} 대미지", Battle_variable.name[j], Battle_variable.field_double[i, 3]);
                                            //Battle_theorem.damage_step("2", Battle_variable.field_double[i, 3], 1, 0, j, j);
                                            double damage = Battle_variable.field_double[i, 3] / (1 + Math.Max(0, Battle_variable.MD[j]) / 100);
                                            Battle_fomular.damage_process("2", damage, j, j);
                                        }
                                    }
                                }
                            }
                        }
                        Battle_variable.field_double[i, 2] -= 0.001;



                        if (Battle_variable.field_double[i, 2] < 0)
                        {
                            //Debug.WriteLine("{3}{0}의 필드 {1}:{2}가 해제됨", Battle_variable.name[Battle_variable.field_int[i, 0]], Battle_variable.field_string[i, 0], Battle_variable.field_double[i, 3], Battle_variable.field_int[i, 0]);
                            Battle_variable.field[i, 0] = false;
                            Battle_variable.field_double[i, 0] = 0;
                            Battle_variable.field_double[i, 1] = 0;
                            Battle_variable.field_double[i, 2] = 0;
                            Battle_variable.field_double[i, 3] = 0;
                            Battle_variable.field_string[i, 0] = "";
                            Battle_variable.field_int[i, 0] = 0;
                            Battle_variable.field_int[i, 1] = 0;
                        }
                    }
                }

                //가장 가까운 적과의 거리 결정
                double[] distance = Enumerable.Repeat<double>(1000000, 15).ToArray<double>();
                double[] least_distance = Enumerable.Repeat<double>(1000000, 30).ToArray<double>();
                int[] least_order = Enumerable.Repeat<int>(-1, 30).ToArray<int>();
                Battle_variable.battle_positionset();

                for (i = 0; i < 15; i++)
                {
                    if (Battle_variable.death[i] == false)
                    {
                        if (Battle_variable.enchant[i] == false && Battle_variable.confuse[i] == false)
                        {
                            for (int j = 15; j < 30; j++)
                            {
                                if ((Battle_variable.position_front[j] < Battle_variable.position[i] && Battle_variable.position[i] < Battle_variable.position_rear[j]) || (Battle_variable.position_front[j] > Battle_variable.position[i] && Battle_variable.position[i] > Battle_variable.position_rear[j]))
                                {
                                    distance[j - 15] = 0;
                                }
                                else
                                {
                                    distance[j - 15] = Math.Min(Math.Abs(Battle_variable.position_front[j] - Battle_variable.position[i]), Math.Abs(Battle_variable.position_rear[j] - Battle_variable.position[i]));
                                }
                            }
                            for (int j = 0; j < 15; j++)
                            {
                                if (least_distance[i] > distance[j] && Battle_variable.death[j + 15] == false)
                                {
                                    least_distance[i] = distance[j];
                                    least_order[i] = j + 15;
                                }
                            }
                            if (least_distance[i] > 900000)
                            {
                                least_distance[i] = 0;
                                least_order[i] = i;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if ((Battle_variable.position_front[j] < Battle_variable.position[i] && Battle_variable.position[i] < Battle_variable.position_rear[j]) || (Battle_variable.position_front[j] > Battle_variable.position[i] && Battle_variable.position[i] > Battle_variable.position_rear[j]))
                                {
                                    distance[j] = 0;
                                }
                                else
                                {
                                    distance[j] = Math.Min(Math.Abs(Battle_variable.position_front[j] - Battle_variable.position[i]), Math.Abs(Battle_variable.position_rear[j] - Battle_variable.position[i]));
                                }
                            }
                            for (int j = 0; j < 15; j++)
                            {
                                if (least_distance[i] > distance[j] && Battle_variable.death[j] == false && i != j)
                                {
                                    least_distance[i] = distance[j];
                                    least_order[i] = j;
                                }
                            }
                            if (least_distance[i] > 900000)
                            {
                                least_distance[i] = 0;
                                least_order[i] = i;
                            }
                        }
                    }
                }
                for (i = 15; i < 30; i++)
                {
                    if (Battle_variable.death[i] == false)
                    {
                        if (Battle_variable.enchant[i] == false && Battle_variable.confuse[i] == false)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if ((Battle_variable.position_front[j] < Battle_variable.position[i] && Battle_variable.position[i] < Battle_variable.position_rear[j]) || (Battle_variable.position_front[j] > Battle_variable.position[i] && Battle_variable.position[i] > Battle_variable.position_rear[j]))
                                {
                                    distance[j] = 0;
                                }
                                else
                                {
                                    distance[j] = Math.Min(Math.Abs(Battle_variable.position_front[j] - Battle_variable.position[i]), Math.Abs(Battle_variable.position_rear[j] - Battle_variable.position[i]));
                                }
                            }
                            for (int j = 0; j < 15; j++)
                            {
                                if (least_distance[i] > distance[j] && Battle_variable.death[j] == false)
                                {
                                    least_distance[i] = distance[j];
                                    least_order[i] = j;
                                }
                            }
                            if (least_distance[i] > 900000)
                            {
                                least_distance[i] = 0;
                                least_order[i] = i;
                            }
                        }
                        else
                        {
                            for (int j = 15; j < 30; j++)
                            {
                                if ((Battle_variable.position_front[j] < Battle_variable.position[i] && Battle_variable.position[i] < Battle_variable.position_rear[j]) || (Battle_variable.position_front[j] > Battle_variable.position[i] && Battle_variable.position[i] > Battle_variable.position_rear[j]))
                                {
                                    distance[j - 15] = 0;
                                }
                                else
                                {
                                    distance[j - 15] = Math.Min(Math.Abs(Battle_variable.position_front[j] - Battle_variable.position[i]), Math.Abs(Battle_variable.position_rear[j] - Battle_variable.position[i]));
                                }
                            }
                            for (int j = 0; j < 15; j++)
                            {
                                if (least_distance[i] > distance[j] && Battle_variable.death[j + 15] == false && i != (j + 15))
                                {
                                    least_distance[i] = distance[j];
                                    least_order[i] = j + 15;
                                }
                            }
                            if (least_distance[i] > 900000)
                            {
                                least_distance[i] = 0;
                                least_order[i] = i;
                            }
                        }
                    }
                }

                //방어덱이 행동 우선 
                for (i = 0; i < 15; i++)//방어덱 행동
                {
                    //행동 결정
                    if (Battle_variable.death[i] == false)
                    {
                        //필요한 정보들 가져오기
                        FieldInfo dummy1 = crc.GetType().GetField(string.Format("{0}", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                        double[] array1_CRC = (double[])dummy1.GetValue(crc);//사거리, 캐스팅시간
                        FieldInfo dummy2 = Cp.GetType().GetField(string.Format("{0}", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                        double[] array2_CP = (double[])dummy2.GetValue(Cp);//캐릭터의 공격 패턴

                        if ((Battle_variable.name_eng[i] == "anna" && Battle_variable.HP[i] / Battle_variable.max_HP[i] <= 0.1) || anna_bomb == true)
                        {
                            if (anna_bomb == false)
                            {
                                A_timing[i] = 0;
                                anna_bomb = true;
                            }
                            Character_skill.anna_1002(A_timing[i], i);
                            continue;
                        }

                        if (state[i] == "FM")//FM 상태의 행동
                        {
                            Battle_variable.Mspeed_coef[i] = 720;

                            if (Battle_variable.name_eng[i] == "rima")//리마 예외:바로 W->A 상태로 넘어가서 1001스킬 사용, 위치에 도달하면 풀림
                            {
                                state[i] = "W";
                                A_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            if (Battle_variable.name_eng[i] == "muimi_newyear")//뉴이미 예외:바로 W->A 상태로 넘어가서 1001스킬 사용, 위치에 도달하면 풀림
                            {
                                state[i] = "W";
                                A_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            else
                            {
                                if (least_distance[i] > array1_CRC[1])
                                {
                                    Battle_variable.position[i] = Battle_variable.position[i] + Battle_variable.Mspeed_coef[i] * 0.001;
                                }
                                else
                                {
                                    state[i] = "W";
                                    A_timing[i] = 0;
                                    Battle_variable.Mspeed_coef[i] = 450;


                                    if (array2_CP[Action_next_seq[i] + 1] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i] + 1] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                    {
                                        if (Level_variable.equip[i] == true)
                                        {
                                            C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                        }
                                        else
                                        {
                                            C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                        }
                                    }
                                    else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }

                                    Action_next_seq[i] += 1;
                                    if (Action_next_seq[i] == 14)
                                    {
                                        Action_next_seq[i] += 1;
                                    }
                                }
                            }
                        }
                        else if (state[i] == "W")
                        {
                            if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && 
                                Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                            {
                                W_timing[i] += 0.001;
                            }

                            if (W_timing[i] >= 2.466)
                            {
                                state[i] = "A";
                            }
                        }
                        else if (state[i] == "M")//M 상태의 행동
                        {
                            if (least_distance[i] > array1_CRC[1])
                            {
                                if (Battle_variable.enchant[i] == true || Battle_variable.confuse[i] == true)
                                {
                                    if (Battle_variable.position[least_order[i]] < Battle_variable.position[i])
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] - Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                    else
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] + Battle_variable.Mspeed_coef[i] * 0.001;
                                    }

                                    if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                                    {
                                        Battle_variable.enchant_break[i] = true;
                                    }
                                    if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                                    {
                                        Battle_variable.confuse_break[i] = true;
                                    }
                                }
                                else if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false &&
                                    Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                                {
                                    if (Battle_variable.position[least_order[i]] < Battle_variable.position[i])
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] - Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                    else
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] + Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                }

                                if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                                {
                                    Battle_variable.enchant_break[i] = false;
                                }
                                if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                                {
                                    Battle_variable.confuse_break[i] = false;
                                }
                            }
                            else
                            {
                                state[i] = "C";
                            }
                        }
                        else if (state[i] == "A")//A 상태의 행동
                        {
                            if (A_timing[i] < 0)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }
                                continue;
                            }

                            if (Battle_variable.paralyze[i] == true || Battle_variable.stun[i] == true || Battle_variable.knockback[i] == true || Battle_variable.bind[i] == true || 
                                Battle_variable.freeze[i] == true || Battle_variable.timestop[i] == true || Battle_variable.delay[i] == true || Battle_variable.sleep[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }
                                continue;
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.enchant_break[i] = true;
                                continue;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.confuse_break[i] = true;
                                continue;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.enchant_break[i] = false;
                                continue;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.confuse_break[i] = false;
                                continue;
                            }

                            MethodInfo skilldummy = Cs.GetType().GetMethod(string.Format("{0}_{1}", Battle_variable.name_eng[i], array2_CP[Action_seq[i] + 1]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                            A_timing[i] = (double)skilldummy.Invoke(Cs, new Object[] { A_timing[i], i });


                            if (((Battle_variable.name_eng[i] == "sinobu" && Array.IndexOf(Battle_variable.name_eng, "skull", 0, 15) != -1 && i < 15) || (Battle_variable.name_eng[i] == "sinobu" && Array.IndexOf(Battle_variable.name_eng, "skull", 15, 15) != -1 && i >= 15)) && array2_CP[Action_seq[i] + 1] == 1001 && A_timing[i] > 0.8675 && A_timing[i] < 0.8685)
                            {
                                int a;
                                if (i < 15)
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "skull", 0, 15);
                                }
                                else
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "skull", 15, 15);
                                }

                                state[a] = "C";

                                Action_seq[a] = 1;
                                Action_next_seq[a] = 2;

                                C_timing[a] = 0;
                                C_next_timing[a] = 0;

                                if (array2_CP[Action_next_seq[a]] == 0)
                                {
                                    Action_next_seq[a] = (int)array2_CP[0];
                                }
                            }

                            if (((Battle_variable.name_eng[i] == "suzume_summer" && Array.IndexOf(Battle_variable.name_eng, "golem", 0, 15) != -1 && i < 15) || (Battle_variable.name_eng[i] == "suzume_summer" && Array.IndexOf(Battle_variable.name_eng, "golem", 15, 15) != -1 && i >= 15)) && array2_CP[Action_seq[i] + 1] == 1001 && A_timing[i] > 0.0005 && A_timing[i] < 0.0015)
                            {
                                int a;
                                if (i < 15)
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "golem", 0, 15);
                                }
                                else
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "golem", 15, 15);
                                }


                                state[a] = "C";

                                Action_seq[a] = 1;
                                Action_next_seq[a] = 2;

                                C_timing[a] = 0;
                                C_next_timing[a] = 0;

                                if (array2_CP[Action_next_seq[a]] == 0)
                                {
                                    Action_next_seq[a] = (int)array2_CP[0];
                                }
                            }
                        }
                        else if (state[i] == "C")//C 상태의 행동
                        {
                            if (least_distance[i] > array1_CRC[1])
                            {
                                state[i] = "M";
                            }
                            else if (C_timing[i] > C_next_timing[i])
                            {
                                state[i] = "A";
                                A_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            else if (Battle_variable.TP[i] >= 1000 && Battle_variable.confuse[i] == false && Battle_variable.enchant[i] == false && Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && 
                                Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false
                                && Battle_variable.sleep[i] == false)
                            {
                                if (Battle_variable.name_eng[i] != "skull" && Battle_variable.name_eng[i] != "sylph_chika" && Battle_variable.name_eng[i] != "sylph_chika_christmas_1" && Battle_variable.name_eng[i] != "sylph_chika_christmas_2" && Battle_variable.name_eng[i] != "sylph_chika_christmas_3" && Battle_variable.name_eng[i] != "golem" && Battle_variable.name_eng[i] != "neneka_alter" && Battle_variable.name_eng[i] != "muimi_ub" && Battle_variable.name_eng[i] != "labyrista_ub")
                                {
                                    state[i] = "UB";
                                    UB_timing[i] = 0;
                                }
                            }

                            if (Battle_variable.name_eng[i] == "labyrista_ub" && array2_CP[Action_seq[i]] == 2003 && array2_CP[Action_next_seq[i]] == 2003)
                            {
                                Battle_variable.name_eng[i] = "labyrista";
                                Action_seq[i] = 1;
                                Action_next_seq[i] = 2;

                                C_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i]] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i]] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                {
                                    C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                if (max_repeat == 1)
                                {
                                    WriteLog(String.Format( "\n{0}{1}의 UB 모드가 해제됨", i, Battle_variable.name[i]));
                                }
                            }
                            
                            if (Battle_variable.name_eng[i] == "muimi_ub" && Battle_variable.TP[i] == 0)
                            {
                                Battle_variable.name_eng[i] = "muimi";
                                Action_seq[i] = 1;
                                Action_next_seq[i] = 2;

                                C_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i]] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i]] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }


                                if (max_repeat == 1)
                                {
                                    Debug.WriteLine("\n{0}{1}의 UB 모드가 해제됨", i, Battle_variable.name[i]);
                                }
                            }

                            if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && 
                                Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                            {
                                C_timing[i] += 0.001;
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                Battle_variable.enchant_break[i] = true;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                Battle_variable.confuse_break[i] = true;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                Battle_variable.enchant_break[i] = false;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                Battle_variable.confuse_break[i] = false;
                            }
                        }
                        else if (state[i] == "UB")//UB 상태의 행동
                        {
                            if (UB_timing[i] < 0.0001)
                            {
                                MethodInfo skilldummy = Cs.GetType().GetMethod(string.Format("{0}_UB", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                                UB_ending[i] = (double)skilldummy.Invoke(Cs, new Object[] { i });


                                if (Battle_variable.name_eng[i] == "muimi_ub")
                                {
                                    Action_seq[i] = 1;
                                    Action_next_seq[i] = 2;

                                    C_timing[i] = 0;

                                    if (array2_CP[Action_next_seq[i]] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i]] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                    {
                                        if (Level_variable.equip[i] == true)
                                        {
                                            C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                        }
                                        else
                                        {
                                            C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                        }
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }
                                }

                                if (Battle_variable.name_eng[i] == "labyrista_ub")
                                {
                                    Action_seq[i] = 1;
                                    Action_next_seq[i] = 2;

                                    C_timing[i] = 0;

                                    if (array2_CP[Action_next_seq[i]] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i]] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                       
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }
                                }


                                if (Battle_variable.name_eng[i] == "chika" && Array.IndexOf(Battle_variable.name_eng, "sylph_chika") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15, 15);
                                    }


                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }
                                }


                                if (Battle_variable.name_eng[i] == "chika_christmas" && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1") != -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2") != -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15, 15);
                                    }
                                    int b;
                                    if (i < 15)
                                    {
                                        b = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0, 15);
                                    }
                                    else
                                    {
                                        b = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15, 15);
                                    }
                                    int c;
                                    if (i < 15)
                                    {
                                        c = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0, 15);
                                    }
                                    else
                                    {
                                        c = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15, 15);
                                    }


                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }


                                    state[b] = "C";

                                    Action_seq[b] = 1;
                                    Action_next_seq[b] = 2;

                                    C_timing[b] = 0;
                                    C_next_timing[b] = 0;

                                    if (array2_CP[Action_next_seq[b]] == 0)
                                    {
                                        Action_next_seq[b] = (int)array2_CP[0];
                                    }


                                    state[c] = "C";

                                    Action_seq[c] = 1;
                                    Action_next_seq[c] = 2;

                                    C_timing[c] = 0;
                                    C_next_timing[c] = 0;

                                    if (array2_CP[Action_next_seq[c]] == 0)
                                    {
                                        Action_next_seq[c] = (int)array2_CP[0];
                                    }
                                }

                                if (Battle_variable.name_eng[i] == "neneka" && Array.IndexOf(Battle_variable.name_eng, "neneka_alter") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15, 15);
                                    }


                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }
                                }
                            }


                            if (UB_timing[i] > UB_ending[i])
                            {
                                state[i] = "C";
                            }

                            if (Battle_variable.paralyze[i] == true || Battle_variable.stun[i] == true || Battle_variable.knockback[i] == true || Battle_variable.bind[i] == true || Battle_variable.freeze[i] == true ||
                                Battle_variable.timestop[i] == true || Battle_variable.delay[i] == true || Battle_variable.sleep[i] == true)
                            {
                                state[i] = "C";
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                state[i] = "C";

                                Battle_variable.enchant_break[i] = true;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                state[i] = "C";

                                Battle_variable.confuse_break[i] = true;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                state[i] = "C";

                                Battle_variable.enchant_break[i] = false;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                state[i] = "C";

                                Battle_variable.confuse_break[i] = false;
                            }

                            UB_timing[i] += 0.001;
                        }
                    }
                    else
                    {
                        state[i] = "C";
                        C_timing[i] = 0;
                        Action_seq[i] = 1;
                        Action_next_seq[i] = 2;
                        C_timing[i] = 0;
                        C_next_timing[i] = -1;
                    }
                }

                //공격자 행동
                for (i = 15; i < 30; i++)//공격덱 행동
                {
                    //행동 결정
                    if (Battle_variable.death[i] == false)
                    {
                        //필요한 정보들 가져오기
                        FieldInfo dummy1 = crc.GetType().GetField(string.Format("{0}", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                        double[] array1_CRC = (double[])dummy1.GetValue(crc);//사거리, 캐스팅시간
                        FieldInfo dummy2 = Cp.GetType().GetField(string.Format("{0}", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                        double[] array2_CP = (double[])dummy2.GetValue(Cp);//캐릭터의 공격 패턴

                        if ((Battle_variable.name_eng[i] == "anna" && Battle_variable.HP[i] / Battle_variable.max_HP[i] <= 0.1) || anna_bomb_est == true)
                        {
                            if (anna_bomb_est == false)
                            {
                                A_timing[i] = 0;
                                anna_bomb_est = true;
                            }
                            Character_skill.anna_1002(A_timing[i], i);
                            continue;
                        }

                        if (state[i] == "FM")//FM 상태의 행동
                        {
                            Battle_variable.Mspeed_coef[i] = 720;

                            if (Battle_variable.name_eng[i] == "rima")//리마 예외:FM 상태에서 1001스킬 계속 사용, 위치에 도달하면 풀림
                            {
                                state[i] = "W";
                                A_timing[i] = 0;


                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            if (Battle_variable.name_eng[i] == "muimi_newyear")//뉴이미 예외:FM 상태에서 1001스킬 계속 사용, 위치에 도달하면 풀림
                            {
                                state[i] = "W";
                                A_timing[i] = 0;


                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            else
                            {
                                if (least_distance[i] > array1_CRC[1])
                                {
                                    Battle_variable.position[i] = Battle_variable.position[i] - Battle_variable.Mspeed_coef[i] * 0.001;
                                }
                                else
                                {
                                    state[i] = "W";
                                    A_timing[i] = 0;
                                    Battle_variable.Mspeed_coef[i] = 450;


                                    if (array2_CP[Action_next_seq[i] + 1] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i] + 1] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                    {
                                        if (Level_variable.equip[i] == true)
                                        {
                                            C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                        }
                                        else
                                        {
                                            C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                        }
                                    }
                                    else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }

                                    Action_next_seq[i] += 1;
                                    if (Action_next_seq[i] == 14)
                                    {
                                        Action_next_seq[i] += 1;
                                    }
                                }
                            }
                        }
                        else if (state[i] == "W")
                        {
                            if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && Battle_variable.freeze[i] == false &&
                                Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                            {
                                W_timing[i] += 0.001;
                            }

                            if (W_timing[i] >= 2.466)
                            {
                                state[i] = "A";
                            }
                        }
                        else if (state[i] == "M")//M 상태의 행동
                        {
                            if (least_distance[i] > array1_CRC[1])
                            {
                                if (Battle_variable.enchant[i] == true || Battle_variable.confuse[i] == true)
                                {
                                    if (Battle_variable.position[least_order[i]] < Battle_variable.position[i])
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] - Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                    else
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] + Battle_variable.Mspeed_coef[i] * 0.001;
                                    }

                                    if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                                    {
                                        Battle_variable.enchant_break[i] = true;
                                    }
                                    if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                                    {
                                        Battle_variable.confuse_break[i] = true;
                                    }
                                }
                                else if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false 
                                    && Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                                {
                                    if (Battle_variable.position[least_order[i]] < Battle_variable.position[i])
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] - Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                    else
                                    {
                                        Battle_variable.position[i] = Battle_variable.position[i] + Battle_variable.Mspeed_coef[i] * 0.001;
                                    }
                                }

                                if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                                {
                                    Battle_variable.enchant_break[i] = false;
                                }
                                if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                                {
                                    Battle_variable.confuse_break[i] = false;
                                }
                            }
                            else
                            {
                                state[i] = "C";
                            }
                        }
                        else if (state[i] == "A")//A 상태의 행동
                        {
                            if (A_timing[i] < 0)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }
                                continue;
                            }

                            if (Battle_variable.paralyze[i] == true || Battle_variable.stun[i] == true || Battle_variable.knockback[i] == true || Battle_variable.bind[i] == true || Battle_variable.freeze[i] == true || 
                                Battle_variable.timestop[i] == true || Battle_variable.delay[i] == true || Battle_variable.sleep[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }
                                continue;
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.enchant_break[i] = true;
                                continue;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.confuse_break[i] = true;
                                continue;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.enchant_break[i] = false;
                                continue;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                state[i] = "C";

                                C_timing[i] = 0;
                                Action_seq[i] += 1;
                                if (Action_seq[i] == 14)
                                {
                                    Action_seq[i] += 1;
                                }
                                if (array2_CP[Action_seq[i] + 1] == 0)
                                {
                                    Action_seq[i] = (int)array2_CP[0];
                                }

                                Battle_variable.confuse_break[i] = false;
                                continue;
                            }

                            MethodInfo skilldummy = Cs.GetType().GetMethod(string.Format("{0}_{1}", Battle_variable.name_eng[i], array2_CP[Action_seq[i] + 1]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                            A_timing[i] = (double)skilldummy.Invoke(Cs, new Object[] { A_timing[i], i });

                            if (((Battle_variable.name_eng[i] == "sinobu" && Array.IndexOf(Battle_variable.name_eng, "skull", 0, 15) != -1 && i < 15) || (Battle_variable.name_eng[i] == "sinobu" && Array.IndexOf(Battle_variable.name_eng, "skull", 15, 15) != -1 && i >= 15)) && array2_CP[Action_seq[i] + 1] == 1001 && A_timing[i] > 0.8675 && A_timing[i] < 0.8685)
                            {
                                int a;
                                if (i < 15)
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "skull", 0, 15);
                                }
                                else
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "skull", 15, 15);
                                }


                                state[a] = "C";

                                Action_seq[a] = 1;
                                Action_next_seq[a] = 2;

                                C_timing[a] = 0;
                                C_next_timing[a] = 0;

                                if (array2_CP[Action_next_seq[a]] == 0)
                                {
                                    Action_next_seq[a] = (int)array2_CP[0];
                                }
                            }


                            if (((Battle_variable.name_eng[i] == "suzume_summer" && Array.IndexOf(Battle_variable.name_eng, "golem", 0, 15) != -1 && i < 15) || (Battle_variable.name_eng[i] == "suzume_summer" && Array.IndexOf(Battle_variable.name_eng, "golem", 15, 15) != -1 && i >= 15)) && array2_CP[Action_seq[i] + 1] == 1001 && A_timing[i] > 0.0005 && A_timing[i] < 0.0015)
                            {
                                int a;
                                if (i < 15)
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "golem", 0, 15);
                                }
                                else
                                {
                                    a = Array.IndexOf(Battle_variable.name_eng, "golem", 15, 15);
                                }


                                state[a] = "C";

                                Action_seq[a] = 1;
                                Action_next_seq[a] = 2;

                                C_timing[a] = 0;
                                C_next_timing[a] = 0;

                                if (array2_CP[Action_next_seq[a]] == 0)
                                {
                                    Action_next_seq[a] = (int)array2_CP[0];
                                }
                            }
                        }
                        else if (state[i] == "C")//C 상태의 행동
                        {
                            if (least_distance[i] > array1_CRC[1])
                            {
                                state[i] = "M";
                            }
                            else if (C_timing[i] > C_next_timing[i])
                            {
                                state[i] = "A";
                                A_timing[i] = 0;


                                if (array2_CP[Action_next_seq[i] + 1] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i] + 1] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1001 || array2_CP[Action_next_seq[i] + 1] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i] + 1] == 1002 || array2_CP[Action_next_seq[i] + 1] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                Action_next_seq[i] += 1;
                                if (Action_next_seq[i] == 14)
                                {
                                    Action_next_seq[i] += 1;
                                }
                            }
                            else if (Battle_variable.TP[i] >= 1000 && Battle_variable.confuse[i] == false && Battle_variable.enchant[i] == false && Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false 
                                && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && Battle_variable.freeze[i] == false && Battle_variable.timestop[i] == false 
                                && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false)
                            {
                                if (Battle_variable.name_eng[i] != "skull" && Battle_variable.name_eng[i] != "sylph_chika" && Battle_variable.name_eng[i] != "sylph_chika_christmas_1" && Battle_variable.name_eng[i] != "sylph_chika_christmas_2" && Battle_variable.name_eng[i] != "sylph_chika_christmas_3" && Battle_variable.name_eng[i] != "golem" && Battle_variable.name_eng[i] != "neneka_alter" && Battle_variable.name_eng[i] != "muimi_ub" && Battle_variable.name_eng[i] != "labyrista_ub")
                                {
                                    state[i] = "UB";
                                    UB_timing[i] = 0;
                                }
                            }
                            if (Battle_variable.name_eng[i] == "labyrista_ub" && array2_CP[Action_seq[i]] == 2003 && array2_CP[Action_next_seq[i]] == 2003)
                            {
                                Battle_variable.name_eng[i] = "labyrista";
                                Action_seq[i] = 1;
                                Action_next_seq[i] = 2;

                                C_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i]] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i]] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                {
                                    C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];

                                }
                                else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                if (max_repeat == 1)
                                {
                                    WriteLog(String.Format("\n{0}{1}의 UB 모드가 해제됨", i, Battle_variable.name[i]));
                                }
                            }

                            if (Battle_variable.name_eng[i] == "muimi_ub" && Battle_variable.TP[i] == 0)
                            {
                                Battle_variable.name_eng[i] = "muimi";
                                Action_seq[i] = 1;
                                Action_next_seq[i] = 2;

                                C_timing[i] = 0;

                                if (array2_CP[Action_next_seq[i]] == 0)
                                {
                                    Action_next_seq[i] = (int)array2_CP[0];
                                }

                                if (array2_CP[Action_next_seq[i]] == 1)
                                {
                                    C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                {
                                    if (Level_variable.equip[i] == true)
                                    {
                                        C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                    }
                                }
                                else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                {
                                    C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                }

                                if (max_repeat == 1)
                                {
                                    Debug.WriteLine("\n{0}{1}의 UB 모드가 해제됨", i, Battle_variable.name[i]);
                                }
                            }

                            if (Battle_variable.paralyze[i] == false && Battle_variable.stun[i] == false && Battle_variable.knockback[i] == false && Battle_variable.bind[i] == false && Battle_variable.freeze[i] == false
                                && Battle_variable.timestop[i] == false && Battle_variable.delay[i] == false && Battle_variable.sleep[i] == false) 
                            {
                                C_timing[i] += 0.001;
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                Battle_variable.enchant_break[i] = true;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                Battle_variable.confuse_break[i] = true;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                Battle_variable.enchant_break[i] = false;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                Battle_variable.confuse_break[i] = false;
                            }
                        }
                        else if (state[i] == "UB")//UB 상태의 행동
                        {
                            if (UB_timing[i] < 0.0001)
                            {
                                string temp =string.Format("{0}_UB", Battle_variable.name_eng[i]);
                                Debug.Write("temp = ");
                                Debug.WriteLine(temp);
                                MethodInfo skilldummy = Cs.GetType().GetMethod(string.Format("{0}_UB", Battle_variable.name_eng[i]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
                                UB_ending[i] = (double)skilldummy.Invoke(Cs, new Object[] { i });


                                if (Battle_variable.name_eng[i] == "muimi_ub")
                                {
                                    Action_seq[i] = 1;
                                    Action_next_seq[i] = 2;

                                    C_timing[i] = 0;

                                    if (array2_CP[Action_next_seq[i]] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i]] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                    {
                                        if (Level_variable.equip[i] == true)
                                        {
                                            C_next_timing[i] = array1_CRC[5] / Battle_variable.Aspeed_coef[i];
                                        }
                                        else
                                        {
                                            C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];
                                        }
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }
                                }


                                if (Battle_variable.name_eng[i] == "chika" && Array.IndexOf(Battle_variable.name_eng, "sylph_chika") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15, 15);
                                    }


                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }
                                }

                                if (Battle_variable.name_eng[i] == "labyrista_ub")
                                {
                                    Action_seq[i] = 1;
                                    Action_next_seq[i] = 2;

                                    C_timing[i] = 0;

                                    if (array2_CP[Action_next_seq[i]] == 0)
                                    {
                                        Action_next_seq[i] = (int)array2_CP[0];
                                    }

                                    if (array2_CP[Action_next_seq[i]] == 1)
                                    {
                                        C_next_timing[i] = array1_CRC[2] / Battle_variable.Aspeed_coef[i];
                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1001 || array2_CP[Action_next_seq[i]] == 2001)
                                    {
                                        C_next_timing[i] = array1_CRC[3] / Battle_variable.Aspeed_coef[i];

                                    }
                                    else if (array2_CP[Action_next_seq[i]] == 1002 || array2_CP[Action_next_seq[i]] == 2002)
                                    {
                                        C_next_timing[i] = array1_CRC[4] / Battle_variable.Aspeed_coef[i];
                                    }
                                }

                                if (Battle_variable.name_eng[i] == "chika_christmas" && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1") != -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2") != -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15, 15);
                                    }
                                    int b;
                                    if (i < 15)
                                    {
                                        b = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0, 15);
                                    }
                                    else
                                    {
                                        b = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15, 15);
                                    }
                                    int c;
                                    if (i < 15)
                                    {
                                        c = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0, 15);
                                    }
                                    else
                                    {
                                        c = Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15, 15);
                                    }


                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }


                                    state[b] = "C";

                                    Action_seq[b] = 1;
                                    Action_next_seq[b] = 2;

                                    C_timing[b] = 0;
                                    C_next_timing[b] = 0;

                                    if (array2_CP[Action_next_seq[b]] == 0)
                                    {
                                        Action_next_seq[b] = (int)array2_CP[0];
                                    }


                                    state[c] = "C";

                                    Action_seq[c] = 1;
                                    Action_next_seq[c] = 2;

                                    C_timing[c] = 0;
                                    C_next_timing[c] = 0;

                                    if (array2_CP[Action_next_seq[c]] == 0)
                                    {
                                        Action_next_seq[c] = (int)array2_CP[0];
                                    }
                                }

                                if (Battle_variable.name_eng[i] == "neneka" && Array.IndexOf(Battle_variable.name_eng, "neneka_alter") != -1)
                                {
                                    int a;
                                    if (i < 15)
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0, 15);
                                    }
                                    else
                                    {
                                        a = Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15, 15);
                                    }

                                    state[a] = "C";

                                    Action_seq[a] = 1;
                                    Action_next_seq[a] = 2;

                                    C_timing[a] = 0;
                                    C_next_timing[a] = 0;

                                    if (array2_CP[Action_next_seq[a]] == 0)
                                    {
                                        Action_next_seq[a] = (int)array2_CP[0];
                                    }
                                }
                            }

                            if (UB_timing[i] > UB_ending[i])
                            {
                                state[i] = "C";
                            }

                            if (Battle_variable.paralyze[i] == true || Battle_variable.stun[i] == true || Battle_variable.knockback[i] == true || Battle_variable.bind[i] == true || Battle_variable.freeze[i] == true || 
                                Battle_variable.timestop[i] == true || Battle_variable.delay[i] == true || Battle_variable.sleep[i] == true)
                            {
                                state[i] = "C";
                            }

                            if (Battle_variable.enchant[i] == true && Battle_variable.enchant_break[i] == false)
                            {
                                state[i] = "C";

                                Battle_variable.enchant_break[i] = true;
                            }
                            if (Battle_variable.confuse[i] == true && Battle_variable.confuse_break[i] == false)
                            {
                                state[i] = "C";

                                Battle_variable.confuse_break[i] = true;
                            }
                            if (Battle_variable.enchant[i] == false && Battle_variable.enchant_break[i] == true)
                            {
                                state[i] = "C";

                                Battle_variable.enchant_break[i] = false;
                            }
                            if (Battle_variable.confuse[i] == false && Battle_variable.confuse_break[i] == true)
                            {
                                state[i] = "C";

                                Battle_variable.confuse_break[i] = false;
                            }

                            UB_timing[i] += 0.001;
                        }
                    }
                    else
                    {
                        state[i] = "C";
                        C_timing[i] = 0;
                        Action_seq[i] = 1;
                        Action_next_seq[i] = 2;
                        C_timing[i] = 0;
                        C_next_timing[i] = -1;
                    }
                }

                //한쪽의 승리 후 break
                int death_count1 = 0, death_count2 = 0;
                for (i = 0; i < 15; i++)
                {
                    if (Battle_variable.death[i] == true)
                    {
                        death_count1 += 1;
                    }
                }
                for (i = 15; i < 30; i++)
                {
                    if (Battle_variable.death[i] == true)
                    {
                        death_count2 += 1;
                    }
                }
                if (death_count1 == 15)
                {
                    //Debug.WriteLine("현재 방덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[0], Battle_variable.position[1], Battle_variable.position[2], Battle_variable.position[3], Battle_variable.position[4]);

                    //Debug.WriteLine("현재 공덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[15], Battle_variable.position[16], Battle_variable.position[17], Battle_variable.position[18], Battle_variable.position[19]);
                    Debug.WriteLine("\n현재 방덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[0], Battle_variable.HP[1], Battle_variable.HP[2], Battle_variable.HP[3], Battle_variable.HP[4]);
                    Debug.WriteLine("\n현재 공덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[15], Battle_variable.HP[16], Battle_variable.HP[17], Battle_variable.HP[18], Battle_variable.HP[19]);
                    Debug.WriteLine("\n남은 시간: {0}", end_time - flow_time);
                    //Debug.WriteLine("공격덱 승리");
                    //off_count += 1;
                    return 0;
                }
                if (death_count2 == 15)
                {
                    //Debug.WriteLine("현재 방덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[0], Battle_variable.position[1], Battle_variable.position[2], Battle_variable.position[3], Battle_variable.position[4]);

                    //Debug.WriteLine("현재 공덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[15], Battle_variable.position[16], Battle_variable.position[17], Battle_variable.position[18], Battle_variable.position[19]);
                    Debug.WriteLine("\n현재 방덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[0], Battle_variable.HP[1], Battle_variable.HP[2], Battle_variable.HP[3], Battle_variable.HP[4]);
                    Debug.WriteLine("\n현재 공덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[15], Battle_variable.HP[16], Battle_variable.HP[17], Battle_variable.HP[18], Battle_variable.HP[19]);
                    Debug.WriteLine("\n남은 시간: {0}", end_time - flow_time);
                    //Debug.WriteLine("방어덱 일반 승리");
                    //def_count += 1;
                    return 1;
                }
                if (flow_time > end_time)
                {
                    //Debug.WriteLine("현재 방덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[0], Battle_variable.position[1], Battle_variable.position[2], Battle_variable.position[3], Battle_variable.position[4]);

                    //Debug.WriteLine("현재 공덱 위치값: {0}, {1}, {2}, {3}, {4}", Battle_variable.position[15], Battle_variable.position[16], Battle_variable.position[17], Battle_variable.position[18], Battle_variable.position[19]);
                    Debug.WriteLine("\n현재 방덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[0], Battle_variable.HP[1], Battle_variable.HP[2], Battle_variable.HP[3], Battle_variable.HP[4]);
                    Debug.WriteLine("\n현재 공덱 HP: {0}, {1}, {2}, {3}, {4}", Battle_variable.HP[15], Battle_variable.HP[16], Battle_variable.HP[17], Battle_variable.HP[18], Battle_variable.HP[19]);
                    Debug.WriteLine("\n남은 시간: {0}", end_time - flow_time);
                    //Debug.WriteLine("방어덱 시간 승리");
                    //def_count += 1;

                    return 2;
                }
                flow_time += 0.001;
            }
        }

        //작마키, 프캬루까지
        public string CharaNameToID(string CharaName)
        {
            string ID;
            if (CharaName == "hiyori") { ID = "100161"; }

            else if (CharaName == "yui") { ID = "100261"; }
            else if (CharaName == "rei") { ID = "100361"; }
            else if (CharaName == "misogi") { ID = "100431"; }
            else if (CharaName == "matsuri") { ID = "100531"; }
            else if (CharaName == "akari") { ID = "100661"; }
            else if (CharaName == "miyako") { ID = "100731"; }
            else if (CharaName == "yuki") { ID = "100831"; }
            else if (CharaName == "anna") { ID = "100931"; }
            else if (CharaName == "maho") { ID = "101061"; }
            else if (CharaName == "rino") { ID = "101161"; }
            else if (CharaName == "hatsune") { ID = "101261"; }
            else if (CharaName == "nanaka") { ID = "101311"; }
            else if (CharaName == "kasumi") { ID = "101411"; }
            else if (CharaName == "misato") { ID = "101531"; }
            else if (CharaName == "suzuna") { ID = "101661"; }
            else if (CharaName == "kaori") { ID = "101731"; }
            else if (CharaName == "io") { ID = "101861"; }
            else if (CharaName == "mimi") { ID = "102031"; }
            else if (CharaName == "kurumi") { ID = "102131"; }
            else if (CharaName == "yori") { ID = "102231"; }
            else if (CharaName == "ayane") { ID = "102361"; }
            else if (CharaName == "suzume") { ID = "102531"; }
            else if (CharaName == "rin") { ID = "102631"; }
            else if (CharaName == "eriko") { ID = "102731"; }
            else if (CharaName == "saren") { ID = "102861"; }
            else if (CharaName == "nozomi") { ID = "102931"; }
            else if (CharaName == "ninon") { ID = "103061"; }
            else if (CharaName == "sinobu") { ID = "103131"; }
            else if (CharaName == "akino") { ID = "103261"; }
            else if (CharaName == "mahiru") { ID = "103331"; }
            else if (CharaName == "yukari") { ID = "103461"; }
            else if (CharaName == "kyouka") { ID = "103631"; }
            else if (CharaName == "tomo") { ID = "103731"; }
            else if (CharaName == "siori") { ID = "103831"; }
            else if (CharaName == "aoi") { ID = "104031"; }
            else if (CharaName == "chika") { ID = "104231"; }
            else if (CharaName == "makoto") { ID = "104331"; }
            else if (CharaName == "iriya") { ID = "104431"; }
            else if (CharaName == "kuuka") { ID = "104531"; }
            else if (CharaName == "tamaki") { ID = "104661"; }
            else if (CharaName == "zyun") { ID = "104731"; }
            else if (CharaName == "mihuyu") { ID = "104861"; }
            else if (CharaName == "sizuru") { ID = "104961"; }
            else if (CharaName == "misaki") { ID = "105031"; }
            else if (CharaName == "mitsuki") { ID = "105131"; }
            else if (CharaName == "rima") { ID = "105261"; }
            else if (CharaName == "monika") { ID = "105331"; }
            else if (CharaName == "tsumugi") { ID = "105431"; }
            else if (CharaName == "ayumi") { ID = "105531"; }
            else if (CharaName == "ruka") { ID = "105631"; }
            else if (CharaName == "zita") { ID = "105731"; }
            else if (CharaName == "pekorinnu") { ID = "105861"; }
            else if (CharaName == "kotkoro") { ID = "105961"; }
            else if (CharaName == "kyaru") { ID = "106061"; }
            else if (CharaName == "muimi") { ID = "106131"; }
            else if (CharaName == "arisa") { ID = "106331"; }
            else if (CharaName == "kaya") { ID = "106531"; }
            else if (CharaName == "inori") { ID = "106631"; }
            else if (CharaName == "labyrista") { ID = "106831"; }
            else if (CharaName == "neneka") { ID = "107031"; }
            else if (CharaName == "kristina") { ID = "107131"; }
            else if (CharaName == "pekorinnu_summer") { ID = "107531"; }
            else if (CharaName == "kotkoro_summer") { ID = "107631"; }
            else if (CharaName == "suzume_summer") { ID = "107731"; }
            else if (CharaName == "kyaru_summer") { ID = "107831"; }
            else if (CharaName == "tamaki_summer") { ID = "107931"; }
            else if (CharaName == "mihuyu_summer") { ID = "108031"; }
            else if (CharaName == "sinobu_halloween") { ID = "108131"; }
            else if (CharaName == "miyako_halloween") { ID = "108231"; }
            else if (CharaName == "misaki_halloween") { ID = "108331"; }
            else if (CharaName == "chika_christmas") { ID = "108431"; }
            else if (CharaName == "kurumi_christmas") { ID = "108531"; }
            else if (CharaName == "ayane_christmas") { ID = "108611"; }
            else if (CharaName == "hiyori_newyear") { ID = "108731"; }
            else if (CharaName == "yui_newyear") { ID = "108831"; }
            else if (CharaName == "rei_newyear") { ID = "108931"; }
            else if (CharaName == "eriko_valentine") { ID = "109031"; }
            else if (CharaName == "sizuru_valentine") { ID = "109131"; }
            else if (CharaName == "anne") { ID = "109231"; }
            else if (CharaName == "lou") { ID = "109331"; }
            else if (CharaName == "grea") { ID = "109431"; }
            else if (CharaName == "kuuka_ooedo") { ID = "109531"; }
            else if (CharaName == "ninon_ooedo") { ID = "109631"; }
            else if (CharaName == "rem") { ID = "109731"; }
            else if (CharaName == "ram") { ID = "109831"; }
            else if (CharaName == "emilia") { ID = "109931"; }
            else if (CharaName == "suzuna_summer") { ID = "110031"; }
            else if (CharaName == "io_summer") { ID = "110131"; }
            else if (CharaName == "saren_summer") { ID = "110331"; }
            else if (CharaName == "makoto_summer") { ID = "110431"; }
            else if (CharaName == "kaori_summer") { ID = "110531"; }
            else if (CharaName == "maho_summer") { ID = "110631"; }
            else if (CharaName == "aoi_nakayosi") { ID = "110731"; }
            else if (CharaName == "chloe") { ID = "110831"; }
            else if (CharaName == "yuni") { ID = "111031"; }
            else if (CharaName == "chieru") { ID = "110931"; }
            else if (CharaName == "kyouka_halloween") { ID = "111131"; }
            else if (CharaName == "misogi_halloween") { ID = "111231"; }
            else if (CharaName == "mimi_halloween") { ID = "111331"; }
            else if (CharaName == "runa") { ID = "111431"; }
            else if (CharaName == "kristina_christmas") { ID = "111531"; }
            else if (CharaName == "nozomi_christmas") { ID = "111631"; }
            else if (CharaName == "iriya_christmas") { ID = "111731"; }
            else if (CharaName == "kotkoro_newyear") { ID = "111931"; }
            else if (CharaName == "kyaru_newyear") { ID = "112031"; }
            else if (CharaName == "suzume_newyear") { ID = "112131"; }
            else if (CharaName == "kasumi_magical") { ID = "112231"; }
            else if (CharaName == "siori_magical") { ID = "112331"; }
            else if (CharaName == "uzuki_deremas") { ID = "112431"; }
            else if (CharaName == "mio_deremas") { ID = "112631"; }
            else if (CharaName == "rin_deremas") { ID = "112531"; }
            else if (CharaName == "rin_ranger") { ID = "112731"; }
            else if (CharaName == "mahiru_ranger") { ID = "112831"; }
            else if (CharaName == "rino_wonder") { ID = "112931"; }
            else if (CharaName == "ayumi_wonder") { ID = "113031"; }
            else if (CharaName == "ruka_summer") { ID = "113131"; }
            else if (CharaName == "anna_summer") { ID = "113231"; }
            else if (CharaName == "nanaka_summer") { ID = "113331"; }
            else if (CharaName == "hatsune_summer") { ID = "113431"; }
            else if (CharaName == "misato_summer") { ID = "113531"; }
            else if (CharaName == "zyun_summer") { ID = "113631"; }
            else if (CharaName == "akari_angel") { ID = "113731"; }
            else if (CharaName == "yori_angel") { ID = "113831"; }
            else if (CharaName == "tsumugi_halloween") { ID = "113931"; }
            else if (CharaName == "rei_halloween") { ID = "114031"; }
            else if (CharaName == "matsuri_halloween") { ID = "114131"; }
            else if (CharaName == "monika_magical") { ID = "114231"; }
            else if (CharaName == "tomo_magical") { ID = "114331"; }
            else if (CharaName == "akino_christmas") { ID = "114431"; }
            else if (CharaName == "saren_christmas") { ID = "114531"; }
            else if (CharaName == "yukari_christmas") { ID = "114631"; }
            else if (CharaName == "muimi_newyear") { ID = "114731"; }
            else if (CharaName == "pekorinnu_newyear") { ID = "115031"; }
            else if (CharaName == "kotkori_maiden") { ID = "115531"; }
            else if (CharaName == "yui_maiden") { ID = "115631"; }
            else if (CharaName == "kasumi_summer") { ID = "115731"; }
            else if (CharaName == "rima_cinderella") { ID = "115831"; }
            else if (CharaName == "makoto_cinderella") { ID = "115931"; }
            else if (CharaName == "maho_cinderella") { ID = "116031"; }
            else if (CharaName == "chloe_nakayosi2") { ID = "116231"; }
            else if (CharaName == "chieru_nakayosi2") { ID = "116331"; }
            else if (CharaName == "inori_timetravel") { ID = "116531"; }
            else if (CharaName == "kaya_timetravel") { ID = "116631"; }
            else if (CharaName == "aoi_worker") { ID = "116731"; }
            else if (CharaName == "tamaki_worker") { ID = "116831"; }
            else if (CharaName == "hiyori_princess") { ID = "180131"; }
            else if (CharaName == "yui_princess") { ID = "180231"; }
            else if (CharaName == "rei_princess") { ID = "180331"; }
            else if (CharaName == "pekorinnu_princess") { ID = "180431"; }
            else if (CharaName == "kotkoro_princess") { ID = "180531"; }
            else if (CharaName == "kyaru_princess") { ID = "180631"; }
            else { ID = "000000"; }

            return ID;
        }

        public string IDtoCharaEngName(string ID)
        {
            try
            {
                if (LikeOperator.LikeString(ID, "1001*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori";
                else if (ID == "100211" || ID == "100231" || ID == "100261") return "yui";
                else if (ID == "100311" || ID == "100331" || ID == "100361") return "rei";
                else if (ID == "100411" || ID == "100431" || ID == "100461") return "misogi";
                else if (ID == "100511" || ID == "100531" || ID == "100561") return "matsuri";
                else if (ID == "100611" || ID == "100631" || ID == "100661") return "akari";
                else if (ID == "100711" || ID == "100731" || ID == "100761") return "miyako";
                else if (ID == "100811" || ID == "100831" || ID == "100861") return "yuki";
                else if (ID == "100911" || ID == "100931" || ID == "100961") return "anna";
                else if (ID == "101011" || ID == "101031" || ID == "101061") return "maho";
                else if (ID == "101111" || ID == "101131" || ID == "101161") return "rino";
                else if (ID == "101211" || ID == "101231" || ID == "101261") return "hatsune";
                else if (ID == "101311" || ID == "101331" || ID == "101361") return "nanaka";
                else if (ID == "101411" || ID == "101431" || ID == "101461") return "kasumi";
                else if (ID == "101511" || ID == "101531" || ID == "101561") return "misato";
                else if (ID == "101611" || ID == "101631" || ID == "101661") return "suzuna";
                else if (ID == "101711" || ID == "101731" || ID == "101761") return "kaori";
                else if (ID == "101811" || ID == "101831" || ID == "101861") return "io";
                else if (ID == "102011" || ID == "102031" || ID == "102061") return "mimi";
                else if (ID == "102111" || ID == "102131" || ID == "102161") return "kurumi";
                else if (ID == "102211" || ID == "102231" || ID == "102261") return "yori";
                else if (ID == "102311" || ID == "102331" || ID == "102361") return "ayane";
                else if (ID == "102511" || ID == "102531" || ID == "102561") return "suzume";
                else if (ID == "102611" || ID == "102631" || ID == "102661") return "rin";
                else if (ID == "102711" || ID == "102731" || ID == "102761") return "eriko";
                else if (ID == "102811" || ID == "102831" || ID == "102861") return "saren";
                else if (ID == "102911" || ID == "102931" || ID == "102961") return "nozomi";
                else if (ID == "103011" || ID == "103031" || ID == "103061") return "ninon";
                else if (ID == "103111" || ID == "103131" || ID == "103161") return "sinobu";
                else if (ID == "103211" || ID == "103231" || ID == "103261") return "akino";
                else if (ID == "103311" || ID == "103331" || ID == "103361") return "mahiru";
                else if (ID == "103411" || ID == "103431" || ID == "103461") return "yukari";
                else if (ID == "103611" || ID == "103631" || ID == "103661") return "kyouka";
                else if (ID == "103711" || ID == "103731" || ID == "103761") return "tomo";
                else if (ID == "103811" || ID == "103831" || ID == "103861") return "siori";
                else if (ID == "104011" || ID == "104031" || ID == "104061") return "aoi";
                else if (ID == "104211" || ID == "104231" || ID == "104261") return "chika";
                else if (ID == "104311" || ID == "104331" || ID == "104361") return "makoto";
                else if (ID == "104411" || ID == "104431" || ID == "104461") return "iriya";
                else if (ID == "104511" || ID == "104531" || ID == "104561") return "kuuka";
                else if (ID == "104611" || ID == "104631" || ID == "104661") return "tamaki";
                else if (LikeOperator.LikeString(ID, "1047*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "zyun";
                else if (LikeOperator.LikeString(ID, "1048*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mihuyu";
                else if (LikeOperator.LikeString(ID, "1049*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "sizuru";
                else if (LikeOperator.LikeString(ID, "1050*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "misaki";
                else if (LikeOperator.LikeString(ID, "1051*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mitsuki";
                else if (LikeOperator.LikeString(ID, "1052*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rima";
                else if (LikeOperator.LikeString(ID, "1053*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "monika";
                else if (LikeOperator.LikeString(ID, "1054*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "tsumugi";
                else if (LikeOperator.LikeString(ID, "1055*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ayumi";
                else if (LikeOperator.LikeString(ID, "1056*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ruka";
                else if (LikeOperator.LikeString(ID, "1057*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "zita";
                else if (LikeOperator.LikeString(ID, "1058*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu";
                else if (LikeOperator.LikeString(ID, "1059*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro";
                else if (LikeOperator.LikeString(ID, "1060*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru";
                else if (LikeOperator.LikeString(ID, "1061*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "muimi";
                else if (LikeOperator.LikeString(ID, "1063*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "arisa";
                else if (LikeOperator.LikeString(ID, "1064*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "shepi";
                else if (LikeOperator.LikeString(ID, "1065*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kaya";
                else if (LikeOperator.LikeString(ID, "1066*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "inori";
                else if (LikeOperator.LikeString(ID, "1067*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "homare";
                else if (LikeOperator.LikeString(ID, "1068*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "labyrista";
                else if (LikeOperator.LikeString(ID, "1069*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kaiser";
                else if (LikeOperator.LikeString(ID, "1070*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "neneka";
                else if (LikeOperator.LikeString(ID, "1071*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kristina";
                else if (ID == "107311" || ID == "107331" || ID == "107361") return "lazilazi";
                else if (LikeOperator.LikeString(ID, "1075*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_summer";
                else if (LikeOperator.LikeString(ID, "1076*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_summer";
                else if (LikeOperator.LikeString(ID, "1077*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "suzume_summer";
                else if (LikeOperator.LikeString(ID, "1078*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_summer";
                else if (LikeOperator.LikeString(ID, "1079*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "tamaki_summer";
                else if (LikeOperator.LikeString(ID, "1080*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mihuyu_summer";
                else if (LikeOperator.LikeString(ID, "1081*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "sinobu_halloween";
                else if (LikeOperator.LikeString(ID, "1082*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "miyako_halloween";
                else if (LikeOperator.LikeString(ID, "1083*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "misaki_halloween";
                else if (LikeOperator.LikeString(ID, "1084*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "chika_christmas";
                else if (LikeOperator.LikeString(ID, "1085*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kurumi_christmas";
                else if (LikeOperator.LikeString(ID, "1086*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ayane_christmas";
                else if (LikeOperator.LikeString(ID, "1087*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori_newyear";
                else if (LikeOperator.LikeString(ID, "1088*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_newyear";
                else if (LikeOperator.LikeString(ID, "1089*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_newyear";
                else if (LikeOperator.LikeString(ID, "1090*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "eriko_valentine";
                else if (LikeOperator.LikeString(ID, "1091*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "sizuru_valentine";
                else if (LikeOperator.LikeString(ID, "1092*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "anne";
                else if (LikeOperator.LikeString(ID, "1093*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "lou";
                else if (LikeOperator.LikeString(ID, "1094*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "grea";
                else if (LikeOperator.LikeString(ID, "1095*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kuuka_ooedo";
                else if (LikeOperator.LikeString(ID, "1096*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ninon_ooedo";
                else if (LikeOperator.LikeString(ID, "1097*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ram";
                else if (LikeOperator.LikeString(ID, "1098*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rem";
                else if (LikeOperator.LikeString(ID, "1099*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "emilia";
                else if (LikeOperator.LikeString(ID, "1100*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "suzuna_summer";
                else if (LikeOperator.LikeString(ID, "1101*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "io_summer";
                else if (LikeOperator.LikeString(ID, "1103*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "saren_summer";
                else if (LikeOperator.LikeString(ID, "1104*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "makoto_summer";
                else if (LikeOperator.LikeString(ID, "1105*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kaori_summer";
                else if (LikeOperator.LikeString(ID, "1106*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "maho_summer";
                else if (ID == "110711" || ID == "110731" || ID == "110761") return "aoi_nakayosi";
                else if (LikeOperator.LikeString(ID, "1108*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "chloe";
                else if (LikeOperator.LikeString(ID, "1109*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "chieru";
                else if (LikeOperator.LikeString(ID, "1110*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yuni";
                else if (LikeOperator.LikeString(ID, "1111*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kyouka_halloween";
                else if (LikeOperator.LikeString(ID, "1112*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "misogi_halloween";
                else if (LikeOperator.LikeString(ID, "1113*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mimi_halloween";
                else if (LikeOperator.LikeString(ID, "1114*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "runa";
                else if (LikeOperator.LikeString(ID, "1115*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kristina_christmas";
                else if (LikeOperator.LikeString(ID, "1116*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "nozomi_christmas";
                else if (LikeOperator.LikeString(ID, "1117*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "iriya_christmas";
                else if (LikeOperator.LikeString(ID, "1118*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_newyear";
                else if (LikeOperator.LikeString(ID, "1119*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_newyear";
                else if (LikeOperator.LikeString(ID, "1120*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_newyear";
                else if (LikeOperator.LikeString(ID, "1121*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "suzume_newyear";
                else if (LikeOperator.LikeString(ID, "1122*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kasumi_magical";
                else if (LikeOperator.LikeString(ID, "1123*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "siori_magical";
                else if (LikeOperator.LikeString(ID, "1124*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "uzuki_deremas";
                else if (LikeOperator.LikeString(ID, "1125*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rin_deremas";
                else if (LikeOperator.LikeString(ID, "1126*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mio_deremas";
                else if (LikeOperator.LikeString(ID, "1127*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rin_ranger";
                else if (LikeOperator.LikeString(ID, "1128*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "mahiru_ranger";
                else if (LikeOperator.LikeString(ID, "1129*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rino_alice";
                else if (LikeOperator.LikeString(ID, "1130*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ayumi_alice";
                else if (LikeOperator.LikeString(ID, "1131*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "ruka_summer";
                else if (LikeOperator.LikeString(ID, "1132*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "anna_summer";
                else if (LikeOperator.LikeString(ID, "1133*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "nanaka_summer";
                else if (LikeOperator.LikeString(ID, "1134*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "hatsune_summer";
                else if (LikeOperator.LikeString(ID, "1135*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "misato_summer";
                else if (LikeOperator.LikeString(ID, "1136*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "zyun_summer";
                else if (LikeOperator.LikeString(ID, "1137*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "akari_angel";
                else if (LikeOperator.LikeString(ID, "1138*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yori_angel";
                else if (LikeOperator.LikeString(ID, "1139*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "tsumugi_halloween";
                else if (LikeOperator.LikeString(ID, "1140*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_halloween";
                else if (LikeOperator.LikeString(ID, "1141*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "matsuri_halloween";
                else if (LikeOperator.LikeString(ID, "1142*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "monika_magical";
                else if (LikeOperator.LikeString(ID, "1143*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "tomo_magical";
                else if (LikeOperator.LikeString(ID, "1144*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "akino_christmas";
                else if (LikeOperator.LikeString(ID, "1145*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "saren_christmas";
                else if (LikeOperator.LikeString(ID, "1146*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yukari_christmas";
                else if (LikeOperator.LikeString(ID, "1147*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "muimi_newyear";
                else if (LikeOperator.LikeString(ID, "1150*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "neneka_newyear";
                else if (LikeOperator.LikeString(ID, "1155*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_maiden";
                else if (LikeOperator.LikeString(ID, "1156*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_maiden";
                else if (LikeOperator.LikeString(ID, "1157*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kasume_summer";
                else if (LikeOperator.LikeString(ID, "1158*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rima_cinderella";
                else if (LikeOperator.LikeString(ID, "1159*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "makoto_cinderella";
                else if (LikeOperator.LikeString(ID, "1160*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "maho_cinderella";
                else if (LikeOperator.LikeString(ID, "1162*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "chloe_nakayosi2";
                else if (LikeOperator.LikeString(ID, "1163*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "chieru_nakayosi2";
                else if (LikeOperator.LikeString(ID, "1165*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "inori_timetravel";
                else if (LikeOperator.LikeString(ID, "1166*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kaya_timetravel";
                else if (LikeOperator.LikeString(ID, "1167*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "aoi_worker";
                else if (LikeOperator.LikeString(ID, "1168*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "tamaki_worker";
                else if (LikeOperator.LikeString(ID, "1801*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori_princess";
                else if (LikeOperator.LikeString(ID, "1802*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_princess";
                else if (LikeOperator.LikeString(ID, "1803*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_princess";
                else if (LikeOperator.LikeString(ID, "1804*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_princess";
                else if (LikeOperator.LikeString(ID, "1805*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_princess";
                else if (LikeOperator.LikeString(ID, "1806*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_princess";
                else return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public string IDtoCharaKorName(string ID)
        {
            try
            {
                if (LikeOperator.LikeString(ID, "1001*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "히요리";
                else if (ID == "100211" || ID == "100231" || ID == "100261") return "유이";
                else if (ID == "100311" || ID == "100331" || ID == "100361") return "레이";
                else if (ID == "100411" || ID == "100431" || ID == "100461") return "미소기";
                else if (ID == "100511" || ID == "100531" || ID == "100561") return "마츠리";
                else if (ID == "100611" || ID == "100631" || ID == "100661") return "아카리";
                else if (ID == "100711" || ID == "100731" || ID == "100761") return "미야코";
                else if (ID == "100811" || ID == "100831" || ID == "100861") return "유키";
                else if (ID == "100911" || ID == "100931" || ID == "100961") return "안나";
                else if (ID == "101011" || ID == "101031" || ID == "101061") return "마호";
                else if (ID == "101111" || ID == "101131" || ID == "101161") return "리노";
                else if (ID == "101211" || ID == "101231" || ID == "101261") return "하츠네";
                else if (ID == "101311" || ID == "101331" || ID == "101361") return "나나카";
                else if (ID == "101411" || ID == "101431" || ID == "101461") return "카스미";
                else if (ID == "101511" || ID == "101531" || ID == "101561") return "미사토";
                else if (ID == "101611" || ID == "101631" || ID == "101661") return "스즈나";
                else if (ID == "101711" || ID == "101731" || ID == "101761") return "카오리";
                else if (ID == "101811" || ID == "101831" || ID == "101861") return "이오";
                else if (ID == "102011" || ID == "102031" || ID == "102061") return "미미";
                else if (ID == "102111" || ID == "102131" || ID == "102161") return "쿠루미";
                else if (ID == "102211" || ID == "102231" || ID == "102261") return "요리";
                else if (ID == "102311" || ID == "102331" || ID == "102361") return "아야네";
                else if (ID == "102511" || ID == "102531" || ID == "102561") return "스즈메";
                else if (ID == "102611" || ID == "102631" || ID == "102661") return "린";
                else if (ID == "102711" || ID == "102731" || ID == "102761") return "에리코";
                else if (ID == "102811" || ID == "102831" || ID == "102861") return "사렌";
                else if (ID == "102911" || ID == "102931" || ID == "102961") return "노조미";
                else if (ID == "103011" || ID == "103031" || ID == "103061") return "니논";
                else if (ID == "103111" || ID == "103131" || ID == "103161") return "시노부";
                else if (ID == "103211" || ID == "103231" || ID == "103261") return "아키노";
                else if (ID == "103311" || ID == "103331" || ID == "103361") return "마히루";
                else if (ID == "103411" || ID == "103431" || ID == "103461") return "유카리";
                else if (ID == "103611" || ID == "103631" || ID == "103661") return "쿄우카";
                else if (ID == "103711" || ID == "103731" || ID == "103761") return "토모";
                else if (ID == "103811" || ID == "103831" || ID == "103861") return "시오리";
                else if (ID == "104011" || ID == "104031" || ID == "104061") return "아오이";
                else if (ID == "104211" || ID == "104231" || ID == "104261") return "치카";
                else if (ID == "104311" || ID == "104331" || ID == "104361") return "마코토";
                else if (ID == "104411" || ID == "104431" || ID == "104461") return "이리야";
                else if (ID == "104511" || ID == "104531" || ID == "104561") return "쿠우카";
                else if (ID == "104611" || ID == "104631" || ID == "104661") return "타마키";
                else if (LikeOperator.LikeString(ID, "1047*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "쥰";
                else if (LikeOperator.LikeString(ID, "1048*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "미후유";
                else if (LikeOperator.LikeString(ID, "1049*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "시즈루";
                else if (LikeOperator.LikeString(ID, "1050*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "미사키";
                else if (LikeOperator.LikeString(ID, "1051*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "미츠키";
                else if (LikeOperator.LikeString(ID, "1052*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "리마";
                else if (LikeOperator.LikeString(ID, "1053*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "모니카";
                else if (LikeOperator.LikeString(ID, "1054*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "츠무기";
                else if (LikeOperator.LikeString(ID, "1055*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "아유미";
                else if (LikeOperator.LikeString(ID, "1056*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "루카";
                else if (LikeOperator.LikeString(ID, "1057*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "지타";
                else if (LikeOperator.LikeString(ID, "1058*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "페코린느";
                else if (LikeOperator.LikeString(ID, "1059*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "콧코로";
                else if (LikeOperator.LikeString(ID, "1060*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "캬루";
                else if (LikeOperator.LikeString(ID, "1061*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "무이미";
                else if (LikeOperator.LikeString(ID, "1063*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "아리사";
                else if (LikeOperator.LikeString(ID, "1064*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "셰피";
                else if (LikeOperator.LikeString(ID, "1065*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "카야";
                else if (LikeOperator.LikeString(ID, "1066*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "이노리";
                else if (LikeOperator.LikeString(ID, "1067*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "호마레";
                else if (LikeOperator.LikeString(ID, "1068*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "라비리스타";
                else if (LikeOperator.LikeString(ID, "1069*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "패동";
                else if (LikeOperator.LikeString(ID, "1070*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "네네카";
                else if (LikeOperator.LikeString(ID, "1071*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "크리스티나";
                else if (ID == "107311" || ID == "107331" || ID == "107361") return "라지라지";
                else if (LikeOperator.LikeString(ID, "1075*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수페코";
                else if (LikeOperator.LikeString(ID, "1076*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수코로";
                else if (LikeOperator.LikeString(ID, "1077*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수즈메";
                else if (LikeOperator.LikeString(ID, "1078*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수캬루";
                else if (LikeOperator.LikeString(ID, "1079*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수마키";
                else if (LikeOperator.LikeString(ID, "1080*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수후유";
                else if (LikeOperator.LikeString(ID, "1081*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할노부";
                else if (LikeOperator.LikeString(ID, "1082*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할푸딩";
                else if (LikeOperator.LikeString(ID, "1083*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할사키";
                else if (LikeOperator.LikeString(ID, "1084*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성치카";
                else if (LikeOperator.LikeString(ID, "1085*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성루미";
                else if (LikeOperator.LikeString(ID, "1086*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성야네";
                else if (LikeOperator.LikeString(ID, "1087*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴요리";
                else if (LikeOperator.LikeString(ID, "1088*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴이";
                else if (LikeOperator.LikeString(ID, "1089*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "신레이";
                else if (LikeOperator.LikeString(ID, "1090*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "발리코";
                else if (LikeOperator.LikeString(ID, "1091*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "발즈루";
                else if (LikeOperator.LikeString(ID, "1092*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "앤";
                else if (LikeOperator.LikeString(ID, "1093*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "루";
                else if (LikeOperator.LikeString(ID, "1094*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "글레어";
                else if (LikeOperator.LikeString(ID, "1095*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "오우카";
                else if (LikeOperator.LikeString(ID, "1096*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "오니논";
                else if (LikeOperator.LikeString(ID, "1097*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "람";
                else if (LikeOperator.LikeString(ID, "1098*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "렘";
                else if (LikeOperator.LikeString(ID, "1099*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "에밀리아";
                else if (LikeOperator.LikeString(ID, "1100*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수즈나";
                else if (LikeOperator.LikeString(ID, "1101*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수이오";
                else if (LikeOperator.LikeString(ID, "1103*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수사렌";
                else if (LikeOperator.LikeString(ID, "1104*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수코토";
                else if (LikeOperator.LikeString(ID, "1105*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수오리";
                else if (LikeOperator.LikeString(ID, "1106*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수마호";
                else if (ID == "110711" || ID == "110731" || ID == "110761") return "편오이";
                else if (LikeOperator.LikeString(ID, "1108*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "클로에";
                else if (LikeOperator.LikeString(ID, "1109*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "치에루";
                else if (LikeOperator.LikeString(ID, "1110*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "유니";
                else if (LikeOperator.LikeString(ID, "1111*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할쿄카";
                else if (LikeOperator.LikeString(ID, "1112*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할소기";
                else if (LikeOperator.LikeString(ID, "1113*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할미미";
                else if (LikeOperator.LikeString(ID, "1114*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "루나";
                else if (LikeOperator.LikeString(ID, "1115*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성리스";
                else if (LikeOperator.LikeString(ID, "1116*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성조미";
                else if (LikeOperator.LikeString(ID, "1117*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성리야";
                else if (LikeOperator.LikeString(ID, "1118*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴페코";
                else if (LikeOperator.LikeString(ID, "1119*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴코로";
                else if (LikeOperator.LikeString(ID, "1120*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "냐루";
                else if (LikeOperator.LikeString(ID, "1121*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴즈메";
                else if (LikeOperator.LikeString(ID, "1122*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "마스미";
                else if (LikeOperator.LikeString(ID, "1123*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "마오리";
                else if (LikeOperator.LikeString(ID, "1124*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "우즈키";
                else if (LikeOperator.LikeString(ID, "1125*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "시부린";
                else if (LikeOperator.LikeString(ID, "1126*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "미오";
                else if (LikeOperator.LikeString(ID, "1127*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "레린";
                else if (LikeOperator.LikeString(ID, "1128*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "레히루";
                else if (LikeOperator.LikeString(ID, "1129*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "앨리노";
                else if (LikeOperator.LikeString(ID, "1130*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "앨유미";
                else if (LikeOperator.LikeString(ID, "1131*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수루카";
                else if (LikeOperator.LikeString(ID, "1132*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수안나";
                else if (LikeOperator.LikeString(ID, "1133*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수나카";
                else if (LikeOperator.LikeString(ID, "1134*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수츠네";
                else if (LikeOperator.LikeString(ID, "1135*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수사토";
                else if (LikeOperator.LikeString(ID, "1136*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수쥰";
                else if (LikeOperator.LikeString(ID, "1137*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "엔카리";
                else if (LikeOperator.LikeString(ID, "1138*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "엔요리";
                else if (LikeOperator.LikeString(ID, "1139*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할무기";
                else if (LikeOperator.LikeString(ID, "1140*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할레이";
                else if (LikeOperator.LikeString(ID, "1141*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "할츠리";
                else if (LikeOperator.LikeString(ID, "1142*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "마니카";
                else if (LikeOperator.LikeString(ID, "1143*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "마토모";
                else if (LikeOperator.LikeString(ID, "1144*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성키노";
                else if (LikeOperator.LikeString(ID, "1145*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성사렌";
                else if (LikeOperator.LikeString(ID, "1146*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성카리";
                else if (LikeOperator.LikeString(ID, "1147*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴이미";
                else if (LikeOperator.LikeString(ID, "1150*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴네카";
                else if (LikeOperator.LikeString(ID, "1155*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "의코로";
                else if (LikeOperator.LikeString(ID, "1156*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "의유이";
                else if (LikeOperator.LikeString(ID, "1157*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "수스미";
                else if (LikeOperator.LikeString(ID, "1158*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "신리마";
                else if (LikeOperator.LikeString(ID, "1159*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "신코토";
                else if (LikeOperator.LikeString(ID, "1160*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "신마호";
                else if (LikeOperator.LikeString(ID, "1162*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성로에";
                else if (LikeOperator.LikeString(ID, "1163*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "성에루";
                else if (LikeOperator.LikeString(ID, "1165*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "시노리";
                else if (LikeOperator.LikeString(ID, "1166*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "시카야";
                else if (LikeOperator.LikeString(ID, "1167*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "작오이";
                else if (LikeOperator.LikeString(ID, "1168*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "작마키";
                else if (LikeOperator.LikeString(ID, "1801*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프요리";
                else if (LikeOperator.LikeString(ID, "1802*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프유이";
                else if (LikeOperator.LikeString(ID, "1803*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프레이";
                else if (LikeOperator.LikeString(ID, "1804*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프페코";
                else if (LikeOperator.LikeString(ID, "1805*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프코로";
                else if (LikeOperator.LikeString(ID, "1806*1", Microsoft.VisualBasic.CompareMethod.Binary)) return "프캬루";

                else return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }



        }

        private void bt_capture_Def_Click(object sender, RoutedEventArgs e)
        {
            CaptureMask cm = new CaptureMask();
            cm.ShowDialog();

            if (mWidth > 0 && mHeigt > 0)
            {
                System.Drawing.Size mSize = new System.Drawing.Size(mWidth, mHeigt);
                Bitmap image = new Bitmap(mWidth, mHeigt);
                Graphics g = Graphics.FromImage(image);

                try
                {
                    g.CopyFromScreen(mX, mY, 0, 0, mSize);
                }
                catch (Win32Exception w)
                {
                    Debug.WriteLine(w.Message);
                }

                //image = ResizeImage(image, (int)ib_testBox.Width, (int)ib_testBox.Height);
                //ib_testBox.Source = BitmapToImageSource(image);

                if (!isImageprepared)
                    ImagePrepare();

                searchIMG(image, 1);
                isDefDeckReady = true;
            }
            else
            {
                MessageBox.Show("다시 시도하세요", "알림");
            }


        }

        private void bt_capture_Off_Click(object sender, RoutedEventArgs e)
        {
            CaptureMask cm = new CaptureMask();
            cm.ShowDialog();

            if (mWidth > 0 && mHeigt > 0)
            {
                System.Drawing.Size mSize = new System.Drawing.Size(mWidth, mHeigt);
                Bitmap image = new Bitmap(mWidth, mHeigt);
                Graphics g = Graphics.FromImage(image);

                try
                {
                    g.CopyFromScreen(mX, mY, 0, 0, mSize);
                }
                catch (Win32Exception w)
                {
                    Debug.WriteLine(w.Message);
                }

                //image = ResizeImage(image, (int)ib_testBox.Width, (int)ib_testBox.Height);
                //ib_testBox.Source = BitmapToImageSource(image);

                if (!isImageprepared)
                    ImagePrepare();

                searchIMG(image, 0);
                isOffDeckReady = true;
            }
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap ImageSourceToBitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        public void ShowDefCharas(string[] defDeck_eng)
        {
            string[] uriS = new string[5];

            for (int i = 0; i < 5; i++)
            {
                uriS[i] = CharaNameToID(defDeck_eng[i]);
            }


            var uriIS0 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[0] + ".png", UriKind.Absolute);
            BitmapImage charaBmI0 = new BitmapImage(uriIS0);

            var uriIS1 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[1] + ".png", UriKind.Absolute);
            BitmapImage charaBmI1 = new BitmapImage(uriIS1);

            var uriIS2 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[2] + ".png", UriKind.Absolute);
            BitmapImage charaBmI2 = new BitmapImage(uriIS2);

            var uriIS3 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[3] + ".png", UriKind.Absolute);
            BitmapImage charaBmI3 = new BitmapImage(uriIS3);

            var uriIS4 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[4] + ".png", UriKind.Absolute);
            BitmapImage charaBmI4 = new BitmapImage(uriIS4);
            ib_defChara1.Source = charaBmI0;
            ib_defChara2.Source = charaBmI1;
            ib_defChara3.Source = charaBmI2;
            ib_defChara4.Source = charaBmI3;
            ib_defChara5.Source = charaBmI4;
            ib_defChara1.Opacity = 1.0;
            ib_defChara2.Opacity = 1.0;
            ib_defChara3.Opacity = 1.0;
            ib_defChara4.Opacity = 1.0;
            ib_defChara5.Opacity = 1.0;
        }
        public void ShowOffCharas(string[] offDeck_eng)
        {
            string[] uriS = new string[5];

            for (int i = 0; i < 5; i++)
            {
                uriS[i] = CharaNameToID(offDeck_eng[i]);
            }


            if (isFindOffReady == false)
            {
                var uriIS0 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[0] + ".png", UriKind.Absolute);
                BitmapImage charaBmI0 = new BitmapImage(uriIS0);

                var uriIS1 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[1] + ".png", UriKind.Absolute);
                BitmapImage charaBmI1 = new BitmapImage(uriIS1);

                var uriIS2 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[2] + ".png", UriKind.Absolute);
                BitmapImage charaBmI2 = new BitmapImage(uriIS2);

                var uriIS3 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[3] + ".png", UriKind.Absolute);
                BitmapImage charaBmI3 = new BitmapImage(uriIS3);

                var uriIS4 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[4] + ".png", UriKind.Absolute);
                BitmapImage charaBmI4 = new BitmapImage(uriIS4);
                ib_offChara1.Source = charaBmI0;
                ib_offChara2.Source = charaBmI1;
                ib_offChara3.Source = charaBmI2;
                ib_offChara4.Source = charaBmI3;
                ib_offChara5.Source = charaBmI4;
                ib_offChara1.Opacity = 1.0;
                ib_offChara2.Opacity = 1.0;
                ib_offChara3.Opacity = 1.0;
                ib_offChara4.Opacity = 1.0;
                ib_offChara5.Opacity = 1.0;
            }
            else if (isFindOffReady == true && FindPick_temp.Count == 4)
            {
                var uriIS0 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[0] + ".png", UriKind.Absolute);
                BitmapImage charaBmI0 = new BitmapImage(uriIS0);

                var uriIS1 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[1] + ".png", UriKind.Absolute);
                BitmapImage charaBmI1 = new BitmapImage(uriIS1);

                var uriIS2 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[2] + ".png", UriKind.Absolute);
                BitmapImage charaBmI2 = new BitmapImage(uriIS2);

                var uriIS3 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[3] + ".png", UriKind.Absolute);
                BitmapImage charaBmI3 = new BitmapImage(uriIS3);

                var uriIS4 = new Uri("pack://application:,,,/res/icon_unit/000000.png", UriKind.Absolute);
                BitmapImage charaBmI4 = new BitmapImage(uriIS4);
                ib_offChara1.Source = charaBmI0;
                ib_offChara2.Source = charaBmI1;
                ib_offChara3.Source = charaBmI2;
                ib_offChara4.Source = charaBmI3;
                ib_offChara5.Source = charaBmI4;
                ib_offChara1.Opacity = 1.0;
                ib_offChara2.Opacity = 1.0;
                ib_offChara3.Opacity = 1.0;
                ib_offChara4.Opacity = 1.0;
                ib_offChara5.Opacity = 1.0;

            }
            else if (isFindOffReady == true && FindPick_temp.Count == 3)
            {
                var uriIS0 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[0] + ".png", UriKind.Absolute);
                BitmapImage charaBmI0 = new BitmapImage(uriIS0);

                var uriIS1 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[1] + ".png", UriKind.Absolute);
                BitmapImage charaBmI1 = new BitmapImage(uriIS1);

                var uriIS2 = new Uri("pack://application:,,,/res/icon_unit/" + uriS[2] + ".png", UriKind.Absolute);
                BitmapImage charaBmI2 = new BitmapImage(uriIS2);

                var uriIS3 = new Uri("pack://application:,,,/res/icon_unit/000000.png", UriKind.Absolute);
                BitmapImage charaBmI3 = new BitmapImage(uriIS3);

                var uriIS4 = new Uri("pack://application:,,,/res/icon_unit/000000.png", UriKind.Absolute);
                BitmapImage charaBmI4 = new BitmapImage(uriIS4);
                ib_offChara1.Source = charaBmI0;
                ib_offChara2.Source = charaBmI1;
                ib_offChara3.Source = charaBmI2;
                ib_offChara4.Source = charaBmI3;
                ib_offChara5.Source = charaBmI4;
                ib_offChara1.Opacity = 1.0;
                ib_offChara2.Opacity = 1.0;
                ib_offChara3.Opacity = 1.0;
                ib_offChara4.Opacity = 1.0;
                ib_offChara5.Opacity = 1.0;

            }
            else
            {

            }

        }
        
        public void LoadDefDeck()
        {
            power_sum_def = 0.0;
            for (int i = 0; i < 5; i++)
            {
                StreamReader sr = new StreamReader("character_defence.txt");
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                    int pos = Array.IndexOf(temp, select_defence_temp[i]);
                    if (pos > -1)
                    {
                        Level_variable.star[i] = Convert.ToInt32(temp[pos + 2]);
                        Level_variable.Lv[i] = Convert.ToInt32(temp[pos + 3]);
                        Level_variable.Rank[i] = Convert.ToInt32(temp[pos + 4]);

                        //pos + 4 : 전용장비 0~160
                        Level_variable.equip[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 5]));
                        Level_variable.UE_Lv[i] = Convert.ToInt32(temp[pos + 5]);
#if DEBUG
                        Debug.WriteLine(temp[pos] + "," + temp[pos + 1]);
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
                        //
                        if (Convert.ToInt32(temp[pos + 6]) > 0)
                        { Level_variable.equip2[i] = true; }
                        else
                        {
                            Level_variable.equip2[i] = false;
                        }

                        if (Convert.ToInt32(temp[pos + 7]) > 0)
                        { Level_variable.equip4[i] = true; }
                        else
                        {
                            Level_variable.equip4[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 8]) > 0)
                        { Level_variable.equip6[i] = true; }
                        else
                        {
                            Level_variable.equip6[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 9]) > 0)
                        { Level_variable.equip5[i] = true; }
                        else
                        {
                            Level_variable.equip5[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 10]) > 0)
                        {
                            Level_variable.equip3[i] = true;
                        }
                        else
                        {
                            Level_variable.equip3[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 11]) > 0)
                        { Level_variable.equip1[i] = true; }
                        else
                        {
                            Level_variable.equip1[i] = false;
                        }

                        //강화

                        Level_variable.rf2[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 6])) ? Convert.ToInt32(temp[pos + 6]) : 0;
                        Level_variable.rf4[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 7])) ? Convert.ToInt32(temp[pos + 7]) : 0;
                        Level_variable.rf6[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 8])) ? Convert.ToInt32(temp[pos + 8]) : 0;
                        Level_variable.rf5[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 9])) ? Convert.ToInt32(temp[pos + 9]) : 0;
                        Level_variable.rf3[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 10])) ? Convert.ToInt32(temp[pos + 10]) : 0;
                        Level_variable.rf1[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 11])) ? Convert.ToInt32(temp[pos + 11]) : 0;

                        break;
                    }
                }
                sr.Close();
            }

            //스탯 적용
            for (int i = 0; i < 5; i++)
            {
                Chara_set.status_cal(select_defence_eng[i], Level_variable.star[i], Level_variable.Lv[i], Level_variable.Rank[i], i);
                Chara_set.status_equip(select_defence_eng[i], Level_variable.Rank[i], Level_variable.equip1[i], Level_variable.equip2[i], Level_variable.equip3[i], Level_variable.equip4[i], Level_variable.equip5[i], Level_variable.equip6[i], Level_variable.rf1[i], Level_variable.rf2[i], Level_variable.rf3[i], Level_variable.rf4[i], Level_variable.rf5[i], Level_variable.rf6[i], i);
                Chara_set.status_unique_equip(select_defence_eng[i], ref Level_variable.equip[i], Level_variable.UE_Lv[i], i);
                Chara_set.status_destiny(select_defence_eng[i], i);
            }

            //전투력 적용
            for (int i = 0; i < 5; i++)
            {
                Level_variable.power[i] = Stat_variable.HP[i] * 0.1 + Stat_variable.PA[i] * 1 + Stat_variable.MA[i] * 1 + Stat_variable.PD[i] * 4.5 + Stat_variable.MD[i] * 4.5 + Stat_variable.PC[i] * 0.5 +
                    Stat_variable.MC[i] * 0.5 + Stat_variable.HPauto[i] * 0.1 + Stat_variable.TPauto[i] * 0.3 + Stat_variable.Dodge[i] * 6 + Stat_variable.HPabs[i] * 4.5 + Stat_variable.HPup[i] * 1 +
                    Stat_variable.TPup[i] * 1.5 + Stat_variable.TPdec[i] * 3 + Stat_variable.acc[i] * 2;

                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;

                if (Level_variable.equip[i] == true)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1.2 * 10 + 100;
                }
                else
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                }

                if (Level_variable.star[i] >= 6)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1.5 * 10 + 2000;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                }
                else if (Level_variable.star[i] >= 5)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                }
                else
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                power_sum_def += Level_variable.power[i];
            }
        }

        public void LoadOffDeck()
        {
            power_sum_off = 0.0;
            for (int i = 15; i < 20; i++)
            {
                StreamReader sr = new StreamReader("character_offence.txt");
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                    int pos = Array.IndexOf(temp, select_offence_temp[i - 15]);
                    if (pos > -1)
                    {
                        Level_variable.star[i] = Convert.ToInt32(temp[pos + 2]);
                        Level_variable.Lv[i] = Convert.ToInt32(temp[pos + 3]);
                        Level_variable.Rank[i] = Convert.ToInt32(temp[pos + 4]);

                        //pos + 4 : 전용장비 0~160
                        Level_variable.equip[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 5]));
                        Level_variable.UE_Lv[i] = Convert.ToInt32(temp[pos + 5]);
#if DEBUG
                        Debug.WriteLine(temp[pos] + "," + temp[pos + 1]);
                        Debug.WriteLine(Convert.ToString(temp[pos + 2]) + "," + Convert.ToString(temp[pos + 3]) + "," + Convert.ToString(temp[pos + 4])
                            + "," + Convert.ToString(temp[pos + 5]) + "," + Convert.ToString(temp[pos + 6]) + "," + Convert.ToString(temp[pos + 7])
                            + "," + Convert.ToString(temp[pos + 8]) + "," + Convert.ToString(temp[pos + 9]) + "," + Convert.ToString(temp[pos + 10]) + "," + Convert.ToString(temp[pos + 11]));

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
                        //
                        if (Convert.ToInt32(temp[pos + 6]) > 0)
                        { Level_variable.equip2[i] = true; }
                        else
                        {
                            Level_variable.equip2[i] = false;
                        }

                        if (Convert.ToInt32(temp[pos + 7]) > 0)
                        { Level_variable.equip4[i] = true; }
                        else
                        {
                            Level_variable.equip4[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 8]) > 0)
                        { Level_variable.equip6[i] = true; }
                        else
                        {
                            Level_variable.equip6[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 9]) > 0)
                        { Level_variable.equip5[i] = true; }
                        else
                        {
                            Level_variable.equip5[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 10]) > 0)
                        {
                            Level_variable.equip3[i] = true;
                        }
                        else
                        {
                            Level_variable.equip3[i] = false;
                        }
                        if (Convert.ToInt32(temp[pos + 11]) > 0)
                        { Level_variable.equip1[i] = true; }
                        else
                        {
                            Level_variable.equip1[i] = false;
                        }

                        //강화

                        Level_variable.rf2[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 6])) ? Convert.ToInt32(temp[pos + 6]) : 0;
                        Level_variable.rf4[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 7])) ? Convert.ToInt32(temp[pos + 7]) : 0;
                        Level_variable.rf6[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 8])) ? Convert.ToInt32(temp[pos + 8]) : 0;
                        Level_variable.rf5[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 9])) ? Convert.ToInt32(temp[pos + 9]) : 0;
                        Level_variable.rf3[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 10])) ? Convert.ToInt32(temp[pos + 10]) : 0;
                        Level_variable.rf1[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 11])) ? Convert.ToInt32(temp[pos + 11]) : 0;

                        break;
                    }
                }
                sr.Close();
            }

            //스탯 적용
            for (int i = 15; i < 20; i++)
            {
                Chara_set.status_cal(select_offence_eng[i - 15], Level_variable.star[i], Level_variable.Lv[i], Level_variable.Rank[i], i);
                Chara_set.status_equip(select_offence_eng[i - 15], Level_variable.Rank[i], Level_variable.equip1[i], Level_variable.equip2[i], Level_variable.equip3[i], Level_variable.equip4[i], Level_variable.equip5[i], Level_variable.equip6[i], Level_variable.rf1[i], Level_variable.rf2[i], Level_variable.rf3[i], Level_variable.rf4[i], Level_variable.rf5[i], Level_variable.rf6[i], i);
                Chara_set.status_unique_equip(select_offence_eng[i - 15], ref Level_variable.equip[i], Level_variable.UE_Lv[i], i);
                Chara_set.status_destiny(select_offence_eng[i - 15], i);
            }

            //전투력 적용
            for (int i = 15; i < 20; i++)
            {
                Level_variable.power[i] = Stat_variable.HP[i] * 0.1 + Stat_variable.PA[i] * 1 + Stat_variable.MA[i] * 1 + Stat_variable.PD[i] * 4.5 + Stat_variable.MD[i] * 4.5 + Stat_variable.PC[i] * 0.5 +
                    Stat_variable.MC[i] * 0.5 + Stat_variable.HPauto[i] * 0.1 + Stat_variable.TPauto[i] * 0.3 + Stat_variable.Dodge[i] * 6 + Stat_variable.HPabs[i] * 4.5 + Stat_variable.HPup[i] * 1 +
                    Stat_variable.TPup[i] * 1.5 + Stat_variable.TPdec[i] * 3 + Stat_variable.acc[i] * 2;

                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;

                if (Level_variable.equip[i] == true)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1.2 * 10 + 100;
                }
                else
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                }

                if (Level_variable.star[i] >= 6)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1.5 * 10 + 2000;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                }
                else if (Level_variable.star[i] >= 5)
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                }
                else
                {
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                    Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                }
            }

            power_sum_off = Level_variable.power[15] + Level_variable.power[16] + Level_variable.power[17] + Level_variable.power[18] + Level_variable.power[19];

        }
        public void SetDefPower(int power) { tB_def_power.Text = "방덱 전투력 : " + Convert.ToString(power) + "     "; }
        public void SetOffPower(int power) 
        {
            if(isFindOffReady)
                tB_off_power.Text = "     " + "공덱 전투력 : ??";
            else
                tB_off_power.Text = "     " + "공덱 전투력 : " + Convert.ToString(power);
        }
        
        public void ImagePrepare()
        {
            int StarIndex = 1;
            string[] StarIndexStr = { "1", "3", "6" };
            int CharaIndex = 1;
            int Index = 0;

            //작마키까지 168
            while (CharaIndex <= 168)
            {
                //빈칸 제거
                if (CharaIndex == 19 || CharaIndex == 24 || CharaIndex == 35 || CharaIndex == 39
                    || CharaIndex == 41 || CharaIndex == 62 || CharaIndex == 64 || CharaIndex == 67 || CharaIndex == 69
                    || CharaIndex == 72 || CharaIndex == 73 || CharaIndex == 74 || CharaIndex == 102
                    || CharaIndex == 148 || CharaIndex == 149 || CharaIndex == 151 || CharaIndex == 152 || CharaIndex == 153 || CharaIndex == 154
                    || CharaIndex == 161 || CharaIndex == 164 )
                {

                }
                else
                {
                    //6성
                    if (CharaIndex == 1 || CharaIndex == 2 || CharaIndex == 3 || CharaIndex == 4 || CharaIndex == 6 || CharaIndex == 10 || CharaIndex == 11
                        || CharaIndex == 12 || CharaIndex == 16 || CharaIndex == 18 || CharaIndex == 20 || CharaIndex == 21 || CharaIndex == 22 || CharaIndex == 23 
                        || CharaIndex == 25 || CharaIndex == 28 ||  CharaIndex == 29 
                        || CharaIndex == 30 || CharaIndex == 32 || CharaIndex == 33 || CharaIndex == 34 
                        || CharaIndex == 36 || CharaIndex == 46 || CharaIndex == 48 || CharaIndex == 49 ||  CharaIndex == 52 || CharaIndex == 58 || CharaIndex == 59 
                        || CharaIndex == 60)
                    {
                        for (StarIndex = 0; StarIndex < 3; StarIndex++)
                        {
                            if (CharaIndex < 10)
                            {
                                uriString[Index] = "100" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;
                            }
                            else if (CharaIndex >= 10 && CharaIndex < 100)
                            {
                                uriString[Index] = "10" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;
                            }
                            else if (CharaIndex >= 100 && CharaIndex < 1000)
                            {
                                uriString[Index] = "1" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;
                            }

                        }
                    }
                    else
                    {
                        for (StarIndex = 0; StarIndex < 2; StarIndex++)
                        {
                            if (CharaIndex < 10)
                            {
                                uriString[Index] = "100" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;

                            }
                            else if (CharaIndex >= 10 && CharaIndex < 100)
                            {
                                uriString[Index] = "10" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;
                            }
                            else if (CharaIndex >= 100 && CharaIndex < 1000)
                            {
                                uriString[Index] = "1" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                                //Debug.WriteLine(uriString[Index]);
                                Index++;
                            }

                        }

                    }
                }
                CharaIndex++;
            }

            CharaIndex = 1;

            //프린세스 폼 6명
            while (CharaIndex <= 6)
            {
                //빈칸 제거
                if (CharaIndex == 3)
                {

                }
                else
                {
                    for (StarIndex = 0; StarIndex < 2; StarIndex++)
                    {
                        uriString[Index] = "180" + Convert.ToString(CharaIndex) + StarIndexStr[StarIndex] + "1";
                        // Debug.WriteLine(uriString[Index]);
                        Index++;
                    }
                }
                CharaIndex++;
            }
            /*
            for (Index = 0; Index < MaxLoopCount; Index++)
            {
                Debug.WriteLine(Convert.ToString(Index) + " : " + uriString[Index]);


                if (uriString[Index] != null)
                {
                    //var uriTemp = new Uri(uriString[Index], UriKind.Absolute);
                    //BitmapImage BmiTemp = new BitmapImage(uriTemp);
                    //Bitmap BmpTemp = new Bitmap(ImageSourceToBitmap(BmiTemp));
                    //Mat matTemp = OpenCvSharp.Extensions.BitmapConverter.ToMat(BmpTemp);
                    //Cv2.ImShow("22",matTemp);
                    //UnitIcon[Index] =matTemp ;
                }

            }
            */
            Index = 0;
            while (uriString[Index] != null)
            {
                Debug.WriteLine(Convert.ToString(Index) + " : " + uriString[Index]);


                if (uriString[Index] != null)
                {
                    //var uriTemp = new Uri(uriString[Index], UriKind.Absolute);
                    //BitmapImage BmiTemp = new BitmapImage(uriTemp);
                    //Bitmap BmpTemp = new Bitmap(ImageSourceToBitmap(BmiTemp));
                    //Mat matTemp = OpenCvSharp.Extensions.BitmapConverter.ToMat(BmpTemp);
                    //Cv2.ImShow("22",matTemp);
                    //UnitIcon[Index] =matTemp ;
                }
                Index++;
            }
            //BitmapImage bmp = new BitmapImage(uriSource);
            isImageprepared = true;

        }

        public void searchIMG(Bitmap imageBig, int isOfforDef)
        {
            //isofforDef == 1 방덱 , 0이면 공덱
            int ix = 0;
            bool isFoundFirstChara = false;
            int numChara = 0;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            double max_ratio = 0.0;
            double max_maxval = 0.0;
            double ratio;
            bool WrongArea = false;

            while (numChara < 5)
            {
                try
                {
                    string uriStr = "";
                    if (isOfforDef == 1)
                    {
                        uriStr = "pack://application:,,,/res/icon_unit_crop/" + uriString[ix] + ".png";
                    }
                    else if (isOfforDef == 0) { uriStr = "pack://application:,,,/res/icon_unit_crop/" + uriString[ix] + ".png"; }
                    else { }

                    var uriSource = new Uri(uriStr, UriKind.Absolute);
                    BitmapImage bmp = new BitmapImage(uriSource);
                    Mat TemplateImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(ImageSourceToBitmap(bmp));
                    Mat CapturedSourceImage = OpenCvSharp.Extensions.BitmapConverter.ToMat(imageBig);

                    Mat TemplateImageGray = new Mat();
                    //Mat TemplateImageCanny = new Mat();
                    Mat CapturedSourceImageGray = new Mat();
                    //Mat CapturedSourceImageCanny = new Mat();
                    Cv2.CvtColor(TemplateImage, TemplateImageGray, ColorConversionCodes.BGR2GRAY);
                    //Cv2.Canny(TemplateImageGray, TemplateImageCanny, 50, 200);

                    Cv2.CvtColor(CapturedSourceImage, CapturedSourceImageGray, ColorConversionCodes.BGR2GRAY);
                    //Cv2.Canny(CapturedSourceImageGray, CapturedSourceImageCanny, 50, 200);

                    Mat CapturedSourceImageGrayResized = new Mat();

                    Debug.WriteLine("이미지 검색중 ... ID : " + uriString[ix]);
                    int FirstLoopCount = 100;

                    if (isFoundFirstChara == false)
                    {
                        //첫 캐릭터 찾기 전까지는 100번 돌림
                        for (int i = FirstLoopCount; i > 1; i--)
                        {
                            ratio = i * 0.01;
                            OpenCvSharp.Size dsize = new OpenCvSharp.Size((double)CapturedSourceImageGray.Width * ratio, (double)CapturedSourceImageGray.Height * ratio);

                            Cv2.Resize(CapturedSourceImageGray, CapturedSourceImageGrayResized, dsize);
                            //Debug.WriteLine("CapturedSourceImageGrayResized.Width = " + Convert.ToString(CapturedSourceImageGrayResized.Width));
                            //Debug.WriteLine("CapturedSourceImageGrayResized.Heigth = " + Convert.ToString(CapturedSourceImageGrayResized.Height));
                            if (CapturedSourceImageGrayResized.Width < TemplateImageGray.Width || CapturedSourceImageGrayResized.Height < TemplateImageGray.Height)
                            {
                                //Debug.WriteLine("break da loop");
                                break;
                            }

                            Mat res = CapturedSourceImageGrayResized.MatchTemplate(TemplateImageGray, TemplateMatchModes.CCoeffNormed);

                            //찾은 이미지의 유사도를 담을 더블형 최대 최소 값을 선언합니다.
                            double minval, maxval = 0;
                            //찾은 이미지의 위치를 담을 포인트형을 선언합니다.
                            OpenCvSharp.Point minloc, maxloc;
                            //찾은 이미지의 유사도 및 위치 값을 받습니다. 
                            Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);
#if DEBUG
                            Debug.WriteLine("Ratio = " + Convert.ToString(ratio) + ", 찾은 이미지의 유사도 : " + maxval);

#else
#endif
                            if (maxval > max_maxval)
                            {
                                max_ratio = ratio + 0.01;
                                max_maxval = maxval;
                            }
                        }

                    }
                    else
                    {
                        Mat CapturedSourceImageFixedRatioResize = new Mat();
                        //찾으면 배율만 적용해서 돌림
                        OpenCvSharp.Size dsize = new OpenCvSharp.Size((double)CapturedSourceImageGray.Width * max_ratio, (double)CapturedSourceImageGray.Height * max_ratio);
                        Cv2.Resize(CapturedSourceImageGray, CapturedSourceImageFixedRatioResize, dsize);

                        Mat res = CapturedSourceImageFixedRatioResize.MatchTemplate(TemplateImageGray, TemplateMatchModes.CCoeffNormed);

                        //찾은 이미지의 유사도를 담을 더블형 최대 최소 값을 선언합니다.
                        double minval, maxval = 0;
                        //찾은 이미지의 위치를 담을 포인트형을 선언합니다.
                        OpenCvSharp.Point minloc, maxloc;
                        //찾은 이미지의 유사도 및 위치 값을 받습니다. 
                        Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);
#if DEBUG
                        Debug.WriteLine("찾은 이미지의 유사도 : " + maxval);

#else
#endif
                        if (maxval > max_maxval)
                        {
                            max_maxval = maxval;
                        }
                    }


                    Debug.WriteLine("max ratio = " + Convert.ToString(max_ratio));
                    Debug.WriteLine("max maxval = " + Convert.ToString(max_maxval));
                    // Cv2.ImShow("2", CapturedSourceImageResized);
                    //Cv2.ImShow("1", TemplateImage);

                    if (max_maxval < 0.85 && max_maxval > 0.01)
                    {
                        //정확도 미달이면 없는거니까 다음으로 넘어감 
                        ix++;
                    }
                    else if (max_maxval >= 0.85)
                    {
                        //발견 함
                        max_maxval = 0.0;
                        isFoundFirstChara = true;

                        DeckIndex[numChara] = uriString[ix];
                        numChara++; ix++;
                    }
                    else
                    {
                        //잘못 지정한 경우
                        MessageBox.Show("범위 지정이 잘못되었습니다", "알림");
                        WrongArea = true;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    MessageBox.Show("몬가잘못됨", "알림");
                    break;
                }

            }


            sw.Stop();
            Debug.WriteLine("이미지서치 시간 : {0} ms", sw.ElapsedMilliseconds);

            if (!WrongArea && isFoundFirstChara && numChara == 5)
            {
                string[] EngName = new string[5];
                string[] KorName = new string[5];
                for (int idx = 0; idx < 5; idx++)
                {

                    Debug.WriteLine("ID " + Convert.ToString(idx) + " = " + DeckIndex[idx] + "," + IDtoCharaEngName(DeckIndex[idx]));

                    EngName[idx] = IDtoCharaEngName(DeckIndex[idx]);
                    KorName[idx] = IDtoCharaKorName(DeckIndex[idx]);
                }
                if (isOfforDef == 1)
                    SetDefDeck(EngName, KorName);
                else if (isOfforDef == 0)
                    SetOffDeck(EngName, KorName);
                else
                {
                    MessageBox.Show("몬가잘못됨", "알림");
                }

            }
        }

        public void SetDefDeck(string[] DefDeckListEng, string[] DefDeckListKor)
        {
            try
            {
                Debug.WriteLine(DefDeckListEng.Length);
                select_count_temp = DefDeckListEng.Length;

                #region save

                if (select_count_temp == 5)
                {
                    /*
                    for (int i = 0; i < 5; i++)
                    {
                        select_defence_temp_eng[i] = DefDeckListEng[i];
                        select_defence_temp[i] = DefDeckListKor[i];
                    }
                    */
                    Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                    Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                    Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                    Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();

                    string[] tempY = new string[10];
                    tempY = CharaSort(DefDeckListEng, DefDeckListKor);

                    if (tempY != null)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            select_defence_temp[i] = tempY[i + 5];
                            select_defence_temp_eng[i] = tempY[i];
                        }

                        select_defence = select_defence_temp;
                        select_defence_eng = select_defence_temp_eng;

                        //캐릭터 정보 불러오기

                        for (int i = 0; i < 5; i++)
                        {
                            StreamReader sr = new StreamReader("character_defence.txt");
                            while (!sr.EndOfStream)
                            {
                                string s = sr.ReadLine();
                                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                                int pos = Array.IndexOf(temp, select_defence_temp[i]);
                                if (pos > -1)
                                {
                                    Level_variable.star[i] = Convert.ToInt32(temp[pos + 2]);
                                    Level_variable.Lv[i] = Convert.ToInt32(temp[pos + 3]);
                                    Level_variable.Rank[i] = Convert.ToInt32(temp[pos + 4]);

                                    //pos + 4 : 전용장비 0~160
                                    Level_variable.equip[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 5]));
                                    Level_variable.UE_Lv[i] = Convert.ToInt32(temp[pos + 5]);
#if DEBUG
                                    Debug.WriteLine(temp[pos] + "," + temp[pos + 1]);
                                    Debug.WriteLine(Convert.ToString(temp[pos + 2]) + "," + Convert.ToString(temp[pos + 3]) + "," + Convert.ToString(temp[pos + 4])
                                        + "," + Convert.ToString(temp[pos + 5]) + "," + Convert.ToString(temp[pos + 6]) + "," + Convert.ToString(temp[pos + 7])
                                        + "," + Convert.ToString(temp[pos + 8]) + "," + Convert.ToString(temp[pos + 9]) + "," + Convert.ToString(temp[pos + 10]) + "," + Convert.ToString(temp[pos + 11]));

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
                                    //
                                    if (Convert.ToInt32(temp[pos + 6]) > 0)
                                    { Level_variable.equip2[i] = true; }
                                    else
                                    {
                                        Level_variable.equip2[i] = false;
                                    }

                                    if (Convert.ToInt32(temp[pos + 7]) > 0)
                                    { Level_variable.equip4[i] = true; }
                                    else
                                    {
                                        Level_variable.equip4[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 8]) > 0)
                                    { Level_variable.equip6[i] = true; }
                                    else
                                    {
                                        Level_variable.equip6[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 9]) > 0)
                                    { Level_variable.equip5[i] = true; }
                                    else
                                    {
                                        Level_variable.equip5[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 10]) > 0)
                                    {
                                        Level_variable.equip3[i] = true;
                                    }
                                    else
                                    {
                                        Level_variable.equip3[i] = false;

                                    }
                                    if (Convert.ToInt32(temp[pos + 11]) > 0)
                                    { Level_variable.equip1[i] = true; }
                                    else
                                    {
                                        Level_variable.equip1[i] = false;
                                    }

                                    //강화
                                    #region rein

                                    Level_variable.rf2[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 6])) ? Convert.ToInt32(temp[pos + 6]) : 0;
                                    Level_variable.rf4[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 7])) ? Convert.ToInt32(temp[pos + 7]) : 0;
                                    Level_variable.rf6[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 8])) ? Convert.ToInt32(temp[pos + 8]) : 0;
                                    Level_variable.rf5[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 9])) ? Convert.ToInt32(temp[pos + 9]) : 0;
                                    Level_variable.rf3[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 10])) ? Convert.ToInt32(temp[pos + 10]) : 0;
                                    Level_variable.rf1[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 11])) ? Convert.ToInt32(temp[pos + 11]) : 0;

                                    #endregion
                                    break;

                                }
                            }
                            sr.Close();
                        }


                        //스탯 적용
                        for (int i = 0; i < 5; i++)
                        {
                            Chara_set.status_cal(select_defence_eng[i], Level_variable.star[i], Level_variable.Lv[i], Level_variable.Rank[i], i);
                            Chara_set.status_equip(select_defence_eng[i], Level_variable.Rank[i], Level_variable.equip1[i], Level_variable.equip2[i], Level_variable.equip3[i], Level_variable.equip4[i], Level_variable.equip5[i], Level_variable.equip6[i], Level_variable.rf1[i], Level_variable.rf2[i], Level_variable.rf3[i], Level_variable.rf4[i], Level_variable.rf5[i], Level_variable.rf6[i], i);
                            Chara_set.status_unique_equip(select_defence_eng[i], ref Level_variable.equip[i], Level_variable.UE_Lv[i], i);
                            Chara_set.status_destiny(select_defence_eng[i], i);
                        }

                        //전투력 적용
                        for (int i = 0; i < 5; i++)
                        {
                            Level_variable.power[i] = Stat_variable.HP[i] * 0.1 + Stat_variable.PA[i] * 1 + Stat_variable.MA[i] * 1 + Stat_variable.PD[i] * 4.5 + Stat_variable.MD[i] * 4.5 + Stat_variable.PC[i] * 0.5 +
                                Stat_variable.MC[i] * 0.5 + Stat_variable.HPauto[i] * 0.1 + Stat_variable.TPauto[i] * 0.3 + Stat_variable.Dodge[i] * 6 + Stat_variable.HPabs[i] * 4.5 + Stat_variable.HPup[i] * 1 +
                                Stat_variable.TPup[i] * 1.5 + Stat_variable.TPdec[i] * 3 + Stat_variable.acc[i] * 2;

                            Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;

                            if (Level_variable.equip[i] == true)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1.2 * 10 + 100;
                            }
                            else
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                            }

                            if (Level_variable.star[i] >= 6)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1.5 * 10 + 2000;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                            }
                            else if (Level_variable.star[i] >= 5)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                            }
                            else
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                            }
                        }

                        double power_sum_def = 0.0;
                        for (int i = 0; i < 5; i++)
                        {
                            power_sum_def += Level_variable.power[i];
                        }

                        #endregion

                        select_count = 0;
                        Debug.WriteLine("SetDefDeck");
                        Debug.WriteLine("select_count_temp = {0}", select_count_temp);
                        Debug.WriteLine("select_count = {0}", select_count);
                        select_defence = select_defence_temp;
                        select_defence_eng = select_defence_temp_eng;

                        isDefDeckReady = true;

                        MessageBox.Show("방덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp[0], select_defence_temp[1], select_defence_temp[2], select_defence_temp[3], select_defence_temp[4]);
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp_eng[0], select_defence_temp_eng[1], select_defence_temp_eng[2], select_defence_temp_eng[3], select_defence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_defence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[4 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[4 - i]));
                            Debug.WriteLine(" ");
                        }

                        Debug.WriteLine(string.Format("{0:F2}", power_sum_def));
#endif
                        ShowDefCharas(select_defence_temp_eng);
                        SetDefPower((int)power_sum_def);

                        UnCheckAll();
                    }
                    else
                        MessageBox.Show("ㅈ망", "알림");
                    

                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            
        }

        public void SetOffDeck(string[] DeckListEng, string[] DeckListKor)
        {
            select_count_temp = DeckListEng.Length;
            
            #region save
            try
            {
                if (select_count_temp == 5)
                {
                    /*
                    for (int i = 0; i < 5; i++)
                    {
                        select_offence_temp_eng[i] = DeckListEng[i];
                        select_offence_temp[i] = DeckListKor[i];
                    }
                    */

                    Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                    Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                    Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                    Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                    Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                    Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();

                    string[] tempZ = new string[10];
                    tempZ = CharaSort(DeckListEng, DeckListKor);

                    if (tempZ != null)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            select_offence_temp[i] = tempZ[i + 5];
                            select_offence_temp_eng[i] = tempZ[i];
                        }

                        select_offence = select_offence_temp;
                        select_offence_eng = select_offence_temp_eng;
                        //캐릭터 정보 불러오기

                        for (int i = 15; i < 20; i++)
                        {
                            StreamReader sr = new StreamReader("character_offence.txt");
                            while (!sr.EndOfStream)
                            {
                                string s = sr.ReadLine();
                                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                                int pos = Array.IndexOf(temp, select_offence_temp[i - 15]);
                                if (pos > -1)
                                {
                                    Level_variable.star[i] = Convert.ToInt32(temp[pos + 2]);
                                    Level_variable.Lv[i] = Convert.ToInt32(temp[pos + 3]);
                                    Level_variable.Rank[i] = Convert.ToInt32(temp[pos + 4]);

                                    //pos + 4 : 전용장비 0~160
                                    Level_variable.equip[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 5]));
                                    Level_variable.UE_Lv[i] = Convert.ToInt32(temp[pos + 5]);

#if DEBUG
                                    Debug.WriteLine(temp[pos] + "," + temp[pos + 1]);
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
                                    //
                                    if (Convert.ToInt32(temp[pos + 6]) > 0)
                                    { Level_variable.equip2[i] = true; }
                                    else
                                    {
                                        Level_variable.equip2[i] = false;
                                    }

                                    if (Convert.ToInt32(temp[pos + 7]) > 0)
                                    { Level_variable.equip4[i] = true; }
                                    else
                                    {
                                        Level_variable.equip4[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 8]) > 0)
                                    { Level_variable.equip6[i] = true; }
                                    else
                                    {
                                        Level_variable.equip6[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 9]) > 0)
                                    { Level_variable.equip5[i] = true; }
                                    else
                                    {
                                        Level_variable.equip5[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 10]) > 0)
                                    {
                                        Level_variable.equip3[i] = true;
                                    }
                                    else
                                    {
                                        Level_variable.equip3[i] = false;
                                    }
                                    if (Convert.ToInt32(temp[pos + 11]) > 0)
                                    { Level_variable.equip1[i] = true; }
                                    else
                                    {
                                        Level_variable.equip1[i] = false;
                                    }

                                    //강화
                                    #region rein

                                    Level_variable.rf2[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 6])) ? Convert.ToInt32(temp[pos + 6]) : 0;
                                    Level_variable.rf4[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 7])) ? Convert.ToInt32(temp[pos + 7]) : 0;
                                    Level_variable.rf6[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 8])) ? Convert.ToInt32(temp[pos + 8]) : 0;
                                    Level_variable.rf5[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 9])) ? Convert.ToInt32(temp[pos + 9]) : 0;
                                    Level_variable.rf3[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 10])) ? Convert.ToInt32(temp[pos + 10]) : 0;
                                    Level_variable.rf1[i] = Convert.ToBoolean(Convert.ToInt32(temp[pos + 11])) ? Convert.ToInt32(temp[pos + 11]) : 0;

                                    #endregion
                                    break;

                                }
                            }
                            sr.Close();
                        }

                        //스탯 적용
                        for (int i = 15; i < 20; i++)
                        {
                            Chara_set.status_cal(select_offence_eng[i - 15], Level_variable.star[i], Level_variable.Lv[i], Level_variable.Rank[i], i);
                            Chara_set.status_equip(select_offence_eng[i - 15], Level_variable.Rank[i], Level_variable.equip1[i], Level_variable.equip2[i], Level_variable.equip3[i], Level_variable.equip4[i], Level_variable.equip5[i], Level_variable.equip6[i], Level_variable.rf1[i], Level_variable.rf2[i], Level_variable.rf3[i], Level_variable.rf4[i], Level_variable.rf5[i], Level_variable.rf6[i], i);
                            Chara_set.status_unique_equip(select_offence_eng[i - 15], ref Level_variable.equip[i], Level_variable.UE_Lv[i], i);
                            Chara_set.status_destiny(select_offence_eng[i - 15], i);
                        }

                        //전투력 적용
                        for (int i = 15; i < 20; i++)
                        {
                            Level_variable.power[i] = Stat_variable.HP[i] * 0.1 + Stat_variable.PA[i] * 1 + Stat_variable.MA[i] * 1 + Stat_variable.PD[i] * 4.5 + Stat_variable.MD[i] * 4.5 + Stat_variable.PC[i] * 0.5 +
                                Stat_variable.MC[i] * 0.5 + Stat_variable.HPauto[i] * 0.1 + Stat_variable.TPauto[i] * 0.3 + Stat_variable.Dodge[i] * 6 + Stat_variable.HPabs[i] * 4.5 + Stat_variable.HPup[i] * 1 +
                                Stat_variable.TPup[i] * 1.5 + Stat_variable.TPdec[i] * 3 + Stat_variable.acc[i] * 2;

                            Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;

                            if (Level_variable.equip[i] == true)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1.2 * 10 + 100;
                            }
                            else
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                            }

                            if (Level_variable.star[i] >= 6)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1.5 * 10 + 2000;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                            }
                            else if (Level_variable.star[i] >= 5)
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10 + 150;
                            }
                            else
                            {
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                                Level_variable.power[i] += Level_variable.Lv[i] * 1 * 10;
                            }
                        }

                        double power_sum_off = Level_variable.power[15] + Level_variable.power[16] + Level_variable.power[17] + Level_variable.power[18] + Level_variable.power[19];


                        #endregion


                        select_count = 0;
                        select_offence = select_offence_temp;
                        select_offence_eng = select_offence_temp_eng;

                        Debug.WriteLine("SetOffDeck");
                        Debug.WriteLine("select_count_temp = {0}", select_count_temp);
                        Debug.WriteLine("select_count = {0}", select_count);
                        select_defence = select_defence_temp;

                        isOffDeckReady = true;

                        MessageBox.Show("공덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp[0], select_offence_temp[1], select_offence_temp[2], select_offence_temp[3], select_offence_temp[4]);
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp_eng[0], select_offence_temp_eng[1], select_offence_temp_eng[2], select_offence_temp_eng[3], select_offence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_offence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[19 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[19 - i]));
                            Debug.WriteLine(" ");
                        }
                        Debug.WriteLine(string.Format("{0:F2}", power_sum_off));
#endif
                        SetOffPower((int)power_sum_off);
                        ShowOffCharas(select_offence_temp_eng);

                        UnCheckAll();

                    }
                    else
                        MessageBox.Show("ㅈ망", "알림");
                    
                }
            }
            catch (Exception e)
            { Debug.WriteLine(e.Message); }
        }

        //캐릭터 선택 의코로까지
        public void CharacterSelectCount(int isOfforDef)
        {
            //isOfforDef == 1 방덱 , 0이면 공덱
            
            string[] temp = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string[] temp_eng = new string[15] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

            #region csss3

            if (cs.hiyori == true)
            {
                temp[select_count_temp] = "히요리";
                temp_eng[select_count_temp] = "hiyori";
                select_count_temp++;
            }
            if (cs.yui == true)
            {
                temp[select_count_temp] = "유이";
                temp_eng[select_count_temp] = "yui";
                select_count_temp++;
            }
            if (cs.rei == true)
            {
                temp[select_count_temp] = "레이";
                temp_eng[select_count_temp] = "rei";
                select_count_temp++;
            }
            if (cs.misogi == true)
            {
                temp[select_count_temp] = "미소기";
                temp_eng[select_count_temp] = "misogi";
                select_count_temp++;
            }
            if (cs.matsuri == true)
            {
                temp[select_count_temp] = "마츠리";
                temp_eng[select_count_temp] = "matsuri";
                select_count_temp++;
            }
            if (cs.akari == true)
            {
                temp[select_count_temp] = "아카리";
                temp_eng[select_count_temp] = "akari";
                select_count_temp++;
            }
            if (cs.miyako == true)
            {
                temp[select_count_temp] = "미야코";
                temp_eng[select_count_temp] = "miyako";
                select_count_temp++;
            }
            if (cs.yuki == true)
            {
                temp[select_count_temp] = "유키";
                temp_eng[select_count_temp] = "yuki";
                select_count_temp += 1;
            }
            if (cs.anna == true)
            {
                temp[select_count_temp] = "안나";
                temp_eng[select_count_temp] = "anna";
                select_count_temp += 1;
            }
            if (cs.maho == true)
            {
                temp[select_count_temp] = "마호";
                temp_eng[select_count_temp] = "maho";
                select_count_temp += 1;

            }
            if (cs.rino == true)
            {
                temp[select_count_temp] = "리노";
                temp_eng[select_count_temp] = "rino";
                select_count_temp += 1;
            }
            if (cs.hatsune == true)
            {
                temp[select_count_temp] = "하츠네";
                temp_eng[select_count_temp] = "hatsune";
                select_count_temp += 1;
            }
            if (cs.nanaka == true)
            {
                temp[select_count_temp] = "나나카";
                temp_eng[select_count_temp] = "nanaka";
                select_count_temp += 1;
            }
            if (cs.kasumi == true)
            {
                temp[select_count_temp] = "카스미";
                temp_eng[select_count_temp] = "kasumi";
                select_count_temp += 1;
            }
            if (cs.misato == true)
            {
                temp[select_count_temp] = "미사토";
                temp_eng[select_count_temp] = "misato";
                select_count_temp += 1;
            }
            if (cs.suzuna == true)
            {
                temp[select_count_temp] = "스즈나";
                temp_eng[select_count_temp] = "suzuna";
                select_count_temp += 1;
            }
            if (cs.kaori == true)
            {
                temp[select_count_temp] = "카오리";
                temp_eng[select_count_temp] = "kaori";
                select_count_temp += 1;
            }
            if (cs.io == true)
            {
                temp[select_count_temp] = "이오";
                temp_eng[select_count_temp] = "io";
                select_count_temp += 1;
            }
            if (cs.mimi == true)
            {
                temp[select_count_temp] = "미미";
                temp_eng[select_count_temp] = "mimi";
                select_count_temp += 1;
            }
            if (cs.kurumi == true)
            {
                temp[select_count_temp] = "쿠루미";
                temp_eng[select_count_temp] = "kurumi";
                select_count_temp += 1;
            }
            if (cs.yori == true)
            {
                temp[select_count_temp] = "요리";
                temp_eng[select_count_temp] = "yori";
                select_count_temp += 1;
            }
            if (cs.ayane == true)
            {
                temp[select_count_temp] = "아야네";
                temp_eng[select_count_temp] = "ayane";
                select_count_temp += 1;
            }
            if (cs.suzume == true)
            {
                temp[select_count_temp] = "스즈메";
                temp_eng[select_count_temp] = "suzume";
                select_count_temp += 1;
            }
            if (cs.rin == true)
            {
                temp[select_count_temp] = "린";
                temp_eng[select_count_temp] = "rin";
                select_count_temp += 1;
            }
            if (cs.eriko == true)
            {
                temp[select_count_temp] = "에리코";
                temp_eng[select_count_temp] = "eriko";
                select_count_temp += 1;
            }
            if (cs.saren == true)
            {
                temp[select_count_temp] = "사렌";
                temp_eng[select_count_temp] = "saren";
                select_count_temp += 1;
            }
            if (cs.nozomi == true)
            {
                temp[select_count_temp] = "노조미";
                temp_eng[select_count_temp] = "nozomi";
                select_count_temp += 1;
            }
            if (cs.ninon == true)
            {
                temp[select_count_temp] = "니논";
                temp_eng[select_count_temp] = "ninon";
                select_count_temp += 1;
            }
            if (cs.sinobu == true)
            {
                temp[select_count_temp] = "시노부";
                temp_eng[select_count_temp] = "sinobu";
                select_count_temp += 1;
            }
            if (cs.akino == true)
            {
                temp[select_count_temp] = "아키노";
                temp_eng[select_count_temp] = "akino";
                select_count_temp += 1;
            }
            if (cs.mahiru == true)
            {
                temp[select_count_temp] = "마히루";
                temp_eng[select_count_temp] = "mahiru";
                select_count_temp += 1;
            }
            if (cs.yukari == true)
            {
                temp[select_count_temp] = "유카리";
                temp_eng[select_count_temp] = "yukari";
                select_count_temp += 1;
            }
            if (cs.kyouka == true)
            {
                temp[select_count_temp] = "쿄우카";
                temp_eng[select_count_temp] = "kyouka";
                select_count_temp += 1;
            }
            if (cs.tomo == true)
            {
                temp[select_count_temp] = "토모";
                temp_eng[select_count_temp] = "tomo";
                select_count_temp += 1;
            }
            if (cs.siori == true)
            {
                temp[select_count_temp] = "시오리";
                temp_eng[select_count_temp] = "siori";
                select_count_temp += 1;
            }
            if (cs.aoi == true)
            {
                temp[select_count_temp] = "아오이";
                temp_eng[select_count_temp] = "aoi";
                select_count_temp += 1;
            }
            if (cs.chika == true)
            {
                temp[select_count_temp] = "치카";
                temp_eng[select_count_temp] = "chika";
                select_count_temp += 1;
            }
            if (cs.makoto == true)
            {
                temp[select_count_temp] = "마코토";
                temp_eng[select_count_temp] = "makoto";
                select_count_temp += 1;
            }
            if (cs.iriya == true)
            {
                temp[select_count_temp] = "이리야";
                temp_eng[select_count_temp] = "iriya";
                select_count_temp += 1;
            }
            if (cs.kuuka == true)
            {
                temp[select_count_temp] = "쿠우카";
                temp_eng[select_count_temp] = "kuuka";
                select_count_temp += 1;
            }
            if (cs.tamaki == true)
            {
                temp[select_count_temp] = "타마키";
                temp_eng[select_count_temp] = "tamaki";
                select_count_temp += 1;
            }
            if (cs.zyun == true)
            {
                temp[select_count_temp] = "쥰";
                temp_eng[select_count_temp] = "zyun";
                select_count_temp += 1;
            }
            if (cs.mihuyu == true)
            {
                temp[select_count_temp] = "미후유";
                temp_eng[select_count_temp] = "mihuyu";
                select_count_temp += 1;
            }
            if (cs.sizuru == true)
            {
                temp[select_count_temp] = "시즈루";
                temp_eng[select_count_temp] = "sizuru";
                select_count_temp += 1;
            }
            if (cs.misaki == true)
            {
                temp[select_count_temp] = "미사키";
                temp_eng[select_count_temp] = "misaki";
                select_count_temp += 1;
            }
            if (cs.mitsuki == true)
            {
                temp[select_count_temp] = "미츠키";
                temp_eng[select_count_temp] = "mitsuki";
                select_count_temp += 1;
            }
            if (cs.rima == true)
            {
                temp[select_count_temp] = "리마";
                temp_eng[select_count_temp] = "rima";
                select_count_temp += 1;
            }
            if (cs.monika == true)
            {
                temp[select_count_temp] = "모니카";
                temp_eng[select_count_temp] = "monika";
                select_count_temp += 1;
            }
            if (cs.tsumugi == true)
            {
                temp[select_count_temp] = "츠무기";
                temp_eng[select_count_temp] = "tsumugi";
                select_count_temp += 1;
            }
            if (cs.ayumi == true)
            {
                temp[select_count_temp] = "아유미";
                temp_eng[select_count_temp] = "ayumi";
                select_count_temp += 1;
            }
            if (cs.ruka == true)
            {
                temp[select_count_temp] = "루카";
                temp_eng[select_count_temp] = "ruka";
                select_count_temp += 1;
            }
            if (cs.zita == true)
            {
                temp[select_count_temp] = "지타";
                temp_eng[select_count_temp] = "zita";
                select_count_temp += 1;
            }
            if (cs.pekorinnu == true)
            {
                temp[select_count_temp] = "페코린느";
                temp_eng[select_count_temp] = "pekorinnu";
                select_count_temp += 1;
            }
            if (cs.kotkoro == true)
            {
                temp[select_count_temp] = "콧코로";
                temp_eng[select_count_temp] = "kotkoro";
                select_count_temp += 1;
            }
            if (cs.kyaru == true)
            {
                temp[select_count_temp] = "캬루";
                temp_eng[select_count_temp] = "kyaru";
                select_count_temp += 1;
            }
            if (cs.muimi == true)
            {
                temp[select_count_temp] = "무이미";
                temp_eng[select_count_temp] = "muimi";
                select_count_temp += 1;
            }
            if (cs.arisa == true)
            {
                temp[select_count_temp] = "아리사";
                temp_eng[select_count_temp] = "arisa";
                select_count_temp += 1;
            }
            if (cs.kaya == true)
            {
                temp[select_count_temp] = "카야";
                temp_eng[select_count_temp] = "kaya";
                select_count_temp += 1;
            }
            if (cs.neneka == true)
            {
                temp[select_count_temp] = "네네카";
                temp_eng[select_count_temp] = "neneka";
                select_count_temp += 1;
            }
            if (cs.kristina == true)
            {
                temp[select_count_temp] = "크리스티나";
                temp_eng[select_count_temp] = "kristina";
                select_count_temp += 1;
            }
            if (cs.pekorinnu_summer == true)
            {
                temp[select_count_temp] = "수페코";
                temp_eng[select_count_temp] = "pekorinnu_summer";
                select_count_temp += 1;
            }
            if (cs.kotkoro_summer == true)
            {
                temp[select_count_temp] = "수코로";
                temp_eng[select_count_temp] = "kotkoro_summer";
                select_count_temp += 1;
            }
            if (cs.suzume_summer == true)
            {
                temp[select_count_temp] = "수즈메";
                temp_eng[select_count_temp] = "suzume_summer";
                select_count_temp += 1;
            }
            if (cs.kyaru_summer == true)
            {
                temp[select_count_temp] = "수캬루";
                temp_eng[select_count_temp] = "kyaru_summer";
                select_count_temp += 1;
            }
            if (cs.tamaki_summer == true)
            {
                temp[select_count_temp] = "수마키";
                temp_eng[select_count_temp] = "tamaki_summer";
                select_count_temp += 1;
            }
            if (cs.mihuyu_summer == true)
            {
                temp[select_count_temp] = "수후유";
                temp_eng[select_count_temp] = "mihuyu_summer";
                select_count_temp += 1;
            }
            if (cs.sinobu_halloween == true)
            {
                temp[select_count_temp] = "할노부";
                temp_eng[select_count_temp] = "sinobu_halloween";
                select_count_temp += 1;
            }
            if (cs.miyako_halloween == true)
            {
                temp[select_count_temp] = "할푸딩";
                temp_eng[select_count_temp] = "miyako_halloween";
                select_count_temp += 1;
            }
            if (cs.misaki_halloween == true)
            {
                temp[select_count_temp] = "할사키";
                temp_eng[select_count_temp] = "misaki_halloween";
                select_count_temp += 1;
            }
            if (cs.chika_christmas == true)
            {
                temp[select_count_temp] = "성치카";
                temp_eng[select_count_temp] = "chika_christmas";
                select_count_temp += 1;
            }
            if (cs.kurumi_christmas == true)
            {
                temp[select_count_temp] = "성루미";
                temp_eng[select_count_temp] = "kurumi_christmas";
                select_count_temp += 1;
            }
            if (cs.ayane_christmas == true)
            {
                temp[select_count_temp] = "성야네";
                temp_eng[select_count_temp] = "ayane_christmas";
                select_count_temp += 1;
            }
            if (cs.hiyori_newyear == true)
            {
                temp[select_count_temp] = "뉴요리";
                temp_eng[select_count_temp] = "hiyori_newyear";
                select_count_temp += 1;
            }
            if (cs.yui_newyear == true)
            {
                temp[select_count_temp] = "뉴이";
                temp_eng[select_count_temp] = "yui_newyear";
                select_count_temp += 1;
            }
            if (cs.rei_newyear == true)
            {
                temp[select_count_temp] = "신레이";
                temp_eng[select_count_temp] = "rei_newyear";
                select_count_temp += 1;
            }
            if (cs.eriko_valentine == true)
            {
                temp[select_count_temp] = "발리코";
                temp_eng[select_count_temp] = "eriko_valentine";
                select_count_temp += 1;
            }
            if (cs.sizuru_valentine == true)
            {
                temp[select_count_temp] = "발즈루";
                temp_eng[select_count_temp] = "sizuru_valentine";
                select_count_temp += 1;
            }
            if (cs.anne == true)
            {
                temp[select_count_temp] = "앤";
                temp_eng[select_count_temp] = "anne";
                select_count_temp += 1;
            }
            if (cs.lou == true)
            {
                temp[select_count_temp] = "루";
                temp_eng[select_count_temp] = "lou";
                select_count_temp += 1;
            }
            if (cs.grea == true)
            {
                temp[select_count_temp] = "글레어";
                temp_eng[select_count_temp] = "grea";
                select_count_temp += 1;
            }
            if (cs.kuuka_ooedo == true)
            {
                temp[select_count_temp] = "오우카";
                temp_eng[select_count_temp] = "kuuka_ooedo";
                select_count_temp += 1;
            }
            if (cs.ninon_ooedo == true)
            {
                temp[select_count_temp] = "오니논";
                temp_eng[select_count_temp] = "ninon_ooedo";
                select_count_temp += 1;
            }
            if (cs.rem == true)
            {
                temp[select_count_temp] = "렘";
                temp_eng[select_count_temp] = "rem";
                select_count_temp += 1;
            }
            if (cs.ram == true)
            {
                temp[select_count_temp] = "람";
                temp_eng[select_count_temp] = "ram";
                select_count_temp += 1;
            }
            if (cs.emilia == true)
            {
                temp[select_count_temp] = "에밀리아";
                temp_eng[select_count_temp] = "emilia";
                select_count_temp += 1;
            }
            if (cs.suzuna_summer == true)
            {
                temp[select_count_temp] = "수즈나";
                temp_eng[select_count_temp] = "suzuna_summer";
                select_count_temp += 1;
            }
            if (cs.io_summer == true)
            {
                temp[select_count_temp] = "수이오";
                temp_eng[select_count_temp] = "io_summer";
                select_count_temp += 1;
            }
            if (cs.saren_summer == true)
            {
                temp[select_count_temp] = "수사렌";
                temp_eng[select_count_temp] = "saren_summer";
                select_count_temp += 1;
            }
            if (cs.makoto_summer == true)
            {
                temp[select_count_temp] = "수코토";
                temp_eng[select_count_temp] = "makoto_summer";
                select_count_temp += 1;
            }
            if (cs.kaori_summer == true)
            {
                temp[select_count_temp] = "수오리";
                temp_eng[select_count_temp] = "kaori_summer";
                select_count_temp += 1;
            }
            if (cs.maho_summer == true)
            {
                temp[select_count_temp] = "수마호";
                temp_eng[select_count_temp] = "maho_summer";
                select_count_temp += 1;
            }
            if (cs.aoi_nakayosi == true)
            {
                temp[select_count_temp] = "편오이";
                temp_eng[select_count_temp] = "aoi_nakayosi";
                select_count_temp += 1;
            }
            if (cs.chloe == true)
            {
                temp[select_count_temp] = "클로에";
                temp_eng[select_count_temp] = "chloe";
                select_count_temp += 1;
            }
            if (cs.chieru == true)
            {
                temp[select_count_temp] = "치에루";
                temp_eng[select_count_temp] = "chieru";
                select_count_temp += 1;
            }
            if (cs.kyouka_halloween == true)
            {
                temp[select_count_temp] = "할쿄카";
                temp_eng[select_count_temp] = "kyouka_halloween";
                select_count_temp += 1;
            }
            if (cs.misogi_halloween == true)
            {
                temp[select_count_temp] = "할소기";
                temp_eng[select_count_temp] = "misogi_halloween";
                select_count_temp += 1;
            }
            if (cs.mimi_halloween == true)
            {
                temp[select_count_temp] = "할미미";
                temp_eng[select_count_temp] = "mimi_halloween";
                select_count_temp += 1;
            }
            if (cs.runa == true)
            {
                temp[select_count_temp] = "루나";
                temp_eng[select_count_temp] = "runa";
                select_count_temp += 1;
            }
            if (cs.kristina_christmas == true)
            {
                temp[select_count_temp] = "성리스";
                temp_eng[select_count_temp] = "kristina_christmas";
                select_count_temp += 1;

            }
            if (cs.nozomi_christmas == true)
            {
                temp[select_count_temp] = "성조미";
                temp_eng[select_count_temp] = "nozomi_christmas";
                select_count_temp += 1;
            }
            if (cs.iriya_christmas == true)
            {
                temp[select_count_temp] = "성리야";
                temp_eng[select_count_temp] = "iriya_christmas";
                select_count_temp += 1;

            }
            if (cs.kotkoro_newyear == true)
            {
                temp[select_count_temp] = "뉴코로";
                temp_eng[select_count_temp] = "kotkoro_newyear";
                select_count_temp += 1;
            }
            if (cs.kyaru_newyear == true)
            {
                temp[select_count_temp] = "냐루";
                temp_eng[select_count_temp] = "kyaru_newyear";
                select_count_temp += 1;
            }
            if (cs.suzume_newyear == true)
            {
                temp[select_count_temp] = "뉴즈메";
                temp_eng[select_count_temp] = "suzume_newyear";
                select_count_temp += 1;

            }
            if (cs.kasumi_magical == true)
            {
                temp[select_count_temp] = "마스미";
                temp_eng[select_count_temp] = "kasumi_magical";
                select_count_temp += 1;

            }
            if (cs.siori_magical == true)
            {
                temp[select_count_temp] = "마오리";
                temp_eng[select_count_temp] = "siori_magical";
                select_count_temp += 1;

            }
            if (cs.uzuki_deremas == true)
            {
                temp[select_count_temp] = "우즈키";
                temp_eng[select_count_temp] = "uzuki_deremas";
                select_count_temp += 1;
            }
            if (cs.mio_deremas == true)
            {
                temp[select_count_temp] = "미오";
                temp_eng[select_count_temp] = "mio_deremas";
                select_count_temp += 1;
            }
            if (cs.rin_deremas == true)
            {
                temp[select_count_temp] = "시부린";
                temp_eng[select_count_temp] = "rin_deremas";
                select_count_temp += 1;
            }
            if (cs.rin_ranger == true)
            {
                temp[select_count_temp] = "레린";
                temp_eng[select_count_temp] = "rin_ranger";
                select_count_temp += 1;
            }
            if (cs.mahiru_ranger == true)
            {
                temp[select_count_temp] = "레히루";
                temp_eng[select_count_temp] = "mahiru_ranger";
                select_count_temp += 1;
            }
            if (cs.rino_wonder == true)
            {
                temp[select_count_temp] = "앨리노";
                temp_eng[select_count_temp] = "rino_wonder";
                select_count_temp += 1;
            }
            if (cs.ayumi_wonder == true)
            {
                temp[select_count_temp] = "앨유미";
                temp_eng[select_count_temp] = "ayumi_wonder";
                select_count_temp += 1;
            }
            if (cs.ruka_summer == true)
            {
                temp[select_count_temp] = "수루카";
                temp_eng[select_count_temp] = "ruka_summer";
                select_count_temp += 1;
            }
            if (cs.anna_summer == true)
            {
                temp[select_count_temp] = "수안나";
                temp_eng[select_count_temp] = "anna_summer";
                select_count_temp += 1;
            }
            if (cs.hatsune_summer == true)
            {
                temp[select_count_temp] = "수츠네";
                temp_eng[select_count_temp] = "hatsune_summer";
                select_count_temp += 1;
            }
            if (cs.nanaka_summer == true)
            {
                temp[select_count_temp] = "수나카";
                temp_eng[select_count_temp] = "nanaka_summer";
                select_count_temp += 1;
            }
            if (cs.misato_summer == true)
            {
                temp[select_count_temp] = "수사토";
                temp_eng[select_count_temp] = "misato_summer";
                select_count_temp += 1;
            }
            if (cs.zyun_summer == true)
            {
                temp[select_count_temp] = "수쥰";
                temp_eng[select_count_temp] = "zyun_summer";
                select_count_temp += 1;
            }
            if (cs.akari_angel == true)
            {
                temp[select_count_temp] = "엔카리";
                temp_eng[select_count_temp] = "akari_angel";
                select_count_temp += 1;
            }
            if (cs.yori_angel == true)
            {
                temp[select_count_temp] = "엔요리";
                temp_eng[select_count_temp] = "yori_angel";
                select_count_temp += 1;
            }
            if (cs.tsumugi_halloween == true)
            {
                temp[select_count_temp] = "할무기";
                temp_eng[select_count_temp] = "tsumugi_halloween";
                select_count_temp += 1;
            }
            if (cs.rei_halloween == true)
            {
                temp[select_count_temp] = "할레이";
                temp_eng[select_count_temp] = "rei_halloween";
                select_count_temp += 1;
            }
            if (cs.matsuri_halloween == true)
            {
                temp[select_count_temp] = "할츠리";
                temp_eng[select_count_temp] = "matsuri_halloween";
                select_count_temp += 1;
            }
           
            if (cs.monika_magical == true)
            {
                temp[select_count_temp] = "마니카";
                temp_eng[select_count_temp] = "monika_magical";
                select_count_temp += 1;
            }
            if (cs.tomo_magical == true)
            {
                temp[select_count_temp] = "마토모";
                temp_eng[select_count_temp] = "tomo_magical";
                select_count_temp += 1;
            }
            if (cs.akino_christmas == true)
            {
                temp[select_count_temp] = "성키노";
                temp_eng[select_count_temp] = "akino_christmas";
                select_count_temp += 1;
            }
            if (cs.saren_christmas == true)
            {
                temp[select_count_temp] = "성사렌";
                temp_eng[select_count_temp] = "saren_christmas";
                select_count_temp += 1;
            } 
            if (cs.yukari_christmas == true)
            {
                temp[select_count_temp] = "성카리";
                temp_eng[select_count_temp] = "yukari_christmas";
                select_count_temp += 1;
            }
            
            if (cs.pekorinnu_newyear == true)
            {
                temp[select_count_temp] = "뉴페코";
                temp_eng[select_count_temp] = "pekorinnu_newyear";
                select_count_temp += 1;
            }
            if (cs.muimi_newyear == true)
            {
                temp[select_count_temp] = "뉴이미";
                temp_eng[select_count_temp] = "muimi_newyear";
                select_count_temp += 1;
            }
            if (cs.neneka_newyear == true)
            {
                temp[select_count_temp] = "뉴네카";
                temp_eng[select_count_temp] = "neneka_newyear";
                select_count_temp += 1;
            }
           
            if (cs.kotkoro_maiden == true)
            {
                temp[select_count_temp] = "의코로";
                temp_eng[select_count_temp] = "kotkoro_maiden";
                select_count_temp += 1;
            }
            if (cs.yui_maiden == true)
            {
                temp[select_count_temp] = "의유이";
                temp_eng[select_count_temp] = "yui_maiden";
                select_count_temp += 1;
            } 
            /*
            if (cs.kasumi_summer == true)
            {
                temp[select_count_temp] = "수스미";
                temp_eng[select_count_temp] = "kasumi_summer";
                select_count_temp += 1;
            }
            if (cs.rima_cinderella == true)
            {
                temp[select_count_temp] = "신리마";
                temp_eng[select_count_temp] = "rima_cinderella";
                select_count_temp += 1;
            }
            if (cs.makoto_cinderella == true)
            {
                temp[select_count_temp] = "신코토";
                temp_eng[select_count_temp] = "makoto_cinderella";
                select_count_temp += 1;
            }
            if (cs.maho_cinderella == true)
            {
                temp[select_count_temp] = "신마호";
                temp_eng[select_count_temp] = "maho_cinderella";
                select_count_temp += 1;
            }
            if (cs.chloe_nakayosi2 == true)
            {
                temp[select_count_temp] = "성로에";
                temp_eng[select_count_temp] = "chloe_nakayosi2";
                select_count_temp += 1;
            }
            if (cs.chieru_nakayosi2 == true)
            {
                temp[select_count_temp] = "성에루";
                temp_eng[select_count_temp] = "chieru_nakayosi2";
                select_count_temp += 1;
            }
            if (cs.inori_timetravel == true)
            {
                temp[select_count_temp] = "시노리";
                temp_eng[select_count_temp] = "inori_timetravel";
                select_count_temp += 1;
            }
            if (cs.kaya_timetravel == true)
            {
                temp[select_count_temp] = "시카야";
                temp_eng[select_count_temp] = "kaya_timetravel";
                select_count_temp += 1;
            }
            if (cs.aoi_worker == true)
            {
                temp[select_count_temp] = "작오이";
                temp_eng[select_count_temp] = "aoi_worker";
                select_count_temp += 1;
            }
            if (cs.tamaki_worker == true)
            {
                temp[select_count_temp] = "작마키";
                temp_eng[select_count_temp] = "tamaki_worker";
                select_count_temp += 1;
            }
            if (cs.rei_princess == true)
            {
                temp[select_count_temp] = "프레이";
                temp_eng[select_count_temp] = "rei_princess";
                select_count_temp += 1;
            }
            
            if (cs.kyaru_princess == true)
            {
                temp[select_count_temp] = "프캬루";
                temp_eng[select_count_temp] = "kyaru_princess";
                select_count_temp += 1;
            }
            */
            if (cs.hiyori_princess == true)
            {
                temp[select_count_temp] = "프요리";
                temp_eng[select_count_temp] = "hiyori_princess";
                select_count_temp += 1;
            }
            if (cs.pekorinnu_princess == true)
            {
                temp[select_count_temp] = "프페코";
                temp_eng[select_count_temp] = "pekorinnu_princess";
                select_count_temp += 1;
            }
            if (cs.kotkoro_princess == true)
            {
                temp[select_count_temp] = "프코로";
                temp_eng[select_count_temp] = "kotkoro_princess";
                select_count_temp += 1;
            }
            if (cs.yui_princess == true)
            {
                temp[select_count_temp] = "프유이";
                temp_eng[select_count_temp] = "yui_princess";
                select_count_temp += 1;
            }
            if (cs.inori == true)
            {
                temp[select_count_temp] = "이노리";
                temp_eng[select_count_temp] = "inori";
                select_count_temp += 1;
            }
            if (cs.yuni == true)
            {
                temp[select_count_temp] = "유니";
                temp_eng[select_count_temp] = "yuni";
                select_count_temp += 1;
            }
            if (cs.labyrista == true)
            {
                temp[select_count_temp] = "라비리스타";
                temp_eng[select_count_temp] = "labyrista";
                select_count_temp += 1;
            }
            #endregion
            //isOfforDef == 1 방덱 , 0이면 공덱
            if (isOfforDef == 0)
            {
                select_offence_temp = temp;
                select_offence_temp_eng = temp_eng;
            }
            else if (isOfforDef == 1)
            {
                select_defence_temp = temp;
                select_defence_temp_eng = temp_eng;
            }

            else
                MessageBox.Show("?", "알림");
        }

        #endregion
        // 
        // 캐릭터 설정 탭

        #region CharaSetting

        private void bt_open_defDeck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad.exe", "character_defence.txt");
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee);
                MessageBox.Show("character_defence.txt 파일이 없어!", "알림");
            }
        }

        private void bt_open_offDeck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad.exe", "character_offence.txt");
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee);
                MessageBox.Show("character_offence.txt 파일이 없어!", "알림");
            }
        }

        public static decimal maxLevel = 184;
        public static decimal maxRank = 19;
        public static decimal maxItemQuantity = 4;
        
        public static decimal maxUnique = (int)(( Math.Floor(maxLevel/10) +1)*10);

        public void InitialMaxText()
        {
            tb_MaxLevel.Text = Convert.ToString(maxLevel);
            tb_MaxRank.Text = Convert.ToString(maxRank) ;
            tb_MaxItemQuqn.Text = Convert.ToString(maxItemQuantity) ;
            tb_MaxUnique.Text = Convert.ToString(maxUnique);
        }
        private void bt_DefAutoReinUniqueEquip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_defence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[5] = Convert.ToString(maxUnique);

                    stringArray[row] = StringArrayToCommaString(temp);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_defence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show("방덱의 전용장비를 " + Convert.ToString(maxUnique) + "레벨로 자동강화 성공!", "알림");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DefAutoReinItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_defence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[4] = Convert.ToString(maxRank);
                    for (int xx = 0; xx < maxItemQuantity; xx++)
                    {
                        temp[6 + xx] = "5";
                    }
                    stringArray[row] = StringArrayToCommaString(temp);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_defence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show("방덱을 " + Convert.ToString(maxRank) + "랭크 " + Convert.ToString(maxItemQuantity) + "템으로 자동강화 성공!", "알림");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DefAutoReinLevel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_defence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[3] = Convert.ToString(maxLevel);
                    Debug.Write(temp[0]);
                    Debug.Write(temp[1]);
                    Debug.Write(temp[2]);
                    Debug.WriteLine(temp[3]);
                    stringArray[row] = StringArrayToCommaString(temp);
                    Debug.WriteLine(stringArray[row]);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_defence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show("방덱을 " + Convert.ToString(maxLevel) + "레벨로 자동강화 성공!", "알림");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_OffAutoReinUniqueEquip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_offence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[5] = Convert.ToString(maxUnique);
                    
                    stringArray[row] = StringArrayToCommaString(temp);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_offence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show("공덱의 전용장비를 " + Convert.ToString(maxUnique) +  "레벨로 자동강화 성공!", "알림");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_OffAutoReinItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_offence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[4] = Convert.ToString(maxRank);
                    for(int xx=0;xx< maxItemQuantity; xx++)
                    {
                        temp[6 + xx] = "5";
                    }
                    stringArray[row] = StringArrayToCommaString(temp);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_offence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show("공덱을 " + Convert.ToString(maxRank) + "랭크 " + Convert.ToString(maxItemQuantity)+"템으로 자동강화 성공!", "알림");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_OffAutoReinLevel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("character_offence.txt");
                int row = 1;
                string[] stringArray = new string[400];
                stringArray[0] = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄

                    temp[3] = Convert.ToString(maxLevel);
                    Debug.Write(temp[0]);
                    Debug.Write(temp[1]);
                    Debug.Write(temp[2]);
                    Debug.WriteLine(temp[3]);
                    stringArray[row] = StringArrayToCommaString(temp);
                    Debug.WriteLine(stringArray[row]);
                    row++;

                }
                sr.Close();

                StreamWriter sw = new StreamWriter("character_offence.txt");
                int i = 0;
                while (stringArray[i] != null)
                {
                    Debug.WriteLine(i);
                    sw.WriteLine(stringArray[i]);
                    Debug.WriteLine(stringArray[i]);
                    i++;
                }
                sw.Close();

                MessageBox.Show( "공덱을 " + Convert.ToString(maxLevel) + "레벨로 자동강화 성공!","알림");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string StringArrayToCommaString(string[] temp)
        {
            string result="";
            Debug.WriteLine("x = " + temp.Length);
            for (int i = 0; i < temp.Length; i++)
            {
                result = result + temp[i] + ",";
            }
            Debug.WriteLine("result = " + result); ;
            return result.Remove(result.Length -1);
        }
        #region SetClick
        private void bt_rima_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rima = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_miyako_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.miyako = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kuuka_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kuuka = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_zyun_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.zyun = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kuuka_ooedo_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kuuka_ooedo = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kaori_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kaori = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rei_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rei_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_pekorinnu_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.pekorinnu = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_pekorinnu_princess_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.pekorinnu_princess = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ruka_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ruka = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kotkoro_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kotkoro_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_nozomi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.nozomi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_muimi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.muimi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_makoto_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.makoto = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kaya_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kaya = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_inori_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.inori = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_hiyori_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.hiyori_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ninon_ooedo_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ninon_ooedo = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_akino_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.akino = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_makoto_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.makoto_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_matsuri_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.matsuri = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_chloe_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.chloe = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_chieru_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.chieru = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_eriko_valentine_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.eriko_valentine = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ayane_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ayane_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tsumugi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tsumugi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_hiyori_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.hiyori = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misogi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misogi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ayane_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ayane = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misogi_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misogi_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tamaki_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tamaki = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tomo_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tomo = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tamaki_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tamaki = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_eriko_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.eriko = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_pekorinnu_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.pekorinnu_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kurumi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kurumi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_zita_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.zita = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rei_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rei = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_iriya_christmas_set_Click(object sender, RoutedEventArgs e)
        {            
            Chara_set.iriya_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kristina_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kristina_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_sizuru_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.sizuru = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kristina_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kristina = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kurumi_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kurumi_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mimi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mimi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_sinobu_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.sinobu = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mimi_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mimi_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_sizuru_valentine_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.sizuru_valentine = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mahiru_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mahiru = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yukari_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yukari = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_monika_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.monika = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ninon_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ninon = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_nozomi_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.nozomi_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mihuyu_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mihuyu = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_iriya_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.iriya = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kaori_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kaori_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_saren_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.saren = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_anna_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.anna = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_sinobu_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.sinobu_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mihuyu_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mihuyu_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kotkoro_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kotkoro = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ayumi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ayumi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_grea_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.grea = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kotkoro_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kotkoro_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rem_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rem = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ram_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ram = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rin_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rin = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mitsuki_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mitsuki = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_akari_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.akari = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yori_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yori = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_saren_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.saren_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_miyako_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.miyako_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_arisa_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.arisa = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_anne_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.anne = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_lou_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.lou = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_neneka_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.neneka = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_aoi_nakayosi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.aoi_nakayosi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kyaru_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kyaru_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rino_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rino = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_suzuna_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.suzuna = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_suzuna_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.suzuna_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_siori_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.siori = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_siori_magical_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.siori_magical = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_io_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.io = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_io_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.io_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_suzume_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.suzume = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_suzume_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.suzume_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_emilia_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.emilia = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kasumi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kasumi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kasumi_magical_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kasumi_magical = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misato_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misato = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_nanaka_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.nanaka = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yui_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yui_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kyaru_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kyaru = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_hatsune_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.hatsune = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misaki_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misaki = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_runa_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.runa = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_chika_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.chika_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_suzume_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.suzume_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kyaru_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kyaru_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_aoi_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.aoi = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_chika_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.chika = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_maho_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.maho_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_maho_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.maho = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yui_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yui = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yuki_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yuki = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kyouka_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kyouka = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misaki_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misaki_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kyouka_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kyouka_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }

        private void bt_uzuki_deremas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.uzuki_deremas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mio_deremas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mio_deremas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rin_deremas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rin_deremas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rin_ranger_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rin_ranger = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_mahiru_ranger_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.mahiru_ranger = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rino_wonder_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rino_wonder = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ayumi_wonder_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ayumi_wonder = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_ruka_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.ruka_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_anna_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.anna_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_nanaka_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.nanaka_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_hatsune_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.hatsune_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_misato_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.misato_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_zyun_summer_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.zyun_summer = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_akari_angel_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.akari_angel = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yori_angel_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yori_angel = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_kotkoro_princess_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.kotkoro_princess = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yui_princess_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yui_princess = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yuni_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yuni = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_labyrista_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.labyrista = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tsumugi_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tsumugi_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_rei_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.rei_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_matsuri_halloween_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.matsuri_halloween = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_tomo_magical_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.tomo_magical = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_monika_magical_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.monika_magical = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_saren_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.saren_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_akino_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.akino_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_yukari_christmas_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.yukari_christmas = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_hiyori_princess_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.hiyori_princess = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_pekorinnu_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.pekorinnu_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_neneka_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.neneka_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }
        private void bt_muimi_newyear_set_Click(object sender, RoutedEventArgs e)
        {
            Chara_set.muimi_newyear = true;
            Chara_set C_S = new Chara_set(); C_S.ShowDialog();
        }

        //캐릭터 설정 뉴이미까지

        #endregion



        #endregion

        //
        // 캐릭터 사용 탭
        //

        /*
        #region Availablity

        #region Enabled

        int SomeMeaninglessVariable = 0;
        public void tb_enable_hiyori_Checked(object sender, RoutedEventArgs args) { cs.hiyori_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_hiyori_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori_enable = false; }
        public void tb_enable_rei_Checked(object sender, RoutedEventArgs args) { cs.rei_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rei_UnChecked(object sender, RoutedEventArgs args) { cs.rei_enable = false; }
        public void tb_enable_yui_Checked(object sender, RoutedEventArgs args) { cs.yui_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yui_UnChecked(object sender, RoutedEventArgs args) { cs.yui_enable = false; }
        public void tb_enable_misogi_Checked(object sender, RoutedEventArgs args) { cs.misogi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misogi_UnChecked(object sender, RoutedEventArgs args) { cs.misogi_enable = false; }

        public void tb_enable_matsuri_Checked(object sender, RoutedEventArgs args) { cs.matsuri_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_matsuri_UnChecked(object sender, RoutedEventArgs args) { cs.matsuri_enable = false; }

        public void tb_enable_akari_Checked(object sender, RoutedEventArgs args) { cs.akari_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_akari_UnChecked(object sender, RoutedEventArgs args) { cs.akari_enable = false; }

        public void tb_enable_miyako_Checked(object sender, RoutedEventArgs args) { cs.miyako_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_miyako_UnChecked(object sender, RoutedEventArgs args) { cs.miyako_enable = false; }

        public void tb_enable_yuki_Checked(object sender, RoutedEventArgs args) { cs.yuki_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yuki_UnChecked(object sender, RoutedEventArgs args) { cs.yuki_enable = false; }

        public void tb_enable_anna_Checked(object sender, RoutedEventArgs args) { cs.anna_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_anna_UnChecked(object sender, RoutedEventArgs args) { cs.anna_enable = false; }
        public void tb_enable_maho_Checked(object sender, RoutedEventArgs args) { cs.maho_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_maho_UnChecked(object sender, RoutedEventArgs args) { cs.maho_enable = false; }
        public void tb_enable_rino_Checked(object sender, RoutedEventArgs args) { cs.rino_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rino_UnChecked(object sender, RoutedEventArgs args) { cs.rino_enable = false; }
        public void tb_enable_hatsune_Checked(object sender, RoutedEventArgs args) { cs.hatsune_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_hatsune_UnChecked(object sender, RoutedEventArgs args) { cs.hatsune_enable = false; }
        public void tb_enable_nanaka_Checked(object sender, RoutedEventArgs args) { cs.nanaka_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_nanaka_UnChecked(object sender, RoutedEventArgs args) { cs.nanaka_enable = false; }
        public void tb_enable_kasumi_Checked(object sender, RoutedEventArgs args) { cs.kasumi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kasumi_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi_enable = false; }
        public void tb_enable_misato_Checked(object sender, RoutedEventArgs args) { cs.misato_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misato_UnChecked(object sender, RoutedEventArgs args) { cs.misato_enable = false; }
        public void tb_enable_suzuna_Checked(object sender, RoutedEventArgs args) { cs.suzuna_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_suzuna_UnChecked(object sender, RoutedEventArgs args) { cs.suzuna_enable = false; }
        public void tb_enable_kaori_Checked(object sender, RoutedEventArgs args) { cs.kaori_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kaori_UnChecked(object sender, RoutedEventArgs args) { cs.kaori_enable = false; }
        public void tb_enable_io_Checked(object sender, RoutedEventArgs args) { cs.io_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_io_UnChecked(object sender, RoutedEventArgs args) { cs.io_enable = false; }
        public void tb_enable_mimi_Checked(object sender, RoutedEventArgs args) { cs.mimi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mimi_UnChecked(object sender, RoutedEventArgs args) { cs.mimi_enable = false; }
        public void tb_enable_kurumi_Checked(object sender, RoutedEventArgs args) { cs.kurumi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kurumi_UnChecked(object sender, RoutedEventArgs args) { cs.kurumi_enable = false; }
        public void tb_enable_yori_Checked(object sender, RoutedEventArgs args) { cs.yori_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yori_UnChecked(object sender, RoutedEventArgs args) { cs.yori_enable = false; }
        public void tb_enable_ayane_Checked(object sender, RoutedEventArgs args) { cs.ayane_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ayane_UnChecked(object sender, RoutedEventArgs args) { cs.ayane_enable = false; }
        public void tb_enable_suzume_Checked(object sender, RoutedEventArgs args) { cs.suzume_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_suzume_UnChecked(object sender, RoutedEventArgs args) { cs.suzume_enable = false; }
        public void tb_enable_rin_Checked(object sender, RoutedEventArgs args) { cs.rin_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rin_UnChecked(object sender, RoutedEventArgs args) { cs.rin_enable = false; }
        public void tb_enable_eriko_Checked(object sender, RoutedEventArgs args) { cs.eriko_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_eriko_UnChecked(object sender, RoutedEventArgs args) { cs.eriko_enable = false; }
        public void tb_enable_saren_Checked(object sender, RoutedEventArgs args) { cs.saren_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_saren_UnChecked(object sender, RoutedEventArgs args) { cs.saren_enable = false; }
        public void tb_enable_nozomi_Checked(object sender, RoutedEventArgs args) { cs.nozomi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_nozomi_UnChecked(object sender, RoutedEventArgs args) { cs.nozomi_enable = false; }
        public void tb_enable_ninon_Checked(object sender, RoutedEventArgs args) { cs.ninon_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ninon_UnChecked(object sender, RoutedEventArgs args) { cs.ninon_enable = false; }
        public void tb_enable_sinobu_Checked(object sender, RoutedEventArgs args) { cs.sinobu_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_sinobu_UnChecked(object sender, RoutedEventArgs args) { cs.sinobu_enable = false; }
        public void tb_enable_akino_Checked(object sender, RoutedEventArgs args) { cs.akino_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_akino_UnChecked(object sender, RoutedEventArgs args) { cs.akino_enable = false; }
        public void tb_enable_mahiru_Checked(object sender, RoutedEventArgs args) { cs.mahiru_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mahiru_UnChecked(object sender, RoutedEventArgs args) { cs.mahiru_enable = false; }
        public void tb_enable_yukari_Checked(object sender, RoutedEventArgs args) { cs.yukari_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yukari_UnChecked(object sender, RoutedEventArgs args) { cs.yukari_enable = false; }
        public void tb_enable_kyouka_Checked(object sender, RoutedEventArgs args) { cs.kyouka_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kyouka_UnChecked(object sender, RoutedEventArgs args) { cs.kyouka_enable = false; }
        public void tb_enable_tomo_Checked(object sender, RoutedEventArgs args) { cs.tomo_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_tomo_UnChecked(object sender, RoutedEventArgs args) { cs.tomo_enable = false; }
        public void tb_enable_siori_Checked(object sender, RoutedEventArgs args) { cs.siori_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_siori_UnChecked(object sender, RoutedEventArgs args) { cs.siori_enable = false; }
        public void tb_enable_aoi_Checked(object sender, RoutedEventArgs args) { cs.aoi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_aoi_UnChecked(object sender, RoutedEventArgs args) { cs.aoi_enable = false; }
        public void tb_enable_chika_Checked(object sender, RoutedEventArgs args) { cs.chika_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_chika_UnChecked(object sender, RoutedEventArgs args) { cs.chika_enable = false; }
        public void tb_enable_makoto_Checked(object sender, RoutedEventArgs args) { cs.makoto_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_makoto_UnChecked(object sender, RoutedEventArgs args) { cs.makoto_enable = false; }
        public void tb_enable_iriya_Checked(object sender, RoutedEventArgs args) { cs.iriya_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_iriya_UnChecked(object sender, RoutedEventArgs args) { cs.iriya_enable = false; }
        public void tb_enable_kuuka_Checked(object sender, RoutedEventArgs args) { cs.kuuka_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kuuka_UnChecked(object sender, RoutedEventArgs args) { cs.kuuka_enable = false; }
        public void tb_enable_tamaki_Checked(object sender, RoutedEventArgs args) { cs.tamaki_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_tamaki_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki_enable = false; }
        public void tb_enable_zyun_Checked(object sender, RoutedEventArgs args) { cs.zyun_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_zyun_UnChecked(object sender, RoutedEventArgs args) { cs.zyun_enable = false; }
        public void tb_enable_mihuyu_Checked(object sender, RoutedEventArgs args) { cs.mihuyu_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mihuyu_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu_enable = false; }
        public void tb_enable_sizuru_Checked(object sender, RoutedEventArgs args) { cs.sizuru_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_sizuru_UnChecked(object sender, RoutedEventArgs args) { cs.sizuru_enable = false; }
        public void tb_enable_misaki_Checked(object sender, RoutedEventArgs args) { cs.misaki_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misaki_UnChecked(object sender, RoutedEventArgs args) { cs.misaki_enable = false; }
        public void tb_enable_mitsuki_Checked(object sender, RoutedEventArgs args) { cs.mitsuki_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mitsuki_UnChecked(object sender, RoutedEventArgs args) { cs.mitsuki_enable = false; }
        public void tb_enable_rima_Checked(object sender, RoutedEventArgs args) { cs.rima_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rima_UnChecked(object sender, RoutedEventArgs args) { cs.rima_enable = false; }
        public void tb_enable_monika_Checked(object sender, RoutedEventArgs args) { cs.monika_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_monika_UnChecked(object sender, RoutedEventArgs args) { cs.monika_enable = false; }
        public void tb_enable_tsumugi_Checked(object sender, RoutedEventArgs args) { cs.tsumugi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_tsumugi_UnChecked(object sender, RoutedEventArgs args) { cs.tsumugi_enable = false; }
        public void tb_enable_ayumi_Checked(object sender, RoutedEventArgs args) { cs.ayumi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ayumi_UnChecked(object sender, RoutedEventArgs args) { cs.ayumi_enable = false; }
        public void tb_enable_ruka_Checked(object sender, RoutedEventArgs args) { cs.ruka_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ruka_UnChecked(object sender, RoutedEventArgs args) { cs.ruka_enable = false; }
        public void tb_enable_zita_Checked(object sender, RoutedEventArgs args) { cs.zita_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_zita_UnChecked(object sender, RoutedEventArgs args) { cs.zita_enable = false; }
        public void tb_enable_pekorinnu_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_pekorinnu_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_enable = false; }
        public void tb_enable_kotkoro_Checked(object sender, RoutedEventArgs args) { cs.kotkoro_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kotkoro_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_enable = false; }
        public void tb_enable_kyaru_Checked(object sender, RoutedEventArgs args) { cs.kyaru_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kyaru_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_enable = false; }
        public void tb_enable_muimi_Checked(object sender, RoutedEventArgs args) { cs.muimi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_muimi_UnChecked(object sender, RoutedEventArgs args) { cs.muimi_enable = false; }
        public void tb_enable_arisa_Checked(object sender, RoutedEventArgs args) { cs.arisa_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_arisa_UnChecked(object sender, RoutedEventArgs args) { cs.arisa_enable = false; }
        public void tb_enable_kaya_Checked(object sender, RoutedEventArgs args) { cs.kaya_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kaya_UnChecked(object sender, RoutedEventArgs args) { cs.kaya_enable = false; }
        public void tb_enable_neneka_Checked(object sender, RoutedEventArgs args) { cs.neneka_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_neneka_UnChecked(object sender, RoutedEventArgs args) { cs.neneka_enable = false; }
        public void tb_enable_kristina_Checked(object sender, RoutedEventArgs args) { cs.kristina_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kristina_UnChecked(object sender, RoutedEventArgs args) { cs.kristina_enable = false; }
        public void tb_enable_pekorinnu_summer_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_pekorinnu_summer_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_summer_enable = false; }
        public void tb_enable_kotkoro_summer_Checked(object sender, RoutedEventArgs args) { cs.kotkoro_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kotkoro_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_summer_enable = false; }
        public void tb_enable_suzume_summer_Checked(object sender, RoutedEventArgs args) { cs.suzume_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_suzume_summer_UnChecked(object sender, RoutedEventArgs args) { cs.suzume_summer_enable = false; }
        public void tb_enable_kyaru_summer_Checked(object sender, RoutedEventArgs args) { cs.kyaru_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kyaru_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_summer_enable = false; }
        public void tb_enable_tamaki_summer_Checked(object sender, RoutedEventArgs args) { cs.tamaki_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_tamaki_summer_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki_summer_enable = false; }
        public void tb_enable_mihuyu_summer_Checked(object sender, RoutedEventArgs args) { cs.mihuyu_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mihuyu_summer_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu_summer_enable = false; }
        public void tb_enable_sinobu_halloween_Checked(object sender, RoutedEventArgs args) { cs.sinobu_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_sinobu_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.sinobu_halloween_enable = false; }
        public void tb_enable_miyako_halloween_Checked(object sender, RoutedEventArgs args) { cs.miyako_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_miyako_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.miyako_halloween_enable = false; }
        public void tb_enable_misaki_halloween_Checked(object sender, RoutedEventArgs args) { cs.misaki_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misaki_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.misaki_halloween_enable = false; }
        public void tb_enable_chika_christmas_Checked(object sender, RoutedEventArgs args) { cs.chika_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_chika_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.chika_christmas_enable = false; }
        public void tb_enable_kurumi_christmas_Checked(object sender, RoutedEventArgs args) { cs.kurumi_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kurumi_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.kurumi_christmas_enable = false; }
        public void tb_enable_ayane_christmas_Checked(object sender, RoutedEventArgs args) { cs.ayane_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ayane_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.ayane_christmas_enable = false; }
        public void tb_enable_hiyori_newyear_Checked(object sender, RoutedEventArgs args) { cs.hiyori_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_hiyori_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori_newyear_enable = false; }
        public void tb_enable_yui_newyear_Checked(object sender, RoutedEventArgs args) { cs.yui_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yui_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.yui_newyear_enable = false; }
        public void tb_enable_rei_newyear_Checked(object sender, RoutedEventArgs args) { cs.rei_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rei_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.rei_newyear_enable = false; }
        public void tb_enable_eriko_valentine_Checked(object sender, RoutedEventArgs args) { cs.eriko_valentine_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_eriko_valentine_UnChecked(object sender, RoutedEventArgs args) { cs.eriko_valentine_enable = false; }
        public void tb_enable_sizuru_valentine_Checked(object sender, RoutedEventArgs args) { cs.sizuru_valentine_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_sizuru_valentine_UnChecked(object sender, RoutedEventArgs args) { cs.sizuru_valentine_enable = false; }
        public void tb_enable_anne_Checked(object sender, RoutedEventArgs args) { cs.anne_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_anne_UnChecked(object sender, RoutedEventArgs args) { cs.anne_enable = false; }
        public void tb_enable_lou_Checked(object sender, RoutedEventArgs args) { cs.lou_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_lou_UnChecked(object sender, RoutedEventArgs args) { cs.lou_enable = false; }
        public void tb_enable_grea_Checked(object sender, RoutedEventArgs args) { cs.grea_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_grea_UnChecked(object sender, RoutedEventArgs args) { cs.grea_enable = false; }
        public void tb_enable_kuuka_ooedo_Checked(object sender, RoutedEventArgs args) { cs.kuuka_ooedo_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kuuka_ooedo_UnChecked(object sender, RoutedEventArgs args) { cs.kuuka_ooedo_enable = false; }
        public void tb_enable_ninon_ooedo_Checked(object sender, RoutedEventArgs args) { cs.ninon_ooedo_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ninon_ooedo_UnChecked(object sender, RoutedEventArgs args) { cs.ninon_ooedo_enable = false; }
        public void tb_enable_rem_Checked(object sender, RoutedEventArgs args) { cs.rem_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rem_UnChecked(object sender, RoutedEventArgs args) { cs.rem_enable = false; }
        public void tb_enable_ram_Checked(object sender, RoutedEventArgs args) { cs.ram_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ram_UnChecked(object sender, RoutedEventArgs args) { cs.ram_enable = false; }
        public void tb_enable_emilia_Checked(object sender, RoutedEventArgs args) { cs.emilia_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_emilia_UnChecked(object sender, RoutedEventArgs args) { cs.emilia_enable = false; }
        public void tb_enable_suzuna_summer_Checked(object sender, RoutedEventArgs args) { cs.suzuna_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_suzuna_summer_UnChecked(object sender, RoutedEventArgs args) { cs.suzuna_summer_enable = false; }
        public void tb_enable_io_summer_Checked(object sender, RoutedEventArgs args) { cs.io_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_io_summer_UnChecked(object sender, RoutedEventArgs args) { cs.io_summer_enable = false; }
        public void tb_enable_saren_summer_Checked(object sender, RoutedEventArgs args) { cs.saren_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_saren_summer_UnChecked(object sender, RoutedEventArgs args) { cs.saren_summer_enable = false; }
        public void tb_enable_makoto_summer_Checked(object sender, RoutedEventArgs args) { cs.makoto_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_makoto_summer_UnChecked(object sender, RoutedEventArgs args) { cs.makoto_summer_enable = false; }
        public void tb_enable_kaori_summer_Checked(object sender, RoutedEventArgs args) { cs.kaori_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kaori_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kaori_summer_enable = false; }
        public void tb_enable_maho_summer_Checked(object sender, RoutedEventArgs args) { cs.maho_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_maho_summer_UnChecked(object sender, RoutedEventArgs args) { cs.maho_summer_enable = false; }
        public void tb_enable_aoi_nakayosi_Checked(object sender, RoutedEventArgs args) { cs.aoi_nakayosi_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_aoi_nakayosi_UnChecked(object sender, RoutedEventArgs args) { cs.aoi_nakayosi_enable = false; }
        public void tb_enable_chloe_Checked(object sender, RoutedEventArgs args) { cs.chloe_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_chloe_UnChecked(object sender, RoutedEventArgs args) { cs.chloe_enable = false; }
        public void tb_enable_chieru_Checked(object sender, RoutedEventArgs args) { cs.chieru_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_chieru_UnChecked(object sender, RoutedEventArgs args) { cs.chieru_enable = false; }
        public void tb_enable_kyouka_halloween_Checked(object sender, RoutedEventArgs args) { cs.kyouka_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kyouka_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.kyouka_halloween_enable = false; }
        public void tb_enable_misogi_halloween_Checked(object sender, RoutedEventArgs args) { cs.misogi_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misogi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.misogi_halloween_enable = false; }
        public void tb_enable_mimi_halloween_Checked(object sender, RoutedEventArgs args) { cs.mimi_halloween_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mimi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.mimi_halloween_enable = false; }
        public void tb_enable_runa_Checked(object sender, RoutedEventArgs args) { cs.runa_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_runa_UnChecked(object sender, RoutedEventArgs args) { cs.runa_enable = false; }
        public void tb_enable_kristina_christmas_Checked(object sender, RoutedEventArgs args) { cs.kristina_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kristina_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.kristina_christmas_enable = false; }
        public void tb_enable_nozomi_christmas_Checked(object sender, RoutedEventArgs args) { cs.nozomi_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_nozomi_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.nozomi_christmas_enable = false; }
        public void tb_enable_iriya_christmas_Checked(object sender, RoutedEventArgs args) { cs.iriya_christmas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_iriya_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.iriya_christmas_enable = false; }
        public void tb_enable_kotkoro_newyear_Checked(object sender, RoutedEventArgs args) { cs.kotkoro_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kotkoro_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_newyear_enable = false; }
        public void tb_enable_kyaru_newyear_Checked(object sender, RoutedEventArgs args) { cs.kyaru_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kyaru_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_newyear_enable = false; }
        public void tb_enable_suzume_newyear_Checked(object sender, RoutedEventArgs args) { cs.suzume_newyear_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_suzume_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.suzume_newyear_enable = false; }
        public void tb_enable_kasumi_magical_Checked(object sender, RoutedEventArgs args) { cs.kasumi_magical_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kasumi_magical_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi_magical_enable = false; }
        public void tb_enable_siori_magical_Checked(object sender, RoutedEventArgs args) { cs.siori_magical_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_siori_magical_UnChecked(object sender, RoutedEventArgs args) { cs.siori_magical_enable = false; }

        private void tb_enable_uzuki_deremas_Checked(object sender, RoutedEventArgs e) { cs.uzuki_deremas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_uzuki_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.uzuki_deremas_enable = false; }
        private void tb_enable_mio_deremas_Checked(object sender, RoutedEventArgs e) { cs.mio_deremas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mio_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.mio_deremas_enable = false; }
        private void tb_enable_rin_deremas_Checked(object sender, RoutedEventArgs e) { cs.rin_deremas_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rin_deremas_UnChecked(object sender, RoutedEventArgs args) { cs.rin_deremas_enable = false; }


        private void tb_enable_rin_ranger_Checked(object sender, RoutedEventArgs e) { cs.rin_ranger_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rin_ranger_UnChecked(object sender, RoutedEventArgs args) { cs.rin_ranger_enable = false; }

        private void tb_enable_mahiru_ranger_Checked(object sender, RoutedEventArgs e) { cs.mahiru_ranger_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_mahiru_ranger_UnChecked(object sender, RoutedEventArgs args) { cs.mahiru_ranger_enable = false; }

        private void tb_enable_rino_wonder_Checked(object sender, RoutedEventArgs e) { cs.rino_wonder_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_rino_wonder_UnChecked(object sender, RoutedEventArgs args) { cs.rino_wonder_enable = false; }

        private void tb_enable_ayumi_wonder_Checked(object sender, RoutedEventArgs e) { cs.ayumi_wonder_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ayumi_wonder_UnChecked(object sender, RoutedEventArgs args) { cs.ayumi_wonder_enable = false; }

        private void tb_enable_ruka_summer_Checked(object sender, RoutedEventArgs e) { cs.ruka_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_ruka_summer_UnChecked(object sender, RoutedEventArgs args) { cs.ruka_summer_enable = false; }
        private void tb_enable_anna_summer_Checked(object sender, RoutedEventArgs e) { cs.anna_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_anna_summer_UnChecked(object sender, RoutedEventArgs args) { cs.anna_summer_enable = false; }
        private void tb_enable_nanaka_summer_Checked(object sender, RoutedEventArgs e) { cs.nanaka_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_nanaka_summer_UnChecked(object sender, RoutedEventArgs args) { cs.nanaka_summer_enable = false; }
        private void tb_enable_hatsune_summer_Checked(object sender, RoutedEventArgs e) { cs.hatsune_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_hatsune_summer_UnChecked(object sender, RoutedEventArgs args) { cs.hatsune_summer_enable = false; }
        private void tb_enable_misato_summer_Checked(object sender, RoutedEventArgs e) { cs.misato_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_misato_summer_UnChecked(object sender, RoutedEventArgs args) { cs.misato_summer_enable = false; }
        private void tb_enable_zyun_summer_Checked(object sender, RoutedEventArgs e) { cs.zyun_summer_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_zyun_summer_UnChecked(object sender, RoutedEventArgs args) { cs.zyun_summer_enable = false; }
        private void tb_enable_akari_angel_Checked(object sender, RoutedEventArgs e) { cs.akari_angel_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_akari_angel_UnChecked(object sender, RoutedEventArgs args) { cs.akari_angel_enable = false; }

        private void tb_enable_yui_princess_Checked(object sender, RoutedEventArgs e) { cs.yui_princess_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yui_princess_UnChecked(object sender, RoutedEventArgs args) { cs.yui_princess_enable = false; }
        public void tb_enable_pekorinnu_princess_Checked(object sender, RoutedEventArgs args) { cs.pekorinnu_princess_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_pekorinnu_princess_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_princess_enable = false; }

        private void tb_enable_kotkoro_princess_Checked(object sender, RoutedEventArgs e) { cs.kotkoro_princess_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_kotkoro_princess_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_princess_enable = false; }

        private void tb_enable_yuni_Checked(object sender, RoutedEventArgs e) { cs.yuni_enable = true; this.SomeMeaninglessVariable++; }
        public void tb_enable_yuni_UnChecked(object sender, RoutedEventArgs args) { cs.yuni_enable = false; }

        public void tb_enable_yori_angel_Checked(object sender, RoutedEventArgs e) { cs.yori_angel_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_yori_angel_UnChecked(object sender, RoutedEventArgs args) { cs.yori_angel_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_inori_Checked(object sender, RoutedEventArgs e) { cs.inori_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_inori_UnChecked(object sender, RoutedEventArgs args) { cs.inori_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_labyrista_Checked(object sender, RoutedEventArgs e) { cs.labyrista_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_labyrista_UnChecked(object sender, RoutedEventArgs args) { cs.labyrista_enable = false; SomeMeaninglessVariable--; }


        public void tb_enable_tsumugi_halloween_Checked(object sender, RoutedEventArgs e) { cs.tsumugi_halloween_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_tsumugi_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.tsumugi_halloween_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_rei_halloween_Checked(object sender, RoutedEventArgs e) { cs.rei_halloween_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_rei_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.rei_halloween_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_matsuri_halloween_Checked(object sender, RoutedEventArgs e) { cs.matsuri_halloween_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_matsuri_halloween_UnChecked(object sender, RoutedEventArgs args) { cs.matsuri_halloween_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_monika_magical_Checked(object sender, RoutedEventArgs e) { cs.monika_magical_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_monika_magical_UnChecked(object sender, RoutedEventArgs args) { cs.monika_magical_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_tomo_magical_Checked(object sender, RoutedEventArgs e) { cs.tomo_magical_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_tomo_magical_UnChecked(object sender, RoutedEventArgs args) { cs.tomo_magical_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_shepi_Checked(object sender, RoutedEventArgs e) { cs.shepi_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_shepi_UnChecked(object sender, RoutedEventArgs args) { cs.shepi_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_akino_christmas_Checked(object sender, RoutedEventArgs e) { cs.akino_christmas_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_akino_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.akino_christmas_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_saren_christmas_Checked(object sender, RoutedEventArgs e) { cs.saren_christmas_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_saren_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.saren_christmas_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_yukari_christmas_Checked(object sender, RoutedEventArgs e) { cs.yukari_christmas_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_yukari_christmas_UnChecked(object sender, RoutedEventArgs args) { cs.yukari_christmas_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_muimi_newyear_Checked(object sender, RoutedEventArgs e) { cs.muimi_newyear_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_muimi_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.muimi_newyear_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_neneka_newyear_Checked(object sender, RoutedEventArgs e) { cs.neneka_newyear_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_neneka_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.neneka_newyear_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_pekorinnu_newyear_Checked(object sender, RoutedEventArgs e) { cs.pekorinnu_newyear_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_pekorinnu_newyear_UnChecked(object sender, RoutedEventArgs args) { cs.pekorinnu_newyear_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_kotkoro_maiden_Checked(object sender, RoutedEventArgs e) { cs.kotkoro_maiden_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_kotkoro_maiden_UnChecked(object sender, RoutedEventArgs args) { cs.kotkoro_maiden_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_yui_maiden_Checked(object sender, RoutedEventArgs e) { cs.yui_maiden_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_yui_maiden_UnChecked(object sender, RoutedEventArgs args) { cs.yui_maiden_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_kasumi_summer_Checked(object sender, RoutedEventArgs e) { cs.kasumi_summer_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_kasumi_summer_UnChecked(object sender, RoutedEventArgs args) { cs.kasumi_summer_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_rima_cinderella_Checked(object sender, RoutedEventArgs e) { cs.rima_cinderella_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_rima_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.rima_cinderella_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_makoto_cinderella_Checked(object sender, RoutedEventArgs e) { cs.makoto_cinderella_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_makoto_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.makoto_cinderella_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_maho_cinderella_Checked(object sender, RoutedEventArgs e) { cs.maho_cinderella_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_maho_cinderella_UnChecked(object sender, RoutedEventArgs args) { cs.maho_cinderella_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_chloe_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.chloe_nakayosi2_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_chloe_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.chloe_nakayosi2_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_chieru_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.chieru_nakayosi2_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_chieru_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.chieru_nakayosi2_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_yuni_nakayosi2_Checked(object sender, RoutedEventArgs e) { cs.yuni_nakayosi2_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_yuni_nakayosi2_UnChecked(object sender, RoutedEventArgs args) { cs.yuni_nakayosi2_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_inori_timetravel_Checked(object sender, RoutedEventArgs e) { cs.inori_timetravel_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_inori_timetravel_UnChecked(object sender, RoutedEventArgs args) { cs.inori_timetravel_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_kaya_timetravel_Checked(object sender, RoutedEventArgs e) { cs.kaya_timetravel_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_kaya_timetravel_UnChecked(object sender, RoutedEventArgs args) { cs.kaya_timetravel_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_aoi_worker_Checked(object sender, RoutedEventArgs e) { cs.aoi_worker_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_aoi_worker_UnChecked(object sender, RoutedEventArgs args) { cs.aoi_worker_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_tamaki_worker_Checked(object sender, RoutedEventArgs e) { cs.tamaki_worker_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_tamaki_worker_UnChecked(object sender, RoutedEventArgs args) { cs.tamaki_worker_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_mihuyu_worker_Checked(object sender, RoutedEventArgs e) { cs.mihuyu_worker_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_mihuyu_worker_UnChecked(object sender, RoutedEventArgs args) { cs.mihuyu_worker_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_hiyori_princess_Checked(object sender, RoutedEventArgs e) { cs.hiyori_princess_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_hiyori_princess_UnChecked(object sender, RoutedEventArgs args) { cs.hiyori_princess_enable = false; SomeMeaninglessVariable--; }
        public void tb_enable_kyaru_princess_Checked(object sender, RoutedEventArgs e) { cs.kyaru_princess_enable = true; SomeMeaninglessVariable++; }
        public void tb_enable_kyaru_princess_UnChecked(object sender, RoutedEventArgs args) { cs.kyaru_princess_enable = false; SomeMeaninglessVariable--; }

        #endregion

        private void bt_save_enable_offDeck_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("character_availability.txt");
            string[] temp = new string[2];
            int row = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
            }
            sr.Close();

            string newString = temp[0] + "," + temp[1];


        }

        public string CharaName_KRtoEN(string KR)
        {
            StreamReader sr = new StreamReader("character_abbreviation.txt");
            while (!sr.EndOfStream)
            {
                string EN;
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                if (temp[0] == KR)
                {
                    EN = temp[1];
                    sr.Close();
                    return EN;
                }
                else
                    continue;
            }

            sr.Close();
            return "";

        }
        public string CharaName_ENtoKR(string EN)
        {
            StreamReader sr = new StreamReader("character_abbreviation.txt");
            while (!sr.EndOfStream)
            {
                string KR;
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                if (temp[1] == EN)
                {
                    KR = temp[0];
                    sr.Close();
                    return KR;
                }
                else
                    continue;
            }
            sr.Close();

            return "";

        }

        private void InitialAvaliabilty()
        {
            StreamReader sr = new StreamReader("character_availability.txt");
            int index = 0;

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                Debug.WriteLine(s);

                if (temp[0] == "히요리")
                {
                    if (temp[1] == "0") { cs.hiyori_enable = false; tb_enable_hiyori.IsChecked = true; }
                    else { cs.hiyori_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_hiyori.IsChecked = false;
                        Debug.WriteLine("히");
                    }
                }
                else if (temp[0] == "유이")
                {
                    if (temp[1] == "0") { cs.yui_enable = false; tb_enable_yui.IsChecked = true; }
                    else { cs.yui_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yui.IsChecked = false;
                        Debug.WriteLine("유이2");
                    }
                }
                else if (temp[0] == "레이")
                {
                    if (temp[1] == "0") { cs.rei_enable = false; tb_enable_rei.IsChecked = true; }
                    else { cs.rei_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rei.IsChecked = false; }
                }
                else if (temp[0] == "미소기")
                {
                    if (temp[1] == "0") { cs.misogi_enable = false; tb_enable_misogi.IsChecked = true; }
                    else { cs.misogi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misogi.IsChecked = false; }
                }
                else if (temp[0] == "마츠리")
                {
                    if (temp[1] == "0") { cs.matsuri_enable = false; tb_enable_matsuri.IsChecked = true; }
                    else { cs.matsuri_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_matsuri.IsChecked = false; }
                }
                else if (temp[0] == "아카리")
                {
                    if (temp[1] == "0") { cs.akari_enable = false; tb_enable_akari.IsChecked = true; }
                    else { cs.akari_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_akari.IsChecked = false; }
                }
                else if (temp[0] == "미야코")
                {
                    if (temp[1] == "0") { cs.miyako_enable = false; tb_enable_miyako.IsChecked = true; }
                    else { cs.miyako_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_miyako.IsChecked = false; }
                }
                else if (temp[0] == "유키")
                {
                    if (temp[1] == "0") { cs.yuki_enable = false; tb_enable_yuki.IsChecked = true; }
                    else { cs.yuki_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yuki.IsChecked = false; }
                }
                else if (temp[0] == "안나")
                {
                    if (temp[1] == "0") { cs.anna_enable = false; tb_enable_anna.IsChecked = true; }
                    else { cs.anna_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_anna.IsChecked = false; }
                }
                else if (temp[0] == "마호")
                {
                    if (temp[1] == "0") { cs.maho_enable = false; tb_enable_maho.IsChecked = true; }
                    else { cs.maho_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_maho.IsChecked = false; }
                }
                else if (temp[0] == "리노")
                {
                    if (temp[1] == "0") { cs.rino_enable = false; tb_enable_rino.IsChecked = true; }
                    else { cs.rino_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rino.IsChecked = false; }
                }
                else if (temp[0] == "하츠네")
                {
                    if (temp[1] == "0") { cs.hatsune_enable = false; tb_enable_hatsune.IsChecked = true; }
                    else { cs.hatsune_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_hatsune.IsChecked = false; }
                }
                else if (temp[0] == "나나카")
                {
                    if (temp[1] == "0") { cs.nanaka_enable = false; tb_enable_nanaka.IsChecked = true; }
                    else { cs.nanaka_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_nanaka.IsChecked = false; }
                }
                else if (temp[0] == "카스미")
                {
                    if (temp[1] == "0") { cs.kasumi_enable = false; tb_enable_kasumi.IsChecked = true; }
                    else { cs.kasumi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kasumi.IsChecked = false; }
                }
                else if (temp[0] == "미사토")
                {
                    if (temp[1] == "0") { cs.misato_enable = false; tb_enable_misato.IsChecked = true; }
                    else { cs.misato_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misato.IsChecked = false; }
                }
                else if (temp[0] == "스즈나")
                {
                    if (temp[1] == "0") { cs.suzuna_enable = false; tb_enable_suzuna.IsChecked = true; }
                    else { cs.suzuna_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_suzuna.IsChecked = false; }
                }
                else if (temp[0] == "카오리")
                {
                    if (temp[1] == "0") { cs.kaori_enable = false; tb_enable_kaori.IsChecked = true; }
                    else { cs.kaori_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kaori.IsChecked = false; }
                }
                else if (temp[0] == "이오")
                {
                    if (temp[1] == "0") { cs.io_enable = false; tb_enable_io.IsChecked = true; }
                    else { cs.io_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_io.IsChecked = false; }
                }
                else if (temp[0] == "미미")
                {
                    if (temp[1] == "0") { cs.mimi_enable = false; tb_enable_mimi.IsChecked = true; }
                    else { cs.mimi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mimi.IsChecked = false; }
                }
                else if (temp[0] == "쿠루미")
                {
                    if (temp[1] == "0") { cs.kurumi_enable = false; tb_enable_kurumi.IsChecked = true; }
                    else { cs.kurumi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kurumi.IsChecked = false; }
                }
                else if (temp[0] == "요리")
                {
                    if (temp[1] == "0") { cs.yori_enable = false; tb_enable_yori.IsChecked = true; }
                    else { cs.yori_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yori.IsChecked = false; }
                }
                else if (temp[0] == "아야네")
                {
                    if (temp[1] == "0") { cs.ayane_enable = false; tb_enable_ayane.IsChecked = true; }
                    else { cs.ayane_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ayane.IsChecked = false; }
                }
                else if (temp[0] == "스즈메")
                {
                    if (temp[1] == "0") { cs.suzume_enable = false; tb_enable_suzume.IsChecked = true; }
                    else { cs.suzume_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_suzume.IsChecked = false; }
                }
                else if (temp[0] == "린")
                {
                    if (temp[1] == "0") { cs.rin_enable = false; tb_enable_rin.IsChecked = true; }
                    else { cs.rin_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rin.IsChecked = false; }
                }
                else if (temp[0] == "에리코")
                {
                    if (temp[1] == "0") { cs.eriko_enable = false; tb_enable_eriko.IsChecked = true; }
                    else { cs.eriko_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_eriko.IsChecked = false; }
                }
                else if (temp[0] == "사렌")
                {
                    if (temp[1] == "0") { cs.saren_enable = false; tb_enable_saren.IsChecked = true; }
                    else { cs.saren_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_saren.IsChecked = false; }
                }
                else if (temp[0] == "노조미")
                {
                    if (temp[1] == "0") { cs.nozomi_enable = false; tb_enable_nozomi.IsChecked = true; }
                    else { cs.nozomi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_nozomi.IsChecked = false; }
                }
                else if (temp[0] == "니논")
                {
                    if (temp[1] == "0") { cs.ninon_enable = false; tb_enable_ninon.IsChecked = true; }
                    else { cs.ninon_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ninon.IsChecked = false; }
                }
                else if (temp[0] == "시노부")
                {
                    if (temp[1] == "0") { cs.sinobu_enable = false; tb_enable_sinobu.IsChecked = true; }
                    else { cs.sinobu_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_sinobu.IsChecked = false; }
                }
                else if (temp[0] == "아키노")
                {
                    if (temp[1] == "0")
                    {
                        cs.akino_enable = false; tb_enable_akino.IsChecked = true;
                    }
                    else { cs.akino_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_akino.IsChecked = false; }
                }
                else if (temp[0] == "마히루")
                {
                    if (temp[1] == "0")
                    {
                        cs.mahiru_enable = false; tb_enable_mahiru.IsChecked = true;
                    }
                    else { cs.mahiru_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mahiru.IsChecked = false; }
                }
                else if (temp[0] == "유카리")
                {
                    if (temp[1] == "0") { cs.yukari_enable = false; tb_enable_yukari.IsChecked = true; }
                    else { cs.yukari_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yukari.IsChecked = false; }
                }
                else if (temp[0] == "쿄우카")
                {
                    if (temp[1] == "0") { cs.kyouka_enable = false; tb_enable_kyouka.IsChecked = true; }
                    else { cs.kyouka_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyouka.IsChecked = false; }
                }
                else if (temp[0] == "토모")
                {
                    if (temp[1] == "0") { cs.tomo_enable = false; tb_enable_tomo.IsChecked = true; }
                    else { cs.tomo_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_tomo.IsChecked = false; }
                }
                else if (temp[0] == "시오리")
                {
                    if (temp[1] == "0") { cs.siori_enable = false; tb_enable_siori.IsChecked = true; }
                    else { cs.siori_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_siori.IsChecked = false; }
                }
                else if (temp[0] == "아오이")
                {
                    if (temp[1] == "0") { cs.aoi_enable = false; tb_enable_aoi.IsChecked = true; }
                    else { cs.aoi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_aoi.IsChecked = false; }
                }
                else if (temp[0] == "치카")
                {
                    if (temp[1] == "0") { cs.chika_enable = false; tb_enable_chika.IsChecked = true; }
                    else { cs.chika_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_chika.IsChecked = false; }
                }
                else if (temp[0] == "마코토")
                {
                    if (temp[1] == "0") { cs.makoto_enable = false; tb_enable_makoto.IsChecked = true; }
                    else { cs.makoto_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_makoto.IsChecked = false; }
                }
                else if (temp[0] == "이리야")
                {
                    if (temp[1] == "0") { cs.iriya_enable = false; tb_enable_iriya.IsChecked = true; }
                    else { cs.iriya_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_iriya.IsChecked = false; }
                }
                else if (temp[0] == "쿠우카")
                {
                    if (temp[1] == "0") { cs.kuuka_enable = false; tb_enable_kuuka.IsChecked = true; }
                    else { cs.kuuka_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kuuka.IsChecked = false; }
                }
                else if (temp[0] == "타마키")
                {
                    if (temp[1] == "0") { cs.tamaki_enable = false; tb_enable_tamaki.IsChecked = true; }
                    else { cs.tamaki_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_tamaki.IsChecked = false; }
                }
                else if (temp[0] == "쥰")
                {
                    if (temp[1] == "0") { cs.zyun_enable = false; tb_enable_zyun.IsChecked = true; }
                    else { cs.zyun_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_zyun.IsChecked = false; }
                }
                else if (temp[0] == "미후유")
                {
                    if (temp[1] == "0") { cs.mihuyu_enable = false; tb_enable_mihuyu.IsChecked = true; }
                    else { cs.mihuyu_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mihuyu.IsChecked = false; }
                }
                else if (temp[0] == "시즈루")
                {
                    if (temp[1] == "0") { cs.sizuru_enable = false; tb_enable_sizuru.IsChecked = true; }
                    else { cs.sizuru_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_sizuru.IsChecked = false; }
                }
                else if (temp[0] == "미사키")
                {
                    if (temp[1] == "0") { cs.misaki_enable = false; tb_enable_misaki.IsChecked = true; }
                    else { cs.misaki_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misaki.IsChecked = false; }
                }
                else if (temp[0] == "미츠키")
                {
                    if (temp[1] == "0") { cs.mitsuki_enable = false; tb_enable_mitsuki.IsChecked = true; }
                    else { cs.mitsuki_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mitsuki.IsChecked = false; }
                }
                else if (temp[0] == "리마")
                {
                    if (temp[1] == "0") { cs.rima_enable = false; tb_enable_rima.IsChecked = true; }
                    else { cs.rima_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rima.IsChecked = false; }
                }
                else if (temp[0] == "모니카")
                {
                    if (temp[1] == "0") { cs.monika_enable = false; tb_enable_monika.IsChecked = true; }
                    else { cs.monika_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_monika.IsChecked = false; }
                }
                else if (temp[0] == "츠무기")
                {
                    if (temp[1] == "0") { cs.tsumugi_enable = false; tb_enable_tsumugi.IsChecked = true; }
                    else { cs.tsumugi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_tsumugi.IsChecked = false; }
                }
                else if (temp[0] == "아유미")
                {
                    if (temp[1] == "0") { cs.ayumi_enable = false; tb_enable_ayumi.IsChecked = true; }
                    else { cs.ayumi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ayumi.IsChecked = false; }
                }
                else if (temp[0] == "루카")
                {
                    if (temp[1] == "0") { cs.ruka_enable = false; tb_enable_ruka.IsChecked = true; }
                    else { cs.ruka_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ruka.IsChecked = false; }
                }
                else if (temp[0] == "지타")
                {
                    if (temp[1] == "0") { cs.zita_enable = false; tb_enable_zita.IsChecked = true; }
                    else { cs.zita_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_zita.IsChecked = false; }
                }
                else if (temp[0] == "페코린느")
                {
                    if (temp[1] == "0") { cs.pekorinnu_enable = false; tb_enable_pekorinnu.IsChecked = true; }
                    else { cs.pekorinnu_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_pekorinnu.IsChecked = false; }
                }
                else if (temp[0] == "콧코로")
                {
                    if (temp[1] == "0") { cs.kotkoro_enable = false; tb_enable_kotkoro.IsChecked = true; }
                    else { cs.kotkoro_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kotkoro.IsChecked = false; }
                }
                else if (temp[0] == "캬루")
                {
                    if (temp[1] == "0") { cs.kyaru_enable = false; tb_enable_kyaru.IsChecked = true; }
                    else { cs.kyaru_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyaru.IsChecked = false; }
                }
                else if (temp[0] == "무이미")
                {
                    if (temp[1] == "0") { cs.muimi_enable = false; tb_enable_muimi.IsChecked = true; }
                    else { cs.muimi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_muimi.IsChecked = false; }
                }
                else if (temp[0] == "아리사")
                {
                    if (temp[1] == "0") { cs.arisa_enable = false; tb_enable_arisa.IsChecked = true; }
                    else { cs.arisa_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_arisa.IsChecked = false; }
                }
                else if (temp[0] == "카야")
                {
                    if (temp[1] == "0") { cs.kaya_enable = false; tb_enable_kaya.IsChecked = true; }
                    else { cs.kaya_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kaya.IsChecked = false; }
                }
                else if (temp[0] == "네네카")
                {
                    if (temp[1] == "0") { cs.neneka_enable = false; tb_enable_neneka.IsChecked = true; }
                    else { cs.neneka_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_neneka.IsChecked = false; }
                }
                else if (temp[0] == "크리스티나")
                {
                    if (temp[1] == "0") { cs.kristina_enable = false; tb_enable_kristina.IsChecked = true; }
                    else { cs.kristina_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kristina.IsChecked = false; }
                }
                else if (temp[0] == "수페코")
                {
                    if (temp[1] == "0") { cs.pekorinnu_summer_enable = false; tb_enable_pekorinnu_summer.IsChecked = true; }
                    else { cs.pekorinnu_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_pekorinnu_summer.IsChecked = false; }
                }
                else if (temp[0] == "수코로")
                {
                    if (temp[1] == "0") { cs.kotkoro_summer_enable = false; tb_enable_kotkoro_summer.IsChecked = true; }
                    else { cs.kotkoro_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kotkoro_summer.IsChecked = false; }
                }
                else if (temp[0] == "수즈메")
                {
                    if (temp[1] == "0") { cs.suzume_summer_enable = false; tb_enable_suzume_summer.IsChecked = true; }
                    else { cs.suzume_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_suzume_summer.IsChecked = false; }
                }
                else if (temp[0] == "수캬루")
                {
                    if (temp[1] == "0") { cs.kyaru_summer_enable = false; tb_enable_kyaru_summer.IsChecked = true; }
                    else { cs.kyaru_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyaru_summer.IsChecked = false; }
                }
                else if (temp[0] == "수마키")
                {
                    if (temp[1] == "0") { cs.tamaki_summer_enable = false; tb_enable_tamaki_summer.IsChecked = true; }
                    else { cs.tamaki_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_tamaki_summer.IsChecked = false; }
                }
                else if (temp[0] == "수후유")
                {
                    if (temp[1] == "0") { cs.mihuyu_summer_enable = false; tb_enable_mihuyu_summer.IsChecked = true; }
                    else { cs.mihuyu_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mihuyu_summer.IsChecked = false; }
                }
                else if (temp[0] == "할노부")
                {
                    if (temp[1] == "0") { cs.sinobu_halloween_enable = false; tb_enable_sinobu_halloween.IsChecked = true; }
                    else { cs.sinobu_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_sinobu_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할푸딩")
                {
                    if (temp[1] == "0") { cs.miyako_halloween_enable = false; tb_enable_miyako_halloween.IsChecked = true; }
                    else { cs.miyako_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_miyako_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할사키")
                {
                    if (temp[1] == "0") { cs.misaki_halloween_enable = false; tb_enable_misaki_halloween.IsChecked = true; }
                    else { cs.misaki_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misaki_halloween.IsChecked = false; }
                }
                else if (temp[0] == "성치카")
                {
                    if (temp[1] == "0") { cs.chika_christmas_enable = false; tb_enable_chika_christmas.IsChecked = true; }
                    else { cs.chika_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_chika_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성루미")
                {
                    if (temp[1] == "0") { cs.kurumi_christmas_enable = false; tb_enable_kurumi_christmas.IsChecked = true; }
                    else { cs.kurumi_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kurumi_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성야네")
                {
                    if (temp[1] == "0") { cs.ayane_christmas_enable = false; tb_enable_ayane_christmas.IsChecked = true; }
                    else { cs.ayane_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ayane_christmas.IsChecked = false; }
                }
                else if (temp[0] == "뉴요리")
                {
                    if (temp[1] == "0") { cs.hiyori_newyear_enable = false; tb_enable_hiyori_newyear.IsChecked = true; }
                    else { cs.hiyori_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_hiyori_newyear.IsChecked = false; }
                }
                else if (temp[0] == "뉴이")
                {
                    if (temp[1] == "0") { cs.yui_newyear_enable = false; tb_enable_yui_newyear.IsChecked = true; }
                    else { cs.yui_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yui_newyear.IsChecked = false; }
                }
                else if (temp[0] == "신레이")
                {
                    if (temp[1] == "0") { cs.rei_newyear_enable = false; tb_enable_rei_newyear.IsChecked = true; }
                    else { cs.rei_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rei_newyear.IsChecked = false; }
                }
                else if (temp[0] == "발리코")
                {
                    if (temp[1] == "0") { cs.eriko_valentine_enable = false; tb_enable_eriko_valentine.IsChecked = true; }
                    else { cs.eriko_valentine_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_eriko_valentine.IsChecked = false; }
                }
                else if (temp[0] == "발즈루")
                {
                    if (temp[1] == "0") { cs.sizuru_valentine_enable = false; tb_enable_sizuru_valentine.IsChecked = true; }
                    else { cs.sizuru_valentine_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_sizuru_valentine.IsChecked = false; }
                }
                else if (temp[0] == "앤")
                {
                    if (temp[1] == "0") { cs.anne_enable = false; tb_enable_anne.IsChecked = true; }
                    else { cs.anne_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_anne.IsChecked = false; }
                }
                else if (temp[0] == "루")
                {
                    if (temp[1] == "0") { cs.lou_enable = false; tb_enable_lou.IsChecked = true; }
                    else { cs.lou_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_lou.IsChecked = false; }
                }
                else if (temp[0] == "글레어")
                {
                    if (temp[1] == "0") { cs.grea_enable = false; tb_enable_grea.IsChecked = true; }
                    else { cs.grea_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_grea.IsChecked = false; }
                }
                else if (temp[0] == "오우카")
                {
                    if (temp[1] == "0") { cs.kuuka_ooedo_enable = false; tb_enable_kuuka_ooedo.IsChecked = true; }
                    else { cs.kuuka_ooedo_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kuuka_ooedo.IsChecked = false; }
                }
                else if (temp[0] == "오니논")
                {
                    if (temp[1] == "0") { cs.ninon_ooedo_enable = false; tb_enable_ninon_ooedo.IsChecked = true; }
                    else { cs.ninon_ooedo_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ninon_ooedo.IsChecked = false; }
                }
                else if (temp[0] == "렘")
                {
                    if (temp[1] == "0") { cs.rem_enable = false; tb_enable_rem.IsChecked = true; }
                    else { cs.rem_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rem.IsChecked = false; }
                }
                else if (temp[0] == "람")
                {
                    if (temp[1] == "0") { cs.ram_enable = false; tb_enable_ram.IsChecked = true; }
                    else { cs.ram_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ram.IsChecked = false; }
                }
                else if (temp[0] == "에밀리아")
                {
                    if (temp[1] == "0") { cs.emilia_enable = false; tb_enable_emilia.IsChecked = true; }
                    else { cs.emilia_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_emilia.IsChecked = false; }
                }
                else if (temp[0] == "수즈나")
                {
                    if (temp[1] == "0") { cs.suzuna_summer_enable = false; tb_enable_suzuna_summer.IsChecked = true; }
                    else { cs.suzuna_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_suzuna_summer.IsChecked = false; }
                }
                else if (temp[0] == "수이오")
                {
                    if (temp[1] == "0") { cs.io_summer_enable = false; tb_enable_io_summer.IsChecked = true; }
                    else { cs.io_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_io_summer.IsChecked = false; }
                }
                else if (temp[0] == "수사렌")
                {
                    if (temp[1] == "0") { cs.saren_summer_enable = false; tb_enable_saren_summer.IsChecked = true; }
                    else { cs.saren_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_saren_summer.IsChecked = false; }
                }
                else if (temp[0] == "수코토")
                {
                    if (temp[1] == "0") { cs.makoto_summer_enable = false; tb_enable_makoto_summer.IsChecked = true; }
                    else { cs.makoto_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_makoto_summer.IsChecked = false; }
                }
                else if (temp[0] == "수오리")
                {
                    if (temp[1] == "0") { cs.kaori_summer_enable = false; tb_enable_kaori_summer.IsChecked = true; }
                    else { cs.kaori_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kaori_summer.IsChecked = false; }
                }
                else if (temp[0] == "수마호")
                {
                    if (temp[1] == "0") { cs.maho_summer_enable = false; tb_enable_maho_summer.IsChecked = true; }
                    else { cs.maho_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_maho_summer.IsChecked = false; }
                }
                else if (temp[0] == "편오이")
                {
                    if (temp[1] == "0") { cs.aoi_nakayosi_enable = false; tb_enable_aoi_nakayosi.IsChecked = true; }
                    else { cs.aoi_nakayosi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_aoi_nakayosi.IsChecked = false; }
                }
                else if (temp[0] == "클로에")
                {
                    if (temp[1] == "0") { cs.chloe_enable = false; tb_enable_chloe.IsChecked = true; }
                    else { cs.chloe_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_chloe.IsChecked = false; }
                }
                else if (temp[0] == "할쿄카")
                {
                    if (temp[1] == "0") { cs.kyouka_halloween_enable = false; tb_enable_kyouka_halloween.IsChecked = true; }
                    else { cs.kyouka_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyouka_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할소기")
                {
                    if (temp[1] == "0") { cs.misogi_halloween_enable = false; tb_enable_misogi_halloween.IsChecked = true; }
                    else { cs.misogi_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misogi_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할미미")
                {
                    if (temp[1] == "0") { cs.mimi_halloween_enable = false; tb_enable_mimi_halloween.IsChecked = true; }
                    else { cs.mimi_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mimi_halloween.IsChecked = false; }
                }
                else if (temp[0] == "루나")
                {
                    if (temp[1] == "0") { cs.runa_enable = false; tb_enable_runa.IsChecked = true; }
                    else { cs.runa_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_runa.IsChecked = false; }
                }
                else if (temp[0] == "성리스")
                {
                    if (temp[1] == "0") { cs.kristina_christmas_enable = false; tb_enable_kristina_christmas.IsChecked = true; }
                    else { cs.kristina_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kristina_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성조미")
                {
                    if (temp[1] == "0") { cs.nozomi_christmas_enable = false; tb_enable_nozomi_christmas.IsChecked = true; }
                    else { cs.nozomi_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_nozomi_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성리야")
                {
                    if (temp[1] == "0") { cs.iriya_christmas_enable = false; tb_enable_iriya_christmas.IsChecked = true; }
                    else { cs.iriya_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_iriya_christmas.IsChecked = false; }
                }
                else if (temp[0] == "뉴코로")
                {
                    if (temp[1] == "0") { cs.kotkoro_newyear_enable = false; tb_enable_kotkoro_newyear.IsChecked = true; }
                    else { cs.kotkoro_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kotkoro_newyear.IsChecked = false; }
                }
                else if (temp[0] == "냐루")
                {
                    if (temp[1] == "0") { cs.kyaru_newyear_enable = false; tb_enable_kyaru_newyear.IsChecked = true; }
                    else { cs.kyaru_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyaru_newyear.IsChecked = false; }
                }
                else if (temp[0] == "뉴즈메")
                {
                    if (temp[1] == "0") { cs.suzume_newyear_enable = false; tb_enable_suzume_newyear.IsChecked = true; }
                    else { cs.suzume_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_suzume_newyear.IsChecked = false; }
                }
                else if (temp[0] == "마스미")
                {
                    if (temp[1] == "0") { cs.kasumi_magical_enable = false; tb_enable_kasumi_magical.IsChecked = true; }
                    else { cs.kasumi_magical_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kasumi_magical.IsChecked = false; }
                }
                else if (temp[0] == "마오리")
                {
                    if (temp[1] == "0") { cs.siori_magical_enable = false; tb_enable_siori_magical.IsChecked = true; }
                    else { cs.siori_magical_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_siori_magical.IsChecked = false; }
                }
                else if (temp[0] == "프페코")
                {
                    if (temp[1] == "0") { cs.pekorinnu_princess_enable = false; tb_enable_pekorinnu_princess.IsChecked = true; }
                    else { cs.pekorinnu_princess_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_pekorinnu_princess.IsChecked = false; }
                }
                else if (temp[0] == "우즈키")
                {
                    if (temp[1] == "0") { cs.uzuki_deremas_enable = false; tb_enable_uzuki_deremas.IsChecked = true; }
                    else { cs.uzuki_deremas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_uzuki_deremas.IsChecked = false; }
                }
                else if (temp[0] == "시부린")
                {
                    if (temp[1] == "0") { cs.rin_deremas_enable = false; tb_enable_rin_deremas.IsChecked = true; }
                    else { cs.rin_deremas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rin_deremas.IsChecked = false; }
                }
                else if (temp[0] == "미오")
                {
                    if (temp[1] == "0") { cs.mio_deremas_enable = false; tb_enable_mio_deremas.IsChecked = true; }
                    else { cs.mio_deremas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mio_deremas.IsChecked = false; }
                }
                else if (temp[0] == "유니")
                {
                    if (temp[1] == "0") { cs.yuni_enable = false; tb_enable_yuni.IsChecked = true; }
                    else { cs.yuni_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yuni.IsChecked = false; }
                }
                else if (temp[0] == "치에루")
                {
                    if (temp[1] == "0") { cs.chieru_enable = false; tb_enable_chieru.IsChecked = true; }
                    else { cs.chieru_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_chieru.IsChecked = false; }
                }
                else if (temp[0] == "레린")
                {
                    if (temp[1] == "0") { cs.rin_ranger_enable = false; tb_enable_rin_ranger.IsChecked = true; }
                    else { cs.rin_ranger_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rin_ranger.IsChecked = false; }
                }
                else if (temp[0] == "레히루")
                {
                    if (temp[1] == "0") { cs.mahiru_ranger_enable = false; tb_enable_mahiru_ranger.IsChecked = true; }
                    else { cs.mahiru_ranger_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_mahiru_ranger.IsChecked = false; }
                }
                else if (temp[0] == "앨리노")
                {
                    if (temp[1] == "0") { cs.rino_wonder_enable = false; tb_enable_rino_wonder.IsChecked = true; }
                    else { cs.rino_wonder_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_rino_wonder.IsChecked = false; }
                }
                else if (temp[0] == "앨유미")
                {
                    if (temp[1] == "0") { cs.ayumi_wonder_enable = false; tb_enable_ayumi_wonder.IsChecked = true; }
                    else { cs.ayumi_wonder_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ayumi_wonder.IsChecked = false; }
                }
                else if (temp[0] == "수루카")
                {
                    if (temp[1] == "0") { cs.ruka_summer_enable = false; tb_enable_ruka_summer.IsChecked = true; }
                    else { cs.ruka_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_ruka_summer.IsChecked = false; }
                }
                else if (temp[0] == "수안나")
                {
                    if (temp[1] == "0") { cs.anna_summer_enable = false; tb_enable_anna_summer.IsChecked = true; }
                    else { cs.anna_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_anna_summer.IsChecked = false; }
                }
                else if (temp[0] == "수나카")
                {
                    if (temp[1] == "0") { cs.nanaka_summer_enable = false; tb_enable_nanaka_summer.IsChecked = true; }
                    else { cs.nanaka_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_nanaka_summer.IsChecked = false; }
                }
                else if (temp[0] == "수츠네")
                {
                    if (temp[1] == "0") { cs.hatsune_summer_enable = false; tb_enable_hatsune_summer.IsChecked = true; }
                    else { cs.hatsune_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_hatsune_summer.IsChecked = false; }
                }
                else if (temp[0] == "수사토")
                {
                    if (temp[1] == "0") { cs.misato_summer_enable = false; tb_enable_misato_summer.IsChecked = true; }
                    else { cs.misato_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_misato_summer.IsChecked = false; }
                }
                else if (temp[0] == "수쥰")
                {
                    if (temp[1] == "0") { cs.zyun_summer_enable = false; tb_enable_zyun_summer.IsChecked = true; }
                    else { cs.zyun_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_zyun_summer.IsChecked = false; }
                }
                else if (temp[0] == "엔카리")
                {
                    if (temp[1] == "0") { cs.akari_angel_enable = false; tb_enable_akari_angel.IsChecked = true; }
                    else { cs.akari_angel_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_akari_angel.IsChecked = false; }
                }
                else if (temp[0] == "프유이")
                {
                    if (temp[1] == "0") { cs.yui_princess_enable = false; tb_enable_yui_princess.IsChecked = true; }
                    else { cs.yui_princess_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_yui_princess.IsChecked = false; }
                }
                else if (temp[0] == "프코로")
                {
                    if (temp[1] == "0") { cs.kotkoro_princess_enable = false; tb_enable_kotkoro_princess.IsChecked = true; }
                    else { cs.kotkoro_princess_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kotkoro_princess.IsChecked = false; }
                }
                else if (temp[0] == "프요리")
                {
                    if (temp[1] == "0") { cs.hiyori_princess_enable = false; tb_enable_hiyori_princess.IsChecked = true; }
                    else { cs.hiyori_princess_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_hiyori_princess.IsChecked = false; }
                }
                else if (temp[0] == "프캬루")
                {
                    if (temp[1] == "0") { cs.kyaru_princess_enable = false; tb_enable_kyaru_princess.IsChecked = true; }
                    else { cs.kyaru_princess_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_enable_kyaru_princess.IsChecked = false; }
                }
                else if (temp[0] == "엔요리")
                {
                    if (temp[1] == "0") { cs.yori_angel_enable = false; tb_enable_yori_angel.IsChecked = true; }
                    else { cs.yori_angel_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_yori_angel.IsChecked = false; }
                }
                else if (temp[0] == "라비리스타")
                {
                    if (temp[1] == "0") { cs.labyrista_enable = false; tb_enable_labyrista.IsChecked = true; }
                    else { cs.labyrista_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_labyrista.IsChecked = false; }
                }
                else if (temp[0] == "이노리")
                {
                    if (temp[1] == "0") { cs.inori_enable = false; tb_enable_inori.IsChecked = true; }
                    else { cs.inori_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_inori.IsChecked = false; }
                }
                else if (temp[0] == "세피")
                {
                    if (temp[1] == "0") { cs.shepi_enable = false; tb_enable_shepi.IsChecked = true; }
                    else { cs.shepi_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_shepi.IsChecked = false; }
                }
                else if (temp[0] == "할무기")
                {
                    if (temp[1] == "0") { cs.tsumugi_halloween_enable = false; tb_enable_tsumugi_halloween.IsChecked = true; }
                    else { cs.tsumugi_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_tsumugi_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할레이")
                {
                    if (temp[1] == "0") { cs.rei_halloween_enable = false; tb_enable_rei_halloween.IsChecked = true; }
                    else { cs.rei_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_rei_halloween.IsChecked = false; }
                }
                else if (temp[0] == "할츠리")
                {
                    if (temp[1] == "0") { cs.matsuri_halloween_enable = false; tb_enable_matsuri_halloween.IsChecked = true; }
                    else { cs.matsuri_halloween_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_matsuri_halloween.IsChecked = false; }
                }
                else if (temp[0] == "마니카")
                {
                    if (temp[1] == "0") { cs.monika_magical_enable = false; tb_enable_monika_magical.IsChecked = true; }
                    else { cs.monika_magical_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_monika_magical.IsChecked = false; }
                }
                else if (temp[0] == "마토모")
                {
                    if (temp[1] == "0") { cs.tomo_magical_enable = false; tb_enable_tomo_magical.IsChecked = true; }
                    else { cs.tomo_magical_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_tomo_magical.IsChecked = false; }
                }
                else if (temp[0] == "성리노")
                {
                    if (temp[1] == "0") { cs.akino_christmas_enable = false; tb_enable_akino_christmas.IsChecked = true; }
                    else { cs.akino_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_akino_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성사렌")
                {
                    if (temp[1] == "0") { cs.saren_christmas_enable = false; tb_enable_saren_christmas.IsChecked = true; }
                    else { cs.saren_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_saren_christmas.IsChecked = false; }
                }
                else if (temp[0] == "성카리")
                {
                    if (temp[1] == "0") { cs.yukari_christmas_enable = false; tb_enable_yukari_christmas.IsChecked = true; }
                    else { cs.yukari_christmas_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_yukari_christmas.IsChecked = false; }
                }
                else if (temp[0] == "뉴이미")
                {
                    if (temp[1] == "0") { cs.muimi_newyear_enable = false; tb_enable_muimi_newyear.IsChecked = true; }
                    else { cs.muimi_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_muimi_newyear.IsChecked = false; }
                }
                else if (temp[0] == "뉴네카")
                {
                    if (temp[1] == "0") { cs.neneka_newyear_enable = false; tb_enable_neneka_newyear.IsChecked = true; }
                    else { cs.neneka_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_neneka_newyear.IsChecked = false; }
                }
                else if (temp[0] == "뉴페코")
                {
                    if (temp[1] == "0") { cs.pekorinnu_newyear_enable = false; tb_enable_pekorinnu_newyear.IsChecked = true; }
                    else { cs.pekorinnu_newyear_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_neneka_newyear.IsChecked = false; }
                }
                else if (temp[0] == "의코로")
                {
                    if (temp[1] == "0") { cs.kotkoro_maiden_enable = false; tb_enable_kotkoro_maiden.IsChecked = true; }
                    else { cs.kotkoro_maiden_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_kotkoro_maiden.IsChecked = false; }
                }
                else if (temp[0] == "의유이")
                {
                    if (temp[1] == "0") { cs.yui_maiden_enable = false; tb_enable_yui_maiden.IsChecked = true; }
                    else { cs.yui_maiden_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_yui_maiden.IsChecked = false; }
                }
                else if (temp[0] == "수스미")
                {
                    if (temp[1] == "0") { cs.kasumi_summer_enable = false; tb_enable_kasumi_summer.IsChecked = true; }
                    else { cs.kasumi_summer_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_kasumi_summer.IsChecked = false; }
                }
                else if (temp[0] == "신리마")
                {
                    if (temp[1] == "0") { cs.rima_cinderella_enable = false; tb_enable_rima_cinderella.IsChecked = true; }
                    else { cs.rima_cinderella_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_rima_cinderella.IsChecked = false; }
                }
                else if (temp[0] == "신마호")
                {
                    if (temp[1] == "0") { cs.maho_cinderella_enable = false; tb_enable_maho_cinderella.IsChecked = true; }
                    else { cs.maho_cinderella_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_maho_cinderella.IsChecked = false; }
                }
                else if (temp[0] == "신코토")
                {
                    if (temp[1] == "0") { cs.makoto_cinderella_enable = false; tb_enable_makoto_cinderella.IsChecked = true; }
                    else { cs.makoto_cinderella_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_makoto_cinderella.IsChecked = false; }
                }
                else if (temp[0] == "성로에")
                {
                    if (temp[1] == "0") { cs.chloe_nakayosi2_enable = false; tb_enable_chloe_nakayosi2.IsChecked = true; }
                    else { cs.chloe_nakayosi2_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_chloe_nakayosi2.IsChecked = false; }
                }
                else if (temp[0] == "성에루")
                {
                    if (temp[1] == "0") { cs.chieru_nakayosi2_enable = false; tb_enable_chieru_nakayosi2.IsChecked = true; }
                    else { cs.chieru_nakayosi2_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_chieru_nakayosi2.IsChecked = false; }
                }
                else if (temp[0] == "시노리")
                {
                    if (temp[1] == "0") { cs.inori_timetravel_enable = false; tb_enable_inori_timetravel.IsChecked = true; }
                    else { cs.inori_timetravel_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_inori_timetravel.IsChecked = false; }
                }
                else if (temp[0] == "시카야")
                {
                    if (temp[1] == "0") { cs.kaya_timetravel_enable = false; tb_enable_kaya_timetravel.IsChecked = true; }
                    else { cs.kaya_timetravel_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_kaya_timetravel.IsChecked = false; }
                }
                else if (temp[0] == "작오이")
                {
                    if (temp[1] == "0") { cs.aoi_worker_enable = false; tb_enable_aoi_worker.IsChecked = true; }
                    else { cs.aoi_worker_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_aoi_worker.IsChecked = false; }
                }
                else if (temp[0] == "작마키")
                {
                    if (temp[1] == "0") { cs.tamaki_worker_enable = false; tb_enable_tamaki_worker.IsChecked = true; }
                    else { cs.tamaki_worker_enable = true; AvailableCharaList[index] = temp[0]; index++; tb_tamaki_worker.IsChecked = false; }
                }
                Debug.WriteLine(String.Format("index = {0}", index));
                //Debug.WriteLine(string.Format("{0},{1}", temp[0], temp[1]));

            }
            sr.Close();

            int x = 0;
            while(AvailableCharaList[x] != null)
            {
                Debug.WriteLine(string.Format("AvailableCharaList[{0}] = {1}", x, AvailableCharaList[x]));
                x++;
            }
        }
        #endregion
        */
        //
        // 로그 보기 탭
        //
        #region Log
        private void bt_save_log_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.FileName = Filename + ".txt";
            saveFileDialog1.Filter = "Text file|*.txt";
            saveFileDialog1.Title = "로그 저장";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, LogString);
            }
        }

        private void bt_clear_log_Click(object sender, RoutedEventArgs e)
        {
            myFlowDoc.Blocks.Clear();
            myFlowDoc.Blocks.Add(new Paragraph(new Run("3545")));
            RTxtbox_Logbox.Document = myFlowDoc;
            LogString = "";
        }
        public static void WriteLog(string text) { LogString += text; }
        #endregion


        //
        // 설정 탭
        //

        #region abbr
        //축약어 뉴이미까지
        string Abbr_misaki_halloween, Abbr_kyouka, Abbr_yuni, Abbr_yuki, Abbr_yui, Abbr_maho, Abbr_maho_summer, Abbr_chika, Abbr_aoi, Abbr_kyaru_summer, 
            Abbr_suzume_summer, Abbr_chika_christmas, Abbr_yui_princess, Abbr_runa, Abbr_misaki, Abbr_hatsune, Abbr_kyaru, Abbr_yui_newyear, Abbr_nanaka, Abbr_misato, Abbr_rino_wonder,
            Abbr_kasumi_magical, Abbr_kasumi, Abbr_emilia, Abbr_suzume_newyear, Abbr_suzume, Abbr_io_summer, Abbr_io, Abbr_siori_magical, Abbr_siori, Abbr_suzuna_summer, Abbr_suzuna, 
            Abbr_rino, Abbr_misato_summer, Abbr_mio_deremas, Abbr_kyaru_newyear, Abbr_aoi_nakayosi, Abbr_neneka, Abbr_lou, Abbr_anne, Abbr_arisa, Abbr_miyako_halloween,
            Abbr_saren_summer, Abbr_yori, Abbr_akari, Abbr_hatsune_summer, Abbr_mitsuki, Abbr_kotkoro_princess, Abbr_rin, Abbr_ram, Abbr_rem, Abbr_kotkoro_summer, Abbr_akari_angel, 
            Abbr_grea, Abbr_ayumi, Abbr_ayumi_wonder, Abbr_kotkoro, Abbr_mihuyu_summer, Abbr_nanaka_summer, Abbr_sinobu_halloween, Abbr_anna, Abbr_saren, Abbr_kaori_summer, Abbr_iriya, 
            Abbr_rin_ranger, Abbr_mihuyu, Abbr_nozomi_christmas, Abbr_ninon, Abbr_monika, Abbr_yukari, Abbr_mahiru, Abbr_mahiru_ranger, Abbr_sizuru_valentine, Abbr_uzuki_deremas, 
            Abbr_mimi_halloween, Abbr_sinobu, Abbr_mimi, Abbr_kurumi_christmas, Abbr_kristina, Abbr_sizuru, Abbr_kristina_christmas, Abbr_anna_summer, Abbr_iriya_christmas, Abbr_rei, 
            Abbr_zita, Abbr_kurumi, Abbr_pekorinnu_summer, Abbr_eriko, Abbr_tamaki_summer, Abbr_chieru, Abbr_tomo, Abbr_tamaki, Abbr_misogi_halloween, Abbr_ayane, Abbr_misogi, 
            Abbr_hiyori, Abbr_inori, Abbr_tsumugi, Abbr_ruka_summer, Abbr_ayane_christmas, Abbr_eriko_valentine, Abbr_chloe, Abbr_matsuri, Abbr_zyun_summer, Abbr_makoto_summer, 
            Abbr_akino, Abbr_ninon_ooedo, Abbr_hiyori_newyear, Abbr_kaya, Abbr_makoto, Abbr_muimi, Abbr_nozomi, Abbr_kotkoro_newyear, Abbr_ruka, Abbr_pekorinnu_princess, 
            Abbr_pekorinnu, Abbr_rin_deremas, Abbr_rei_newyear, Abbr_kaori, Abbr_kuuka_ooedo, Abbr_zyun, Abbr_kuuka, Abbr_miyako, Abbr_rima, Abbr_kyouka_halloween = "";

        string Abbr_yori_angel, Abbr_labyrista, Abbr_matsuri_halloween, Abbr_rei_halloween, Abbr_tsumugi_halloween, Abbr_akino_christmas, Abbr_saren_christmas, Abbr_yukari_christmas,
            Abbr_monika_magical, Abbr_tomo_magical, Abbr_pekorinnu_newyear, Abbr_muimi_newyear, Abbr_neneka_newyear, Abbr_kyaru_princess = "";

        private void bt_open_abbr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad.exe", "character_abbreviation.txt");
            }
            catch (Exception ee)
            {
#if DEBUG
                Debug.WriteLine(ee);
#endif
                MessageBox.Show("character_abbreviation.txt 파일이 없어!", "알림");
            }
        }

        private void tb_CharaAbbr_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Enter))
            {
                if (isOffDeckReady == false && isDefDeckReady == false)
                {
                    //공덱
                    //int isOfforDef = MessageBox.Show("크아앙1", "알림");
                    SetDeckWithAbbr(tb_CharaAbbr.Text, 0);

                }
                else if (isOffDeckReady == true && isDefDeckReady == false)
                {
                    //방덱
                    //MessageBox.Show("크아앙2", "알림");
                    SetDeckWithAbbr(tb_CharaAbbr.Text, 1);
                }
                else if (isOffDeckReady == true && isDefDeckReady == true)
                {
                    //공덱 덮어쓰기
                    //MessageBox.Show("크아앙3", "알림");
                    SetDeckWithAbbr(tb_CharaAbbr.Text, 0);
                }
                else if (isOffDeckReady == false && isDefDeckReady == true)
                {
                    //공덱
                    //MessageBox.Show("크아앙4", "알림");
                    SetDeckWithAbbr(tb_CharaAbbr.Text, 0);
                }
                else
                {
                    MessageBox.Show("??", "알림");
                }
            }
        }

        private void tb_CharaAbbr_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
            
            
            
        }

        private void SetDeckWithAbbr(string s, int isOfforDef)
        {
            //isOfforDef 0이면 공덱 1이면 방덱

            select_count_temp = 0;
            Debug.Write("select_count = ");
            Debug.WriteLine(select_count);
            isFindOffReady = false;

            //string s = tb_CharaAbbr.Text;
            int numCharacter = 0;
            int numCharaAbbr = 0;
            char[] charArr = s.ToCharArray();

            foreach (char c in charArr)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    Debug.WriteLine("한글입니다");
                    numCharacter++;
                }
            }

            if (numCharacter == 5)
            {
                Debug.WriteLine(tb_CharaAbbr.Text.Length);
                Debug.WriteLine(tb_CharaAbbr.Text);
                Level_variable.star = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.Lv = Enumerable.Repeat<int>(148, 30).ToArray<int>();
                Level_variable.Rank = Enumerable.Repeat<int>(14, 30).ToArray<int>();
                Level_variable.equip = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip1 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip2 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip3 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip4 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip5 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.equip6 = Enumerable.Repeat<bool>(true, 30).ToArray<bool>();
                Level_variable.rf1 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.rf2 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.rf3 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.rf4 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.rf5 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.rf6 = Enumerable.Repeat<int>(5, 30).ToArray<int>();
                Level_variable.UE_Lv = Enumerable.Repeat<int>(150, 30).ToArray<int>();
                Level_variable.power = Enumerable.Repeat<double>(0, 30).ToArray<double>();
                string tempAbbr = tb_CharaAbbr.Text;

                string[] temp = new string[5];
                string[] temp2 = new string[5];
                string[] temp3 = new string[10];
                for (int i = 0; i < 5; i++)
                {
                    temp[i] = AbbrToChara(Convert.ToString(tempAbbr[i]));
                    Debug.WriteLine(string.Format("temp[{0}] = {1}", i, temp[i]));
                    if (temp[i] != "")
                        numCharaAbbr++;

                    temp2[i] = IDtoCharaKorName(CharaNameToID(temp[i]));
                    Debug.WriteLine(string.Format("temp2[{0}] = {1}", i, temp2[i]));
                }
                Debug.Write("numCharaAbbr = ");
                Debug.WriteLine(numCharaAbbr);

                if (numCharaAbbr == 5)
                {
                    temp3 = CharaSort(temp, temp2);

#if DEBUG
                    for (int i = 0; i < 10; i++)
                        Debug.WriteLine(temp3[i]);
#endif

                    select_count = select_count_temp;

                    if(isOfforDef == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            select_offence[i] = temp3[i + 5];
                            select_offence_temp[i] = temp3[i + 5];
                            select_offence_eng[i] = temp3[i];
                            select_offence_temp_eng[i] = temp3[i];
                        }
                        LoadOffDeck();


                        isOffDeckReady = true;

                        MessageBox.Show("공덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp[0], select_offence_temp[1], select_offence_temp[2], select_offence_temp[3], select_offence_temp[4]);
                        Debug.WriteLine("현재 선택된 공덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_offence_temp_eng[0], select_offence_temp_eng[1], select_offence_temp_eng[2], select_offence_temp_eng[3], select_offence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_offence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[19 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[19 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[19 - i]));
                            Debug.WriteLine(" ");
                        }
                        Debug.WriteLine(string.Format("{0:F2}", power_sum_off));
#endif
                        SetOffPower((int)power_sum_off);
                        ShowOffCharas(select_offence_temp_eng);

                        UnCheckAll();
                    }
                    else if(isOfforDef == 1)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            select_defence[i] = temp3[i + 5];
                            select_defence_temp[i] = temp3[i + 5];
                            select_defence_eng[i] = temp3[i];
                            select_defence_temp_eng[i] = temp3[i];
                        }
                        LoadDefDeck();

                        isDefDeckReady = true;

                        MessageBox.Show("방덱이 저장되었습니다", "알림");
#if DEBUG
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp[0], select_defence_temp[1], select_defence_temp[2], select_defence_temp[3], select_defence_temp[4]);
                        Debug.WriteLine("현재 선택된 방덱 캐릭터: {0}, {1}, {2}, {3}, {4}", select_defence_temp_eng[0], select_defence_temp_eng[1], select_defence_temp_eng[2], select_defence_temp_eng[3], select_defence_temp_eng[4]);

                        for (int i = 0; i < 5; i++)
                        {
                            Debug.WriteLine(select_defence[4 - i]);
                            Debug.WriteLine(string.Format("{0}", Level_variable.Lv[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.star[4 - i]));
                            Debug.WriteLine(string.Format("{0}", Level_variable.Rank[4 - i]));
                            Debug.WriteLine(string.Format("{0:F2}", Level_variable.power[4 - i]));
                            Debug.WriteLine(" ");
                        }
                        Debug.WriteLine(string.Format("{0:F2}", power_sum_def));
#endif
                        SetDefPower((int)power_sum_def);
                        ShowDefCharas(select_defence_temp_eng);

                        UnCheckAll();
                    }
                    else
                    {
                        MessageBox.Show("??", "알림");                       
                    }
                    
                }
                else
                {
                    MessageBox.Show("다시 입력하세요", "알림");
                    tb_CharaAbbr.Text = "";
                }
            }
            else
            {
                MessageBox.Show("5명으로 입력하세요", "알림");
                tb_CharaAbbr.Text = "";
            }
        }

        
        

        private void InitializeAbbr()
        {
            StreamReader sr = new StreamReader("character_abbreviation.txt");
            int index = 0;

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                //Debug.WriteLine(s);

                if (temp[0] == "히요리")
                {
                    tb_abbr_hiyori.Text = Abbr_hiyori = temp[1];
                    Debug.WriteLine("히");
                }
                else if (temp[0] == "유이")
                {
                    tb_abbr_yui.Text = Abbr_yui = temp[1];
                    Debug.WriteLine("유이2");
                }
                else if (temp[0] == "레이")
                {
                    tb_abbr_rei.Text = Abbr_rei = temp[1];
                }
                else if (temp[0] == "미소기")
                {
                    tb_abbr_misogi.Text = Abbr_misogi = temp[1];
                }
                else if (temp[0] == "마츠리")
                {
                    tb_abbr_matsuri.Text = Abbr_matsuri = temp[1];
                }
                else if (temp[0] == "아카리")
                {
                    tb_abbr_akari.Text = Abbr_akari = temp[1];
                }
                else if (temp[0] == "미야코")
                {
                    tb_abbr_miyako.Text = Abbr_miyako = temp[1];
                }
                else if (temp[0] == "유키")
                {
                    tb_abbr_yuki.Text = Abbr_yuki = temp[1];
                }
                else if (temp[0] == "안나")
                {
                    tb_abbr_anna.Text = Abbr_anna = temp[1];
                }
                else if (temp[0] == "마호")
                {
                    tb_abbr_maho.Text = Abbr_maho = temp[1];
                }
                else if (temp[0] == "리노")
                {
                    tb_abbr_rino.Text = Abbr_rino = temp[1];
                }
                else if (temp[0] == "하츠네")
                {
                    tb_abbr_hatsune.Text = Abbr_hatsune = temp[1];
                }
                else if (temp[0] == "나나카")
                {
                    tb_abbr_nanaka.Text = Abbr_nanaka = temp[1];
                }
                else if (temp[0] == "카스미")
                {
                    tb_abbr_kasumi.Text = Abbr_kasumi = temp[1];
                }
                else if (temp[0] == "미사토")
                {
                    tb_abbr_misato.Text = Abbr_misato = temp[1];
                }
                else if (temp[0] == "스즈나")
                {
                    tb_abbr_suzuna.Text = Abbr_suzuna = temp[1];
                }
                else if (temp[0] == "카오리")
                {
                    tb_abbr_kaori.Text = Abbr_kaori = temp[1];
                }
                else if (temp[0] == "이오")
                {
                    tb_abbr_io.Text = Abbr_io = temp[1];
                }
                else if (temp[0] == "미미")
                {
                    tb_abbr_mimi.Text = Abbr_mimi = temp[1];
                }
                else if (temp[0] == "쿠루미")
                {
                    tb_abbr_kurumi.Text = Abbr_kurumi = temp[1];
                }
                else if (temp[0] == "요리")
                {
                    tb_abbr_yori.Text = Abbr_yori = temp[1];
                }
                else if (temp[0] == "아야네")
                {
                    tb_abbr_ayane.Text = Abbr_ayane = temp[1];
                }
                else if (temp[0] == "스즈메")
                {
                    tb_abbr_suzume.Text = Abbr_suzume = temp[1];
                }
                else if (temp[0] == "린")
                {
                    tb_abbr_rin.Text = Abbr_rin = temp[1];
                }
                else if (temp[0] == "에리코")
                {
                    tb_abbr_eriko.Text = Abbr_eriko = temp[1];
                }
                else if (temp[0] == "사렌")
                {
                    tb_abbr_saren.Text = Abbr_saren = temp[1];
                }
                else if (temp[0] == "노조미")
                {
                    tb_abbr_nozomi.Text = Abbr_nozomi = temp[1];
                }
                else if (temp[0] == "니논")
                {
                    tb_abbr_ninon.Text = Abbr_ninon = temp[1];
                }
                else if (temp[0] == "시노부")
                {
                    tb_abbr_sinobu.Text = Abbr_sinobu = temp[1];
                }
                else if (temp[0] == "아키노")
                {
                    tb_abbr_akino.Text = Abbr_akino = temp[1];
                }
                else if (temp[0] == "마히루")
                {
                    tb_abbr_mahiru.Text = Abbr_mahiru = temp[1];
                }
                else if (temp[0] == "유카리")
                {
                    tb_abbr_yukari.Text = Abbr_yukari = temp[1];
                }
                else if (temp[0] == "쿄우카")
                {
                    tb_abbr_kyouka.Text = Abbr_kyouka = temp[1];
                }
                else if (temp[0] == "토모")
                {
                    tb_abbr_tomo.Text = Abbr_tomo = temp[1];
                }
                else if (temp[0] == "시오리")
                {
                    tb_abbr_siori.Text = Abbr_siori = temp[1];
                }
                else if (temp[0] == "아오이")
                {
                    tb_abbr_aoi.Text = Abbr_aoi = temp[1];
                }
                else if (temp[0] == "치카")
                {
                    tb_abbr_chika.Text = Abbr_chika = temp[1];
                }
                else if (temp[0] == "마코토")
                {
                    tb_abbr_makoto.Text = Abbr_makoto = temp[1];
                }
                else if (temp[0] == "이리야")
                {
                    tb_abbr_iriya.Text = Abbr_iriya = temp[1];
                }
                else if (temp[0] == "쿠우카")
                {
                    tb_abbr_kuuka.Text = Abbr_kuuka = temp[1];
                }
                else if (temp[0] == "타마키")
                {
                    tb_abbr_tamaki.Text = Abbr_tamaki = temp[1];
                }
                else if (temp[0] == "쥰")
                {
                    tb_abbr_zyun.Text = Abbr_zyun = temp[1];
                }
                else if (temp[0] == "미후유")
                {
                    tb_abbr_mihuyu.Text = Abbr_mihuyu = temp[1];
                }
                else if (temp[0] == "시즈루")
                {
                    tb_abbr_sizuru.Text = Abbr_sizuru = temp[1];
                }
                else if (temp[0] == "미사키")
                {
                    tb_abbr_misaki.Text = Abbr_misaki = temp[1];
                }
                else if (temp[0] == "미츠키")
                {
                    tb_abbr_mitsuki.Text = Abbr_mitsuki = temp[1];
                }
                else if (temp[0] == "리마")
                {
                    tb_abbr_rima.Text = Abbr_rima = temp[1];
                }
                else if (temp[0] == "모니카")
                {
                    tb_abbr_monika.Text = Abbr_monika = temp[1];
                }
                else if (temp[0] == "츠무기")
                {
                    tb_abbr_tsumugi.Text = Abbr_tsumugi = temp[1];
                }
                else if (temp[0] == "아유미")
                {
                    tb_abbr_ayumi.Text = Abbr_ayumi = temp[1];
                }
                else if (temp[0] == "루카")
                {
                    tb_abbr_ruka.Text = Abbr_ruka = temp[1];
                }
                else if (temp[0] == "지타")
                {
                    tb_abbr_zita.Text = Abbr_zita = temp[1];
                }
                else if (temp[0] == "페코린느")
                {
                    tb_abbr_pekorinnu.Text = Abbr_pekorinnu = temp[1];
                }
                else if (temp[0] == "콧코로")
                {
                    tb_abbr_kotkoro.Text = Abbr_kotkoro = temp[1];
                }
                else if (temp[0] == "캬루")
                {
                    tb_abbr_kyaru.Text = Abbr_kyaru = temp[1];
                }
                else if (temp[0] == "무이미")
                {
                    tb_abbr_muimi.Text = Abbr_muimi = temp[1];
                }
                else if (temp[0] == "아리사")
                {
                    tb_abbr_arisa.Text = Abbr_arisa = temp[1];
                }
                else if (temp[0] == "카야")
                {
                    tb_abbr_kaya.Text = Abbr_kaya = temp[1];
                }
                else if (temp[0] == "네네카")
                {
                    tb_abbr_neneka.Text = Abbr_neneka = temp[1];
                }
                else if (temp[0] == "크리스티나")
                {
                    tb_abbr_kristina.Text = Abbr_kristina = temp[1];
                }
                else if (temp[0] == "수페코")
                {
                    tb_abbr_pekorinnu_summer.Text = Abbr_pekorinnu_summer = temp[1];
                }
                else if (temp[0] == "수코로")
                {
                    tb_abbr_kotkoro_summer.Text = Abbr_kotkoro_summer = temp[1];
                }
                else if (temp[0] == "수즈메")
                {
                    tb_abbr_suzume_summer.Text = Abbr_suzume_summer = temp[1];
                }
                else if (temp[0] == "수캬루")
                {
                    tb_abbr_kyaru_summer.Text = Abbr_kyaru_summer = temp[1];
                }
                else if (temp[0] == "수마키")
                {
                    tb_abbr_tamaki_summer.Text = Abbr_tamaki_summer = temp[1];
                }
                else if (temp[0] == "수후유")
                {
                    tb_abbr_mihuyu_summer.Text = Abbr_mihuyu_summer = temp[1];
                }
                else if (temp[0] == "할노부")
                {
                    tb_abbr_sinobu_halloween.Text = Abbr_sinobu_halloween = temp[1];
                }
                else if (temp[0] == "할푸딩")
                {
                    tb_abbr_miyako_halloween.Text = Abbr_miyako_halloween = temp[1];
                }
                else if (temp[0] == "할사키")
                {
                    tb_abbr_misaki_halloween.Text = Abbr_misaki_halloween = temp[1];
                }
                else if (temp[0] == "성치카")
                {
                    tb_abbr_chika_christmas.Text = Abbr_chika_christmas = temp[1];
                }
                else if (temp[0] == "성루미")
                {
                    tb_abbr_kurumi_christmas.Text = Abbr_kurumi_christmas = temp[1];
                }
                else if (temp[0] == "성야네")
                {
                    tb_abbr_ayane_christmas.Text = Abbr_ayane_christmas = temp[1];
                }
                else if (temp[0] == "뉴요리")
                {
                    tb_abbr_hiyori_newyear.Text = Abbr_hiyori_newyear = temp[1];
                }
                else if (temp[0] == "뉴이")
                {
                    tb_abbr_yui_newyear.Text = Abbr_yui_newyear = temp[1];
                }
                else if (temp[0] == "신레이")
                {
                    tb_abbr_rei_newyear.Text = Abbr_rei_newyear = temp[1];
                }
                else if (temp[0] == "발리코")
                {
                    tb_abbr_eriko_valentine.Text = Abbr_eriko_valentine = temp[1];
                }
                else if (temp[0] == "발즈루")
                {
                    tb_abbr_sizuru_valentine.Text = Abbr_sizuru_valentine = temp[1];
                }
                else if (temp[0] == "앤")
                {
                    tb_abbr_anne.Text = Abbr_anne = temp[1];
                }
                else if (temp[0] == "루")
                {
                    tb_abbr_lou.Text = Abbr_lou = temp[1];
                }
                else if (temp[0] == "글레어")
                {
                    tb_abbr_grea.Text = Abbr_grea = temp[1];
                }
                else if (temp[0] == "오우카")
                {
                    tb_abbr_kuuka_ooedo.Text = Abbr_kuuka_ooedo = temp[1];
                }
                else if (temp[0] == "오니논")
                {
                    tb_abbr_ninon_ooedo.Text = Abbr_ninon_ooedo = temp[1];
                }
                else if (temp[0] == "렘")
                {
                    tb_abbr_rem.Text = Abbr_rem = temp[1];
                }
                else if (temp[0] == "람")
                {
                    tb_abbr_ram.Text = Abbr_ram = temp[1];
                }
                else if (temp[0] == "에밀리아")
                {
                    tb_abbr_emilia.Text = Abbr_emilia = temp[1];
                }
                else if (temp[0] == "수즈나")
                {
                    tb_abbr_suzuna_summer.Text = Abbr_suzuna_summer = temp[1];
                }
                else if (temp[0] == "수이오")
                {
                    tb_abbr_io_summer.Text = Abbr_io_summer = temp[1];
                }
                else if (temp[0] == "수사렌")
                {
                    tb_abbr_saren_summer.Text = Abbr_saren_summer = temp[1];
                }
                else if (temp[0] == "수코토")
                {
                    tb_abbr_makoto_summer.Text = Abbr_makoto_summer = temp[1];
                }
                else if (temp[0] == "수오리")
                {
                    tb_abbr_kaori_summer.Text = Abbr_kaori_summer = temp[1];
                }
                else if (temp[0] == "수마호")
                {
                    tb_abbr_maho_summer.Text = Abbr_maho_summer = temp[1];
                }
                else if (temp[0] == "편오이")
                {
                    tb_abbr_aoi_nakayosi.Text = Abbr_aoi_nakayosi = temp[1];
                }
                else if (temp[0] == "클로에")
                {
                    tb_abbr_chloe.Text = Abbr_chloe = temp[1];
                }
                else if (temp[0] == "할쿄카")
                {
                    tb_abbr_kyouka_halloween.Text = Abbr_kyouka_halloween = temp[1];
                }
                else if (temp[0] == "할소기")
                {
                    tb_abbr_misogi_halloween.Text = Abbr_misogi_halloween = temp[1];
                }
                else if (temp[0] == "할미미")
                {
                    tb_abbr_mimi_halloween.Text = Abbr_mimi_halloween = temp[1];
                }
                else if (temp[0] == "루나")
                {
                    tb_abbr_runa.Text = Abbr_runa = temp[1];
                }
                else if (temp[0] == "성리스")
                {
                    tb_abbr_kristina_christmas.Text = Abbr_kristina_christmas = temp[1];
                }
                else if (temp[0] == "성조미")
                {
                    tb_abbr_nozomi_christmas.Text = Abbr_nozomi_christmas = temp[1];
                }
                else if (temp[0] == "성리야")
                {
                    tb_abbr_iriya_christmas.Text = Abbr_iriya_christmas = temp[1];
                }
                else if (temp[0] == "뉴코로")
                {
                    tb_abbr_kotkoro_newyear.Text = Abbr_kotkoro_newyear = temp[1];
                }
                else if (temp[0] == "냐루")
                {
                    tb_abbr_kyaru_newyear.Text = Abbr_kyaru_newyear = temp[1];
                }
                else if (temp[0] == "뉴즈메")
                {
                    tb_abbr_suzume_newyear.Text = Abbr_suzume_newyear = temp[1];
                }
                else if (temp[0] == "마스미")
                {
                    tb_abbr_kasumi_magical.Text = Abbr_kasumi_magical = temp[1];
                }
                else if (temp[0] == "마오리")
                {
                    tb_abbr_siori_magical.Text = Abbr_siori_magical = temp[1];
                }
                else if (temp[0] == "프페코")
                {
                    tb_abbr_pekorinnu_princess.Text = Abbr_pekorinnu_princess = temp[1];
                }
                else if (temp[0] == "우즈키")
                {
                    tb_abbr_uzuki_deremas.Text = Abbr_uzuki_deremas = temp[1];
                }
                else if (temp[0] == "시부린")
                {
                    tb_abbr_rin_deremas.Text = Abbr_rin_deremas = temp[1];
                }
                else if (temp[0] == "미오")
                {
                    tb_abbr_mio_deremas.Text = Abbr_mio_deremas = temp[1];
                }
                else if (temp[0] == "유니")
                {
                    tb_abbr_yuni.Text = Abbr_yuni = temp[1];
                }
                else if (temp[0] == "치에루")
                {
                    tb_abbr_chieru.Text = Abbr_chieru = temp[1];
                }
                else if (temp[0] == "레린")
                {
                    tb_abbr_rin_ranger.Text = Abbr_rin_ranger = temp[1];
                }
                else if (temp[0] == "레히루")
                {
                    tb_abbr_mahiru_ranger.Text = Abbr_mahiru_ranger = temp[1];
                }
                else if (temp[0] == "앨리노")
                {
                    tb_abbr_rino_wonder.Text = Abbr_rino_wonder = temp[1];
                }
                else if (temp[0] == "앨유미")
                {
                    tb_abbr_ayumi_wonder.Text = Abbr_ayumi_wonder = temp[1];
                }
                else if (temp[0] == "수루카")
                {
                    tb_abbr_ruka_summer.Text = Abbr_ruka_summer = temp[1];
                }
                else if (temp[0] == "수안나")
                {
                    tb_abbr_anna_summer.Text = Abbr_anna_summer = temp[1];
                }
                else if (temp[0] == "수나카")
                {
                    tb_abbr_nanaka_summer.Text = Abbr_nanaka_summer = temp[1];
                }
                else if (temp[0] == "수츠네")
                {
                    tb_abbr_hatsune_summer.Text = Abbr_hatsune_summer = temp[1];
                }
                else if (temp[0] == "수사토")
                {
                    tb_abbr_misato_summer.Text = Abbr_misato_summer = temp[1];
                }
                else if (temp[0] == "수쥰")
                {
                    tb_abbr_zyun_summer.Text = Abbr_zyun_summer = temp[1];
                }
                else if (temp[0] == "엔카리")
                {
                    tb_abbr_akari_angel.Text = Abbr_akari_angel = temp[1];
                }
                else if (temp[0] == "프유이")
                {
                    tb_abbr_yui_princess.Text = Abbr_yui_princess = temp[1];
                }
                else if (temp[0] == "프코로")
                {
                    tb_abbr_kotkoro_princess.Text = Abbr_kotkoro_princess = temp[1];
                }
                else if (temp[0] == "프요리")
                {
                    //tb_abbr_hiyori_princess.Text = Abbr_hiyori_princess = temp[1];
                }
                else if (temp[0] == "프캬루")
                {
                    tb_abbr_kyaru_princess.Text = Abbr_kyaru_princess = temp[1];
                }
                else if (temp[0] == "엔요리")
                {
                    tb_abbr_yori_angel.Text = Abbr_yori_angel = temp[1];
                }
                else if (temp[0] == "라비리스타")
                {
                    tb_abbr_labyrista.Text = Abbr_labyrista = temp[1];
                }
                else if (temp[0] == "이노리")
                {
                    tb_abbr_inori.Text = Abbr_inori = temp[1];
                }
                else if (temp[0] == "할무기")
                {
                    tb_abbr_tsumugi_halloween.Text = Abbr_tsumugi_halloween = temp[1];
                }
                else if (temp[0] == "할레이")
                {
                    tb_abbr_rei_halloween.Text = Abbr_rei_halloween = temp[1];
                }
                else if (temp[0] == "할츠리")
                {
                    tb_abbr_matsuri_halloween.Text = Abbr_matsuri_halloween = temp[1];
                }
                else if (temp[0] == "마니카")
                {
                    tb_abbr_monika_magical.Text = Abbr_monika_magical = temp[1];
                }
                else if (temp[0] == "마토모")
                {
                    tb_abbr_tomo_magical.Text = Abbr_tomo_magical = temp[1];
                }
                else if (temp[0] == "성리노")
                {
                    tb_abbr_akino_christmas.Text = Abbr_akino_christmas = temp[1];
                }
                else if (temp[0] == "성사렌")
                {
                    tb_abbr_saren_christmas.Text = Abbr_saren_christmas = temp[1];
                }
                else if (temp[0] == "성카리")
                {
                    tb_abbr_yukari_christmas.Text = Abbr_yukari_christmas = temp[1];
                }
                else if (temp[0] == "뉴이미")
                {
                    tb_abbr_muimi_newyear.Text = Abbr_muimi_newyear = temp[1];
                }
                else if (temp[0] == "뉴네카")
                {
                    tb_abbr_neneka_newyear.Text = Abbr_neneka_newyear = temp[1];
                }
                else if (temp[0] == "뉴페코")
                {
                    tb_abbr_pekorinnu_newyear.Text = Abbr_pekorinnu_newyear = temp[1];
                }
                /*
                else if (temp[0] == "셰피")
                {
                    tb_abbr_sepi.Text = Abbr_sepi = temp[1];
                }
                else if (temp[0] == "의코로")
                {
                    tb_abbr_kotkoro_maiden.Text = Abbr_kotkoro_maiden = temp[1];
                }
                else if (temp[0] == "의유이")
                {
                    tb_abbr_yui_maiden.Text = Abbr_yui_maiden = temp[1];
                }
                else if (temp[0] == "수스미")
                {
                    tb_abbr_kasumi_summer.Text = Abbr_kasumi_summer = temp[1];
                }
                else if (temp[0] == "신리마")
                {
                    tb_abbr_rima_cinderella.Text = Abbr_rima_cinderella = temp[1];
                }
                else if (temp[0] == "신마호")
                {
                    tb_abbr_maho_cinderella.Text = Abbr_maho_cinderella = temp[1];
                }
                else if (temp[0] == "신코토")
                {
                    tb_abbr_makoto_cinderella.Text = Abbr_makoto_cinderella = temp[1];
                }
                else if (temp[0] == "성로에")
                {
                    tb_abbr_chloe_nakayosi2.Text = Abbr_chloe_nakayosi2 = temp[1];
                }
                else if (temp[0] == "성에루")
                {
                    tb_abbr_chieru_nakayosi2.Text = Abbr_chieru_nakayosi2 = temp[1];
                }
                else if (temp[0] == "시노리")
                {
                    tb_abbr_inori_timetravel.Text = Abbr_inori_timetravel = temp[1];
                }
                else if (temp[0] == "시카야")
                {
                    tb_abbr_kaya_timetravel.Text = Abbr_kaya_timetravel = temp[1];
                }
                else if (temp[0] == "작오이")
                {
                    tb_abbr_aoi_worker.Text = Abbr_aoi_worker = temp[1];
                }
                else if (temp[0] == "작마키")
                {
                    tb_abbr_tamaki_worker.Text = Abbr_tamaki_worker = temp[1];
                }
                */
                //Debug.WriteLine(String.Format("index = {0}", index));
                //Debug.WriteLine(string.Format("{0},{1}", temp[0], temp[1]));

            }
            sr.Close();
        }
        private void bt_save_abbr_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("character_abbreviation.txt");
            if(sw != null)
            {
                sw.WriteLine(string.Format("리마,{0}", tb_abbr_rima.Text));
                sw.WriteLine(string.Format("미야코,{0}", tb_abbr_miyako.Text));
                sw.WriteLine(string.Format("쿠우카,{0}", tb_abbr_kuuka.Text));
                sw.WriteLine(string.Format("쥰,{0}", tb_abbr_zyun.Text));
                sw.WriteLine(string.Format("오우카,{0}", tb_abbr_kuuka_ooedo.Text));
                sw.WriteLine(string.Format("카오리,{0}", tb_abbr_kaori.Text));
                sw.WriteLine(string.Format("성사렌,{0}", tb_abbr_saren_christmas.Text));
                sw.WriteLine(string.Format("할무기,{0}", tb_abbr_tsumugi_halloween.Text));
                sw.WriteLine(string.Format("신레이,{0}", tb_abbr_rei_newyear.Text));
                sw.WriteLine(string.Format("시부린,{0}", tb_abbr_rin_deremas.Text));
                sw.WriteLine(string.Format("페코린느,{0}", tb_abbr_pekorinnu.Text));
                sw.WriteLine(string.Format("프페코,{0}", tb_abbr_pekorinnu_princess.Text));
                sw.WriteLine(string.Format("루카,{0}", tb_abbr_ruka.Text));
                sw.WriteLine(string.Format("뉴코로,{0}", tb_abbr_kotkoro_newyear.Text));
                sw.WriteLine(string.Format("노조미,{0}", tb_abbr_nozomi.Text));
                sw.WriteLine(string.Format("무이미,{0}", tb_abbr_muimi.Text));
                sw.WriteLine(string.Format("마코토,{0}", tb_abbr_makoto.Text));
                sw.WriteLine(string.Format("카야,{0}", tb_abbr_kaya.Text));
                sw.WriteLine(string.Format("뉴요리,{0}", tb_abbr_hiyori_newyear.Text));
                sw.WriteLine(string.Format("오니논,{0}", tb_abbr_ninon_ooedo.Text));
                sw.WriteLine(string.Format("아키노,{0}", tb_abbr_akino.Text));
                sw.WriteLine(string.Format("수코토,{0}", tb_abbr_makoto_summer.Text));
                sw.WriteLine(string.Format("수쥰,{0}", tb_abbr_zyun_summer.Text));
                sw.WriteLine(string.Format("마츠리,{0}", tb_abbr_matsuri.Text));
                sw.WriteLine(string.Format("클로에,{0}", tb_abbr_chloe.Text));
                sw.WriteLine(string.Format("할츠리,{0}", tb_abbr_matsuri_halloween.Text));
                sw.WriteLine(string.Format("발리코,{0}", tb_abbr_eriko_valentine.Text));
                sw.WriteLine(string.Format("성키노,{0}", tb_abbr_akino_christmas.Text));
                sw.WriteLine(string.Format("성야네,{0}", tb_abbr_ayane_christmas.Text));
                sw.WriteLine(string.Format("수루카,{0}", tb_abbr_ruka_summer.Text));
                sw.WriteLine(string.Format("츠무기,{0}", tb_abbr_tsumugi.Text));
                sw.WriteLine(string.Format("이노리,{0}", tb_abbr_inori.Text));
                sw.WriteLine(string.Format("히요리,{0}", tb_abbr_hiyori.Text));
                sw.WriteLine(string.Format("미소기,{0}", tb_abbr_misogi.Text));
                sw.WriteLine(string.Format("아야네,{0}", tb_abbr_ayane.Text));
                sw.WriteLine(string.Format("할소기,{0}", tb_abbr_misogi_halloween.Text));
                sw.WriteLine(string.Format("타마키,{0}", tb_abbr_tamaki.Text));
                sw.WriteLine(string.Format("토모,{0}", tb_abbr_tomo.Text));
                sw.WriteLine(string.Format("치에루,{0}", tb_abbr_chieru.Text));
                sw.WriteLine(string.Format("수마키,{0}", tb_abbr_tamaki_summer.Text));
                sw.WriteLine(string.Format("에리코,{0}", tb_abbr_eriko.Text));
                sw.WriteLine(string.Format("수페코,{0}", tb_abbr_pekorinnu_summer.Text));
                sw.WriteLine(string.Format("쿠루미,{0}", tb_abbr_kurumi.Text));
                sw.WriteLine(string.Format("지타,{0}", tb_abbr_zita.Text));
                sw.WriteLine(string.Format("뉴페코,{0}", tb_abbr_pekorinnu_newyear.Text));
                sw.WriteLine(string.Format("레이,{0}", tb_abbr_rei.Text));
                sw.WriteLine(string.Format("성리야,{0}", tb_abbr_iriya_christmas.Text));
                sw.WriteLine(string.Format("수안나,{0}", tb_abbr_anna_summer.Text));
                sw.WriteLine(string.Format("성리스,{0}", tb_abbr_kristina_christmas.Text));
                sw.WriteLine(string.Format("시즈루,{0}", tb_abbr_sizuru.Text));
                sw.WriteLine(string.Format("크리스티나,{0}", tb_abbr_kristina.Text));
                sw.WriteLine(string.Format("성루미,{0}", tb_abbr_kurumi_christmas.Text));


                sw.WriteLine(string.Format("미미,{0}", tb_abbr_mimi.Text));
                sw.WriteLine(string.Format("시노부,{0}", tb_abbr_sinobu.Text));
                sw.WriteLine(string.Format("할미미,{0}", tb_abbr_mimi_halloween.Text));
                sw.WriteLine(string.Format("우즈키,{0}", tb_abbr_uzuki_deremas.Text));
                sw.WriteLine(string.Format("할레이,{0}", tb_abbr_rei_halloween.Text));
                sw.WriteLine(string.Format("발즈루,{0}", tb_abbr_sizuru_valentine.Text));
                sw.WriteLine(string.Format("레히루,{0}", tb_abbr_mahiru_ranger.Text));
                sw.WriteLine(string.Format("마히루,{0}", tb_abbr_mahiru.Text));
                sw.WriteLine(string.Format("마토모,{0}", tb_abbr_tomo_magical.Text));
                sw.WriteLine(string.Format("유카리,{0}", tb_abbr_yukari.Text));
                sw.WriteLine(string.Format("성카리,{0}", tb_abbr_yukari_christmas.Text));
                sw.WriteLine(string.Format("모니카,{0}", tb_abbr_monika.Text));
                sw.WriteLine(string.Format("니논,{0}", tb_abbr_ninon.Text));
                sw.WriteLine(string.Format("성조미,{0}", tb_abbr_nozomi_christmas.Text));
                sw.WriteLine(string.Format("미후유,{0}", tb_abbr_mihuyu.Text));
                sw.WriteLine(string.Format("레린,{0}", tb_abbr_rin_ranger.Text));
                sw.WriteLine(string.Format("이리야,{0}", tb_abbr_iriya.Text));
                sw.WriteLine(string.Format("수오리,{0}", tb_abbr_kaori_summer.Text));
                sw.WriteLine(string.Format("사렌,{0}", tb_abbr_saren.Text));
                sw.WriteLine(string.Format("안나,{0}", tb_abbr_anna.Text));
                sw.WriteLine(string.Format("할노부,{0}", tb_abbr_sinobu_halloween.Text));
                sw.WriteLine(string.Format("수나카,{0}", tb_abbr_nanaka_summer.Text));
                sw.WriteLine(string.Format("수후유,{0}", tb_abbr_mihuyu_summer.Text));
                sw.WriteLine(string.Format("콧코로,{0}", tb_abbr_kotkoro.Text));
                sw.WriteLine(string.Format("앨유미,{0}", tb_abbr_ayumi_wonder.Text));
                sw.WriteLine(string.Format("아유미,{0}", tb_abbr_ayumi.Text));
                sw.WriteLine(string.Format("글레어,{0}", tb_abbr_grea.Text));
                sw.WriteLine(string.Format("마니카,{0}", tb_abbr_monika_magical.Text));
                sw.WriteLine(string.Format("엔카리,{0}", tb_abbr_akari_angel.Text));
                sw.WriteLine(string.Format("엔요리,{0}", tb_abbr_yori_angel.Text));
                sw.WriteLine(string.Format("수코로,{0}", tb_abbr_kotkoro_summer.Text));
                sw.WriteLine(string.Format("렘,{0}", tb_abbr_rem.Text));
                sw.WriteLine(string.Format("람,{0}", tb_abbr_ram.Text));
                sw.WriteLine(string.Format("린,{0}", tb_abbr_rin.Text));
                sw.WriteLine(string.Format("프코로,{0}", tb_abbr_kotkoro_princess.Text));
                sw.WriteLine(string.Format("라비리스타,{0}", tb_abbr_labyrista.Text));
                sw.WriteLine(string.Format("뉴네카,{0}", tb_abbr_neneka_newyear.Text));
                sw.WriteLine(string.Format("미츠키,{0}", tb_abbr_mitsuki.Text));
                sw.WriteLine(string.Format("수츠네,{0}", tb_abbr_hatsune_summer.Text));
                sw.WriteLine(string.Format("아카리,{0}", tb_abbr_akari.Text));
                sw.WriteLine(string.Format("요리,{0}", tb_abbr_yori.Text));
                sw.WriteLine(string.Format("수사렌,{0}", tb_abbr_saren_summer.Text));
                sw.WriteLine(string.Format("할푸딩,{0}", tb_abbr_miyako_halloween.Text));


                sw.WriteLine(string.Format("아리사,{0}", tb_abbr_arisa.Text));
                sw.WriteLine(string.Format("앤,{0}", tb_abbr_anne.Text));
                sw.WriteLine(string.Format("루,{0}", tb_abbr_lou.Text));
                sw.WriteLine(string.Format("네네카,{0}", tb_abbr_neneka.Text));
                sw.WriteLine(string.Format("편오이,{0}", tb_abbr_aoi_nakayosi.Text));
                sw.WriteLine(string.Format("냐루,{0}", tb_abbr_kyaru_newyear.Text));
                sw.WriteLine(string.Format("미오,{0}", tb_abbr_mio_deremas.Text));
                sw.WriteLine(string.Format("수사토,{0}", tb_abbr_misato_summer.Text));
                sw.WriteLine(string.Format("리노,{0}", tb_abbr_rino.Text));
                sw.WriteLine(string.Format("스즈나,{0}", tb_abbr_suzuna.Text));
                sw.WriteLine(string.Format("수즈나,{0}", tb_abbr_suzuna_summer.Text));
                sw.WriteLine(string.Format("시오리,{0}", tb_abbr_siori.Text));
                sw.WriteLine(string.Format("마오리,{0}", tb_abbr_siori_magical.Text));
                sw.WriteLine(string.Format("이오,{0}", tb_abbr_io.Text));
                sw.WriteLine(string.Format("수이오,{0}", tb_abbr_io_summer.Text));
                sw.WriteLine(string.Format("스즈메,{0}", tb_abbr_suzume.Text));
                sw.WriteLine(string.Format("뉴즈메,{0}", tb_abbr_suzume_newyear.Text));
                sw.WriteLine(string.Format("에밀리아,{0}", tb_abbr_emilia.Text));
                sw.WriteLine(string.Format("카스미,{0}", tb_abbr_kasumi.Text));
                sw.WriteLine(string.Format("마스미,{0}", tb_abbr_kasumi_magical.Text));
                sw.WriteLine(string.Format("앨리노,{0}", tb_abbr_rino_wonder.Text));
                sw.WriteLine(string.Format("미사토,{0}", tb_abbr_misato.Text));
                sw.WriteLine(string.Format("나나카,{0}", tb_abbr_nanaka.Text));
                sw.WriteLine(string.Format("뉴이,{0}", tb_abbr_yui_newyear.Text));
                sw.WriteLine(string.Format("프캬루,{0}", tb_abbr_kyaru_princess.Text));
                sw.WriteLine(string.Format("캬루,{0}", tb_abbr_kyaru.Text));
                sw.WriteLine(string.Format("하츠네,{0}", tb_abbr_hatsune.Text));
                sw.WriteLine(string.Format("미사키,{0}", tb_abbr_misaki.Text));
                sw.WriteLine(string.Format("루나,{0}", tb_abbr_runa.Text));
                sw.WriteLine(string.Format("프유이,{0}", tb_abbr_yui_princess.Text));
                sw.WriteLine(string.Format("성치카,{0}", tb_abbr_chika_christmas.Text));
                sw.WriteLine(string.Format("수즈메,{0}", tb_abbr_suzume_summer.Text));
                sw.WriteLine(string.Format("수캬루,{0}", tb_abbr_kyaru_summer.Text));
                sw.WriteLine(string.Format("아오이,{0}", tb_abbr_aoi.Text));
                sw.WriteLine(string.Format("치카,{0}", tb_abbr_chika.Text));
                sw.WriteLine(string.Format("수마호,{0}", tb_abbr_maho_summer.Text));
                sw.WriteLine(string.Format("마호,{0}", tb_abbr_maho.Text));
                sw.WriteLine(string.Format("유이,{0}", tb_abbr_yui.Text));
                sw.WriteLine(string.Format("유키,{0}", tb_abbr_yuki.Text));
                sw.WriteLine(string.Format("유니,{0}", tb_abbr_yuni.Text));
                sw.WriteLine(string.Format("쿄우카,{0}", tb_abbr_kyouka.Text));
                sw.WriteLine(string.Format("할사키,{0}", tb_abbr_misaki_halloween.Text));
                sw.WriteLine(string.Format("할쿄카,{0}", tb_abbr_kyouka_halloween.Text));

                sw.Close();

                Abbr_rima = tb_abbr_rima.Text;
                Abbr_miyako = tb_abbr_miyako.Text;
                Abbr_kuuka = tb_abbr_kuuka.Text;
                Abbr_zyun = tb_abbr_zyun.Text;
                Abbr_muimi_newyear = tb_abbr_muimi_newyear.Text;
                Abbr_kuuka_ooedo = tb_abbr_kuuka_ooedo.Text;
                Abbr_kaori = tb_abbr_kaori.Text;
                Abbr_saren_christmas = tb_abbr_saren_christmas.Text;
                Abbr_tsumugi_halloween = tb_abbr_tsumugi_halloween.Text;
                Abbr_rei_newyear = tb_abbr_rei_newyear.Text;
                Abbr_rin_deremas = tb_abbr_rin_deremas.Text;
                Abbr_pekorinnu =   tb_abbr_pekorinnu.Text;
                Abbr_pekorinnu_princess = tb_abbr_pekorinnu_princess.Text;
                Abbr_ruka = tb_abbr_ruka.Text;
                Abbr_kotkoro_newyear = tb_abbr_kotkoro_newyear.Text;
                Abbr_nozomi = tb_abbr_nozomi.Text;
                Abbr_muimi = tb_abbr_muimi.Text;
                Abbr_makoto = tb_abbr_makoto.Text;
                Abbr_kaya = tb_abbr_kaya.Text;
                Abbr_hiyori_newyear = tb_abbr_hiyori_newyear.Text;
                Abbr_ninon_ooedo = tb_abbr_ninon_ooedo.Text;
                Abbr_akino = tb_abbr_akino.Text;
                Abbr_makoto_summer = tb_abbr_makoto_summer.Text;
                Abbr_zyun_summer = tb_abbr_zyun_summer.Text;
                Abbr_matsuri = tb_abbr_matsuri.Text;
                Abbr_chloe = tb_abbr_chloe.Text;
                Abbr_eriko_valentine = tb_abbr_eriko_valentine.Text;
                Abbr_ayane_christmas = tb_abbr_ayane_christmas.Text;
                Abbr_ruka_summer = tb_abbr_ruka_summer.Text;
                Abbr_tsumugi = tb_abbr_tsumugi.Text;
                Abbr_inori = tb_abbr_inori.Text;
                Abbr_hiyori = tb_abbr_hiyori.Text;
                Abbr_misogi = tb_abbr_misogi.Text;
                Abbr_ayane = tb_abbr_ayane.Text;
                Abbr_misogi_halloween = tb_abbr_misogi_halloween.Text;
                Abbr_tamaki = tb_abbr_tamaki.Text;
                Abbr_tomo = tb_abbr_tomo.Text;
                Abbr_chieru = tb_abbr_chieru.Text;
                Abbr_tamaki_summer = tb_abbr_tamaki_summer.Text;
                Abbr_eriko = tb_abbr_eriko.Text;
                Abbr_pekorinnu_summer = tb_abbr_pekorinnu_summer.Text;
                Abbr_kurumi = tb_abbr_kurumi.Text;
                Abbr_zita = tb_abbr_zita.Text;
                Abbr_pekorinnu_newyear = tb_abbr_pekorinnu_newyear.Text;
                Abbr_rei = tb_abbr_rei.Text;
                Abbr_iriya_christmas = tb_abbr_iriya_christmas.Text;
                Abbr_anna_summer = tb_abbr_anna_summer.Text;
                Abbr_kristina_christmas = tb_abbr_kristina_christmas.Text;
                Abbr_sizuru = tb_abbr_sizuru.Text;
                Abbr_kristina =  tb_abbr_kristina.Text;
                Abbr_kurumi_christmas = 	tb_abbr_kurumi_christmas.Text;
	
	
                Abbr_mimi = 	tb_abbr_mimi.Text;
                Abbr_sinobu = 	tb_abbr_sinobu.Text;
                Abbr_mimi_halloween = 	tb_abbr_mimi_halloween.Text;
                Abbr_uzuki_deremas = 	tb_abbr_uzuki_deremas.Text;
                Abbr_rei_halloween = tb_abbr_rei_halloween.Text;
                Abbr_sizuru_valentine = 	tb_abbr_sizuru_valentine.Text;
                Abbr_mahiru_ranger = 	tb_abbr_mahiru_ranger.Text;
                Abbr_mahiru = 	tb_abbr_mahiru.Text;
                Abbr_yukari = 	tb_abbr_yukari.Text;
                Abbr_yukari_christmas = tb_abbr_yukari_christmas.Text;
                Abbr_monika = 	tb_abbr_monika.Text;
                Abbr_ninon = 	tb_abbr_ninon.Text;
                Abbr_nozomi_christmas = 	tb_abbr_nozomi_christmas.Text;
                Abbr_mihuyu = 	tb_abbr_mihuyu.Text;
                Abbr_rin_ranger = 	tb_abbr_rin_ranger.Text;
                Abbr_iriya = 	tb_abbr_iriya.Text;
                Abbr_kaori_summer = 	tb_abbr_kaori_summer.Text;
                Abbr_saren = 	tb_abbr_saren.Text;
                Abbr_anna = 	tb_abbr_anna.Text;
                Abbr_sinobu_halloween = 	tb_abbr_sinobu_halloween.Text;
                Abbr_nanaka_summer = 	tb_abbr_nanaka_summer.Text;
                Abbr_mihuyu_summer = 	tb_abbr_mihuyu_summer.Text;
                Abbr_kotkoro = 	tb_abbr_kotkoro.Text;
                Abbr_ayumi_wonder = 	tb_abbr_ayumi_wonder.Text;
                Abbr_ayumi = 	tb_abbr_ayumi.Text;
                Abbr_grea = 	tb_abbr_grea.Text;
                Abbr_monika_magical = tb_abbr_monika_magical.Text;
                Abbr_akari_angel = 	tb_abbr_akari_angel.Text;
                Abbr_yori_angel = 	tb_abbr_yori_angel.Text;
                Abbr_kotkoro_summer = 	tb_abbr_kotkoro_summer.Text;
                Abbr_rem = 	tb_abbr_rem.Text;
                Abbr_ram = 	tb_abbr_ram.Text;
                Abbr_rin = 	tb_abbr_rin.Text;
                Abbr_kotkoro_princess = 	tb_abbr_kotkoro_princess.Text;
                Abbr_labyrista = 	tb_abbr_labyrista.Text;
                Abbr_neneka_newyear = tb_abbr_neneka_newyear.Text;
                Abbr_mitsuki = 	tb_abbr_mitsuki.Text;
                Abbr_hatsune_summer = 	tb_abbr_hatsune_summer.Text;
                Abbr_akari = 	tb_abbr_akari.Text;
                Abbr_yori = 	tb_abbr_yori.Text;
                Abbr_saren_summer = 	tb_abbr_saren_summer.Text;
                Abbr_miyako_halloween = 	tb_abbr_miyako_halloween.Text;
	
	
                Abbr_arisa = 	tb_abbr_arisa.Text;
                Abbr_anne = 	tb_abbr_anne.Text;
                Abbr_lou = 	tb_abbr_lou.Text;
                Abbr_neneka = 	tb_abbr_neneka.Text;
                Abbr_aoi_nakayosi = 	tb_abbr_aoi_nakayosi.Text;
                Abbr_kyaru_newyear = 	tb_abbr_kyaru_newyear.Text;
                Abbr_mio_deremas = 	tb_abbr_mio_deremas.Text;
                Abbr_misato_summer = 	tb_abbr_misato_summer.Text;
                Abbr_rino = 	tb_abbr_rino.Text;
                Abbr_suzuna = 	tb_abbr_suzuna.Text;
                Abbr_suzuna_summer = 	tb_abbr_suzuna_summer.Text;
                Abbr_siori = 	tb_abbr_siori.Text;
                Abbr_siori_magical = 	tb_abbr_siori_magical.Text;
                Abbr_io = 	tb_abbr_io.Text;
                Abbr_io_summer = 	tb_abbr_io_summer.Text;
                Abbr_suzume = 	tb_abbr_suzume.Text;
                Abbr_suzume_newyear = 	tb_abbr_suzume_newyear.Text;
                Abbr_emilia = 	tb_abbr_emilia.Text;
                Abbr_kasumi = 	tb_abbr_kasumi.Text;
                Abbr_kasumi_magical = 	tb_abbr_kasumi_magical.Text;
                Abbr_rino_wonder = 	tb_abbr_rino_wonder.Text;
                Abbr_misato = 	tb_abbr_misato.Text;
                Abbr_nanaka = 	tb_abbr_nanaka.Text;
                Abbr_yui_newyear = 	tb_abbr_yui_newyear.Text;
                Abbr_kyaru_princess = tb_abbr_kyaru_princess.Text;
                Abbr_kyaru = 	tb_abbr_kyaru.Text;
                Abbr_hatsune = 	tb_abbr_hatsune.Text;
                Abbr_misaki = 	tb_abbr_misaki.Text;
                Abbr_runa = 	tb_abbr_runa.Text;
                Abbr_yui_princess = 	tb_abbr_yui_princess.Text;
                Abbr_chika_christmas = 	tb_abbr_chika_christmas.Text;
                Abbr_suzume_summer = 	tb_abbr_suzume_summer.Text;
                Abbr_kyaru_summer = 	tb_abbr_kyaru_summer.Text;
                Abbr_aoi = 	tb_abbr_aoi.Text;
                Abbr_chika = 	tb_abbr_chika.Text;
                Abbr_maho_summer = 	tb_abbr_maho_summer.Text;
                Abbr_maho = 	tb_abbr_maho.Text;
                Abbr_yui = 	tb_abbr_yui.Text;
                Abbr_yuki = 	tb_abbr_yuki.Text;
                Abbr_yuni = 	tb_abbr_yuni.Text;
                Abbr_kyouka = 	tb_abbr_kyouka.Text;
                Abbr_misaki_halloween = 	tb_abbr_misaki_halloween.Text;
                Abbr_kyouka_halloween = 	tb_abbr_kyouka_halloween.Text;

                MessageBox.Show("저장해썽!", "알림");
            }
            else
            {
                MessageBox.Show("ㅁ?ㄹ", "알림");
            }
        }
        private void bt_read_abbr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InitializeAbbr();
                MessageBox.Show("불러왔어!", "알림");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "알림");
            }

        }

        
        private string AbbrToChara (string abbrChara)
        {
            if (abbrChara == Abbr_rima) return "rima";
            else if (abbrChara == Abbr_miyako) return "miyako";
            else if (abbrChara == Abbr_kuuka) return "kuuka";
            else if (abbrChara == Abbr_zyun) return "zyun";
            else if (abbrChara == Abbr_muimi_newyear) return "muimi_newyear";
            else if (abbrChara == Abbr_kuuka_ooedo) return "kuuka_ooedo";
            else if (abbrChara == Abbr_kaori) return "kaori";
            else if (abbrChara == Abbr_saren_christmas) return "saren_christmas";
            else if (abbrChara == Abbr_tsumugi_halloween) return "tsumugi_halloween";
            else if (abbrChara == Abbr_rei_newyear) return "rei_newyear";
            else if (abbrChara == Abbr_rin_deremas) return "rin_deremas";
            else if (abbrChara == Abbr_pekorinnu) return "pekorinnu";
            else if (abbrChara == Abbr_pekorinnu_princess) return "pekorinnu_princess";
            else if (abbrChara == Abbr_ruka) return "ruka";
            else if (abbrChara == Abbr_kotkoro_newyear) return "kotkoro_newyear";
            else if (abbrChara == Abbr_nozomi) return "nozomi";
            else if (abbrChara == Abbr_muimi) return "muimi";
            else if (abbrChara == Abbr_makoto) return "makoto";
            else if (abbrChara == Abbr_kaya) return "kaya";
            else if (abbrChara == Abbr_hiyori_newyear) return "hiyori_newyear";
            else if (abbrChara == Abbr_ninon_ooedo) return "ninon_ooedo";
            else if (abbrChara == Abbr_akino) return "akino";
            else if (abbrChara == Abbr_makoto_summer) return "makoto_summer";
            else if (abbrChara == Abbr_zyun_summer) return "zyun_summer";
            else if (abbrChara == Abbr_matsuri) return "matsuri";
            else if (abbrChara == Abbr_chloe) return "chloe";
            else if (abbrChara == Abbr_matsuri_halloween) return "matsuri_halloween";
            else if (abbrChara == Abbr_eriko_valentine) return "eriko_valentine";
            else if (abbrChara == Abbr_akino_christmas) return "akino_christmas";
            else if (abbrChara == Abbr_ayane_christmas) return "ayane_christmas";
            else if (abbrChara == Abbr_ruka_summer) return "ruka_summer";
            else if (abbrChara == Abbr_tsumugi) return "tsumugi";
            else if (abbrChara == Abbr_inori) return "inori";
            else if (abbrChara == Abbr_hiyori) return "hiyori";
            else if (abbrChara == Abbr_misogi) return "misogi";
            else if (abbrChara == Abbr_ayane) return "ayane";
            else if (abbrChara == Abbr_misogi_halloween) return "misogi_halloween";
            else if (abbrChara == Abbr_tamaki) return "tamaki";
            else if (abbrChara == Abbr_tomo) return "tomo";
            else if (abbrChara == Abbr_chieru) return "chieru";
            else if (abbrChara == Abbr_tamaki_summer) return "tamaki_summer";
            else if (abbrChara == Abbr_eriko) return "eriko";
            else if (abbrChara == Abbr_pekorinnu_summer) return "pekorinnu_summer";
            else if (abbrChara == Abbr_kurumi) return "kurumi";
            else if (abbrChara == Abbr_zita) return "zita";
            else if (abbrChara == Abbr_pekorinnu_newyear) return "pekorinnu_newyear";
            else if (abbrChara == Abbr_rei) return "rei";
            else if (abbrChara == Abbr_iriya_christmas) return "iriya_christmas";
            else if (abbrChara == Abbr_anna_summer) return "anna_summer";
            else if (abbrChara == Abbr_kristina_christmas) return "kristina_christmas";
            else if (abbrChara == Abbr_sizuru) return "sizuru";
            else if (abbrChara == Abbr_kristina) return "kristina";
            else if (abbrChara == Abbr_kurumi_christmas) return "kurumi_christmas";


            else if (abbrChara == Abbr_mimi) return "mimi";
            else if (abbrChara == Abbr_sinobu) return "sinobu";
            else if (abbrChara == Abbr_mimi_halloween) return "mimi_halloween";
            else if (abbrChara == Abbr_uzuki_deremas) return "uzuki_deremas";
            else if (abbrChara == Abbr_rei_halloween) return "rei_halloween";
            else if (abbrChara == Abbr_sizuru_valentine) return "sizuru_valentine";
            else if (abbrChara == Abbr_mahiru_ranger) return "mahiru_ranger";
            else if (abbrChara == Abbr_mahiru) return "mahiru";
            else if (abbrChara == Abbr_tomo_magical) return "tomo_magical";
            else if (abbrChara == Abbr_yukari) return "yukari";
            else if (abbrChara == Abbr_yukari_christmas) return "yukari_christmas";
            else if (abbrChara == Abbr_monika) return "monika";
            else if (abbrChara == Abbr_ninon) return "ninon";
            else if (abbrChara == Abbr_nozomi_christmas) return "nozomi_christmas";
            else if (abbrChara == Abbr_mihuyu) return "mihuyu";
            else if (abbrChara == Abbr_rin_ranger) return "rin_ranger";
            else if (abbrChara == Abbr_iriya) return "iriya";
            else if (abbrChara == Abbr_kaori_summer) return "kaori_summer";
            else if (abbrChara == Abbr_saren) return "saren";
            else if (abbrChara == Abbr_anna) return "anna";
            else if (abbrChara == Abbr_sinobu_halloween) return "sinobu_halloween";
            else if (abbrChara == Abbr_nanaka_summer) return "nanaka_summer";
            else if (abbrChara == Abbr_mihuyu_summer) return "mihuyu_summer";
            else if (abbrChara == Abbr_kotkoro) return "kotkoro";
            else if (abbrChara == Abbr_ayumi_wonder) return "ayumi_wonder";
            else if (abbrChara == Abbr_ayumi) return "ayumi";
            else if (abbrChara == Abbr_grea) return "grea";
            else if (abbrChara == Abbr_monika_magical) return "monika_magical";
            else if (abbrChara == Abbr_akari_angel) return "akari_angel";
            else if (abbrChara == Abbr_yori_angel) return "yori_angel";
            else if (abbrChara == Abbr_kotkoro_summer) return "kotkoro_summer";
            else if (abbrChara == Abbr_rem) return "rem";
            else if (abbrChara == Abbr_ram) return "ram";
            else if (abbrChara == Abbr_rin) return "rin";
            else if (abbrChara == Abbr_kotkoro_princess) return "kotkoro_princess";
            else if (abbrChara == Abbr_labyrista) return "labyrista";
            else if (abbrChara == Abbr_neneka_newyear) return "neneka_newyear";
            else if (abbrChara == Abbr_mitsuki) return "mitsuki";
            else if (abbrChara == Abbr_hatsune_summer) return "hatsune_summer";
            else if (abbrChara == Abbr_akari) return "akari";
            else if (abbrChara == Abbr_yori) return "yori";
            else if (abbrChara == Abbr_saren_summer) return "saren_summer";
            else if (abbrChara == Abbr_miyako_halloween) return "miyako_halloween";


            else if (abbrChara == Abbr_arisa) return "arisa";
            else if (abbrChara == Abbr_anne) return "anne";
            else if (abbrChara == Abbr_lou) return "lou";
            else if (abbrChara == Abbr_neneka) return "neneka";
            else if (abbrChara == Abbr_aoi_nakayosi) return "aoi_nakayosi";
            else if (abbrChara == Abbr_kyaru_newyear) return "kyaru_newyear";
            else if (abbrChara == Abbr_mio_deremas) return "mio_deremas";
            else if (abbrChara == Abbr_misato_summer) return "misato_summer";
            else if (abbrChara == Abbr_rino) return "rino";
            else if (abbrChara == Abbr_suzuna) return "suzuna";
            else if (abbrChara == Abbr_suzuna_summer) return "suzuna_summer";
            else if (abbrChara == Abbr_siori) return "siori";
            else if (abbrChara == Abbr_siori_magical) return "siori_magical";
            else if (abbrChara == Abbr_io) return "io";
            else if (abbrChara == Abbr_io_summer) return "io_summer";
            else if (abbrChara == Abbr_suzume) return "suzume";
            else if (abbrChara == Abbr_suzume_newyear) return "suzume_newyear";
            else if (abbrChara == Abbr_emilia) return "emilia";
            else if (abbrChara == Abbr_kasumi) return "kasumi";
            else if (abbrChara == Abbr_kasumi_magical) return "kasumi_magical";
            else if (abbrChara == Abbr_rino_wonder) return "rino_wonder";
            else if (abbrChara == Abbr_misato) return "misato";
            else if (abbrChara == Abbr_nanaka) return "nanaka";
            else if (abbrChara == Abbr_yui_newyear) return "yui_newyear";
            else if (abbrChara == Abbr_kyaru_princess) return "kyaru_princess";
            else if (abbrChara == Abbr_kyaru) return "kyaru";
            else if (abbrChara == Abbr_hatsune) return "hatsune";
            else if (abbrChara == Abbr_misaki) return "misaki";
            else if (abbrChara == Abbr_runa) return "runa";
            else if (abbrChara == Abbr_yui_princess) return "yui_princess";
            else if (abbrChara == Abbr_chika_christmas) return "chika_christmas";
            else if (abbrChara == Abbr_suzume_summer) return "suzume_summer";
            else if (abbrChara == Abbr_kyaru_summer) return "kyaru_summer";
            else if (abbrChara == Abbr_aoi) return "aoi";
            else if (abbrChara == Abbr_chika) return "chika";
            else if (abbrChara == Abbr_maho_summer) return "maho_summer";
            else if (abbrChara == Abbr_maho) return "maho";
            else if (abbrChara == Abbr_yui) return "yui";
            else if (abbrChara == Abbr_yuki) return "yuki";
            else if (abbrChara == Abbr_yuni) return "yuni";
            else if (abbrChara == Abbr_kyouka) return "kyouka";
            else if (abbrChara == Abbr_misaki_halloween) return "misaki_halloween";
            else if (abbrChara == Abbr_kyouka_halloween) return "kyouka_halloween";
            else return "";
        }

        #endregion

        // 업데이트 탭

        #region Update
        private void UpdateCheck()
        {
            if (File.Exists(fileName + ".old"))
            {
                System.IO.File.Delete(fileName + ".old");
            }
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            Debug.WriteLine(System.Environment.CurrentDirectory);
            AutoUpdater.Synchronous = true;
            AutoUpdater.DownloadPath = System.Environment.CurrentDirectory;
            AutoUpdater.Start(@"https://raw.githubusercontent.com/SoKae1/PCRD_KR_ArenaSim/master/PCRD_KR_ArenaSim_WPF/bin/x64/Release/UpdateInfo.xml");
            //https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/latest/download/PCRD_KR_ArenaSim.exe
            AutoUpdater.AppTitle = "프리코네 아레나 시뮬레이터";
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.ReportErrors = true;
            WriteUpdateInfoXml();
        }
        private void bt_UpdateCheck_Click(object sender, RoutedEventArgs e)
        {
            
                Rtb_info_update.Document.Blocks.Clear();
            Rtb_info_update.Document.Blocks.Add(new Paragraph(new Run(Environment.NewLine + Environment.NewLine + "업데이트 로그: " + Environment.NewLine + AgilityTest() )));

            UpdateCheck();
        }


        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    System.Windows.Forms.DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            System.Windows.Forms.MessageBox.Show(
                                $@"새 버전 {args.CurrentVersion} 이 있어요! You are using version {args.InstalledVersion}. This is required update. Press Ok to begin updating the application.", @"알림",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            System.Windows.Forms.MessageBox.Show(
                                $@"새 버전 {args.CurrentVersion} 이 있습니다! 지금 실행한 버전은 {
                                        args.InstalledVersion
                                    }입니다. 지금 업데이트 하시겠습니까?" , @"알림",
                                System.Windows.Forms.MessageBoxButtons.YesNo,
                                System.Windows.Forms.MessageBoxIcon.Information); ; ;
                    }

                    // Uncomment the following line if you want to show standard update dialog instead.
                    //AutoUpdater.ShowUpdateForm(args);
                    if (dialogResult.Equals(System.Windows.Forms.DialogResult.Yes) || dialogResult.Equals(System.Windows.Forms.DialogResult.OK))
                    {
                        try
                        {
                            DeleteOldFile();
                            System.IO.File.Move(fileName, fileName + ".old");
                            Debug.WriteLine("1");
                            Debug.WriteLine("Change!");

                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Debug.WriteLine("다운로드 완료!");

                                this.Close();
                            }
                        }
                        catch (Exception exception)
                        {
                            System.Windows.Forms.MessageBox.Show(exception.Message, exception.GetType().ToString(), System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(@"없데이트", @"알림",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is System.Net.WebException)
                {
                    System.Windows.Forms.MessageBox.Show(
                        @"인터넷 연결에 문제가 있어.",
                        @"알림", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        private void WriteUpdateInfoXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineOnAttributes = true;
            XmlWriter wr = XmlWriter.Create("UpdateInfo.xml", settings);
            wr.WriteStartDocument();
            Debug.WriteLine("Xml");
            wr.WriteStartElement("item");
            wr.WriteElementString("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Debug.WriteLine("Xml1");
            wr.WriteElementString("url", @"https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/download/"
+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + @"/PCRD_KR_ArenaSim.exe");
            Debug.WriteLine("Xml2");
            wr.WriteElementString("changelog", @"https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/tag/"
+ System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + @"/");
            wr.WriteElementString("mandatory", "false");
            Debug.WriteLine("Xml3");
            wr.WriteEndElement();
            wr.WriteEndDocument();
            wr.Close();
            Debug.WriteLine("Xml4");
        }

        private void DeleteOldFile()
        {
            if (File.Exists(fileName + ".old"))
            {
                System.IO.File.Delete(fileName + ".old");
                Debug.WriteLine("Deleted old file");
            }
            else
                Debug.WriteLine("No old file exist");
        }

        private void WebTest()
        {
            //WebRequest와 WebResponse를 이용하여

            //응답요청을 한다
            WebRequest request = null;
            WebResponse response = null;

            //스트림으로 받아온다
            Stream resStream = null;
            StreamReader resReader = null;

            try
            {
                //URI를 입력받는다
                String uriString = @"https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/latest/";

                //URI로부터 요청을 생성한다
                request = WebRequest.Create(uriString.Trim());

                //요청을 보내고 응답을 받는다
                response = request.GetResponse();

                //응답을 스트림으로 얻어온다
                resStream = response.GetResponseStream();
                resReader = new StreamReader(resStream);

                //결과를 출력
                string resString = resReader.ReadToEnd();
                Debug.WriteLine(resString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (resReader != null) resReader.Close();
                if (response != null) response.Close();
            }
        }

        private string AgilityTest()
        {
            var html = @"https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/latest/"; ;

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);
            HtmlNodeCollection divNodes = htmlDoc.DocumentNode.SelectNodes(@"//body/div[@class='application-main ']/div/main/div[@class='clearfix new-discussion-timeline container-xl px-3 px-md-4 px-lg-5']/div/div/div[@class='Box']/div[@class='Box-body']");
            string data = "";
            foreach (HtmlNode node in divNodes)
            {
                HtmlNode span = node.SelectSingleNode("div[@class='markdown-body my-3']");
                data = span.InnerText;
            }
            Debug.WriteLine(data);
            return data;
        }

        #endregion

        // 제작자 탭

        #region maker
        private void InitialText()
        {
            Rtb_info_maker.Document.Blocks.Clear();
            Rtb_info_maker.Document.Blocks.Add(new Paragraph(new Run(" ")));

            AddHyperlinkText("https://github.com/aattat/priconne_redive_kr_arena_simulator/", "https://github.com/aattat/priconne_redive_kr_arena_simulator/",
               " 원작(프바) : ", " ");

            Rtb_info_maker.Document.Blocks.Add(new Paragraph(new Run(" ")));

            AddHyperlinkText("https://github.com/SoKae1/PCRD_KR_ArenaSim/releases/", "소개 (UID : 233 *** 916 ***)",
                "  돚거 후 수정 :  ", " ");
            Rtb_info_maker.Document.Blocks.Add(new Paragraph());
            AddHyperlinkText("https://visualstudio.microsoft.com/ko/thank-you-downloading-visual-studio/?sku=Community&rel=16", "https://visualstudio.microsoft.com/ko/thank-you-downloading-visual-studio/?sku=Community&rel=16",
               " 비주얼 스튜디오 2019 커뮤니티 : ", " ");


            AddHyperlinkText("https://github.com/shimat/opencvsharp/", "https://github.com/shimat/opencvsharp/",
               " Opencvsharp : ", " ");
            AddHyperlinkText("https://stackoverflow.com/questions/tagged/c%23", "https://stackoverflow.com/questions/tagged/c%23",
               " Stackoverflow C# : ", " ");
        
            AddHyperlinkText("https://www.pyimagesearch.com/2015/01/26/multi-scale-template-matching-using-python-opencv/", "https://www.pyimagesearch.com/2015/01/26/multi-scale-template-matching-using-python-opencv/",
               " 이미지 서치 : ", " ");
            AddHyperlinkText("https://html-agility-pack.net/", "https://html-agility-pack.net/",
               " Html Agility Pack : ", " "); 
            AddHyperlinkText("https://github.com/ravibpatel/AutoUpdater.NET/releases", "https://github.com/ravibpatel/AutoUpdater.NET/releases",
                " AutoUpdater.NET : ", " ");

            AddHyperlinkText("https://notepad-plus-plus.org/downloads/", "https://notepad-plus-plus.org/downloads/",
               " Notepad++ : ", " ");
            Rtb_info_maker.Document.Blocks.Add(new Paragraph(new Run(@"")));
            AddHyperlinkText("https://www.gg.go.kr/archives/3734940", "https://www.gg.go.kr/archives/3734940",
               " 경기천년체 : ", " ");
            AddHyperlinkText("https://redive.estertion.win/", "https://redive.estertion.win/",
               " 아이콘 퍼온 곳 : ", " ");
            AddHyperlinkText("https://github.com/HerDataSam/KasumiNotes/releases", "https://github.com/HerDataSam/KasumiNotes/releases",
               " 카스미노트 : ", " ");
            AddHyperlinkText("https://redive.estertion.win/spine/", "https://redive.estertion.win/spine/",
               " 프리코네 모션 시뮬레이터 : ", " ");

            AddHyperlinkText("https://github.com/esterTion/redive_master_db_diff/", "https://github.com/esterTion/redive_master_db_diff/",
               " 일섭 DB : ", " "); 
            AddHyperlinkText("https://github.com/HerDataSam/redive_kr_db_diff", "https://github.com/HerDataSam/redive_kr_db_diff",
                " 한섭 DB : ", " ");
        
            AddHyperlinkText("https://rwiki.jp/priconne_redive/", "https://rwiki.jp/priconne_redive/",
               " R위키 : ", " ");
            AddHyperlinkText("https://pcredivewiki.tw/", "https://pcredivewiki.tw/",
               " 머만위키 : ", " ");        


        

            //Rtb_info_maker.Document.Blocks.Add(new Paragraph(new Run(@"  ^(?([^\r\n])\s)*\r?$\r?\n ")));
            
        }
        private void AddHyperlinkText(string linkURL, string linkName,
              string TextBeforeLink, string TextAfterLink)
        {
            Paragraph para = new Paragraph();
            para.Margin = new Thickness(3); // remove indent between paragraphs

            Hyperlink link = new Hyperlink();
            link.IsEnabled = true;
            link.Inlines.Add(linkName);
            link.NavigateUri = new Uri(linkURL);
            link.RequestNavigate += (sender, args) => System.Diagnostics.Process.Start(args.Uri.ToString());

            //para.Inlines.Add(new Run("[" + DateTime.Now.ToLongTimeString() + "]: "));
            para.Inlines.Add(TextBeforeLink);
            para.Inlines.Add(link);
            para.Inlines.Add(new Run(TextAfterLink));

            Rtb_info_maker.Document.Blocks.Add(para);
        }
        public string fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe";
        


        #endregion




    }
}
