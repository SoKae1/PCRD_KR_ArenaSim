namespace PCRD_KR_ArenaSim
{

    class Character_pattern
    {
        /* 반복시작점, 반복끝점, 행동 20개 */
        /* 첫번째 행동부터 하다가 모든 행동이 끝나면 반복시작점부터 재행동
         https://github.com/esterTion/redive_master_db_diff/blob/master/unit_attack_pattern.sql
        오유키, 프캬루까지 넣음
         * 
         */
        public double[] hiyori = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui = new double[22] { 3, 10, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei = new double[22] { 4, 8, 1, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi = new double[22] { 3, 7, 1002, 1001, 1, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari = new double[22] { 3, 9, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako = new double[22] { 6, 9, 1, 1, 1001, 1, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki = new double[22] { 3, 10, 1001, 1002, 1, 1001, 1, 1002, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna = new double[22] { 3, 7, 1001, 1, 1001, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho = new double[22] { 3, 10, 1002, 1001, 1, 1002, 1, 1, 1001, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka = new double[22] { 3, 7, 1001, 1002, 1, 1001, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori = new double[22] { 5, 9, 1002, 1001, 1, 1001, 1, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume = new double[22] { 3, 8, 1002, 1001, 1, 1002, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin = new double[22] { 4, 12, 1001, 1002, 1, 1001, 1, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko = new double[22] { 3, 8, 1001, 1002, 1, 1002, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi = new double[22] { 3, 9, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari = new double[22] { 4, 8, 1002, 1, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka = new double[22] { 3, 12, 1002, 1001, 1, 1002, 1001, 1, 1002, 1001, 1, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo = new double[22] { 3, 10, 1002, 1001, 1, 1002, 1001, 1, 1002, 1001, 1001, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya = new double[22] { 3, 12, 1001, 1002, 1, 1002, 1001, 1, 1002, 1001, 1, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka = new double[22] { 3, 9, 1001, 1002, 1, 1001, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru = new double[22] { 3, 13, 1002, 1001, 1, 1, 1002, 1, 1, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima = new double[22] { 2, 7, 1001, 1, 1002, 1, 1002, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika = new double[22] { 4, 6, 1001, 1, 1002, 1, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi = new double[22] { 4, 11, 1001, 1, 1002, 1, 1, 1002, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi = new double[22] { 3, 8, 1001, 1002, 1, 1, 1001, 1, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka = new double[22] { 3, 9, 1001, 1002, 1, 1001, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro = new double[22] { 3, 9, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] muimi = new double[22] { 3, 9, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_ub = new double[22] { 2, 3, 2001, 2002, 2001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] arisa = new double[22] { 4, 11, 1001, 1002, 1, 1002, 1, 1002, 1001, 1, 1002, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya = new double[22] { 8, 16, 1002, 1001, 1001, 1002, 1, 1001, 1002, 1001, 1, 1002, 1, 1001, 1, 1, 1002, 1, 0, 0, 0, 0 };
        public double[] inori = new double[22] { 3, 9, 1001, 1002, 1, 1, 1001, 1, 1002, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] labyrista = new double[22] { 3, 9, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_ub = new double[22] { 8, 9, 2002, 2001, 2002, 2001, 2002, 2001, 2003, 2003, 2003, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] neneka = new double[22] { 3, 13, 1002, 1001, 1, 1001, 1, 1002, 1001, 1, 1, 1001, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_alter = new double[22] { 3, 13, 1002, 1001, 1, 1001, 1, 1002, 1001, 1, 1, 1001, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina = new double[22] { 3, 13, 1001, 1002, 1, 1002, 1, 1001, 1002, 1, 1, 1002, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer = new double[22] { 3, 13, 1001, 1002, 1, 1001, 1, 1, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer = new double[22] { 4, 11, 1001, 1002, 1, 1002, 1, 1002, 1001, 1, 1002, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer = new double[22] { 3, 13, 1001, 1002, 1, 1, 1001, 1, 1002, 1, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer = new double[22] { 3, 13, 1002, 1001, 1, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer = new double[22] { 4, 11, 1002, 1001, 1, 1002, 1, 1, 1001, 1, 1002, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer = new double[22] { 3, 8, 1002, 1001, 1, 1, 1002, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween = new double[22] { 3, 11, 1001, 1002, 1, 1, 1001, 1002, 1002, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween = new double[22] { 9, 17, 1002, 1001, 1, 1002, 1, 1002, 1, 1001, 1, 1002, 1, 1002, 1001, 1, 1002, 1, 1001, 0, 0, 0 };
        public double[] misaki_halloween = new double[22] { 3, 10, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas = new double[22] { 3, 5, 1001, 1002, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear = new double[22] { 3, 13, 1001, 1002, 1, 1002, 1001, 1, 1002, 1, 1001, 1, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear = new double[22] { 4, 10, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear = new double[22] { 3, 6, 1001, 1002, 1001, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine = new double[22] { 4, 11, 1002, 1, 1001, 1, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou = new double[22] { 3, 6, 1001, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea = new double[22] { 4, 11, 1002, 1, 1001, 1, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo = new double[22] { 4, 7, 1002, 1001, 1, 1002, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem = new double[22] { 5, 9, 1001, 1, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia = new double[22] { 3, 11, 1001, 1002, 1, 1001, 1, 1001, 1002, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer = new double[22] { 11, 12, 1001, 1, 1001, 1, 1001, 1, 1001, 1, 1001, 1002, 1001, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer = new double[22] { 4, 9, 1001, 1, 1002, 1, 1, 1002, 1, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer = new double[22] { 4, 11, 1002, 1001, 1, 1002, 1, 1001, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer = new double[22] { 3, 11, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe = new double[22] { 2, 6, 1001, 1002, 1, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru = new double[22] { 4, 6, 1001, 1, 1002, 1, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni = new double[22] { 4, 8, 1001, 1002, 1, 1001, 1, 1002, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween = new double[22] { 3, 12, 1001, 1002, 1, 1001, 1002, 1, 1001, 1002, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween = new double[22] { 4, 7, 1002, 1001, 1001, 1002, 1001, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa = new double[22] { 7, 11, 2001, 1001, 1, 1001, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas = new double[22] { 3, 13, 1001, 1002, 1, 1002, 1, 1001, 1002, 1, 1, 1002, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas = new double[22] { 2, 11, 1001, 1002, 1, 1, 1002, 1, 1, 1002, 1, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas = new double[22] { 3, 12, 1002, 1001, 1, 1001, 1002, 1, 1001, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear = new double[22] { 3, 11, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear = new double[22] { 3, 8, 1002, 1001, 1, 1001, 1002, 1, 1001, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear = new double[22] { 5, 11, 1002, 1001, 1, 1002, 1, 1001, 1, 1, 1001, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical = new double[22] { 3, 7, 1002, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas = new double[22] { 3, 7, 1001, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas = new double[22] { 4, 7, 1002, 1001, 1, 1002, 1, 1001, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas = new double[22] { 4, 8, 1001, 1, 1001, 1002, 1001, 1, 1001, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger = new double[22] { 3, 9, 1001, 1002, 1002, 1, 1002, 1, 1002, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger = new double[22] { 5, 12, 1001, 1002, 1, 1002, 1001, 1002, 1, 1002, 1001, 1, 1002, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder = new double[22] { 3, 11, 1001, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder = new double[22] { 3, 11, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 1, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer = new double[22] { 7, 13, 1001, 1, 1, 1001, 1, 1002, 1001, 1, 1002, 1, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer = new double[22] { 3, 9, 1001, 1002, 1, 1001, 1, 1002, 1001, 1, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer = new double[22] { 3, 11, 1002, 1001, 1, 1, 1002, 1, 1001, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer = new double[22] { 4, 12, 1001, 1002, 1001, 1, 1002, 1, 1001, 1, 1, 1002, 1, 1001, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer = new double[22] { 3, 13, 1001, 1002, 1, 1, 1001, 1002, 1, 1001, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer = new double[22] { 3, 13, 1002, 1001, 1, 1002, 1001, 1, 1002, 1001, 1, 1002, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel = new double[22] { 3, 13, 1001, 1002, 1, 1001, 1002, 1, 1, 1001, 1002, 1, 1, 1001, 1002, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel = new double[22] {/*loop_start*/3, /*loop_end*/13, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/1001, /*atk_pattern_12*/1, /*atk_pattern_13*/1002, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };

        public double[] tsumugi_halloween = new double[22] {/*loop_start*/5, /*loop_end*/11, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1, /*atk_pattern_11*/1002, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] rei_halloween = new double[22] { /*loop_start*/3, /*loop_end*/11, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1, /*atk_pattern_6*/1001, /*atk_pattern_7*/1, /*atk_pattern_8*/1002, /*atk_pattern_9*/1001, /*atk_pattern_10*/1, /*atk_pattern_11*/1001, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] matsuri_halloween = new double[22] { /*loop_start*/5, /*loop_end*/10, /*atk_pattern_1*/1002, /*atk_pattern_2*/1, /*atk_pattern_3*/1001, /*atk_pattern_4*/1002, /*atk_pattern_5*/1, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1001, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] monika_magical = new double[22] { /*loop_start*/6, /*loop_end*/13, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1002, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1, /*atk_pattern_11*/1001, /*atk_pattern_12*/1, /*atk_pattern_13*/1002, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] tomo_magical = new double[22] { /*loop_start*/3, /*loop_end*/12, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1002, /*atk_pattern_11*/1, /*atk_pattern_12*/1001, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] akino_christmas = new double[22] { /*loop_start*/4, /*loop_end*/10, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] saren_christmas = new double[22] { /*loop_start*/4, /*loop_end*/10, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1002, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1002, /*atk_pattern_10*/1, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] yukari_christmas = new double[22] { /*loop_start*/4, /*loop_end*/7, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] muimi_newyear = new double[22] { /*loop_start*/4, /*loop_end*/10, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] neneka_newyear = new double[22] { /*loop_start*/6, /*loop_end*/17, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1002, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1001, /*atk_pattern_7*/1, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1001, /*atk_pattern_11*/1, /*atk_pattern_12*/1001, /*atk_pattern_13*/1, /*atk_pattern_14*/1, /*atk_pattern_15*/1002, /*atk_pattern_16*/1, /*atk_pattern_17*/1001, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] pekorinnu_newyear = new double[22] { /*loop_start*/3, /*loop_end*/12, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1002, /*atk_pattern_10*/1, /*atk_pattern_11*/1001, /*atk_pattern_12*/1002, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] kotkoro_maiden = new double[22] { /*loop_start*/3, /*loop_end*/13, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1, /*atk_pattern_10*/1001, /*atk_pattern_11*/1002, /*atk_pattern_12*/1, /*atk_pattern_13*/1001, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] yui_maiden = new double[22] { 6,    /*loop_end*/    10, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1002, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] kasumi_summer = new double[22] { 3, /*loop_end*/12, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/1001, /*atk_pattern_12*/1, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] shepi = new double[22] {/*loop_start*/5,   /*loop_end*/11, /*atk_pattern_1*/2001, /*atk_pattern_2*/1001, /*atk_pattern_3*/1002, /*atk_pattern_4*/1, /*atk_pattern_5*/1001, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/1, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };


        public double[] rima_cinderella_1 = new double[22] { 2,   /*loop_end*/ 2, /*atk_pattern_1*/2003, /*atk_pattern_2*/2003, /*atk_pattern_3*/0, /*atk_pattern_4*/0, /*atk_pattern_5*/0, /*atk_pattern_6*/0, /*atk_pattern_7*/0, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] rima_cinderella_2 = new double[22] { 1,   /*loop_end*/ 3, /*atk_pattern_1*/2001, /*atk_pattern_2*/1, /*atk_pattern_3*/2002, /*atk_pattern_4*/0, /*atk_pattern_5*/0, /*atk_pattern_6*/0, /*atk_pattern_7*/0, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] rima_cinderella = new double[22] { 1,   /*loop_end*/ 5, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1002, /*atk_pattern_4*/1, /*atk_pattern_5*/1002, /*atk_pattern_6*/0, /*atk_pattern_7*/0, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        //행동패턴3: rima_cinderella
        //행동패턴2:rima_cinderella_2
        //행동패턴1:rima_cinderella_1

        public double[] makoto_cinderella = new double[22] { 3, /*loop_end*/           8, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] maho_cinderella = new double[22] { 4,   /*loop_end*/ 9, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] chloe_terefes = new double[22] { 2,    /*loop_end*/  6, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/0, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] chieru_terefes = new double[22] { 3,   /*loop_end*/ 5, /*atk_pattern_1*/1002, /*atk_pattern_2*/1, /*atk_pattern_3*/1001, /*atk_pattern_4*/1, /*atk_pattern_5*/1, /*atk_pattern_6*/0, /*atk_pattern_7*/0, /*atk_pattern_8*/0, /*atk_pattern_9*/0, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] inori_timetravel = new double[22] { 3,  /*loop_end*/9, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1002, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] kaya_timetravel = new double[22] { 3,   /*loop_end*/ 9, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] aoi_worker = new double[22] { 4,    /*loop_end*/    10, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] tamaki_worker = new double[22] { 3, /*loop_end*/ 11, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1001, /*atk_pattern_7*/1, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1002, /*atk_pattern_11*/1, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] mihuyu_worker = new double[22] { 12, /*loop_end*/19, /*atk_pattern_1*/1002, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1002, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1002, /*atk_pattern_10*/1001, /*atk_pattern_11*/1, /*atk_pattern_12*/1001, /*atk_pattern_13*/1, /*atk_pattern_14*/1, /*atk_pattern_15*/1001, /*atk_pattern_16*/1, /*atk_pattern_17*/1002, /*atk_pattern_18*/1, /*atk_pattern_19*/1001, /*atk_pattern_20*/0 };
        public double[] eriko_summer = new double[22] { 3,  /*loop_end*/  9, /*atk_pattern_1*/1002, /*atk_pattern_2*/1001, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] sizuru_summer = new double[22] { 5, /*loop_end*/ 12, /*atk_pattern_1*/1, /*atk_pattern_2*/1001, /*atk_pattern_3*/1002, /*atk_pattern_4*/1, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1001, /*atk_pattern_8*/1002, /*atk_pattern_9*/1, /*atk_pattern_10*/1, /*atk_pattern_11*/1001, /*atk_pattern_12*/1, /*atk_pattern_13*/1002, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] nozomi_summer = new double[22] { 6, /*loop_end*/ 12, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1001, /*atk_pattern_4*/1, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/1, /*atk_pattern_12*/1002, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] chika_summer = new double[22] { 7,  /*loop_end*/  16, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1, /*atk_pattern_10*/1002, /*atk_pattern_11*/1, /*atk_pattern_12*/1001, /*atk_pattern_13*/1, /*atk_pattern_14*/0, /*atk_pattern_15*/1002, /*atk_pattern_16*/1, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] tsumugi_summer = new double[22] { 4,    /*loop_end*/    10, /*atk_pattern_1*/1002, /*atk_pattern_2*/1, /*atk_pattern_3*/1001, /*atk_pattern_4*/1, /*atk_pattern_5*/1001, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1, /*atk_pattern_9*/1, /*atk_pattern_10*/1001, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] mitsuki_ooedo = new double[22] { 3, /*loop_end*/ 9, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1002, /*atk_pattern_10*/0, /*atk_pattern_11*/0, /*atk_pattern_12*/0, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] yuki_ooedo = new double[22] { 6,    /*loop_end*/    16, /*atk_pattern_1*/1, /*atk_pattern_2*/1002, /*atk_pattern_3*/1001, /*atk_pattern_4*/1, /*atk_pattern_5*/1002, /*atk_pattern_6*/1, /*atk_pattern_7*/1002, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1, /*atk_pattern_11*/1002, /*atk_pattern_12*/1, /*atk_pattern_13*/1001, /*atk_pattern_14*/0, /*atk_pattern_15*/1, /*atk_pattern_16*/1002, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };

        public double[] yui_princess = new double[22] { 4, 15, 1001, 1002, 1, 1001, 1, 1002, 1, 1001, 1, 1002, 1, 1, 1001, 1, 1002, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess = new double[22] { 3, 12, 1001, 1002, 1, 1002, 1, 1001, 1002, 1, 1001, 1, 1002, 1001, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess = new double[22] { 5, 17, 1002, 1, 1002, 1001, 1002, 1, 1002, 1, 1001, 1002, 1, 1002, 1, 1, 1, 1002, 1001, 0, 0, 0 };
        public double[] hiyori_princess = new double[22] { /*loop_start*/4, /*loop_end*/15, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1001, /*atk_pattern_4*/1002, /*atk_pattern_5*/1001, /*atk_pattern_6*/1002, /*atk_pattern_7*/1, /*atk_pattern_8*/1001, /*atk_pattern_9*/1002, /*atk_pattern_10*/1, /*atk_pattern_11*/1001, /*atk_pattern_12*/1002, /*atk_pattern_13*/1, /*atk_pattern_14*/1, /*atk_pattern_15*/1001, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] rei_princess = new double[22] { /*loop_start*/3, /*loop_end*/12, /*atk_pattern_1*/1001, /*atk_pattern_2*/1002, /*atk_pattern_3*/1, /*atk_pattern_4*/1001, /*atk_pattern_5*/1002, /*atk_pattern_6*/1001, /*atk_pattern_7*/1002, /*atk_pattern_8*/1, /*atk_pattern_9*/1001, /*atk_pattern_10*/1002, /*atk_pattern_11*/1001, /*atk_pattern_12*/1, /*atk_pattern_13*/0, /*atk_pattern_14*/0, /*atk_pattern_15*/0, /*atk_pattern_16*/0, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };
        public double[] kyaru_princess = new double[22] { /*loop_start*/4, /*loop_end*/16, /*atk_pattern_1*/1001, /*atk_pattern_2*/1, /*atk_pattern_3*/1002, /*atk_pattern_4*/1001, /*atk_pattern_5*/1, /*atk_pattern_6*/1002, /*atk_pattern_7*/1001, /*atk_pattern_8*/1, /*atk_pattern_9*/1, /*atk_pattern_10*/1001, /*atk_pattern_11*/1002, /*atk_pattern_12*/1, /*atk_pattern_13*/1001, /*atk_pattern_14*/1, /*atk_pattern_15*/1, /*atk_pattern_16*/1002, /*atk_pattern_17*/0, /*atk_pattern_18*/0, /*atk_pattern_19*/0, /*atk_pattern_20*/0 };

        public double[] skull = new double[22] { 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sylph_chika = new double[22] { 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sylph_chika_christmas_1 = new double[22] { 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sylph_chika_christmas_2 = new double[22] { 2, 7, 1001, 1, 1001, 1001, 1, 1001, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sylph_chika_christmas_3 = new double[22] { 2, 4, 1001, 1, 1001, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] golem = new double[22] { 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    }

}
