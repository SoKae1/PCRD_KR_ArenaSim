namespace PCRD_KR_ArenaSim
{

    class Unique_equipment
    {
        /* 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복, 8TP 자동 회복, 9회피, 10HP 흡수, 11회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 */
        /* 전용 장비에 따른 능력치는 전용 장비 능력치를 그대로 더하면 됨 */
        /* 전용 장비 착용자가 변수명이 됨 */
        /* 강화로 추가되는 스탯 순서도 동일: 전체 스탯 = 초기 장비 스탯 + 추가 장비 스탯 * ( 전용 장비 레벨 -1)
         * HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 
         https://github.com/esterTion/redive_master_db_diff/blob/master/unique_equipment_enhance_rate.sql
         
        전장 스탯은 엔요리까지
        강화수치 엔요리까지
         */

        public double[] hiyori = new double[15] { 0, 94, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_reinforce = new double[15] { 0, 4.7, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string hiyori_name = "냥피언 벨트";

        public double[] yui = new double[15] { 0, 0, 46, 5, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] yui_reinforce = new double[15] { 0, 0, 2.3, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string yui_name = "블로섬 위시";

        public double[] rei = new double[15] { 110, 95, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_reinforce = new double[15] { 5.5, 4.75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string rei_name = "게일 글러브";

        public double[] misogi = new double[15] { 0, 67, 0, 6, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_reinforce = new double[15] { 0, 3.35, 0, 0.3, 0.1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string misogi_name = "트릭 기프트";

        public double[] matsuri = new double[15] { 130, 0, 0, 9, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_reinforce = new double[15] { 6.5, 0, 0, 0.45, 0.4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string matsuri_name = "저스티스 메달";

        public double[] akari = new double[15] { 0, 0, 72, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_reinforce = new double[15] { 0, 0, 3.6, 0.15, 0.15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string akari_name = "데몬즈 트라이던트";

        public double[] miyako = new double[15] { 230, 0, 0, 9, 3, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] miyako_reinforce = new double[15] { 11.5, 0, 0, 0.45, 0.15, 0, 0, 0, 0, 0.15, 0, 0, 0, 0, 0 };
        public string miyako_name = "영감 고스트 푸딩";

        public double[] yuki = new double[15] { 0, 0, 63, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_reinforce = new double[15] { 0, 0, 3.15, 0.2, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string yuki_name = "글리터 콤팩트";

        public double[] anna = new double[15] { 0, 0, 90, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_reinforce = new double[15] { 0, 0, 4.5, 0, 0, 0, 0.5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string anna_name = "나선영격질풍비검";

        public double[] maho = new double[15] { 0, 0, 42, 6, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] maho_reinforce = new double[15] { 0, 0, 2.1, 0.3, 0.25, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string maho_name = "퓨어 메르헨 완드";

        public double[] rino = new double[15] { 0, 92, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_reinforce = new double[15] { 0, 4.6, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string rino_name = "프로미넌스 애로우";

        public double[] hatsune = new double[15] { 0, 0, 88, 1, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_reinforce = new double[15] { 0, 0, 4.4, 0.05, 0, 0, 0.5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string hatsune_name = "미티아☆리본";

        public double[] nanaka = new double[15] { 0, 0, 90, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_reinforce = new double[15] { 0, 0, 4.5, 0, 0, 0, 0.75, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string nanaka_name = "나나카 최강 로드";

        public double[] kasumi = new double[15] { 0, 0, 70, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_reinforce = new double[15] { 0, 0, 3.5, 0.15, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kasumi_name = "디텍티브 루페";

        public double[] misato = new double[15] { 0, 0, 51, 3, 7, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0 };
        public double[] misato_reinforce = new double[15] { 0, 0, 2.55, 0.15, 0.35, 0, 0, 0, 0, 0, 0, 0.15, 0, 0, 0 };
        public string misato_name = "아가페 베일";

        public double[] suzuna = new double[15] { 0, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] suzuna_reinforce = new double[15] { 0, 4.9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string suzuna_name = "크리티컬 키스";

        public double[] kaori = new double[15] { 0, 94, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_reinforce = new double[15] { 0, 4.7, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kaori_name = "구양당수비전서";

        public double[] io = new double[15] { 0, 0, 85, 0, 0, 0, 10, 0, 0, 0, 0, 0, 1, 0, 0 };
        public double[] io_reinforce = new double[15] { 0, 0, 4.25, 0, 0, 0, 0.5, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string io_name = "글래머 휩";

        public double[] mimi = new double[15] { 0, 88, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] mimi_reinforce = new double[15] { 0, 4.4, 0, 0, 0, 0.75, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string mimi_name = "토끼씨 블레이드";

        public double[] kurumi = new double[15] { 100, 0, 0, 8, 8, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_reinforce = new double[15] { 5, 0, 0, 0.4, 0.4, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0 };
        public string kurumi_name = "퓨어 액트 벨";

        public double[] yori = new double[15] { 0, 0, 85, 0, 1, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_reinforce = new double[15] { 0, 0, 4.25, 0, 0.05, 0, 0.5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string yori_name = "데몬즈 재블린";

        public double[] ayane = new double[15] { 0, 50, 0, 6, 4, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_reinforce = new double[15] { 0, 2.5, 0, 0.3, 0.2, 0.6, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string ayane_name = "위대한 곰돌이 왕 푸우키치";

        public double[] suzume = new double[15] { 0, 0, 96, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_reinforce = new double[15] { 0, 0, 4.8, 0, 0, 0, 0.5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string suzume_name = "로얄 메이드 드레스";

        public double[] rin = new double[15] { 0, 60, 0, 2, 3, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };
        public double[] rin_reinforce = new double[15] { 0, 3, 0, 0.1, 0.15, 0, 0, 0, 0, 0, 0, 0.5, 0, 0, 0 };
        public string rin_name = "쥬얼 리듬 도토리";

        public double[] eriko = new double[15] { 0, 85, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] eriko_reinforce = new double[15] { 0, 4.25, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string eriko_name = "노 머시";

        public double[] saren = new double[15] { 25, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_reinforce = new double[15] { 1.25, 5.25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string saren_name = "글로리어스 페더";

        public double[] nozomi = new double[15] { 300, 0, 0, 6, 6, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        public double[] nozomi_reinforce = new double[15] { 15, 0, 0, 0.3, 0.3, 0, 0, 0, 0, 0.05, 0, 0, 0, 0, 0 };
        public string nozomi_name = "브릴리언트 마이크";

        public double[] ninon = new double[15] { 0, 95, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_reinforce = new double[15] { 0, 4.75, 0, 0, 0, 0.75, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string ninon_name = "홍련폭염선";

        public double[] sinobu = new double[15] { 250, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] sinobu_reinforce = new double[15] { 12.5, 3.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string sinobu_name = "그림 소울 로브";

        public double[] akino = new double[15] { 150, 60, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 };
        public double[] akino_reinforce = new double[15] { 7.5, 3, 0, 0.1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string akino_name = "홍련석 위스타리아";

        public double[] mahiru = new double[15] { 0, 85, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] mahiru_reinforce = new double[15] { 0, 4.25, 0, 0.05, 0.05, 0, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string mahiru_name = "엘리자베스 판초";

        public double[] yukari = new double[15] { 0, 64, 0, 0, 3, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0 };
        public double[] yukari_reinforce = new double[15] { 0, 3.2, 0, 0, 0.15, 0, 0, 0, 0, 0, 0, 0.6, 0, 0, 0 };
        public string yukari_name = "이터널 저그";

        public double[] kyouka = new double[15] { 0, 0, 88, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_reinforce = new double[15] { 0, 0, 4.4, 0, 0, 0, 0.9, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kyouka_name = "코스모 블루 로드";

        public double[] tomo = new double[15] { 0, 60, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        public double[] tomo_reinforce = new double[15] { 0, 3, 0, 0, 0, 1.2, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string tomo_name = "천검백람";

        public double[] siori = new double[15] { 0, 75, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] siori_reinforce = new double[15] { 0, 3.75, 0, 0, 0, 1.2, 0, 0, 0, 0, 0, 0, 0.15, 0, 0 };
        public string siori_name = "하츠네 수제 수호석";

        public double[] aoi = new double[15] { 0, 60, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_reinforce = new double[15] { 0, 3, 0, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string aoi_name = "BB단의 인연 베레모";

        public double[] chika = new double[15] { 0, 0, 44, 5, 5, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0 };
        public double[] chika_reinforce = new double[15] { 0, 0, 2.2, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0.3, 0, 0, 0 };
        public string chika_name = "취령보의 룬 노트";

        public double[] makoto = new double[15] { 0, 100, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_reinforce = new double[15] { 0, 5, 0, 0, 0, 0.6, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string makoto_name = "울펜 블레이드";

        public double[] iriya = new double[15] { 0, 0, 80, 0, 4, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
        public double[] iriya_reinforce = new double[15] { 0, 0, 4, 0, 0.2, 0, 0, 0, 0, 0, 0.05, 0, 0, 0, 0 };
        public string iriya_name = "암부 나흐트 팡";

        public double[] kuuka = new double[15] { 0, 0, 0, 7, 9, 0, 0, 0, 0, 0, 0, 12, 0, 0, 0 };
        public double[] kuuka_reinforce = new double[15] { 0, 0, 0, 0.35, 0.45, 0, 0, 0, 0, 0, 0, 0.6, 0, 0, 0 };
        public string kuuka_name = "플레저 초커";

        public double[] tamaki = new double[15] { 0, 75, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_reinforce = new double[15] { 0, 3.75, 0, 0, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string tamaki_name = "환상의 붕어빵";

        public double[] zyun = new double[15] { 0, 20, 0, 8, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_reinforce = new double[15] { 0, 1, 0, 0.4, 0.45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string zyun_name = "슈발리에 메일";

        public double[] mihuyu = new double[15] { 0, 75, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_reinforce = new double[15] { 0, 3.75, 0, 0.15, 0.15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string mihuyu_name = "명룡창 레비아탄";

        public double[] sizuru = new double[15] { 0, 64, 0, 6, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] sizuru_reinforce = new double[15] { 0, 3.2, 0, 0.3, 0, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string sizuru_name = "세이크리드 블레이드";

        public double[] misaki = new double[15] { 0, 0, 97, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_reinforce = new double[15] { 0, 0, 4.85, 0, 0, 0, 0.4, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string misaki_name = "마안의 완드 데모니스 아이";

        public double[] mitsuki = new double[15] { 100, 80, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] mitsuki_reinforce = new double[15] { 5, 4, 0, 0, 0, 0.25, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string mitsuki_name = "로즈 오브 커스";

        public double[] rima = new double[15] { 0, 25, 0, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_reinforce = new double[15] { 0, 1.25, 0, 0.45, 0.35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string rima_name = "앰비셔스 드레스";

        public double[] monika = new double[15] { 0, 52, 0, 6, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_reinforce = new double[15] { 0, 2.6, 0, 0.3, 0.2, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string monika_name = "플뤼겔 코트";

        public double[] tsumugi = new double[15] { 0, 50, 0, 6, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_reinforce = new double[15] { 0, 2.5, 0, 0.3, 0.2, 0.2, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string tsumugi_name = "하이 쿠튀리에 벨트";

        public double[] ayumi = new double[15] { 0, 14, 0, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_reinforce = new double[15] { 0, 0.7, 0, 0.45, 0.45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string ayumi_name = "스토킹 망토";

        public double[] ruka = new double[15] { 0, 20, 0, 9, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_reinforce = new double[15] { 0, 1, 0, 0.45, 0.4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string ruka_name = "진타 절해・파랑환";

        public double[] zita = new double[15] { 0, 90, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
        public double[] zita_reinforce = new double[15] { 0, 4.5, 0, 0, 0, 1.1, 0, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string zita_name = "아슈켈론";

        public double[] pekorinnu = new double[15] { 0, 0, 0, 10, 9, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] pekorinnu_reinforce = new double[15] { 0, 0, 0, 0.5, 0.45, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string pekorinnu_name = "프린세스 소드";

        public double[] kotkoro = new double[15] { 0, 50, 0, 5, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] kotkoro_reinforce = new double[15] { 0, 2.5, 0, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string kotkoro_name = "아메스 아뮬렛";

        public double[] kyaru = new double[15] { 0, 0, 94, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_reinforce = new double[15] { 0, 0, 4.7, 0, 0, 0, 0.5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kyaru_name = "카오스 그리모어";

        public double[] arisa = new double[15] { 0, 95, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_reinforce = new double[15] { 0, 4.75, 0, 0, 0, 0.8, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string arisa_name = "퀸 티타니아";

        public double[] kristina = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] kristina_reinforce = new double[15] { 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string kristina_name = "성역검 아발론";

        public double[] pekorinnu_summer = new double[15] { 0, 80, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] pekorinnu_summer_reinforce = new double[15] { 0, 4, 0, 0, 0, 1.25, 0, 0, 0, 0, 0, 0, 0, 0.05, 0 };
        public string pekorinnu_summer_name = "우검 비치 프린세스";

        public double[] kotkoro_summer = new double[15] { 0, 42, 0, 5, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] kotkoro_summer_reinforce = new double[15] { 0, 2.1, 0, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string kotkoro_summer_name = "양창 아쿠아 스쿼시";

        public double[] suzume_summer = new double[15] { 0, 42, 0, 5, 5, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] suzume_summer_reinforce = new double[15] { 0, 0, 2, 0.3, 0.3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string suzume_summer_name = "빛의 완드 샤인 선데이";

        public double[] kyaru_summer = new double[15] { 0, 0, 85, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_reinforce = new double[15] { 0, 0, 4.25, 0, 0, 0, 0.75, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kyaru_summer_name = "고양이 튜브 서머 플로트";

        public double[] tamaki_summer = new double[15] { 0, 0, 85, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_reinforce = new double[15] { 0, 4, 0, 0, 0, 1.5, 0, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string tamaki_summer_name = "얼음 붕어 아이스 대거";

        public double[] mihuyu_summer = new double[15] { 0, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] mihuyu_summer_reinforce = new double[15] { 0, 4.3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.15, 0, 0 };
        public string mihuyu_summer_name = "창룡창 미즈치";

        public double[] sinobu_halloween = new double[15] { 0, 75, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
        public double[] sinobu_halloween_reinforce = new double[15] { 0, 3.75, 0, 0, 0, 1.75, 0, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string sinobu_halloween_name = "영겸 펌킨 사이즈";

        public double[] miyako_halloween = new double[15] { 0, 66, 0, 3, 3, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_reinforce = new double[15] { 0, 3.3, 0, 0.15, 0.15, 0.5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string miyako_halloween_name = "푸딩 오브 할로윈";

        public double[] misaki_halloween = new double[15] { 0, 0, 60, 0, 5, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 };
        public double[] misaki_halloween_reinforce = new double[15] { 0, 0, 3, 0, 0.25, 0, 0, 0, 0, 0, 0.05, 0, 0, 0.05, 0 };
        public string misaki_halloween_name = "마법 빗자루 할로윈 아이";

        public double[] chika_christmas = new double[15] { 80, 0, 46, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_reinforce = new double[15] { 4, 0, 2.3, 0.25, 0.25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string chika_christmas_name = "취령장 룬 스노우";

        public double[] kurumi_christmas = new double[15] { 125, 0, 0, 10, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_reinforce = new double[15] { 6.25, 0, 0, 0.5, 0.4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kurumi_christmas_name = "크리스마스 액트 벨";

        public double[] ayane_christmas = new double[15] { 50, 80, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
        public double[] ayane_christmas_reinforce = new double[15] { 2.5, 4, 0, 0.15, 0, 0, 0, 0, 0, 0, 0.05, 0, 0, 0, 0 };
        public string ayane_christmas_name = "크리스마스 왕 푸우키치";

        public double[] hiyori_newyear = new double[15] { 0, 86, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] hiyori_newyear_reinforce = new double[15] { 0, 4.3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0.05, 0 };
        public string hiyori_newyear_name = "묘명신 냥피스트";

        public double[] yui_newyear = new double[15] { 0, 0, 50, 0, 5, 0, 0, 0, 30, 0, 0, 0, 1, 0, 0 };
        public double[] yui_newyear_reinforce = new double[15] { 0, 0, 2.5, 0, 0.25, 0, 0, 0, 1.5, 0, 0, 0, 0.05, 0, 0 };
        public string yui_newyear_name = "새벽의 축복 완드 블로섬";

        public double[] rei_newyear = new double[15] { 0, 24, 0, 3, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_reinforce = new double[15] { 0, 1.2, 0, 0.15, 0.65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string rei_newyear_name = "빙려도 초화";

        public double[] eriko_valentine = new double[15] { 0, 80, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] eriko_valentine_reinforce = new double[15] { 0, 4, 0, 0, 0, 1.25, 0, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string eriko_valentine_name = "디스트로이 휘퍼";

        public double[] sizuru_valentine = new double[15] { 100, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] sizuru_valentine_reinforce = new double[15] { 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string sizuru_valentine_name = "데코레이션 하트";

        public double[] anne = new double[15] { 0, 0, 88, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 0 };
        public double[] anne_reinforce = new double[15] { 0, 0, 4.4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.1, 0.05, 0 };
        public string anne_name = "앤의 마도서";

        public double[] lou = new double[15] { 0, 0, 70, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_reinforce = new double[15] { 0, 0, 3.5, 0, 0, 0, 1.75, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string lou_name = "오메메!";

        public double[] grea = new double[15] { 0, 0, 92, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] grea_reinforce = new double[15] { 0, 0, 4.6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.15, 0, 0 };
        public string grea_name = "드래그 아뮬렛";

        public double[] kuuka_ooedo = new double[15] { 0, 0, 92, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] kuuka_ooedo_reinforce = new double[15] { 0, 0, 0, 0.35, 0.6, 0, 0, 0, 0, 0, 0, 0.25, 0, 0, 0 };
        public string kuuka_ooedo_name = "천자만홍염춘";

        public double[] ninon_ooedo = new double[15] { 0, 0, 92, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] ninon_ooedo_reinforce = new double[15] { 0, 4.25, 0, 0, 0, 2.0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string ninon_ooedo_name = "닌자 놀이 세트";

        public double[] suzuna_summer = new double[15] { 0, 96, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] suzuna_summer_reinforce = new double[15] { 0, 4.8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.05, 0 };
        public string suzuna_summer_name = "성하궁 스플래시 하트";

        public double[] io_summer = new double[15] { 0, 0, 80, 1, 1, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0 };
        public double[] io_summer_reinforce = new double[15] { 0, 0, 4, 0.05, 0.05, 0, 0, 0, 0, 0, 0, 0.3, 0, 0, 0 };
        public string io_summer_name = "혜애검 서머 러브 패밀리어";

        public double[] saren_summer = new double[15] { 0, 80, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_reinforce = new double[15] { 0, 4, 0, 0, 0, 0, 0, 0, 1.5, 0, 0, 0, 0, 0, 0 };
        public string saren_summer_name = "섬려검 서머 브라이트";

        public double[] muimi = new double[15] { 0, 99, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
        public double[] muimi_reinforce = new double[15] { 0, 4.95, 0, 0, 0, 0.45, 0, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string muimi_name = "인연의 증표";

        public double[] makoto_summer = new double[15] { 0, 88, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
        public double[] makoto_summer_reinforce = new double[15] { 0, 4.4, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0.05, 0, 0 };
        public string makoto_summer_name = "서머 울펜 소드";

        public double[] kaori_summer = new double[15] { 0, 90, 0, 0, 0, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_reinforce = new double[15] { 0, 4.5, 0, 0, 0, 1.4, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string kaori_summer_name = "류쿠견식 신무지농수";

        public double[] maho_summer = new double[15] { 0, 0, 78, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] maho_summer_reinforce = new double[15] { 0, 0, 3.9, 0, 0, 0, 0.9, 0, 0, 0, 0, 0, 0, 0.05, 0 };
        public string maho_summer_name = "하화장 팬시 로어";

        public double[] aoi_nakayosi = new double[15] { 0, 91, 0, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] aoi_nakayosi_reinforce = new double[15] { 0, 4.55, 0, 0, 0, 1.2, 0.9, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string aoi_nakayosi_name = "단짝 궁금";

        public double[] chloe = new double[15] { 0,77, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] chloe_reinforce = new double[15] { 0, 3.85, 0, 0, 0, 1.75, 0.9, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string chloe_name = "프롬 더스크 틸 던";

        public double[] misogi_halloween = new double[15] { 0.0, 50.0, 0.0, 4.0, 0.0, 0.0,  0.0,  0.0, 0.0, 1.0,  0.0, 0.0, 0.0, 0.0,  8.0 };
        public double[] misogi_halloween_reinforce = new double[15] { 0.0, 2.5, 0.0, 0.2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.05, 0.0, 0.0, 0.0, 0.0, 8.0 };
        public string misogi_halloween_name = "트릭 오어 트릭";

        public double[] mimi_halloween = new double[15] { 0, 77, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] mimi_halloween_reinforce = new double[15] { 0, 3.85, 0, 0, 0, 1.75, 0.9, 0, 0, 0, 0, 0, 0.1, 0, 0 };
        public string mimi_halloween_name = "빙글빙글 토끼 씨 블레이드";
        
        public double[] kyouka_halloween = new double[15] {0.0, 0.0, 96.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0 };
        public double[] kyouka_halloween_reinforce = new double[15] { 0.0, 0.0, 4.8, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.05, 0.0 };
        public string kyouka_halloween_name = "할로윈 고양이 지팡이";

        public double[] kaya = new double[15]{0.0, /*atk*/96.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/31.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0};
        public double[] kaya_reinforce = new double[15] { 0.0, /*atk*/4.8, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.55, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        
        public double[] runa = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/75.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/30.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/1.0,  /*accuracy*/0.0 };
        public double[] runa_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/3.75, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/1.5, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.05,  /*accuracy*/0.0 };

        public double[] inori = new double[15]{0.0, /*atk*/64.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/10.0};
        public double[] inori_reinforce = new double[15] { 0.0, /*atk*/3.2, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0,  /*accuracy*/0.5 };

        public double[] ram = new double[15] {0.0, /*atk*/33.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/40.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/5.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/15.0};
        public double[] ram_reinforce = new double[15] { 0.0, /*atk*/1.65, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/2.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.25, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };

        public double[] rem = new double[15] {0.0, /*atk*/0.0, /*magic_str*/52.0, /*def*/8.0, /*magic_def*/2.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};
        public double[] rem_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/2.6, /*def*/8.0, /*magic_def*/0.1, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };

        public double[] emilia = new double[15] {0.0, /*atk*/0.0, /*magic_str*/96.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/6.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};
        public double[] emilia_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.8, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.3, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };

        public double[] chieru = new double[15]{0.0, /*atk*/79.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/40.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};
         
        public double[] yuni = new double[15] {0.0, /*atk*/0.0, /*magic_str*/56.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/200.0, /*wave_energy_recovery*/30.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/1.0,  /*accuracy*/0.0};


        public double[] kristina_christmas = new double[15] {0.0, /*atk*/86.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/20.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/1.0,  /*accuracy*/0.0};

        public double[] nozomi_christmas = new double[15] {290.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/12.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/4.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] iriya_christmas = new double[15] { 100.0, /*atk*/0.0, /*magic_str*/75.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/8.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] kotkoro_newyear = new double[15] { 30.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/9.0, /*magic_def*/10.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] kyaru_newyear = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/74.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/10.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/25.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] suzume_newyear = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/67.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/10.0, /*energy_recovery_rate*/3.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] kasumi_magical = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/52.0, /*def*/4.0, /*magic_def*/6.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] siori_magical = new double[15] { 0.0, /*atk*/84.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/40.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] uzuki_deremas = new double[15] { 0.0, /*atk*/82.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/34.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] rin_deremas = new double[15] { 220.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/8.0, /*magic_def*/8.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] mio_deremas = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/90.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/16.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] rin_ranger = new double[15] { 0.0, /*atk*/78.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/25.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] mahiru_ranger = new double[15] { 0.0, /*atk*/87.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/26.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] rino_wonder= new double[15] { 0.0, /*atk*/80.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/30.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] ayumi_wonder = new double[15] { 210.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/10.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/3.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/1.0,  /*accuracy*/0.0};

        public double[] ruka_summer = new double[15] { 0.0, /*atk*/94.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/13.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] anna_summer = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/82.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/8.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] nanaka_summer = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/91.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] hatsune_summer = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/88.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/13.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] misato_summer = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/30.0, /*def*/0.0, /*magic_def*/12.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] zyun_summer = new double[15] { 100.0, /*atk*/89.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] akari_angel = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/80.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/13.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/2.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0};

        public double[] yori_angel = new double[15] { 300.0, /*atk*/0.0, /*magic_str*/64.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/1.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };

        public double[] kotkoro_newyear_reinforce = new double[15] { 1.5, /*atk*/0.0, /*magic_str*/0.0, /*def*/0.45, /*magic_def*/0.5, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        
        public double[] chieru_reinforce = new double[15] { 0.0, /*atk*/3.95, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/2.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] yuni_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/2.8, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/10.0, /*wave_energy_recovery*/1.5, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.05, /*accuracy*/0.0 };
        public double[] kristina_christmas_reinforce = new double[15] { 0.0, /*atk*/4.3, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.05, /*accuracy*/0.0 };
        public double[] nozomi_christmas_reinforce = new double[15] { 14.5, /*atk*/0.0, /*magic_str*/0.0, /*def*/0.6, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.2, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] iriya_christmas_reinforce = new double[15] { 5.0, /*atk*/0.0, /*magic_str*/3.75, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.4, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] pekorinnu_newyear_reinforce = new double[15] { 1.5, /*atk*/0.0, /*magic_str*/0.0, /*def*/0.45, /*magic_def*/0.5, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] kyaru_newyear_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/3.7, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.5, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/1.25, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] suzume_newyear_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/3.35, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.5, /*energy_recovery_rate*/0.15, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] kasumi_magical_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/2.6, /*def*/0.2, /*magic_def*/0.3, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] siori_magical_reinforce = new double[15] { 0.0, /*atk*/4.2, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/2.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] uzuki_deremas_reinforce = new double[15] { 0.0, /*atk*/4.1, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.7, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] rin_deremas_reinforce = new double[15] { 11.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/0.4, /*magic_def*/0.4, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] mio_deremas_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.5, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.8, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] rin_ranger_reinforce = new double[15] { 0.0, /*atk*/3.9, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.25, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] mahiru_ranger_reinforce = new double[15] { 0.0, /*atk*/4.35, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.3, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] rino_wonder_reinforce = new double[15] { 0.0, /*atk*/4.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/1.5, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] ayumi_wonder_reinforce = new double[15] { 10.5, /*atk*/0.0, /*magic_str*/0.0, /*def*/0.5, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.15, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.05, /*accuracy*/0.0 };
        public double[] ruka_summer_reinforce = new double[15] { 0.0, /*atk*/4.7, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.65, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] anna_summer_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.1, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.4, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] nanaka_summer_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.55, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] hatsune_summer_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.4, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.65, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] misato_summer_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/1.5, /*def*/0.0, /*magic_def*/0.6, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] zyun_summer_reinforce = new double[15] { 5.0, /*atk*/4.45, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] akari_angel_reinforce = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/4.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.65, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.1, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        public double[] yori_angel_reinforce = new double[15] { 15.0, /*atk*/0.0, /*magic_str*/3.2, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0, /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.05, /*energy_reduce_rate*/0.0, /*accuracy*/0.0 };
        
        /* HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 */
        /* 전용 장비에 따른 능력치는 전용 장비 능력치를 그대로 더하면 됨 */
        /* 전용 장비 착용자가 변수명이 됨 */
        /* 강화로 추가되는 스탯 순서도 동일: 전체 스탯 = 초기 장비 스탯 + 추가 장비 스탯 * ( 전용 장비 레벨 -1)
         * HP, 물공, 마공, 물방, 마방, 물크, 마크, HP 자동 회복, TP 자동 회복, 회피, HP 흡수, 회복량 상승, TP 상승, TP 소비 감소, 명중 
            0.0 	0.0 	0.0 	0.35 	0.6 	0.0 	0.0 	0.0 	0.0 	0.0 	0.0 	0.0 	0.0 	0.25 	0.0 	0.0 	0.0
         https://github.com/HerDataSam/redive_kr_db_diff/blob/master/unique_equipment_enhance_rate.csv 
        https://github.com/HerDataSam/redive_kr_db_diff/blob/master/unique_equipment_data.csv
        https://github.com/esterTion/redive_master_db_diff/blob/master/unique_equipment_enhance_rate.sql
        https://github.com/esterTion/redive_master_db_diff/blob/master/unique_equipment_data.sql
         */
    }

}
