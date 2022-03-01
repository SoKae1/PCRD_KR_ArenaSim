namespace PCRD_KR_ArenaSim
{

    class Character_range_and_cast
    {
        /* 타입(물리1, 마법2), 사거리, 평타 cast time, 스킬1 cast time, 스킬2 cast time, 전용장비 스킬1 cast time ,SP 스킬1 cast time
         https://github.com/HerDataSam/redive_kr_db_diff/blob/master/unit_data.csv
        https://github.com/esterTion/redive_master_db_diff/blob/master/skill_data.sql
        https://pcredivewiki.tw/Stand


        셰피, 프캬루까지 
         */

        public double[] hiyori = new double[6] { 1, 200, 2.295, 1.125, 1.295, 1.125 };
        public double[] yui = new double[6] { 2, 800, 2.27, 1.6, 1.46, 1.6 };
        public double[] rei = new double[6] { 1, 250, 1.965, 0.955, 1.3275, 0.955 };
        public double[] misogi = new double[6] { 1, 205, 2.17, 1.55, 1.18, 1.55 };
        public double[] matsuri = new double[6] { 1, 185, 2.125, 0.76, 1.5, 0.76 };
        public double[] akari = new double[6] { 2, 570, 2.19, 1.18, 1.25, 1.18 };
        public double[] miyako = new double[6] { 1, 125, 1.7, 0, 0.27, 0 };
        public double[] yuki = new double[6] { 2, 805, 2.07, 1.93, 1.6, 1.93 };
        public double[] anna = new double[6] { 2, 440, 2.25, 1.58, 1.25, 1.58 };
        public double[] maho = new double[6] { 2, 795, 2.27, 1.53, 2.13, 1.53 };
        public double[] rino = new double[6] { 1, 700, 1.97, 1.07, 1.5, 1.07 };
        public double[] hatsune = new double[6] { 2, 755, 2.07, 1.4, 1.4, 1.4 };
        public double[] nanaka = new double[6] { 2, 740, 2.07, 1.4, 1.4, 1.4 };
        public double[] kasumi = new double[6] { 2, 730, 2.27, 1.4, 1.4, 1.4 };
        public double[] misato = new double[6] { 2, 735, 2.27, 1.17, 1.6, 1.17 };
        public double[] suzuna = new double[6] { 1, 705, 1.97, 0.71, 1.4, 0.71 };
        public double[] kaori = new double[6] { 1, 145, 2.17, 1, 1, 1 };
        public double[] io = new double[6] { 2, 715, 2.6, 1.66, 1.33, 1.66 };
        public double[] mimi = new double[6] { 1, 360, 2.125, 0.85, 0.42, 0.85 };
        public double[] kurumi = new double[6] { 1, 240, 1.675, 1.375, 1.375, 1.375 };
        public double[] yori = new double[6] { 2, 575, 2.19, 1.25, 0.98, 1.25 };
        public double[] ayane = new double[6] { 1, 210, 1.425, 1.125, 0.855, 1.125 };
        public double[] suzume = new double[6] { 2, 720, 2.27, 1.6, 1.46, 1.6 };
        public double[] rin = new double[6] { 1, 550, 2.34, 0.59, 0.92, 0.59 };
        public double[] eriko = new double[6] { 1, 230, 1.425, 1.125, 1.125, 1.125 };
        public double[] saren = new double[6] { 1, 430, 2.09, 1.45, 1.25, 1.45 };
        public double[] nozomi = new double[6] { 1, 160, 1.965, 1.25, 1.65, 1.25 };
        public double[] ninon = new double[6] { 1, 415, 2.25, 1.85, 0.85, 1.85 };
        public double[] sinobu = new double[6] { 1, 365, 2.25, 1.38, 2.01, 1.38 };
        public double[] akino = new double[6] { 1, 180, 2.125, 1.3575, 1.5575, 1.3575 };
        public double[] mahiru = new double[6] { 1, 395, 2.34, 1.4, 1.4, 1.4 };
        public double[] yukari = new double[6] { 1, 405, 2.4, 1.4, 1.13, 1.4 };
        public double[] kyouka = new double[6] { 2, 810, 2.07, 1.83, 1.4, 1.83 };
        public double[] tomo = new double[6] { 1, 220, 1.965, 0.76, 1.5, 0.76 };
        public double[] siori = new double[6] { 1, 710, 1.97, 0.76, 1.5, 0.76 };
        public double[] aoi = new double[6] { 1, 785, 1.97, 1.06, 1.06, 0.86 };
        public double[] chika = new double[6] { 2, 790, 2.27, 1.5, 2.03, 1.5 };
        public double[] makoto = new double[6] { 1, 165, 2.125, 1.125, 1.895, 1.125 };
        public double[] iriya = new double[6] { 2, 425, 1.425, 1.125, 0.865, 1.125 };
        public double[] kuuka = new double[6] { 1, 130, 2.375, 0.375, 1.375, 0.375 };
        public double[] tamaki = new double[6] { 1, 215, 2.25, 1.325, 1.325, 1.325 };
        public double[] zyun = new double[6] { 1, 135, 2.125, 0.475, 0.875, 0.475 };
        public double[] mihuyu = new double[6] { 1, 420, 2.19, 1.25, 1.31, 1.25 };
        public double[] sizuru = new double[6] { 1, 285, 2.375, 1.375, 1.375, 1.375 };
        public double[] misaki = new double[6] { 2, 760, 2.07, 1.4, 0.9, 1.4 };
        public double[] mitsuki = new double[6] { 1, 565, 2.25, 1.41, 0.28, 1.41 };
        public double[] rima = new double[6] { 1, 105, 2.215, 0, 1.375, 0 };
        public double[] monika = new double[6] { 1, 410, 2.24, 1.06, 0.86, 1.06 };
        public double[] tsumugi = new double[6] { 1, 195, 2.42, 1.23, 1.23, 1.23 };
        public double[] ayumi = new double[6] { 1, 510, 2.34, 1.23, 1.23, 1.23 };
        public double[] ruka = new double[6] { 1, 158, 1.965, 1.125, 1.125, 1.125 };
        public double[] zita = new double[6] { 1, 245, 1.965, 1.125, 1.125, 1.125 };
        public double[] pekorinnu = new double[6] { 1, 155, 2.25, 0.21, 1.21, 0.21 };
        public double[] kotkoro = new double[6] { 1, 500, 2.34, 0.66, 1.4, 0.66 };
        public double[] kyaru = new double[6] { 2, 750, 2.07, 1.27, 0.83, 1.27 };
        public double[] muimi = new double[6] { 1, 162, 1.8, 0.34, 0.34, 0.34 };
        public double[] muimi_ub = new double[6] { 1, 162, 1.8, 0.25, 0.25, 0.25 };

        public double[] arisa = new double[6] { 1, 625, 1.97, 0.75, 1.35, 1.27 };
        public double[] kaya = new double[6] { 1, 168, 2.17, 0.57, 0.34, 0.57 };
        public double[] inori = new double[6] { 1, 197, 1.55, 0.59, 0.59, 0.59 };
        public double[] labyrista = new double[6] { 1, 560, 1.55, 0.59, 0.59, 0.59 };
        public double[] labyrista_ub = new double[6] { 1, 560, 1.55, 0, 0.59, 0 };

        public double[] neneka = new double[6] { 2, 660, 2, 0.75, 1.35, 0.75 };
        public double[] neneka_alter = new double[6] { 2, 660, 2, 0.75, 1.35, 0.75 };
        public double[] kristina = new double[6] { 1, 290, 2, 0.75, 1.35, 0.75 };
        public double[] pekorinnu_summer = new double[6] { 1, 235, 2.125, 0.065, 1.125, 0.065 };
        public double[] kotkoro_summer = new double[6] { 1, 535, 2.34, 0.69, 0.59, 0.69 };
        public double[] suzume_summer = new double[6] { 2, 775, 2.07, 0.85, 0.92, 0.85 };
        public double[] kyaru_summer = new double[6] { 2, 780, 1.92, 0.74, 1.14, 0.74 };
        public double[] tamaki_summer = new double[6] { 1, 225, 2, 0.5, 1.1, 0.5 };
        public double[] mihuyu_summer = new double[6] { 1, 495, 2.19, 1.05, 1.19, 1.05 };
        public double[] sinobu_halloween = new double[6] { 1, 440.000001, 1.55, 0.75, 1.35, 0.75 };
        public double[] miyako_halloween = new double[6] { 1, 590, 2.42, 0.75, 0.55, 0.75 };
        public double[] misaki_halloween = new double[6] { 2, 815, 2.07, 1.05, 1.19, 1.05 };
        public double[] chika_christmas = new double[6] { 2, 770, 2.27, 1.05, 1.19, 1.05 };
        public double[] kurumi_christmas = new double[6] { 1, 295, 1.55, 1.05, 1.19, 1.05 };
        public double[] ayane_christmas = new double[6] { 1, 190, 1.425, 1.05, 1.19, 1.05 };
        public double[] hiyori_newyear = new double[6] { 1, 170, 2.17, 0.8, 0.94, 0.8 };
        public double[] yui_newyear = new double[6] { 2, 745, 2.27, 1.05, 1.19, 1.05 };
        public double[] rei_newyear = new double[6] { 1, 153, 2.215, 1.7325, 0, 1.7325 };
        public double[] eriko_valentine = new double[6] { 1, 187, 1.9, 0.925, 1.065, 0.925 };
        public double[] sizuru_valentine = new double[6] { 1, 385, 2.125, 1.7325, 0.72, 1.7325 };
        public double[] anne = new double[6] { 2, 630, 2.27, 0.925, 1.065, 0.925 };
        public double[] lou = new double[6] { 2, 640, 2.27, 1.7325, 1.19, 1.7325 };
        public double[] grea = new double[6] { 2, 525, 2.27, 1.05, 0.92, 1.05 };
        public double[] kuuka_ooedo = new double[6] { 2, 140, 2.066, 0.675, 0.715, 0.675 };
        public double[] ninon_ooedo = new double[6] { 1, 175, 2, 0.34, 0.34, 0.34 };
        public double[] rem = new double[6] { 1, 540, 2.25, 0.99, 0.59, 0.99 };
        public double[] ram = new double[6] { 2, 545, 2.5, 0.465, 0.465, 0.465 };
        public double[] emilia = new double[6] { 2, 725, 2.27, 1.77, 0.75, 1.77 };
        public double[] suzuna_summer = new double[6] { 1, 705.000001, 1.82, 0.9, 0.1, 0.9 };
        public double[] io_summer = new double[6] { 2, 715.000001, 2.4, 0.74, 0.74, 0.74 };
        public double[] saren_summer = new double[6] { 1, 585, 2.24, 0.74, 0.74, 0.74 };
        public double[] makoto_summer = new double[6] { 1, 180.000001, 2.125, 0.465, 0.765, 0.465 };
        public double[] kaori_summer = new double[6] { 1, 425.000001, 2.42, 0.89, 0.84, 0.89 };
        public double[] maho_summer = new double[6] { 2, 792, 2.27, 0.74, 1.34, 0.74 };
        public double[] aoi_nakayosi = new double[6] { 1, 680, 1.82, 0.9, 1.14, 0.9 };
        public double[] chloe = new double[6] { 1, 185.000001, 2.125, 0.73, 0.57, 0.73 };
        public double[] chieru = new double[6] { 1, 222, 2.295, 1, 1, 1 };
        public double[] yuni = new double[6] { 2, 807, 2.27, 0.73, 0.57, 0.73 };
        public double[] kyouka_halloween = new double[6] { 2, 820, 2.07, 1.27, 0.97, 1.27 };
        public double[] misogi_halloween = new double[6] { 1, 212, 2.17, 0.465, 0.465, 0.465 };
        public double[] mimi_halloween = new double[6] { 1, 365.000001, 2, 1.67, 2, 1.33 };
        public double[] runa = new double[6] { 2, 765, 1.87, 0.74, 0.74, 0.74 };
        public double[] kristina_christmas = new double[6] { 1, 265, 2, 0.34, 0.58, 0.34 };
        public double[] nozomi_christmas = new double[6] { 1, 418, 2.24, 1.07, 0.77, 1.07 };
        public double[] iriya_christmas = new double[6] { 2, 255, 1.3, 1.27, 0.97, 1.27 };
        public double[] kotkoro_newyear = new double[6] { 1, 159, 1.87, 0.375, 0.715, 0.375 };
        public double[] kyaru_newyear = new double[6] { 2, 690, 2.07, 0.74, 0.74, 0.74 };
        public double[] suzume_newyear = new double[6] { 2, 722, 2.27, 1.27, 0.97, 1.27 };
        public double[] kasumi_magical = new double[6] { 2, 730.000001, 2.27, 1.27, 0.97, 1.27 };
        public double[] siori_magical = new double[6] { 1, 712, 1.97, 1.27, 0.77, 1.27 };
        public double[] uzuki_deremas = new double[6] { 1, 370, 2.24, 1.27, 0.97, 1.27 };
        public double[] rin_deremas = new double[6] { 1, 153.000001, 2.215, 0.59, 0.59, 0.59 };
        public double[] mio_deremas = new double[6] { 2, 695, 2.27, 1.27, 0.97, 1.27 };
        public double[] rin_ranger = new double[6] { 1, 422, 2.19, 0, 0.62, 0 };
        public double[] mahiru_ranger = new double[6] { 1, 390, 2.19, 0.59, 0.59, 0.59 };
        public double[] rino_wonder = new double[6] { 1, 730.000002, 1.97, 1.27, 0.97, 1.27 };
        public double[] ayumi_wonder = new double[6] { 1, 508, 2.34, 1.07, 0.83, 1.07 };
        public double[] ruka_summer = new double[6] { 1, 192, 1.3, 0.465, 0.795, 0.465 };
        public double[] anna_summer = new double[6] { 2, 256, 1.625, 0.795, 1.125, 0.795 };
        public double[] nanaka_summer = new double[6] { 2, 468, 2.07, 1.27, 0.97, 1.27 };
        public double[] hatsune_summer = new double[6] { 2, 567, 1.92, 0.59, 0.59, 0.59 };
        public double[] misato_summer = new double[6] { 2, 697, 2.07, 0.94, 0.94, 0.94 };
        public double[] zyun_summer = new double[6] { 1, 182, 2, 0.66, 0.66, 0.66 };
        public double[] akari_angel = new double[6] { 2, 530, 1.92, 0.59, 0.59, 0.59 };
        public double[] yori_angel = new double[6] { 2, 531, 2.34, 0.74, 0.74, 0.74 };

        public double[] tsumugi_halloween = new double[6] { 2, 152, 2.375, 0.715, 0.715, 0.715 };
        public double[] rei_halloween = new double[6] { 2, 375, 1.965, 0.59, 0.59, 0.59 };
        public double[] matsuri_halloween = new double[6] { 2, 186, 2.295, 1.27, 0.97, 1.27 };
        public double[] monika_magical = new double[6] { 2, 528, 2.24, 0.8, 0.7, 0.8 };
        public double[] tomo_magical = new double[6] { 2, 402, 2.0, 0.59, 0.59, 0.59  };
        public double[] akino_christmas = new double[6] { 2, 189, 2.0, 0.4, 0.4, 0.4 };
        public double[] saren_christmas = new double[6] { 2, 150, 2.09, 0.8, 0.8, 0.8 };
        public double[] yukari_christmas = new double[6] { 2, 408, 2.09, 0.59, 0.82, 0.59 };
        public double[] pekorinnu_newyear = new double[6] { 2, 248, 1.965, 0.715, 0.715, 0.715 };
        public double[] muimi_newyear = new double[6] { 2, 138, 2.0, 1.14, 1.2, 1.14 };
        public double[] neneka_newyear = new double[6] { 2, 562, 2.07, 0.59, 0.59, 0.59 };
        public double[] kotkoro_maiden = new double[6] { 2, 533, 2.0, 0.59, 0.9, 0.59 };
        public double[] yui_maiden = new double[6] { 2, 578, 1.97, 0.7, 0.5, 0.7 };
        public double[] shepi = new double[7] { 2, 368, 1.84, 0.465, 0.465, 0.465 ,0.5};
        public double[] kasumi_summer = new double[6] { 2, 738, 2.27, 0.94, 0.94, 0.94 };


        public double[] yui_princess = new double[6] { 2, 767, 1.92, 0.59, 0.59, 0.59 };
        public double[] pekorinnu_princess = new double[6] { 1, 155.000001, 1.965, 0.92, 0.62, 0.92 };
        public double[] kotkoro_princess = new double[6] { 1, 555, 2.14, 0.66, 0.66, 0.66 };
        public double[] hiyori_princess = new double[6] { 1, 199, 2.14, 0.6, 0.6, 0.6 };
        public double[] rei_princess = new double[6] { 1, 377, 2.14, 0.415, 0.915, 0.415 };
        public double[] kyaru_princess = new double[6] { 1, 747, 2.14, 0.66, 0.66, 0.66 };

        public double[] skull = new double[6] { 1, 300, 2, 0, 0, 0 };
        public double[] sylph_chika = new double[6] { 2, 1000, 2, 0, 0, 0 };
        public double[] sylph_chika_christmas_1 = new double[6] { 2, 700, 2, 0, 0, 0 };
        public double[] sylph_chika_christmas_2 = new double[6] { 2, 750, 2, 3, 0, 3 };
        public double[] sylph_chika_christmas_3 = new double[6] { 2, 800, 2, 3, 0, 3 };
        public double[] golem = new double[6] { 1, 95, 3, 0, 0, 0 };

    }

}
