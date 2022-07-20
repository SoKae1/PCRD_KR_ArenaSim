using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConversion
{
    public class IDNameConversion
    {

        //2022.3.13 쿠루미(스테이지), 리틀리리까지 , 6성 추가될 때 말고는 건들지 말 것
        public string CharaNameToID(string CharaName)
        {
            string ID;
            if (CharaName == "hiyori") { ID = "100161"; }

            else if (CharaName == "yui") { ID = "100261"; }
            else if (CharaName == "rei") { ID = "100361"; }
            else if (CharaName == "misogi") { ID = "100461"; }
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
            else if (CharaName == "kaori") { ID = "101761"; }
            else if (CharaName == "io") { ID = "101861"; }
            else if (CharaName == "mimi") { ID = "102061"; }
            else if (CharaName == "kurumi") { ID = "102161"; }
            else if (CharaName == "yori") { ID = "102261"; }
            else if (CharaName == "ayane") { ID = "102361"; }
            else if (CharaName == "suzume") { ID = "102561"; }
            else if (CharaName == "rin") { ID = "102631"; }
            else if (CharaName == "eriko") { ID = "102731"; }
            else if (CharaName == "saren") { ID = "102861"; }
            else if (CharaName == "nozomi") { ID = "102961"; }
            else if (CharaName == "ninon") { ID = "103061"; }
            else if (CharaName == "sinobu") { ID = "103131"; }
            else if (CharaName == "akino") { ID = "103261"; }
            else if (CharaName == "mahiru") { ID = "103361"; }
            else if (CharaName == "yukari") { ID = "103461"; }
            else if (CharaName == "kyouka") { ID = "103661"; }
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
            else if (CharaName == "shepi") { ID = "106431"; }
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
            else if (CharaName == "ayane_christmas") { ID = "108631"; }
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
            else if (CharaName == "pekorinnu_newyear") { ID = "111831"; }
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
            else if (CharaName == "neneka_newyear") { ID = "115031"; }
            else if (CharaName == "kotkoro_maiden") { ID = "115531"; }
            else if (CharaName == "yui_maiden") { ID = "115631"; }
            else if (CharaName == "kasumi_summer") { ID = "115731"; }
            else if (CharaName == "rima_cinderella") { ID = "115831"; }
            else if (CharaName == "makoto_cinderella") { ID = "115931"; }
            else if (CharaName == "maho_cinderella") { ID = "116031"; }
            else if (CharaName == "chloe_terefes") { ID = "116231"; }
            else if (CharaName == "chieru_terefes") { ID = "116331"; }
            else if (CharaName == "yuni_terefes") { ID = "116431"; }
            else if (CharaName == "inori_timetravel") { ID = "116531"; }
            else if (CharaName == "kaya_timetravel") { ID = "116631"; }
            else if (CharaName == "aoi_worker") { ID = "116731"; }
            else if (CharaName == "tamaki_worker") { ID = "116831"; }
            else if (CharaName == "mihuyu_worker") { ID = "116931"; }
            else if (CharaName == "eriko_summer") { ID = "117031"; }
            else if (CharaName == "sizuru_summer") { ID = "117131"; }
            else if (CharaName == "nozomi_summer") { ID = "117231"; }
            else if (CharaName == "chika_summer") { ID = "117331"; }
            else if (CharaName == "tsumugi_summer") { ID = "117431"; }
            else if (CharaName == "mitsuki_ooedo") { ID = "117531"; }
            else if (CharaName == "yuki_ooedo") { ID = "117631"; }
            else if (CharaName == "kaori_halloween") { ID = "117731"; }
            else if (CharaName == "ninon_halloween") { ID = "117831"; }
            else if (CharaName == "suzuna_halloween") { ID = "117931"; }
            else if (CharaName == "credita") { ID = "118031"; }
            else if (CharaName == "ranpa") { ID = "118131"; }
            else if (CharaName == "hatsune_princess") { ID = "118331"; }
            else if (CharaName == "siori_princess") { ID = "118431"; }
            else if (CharaName == "karin") { ID = "118531"; }
            else if (CharaName == "io_noir") { ID = "119031"; }
            else if (CharaName == "kuuka_noir") { ID = "119131"; }
            else if (CharaName == "mahiru_christmas") { ID = "119231"; }
            else if (CharaName == "rino_christmas") { ID = "119331"; }
            else if (CharaName == "miyako_christmas") { ID = "119931"; }
            else if (CharaName == "mimi_princess") { ID = "120431"; }
            else if (CharaName == "misogi_princess") { ID = "120531"; }
            else if (CharaName == "kyouka_princess") { ID = "120631"; }
            else if (CharaName == "shepi_newyear") { ID = "120731"; }
            else if (CharaName == "ruka_newyear") { ID = "120831"; }
            else if (CharaName == "iriya_newyear") { ID = "120931"; }
            else if (CharaName == "pekorinnu_overload") { ID = "121031"; }
            else if (CharaName == "kyaru_overload") { ID = "121131"; }
            else if (CharaName == "labirista_overload") { ID = "121231"; }
            else if (CharaName == "kurumi_stage") { ID = "121331"; }

            else if (CharaName == "hiyori_princess") { ID = "180131"; }
            else if (CharaName == "yui_princess") { ID = "180231"; }
            else if (CharaName == "rei_princess") { ID = "180331"; }
            else if (CharaName == "pekorinnu_princess") { ID = "180431"; }
            else if (CharaName == "kotkoro_princess") { ID = "180531"; }
            else if (CharaName == "kyaru_princess") { ID = "180631"; }
            else if (CharaName == "hatsusio") { ID = "180731"; }
            else if (CharaName == "littlelyri") { ID = "180831"; }
            else { ID = "000000"; }

            return ID;
        }

        public string IDtoCharaEngName(string ID, int digit)
        {
            try
            {
                if (digit < 4) return null;
                else digit = digit - 4;

                string ls = "";
                for (int i = 0; i < digit; i++)
                {
                    ls += "*";
                }

                if (LikeOperator.LikeString(ID, "1001" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori";
                else if (LikeOperator.LikeString(ID, "1002" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yui";
                else if (LikeOperator.LikeString(ID, "1003" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rei";
                else if (LikeOperator.LikeString(ID, "1004" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misogi";
                else if (LikeOperator.LikeString(ID, "1005" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "matsuri";
                else if (LikeOperator.LikeString(ID, "1006" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "akari";
                else if (LikeOperator.LikeString(ID, "1007" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "miyako";
                else if (LikeOperator.LikeString(ID, "1008" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yuki";
                else if (LikeOperator.LikeString(ID, "1009" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "anna";
                else if (LikeOperator.LikeString(ID, "1010" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "maho";
                else if (LikeOperator.LikeString(ID, "1011" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rino";
                else if (LikeOperator.LikeString(ID, "1012" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hatsune";
                else if (LikeOperator.LikeString(ID, "1013" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "nanaka";
                else if (LikeOperator.LikeString(ID, "1014" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kasumi";
                else if (LikeOperator.LikeString(ID, "1015" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misato";
                else if (LikeOperator.LikeString(ID, "1016" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzuna";
                else if (LikeOperator.LikeString(ID, "1017" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaori";
                else if (LikeOperator.LikeString(ID, "1018" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "io";
                else if (LikeOperator.LikeString(ID, "1020" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mimi";
                else if (LikeOperator.LikeString(ID, "1021" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kurumi";
                else if (LikeOperator.LikeString(ID, "1022" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yori";
                else if (LikeOperator.LikeString(ID, "1023" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ayane";
                else if (LikeOperator.LikeString(ID, "1025" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzume";
                else if (LikeOperator.LikeString(ID, "1026" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rin";
                else if (LikeOperator.LikeString(ID, "1027" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "eriko";
                else if (LikeOperator.LikeString(ID, "1028" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "saren";
                else if (LikeOperator.LikeString(ID, "1029" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "nozomi";
                else if (LikeOperator.LikeString(ID, "1030" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ninon";
                else if (LikeOperator.LikeString(ID, "1031" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sinobu";
                else if (LikeOperator.LikeString(ID, "1032" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "akino";
                else if (LikeOperator.LikeString(ID, "1033" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mahiru";
                else if (LikeOperator.LikeString(ID, "1034" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yukari";
                else if (LikeOperator.LikeString(ID, "1036" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyouka";
                else if (LikeOperator.LikeString(ID, "1037" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tomo";
                else if (LikeOperator.LikeString(ID, "1038" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "siori";
                else if (LikeOperator.LikeString(ID, "1040" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "aoi";
                else if (LikeOperator.LikeString(ID, "1042" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chika";
                else if (LikeOperator.LikeString(ID, "1043" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "makoto";
                else if (LikeOperator.LikeString(ID, "1044" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "iriya";
                else if (LikeOperator.LikeString(ID, "1045" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kuuka";
                else if (LikeOperator.LikeString(ID, "1046" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tamaki";
                else if (LikeOperator.LikeString(ID, "1047" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "zyun";
                else if (LikeOperator.LikeString(ID, "1048" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mihuyu";
                else if (LikeOperator.LikeString(ID, "1049" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sizuru";
                else if (LikeOperator.LikeString(ID, "1050" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misaki";
                else if (LikeOperator.LikeString(ID, "1051" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mitsuki";
                else if (LikeOperator.LikeString(ID, "1052" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rima";
                else if (LikeOperator.LikeString(ID, "1053" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "monika";
                else if (LikeOperator.LikeString(ID, "1054" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tsumugi";
                else if (LikeOperator.LikeString(ID, "1055" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ayumi";
                else if (LikeOperator.LikeString(ID, "1056" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ruka";
                else if (LikeOperator.LikeString(ID, "1057" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "zita";
                else if (LikeOperator.LikeString(ID, "1058" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu";
                else if (LikeOperator.LikeString(ID, "1059" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro";
                else if (LikeOperator.LikeString(ID, "1060" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru";
                else if (LikeOperator.LikeString(ID, "1061" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "muimi";
                else if (LikeOperator.LikeString(ID, "1063" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "arisa";
                else if (LikeOperator.LikeString(ID, "1064" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "shepi";
                else if (LikeOperator.LikeString(ID, "1065" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaya";
                else if (LikeOperator.LikeString(ID, "1066" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "inori";
                else if (LikeOperator.LikeString(ID, "1067" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "homare";
                else if (LikeOperator.LikeString(ID, "1068" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "labyrista";
                else if (LikeOperator.LikeString(ID, "1069" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaiser";
                else if (LikeOperator.LikeString(ID, "1070" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "neneka";
                else if (LikeOperator.LikeString(ID, "1071" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kristina";
                else if (LikeOperator.LikeString(ID, "1073" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "lazilazi";
                else if (LikeOperator.LikeString(ID, "1075" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_summer";
                else if (LikeOperator.LikeString(ID, "1076" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_summer";
                else if (LikeOperator.LikeString(ID, "1077" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzume_summer";
                else if (LikeOperator.LikeString(ID, "1078" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_summer";
                else if (LikeOperator.LikeString(ID, "1079" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tamaki_summer";
                else if (LikeOperator.LikeString(ID, "1080" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mihuyu_summer";
                else if (LikeOperator.LikeString(ID, "1081" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sinobu_halloween";
                else if (LikeOperator.LikeString(ID, "1082" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "miyako_halloween";
                else if (LikeOperator.LikeString(ID, "1083" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misaki_halloween";
                else if (LikeOperator.LikeString(ID, "1084" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chika_christmas";
                else if (LikeOperator.LikeString(ID, "1085" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kurumi_christmas";
                else if (LikeOperator.LikeString(ID, "1086" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ayane_christmas";
                else if (LikeOperator.LikeString(ID, "1087" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori_newyear";
                else if (LikeOperator.LikeString(ID, "1088" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_newyear";
                else if (LikeOperator.LikeString(ID, "1089" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_newyear";
                else if (LikeOperator.LikeString(ID, "1090" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "eriko_valentine";
                else if (LikeOperator.LikeString(ID, "1091" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sizuru_valentine";
                else if (LikeOperator.LikeString(ID, "1092" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "anne";
                else if (LikeOperator.LikeString(ID, "1093" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "lou";
                else if (LikeOperator.LikeString(ID, "1094" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "grea";
                else if (LikeOperator.LikeString(ID, "1095" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kuuka_ooedo";
                else if (LikeOperator.LikeString(ID, "1096" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ninon_ooedo";
                else if (LikeOperator.LikeString(ID, "1097" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rem";
                else if (LikeOperator.LikeString(ID, "1098" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ram";
                else if (LikeOperator.LikeString(ID, "1099" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "emilia";
                else if (LikeOperator.LikeString(ID, "1100" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzuna_summer";
                else if (LikeOperator.LikeString(ID, "1101" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "io_summer";
                else if (LikeOperator.LikeString(ID, "1103" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "saren_summer";
                else if (LikeOperator.LikeString(ID, "1104" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "makoto_summer";
                else if (LikeOperator.LikeString(ID, "1105" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaori_summer";
                else if (LikeOperator.LikeString(ID, "1106" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "maho_summer";
                else if (LikeOperator.LikeString(ID, "1107" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "aoi_nakayosi";
                else if (LikeOperator.LikeString(ID, "1108" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chloe";
                else if (LikeOperator.LikeString(ID, "1109" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chieru";
                else if (LikeOperator.LikeString(ID, "1110" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yuni";
                else if (LikeOperator.LikeString(ID, "1111" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyouka_halloween";
                else if (LikeOperator.LikeString(ID, "1112" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misogi_halloween";
                else if (LikeOperator.LikeString(ID, "1113" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mimi_halloween";
                else if (LikeOperator.LikeString(ID, "1114" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "runa";
                else if (LikeOperator.LikeString(ID, "1115" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kristina_christmas";
                else if (LikeOperator.LikeString(ID, "1116" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "nozomi_christmas";
                else if (LikeOperator.LikeString(ID, "1117" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "iriya_christmas";
                else if (LikeOperator.LikeString(ID, "1118" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_newyear";
                else if (LikeOperator.LikeString(ID, "1119" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_newyear";
                else if (LikeOperator.LikeString(ID, "1120" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_newyear";
                else if (LikeOperator.LikeString(ID, "1121" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzume_newyear";
                else if (LikeOperator.LikeString(ID, "1122" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kasumi_magical";
                else if (LikeOperator.LikeString(ID, "1123" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "siori_magical";
                else if (LikeOperator.LikeString(ID, "1124" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "uzuki_deremas";
                else if (LikeOperator.LikeString(ID, "1125" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rin_deremas";
                else if (LikeOperator.LikeString(ID, "1126" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mio_deremas";
                else if (LikeOperator.LikeString(ID, "1127" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rin_ranger";
                else if (LikeOperator.LikeString(ID, "1128" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mahiru_ranger";
                else if (LikeOperator.LikeString(ID, "1129" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rino_wonder";
                else if (LikeOperator.LikeString(ID, "1130" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ayumi_wonder";
                else if (LikeOperator.LikeString(ID, "1131" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ruka_summer";
                else if (LikeOperator.LikeString(ID, "1132" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "anna_summer";
                else if (LikeOperator.LikeString(ID, "1133" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "nanaka_summer";
                else if (LikeOperator.LikeString(ID, "1134" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hatsune_summer";
                else if (LikeOperator.LikeString(ID, "1135" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misato_summer";
                else if (LikeOperator.LikeString(ID, "1136" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "zyun_summer";
                else if (LikeOperator.LikeString(ID, "1137" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "akari_angel";
                else if (LikeOperator.LikeString(ID, "1138" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yori_angel";
                else if (LikeOperator.LikeString(ID, "1139" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tsumugi_halloween";
                else if (LikeOperator.LikeString(ID, "1140" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_halloween";
                else if (LikeOperator.LikeString(ID, "1141" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "matsuri_halloween";
                else if (LikeOperator.LikeString(ID, "1142" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "monika_magical";
                else if (LikeOperator.LikeString(ID, "1143" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tomo_magical";
                else if (LikeOperator.LikeString(ID, "1144" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "akino_christmas";
                else if (LikeOperator.LikeString(ID, "1145" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "saren_christmas";
                else if (LikeOperator.LikeString(ID, "1146" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yukari_christmas";
                else if (LikeOperator.LikeString(ID, "1147" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "muimi_newyear";
                else if (LikeOperator.LikeString(ID, "1150" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "neneka_newyear";
                else if (LikeOperator.LikeString(ID, "1155" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_maiden";
                else if (LikeOperator.LikeString(ID, "1156" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_maiden";
                else if (LikeOperator.LikeString(ID, "1157" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kasumi_summer";
                else if (LikeOperator.LikeString(ID, "1158" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rima_cinderella";
                else if (LikeOperator.LikeString(ID, "1159" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "makoto_cinderella";
                else if (LikeOperator.LikeString(ID, "1160" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "maho_cinderella";
                else if (LikeOperator.LikeString(ID, "1162" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chloe_terefes";
                else if (LikeOperator.LikeString(ID, "1163" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chieru_terefes";
                else if (LikeOperator.LikeString(ID, "1163" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yuni_terefes";
                else if (LikeOperator.LikeString(ID, "1165" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "inori_timetravel";
                else if (LikeOperator.LikeString(ID, "1166" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaya_timetravel";
                else if (LikeOperator.LikeString(ID, "1167" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "aoi_worker";
                else if (LikeOperator.LikeString(ID, "1168" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tamaki_worker";
                else if (LikeOperator.LikeString(ID, "1169" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mihuyu_worker";
                else if (LikeOperator.LikeString(ID, "1170" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "eriko_summer";
                else if (LikeOperator.LikeString(ID, "1171" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sizuru_summer";
                else if (LikeOperator.LikeString(ID, "1172" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "nozomi_summer";
                else if (LikeOperator.LikeString(ID, "1173" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "chika_summer";
                else if (LikeOperator.LikeString(ID, "1174" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "tsumugi_summer";
                else if (LikeOperator.LikeString(ID, "1175" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mitsuki_ooedo";
                else if (LikeOperator.LikeString(ID, "1176" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yuki_ooedo";
                else if (LikeOperator.LikeString(ID, "1177" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kaori_halloween";
                else if (LikeOperator.LikeString(ID, "1178" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ninon_halloween";
                else if (LikeOperator.LikeString(ID, "1179" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "suzuna_halloween";
                else if (LikeOperator.LikeString(ID, "1180" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "credita";
                else if (LikeOperator.LikeString(ID, "1181" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ranpa";
                else if (LikeOperator.LikeString(ID, "1183" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hatsune_princess";
                else if (LikeOperator.LikeString(ID, "1184" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "siori_princess";
                else if (LikeOperator.LikeString(ID, "1185" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "karin";
                else if (LikeOperator.LikeString(ID, "1190" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "io_noir";
                else if (LikeOperator.LikeString(ID, "1191" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kuuka_noir";
                else if (LikeOperator.LikeString(ID, "1192" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mahiru_christmas";
                else if (LikeOperator.LikeString(ID, "1193" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rino_christmas";
                else if (LikeOperator.LikeString(ID, "1199" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "miyako_christmas";
                else if (LikeOperator.LikeString(ID, "1204" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "mimi_princess";
                else if (LikeOperator.LikeString(ID, "1205" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "misogi_princess";
                else if (LikeOperator.LikeString(ID, "1206" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyouka_princess";
                else if (LikeOperator.LikeString(ID, "1207" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "shepi_newyear";
                else if (LikeOperator.LikeString(ID, "1208" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "ruka_newyear";
                else if (LikeOperator.LikeString(ID, "1209" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "iriya_newyear";
                else if (LikeOperator.LikeString(ID, "1210" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_overload";
                else if (LikeOperator.LikeString(ID, "1211" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_overload";
                else if (LikeOperator.LikeString(ID, "1212" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "labirista_overload";
                else if (LikeOperator.LikeString(ID, "1213" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kurumi_stage";

                else if (LikeOperator.LikeString(ID, "1801" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hiyori_princess";
                else if (LikeOperator.LikeString(ID, "1802" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "yui_princess";
                else if (LikeOperator.LikeString(ID, "1803" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "rei_princess";
                else if (LikeOperator.LikeString(ID, "1804" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "pekorinnu_princess";
                else if (LikeOperator.LikeString(ID, "1805" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kotkoro_princess";
                else if (LikeOperator.LikeString(ID, "1806" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "kyaru_princess";
                else if (LikeOperator.LikeString(ID, "1807" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "hatsusio";
                else if (LikeOperator.LikeString(ID, "1808" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "littlelyri";

                else if (LikeOperator.LikeString(ID, "4031" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "skull";
                else if (LikeOperator.LikeString(ID, "404201" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sylph_chika_1";
                else if (LikeOperator.LikeString(ID, "404205" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "sylph_chika_2";
                else if (LikeOperator.LikeString(ID, "4077" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "golem";
                else if (LikeOperator.LikeString(ID, "408401", Microsoft.VisualBasic.CompareMethod.Binary)) return "sylph_chika_chiristmas_1";
                else if (LikeOperator.LikeString(ID, "408402", Microsoft.VisualBasic.CompareMethod.Binary)) return "sylph_chika_chiristmas_2";
                else if (LikeOperator.LikeString(ID, "408403", Microsoft.VisualBasic.CompareMethod.Binary)) return "sylph_chika_chiristmas_3";


                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string IDtoCharaKorName(string ID, int digit)
        {
            try
            {
                if (digit < 4) return null;
                else digit = digit - 4;

                string ls = "";
                for (int i = 0; i < digit; i++)
                {
                    ls += "*";
                }
                if (LikeOperator.LikeString(ID, "1001" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "히요리";
                else if (LikeOperator.LikeString(ID, "1002" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "유이";
                else if (LikeOperator.LikeString(ID, "1003" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "레이";
                else if (LikeOperator.LikeString(ID, "1004" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미소기";
                else if (LikeOperator.LikeString(ID, "1005" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마츠리";
                else if (LikeOperator.LikeString(ID, "1006" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아카리";
                else if (LikeOperator.LikeString(ID, "1007" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미야코";
                else if (LikeOperator.LikeString(ID, "1008" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "유키";
                else if (LikeOperator.LikeString(ID, "1009" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "안나";
                else if (LikeOperator.LikeString(ID, "1010" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마호";
                else if (LikeOperator.LikeString(ID, "1011" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "리노";
                else if (LikeOperator.LikeString(ID, "1012" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "하츠네";
                else if (LikeOperator.LikeString(ID, "1013" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "나나카";
                else if (LikeOperator.LikeString(ID, "1014" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "카스미";
                else if (LikeOperator.LikeString(ID, "1015" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미사토";
                else if (LikeOperator.LikeString(ID, "1016" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "스즈나";
                else if (LikeOperator.LikeString(ID, "1017" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "카오리";
                else if (LikeOperator.LikeString(ID, "1018" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "이오";
                else if (LikeOperator.LikeString(ID, "1020" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미미";
                else if (LikeOperator.LikeString(ID, "1021" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "쿠루미";
                else if (LikeOperator.LikeString(ID, "1022" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "요리";
                else if (LikeOperator.LikeString(ID, "1023" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아야네";
                else if (LikeOperator.LikeString(ID, "1025" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "스즈메";
                else if (LikeOperator.LikeString(ID, "1026" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "린";
                else if (LikeOperator.LikeString(ID, "1027" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "에리코";
                else if (LikeOperator.LikeString(ID, "1028" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "사렌";
                else if (LikeOperator.LikeString(ID, "1029" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "노조미";
                else if (LikeOperator.LikeString(ID, "1030" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "니논";
                else if (LikeOperator.LikeString(ID, "1031" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "시노부";
                else if (LikeOperator.LikeString(ID, "1032" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아키노";
                else if (LikeOperator.LikeString(ID, "1033" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마히루";
                else if (LikeOperator.LikeString(ID, "1034" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "유카리";
                else if (LikeOperator.LikeString(ID, "1036" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "쿄우카";
                else if (LikeOperator.LikeString(ID, "1037" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "토모";
                else if (LikeOperator.LikeString(ID, "1038" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "시오리";
                else if (LikeOperator.LikeString(ID, "1040" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아오이";
                else if (LikeOperator.LikeString(ID, "1042" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "치카";
                else if (LikeOperator.LikeString(ID, "1043" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마코토";
                else if (LikeOperator.LikeString(ID, "1044" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "이리야";
                else if (LikeOperator.LikeString(ID, "1045" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "쿠우카";
                else if (LikeOperator.LikeString(ID, "1046" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "타마키";
                else if (LikeOperator.LikeString(ID, "1047" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "쥰";
                else if (LikeOperator.LikeString(ID, "1048" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미후유";
                else if (LikeOperator.LikeString(ID, "1049" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "시즈루";
                else if (LikeOperator.LikeString(ID, "1050" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미사키";
                else if (LikeOperator.LikeString(ID, "1051" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미츠키";
                else if (LikeOperator.LikeString(ID, "1052" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "리마";
                else if (LikeOperator.LikeString(ID, "1053" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "모니카";
                else if (LikeOperator.LikeString(ID, "1054" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "츠무기";
                else if (LikeOperator.LikeString(ID, "1055" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아유미";
                else if (LikeOperator.LikeString(ID, "1056" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "루카";
                else if (LikeOperator.LikeString(ID, "1057" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "지타";
                else if (LikeOperator.LikeString(ID, "1058" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "페코린느";
                else if (LikeOperator.LikeString(ID, "1059" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "콧코로";
                else if (LikeOperator.LikeString(ID, "1060" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "캬루";
                else if (LikeOperator.LikeString(ID, "1061" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "무이미";
                else if (LikeOperator.LikeString(ID, "1063" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "아리사";
                else if (LikeOperator.LikeString(ID, "1064" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "셰피";
                else if (LikeOperator.LikeString(ID, "1065" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "카야";
                else if (LikeOperator.LikeString(ID, "1066" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "이노리";
                else if (LikeOperator.LikeString(ID, "1067" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "호마레";
                else if (LikeOperator.LikeString(ID, "1068" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "라비리스타";
                else if (LikeOperator.LikeString(ID, "1069" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "패동";
                else if (LikeOperator.LikeString(ID, "1070" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "네네카";
                else if (LikeOperator.LikeString(ID, "1071" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "크리스티나";
                else if (LikeOperator.LikeString(ID, "1073" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "라지라지";
                else if (LikeOperator.LikeString(ID, "1075" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수페코";
                else if (LikeOperator.LikeString(ID, "1076" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수코로";
                else if (LikeOperator.LikeString(ID, "1077" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수즈메";
                else if (LikeOperator.LikeString(ID, "1078" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수캬루";
                else if (LikeOperator.LikeString(ID, "1079" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수마키";
                else if (LikeOperator.LikeString(ID, "1080" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수후유";
                else if (LikeOperator.LikeString(ID, "1081" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할노부";
                else if (LikeOperator.LikeString(ID, "1082" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할푸딩";
                else if (LikeOperator.LikeString(ID, "1083" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할사키";
                else if (LikeOperator.LikeString(ID, "1084" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성치카";
                else if (LikeOperator.LikeString(ID, "1085" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성루미";
                else if (LikeOperator.LikeString(ID, "1086" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성야네";
                else if (LikeOperator.LikeString(ID, "1087" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴요리";
                else if (LikeOperator.LikeString(ID, "1088" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴이";
                else if (LikeOperator.LikeString(ID, "1089" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "신레이";
                else if (LikeOperator.LikeString(ID, "1090" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "발리코";
                else if (LikeOperator.LikeString(ID, "1091" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "발즈루";
                else if (LikeOperator.LikeString(ID, "1092" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "앤";
                else if (LikeOperator.LikeString(ID, "1093" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "루";
                else if (LikeOperator.LikeString(ID, "1094" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "글레어";
                else if (LikeOperator.LikeString(ID, "1095" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오우카";
                else if (LikeOperator.LikeString(ID, "1096" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오니논";
                else if (LikeOperator.LikeString(ID, "1097" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "렘";
                else if (LikeOperator.LikeString(ID, "1098" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "람";
                else if (LikeOperator.LikeString(ID, "1099" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "에밀리아";
                else if (LikeOperator.LikeString(ID, "1100" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수즈나";
                else if (LikeOperator.LikeString(ID, "1101" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수이오";
                else if (LikeOperator.LikeString(ID, "1103" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수사렌";
                else if (LikeOperator.LikeString(ID, "1104" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수코토";
                else if (LikeOperator.LikeString(ID, "1105" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수오리";
                else if (LikeOperator.LikeString(ID, "1106" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수마호";
                else if (LikeOperator.LikeString(ID, "1107" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "편오이";
                else if (LikeOperator.LikeString(ID, "1108" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "클로에";
                else if (LikeOperator.LikeString(ID, "1109" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "치에루";
                else if (LikeOperator.LikeString(ID, "1110" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "유니";
                else if (LikeOperator.LikeString(ID, "1111" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할쿄카";
                else if (LikeOperator.LikeString(ID, "1112" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할소기";
                else if (LikeOperator.LikeString(ID, "1113" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할미미";
                else if (LikeOperator.LikeString(ID, "1114" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "루나";
                else if (LikeOperator.LikeString(ID, "1115" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성리스";
                else if (LikeOperator.LikeString(ID, "1116" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성조미";
                else if (LikeOperator.LikeString(ID, "1117" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성리야";
                else if (LikeOperator.LikeString(ID, "1118" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴페코";
                else if (LikeOperator.LikeString(ID, "1119" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴코로";
                else if (LikeOperator.LikeString(ID, "1120" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "냐루";
                else if (LikeOperator.LikeString(ID, "1121" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴즈메";
                else if (LikeOperator.LikeString(ID, "1122" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마스미";
                else if (LikeOperator.LikeString(ID, "1123" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마오리";
                else if (LikeOperator.LikeString(ID, "1124" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "우즈키";
                else if (LikeOperator.LikeString(ID, "1125" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "시부린";
                else if (LikeOperator.LikeString(ID, "1126" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "미오";
                else if (LikeOperator.LikeString(ID, "1127" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "레린";
                else if (LikeOperator.LikeString(ID, "1128" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "레히루";
                else if (LikeOperator.LikeString(ID, "1129" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "앨리노";
                else if (LikeOperator.LikeString(ID, "1130" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "앨유미";
                else if (LikeOperator.LikeString(ID, "1131" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수루카";
                else if (LikeOperator.LikeString(ID, "1132" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수안나";
                else if (LikeOperator.LikeString(ID, "1133" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수나카";
                else if (LikeOperator.LikeString(ID, "1134" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수츠네";
                else if (LikeOperator.LikeString(ID, "1135" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수사토";
                else if (LikeOperator.LikeString(ID, "1136" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수쥰";
                else if (LikeOperator.LikeString(ID, "1137" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "엔카리";
                else if (LikeOperator.LikeString(ID, "1138" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "엔요리";
                else if (LikeOperator.LikeString(ID, "1139" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할무기";
                else if (LikeOperator.LikeString(ID, "1140" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할레이";
                else if (LikeOperator.LikeString(ID, "1141" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할츠리";
                else if (LikeOperator.LikeString(ID, "1142" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마니카";
                else if (LikeOperator.LikeString(ID, "1143" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "마토모";
                else if (LikeOperator.LikeString(ID, "1144" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성키노";
                else if (LikeOperator.LikeString(ID, "1145" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성사렌";
                else if (LikeOperator.LikeString(ID, "1146" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성카리";
                else if (LikeOperator.LikeString(ID, "1147" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴이미";
                else if (LikeOperator.LikeString(ID, "1150" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴네카";
                else if (LikeOperator.LikeString(ID, "1155" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "의코로";
                else if (LikeOperator.LikeString(ID, "1156" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "의유이";
                else if (LikeOperator.LikeString(ID, "1157" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수스미";
                else if (LikeOperator.LikeString(ID, "1158" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "신리마";
                else if (LikeOperator.LikeString(ID, "1159" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "신코토";
                else if (LikeOperator.LikeString(ID, "1160" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "신마호";
                else if (LikeOperator.LikeString(ID, "1162" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성로에";
                else if (LikeOperator.LikeString(ID, "1163" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성에루";
                else if (LikeOperator.LikeString(ID, "1163" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성유니";
                else if (LikeOperator.LikeString(ID, "1165" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "시노리";
                else if (LikeOperator.LikeString(ID, "1166" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "타카야";
                else if (LikeOperator.LikeString(ID, "1167" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "작오이";
                else if (LikeOperator.LikeString(ID, "1168" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "작마키";

                else if (LikeOperator.LikeString(ID, "1169" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "작후유";
                else if (LikeOperator.LikeString(ID, "1170" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수리코";
                else if (LikeOperator.LikeString(ID, "1171" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수즈루";
                else if (LikeOperator.LikeString(ID, "1172" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수조미";
                else if (LikeOperator.LikeString(ID, "1173" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수치카";
                else if (LikeOperator.LikeString(ID, "1174" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "수무기";
                else if (LikeOperator.LikeString(ID, "1175" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오츠키";
                else if (LikeOperator.LikeString(ID, "1176" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오유키";
                else if (LikeOperator.LikeString(ID, "1177" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할오리";
                else if (LikeOperator.LikeString(ID, "1178" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할니논";
                else if (LikeOperator.LikeString(ID, "1179" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "할즈나";
                else if (LikeOperator.LikeString(ID, "1180" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "크레짓타";
                else if (LikeOperator.LikeString(ID, "1181" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "란파";
                else if (LikeOperator.LikeString(ID, "1183" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프츠네";
                else if (LikeOperator.LikeString(ID, "1184" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프오리";
                else if (LikeOperator.LikeString(ID, "1185" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "카린";
                else if (LikeOperator.LikeString(ID, "1190" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "느이오";
                else if (LikeOperator.LikeString(ID, "1191" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "느우카";
                else if (LikeOperator.LikeString(ID, "1192" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성히루";
                else if (LikeOperator.LikeString(ID, "1193" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성리노";
                else if (LikeOperator.LikeString(ID, "1199" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "성푸딩";
                else if (LikeOperator.LikeString(ID, "1204" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프미미";
                else if (LikeOperator.LikeString(ID, "1205" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프소기";
                else if (LikeOperator.LikeString(ID, "1206" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프쿄";
                else if (LikeOperator.LikeString(ID, "1207" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴셰피";
                else if (LikeOperator.LikeString(ID, "1208" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴루카";
                else if (LikeOperator.LikeString(ID, "1209" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "뉴리야";
                else if (LikeOperator.LikeString(ID, "1210" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오페코";
                else if (LikeOperator.LikeString(ID, "1211" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오캬루";
                else if (LikeOperator.LikeString(ID, "1212" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "오라비";
                else if (LikeOperator.LikeString(ID, "1213" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "스루미";

                else if (LikeOperator.LikeString(ID, "1801" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프요리";
                else if (LikeOperator.LikeString(ID, "1802" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프유이";
                else if (LikeOperator.LikeString(ID, "1803" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프레이";
                else if (LikeOperator.LikeString(ID, "1804" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프페코";
                else if (LikeOperator.LikeString(ID, "1805" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프코로";
                else if (LikeOperator.LikeString(ID, "1806" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "프캬루";
                else if (LikeOperator.LikeString(ID, "1807" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "하츠시오";
                else if (LikeOperator.LikeString(ID, "1808" + ls, Microsoft.VisualBasic.CompareMethod.Binary)) return "리틀리리";

                else return null;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public bool ReplaceStringInFile(string filename, int position, string str)
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

        public string StringArrayToCommaString(string[] temp)
        {
            string result = "";
            //Debug.WriteLine("x = " + temp.Length);
            for (int i = 0; i < temp.Length; i++)
            {
                result = result + temp[i] + ",";
            }
            //Debug.WriteLine("result = " + result); ;
            return result.Remove(result.Length - 1);
        }
        public string StringListToCommaString(List<string> temp)
        {
            string result = "";
            //Debug.WriteLine("x = " + temp.Length);
            for (int i = 0; i < temp.Count; i++)
            {
                result = result + temp[i] + ",";
            }
            //Debug.WriteLine("result = " + result); ;
            return result.Remove(result.Length - 1);
        }
    }


}
