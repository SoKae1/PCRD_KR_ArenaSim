namespace PCRD_KR_ArenaSim
{

    class Equipment
    {
        /* 0HP, 1물공, 2마공, 3물방, 4마방, 5물크, 6마크, 7HP 자동 회복,8 TP 자동 회복, 9회피, 10HP 흡수,11 회복량 상승, 12TP 상승, 13TP 소비 감소, 14명중 */
        /* 장비에 따른 능력치는 장비 능력치를 그대로 더하면 됨 */
        /* 장비 번호가 변수명이 됨 
         { 0hp, 1atk, 2magic_str, 3def, 4magic_def, 5physical_critical, 6magic_critical,7wave_hp_recovery, 
        8wave_energy_recovery, 9dodge, 10life_steal, 11hp_recovery_rate, 12energy_recovery_rate, 13energy_reduce_rate,  14accuracy };
    https://github.com/esterTion/redive_master_db_diff/blob/master/equipment_data.sql
        https://github.com/HerDataSam/redive_kr_db_diff/blob/master/equipment_data.csv
         
        18랭 4템까지 (한섭 db)
        22랭 3템까지 (일섭 db)
         */
        public double[] E101011 = new double[15] { 15, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101071 = new double[15] { 0, 6, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101101 = new double[15] { 0, 4, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0 };
        public double[] E101131 = new double[15] { 0, 3, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101161 = new double[15] { 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101191 = new double[15] { 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101251 = new double[15] { 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101281 = new double[15] { 50, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101371 = new double[15] { 55, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101401 = new double[15] { 15, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101431 = new double[15] { 15, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        public double[] E101521 = new double[15] { 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101551 = new double[15] { 0, 3, 0, 1, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101581 = new double[15] { 0, 0, 0, 1, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E101611 = new double[15] { 0, 0, 3, 0, 1, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102011 = new double[15] { 30, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102013 = new double[15] { 60, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102014 = new double[15] { 0, 27, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102041 = new double[15] { 35, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102071 = new double[15] { 0, 13, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0 };
        public double[] E102101 = new double[15] { 0, 27, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0 };
        public double[] E102131 = new double[15] { 0, 27, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102162 = new double[15] { 0, 12, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102163 = new double[15] { 0, 20, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102191 = new double[15] { 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102192 = new double[15] { 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102221 = new double[15] { 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102222 = new double[15] { 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102251 = new double[15] { 0, 0, 13, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102252 = new double[15] { 0, 0, 27, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102281 = new double[15] { 90, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102282 = new double[15] { 150, 7, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102311 = new double[15] { 95, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102312 = new double[15] { 180, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102341 = new double[15] { 90, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102342 = new double[15] { 120, 7, 0, 1, 1, 0, 0, 110, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102371 = new double[15] { 65, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102372 = new double[15] { 120, 0, 7, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102401 = new double[15] { 135, 7, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102431 = new double[15] { 30, 2, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        public double[] E102432 = new double[15] { 60, 3, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E102461 = new double[15] { 30, 0, 8, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102491 = new double[15] { 90, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102493 = new double[15] { 90, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102521 = new double[15] { 0, 0, 7, 1, 3, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };
        public double[] E102551 = new double[15] { 0, 11, 0, 0, 0, 0, 0, 30, 5, 0, 0, 0, 0, 0, 0 };
        public double[] E102552 = new double[15] { 0, 20, 0, 1, 0, 0, 0, 0, 10, 0, 0, 5, 0, 0, 0 };
        public double[] E102581 = new double[15] { 55, 0, 0, 1, 1, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102582 = new double[15] { 120, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102611 = new double[15] { 0, 0, 11, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102612 = new double[15] { 0, 0, 10, 0, 0, 0, 0, 25, 5, 0, 0, 0, 0, 0, 0 };
        public double[] E102613 = new double[15] { 0, 0, 24, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E102614 = new double[15] { 0, 0, 20, 0, 1, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0 };
        public double[] E103011 = new double[15] { 90, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103012 = new double[15] { 115, 53, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103013 = new double[15] { 135, 61, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103041 = new double[15] { 65, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103042 = new double[15] { 75, 68, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103071 = new double[15] { 0, 40, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0 };
        public double[] E103072 = new double[15] { 0, 61, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 };
        public double[] E103101 = new double[15] { 0, 53, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0 };
        public double[] E103131 = new double[15] { 0, 53, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103132 = new double[15] { 0, 61, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103161 = new double[15] { 0, 35, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103162 = new double[15] { 0, 46, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103191 = new double[15] { 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103192 = new double[15] { 0, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103193 = new double[15] { 0, 77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103221 = new double[15] { 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103222 = new double[15] { 0, 0, 77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103251 = new double[15] { 0, 0, 40, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103252 = new double[15] { 0, 0, 53, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103281 = new double[15] { 245, 11, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103282 = new double[15] { 325, 15, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103283 = new double[15] { 380, 17, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103311 = new double[15] { 245, 0, 0, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103341 = new double[15] { 180, 10, 0, 1, 1, 0, 0, 160, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103342 = new double[15] { 235, 13, 0, 2, 1, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103343 = new double[15] { 205, 15, 0, 2, 2, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103371 = new double[15] { 235, 0, 13, 2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103372 = new double[15] { 245, 0, 14, 2, 4, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] E103401 = new double[15] { 290, 8, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103431 = new double[15] { 90, 5, 0, 2, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] E103432 = new double[15] { 115, 26, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0 };
        public double[] E103461 = new double[15] { 115, 0, 20, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103491 = new double[15] { 235, 0, 0, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103521 = new double[15] { 90, 0, 20, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103522 = new double[15] { 115, 0, 26, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103551 = new double[15] { 0, 33, 0, 3, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103552 = new double[15] { 0, 44, 0, 2, 0, 0, 0, 235, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103553 = new double[15] { 70, 54, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103581 = new double[15] { 180, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103582 = new double[15] { 0, 26, 0, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103583 = new double[15] { 270, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E103611 = new double[15] { 0, 0, 30, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E103612 = new double[15] { 0, 0, 10, 0, 5, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0 };
        public double[] E103613 = new double[15] { 0, 0, 39, 0, 0, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0 };
        public double[] E103614 = new double[15] { 0, 0, 46, 0, 3, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0 };
        public double[] E104011 = new double[15] { 165, 73, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104012 = new double[15] { 70, 80, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0 };
        public double[] E104013 = new double[15] { 0, 85, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 5, 0, 0 };
        public double[] E104014 = new double[15] { 140, 95, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        public double[] E104041 = new double[15] { 80, 73, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        public double[] E104042 = new double[15] { 0, 84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0 };
        public double[] E104043 = new double[15] { 0, 105, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104044 = new double[15] { 0, 110, 0, 0, 0, 10, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104071 = new double[15] { 0, 73, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E104072 = new double[15] { 50, 75, 0, 0, 0, 0, 0, 300, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104073 = new double[15] { 0, 80, 0, 0, 5, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104074 = new double[15] { 100, 84, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 5 };
        public double[] E104101 = new double[15] { 0, 73, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E104102 = new double[15] { 0, 81, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 12, 0, 0 };
        public double[] E104103 = new double[15] { 0, 90, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 5, 0 };
        public double[] E104104 = new double[15] { 0, 100, 0, 0, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104131 = new double[15] { 0, 73, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104132 = new double[15] { 0, 65, 0, 0, 4, 0, 0, 120, 0, 0, 0, 0, 5, 0, 0 };
        public double[] E104133 = new double[15] { 0, 75, 0, 0, 6, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104134 = new double[15] { 0, 80, 0, 0, 4, 0, 0, 60, 0, 0, 0, 0, 0, 0, 5 };
        public double[] E104161 = new double[15] { 0, 64, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104162 = new double[15] { 0, 68, 0, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104163 = new double[15] { 0, 85, 0, 3, 2, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104164 = new double[15] { 0, 80, 0, 3, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] E104191 = new double[15] { 0, 91, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104192 = new double[15] { 0, 97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104193 = new double[15] { 0, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104194 = new double[15] { 0, 120, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104221 = new double[15] { 0, 0, 91, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104222 = new double[15] { 0, 0, 92, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
        public double[] E104223 = new double[15] { 0, 0, 104, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104224 = new double[15] { 0, 0, 108, 0, 0, 0, 5, 100, 0, 0, 1, 0, 0, 0, 0 };
        public double[] E104251 = new double[15] { 0, 0, 73, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104252 = new double[15] { 0, 0, 67, 0, 4, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0 };
        public double[] E104253 = new double[15] { 0, 0, 77, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0 };
        public double[] E104254 = new double[15] { 0, 0, 86, 0, 4, 0, 0, 100, 0, 0, 0, 5, 0, 0, 0 };
        public double[] E104281 = new double[15] { 450, 20, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104282 = new double[15] { 250, 25, 0, 3, 2, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E104283 = new double[15] { 150, 35, 0, 5, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104284 = new double[15] { 160, 44, 0, 4, 3, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104311 = new double[15] { 450, 0, 0, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104312 = new double[15] { 300, 0, 0, 4, 4, 0, 0, 400, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104313 = new double[15] { 300, 0, 0, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104314 = new double[15] { 100, 0, 0, 7, 10, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
        public double[] E104341 = new double[15] { 360, 10, 0, 2, 2, 0, 0, 325, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104342 = new double[15] { 180, 35, 0, 5, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
        public double[] E104343 = new double[15] { 200, 45, 0, 3, 2, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104344 = new double[15] { 200, 30, 0, 7, 0, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104371 = new double[15] { 165, 0, 37, 2, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0 };
        public double[] E104372 = new double[15] { 240, 0, 37, 2, 4, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] E104373 = new double[15] { 200, 0, 25, 4, 6, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0 };
        public double[] E104401 = new double[15] { 165, 18, 0, 4, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0 };
        public double[] E104402 = new double[15] { 0, 50, 0, 4, 4, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 };
        public double[] E104431 = new double[15] { 165, 9, 0, 4, 2, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0 };
        public double[] E104432 = new double[15] { 220, 0, 0, 3, 3, 0, 0, 0, 0, 5, 0, 15, 0, 0, 0 };
        public double[] E104433 = new double[15] { 0, 38, 0, 0, 3, 0, 0, 0, 0, 5, 0, 10, 0, 0, 0 };
        public double[] E104461 = new double[15] { 165, 0, 27, 4, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104462 = new double[15] { 100, 0, 15, 1, 12, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104463 = new double[15] { 40, 0, 50, 0, 5, 0, 7, 0, 0, 0, 0, 0, 0, 2, 0 };
        public double[] E104491 = new double[15] { 490, 18, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104521 = new double[15] { 165, 0, 37, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104522 = new double[15] { 90, 0, 45, 0, 4, 0, 5, 0, 20, 0, 0, 0, 0, 0, 0 };
        public double[] E104523 = new double[15] { 100, 0, 45, 3, 5, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104551 = new double[15] { 0, 66, 0, 2, 0, 10, 0, 0, 0, 0, 0, 0, 5, 0, 0 };
        public double[] E104552 = new double[15] { 0, 70, 0, 0, 2, 10, 0, 0, 0, 0, 0, 10, 0, 0, 0 };
        public double[] E104553 = new double[15] { 200, 74, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104554 = new double[15] { 0, 54, 0, 0, 0, 8, 0, 0, 0, 2, 0, 0, 0, 0, 10 };
        public double[] E104581 = new double[15] { 240, 0, 10, 5, 6, 0, 0, 200, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104582 = new double[15] { 300, 0, 0, 9, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104583 = new double[15] { 200, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0 };
        public double[] E104611 = new double[15] { 100, 0, 60, 0, 0, 0, 6, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E104612 = new double[15] { 120, 0, 70, 0, 0, 0, 8, 120, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E104613 = new double[15] { 0, 0, 80, 0, 0, 0, 10, 0, 16, 0, 0, 0, 0, 0, 0 };
        public double[] E105011 = new double[15] { 120, 105, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105012 = new double[15] { 120, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105013 = new double[15] { 140, 120, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0 };
        public double[] E105014 = new double[15] { 160, 132, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105015 = new double[15] { 60, 145, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105016 = new double[15] { 80, 153, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105017 = new double[15] { 60, 167, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105041 = new double[15] { 0, 118, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105042 = new double[15] { 0, 120, 0, 0, 0, 12, 0, 0, 0, 0, 0, 6, 0, 0, 0 };
        public double[] E105043 = new double[15] { 0, 125, 0, 0, 0, 14, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        public double[] E105044 = new double[15] { 80, 134, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105045 = new double[15] { 100, 120, 0, 4, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105046 = new double[15] { 0, 150, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 2 };
        public double[] E105047 = new double[15] { 0, 172, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105071 = new double[15] { 120, 100, 0, 0, 0, 20, 0, 150, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105072 = new double[15] { 40, 115, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] E105073 = new double[15] { 60, 120, 0, 0, 0, 16, 0, 120, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105074 = new double[15] { 110, 124, 0, 0, 0, 20, 0, 0, 6, 0, 0, 0, 0, 0, 0 };
        public double[] E105075 = new double[15] { 0, 146, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105076 = new double[15] { 0, 161, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105077 = new double[15] { 0, 153, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 4 };
        public double[] E105101 = new double[15] { 0, 120, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105102 = new double[15] { 0, 130, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105103 = new double[15] { 0, 120, 0, 3, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105104 = new double[15] { 0, 124, 0, 4, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105105 = new double[15] { 0, 111, 0, 0, 6, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105106 = new double[15] { 0, 154, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105107 = new double[15] { 0, 133, 0, 4, 3, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105131 = new double[15] { 0, 100, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] E105132 = new double[15] { 0, 110, 0, 0, 3, 7, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        public double[] E105133 = new double[15] { 0, 126, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105134 = new double[15] { 0, 132, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105135 = new double[15] { 0, 137, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105136 = new double[15] { 0, 139, 0, 4, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105137 = new double[15] { 0, 160, 0, 0, 2, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105161 = new double[15] { 0, 98, 0, 4, 2, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105162 = new double[15] { 0, 92, 0, 4, 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E105163 = new double[15] { 0, 102, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105164 = new double[15] { 0, 113, 0, 3, 3, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0 };
        public double[] E105165 = new double[15] { 0, 141, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105166 = new double[15] { 150, 127, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105167 = new double[15] { 250, 139, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105191 = new double[15] { 0, 120, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1 };
        public double[] E105192 = new double[15] { 0, 120, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] E105193 = new double[15] { 60, 130, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105194 = new double[15] { 0, 140, 0, 0, 0, 12, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105195 = new double[15] { 0, 151, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105196 = new double[15] { 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105197 = new double[15] { 200, 150, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105221 = new double[15] { 0, 0, 100, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 3, 0 };
        public double[] E105222 = new double[15] { 0, 0, 110, 0, 0, 0, 12, 0, 20, 0, 0, 0, 0, 0, 0 };
        public double[] E105223 = new double[15] { 0, 0, 118, 0, 0, 0, 14, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] E105224 = new double[15] { 0, 0, 128, 0, 0, 0, 16, 0, 10, 0, 0, 0, 0, 0, 0 };
        public double[] E105225 = new double[15] { 0, 0, 146, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105226 = new double[15] { 0, 0, 154, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0 };
        public double[] E105227 = new double[15] { 0, 0, 172, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105251 = new double[15] { 0, 0, 95, 0, 4, 0, 0, 120, 0, 0, 0, 6, 0, 0, 0 };
        public double[] E105252 = new double[15] { 0, 0, 92, 2, 3, 0, 0, 0, 10, 0, 0, 0, 0, 2, 0 };
        public double[] E105253 = new double[15] { 0, 0, 100, 3, 4, 0, 0, 120, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105254 = new double[15] { 60, 0, 110, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105255 = new double[15] { 0, 0, 127, 2, 2, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0 };
        public double[] E105256 = new double[15] { 0, 0, 152, 1, 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
        public double[] E105257 = new double[15] { 0, 0, 136, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105281 = new double[15] { 100, 32, 0, 6, 4, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] E105282 = new double[15] { 80, 42, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105283 = new double[15] { 80, 44, 0, 7, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105284 = new double[15] { 0, 48, 0, 6, 6, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0 };
        public double[] E105285 = new double[15] { 0, 70, 0, 8, 2, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105286 = new double[15] { 0, 81, 0, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105287 = new double[15] { 0, 92, 0, 3, 5, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105311 = new double[15] { 120, 0, 0, 10, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105312 = new double[15] { 0, 0, 0, 11, 10, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105313 = new double[15] { 50, 0, 0, 12, 8, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        public double[] E105314 = new double[15] { 70, 0, 0, 12, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105315 = new double[15] { 100, 0, 0, 9, 13, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105316 = new double[15] { 75, 0, 0, 16, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105317 = new double[15] { 210, 0, 0, 15, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105341 = new double[15] { 100, 34, 0, 4, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        public double[] E105342 = new double[15] { 160, 0, 0, 6, 10, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E105343 = new double[15] { 0, 65, 0, 5, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105344 = new double[15] { 0, 66, 0, 5, 4, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105345 = new double[15] { 0, 68, 0, 6, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 };
        public double[] E105346 = new double[15] { 0, 62, 0, 7, 5, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105347 = new double[15] { 0, 68, 0, 6, 5, 12, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E105371 = new double[15] { 120, 0, 20, 5, 7, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0 };
        public double[] E105372 = new double[15] { 0, 0, 43, 5, 7, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105373 = new double[15] { 0, 0, 48, 4, 7, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105374 = new double[15] { 80, 0, 43, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105375 = new double[15] { 0, 0, 46, 5, 8, 0, 13, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105376 = new double[15] { 0, 0, 52, 4, 9, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105377 = new double[15] { 0, 0, 60, 6, 9, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105401 = new double[15] { 0, 54, 0, 5, 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E105402 = new double[15] { 80, 0, 0, 9, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105403 = new double[15] { 120, 0, 0, 9, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105431 = new double[15] { 60, 30, 0, 8, 6, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105432 = new double[15] { 0, 70, 0, 4, 3, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 };
        public double[] E105433 = new double[15] { 100, 0, 0, 6, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105462 = new double[15] { 60, 0, 24, 6, 9, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0 };
        public double[] E105463 = new double[15] { 70, 0, 26, 7, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105464 = new double[15] { 0, 0, 28, 9, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105491 = new double[15] { 0, 60, 0, 5, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105521 = new double[15] { 100, 0, 48, 3, 5, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105522 = new double[15] { 0, 0, 22, 6, 10, 0, 0, 0, 12, 0, 0, 0, 0, 0, 0 };
        public double[] E105523 = new double[15] { 0, 0, 23, 8, 9, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 };
        public double[] E105524 = new double[15] { 0, 0, 36, 7, 10, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0 };
        public double[] E105551 = new double[15] { 70, 64, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 10 };
        public double[] E105552 = new double[15] { 0, 84, 0, 0, 0, 13, 0, 0, 25, 0, 0, 0, 0, 0, 0 };
        public double[] E105553 = new double[15] { 0, 102, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105554 = new double[15] { 0, 104, 0, 0, 0, 28, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105555 = new double[15] { 0, 98, 0, 0, 0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 3 };
        public double[] E105556 = new double[15] { 50, 105, 0, 0, 0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105557 = new double[15] { 0, 110, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105581 = new double[15] { 200, 0, 0, 10, 6, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105582 = new double[15] { 60, 0, 0, 12, 8, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 };
        public double[] E105583 = new double[15] { 0, 0, 0, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0 };
        public double[] E105584 = new double[15] { 0, 0, 0, 10, 12, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105585 = new double[15] { 50, 0, 0, 14, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105586 = new double[15] { 60, 0, 0, 9, 11, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0 };
        public double[] E105587 = new double[15] { 0, 0, 0, 13, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105611 = new double[15] { 0, 0, 78, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 3, 0 };
        public double[] E105612 = new double[15] { 140, 0, 84, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105613 = new double[15] { 0, 0, 92, 0, 0, 0, 14, 120, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105614 = new double[15] { 30, 0, 98, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105615 = new double[15] { 0, 0, 101, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E105616 = new double[15] { 0, 0, 103, 0, 0, 0, 15, 0, 10, 0, 0, 0, 0, 0, 0 };
        public double[] E105617 = new double[15] { 0, 0, 105, 0, 0, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106011 = new double[15] { 155, 191, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106012 = new double[15] { 75, 216, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106013 = new double[15] { 55, 235, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106041 = new double[15] { 0, 206, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106042 = new double[15] { 0, 216, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106043 = new double[15] { 0, 215, 0, 0, 0, 39, 0, 0, 0, 0, 0, 0, 0, 0, 5 };
        public double[] E106071 = new double[15] { 0, 198, 0, 0, 0, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106072 = new double[15] { 250, 199, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106073 = new double[15] { 0, 212, 0, 0, 0, 12, 0, 0, 0, 5, 0, 0, 0, 0, 0 };
        public double[] E106101 = new double[15] { 0, 174, 0, 2, 4, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106102 = new double[15] { 0, 225, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106103 = new double[15] { 0, 220, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106131 = new double[15] { 0, 144, 0, 5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106132 = new double[15] { 0, 195, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106133 = new double[15] { 0, 196, 0, 0, 10, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106161 = new double[15] { 0, 199, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106162 = new double[15] { 0, 200, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106163 = new double[15] { 0, 215, 0, 3, 3, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106191 = new double[15] { 0, 219, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106192 = new double[15] { 0, 235, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106193 = new double[15] { 0, 243, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0 };
        public double[] E106221 = new double[15] { 0, 0, 190, 0, 0, 0, 29, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106222 = new double[15] { 0, 0, 202, 0, 0, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106223 = new double[15] { 0, 0, 214, 0, 0, 0, 36, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106251 = new double[15] { 345, 0, 145, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106252 = new double[15] { 175, 0, 150, 6, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106253 = new double[15] { 250, 0, 142, 7, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106281 = new double[15] { 0, 78, 0, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106282 = new double[15] { 0, 79, 0, 13, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106283 = new double[15] { 0, 120, 0, 6, 5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106311 = new double[15] { 185, 0, 0, 14, 11, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0 };
        public double[] E106312 = new double[15] { 160, 0, 0, 15, 12, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0 };
        public double[] E106313 = new double[15] { 215, 0, 0, 16, 12, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0 };
        public double[] E106341 = new double[15] { 0, 113, 0, 4, 4, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106342 = new double[15] { 0, 109, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106343 = new double[15] { 0, 110, 0, 7, 6, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106371 = new double[15] { 0, 0, 87, 5, 7, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106372 = new double[15] { 0, 0, 49, 10, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106373 = new double[15] { 0, 0, 100, 6, 8, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106401 = new double[15] { 0, 37, 0, 12, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106431 = new double[15] { 0, 24, 0, 11, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106461 = new double[15] { 125, 0, 43, 8, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106462 = new double[15] { 175, 0, 50, 9, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106491 = new double[15] { 0, 31, 0, 11, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106521 = new double[15] { 0, 0, 122, 4, 3, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106551 = new double[15] { 95, 124, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106552 = new double[15] { 100, 137, 0, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106553 = new double[15] { 90, 150, 0, 0, 0, 44, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106581 = new double[15] { 0, 0, 0, 15, 15, 0, 0, 95, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106582 = new double[15] { 35, 0, 0, 17, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106583 = new double[15] { 110, 0, 0, 17, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106611 = new double[15] { 0, 0, 132, 0, 0, 0, 24, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106612 = new double[15] { 0, 0, 134, 0, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] E106613 = new double[15] { 0, 0, 140, 0, 0, 0, 36, 100, 0, 0, 0, 0, 0, 0, 0 };

        public double[] E107011 = new double[15] { 40.0, /*atk*/268.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/18.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107012 = new double[15] { 85.0, /*atk*/281.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/16.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107041 = new double[15] { 0.0, /*atk*/260.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/42.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107042 = new double[15] { 0.0, /*atk*/258.0, /*magic_str*/0.0, /*def*/5.0, /*magic_def*/0.0, /*physical_critical*/31.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107071 = new double[15] { 65.0, /*atk*/254.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/40.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107072 = new double[15] { 0.0, /*atk*/278.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/41.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107101 = new double[15] { 120.0, /*atk*/248.0, /*magic_str*/0.0, /*def*/4.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107102 = new double[15] { 0.0, /*atk*/239.0, /*magic_str*/0.0, /*def*/6.0, /*magic_def*/6.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107131 = new double[15] { 0.0, /*atk*/231.0, /*magic_str*/0.0, /*def*/5.0, /*magic_def*/5.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107132 = new double[15] { 0.0, /*atk*/256.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/7.0, /*physical_critical*/15.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107161 = new double[15] { 0.0, /*atk*/221.0, /*magic_str*/0.0, /*def*/3.0, /*magic_def*/9.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107162 = new double[15] { 0.0, /*atk*/229.0, /*magic_str*/0.0, /*def*/10.0, /*magic_def*/4.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107191 = new double[15] { 0.0, /*atk*/281.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107192 = new double[15] { 255.0, /*atk*/270.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107221 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/229.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/52.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107222 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/252.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/47.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107251 = new double[15] { 50.0, /*atk*/0.0, /*magic_str*/201.0, /*def*/6.0, /*magic_def*/9.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107252 = new double[15] { 320.0, /*atk*/0.0, /*magic_str*/193.0, /*def*/6.0, /*magic_def*/8.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107281 = new double[15] { 0.0, /*atk*/140.0, /*magic_str*/0.0, /*def*/11.0, /*magic_def*/8.0, /*physical_critical*/18.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107311 = new double[15] { 340.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/20.0, /*magic_def*/18.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/20.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107341 = new double[15] { 0.0, /*atk*/164.0, /*magic_str*/0.0, /*def*/9.0, /*magic_def*/7.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107371 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/167.0, /*def*/5.0, /*magic_def*/7.0, /*physical_critical*/0.0, /*magic_critical*/17.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107461 = new double[15] { 345.0, /*atk*/0.0, /*magic_str*/80.0, /*def*/12.0, /*magic_def*/13.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107491 = new double[15] { 0.0, /*atk*/184.0, /*magic_str*/0.0, /*def*/6.0, /*magic_def*/6.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107551 = new double[15] { 0.0, /*atk*/210.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/30.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107552 = new double[15] { 90.0, /*atk*/225.0, /*magic_str*/0.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/11.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107581 = new double[15] { 315.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/19.0, /*magic_def*/19.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107582 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/0.0, /*def*/24.0, /*magic_def*/24.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107611 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/195.0, /*def*/0.0, /*magic_def*/0.0, /*physical_critical*/0.0, /*magic_critical*/30.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };
        public double[] E107612 = new double[15] { 0.0, /*atk*/0.0, /*magic_str*/201.0, /*def*/0.0, /*magic_def*/8.0, /*physical_critical*/0.0, /*magic_critical*/0.0, /*wave_hp_recovery*/0.0, /*wave_energy_recovery*/0.0, /*dodge*/0.0,   /*life_steal*/0.0, /*hp_recovery_rate*/0.0, /*energy_recovery_rate*/0.0, /*energy_reduce_rate*/0.0,  /*accuracy*/0.0 };





        public double[] E999999 = new double[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string E999999_name = "미구현";

        public string[] reinforce_0 = new string[16] { "E101011", "E101071", "E101101", "E101131", "E101161", "E101191",
        "E101251", "E101281", "E101371", "E101401", "E101431", "E101521", "E101551", "E101581", "E101611", "E999999" };

        public string[] reinforce_1 = new string[38] { "E102011", "E102013", "E102014", "E102041", "E102071", "E102101",
            "E102131", "E102162", "E102163", "E102191", "E102192", "E102221", "E102222", "E102251", "E102252", "E102281",
            "E102282", "E102311", "E102312", "E102341", "E102342", "E102371", "E102372", "E102401", "E102431", "E102432",
            "E102461", "E102491", "E102493", "E102521", "E102551", "E102552", "E102581", "E102582", "E102611", "E102612",
            "E102613", "E102614" };

        public string[] reinforce_3 = new string[45] { "E103011", "E103012", "E103013", "E103041", "E103042", "E103071",
        "E103072", "E103101", "E103131", "E103132", "E103161", "E103162", "E103191", "E103192", "E103193", "E103221",
        "E103222", "E103251", "E103252", "E103281", "E103282", "E103283", "E103311", "E103341", "E103342", "E103343",
        "E103371", "E103372", "E103401", "E103431", "E103432", "E103461", "E103491", "E103521", "E103522", "E103551",
        "E103552", "E103553", "E103581", "E103582", "E103583", "E103611", "E103612", "E103613", "E103614" };

        public string[] reinforce_5 = new string[284] { "E104011", "E104012", "E104013", "E104014", "E104041", "E104042",
        "E104043", "E104044", "E104071", "E104072", "E104073", "E104074", "E104101", "E104102", "E104103", "E104104",
        "E104131", "E104132", "E104133", "E104134", "E104161", "E104162", "E104163", "E104164", "E104191", "E104192",
        "E104193", "E104194", "E104221", "E104222", "E104223", "E104224", "E104251", "E104252", "E104253", "E104254",
        "E104281", "E104282", "E104283", "E104284", "E104311", "E104312", "E104313", "E104314", "E104341", "E104342",
        "E104343", "E104344", "E104371", "E104372", "E104373", "E104401", "E104402", "E104431", "E104432", "E104433",
        "E104461", "E104462", "E104463", "E104491", "E104521", "E104522", "E104523", "E104551", "E104552", "E104553",
        "E104554", "E104581", "E104582", "E104583", "E104611", "E104612", "E104613", "E105011", "E105012", "E105013",
        "E105014", "E105015", "E105016", "E105041", "E105042", "E105043", "E105044", "E105045", "E105046", "E105071",
        "E105072", "E105073", "E105074", "E105075", "E105076", "E105101", "E105102", "E105103", "E105104", "E105105",
        "E105106", "E105131", "E105132", "E105133", "E105134", "E105135", "E105136", "E105161", "E105162", "E105163",
        "E105164", "E105165", "E105166", "E105191", "E105192", "E105193", "E105194", "E105195", "E105196", "E105221",
        "E105222", "E105223", "E105224", "E105225", "E105226", "E105251", "E105252", "E105253", "E105254", "E105255",
        "E105256", "E105281", "E105282", "E105283", "E105284", "E105285", "E105311", "E105312", "E105313", "E105314",
        "E105315", "E105341", "E105342", "E105343", "E105344", "E105345", "E105371", "E105372", "E105373", "E105374",
        "E105375", "E105401", "E105402", "E105431", "E105432", "E105462", "E105463", "E105491", "E105521", "E105522",
        "E105523", "E105551", "E105552", "E105553", "E105554", "E105555", "E105556", "E105581", "E105582", "E105583",
        "E105584", "E105585", "E105586", "E105611", "E105612", "E105613", "E105614", "E105615", "E105616",
        "E105017", "E105047", "E105077", "E105107", "E105137", "E105167", "E105197", "E105227", "E105257",
        "E105286", "E105287", "E105316", "E105317", "E105346", "E105347", "E105376", "E105377", "E105403", "E105433",
        "E105464", "E105524", "E105557", "E105587", "E105617", "E106011", "E106041", "E106071", "E106101", "E106131",
        "E106161", "E106191", "E106221", "E106251","E106251",
            "E106252","E106253","E106281","E106282","E106283","E106311",
            "E106312","E106313","E106341","E106342","E106343","E106371","E106372","E106373","E106401","E106431","E106461",
            "E106462","E106491","E106521","E106551","E106552","E106553","E106581","E106582","E106583","E106611","E106612",
            "E106613","E107011","E107012","E107041","E107042","E107071","E107072","E107101","E107102","E107131","E107132",
            "E107161","E107162","E107191","E107192","E107221","E107222","E107251","E107252","E107281","E107311","E107341",
            "E107371","E107461","E107491","E107551","E107552","E107581","E107582","E107611","E107612",
            "E106012","E106013","E106042","E106043","E106072","E106073","E106102","E106103","E106132","E106133","E106162","E106192","E106163","E106193","E106222","E106223"};
    }


}
