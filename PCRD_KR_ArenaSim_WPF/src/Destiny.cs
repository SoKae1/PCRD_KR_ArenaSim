namespace PCRD_KR_ArenaSim
{

    class Destiny
    {
        /* 장비 랭크에 따른 능력치 = 랭크에 따른 보너스 능력치 + 성장 능력치*(랭크) 
         * 
         * 
         1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
        /* db상 데이터 1,2,3물방,4마공,5마방,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 
        https://github.com/esterTion/redive_master_db_diff/blob/master/chara_story_status.sql 일섭은 인연스탯 다를 수 있?나?
        https://github.com/HerDataSam/redive_kr_db_diff/blob/master/chara_story_status.csv
        작후유, 프캬루까지 넣음
        카오리 6성까지 넣음
         */
        public double[] hiyori_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_03 = new double[15] { 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_04 = new double[15] { 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_05 = new double[15] { 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_06 = new double[15] { 200, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_07 = new double[15] { 400, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_08 = new double[15] { 700, 255, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_09 = new double[15] { 700, 335, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_10 = new double[15] { 700, 415, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_11 = new double[15] { 700, 495, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_12 = new double[15] { 700, 695, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] hiyori_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_newyear_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yui_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_03 = new double[15] { 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_04 = new double[15] { 0, 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_05 = new double[15] { 0, 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_06 = new double[15] { 0, 0, 155, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_07 = new double[15] { 0, 0, 195, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_08 = new double[15] { 0, 0, 255, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] yui_09 = new double[15] { 0, 0, 335, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] yui_10 = new double[15] { 0, 0, 455, 4, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] yui_11 = new double[15] { 0, 0, 575, 8, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] yui_12 = new double[15] { 0, 0, 775, 15, 19, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] yui_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_newyear_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yui_princess_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_princess_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rei_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_03 = new double[15] { 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_04 = new double[15] { 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_05 = new double[15] { 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_06 = new double[15] { 200, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_07 = new double[15] { 400, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_08 = new double[15] { 700, 255, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_09 = new double[15] { 700, 335, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_10 = new double[15] { 700, 435, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_11 = new double[15] { 700, 535, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_12 = new double[15] { 1400, 685, 0, 0, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rei_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_04 = new double[15] { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_05 = new double[15] { 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_06 = new double[15] { 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_07 = new double[15] { 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_newyear_08 = new double[15] { 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] misogi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_03 = new double[15] { 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_04 = new double[15] { 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_05 = new double[15] { 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_06 = new double[15] { 0, 155, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_07 = new double[15] { 0, 195, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_08 = new double[15] { 200, 255, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_09 = new double[15] { 200, 335, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_10 = new double[15] { 200, 415, 0, 14, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_11 = new double[15] { 200, 495, 0, 14, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_12 = new double[15] { 200, 695, 0, 14, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
        /* db상 데이터 1,2,3물방,4마공,5,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */

        public double[] misogi_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misogi_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] matsuri_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_03 = new double[15] { 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_04 = new double[15] { 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_05 = new double[15] { 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_06 = new double[15] { 200, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_07 = new double[15] { 400, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_08 = new double[15] { 700, 255, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] akari_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_06 = new double[15] { 0, 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_07 = new double[15] { 0, 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_08 = new double[15] { 0, 0, 240, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] akari_09 = new double[15] { 0, 0, 320, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] akari_10 = new double[15] { 0, 0, 440, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] akari_11 = new double[15] { 0, 0, 560, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] akari_12 = new double[15] { 0, 0, 760, 0, 14, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0 };

        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */

        public double[] akari_angel_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akari_angel_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] miyako_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_02 = new double[15] { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_03 = new double[15] { 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_04 = new double[15] { 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_05 = new double[15] { 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_06 = new double[15] { 200, 0, 0, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_07 = new double[15] { 400, 0, 0, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_08 = new double[15] { 700, 0, 0, 48, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };

        public double[] miyako_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] miyako_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yuki_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_06 = new double[15] { 0, 0, 140, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_07 = new double[15] { 0, 0, 180, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuki_08 = new double[15] { 0, 0, 240, 14, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] anna_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] anna_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anna_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] maho_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_02 = new double[15] { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_03 = new double[15] { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_04 = new double[15] { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_05 = new double[15] { 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_06 = new double[15] { 0, 0, 20, 0, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_07 = new double[15] { 0, 0, 40, 0, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_08 = new double[15] { 0, 0, 70, 0, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] maho_09 = new double[15] { 0, 0, 150, 0, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] maho_10 = new double[15] { 0, 0, 230, 8, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] maho_11 = new double[15] { 0, 0, 310, 16, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] maho_12 = new double[15] { 0, 0, 430, 31, 53, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] maho_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rino_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_09 = new double[15] { 0, 390, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_10 = new double[15] { 0, 510, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_11 = new double[15] { 0, 630, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_12 = new double[15] { 0, 840, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 20 };

        public double[] rino_wonder_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_04 = new double[15] { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_05 = new double[15] { 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_06 = new double[15] { 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_07 = new double[15] { 0, 0, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rino_wonder_08 = new double[15] { 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] hatsune_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_09 = new double[15] { 0, 0, 390, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_10 = new double[15] { 0, 0, 510, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_11 = new double[15] { 0, 0, 630, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_12 = new double[15] { 0, 0, 830, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] hatsune_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hatsune_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] nanaka_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_08 = new double[15] { 0, 0, 310, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };

        public double[] nanaka_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nanaka_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kasumi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_02 = new double[15] { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_03 = new double[15] { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_04 = new double[15] { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_05 = new double[15] { 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_06 = new double[15] { 0, 0, 20, 0, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_07 = new double[15] { 0, 0, 40, 0, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_08 = new double[15] { 0, 0, 70, 0, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] kasumi_magical_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_magical_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] misato_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_03 = new double[15] { 0, 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_04 = new double[15] { 0, 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_05 = new double[15] { 0, 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_06 = new double[15] { 0, 0, 155, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_07 = new double[15] { 0, 0, 195, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_08 = new double[15] { 0, 0, 255, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] misato_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misato_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] suzuna_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_06 = new double[15] { 200, 140, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_07 = new double[15] { 400, 180, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_08 = new double[15] { 700, 240, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_09 = new double[15] { 700, 320, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_10 = new double[15] { 700, 440, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_11 = new double[15] { 700, 560, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_12 = new double[15] { 700, 760, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] suzuna_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzuna_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kaori_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_09 = new double[15] { 0, 380, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_10 = new double[15] { 0, 480, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_11 = new double[15] { 0, 580, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_12 = new double[15] { 0, 710, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        // 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중
        /* db상 데이터 1,2,3물방,4마공,5마방,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */
        public double[] kaori_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaori_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] io_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_06 = new double[15] { 0, 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_07 = new double[15] { 0, 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_08 = new double[15] { 0, 0, 240, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] io_09 = new double[15] { 0, 0, 320, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] io_10 = new double[15] { 0, 0, 400, 0, 22, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] io_11 = new double[15] { 0, 0, 480, 8, 22, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] io_12 = new double[15] { 0, 0, 600, 18, 32, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] io_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] io_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mimi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_06 = new double[15] { 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_07 = new double[15] { 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_08 = new double[15] { 200, 240, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_09 = new double[15] { 200, 320, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_10 = new double[15] { 200, 400, 0, 14, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_11 = new double[15] { 200, 480, 0, 14, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_12 = new double[15] { 200, 680, 0, 14, 0, 140, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
        /* db상 데이터 1,2,3물방,4마공,5,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */
        public double[] mimi_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mimi_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kurumi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_02 = new double[15] { 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_03 = new double[15] { 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_04 = new double[15] { 600, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_05 = new double[15] { 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_06 = new double[15] { 1400, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_07 = new double[15] { 1800, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_08 = new double[15] { 2400, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_09 = new double[15] { 2400, 80, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_10 = new double[15] { 2400, 160, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_11 = new double[15] { 2400, 240, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_12 = new double[15] { 2400, 320, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20 };

        public double[] kurumi_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_04 = new double[15] { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_05 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_06 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_07 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kurumi_christmas_08 = new double[15] { 0, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yori_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_06 = new double[15] { 0, 0, 140, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_07 = new double[15] { 0, 0, 180, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_08 = new double[15] { 0, 0, 240, 14, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0 };
        public double[] yori_09 = new double[15] { 0, 0, 320, 14, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0 };
        public double[] yori_10 = new double[15] { 0, 0, 400, 14, 0, 0, 20, 0, 0, 0, 4, 0, 0, 0, 0 };
        public double[] yori_11 = new double[15] { 0, 0, 480, 14, 0, 0, 40, 0, 0, 0, 4, 0, 0, 0, 0 };
        public double[] yori_12 = new double[15] { 0, 0, 680, 14, 0, 0, 70, 0, 0, 0, 4, 0, 0, 0, 0 };

        public double[] yori_angel_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yori_angel_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ayane_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_03 = new double[15] { 0, 45, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_04 = new double[15] { 0, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_05 = new double[15] { 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_06 = new double[15] { 200, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_07 = new double[15] { 400, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_08 = new double[15] { 700, 255, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_09 = new double[15] { 700, 335, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_10 = new double[15] { 700, 415, 0, 4, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_11 = new double[15] { 700, 495, 0, 8, 8, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_12 = new double[15] { 700, 615, 0, 18, 18, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ayane_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayane_christmas_08 = new double[15] { 0, 70, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] suzume_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_06 = new double[15] { 0, 0, 140, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_07 = new double[15] { 0, 0, 180, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_08 = new double[15] { 0, 0, 240, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_09 = new double[15] { 0, 0, 320, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_10 = new double[15] { 0, 0, 440, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_11 = new double[15] { 0, 0, 560, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_12 = new double[15] { 0, 0, 760, 14, 4, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0 };

        /*1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중*/
        /* db상 데이터 1,2,3물방,4마공,5마방,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */
        public double[] suzume_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_summer_08 = new double[15] { 0, 0, 60, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] suzume_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] suzume_newyear_08 = new double[15] { 0, 0, 60, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rin_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_06 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] rin_07 = new double[15] { 0, 180, 0, 0, 0, 0, 0, 0, 120, 0, 0, 0, 0, 0, 0 };
        public double[] rin_08 = new double[15] { 0, 240, 0, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };

        public double[] rin_ranger_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_ranger_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] eriko_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_08 = new double[15] { 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] eriko_valentine_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] eriko_valentine_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] saren_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_06 = new double[15] { 200, 140, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_07 = new double[15] { 400, 180, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_08 = new double[15] { 700, 240, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_09 = new double[15] { 700, 320, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_10 = new double[15] { 700, 400, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_11 = new double[15] { 700, 480, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_12 = new double[15] { 700, 680, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] saren_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_04 = new double[15] { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_05 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_06 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_07 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_summer_08 = new double[15] { 0, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] nozomi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_02 = new double[15] { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_03 = new double[15] { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_04 = new double[15] { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_05 = new double[15] { 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_06 = new double[15] { 0, 0, 0, 4, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_07 = new double[15] { 0, 0, 0, 8, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_08 = new double[15] { 0, 0, 0, 14, 48, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_09 = new double[15] { 0, 0, 0, 20, 60, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_10 = new double[15] { 0, 0, 0, 28, 76, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_11 = new double[15] { 0, 0, 0, 36, 92, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_12 = new double[15] { 0, 0, 0, 52, 120, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };

        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
        /* db상 데이터 1,2,3물방,4마공,5마방,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */
        public double[] nozomi_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_04 = new double[15] { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_05 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_06 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_07 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] nozomi_christmas_08 = new double[15] { 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ninon_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_06 = new double[15] { 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_07 = new double[15] { 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_08 = new double[15] { 0, 240, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_09 = new double[15] { 0, 320, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_10 = new double[15] { 0, 400, 0, 14, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_11 = new double[15] { 0, 480, 0, 14, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_12 = new double[15] { 0, 680, 0, 14, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ninon_ooedo_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ninon_ooedo_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] sinobu_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_08 = new double[15] { 0, 240, 0, 0, 4, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] sinobu_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sinobu_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] akino_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_06 = new double[15] { 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_07 = new double[15] { 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_08 = new double[15] { 0, 240, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_09 = new double[15] { 0, 320, 0, 14, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_10 = new double[15] { 0, 420, 0, 14, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_11 = new double[15] { 0, 520, 0, 14, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_12 = new double[15] { 0, 645, 0, 14, 0, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mahiru_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_06 = new double[15] { 0, 140, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_07 = new double[15] { 0, 180, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_08 = new double[15] { 0, 240, 0, 0, 14, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_09 = new double[15] { 0, 320, 0, 0, 14, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_10 = new double[15] { 0, 400, 0, 0, 14, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_11 = new double[15] { 0, 400, 0, 0, 14, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_12 = new double[15] { 0, 610, 0, 0, 14, 90, 0, 0, 0, 0, 0, 0, 0, 0, 20 };
        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */


        public double[] mahiru_ranger_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mahiru_ranger_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yukari_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_06 = new double[15] { 0, 140, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_07 = new double[15] { 0, 180, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_08 = new double[15] { 200, 240, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_09 = new double[15] { 200, 320, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_10 = new double[15] { 200, 400, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_11 = new double[15] { 200, 480, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_12 = new double[15] { 200, 600, 0, 8, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kyouka_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_09 = new double[15] { 0, 0, 390, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_10 = new double[15] { 0, 0, 470, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_11 = new double[15] { 0, 0, 550, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_12 = new double[15] { 0, 0, 750, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0 };


        /* db상 데이터 1,2,3물방,4마공,5,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 
        /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
        public double[] kyouka_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyouka_halloween_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] tomo_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] siori_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] siori_magical_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] siori_magical_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] aoi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_06 = new double[15] { 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_07 = new double[15] { 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_08 = new double[15] { 0, 240, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] aoi_nakayosi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_nakayosi_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] chika_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_06 = new double[15] { 0, 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_07 = new double[15] { 0, 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_08 = new double[15] { 0, 0, 240, 0, 14, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] chika_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chika_christmas_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] makoto_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_08 = new double[15] { 0, 260, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] makoto_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] iriya_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] iriya_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] iriya_christmas_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kuuka_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_02 = new double[15] { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_03 = new double[15] { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_04 = new double[15] { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_05 = new double[15] { 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_06 = new double[15] { 0, 0, 0, 4, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_07 = new double[15] { 0, 0, 0, 8, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_08 = new double[15] { 0, 0, 0, 14, 48, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };

        public double[] kuuka_ooedo_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_04 = new double[15] { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_05 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_06 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_07 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kuuka_ooedo_08 = new double[15] { 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] tamaki_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] tamaki_09 = new double[15] { 0, 320, 0, 0, 0, 35, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] tamaki_10 = new double[15] { 0, 400, 0, 0, 0, 75, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] tamaki_11 = new double[15] { 0, 480, 0, 0, 0, 115, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] tamaki_12 = new double[15] { 0, 680, 0, 0, 0, 175, 0, 0, 0, 3, 0, 0, 0, 0, 0 };

        public double[] tamaki_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] zyun_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_02 = new double[15] { 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_03 = new double[15] { 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_04 = new double[15] { 600, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_05 = new double[15] { 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_06 = new double[15] { 1400, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_07 = new double[15] { 1800, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_08 = new double[15] { 2400, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] zyun_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zyun_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mihuyu_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_06 = new double[15] { 0, 140, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_07 = new double[15] { 0, 180, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_08 = new double[15] { 0, 240, 0, 14, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0 };
        public double[] mihuyu_09 = new double[15] { 0, 320, 0, 14, 0, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0 };
        public double[] mihuyu_10 = new double[15] { 0, 400, 0, 14, 0, 40, 0, 0, 0, 0, 0, 20, 0, 0, 0 };
        public double[] mihuyu_11 = new double[15] { 0, 480, 0, 14, 0, 80, 0, 0, 0, 0, 0, 20, 0, 0, 0 };
        public double[] mihuyu_12 = new double[15] { 0, 680, 0, 14, 0, 140, 0, 0, 0, 0, 0, 20, 0, 0, 0 };

        public double[] mihuyu_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] sizuru_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_02 = new double[15] { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_03 = new double[15] { 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_04 = new double[15] { 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_05 = new double[15] { 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_06 = new double[15] { 0, 0, 0, 28, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_07 = new double[15] { 0, 0, 0, 36, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_08 = new double[15] { 200, 0, 0, 48, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_09 = new double[15] { 200, 80, 0, 48, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_10 = new double[15] { 200, 180, 0, 48, 14, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] sizuru_11 = new double[15] { 200, 280, 0, 48, 14, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };
        public double[] sizuru_12 = new double[15] { 200, 480, 0, 51, 14, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0 };

        public double[] sizuru_valentine_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] sizuru_valentine_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] misaki_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_06 = new double[15] { 0, 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_07 = new double[15] { 0, 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_08 = new double[15] { 0, 0, 240, 0, 0, 0, 35, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] misaki_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_05 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_06 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_07 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] misaki_halloween_08 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mitsuki_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mitsuki_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] rima_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_02 = new double[15] { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_03 = new double[15] { 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_04 = new double[15] { 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_05 = new double[15] { 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_06 = new double[15] { 0, 0, 0, 28, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_07 = new double[15] { 0, 0, 0, 36, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_08 = new double[15] { 200, 0, 0, 48, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_09 = new double[15] { 200, 0, 0, 66, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_10 = new double[15] { 200, 0, 0, 90, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_11 = new double[15] { 200, 0, 0, 114, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_12 = new double[15] { 200, 0, 0, 150, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] monika_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_08 = new double[15] { 0, 240, 0, 0, 4, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] tsumugi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] tsumugi_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_04 = new double[15] { 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_05 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_06 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_07 = new double[15] { 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tsumugi_halloween_08 = new double[15] { 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        public double[] ayumi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] ayumi_wonder_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ayumi_wonder_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ruka_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_02 = new double[15] { 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_03 = new double[15] { 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_04 = new double[15] { 600, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_05 = new double[15] { 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_06 = new double[15] { 1400, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_07 = new double[15] { 1800, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_08 = new double[15] { 2400, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ruka_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ruka_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] zita_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] zita_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] pekorinnu_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_02 = new double[15] { 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_03 = new double[15] { 300, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_04 = new double[15] { 600, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_05 = new double[15] { 1000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_06 = new double[15] { 1400, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_07 = new double[15] { 1800, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_08 = new double[15] { 2400, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_09 = new double[15] { 3200, 0, 0, 14, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_10 = new double[15] { 4000, 0, 0, 22, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_11 = new double[15] { 4800, 0, 0, 30, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_12 = new double[15] { 6000, 0, 0, 42, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] pekorinnu_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_summer_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] pekorinnu_princess_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_princess_08 = new double[15] { 0, 60, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kotkoro_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_06 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_07 = new double[15] { 0, 180, 0, 0, 0, 0, 0, 0, 120, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_08 = new double[15] { 0, 240, 0, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_09 = new double[15] { 0, 320, 0, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_10 = new double[15] { 0, 400, 0, 8, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_11 = new double[15] { 0, 480, 0, 16, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_12 = new double[15] { 0, 600, 0, 28, 12, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };

        public double[] kotkoro_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_summer_08 = new double[15] { 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 };

        public double[] kotkoro_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_newyear_08 = new double[15] { 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 };

        public double[] kotkoro_princess_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_princess_08 = new double[15] { 0, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };

        public double[] kyaru_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_06 = new double[15] { 0, 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_07 = new double[15] { 0, 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_08 = new double[15] { 0, 0, 240, 0, 0, 0, 35, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_09 = new double[15] { 0, 0, 320, 0, 0, 0, 35, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_10 = new double[15] { 0, 0, 400, 0, 0, 0, 55, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_11 = new double[15] { 0, 0, 480, 0, 0, 0, 75, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_12 = new double[15] { 0, 0, 600, 0, 0, 0, 105, 0, 180, 0, 0, 0, 0, 0, 0 };

        public double[] kyaru_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_04 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_05 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_06 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_07 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_summer_08 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kyaru_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_04 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_05 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_06 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_07 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_newyear_08 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] muimi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_05 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_07 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] arisa_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] arisa_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kaya_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] inori_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_08 = new double[15] { 0, 240, 0, 0, 0, 35, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] labyrista_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_05 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_06 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_07 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] labyrista_08 = new double[15] { 0, 240, 0, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };

        public double[] neneka_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_05 = new double[15] { 0, 0, 140, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_06 = new double[15] { 0, 0, 140, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_07 = new double[15] { 0, 0, 140, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_08 = new double[15] { 0, 0, 240, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };

        public double[] kristina_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_05 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_06 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_07 = new double[15] { 0, 140, 0, 0, 0, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_08 = new double[15] { 0, 240, 0, 0, 4, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0 };

        public double[] kristina_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kristina_christmas_08 = new double[15] { 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };

        public double[] anne_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] anne_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] lou_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] lou_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] grea_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] grea_08 = new double[15] { 0, 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rem_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_05 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_07 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rem_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] ram_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] ram_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] emilia_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] emilia_08 = new double[15] { 0, 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] chloe_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] chieru_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_06 = new double[15] { 0, 140, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_07 = new double[15] { 0, 180, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_08 = new double[15] { 0, 260, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yuni_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_02 = new double[15] { 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_03 = new double[15] { 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_04 = new double[15] { 0, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_05 = new double[15] { 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_06 = new double[15] { 0, 0, 0, 4, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_07 = new double[15] { 0, 0, 0, 8, 36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yuni_08 = new double[15] { 0, 0, 0, 14, 48, 0, 0, 0, 60, 0, 0, 0, 0, 0, 0 };

        public double[] runa_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_02 = new double[15] { 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_03 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_05 = new double[15] { 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_07 = new double[15] { 0, 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] runa_08 = new double[15] { 0, 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] uzuki_deremas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_05 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_07 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] uzuki_deremas_08 = new double[15] { 0, 310, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rin_deremas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_04 = new double[15] { 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_05 = new double[15] { 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_06 = new double[15] { 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_07 = new double[15] { 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rin_deremas_08 = new double[15] { 0, 0, 0, 26, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mio_deremas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_04 = new double[15] { 0, 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_05 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_06 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_07 = new double[15] { 0, 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mio_deremas_08 = new double[15] { 0, 0, 285, 0, 0, 0, 10, 0, 0, 0, 0, 15, 0, 0, 0 };


        public double[] rei_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rei_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] matsuri_halloween_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] matsuri_halloween_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] monika_magical_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] monika_magical_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] tomo_magical_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tomo_magical_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] akino_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] akino_christmas_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] saren_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] saren_christmas_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yukari_christmas_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yukari_christmas_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        public double[] pekorinnu_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] pekorinnu_newyear_08 = new double[15] { 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };

        public double[] muimi_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] muimi_newyear_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] neneka_newyear_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] neneka_newyear_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kotkoro_maiden_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_05 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_06 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_07 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kotkoro_maiden_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] yui_maiden_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] yui_maiden_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] hiyori_princess_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] hiyori_princess_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kyaru_princess_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kyaru_princess_08 = new double[15] { 0, 0, 65, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };

        public double[] kasumi_summer_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kasumi_summer_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] shepi_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_02 = new double[15] { 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_03 = new double[15] { 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_04 = new double[15] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_05 = new double[15] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_06 = new double[15] { 0, 160, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_07 = new double[15] { 0, 220, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] shepi_08 = new double[15] { 0, 310, 0, 0, 0, 10, 0, 0, 0, 0, 0, 10, 0, 0, 0 };

        public double[] maho_cinderella_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_04 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_05 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_06 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_07 = new double[15] { 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] maho_cinderella_08 = new double[15] { 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] makoto_cinderella_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] makoto_cinderella_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] rima_cinderella_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] rima_cinderella_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] chloe_terefes_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chloe_terefes_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] chieru_terefes_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] chieru_terefes_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] inori_timetravel_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] inori_timetravel_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] kaya_timetravel_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] kaya_timetravel_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] aoi_worker_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] aoi_worker_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] tamaki_worker_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] tamaki_worker_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public double[] mihuyu_worker_01 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_02 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_03 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_04 = new double[15] { 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_05 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_06 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_07 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] mihuyu_worker_08 = new double[15] { 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }
    /* 1HP, 2물공, 3마공, 4물방, 5마방, 6물크, 7마크, 8HP 자동 회복, 9TP 자동 회복, 10회피, 11HP 흡수, 12회복량 상승, 13TP 상승, 14TP 소비 감소, 15명중 */
    /* db상 데이터 1,2물공,3물방,4마공,5,6물크,7마크,8,9HP 흡수,10,11,12,13,14,15 */

}
