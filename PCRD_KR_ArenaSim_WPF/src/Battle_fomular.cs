using System;
using System.Diagnostics;
namespace PCRD_KR_ArenaSim
{
    class Battle_fomular
    {
        public static double direct_damage(string attack_type, double damage, int my_order, int opponent_order)
        {
            if (attack_type == "1" || attack_type == "11")
            {
                if (Battle_variable.damage_add[my_order] == true)
                {
                    damage += Battle_variable.damage_add_coef[my_order] * Battle_variable.damage_add_count[opponent_order];
                }
                damage = damage / (1 + Math.Max(0, Battle_variable.PD[opponent_order]) / 100);
            }
            else if (attack_type == "2")
            {
                if (Battle_variable.damage_add[my_order] == true)
                {
                    damage += Battle_variable.damage_add_coef[my_order] * Battle_variable.damage_add_count[opponent_order];
                }
                damage = damage / (1 + Math.Max(0, Battle_variable.MD[opponent_order]) / 100);
            }
            return damage;
        }

        public static double direct_heal(string attack_type, double heal, int my_order)
        {
            heal = heal * (1 + Battle_variable.HPup[my_order] / 100);
            return heal;
        }

        public static double HP_absorption(string attack_type, double damage, int my_order, int opponent_order)
        {
            double heal = damage * Battle_variable.HPabs[my_order] / (100 + Level_variable.Lv[opponent_order] + Battle_variable.HPabs[my_order]);
            return heal;
        }

        public static double buff_hit(string attack_type, double hit, int my_order, int opponent_order)
        {
            hit = Math.Min(1, 1 - (Level_variable.Lv[opponent_order] - Level_variable.Lv[my_order]) / 100);
            return hit;
        }

        public static double damage_hit(string attack_type, double hit, int my_order, int opponent_order)
        {
            if (hit > 99)
            {
                hit = 1;
                return hit;
            }

            if (attack_type == "1" || attack_type == "11")
            {
                hit = Math.Min(1, 100 / (100 + Math.Max(0, Battle_variable.Dodge[opponent_order]) - Math.Max(0, Battle_variable.acc[my_order])));
                if (Battle_variable.blind[my_order] == true)
                {
                    hit = hit * (Battle_variable.blind_coef[my_order]) / 100;
                }
            }
            else if (attack_type == "2")
            {
                hit = 1;
            }
            return hit;
        }

        public static double critical(string attack_type, double crit, int my_order, int opponent_order)
        {
            if (crit > 99)
            {
                crit = 1;
                return crit;
            }

            if (attack_type == "1" || attack_type == "11")
            {
                crit = Battle_variable.PC[my_order] * 0.05 * 0.01 * Level_variable.Lv[my_order] / Level_variable.Lv[opponent_order];
            }
            else if (attack_type == "2")
            {
                crit = Battle_variable.MC[my_order] * 0.05 * 0.01 * Level_variable.Lv[my_order] / Level_variable.Lv[opponent_order];
            }
            return crit;
        }

        public static void action_TP(int my_order)
        {
            if (Battle_variable.panic[my_order] == false)
            {
                double TP = 90;
                TP = TP * (100 + Math.Max(0, Battle_variable.TPup[my_order])) / 100;
                Battle_variable.TP[my_order] += TP;
                max_TP_Process();
            }
        }

        public static void LostHP_TP(double damage, int opponent_order)
        {
            double TP;
            TP = (damage / Battle_variable.max_HP[opponent_order]) * 500;
            TP = TP * (100 + Math.Max(0, Battle_variable.TPup[opponent_order])) / 100;
            Battle_variable.TP[opponent_order] += TP;
            max_TP_Process();
        }

        public static void death_TP(int my_order, int opponent_order)
        {
            if (Battle_variable.death[opponent_order] == true && Battle_variable.panic[my_order] == false)
            {
                double TP = 200;
                TP = TP * (100 + Math.Max(0, Battle_variable.TPup[my_order])) / 100;
                Battle_variable.TP[my_order] += TP;
                max_TP_Process();
            }
        }

        public static void UB_TP(int my_order)
        {
            //Debug.WriteLine("{1}{0}가 UB 사용\n", Battle_variable.name[my_order], my_order);
            Battle_variable.TP[my_order] = 0;
            Battle_variable.TP[my_order] += 10 * Battle_variable.TPdec[my_order];
            max_TP_Process();
        }

        public static double damage_process(string attack_type, double damage, int my_order, int opponent_order)
        {
            if (Battle_variable.death[opponent_order] == false && Battle_variable.name_eng[opponent_order] == "lou" && Battle_variable.name_eng[my_order] != "lou")
            {
                if (opponent_order < 15 && Character_skill.lou_opponent_omeme >= 1)
                {
                    //루가 오메메를 가지고 있으면 대미지를 받을시 반사(고정대미지)하고 오메메가 하나 사라짐
                    damage = 30 + 30 * Level_variable.Lv[opponent_order];
                    damage = damage_process("99", damage, opponent_order, my_order);

                    Character_skill.lou_opponent_omeme -= 1;
                    return damage;
                }
                if (opponent_order >= 15 && Character_skill.lou_opponent_omeme_est >= 1)
                {
                    //루가 오메메를 가지고 있으면 대미지를 받을시 반사(고정대미지)하고 오메메가 하나 사라짐
                    damage = 30 + 30 * Level_variable.Lv[opponent_order];
                    damage = damage_process("99", damage, opponent_order, my_order);

                    Character_skill.lou_opponent_omeme_est -= 1;
                    return damage;
                }
            }
            if (Battle_variable.death[opponent_order] == false && Battle_variable.name_eng[opponent_order] == "saren_christmas" && Battle_variable.name_eng[my_order] != "saren_christmas")
            {
                if (opponent_order < 15 && Character_skill.saren_christmas_opponent_shield >= 1)
                {
                    //성사렌이 빛의 방패를 가지고 있으면 대미지를 받을시 반사(고정대미지)하고 빛의 방패가 하나 사라짐
                    damage = 37.5 + 37.5 * Level_variable.Lv[opponent_order];
                    damage = damage_process("99", damage, opponent_order, my_order);

                    Character_skill.saren_christmas_opponent_shield -= 1;
                    return damage;
                }
                if (opponent_order >= 15 && Character_skill.saren_christmas_opponent_shield_est >= 1)
                {
                    //성사렌이 빛의 방패를 가지고 있으면 대미지를 받을시 반사(고정대미지)하고 빛의 방패가 하나 사라짐
                    damage = 37.5 + 37.5 * Level_variable.Lv[opponent_order];
                    damage = damage_process("99", damage, opponent_order, my_order);

                    Character_skill.saren_christmas_opponent_shield -= 1;
                    return damage;
                }
            }

            if (attack_type == "1" && Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false && Battle_variable.invincible[opponent_order] == false && Battle_variable.physical_dodge[opponent_order] == false)
            {
                if (Battle_variable.damage_add[my_order] == true && Battle_variable.damage_add_count[opponent_order] < 5)//카오리
                {
                    Battle_variable.damage_add_count[opponent_order] += 1;
                }
                if (Battle_variable.name_eng[my_order] == "chloe" && ((Character_skill.chloe_opponent_twilight == true && my_order < 15) || (Character_skill.chloe_opponent_twilight_est == true && my_order >= 15)))//클로에
                {
                    if(Level_variable.equip[my_order] == true)
                    {
                        if (Battle_variable.intimidated_stack[opponent_order] < 99)
                        {
                            Battle_variable.intimidated_stack[opponent_order] += 1;
                        }
                    }
                    else
                    {
                        if (Battle_variable.intimidated_stack[opponent_order] < 66)
                        {
                            Battle_variable.intimidated_stack[opponent_order] += 1;
                        }
                    }                    
                }
                LostHP_TP(damage, opponent_order);//먼저 적용

                if (Battle_variable.Pabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Pabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Pabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Pabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Pabsorb_coef[opponent_order];
                        Battle_variable.Pabsorb_coef[opponent_order] = 0;
                        Battle_variable.Pabsorb[opponent_order] = false;
                        Battle_variable.Pabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Pbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Pbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Pbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Pbarrier_coef[opponent_order];
                        Battle_variable.Pbarrier_coef[opponent_order] = 0;
                        Battle_variable.Pbarrier[opponent_order] = false;
                        Battle_variable.Pbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                if (Battle_variable.Allabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Allabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Allabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Allabsorb_coef[opponent_order];
                        Battle_variable.Allabsorb_coef[opponent_order] = 0;
                        Battle_variable.Allabsorb[opponent_order] = false;
                        Battle_variable.Allabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Allbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Allbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Allbarrier_coef[opponent_order];
                        Battle_variable.Allbarrier_coef[opponent_order] = 0;
                        Battle_variable.Allbarrier[opponent_order] = false;
                        Battle_variable.Allbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                Character_skill._damage = damage;
                Battle_variable.HP[opponent_order] -= damage;
                max_HP_Process();


                if (Battle_variable.name_eng[opponent_order] == "kurumi_christmas" && damage > 0 && Battle_variable.charge[opponent_order] == true)//성루미
                {
                    //받은 대미지 횟수 저장
                    if (opponent_order < 15)
                    {
                        Character_skill.kurumi_christmas_opponent_counter += 1;
                    }
                    else
                    {
                        Character_skill.kurumi_christmas_opponent_counter_est += 1;
                    }
                }

                if (Battle_variable.name_eng[opponent_order] == "hatsune_summer" && damage > 0 && Battle_variable.sleep[opponent_order] == true)//수츠네
                {
                    //받은 대미지 횟수 저장
                    Battle_variable.sleep[opponent_order] = false;
                    Battle_variable.sleep_time[opponent_order] = 0;
                }
                if (Battle_variable.charge[opponent_order] == true)
                {
                    Battle_variable.charge_coef[opponent_order] += damage;
                }
                if (Battle_variable.counterattack[opponent_order] == true)
                {
                    Battle_variable.counterattack_coef[opponent_order] += 10000;
                }

                if (Battle_variable.death[my_order] == false)
                {
                    double abs_heal = HP_absorption("1", damage, my_order, opponent_order);
                    Battle_variable.HP[my_order] += abs_heal;
                    max_HP_Process();
                }
                death_TP(my_order, opponent_order);
            }
            else if (attack_type == "2" && Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false && Battle_variable.invincible[opponent_order] == false)
            {
                if (Battle_variable.damage_add[my_order] == true && Battle_variable.damage_add_count[opponent_order] < 5)//카오리
                {
                    Battle_variable.damage_add_count[opponent_order] += 1;
                }
                if (Battle_variable.name_eng[my_order] == "chloe" && ((Character_skill.chloe_opponent_twilight == true && my_order < 15) || (Character_skill.chloe_opponent_twilight_est == true && my_order >= 15)))//클로에
                {
                    if (Level_variable.equip[my_order] == true)
                    {
                        if (Battle_variable.intimidated_stack[opponent_order] < 99)
                        {
                            Battle_variable.intimidated_stack[opponent_order] += 1;
                        }
                    }
                    else
                    {
                        if (Battle_variable.intimidated_stack[opponent_order] < 66)
                        {
                            Battle_variable.intimidated_stack[opponent_order] += 1;
                        }
                    }
                }


                LostHP_TP(damage, opponent_order);//먼저 적용

                if (Battle_variable.Mabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Mabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Mabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Mabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Mabsorb_coef[opponent_order];
                        Battle_variable.Mabsorb_coef[opponent_order] = 0;
                        Battle_variable.Mabsorb[opponent_order] = false;
                        Battle_variable.Mabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Mbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Mbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Mbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Mbarrier_coef[opponent_order];
                        Battle_variable.Mbarrier_coef[opponent_order] = 0;
                        Battle_variable.Mbarrier[opponent_order] = false;
                        Battle_variable.Mbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                if (Battle_variable.Allabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Allabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Allabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Allabsorb_coef[opponent_order];
                        Battle_variable.Allabsorb_coef[opponent_order] = 0;
                        Battle_variable.Allabsorb[opponent_order] = false;
                        Battle_variable.Allabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Allbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Allbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Allbarrier_coef[opponent_order];
                        Battle_variable.Allbarrier_coef[opponent_order] = 0;
                        Battle_variable.Allbarrier[opponent_order] = false;
                        Battle_variable.Allbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                Character_skill._damage = damage;
                Battle_variable.HP[opponent_order] -= damage;
                max_HP_Process();


                if (Battle_variable.name_eng[opponent_order] == "kurumi_christmas" && damage > 0 && Battle_variable.charge[opponent_order] == true)//성루미
                {
                    //받은 대미지 횟수 저장
                    if (opponent_order < 15)
                    {
                        Character_skill.kurumi_christmas_opponent_counter += 1;
                    }
                    else
                    {
                        Character_skill.kurumi_christmas_opponent_counter_est += 1;
                    }
                }

                if (Battle_variable.name_eng[opponent_order] == "hatsune_summer" && damage > 0 && Battle_variable.sleep[opponent_order] == true)//수츠네
                {
                    //받은 대미지 횟수 저장
                    Battle_variable.sleep[opponent_order] = false;
                    Battle_variable.sleep_time[opponent_order] = 0;
                }
                if (Battle_variable.charge[opponent_order] == true)
                {
                    Battle_variable.charge_coef[opponent_order] += damage;
                }


                if (Battle_variable.death[my_order] == false)
                {
                    double abs_heal = HP_absorption("2", damage, my_order, opponent_order);
                    Battle_variable.HP[my_order] += abs_heal;
                    max_HP_Process();
                }
                death_TP(my_order, opponent_order);
            }
            else if (attack_type == "11" && Battle_variable.death[opponent_order] == false && Battle_variable.invincible[opponent_order] == false && Battle_variable.physical_dodge[opponent_order] == false)//폭탄:내가 죽어도 작동
            {
                LostHP_TP(damage, opponent_order);//먼저 적용

                if (Battle_variable.Pabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Pabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Pabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Pabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Pabsorb_coef[opponent_order];
                        Battle_variable.Pabsorb_coef[opponent_order] = 0;
                        Battle_variable.Pabsorb[opponent_order] = false;
                        Battle_variable.Pabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Pbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Pbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Pbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Pbarrier_coef[opponent_order];
                        Battle_variable.Pbarrier_coef[opponent_order] = 0;
                        Battle_variable.Pbarrier[opponent_order] = false;
                        Battle_variable.Pbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                if (Battle_variable.Allabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Allabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Allabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Allabsorb_coef[opponent_order];
                        Battle_variable.Allabsorb_coef[opponent_order] = 0;
                        Battle_variable.Allabsorb[opponent_order] = false;
                        Battle_variable.Allabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Allbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Allbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Allbarrier_coef[opponent_order];
                        Battle_variable.Allbarrier_coef[opponent_order] = 0;
                        Battle_variable.Allbarrier[opponent_order] = false;
                        Battle_variable.Allbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                Character_skill._damage = damage;
                Battle_variable.HP[opponent_order] -= damage;
                max_HP_Process();
                //Debug.WriteLine("{3}{2}에 의한 {0}의 폭탄 대미지 {1}", Battle_variable.name[opponent_order], damage, Battle_variable.death[my_order], Battle_variable.name[my_order]);
                //Debug.WriteLine("{0}의 HP: {1}", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order]);


                if (Battle_variable.name_eng[opponent_order] == "kurumi_christmas" && damage > 0 && Battle_variable.charge[opponent_order] == true)//성루미
                {
                    //받은 대미지 횟수 저장
                    if (opponent_order < 15)
                    {
                        Character_skill.kurumi_christmas_opponent_counter += 1;
                    }
                    else
                    {
                        Character_skill.kurumi_christmas_opponent_counter_est += 1;
                    }
                }

                if (Battle_variable.name_eng[opponent_order] == "hatsune_summer" && damage > 0 && Battle_variable.sleep[opponent_order] == true)//수츠네
                {
                    //받은 대미지 횟수 저장
                    Battle_variable.sleep[opponent_order] = false;
                    Battle_variable.sleep_time[opponent_order] = 0;
                }

                if (Battle_variable.charge[opponent_order] == true)
                {
                    Battle_variable.charge_coef[opponent_order] += damage;
                }


                if (Battle_variable.death[my_order] == false)
                {
                    double abs_heal = HP_absorption("1", damage, my_order, opponent_order);
                    Battle_variable.HP[my_order] += abs_heal;
                    max_HP_Process();
                }
                death_TP(my_order, opponent_order);
            }
            else if (attack_type == "99" && Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false && Battle_variable.invincible[opponent_order] == false)
            {
                LostHP_TP(damage, opponent_order);//먼저 적용

                if (Battle_variable.Allabsorb[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allabsorb_coef[opponent_order] -= damage;
                    if (Battle_variable.Allabsorb_coef[opponent_order] < 0)
                    {
                        Battle_variable.HP[opponent_order] += damage + Battle_variable.Allabsorb_coef[opponent_order];
                        max_HP_Process();

                        damage = -Battle_variable.Allabsorb_coef[opponent_order];
                        Battle_variable.Allabsorb_coef[opponent_order] = 0;
                        Battle_variable.Allabsorb[opponent_order] = false;
                        Battle_variable.Allabsorb_time[opponent_order] = 0;
                    }
                    else
                    {
                        Battle_variable.HP[opponent_order] += damage;
                        max_HP_Process();

                        damage = 0;
                    }
                }

                if (Battle_variable.Allbarrier[opponent_order] == true && damage > 0)
                {
                    Battle_variable.Allbarrier_coef[opponent_order] -= damage;
                    if (Battle_variable.Allbarrier_coef[opponent_order] < 0)
                    {
                        damage = -Battle_variable.Allbarrier_coef[opponent_order];
                        Battle_variable.Allbarrier_coef[opponent_order] = 0;
                        Battle_variable.Allbarrier[opponent_order] = false;
                        Battle_variable.Allbarrier_time[opponent_order] = 0;
                    }
                    else
                    {
                        damage = 0;
                    }
                }

                Battle_variable.HP[opponent_order] -= damage;
                max_HP_Process();

            }
            else
            {
                Character_skill._damage = 0;
            }
            return damage;
        }

        public static void HP_process(string attack_type, double heal, int my_order, int opponent_order)
        {
            if (Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false)
            {
                heal = direct_heal(attack_type, heal, my_order);
                Character_skill._damage = heal;
                Battle_variable.HP[opponent_order] += heal;
                max_HP_Process();
                //Debug.WriteLine("{3}{0}가 {4}{1}에게 힐 {2}", Battle_variable.name[my_order], Battle_variable.name[opponent_order], heal, my_order, opponent_order);
                //Debug.WriteLine("{2}{0} HP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order], opponent_order);
            }
            else
            {
                Character_skill._damage = 0;
            }
        }

        public static void TP_process(string attack_type, double TPheal, int my_order, int opponent_order)
        {
            if (Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false)
            {
                TPheal = TPheal * (100 + Math.Max(0, Battle_variable.TPup[opponent_order])) / 100;
                Character_skill._damage = TPheal;
                Battle_variable.TP[opponent_order] += TPheal;
                max_TP_Process();
                //Debug.WriteLine("{3}{0}가 {4}{1}에게 TP 증가 {2}", Battle_variable.name[my_order], Battle_variable.name[opponent_order], TPheal, my_order, opponent_order);
                //Debug.WriteLine("{2}{0} TP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.TP[opponent_order], opponent_order);
            }
            else
            {
                Character_skill._damage = 0;
            }
        }

        public static void max_HP_Process()
        {
            for (int i = 0; i < 30; i++)
            {
                if (Battle_variable.HP[i] > Battle_variable.max_HP[i] && Battle_variable.death[i] == false)
                {
                    Battle_variable.HP[i] = Battle_variable.max_HP[i];
                }
                else if (Battle_variable.HP[i] < 0 && Battle_variable.death[i] == false && Battle_variable.resurrection[i] == false)
                {
                    Battle_variable.HP[i] = 0;
                    Battle_variable.death[i] = true;
                    Battle_variable.battle_unit_initialize(i);
                    //Array.IndexOf(Battle_variable.name_eng, "skull", 0, 15) (Battle_variable.name_eng[i] == "sinobu" && Array.IndexOf(Battle_variable.name_eng, "skull", 15, 15))

                    if (Battle_variable.name_eng[i] == "sinobu")
                    {
                        if (i < 15)
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "skull", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "skull", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "skull", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "skull", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "skull", 0));
                            }
                        }
                        else
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "skull", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "skull", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "skull", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "skull", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "skull", 15));
                            }
                        }
                    }
                    if (Battle_variable.name_eng[i] == "chika")
                    {
                        if (i < 15)
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 0));
                            }
                        }
                        else
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika", 15));
                            }
                        }
                    }
                    if (Battle_variable.name_eng[i] == "chika_christmas")
                    {
                        if (i < 15)
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 0));
                            }
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 0));
                            }
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 0));
                            }
                        }
                        else
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_1", 15));
                            }
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_2", 15));
                            }
                            if (Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "sylph_chika_christmas_3", 15));
                            }
                        }
                    }
                    if (Battle_variable.name_eng[i] == "suzume_summer")
                    {
                        if (i < 15)
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "golem", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "golem", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "golem", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "golem", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "golem", 0));
                            }
                        }
                        else
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "golem", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "golem", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "golem", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "golem", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "golem", 15));
                            }
                        }
                    }
                    if (Battle_variable.name_eng[i] == "neneka")
                    {
                        if (i < 15)
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0) > -1 && Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0) < 15)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 0));
                            }
                        }
                        else
                        {
                            if (Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15) > 14 && Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15) < 30)
                            {
                                Battle_variable.HP[Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15)] = 0;
                                Battle_variable.death[Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15)] = true;
                                Battle_variable.battle_unit_initialize(Array.IndexOf(Battle_variable.name_eng, "neneka_alter", 15));
                            }
                        }
                    }
                }
                else if (Battle_variable.HP[i] < 0 && Battle_variable.death[i] == false && Battle_variable.resurrection[i] == true)
                {
                    Battle_variable.HP[i] = 0;
                    double heal = Battle_variable.resurrection_coef[i];
                    Battle_fomular.HP_process("1", heal, i, i);

                    if (Character_skill.simulation_count == 1)
                    {
                        MainWindow.WriteLog(string.Format("\n({5:F2}) {0}{1}의 기사의 가호로 인해 자신 {2}{3}의 {4:F2} HP 회복(부활)\n", i, Battle_variable.name[i], i, Battle_variable.name[i], Character_skill._damage, MainWindow.end_time - MainWindow.flow_time));
                        MainWindow.WriteLog(string.Format("{0}{1}의 HP: {2}\n", i, Battle_variable.name[i], Battle_variable.HP[i]));
                    }

                    Battle_variable.resurrection[i] = false;
                    Battle_variable.resurrection_time[i] = 0;
                    Battle_variable.resurrection_coef[i] = 0;
                }
            }
        }

        public static void max_TP_Process()
        {
            for (int i = 0; i < 30; i++)
            {
                if (Battle_variable.TP[i] > 1000)
                {
                    Battle_variable.TP[i] = 1000;
                }
                else if (Battle_variable.TP[i] < 0)
                {
                    Battle_variable.TP[i] = 0;
                }
            }
        }

        public static void start_absorb(int array_order)
        {
            if (Battle_variable.absorb[array_order] == true && Battle_variable.absorb_count[array_order] == 0)
            {
                Battle_variable.HPabs[array_order] += Battle_variable.absorb_coef[array_order];
                Battle_variable.absorb_count[array_order] = 1;
            }

            if (Battle_variable.clairvoyance[array_order] == true && Battle_variable.clairvoyance_active[array_order] == false && ((Character_skill.kristina_opponent_UB == false && array_order < 15) || (Character_skill.kristina_opponent_UB_est == false && array_order >= 15)))
            {
                Battle_variable.clairvoyance_active[array_order] = true;
            }
        }
        
        public static void end_absorb(int array_order)
        {
            if (Battle_variable.absorb[array_order] == true && Battle_variable.absorb_count[array_order] == 1)
            {
                Battle_variable.HPabs[array_order] -= Battle_variable.absorb_coef[array_order];
                Battle_variable.absorb[array_order] = false;
                Battle_variable.absorb_coef[array_order] = 0;
                Battle_variable.absorb_count[array_order] = 0;
            }

            if (Battle_variable.clairvoyance[array_order] == true && Battle_variable.clairvoyance_active[array_order] == true && ((Character_skill.kristina_opponent_UB == false && array_order < 15) || (Character_skill.kristina_opponent_UB_est == false && array_order >= 15)))
            {
                Battle_variable.clairvoyance[array_order] = false;
                Battle_variable.clairvoyance_active[array_order] = false;
            }
        }
                
        public static void buff_process(string buff_type, double coefficient, double duration, int my_order, int opponent_order)
        {
            if (Battle_variable.death[opponent_order] == false && Battle_variable.death[my_order] == false)
            {
                if (buff_type == "buff_HP" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_HP[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_HP[i, opponent_order] = true;
                    Battle_variable.buff_HP_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_HP_time[i, opponent_order] = duration;

                    Battle_variable.HP[opponent_order] += Battle_variable.buff_HP_coef[i, opponent_order];
                    Battle_variable.max_HP[opponent_order] += Battle_variable.buff_HP_coef[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 HP 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_HP_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} HP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_PA" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_PA[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_PA[i, opponent_order] = true;
                    Battle_variable.buff_PA_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_PA_time[i, opponent_order] = duration;
                    Battle_variable.PA[opponent_order] = Math.Max(0, Battle_variable.PA[opponent_order] + Battle_variable.buff_PA_coef[i, opponent_order]);
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    Debug.WriteLine("{3}{0}가 {4}{1}에게 물리공격력 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_PA_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리공격력: {1}\n", Battle_variable.name[opponent_order], Battle_variable.PA[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_MA" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_MA[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_MA[i, opponent_order] = true;
                    Battle_variable.buff_MA_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_MA_time[i, opponent_order] = duration;
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    Battle_variable.MA[opponent_order] = Math.Max(0, Battle_variable.MA[opponent_order] + Battle_variable.buff_MA_coef[i, opponent_order]);
                    Debug.WriteLine("{3}{0}가 {4}{1}에게 마법공격력 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_MA_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법공격력: {1}\n", Battle_variable.name[opponent_order], Battle_variable.MA[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_PD" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_PD[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_PD[i, opponent_order] = true;
                    Battle_variable.buff_PD_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_PD_time[i, opponent_order] = duration;
                    Battle_variable.PD[opponent_order] = Math.Max(0, Battle_variable.PD[opponent_order] + Battle_variable.buff_PD_coef[i, opponent_order]);
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리방어력 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_PD_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리방어력: {1}\n", Battle_variable.name[opponent_order], Battle_variable.PD[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_MD" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_MD[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_MD[i, opponent_order] = true;
                    Battle_variable.buff_MD_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_MD_time[i, opponent_order] = duration;

                    Battle_variable.MD[opponent_order] = Math.Max(0, Battle_variable.MD[opponent_order] + Battle_variable.buff_MD_coef[i, opponent_order]);
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 마법방어력 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_MD_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법방어력: {1}\n", Battle_variable.name[opponent_order], Battle_variable.MD[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_PC" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_PC[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_PC[i, opponent_order] = true;
                    Battle_variable.buff_PC_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_PC_time[i, opponent_order] = duration;
                    Battle_variable.PC[opponent_order] += Battle_variable.buff_PC_coef[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리크리티컬 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_PC_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리크리티컬: {1}\n", Battle_variable.name[opponent_order], Battle_variable.PC[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_MC" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_MC[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_MC[i, opponent_order] = true;
                    Battle_variable.buff_MC_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_MC_time[i, opponent_order] = duration;
                    Battle_variable.MC[opponent_order] += Battle_variable.buff_MC_coef[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 마법크리티컬 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_MC_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법크리티컬: {1}\n", Battle_variable.name[opponent_order], Battle_variable.MC[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_dodge" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_dodge[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_dodge[i, opponent_order] = true;
                    Battle_variable.buff_dodge_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_dodge_time[i, opponent_order] = duration;
                    Battle_variable.Dodge[opponent_order] += Battle_variable.buff_dodge_coef[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }


                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 회피 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_dodge_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 회피: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Dodge[opponent_order], opponent_order);
                }
                else if (buff_type == "PCdamage" && (Battle_variable.invincible[opponent_order] == false || coefficient > 2))
                {
                    int i = 0;
                    while (Battle_variable.PCdamage[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.PCdamage[i, opponent_order] = true;
                    Battle_variable.PCdamage_save[i, opponent_order] = coefficient - 2;
                    Battle_variable.PCdamage_time[i, opponent_order] = duration;
                    Battle_variable.PCdamage_coef[opponent_order] += Battle_variable.PCdamage_save[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }


                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 크리티컬 배율 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 크리티컬 배율: {1} (기본 2)\n", Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "MCdamage" && (Battle_variable.invincible[opponent_order] == false || coefficient > 2))
                {
                    int i = 0;
                    while (Battle_variable.MCdamage[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.MCdamage[i, opponent_order] = true;
                    Battle_variable.MCdamage_save[i, opponent_order] = coefficient - 2;
                    Battle_variable.MCdamage_time[i, opponent_order] = duration;
                    Battle_variable.MCdamage_coef[opponent_order] += Battle_variable.MCdamage_save[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }


                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 크리티컬 배율 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 크리티컬 배율: {1} (기본 2)\n", Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "buff_TPup" && (Battle_variable.invincible[opponent_order] == false || coefficient > 0))
                {
                    int i = 0;
                    while (Battle_variable.buff_TPup[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.buff_TPup[i, opponent_order] = true;
                    Battle_variable.buff_TPup_coef[i, opponent_order] = coefficient;
                    Battle_variable.buff_TPup_time[i, opponent_order] = duration;
                    Battle_variable.TPup[opponent_order] += Battle_variable.buff_TPup_coef[i, opponent_order];
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }


                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 TP상승 버프 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.buff_TPup_coef[i, opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} TP상승: {1}\n", Battle_variable.name[opponent_order], Battle_variable.TPup[opponent_order], opponent_order);
                }
                else if (buff_type == "Pbarrier" && Battle_variable.Pabsorb[opponent_order] == false)
                {
                    Battle_variable.Pbarrier[opponent_order] = true;
                    Battle_variable.Pbarrier_coef[opponent_order] = coefficient;
                    Battle_variable.Pbarrier_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Pbarrier_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Pbarrier_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "Mbarrier" && Battle_variable.Mabsorb[opponent_order] == false)
                {
                    Battle_variable.Mbarrier[opponent_order] = true;
                    Battle_variable.Mbarrier_coef[opponent_order] = coefficient;
                    Battle_variable.Mbarrier_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 마법배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Mbarrier_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Mbarrier_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "Allbarrier" && Battle_variable.Allabsorb[opponent_order] == false)
                {
                    Battle_variable.Allbarrier[opponent_order] = true;
                    Battle_variable.Allbarrier_coef[opponent_order] = coefficient;
                    Battle_variable.Allbarrier_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리마법배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Allbarrier_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리마법배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Allbarrier_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "Pabsorb")
                {
                    Battle_variable.Pbarrier[opponent_order] = false;
                    Battle_variable.Pbarrier_coef[opponent_order] = 0;
                    Battle_variable.Pbarrier_time[opponent_order] = 0;
                    Battle_variable.Pabsorb[opponent_order] = true;
                    Battle_variable.Pabsorb_coef[opponent_order] = coefficient;
                    Battle_variable.Pabsorb_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리흡수배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Pabsorb_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리흡수배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Pabsorb[opponent_order], opponent_order);
                }
                else if (buff_type == "Mabsorb")
                {
                    Battle_variable.Mbarrier[opponent_order] = false;
                    Battle_variable.Mbarrier_coef[opponent_order] = 0;
                    Battle_variable.Mbarrier_time[opponent_order] = 0;
                    Battle_variable.Mabsorb[opponent_order] = true;
                    Battle_variable.Mabsorb_coef[opponent_order] = coefficient;
                    Battle_variable.Mabsorb_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 마법흡수배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Mabsorb_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법흡수배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Mabsorb[opponent_order], opponent_order);
                }
                else if (buff_type == "Allabsorb")
                {
                    Battle_variable.Allbarrier[opponent_order] = false;
                    Battle_variable.Allbarrier_coef[opponent_order] = 0;
                    Battle_variable.Allbarrier_time[opponent_order] = 0;
                    Battle_variable.Allabsorb[opponent_order] = true;
                    Battle_variable.Allabsorb_coef[opponent_order] = coefficient;
                    Battle_variable.Allabsorb_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 물리마법흡수배리어 {2} 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.Allabsorb_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리마법흡수배리어: {1}\n", Battle_variable.name[opponent_order], Battle_variable.Allabsorb[opponent_order], opponent_order);
                }
                else if (buff_type == "ConHP")
                {
                    Battle_variable.ConHP[opponent_order] = true;
                    Battle_variable.ConHP_coef[opponent_order] = coefficient;
                    Battle_variable.ConHP_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 지속HP회복 {2} 시작", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.ConHP_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 지속HP회복량: {1}\n", Battle_variable.name[opponent_order], Battle_variable.ConHP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "ConTP")
                {
                    Battle_variable.ConTP[opponent_order] = true;
                    Battle_variable.ConTP_coef[opponent_order] = coefficient;
                    Battle_variable.ConTP_time[opponent_order] = duration;

                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 지속TP회복 {2} 시작", Battle_variable.name[my_order], Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 지속TP회복량: {1}\n", Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "Aspeed" && (Battle_variable.invincible[opponent_order] == false || coefficient > 1))
                {
                    Battle_variable.Aspeed[opponent_order] = true;
                    Battle_variable.Aspeed_coef[opponent_order] = coefficient;
                    Battle_variable.Aspeed_time[opponent_order] = duration;
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }


                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 행동속도 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 행동속도: {1} (기본 1)\n", Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "Mspeed" && (Battle_variable.invincible[opponent_order] == false || coefficient > 450))
                {
                    Battle_variable.Mspeed[opponent_order] = true;
                    Battle_variable.Mspeed_coef[opponent_order] = coefficient;
                    Battle_variable.Mspeed_time[opponent_order] = duration;
                    if (Battle_variable.name[opponent_order] == "성키노")
                    {
                        if (opponent_order < 15)
                        {
                            if(Character_skill.akino_christmas_opponent_holyprize == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter <= 25)
                                    Character_skill.akino_christmas_opponent_glitter++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter = 25;
                                
                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter, opponent_order);

                            }
                        }
                        else
                        {
                            if (Character_skill.akino_christmas_opponent_holyprize_est == true)
                            {
                                if (Character_skill.akino_christmas_opponent_glitter_est <= 25)
                                    Character_skill.akino_christmas_opponent_glitter_est++;
                                else
                                    Character_skill.akino_christmas_opponent_glitter_est = 25;

                                Debug.WriteLine("{2}{0}의 성야의 반짝임 수: {1}\n", Battle_variable.name[opponent_order], Character_skill.akino_christmas_opponent_glitter_est, opponent_order);
                            }
                        }
                    }

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 이동속도 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 이동속도: {1} (기본 450)\n", Battle_variable.name[opponent_order], Battle_variable.ConTP_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "provoke")
                {
                    if (opponent_order < 15)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            Battle_variable.provoke[i] = false;
                            Battle_variable.provoke_time[i] = 0;
                        }
                    }
                    else
                    {
                        for (int i = 15; i < 30; i++)
                        {
                            Battle_variable.provoke[i] = false;
                            Battle_variable.provoke_time[i] = 0;
                        }
                    }
                    Battle_variable.provoke[opponent_order] = true;
                    Battle_variable.provoke_time[opponent_order] = duration;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 도발 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "invincible")
                {
                    Battle_variable.invincible[opponent_order] = true;
                    Battle_variable.invincible_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 무적 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "physical_dodge")
                {
                    Battle_variable.physical_dodge[opponent_order] = true;
                    Battle_variable.physical_dodge_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 물리 회피 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "paralyze" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.paralyze[opponent_order] = true;
                    Battle_variable.paralyze_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 마비 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "stun" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.stun[opponent_order] = true;
                    Battle_variable.stun_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 스턴 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "bind" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.bind[opponent_order] = true;
                    Battle_variable.bind_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 속박 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "knockback" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.knockback[opponent_order] = true;
                    Battle_variable.knockback_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 넉백\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "freeze" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.freeze[opponent_order] = true;
                    Battle_variable.freeze_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 동결 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "timestop" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.timestop[opponent_order] = true;
                    Battle_variable.timestop_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 시간정지 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "delay" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.delay[opponent_order] = true;
                    Battle_variable.delay_time[opponent_order] = duration;
                }
                else if (buff_type == "enchant" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.enchant[opponent_order] = true;
                    Battle_variable.enchant_time[opponent_order] = duration;
                    Battle_variable.enchant_break[opponent_order] = false;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 유혹 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "confuse" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.confuse[opponent_order] = true;
                    Battle_variable.confuse_time[opponent_order] = duration;
                    Battle_variable.confuse_break[opponent_order] = false;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 혼란 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "poison" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.poison[opponent_order] = true;
                    Battle_variable.poison_coef[opponent_order] = coefficient;
                    Battle_variable.poison_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 독 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 독 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.poison_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "toxic" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.toxic[opponent_order] = true;
                    Battle_variable.toxic_coef[opponent_order] = coefficient;
                    Battle_variable.toxic_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 맹독 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 맹독 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.toxic_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "curse" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.curse[opponent_order] = true;
                    Battle_variable.curse_coef[opponent_order] = coefficient;
                    Battle_variable.curse_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 저주 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 저주 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.curse_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "burn" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.burn[opponent_order] = true;
                    Battle_variable.burn_coef[opponent_order] = coefficient;
                    Battle_variable.burn_time[opponent_order] = duration;

                    //Console.WriteLine("{2}{0}가 {3}{1}에게 화상 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Console.WriteLine("{2}{0} 화상 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.burn_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "field_P" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.field_P[opponent_order] = true;
                    Battle_variable.field_P_coef[opponent_order] = coefficient;
                    Battle_variable.field_P_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 물리대미지 필드 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 물리대미지 필드 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.field_P_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "field_M" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.field_M[opponent_order] = true;
                    Battle_variable.field_M_coef[opponent_order] = coefficient;
                    Battle_variable.field_M_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 마법대미지 필드 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 마법대미지 필드 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.field_M_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "blind" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.blind[opponent_order] = true;
                    Battle_variable.blind_coef[opponent_order] = coefficient;
                    Battle_variable.blind_time[opponent_order] = duration;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 암흑 시작", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 암흑 계수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.blind_coef[opponent_order], opponent_order);
                }
                else if (buff_type == "charge")
                {
                    Battle_variable.charge[opponent_order] = true;
                    Battle_variable.charge_coef[opponent_order] = coefficient;
                    Battle_variable.charge_time[opponent_order] = duration;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 차지 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "counterattack")
                {
                    Battle_variable.counterattack[opponent_order] = true;
                    Battle_variable.counterattack_coef[opponent_order] = coefficient;
                    Battle_variable.counterattack_time[opponent_order] = duration;
                    //Console.WriteLine("{2}{0}가 {3}{1}에게 차지 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "absorb")
                {
                    Battle_variable.absorb[opponent_order] = true;
                    Battle_variable.absorb_coef[opponent_order] = coefficient;
                    Battle_variable.absorb_count[opponent_order] = 0;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 HP 흡수 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} HP흡수: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HPabs[opponent_order], opponent_order);
                }
                else if (buff_type == "clairvoyance")
                {
                    Battle_variable.clairvoyance[opponent_order] = true;
                    Battle_variable.clairvoyance_active[opponent_order] = false;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 천리안 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "damage_add")
                {
                    Battle_variable.damage_add[my_order] = true;
                    Battle_variable.damage_add_coef[my_order] = coefficient;
                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 대미지 추가 스택 버프 성공", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} 대미지 추가: {1}회\n", Battle_variable.name[opponent_order], Battle_variable.damage_add_count[opponent_order], opponent_order);
                }
                else if (buff_type == "panic" && Battle_variable.invincible[opponent_order] == false)
                {
                    Battle_variable.panic[opponent_order] = true;
                    Battle_variable.panic_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 공황 시작\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "spirit")
                {
                    Battle_variable.spirit[opponent_order] = true;
                    Battle_variable.spirit_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 영령의 가호 부여\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "blade")
                {
                    Battle_variable.blade[opponent_order] = true;
                    Battle_variable.blade_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 바람의 칼날 부여\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "resurrection")
                {
                    Battle_variable.resurrection[opponent_order] = true;
                    Battle_variable.resurrection_coef[opponent_order] = coefficient;
                    Battle_variable.resurrection_time[opponent_order] = duration;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 기사의 가호 부여\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "sleep")
                {
                    Battle_variable.sleep[opponent_order] = true;
                    Battle_variable.sleep_time[opponent_order] = duration;

                    System.Diagnostics.Debug.WriteLine("{2}{0}가 {3}{1}에게 수면 부여\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
                else if (buff_type == "bomb")
                {
                    int i = 0;
                    while (Battle_variable.bomb[i, opponent_order] != false)
                    {
                        i++;
                    }
                    Battle_variable.bomb[i, opponent_order] = true;
                    Battle_variable.bomb_coef[i, opponent_order] = coefficient;
                    Battle_variable.bomb_time[i, opponent_order] = duration;
                    Battle_variable.bomb_index[i, opponent_order] = my_order;

                    //Debug.WriteLine("{2}{0}가 {3}{1}에게 폭탄 설치\n", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                }
            }
        }
        public static void field_process(double center_position, double radius, double duration, string buff_type, double coefficient, int my_order, int enemy_distinction)
        {
            // enemy distinction: 1이면 적, 2이면 아군 선택
            // field[i,0]은 필드의 생성여부, field_double[i,0]은 좌측 끝, field_double[i,1]은 우측 끝, field_double[i,2]는 필드 지속시간, field_double[i,3]은 필드 버프 계수를 나타냄
            // field_string[i,0]은 필드 버프 종류, field_int[i,0]은 필드 시전자의 인덱스, field_double[i,1]은 필드의 효과가 아군인가 적군인가를 나타냄
            if (Battle_variable.death[my_order] == false)
            {
                int i = 0;
                while (Battle_variable.field[i, 0] != false)
                {
                    i++;
                }
                double a = center_position - radius;
                double b = center_position + radius;

                Battle_variable.field[i, 0] = true;
                Battle_variable.field_double[i, 0] = a;
                Battle_variable.field_double[i, 1] = b;
                Battle_variable.field_double[i, 2] = duration;
                Battle_variable.field_double[i, 3] = coefficient;
                Battle_variable.field_string[i, 0] = buff_type;
                Battle_variable.field_int[i, 0] = my_order;
                Battle_variable.field_int[i, 1] = enemy_distinction;

                //Debug.WriteLine("{3}{0}가 필드 {1}:{2} 생성", Battle_variable.name[my_order], Battle_variable.field_string[i, 0], Battle_variable.field_double[i, 3], my_order);
                //Debug.WriteLine("{0}, {1}", a, b);
            }
        }




        public static void quicksort(ref double[] array, int l, int r, ref int[] sequence, int enemy_distinction)
        {
            if (enemy_distinction == 1 || enemy_distinction == 3)
            {
                for (int i = l; i <= r; i++)//도발
                {
                    if (Battle_variable.death[sequence[i]] == false && Battle_variable.provoke[sequence[i]] == true)
                    {
                        for (int k = l; k < r; k++)
                        {
                            sequence[k] = sequence[i];
                        }
                        return;
                    }
                }
            }
            //array는 위치값 순서이며 정렬되지 않은 데이터. 스킬 목표가 아군이면 array는 위치값 1~5 순서, 적군이면 위치값 5~1 순서로 입력해야함
            //(결과는 오름차순으로 정렬됨)
            //l은 array의 처음 위치(0), r은 array의 마지막 위치(5인일경우 4, 4인이면 3 등)
            if (l >= r)
            {
                return;
            }
            int num = l;
            int num2 = r;
            int index = (num + num2) / 2;
            double t = array[index];
            for (; ; )
            {
                while (num < r && array[num] < t)
                {
                    num++;
                }
                while (num2 > l && array[num2] > t)
                {
                    num2--;
                }
                if (num > num2)
                {
                    break;
                }
                double k = array[num];
                array[num] = array[num2];
                array[num2] = k;
                int j = sequence[num];
                sequence[num] = sequence[num2];
                sequence[num2] = j;
                num++;
                num2--;
            }

            if (l < num2)
            {
                quicksort(ref array, l, num2, ref sequence, 99);
            }
            if (num < r)
            {
                quicksort(ref array, num, r, ref sequence, 99);
            }
        }
    }


}
