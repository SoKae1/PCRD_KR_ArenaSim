namespace PCRD_KR_ArenaSim
{
    class Character_SortByRange
    {
        public string[] Character_Sort_EN = new string[]{
            "kyouka_halloween","misaki_halloween","kyouka","yuni","yuki","yui","maho","maho_summer","chika","aoi","kyaru_summer","suzume_summer","chika_christmas","yui_princess","runa","misaki","hatsune","kyaru","yui_newyear","nanaka","misato","rino_wonder","kasumi_magical","kasumi",
        "emilia","suzume_newyear","suzume","io_summer","io","siori_magical","siori","suzuna_summer","suzuna","rino","misato_summer","mio_deremas","kyaru_newyear","aoi_nakayosi","neneka",
        "lou","anne","arisa","miyako_halloween","saren_summer","yori","akari","hatsune_summer","mitsuki","kotkoro_princess","rin","ram","rem","kotkoro_summer","akari_angel","grea","ayumi","ayumi_wonder","kotkoro","mihuyu_summer","nanaka_summer","sinobu_halloween",
        "anna","saren","kaori_summer","iriya","rin_ranger","mihuyu","nozomi_christmas","ninon","monika","yukari","mahiru","mahiru_ranger","sizuru_valentine","uzuki_deremas","mimi_halloween","sinobu","mimi",
        "kurumi_christmas","kristina","sizuru","kristina_christmas","anna_summer","iriya_christmas","rei","zita","kurumi","pekorinnu_summer","eriko","tamaki_summer","chieru","tomo","tamaki","misogi_halloween",
        "ayane","misogi","hiyori","inori","tsumugi","ruka_summer","ayane_christmas","eriko_valentine","chloe","matsuri","zyun_summer","makoto_summer","akino","ninon_ooedo","hiyori_newyear","kaya","makoto",

        "muimi","nozomi","kotkoro_newyear","ruka","pekorinnu_princess","pekorinnu","rin_deremas","rei_newyear","kaori","kuuka_ooedo","zyun","kuuka","miyako","rima"
        };

        public string[] Character_Sort_KR = new string[]{ "할쿄카", "할사키" ,"쿄우카","유니","유키","유이","마호","수마호","치카","아오이","수캬루","수즈메","성치카",
            "프유이","루나","미사키","하츠네","캬루","뉴이","나나카","미사토","앨리노","마스미","카스미","에밀리아","수즈메","스즈메","수이오","이오","마오리","시오리","수즈나","스즈나","리노","수사토","미오","냐루","편오이","네네카",
        "루","앤","아리사",
        "할푸딩","수사렌","요리","아카리","수츠네","미츠키","프코로","린","람","렘","수코로","엔카리","글레어","아유미","앨유미","콧코로","수후유","수나카","할노부",
        "안나","사렌","수오리","이리야","레린","미후유","성조미","니논","모니카","유카리","마히루","레히루","발즈루","우즈키","할미미","시노부","미미",

            "성루미","크리스티나","시즈루","성리스","수안나","성리야","레이","지타","쿠루미","수페코","에리코","수마키","치에루","토모","타마키","할소기",
        "아야네","미소기","히요리","이노리","츠무기","수루카","성야네","발리코","클로에","마츠리","수쥰","수코토","아키노","오니논","뉴요리","카야","마코토",
        "무이미","노조미","뉴코로","루카","프페코","페코린느","시부린","신레이","카오리","오우카","쥰","쿠우카","미야코","리마"
        };






        public string[] Character_Sort_Abbr = new string[]{ "핰", "핫" ,"쿄","윤","윸","융","마","","벽","찐","숰","숮","킃",
            "","룬","밋","하","캬","뉴","나","미","","맛","카","","","슺","숭","잉","망","싱","","스","리","","혼","냐","편","네",
        "루","앤","알",
        "핲","수","요","앜","","및","","린","람","렘","숰","","글","아","","콧","숳","","할",
        "안","사","숭","이","렐","밓","큰","니","모","유","맣","","발","우","함","","밈",

            "성","크","시","킄","","잌","레","지","쿨","숲","에","","","토","타","할",
        "","","히","츠","","킁","방","클","마","","","앜","","늏","캉","마",
        "무","노","늌","루","픞","페","십","신","","옼","쥰","쿠","푸","리"
        };
        public static bool[] charaAvaliability = new bool[124];

        void intializeAvailability()
        {
            for (int i = 0; i < 124; i++)
            {
                charaAvaliability[i] = false;
            }
        }
    }
}
