using System;
using System.Linq;
using System.Reflection;

namespace PCRD_KR_ArenaSim
{

    class Battle_theorem
    {
        public static void target_assign(int target_type, int enemy_distinction, double range, int array_order, ref int[] opponent_array_order, ref double[] opponent_distance)
        {
            // target_type: 1이면 하나, 2이면 범위내 여러명, 3이면 전체, 22면 전방범위내 여러명, 33이면 전방범위내 전체
            // enemy distinction: 1이면 적, 2이면 아군 선택, 3이면 유혹, 혼란 상태
            // range: target_type이 2일때, 그 범위 (다른 타입과는 상관없음)

            opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
            opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();

            if (enemy_distinction == 1)
            {
                if (Battle_variable.confuse[array_order] == true || Battle_variable.enchant[array_order] == true)
                {
                    enemy_distinction = 3;
                }
            }

            double distance1 = 10000, distance2 = 10000, distance3 = 10000, distance4 = 10000, distance5 = 10000;
            if (target_type == 1 && enemy_distinction == 1)
            {
                if (array_order < 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        opponent_distance[i - 15] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false)
                        {
                            if (opponent_distance[i - 15] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i - 15] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i - 15] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i - 15] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i - 15] < distance5)
                            {
                                distance5 = opponent_distance[i - 15];
                                opponent_array_order[4] = i;
                            }

                            if (Battle_variable.provoke[i] == true)
                            {
                                opponent_array_order[0] = i;
                                opponent_array_order[1] = i;
                                opponent_array_order[2] = i;
                                opponent_array_order[3] = i;
                                opponent_array_order[4] = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        opponent_distance[i] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false)
                        {
                            if (opponent_distance[i] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i] < distance5)
                            {
                                distance5 = opponent_distance[i];
                                opponent_array_order[4] = i;
                            }

                            if (Battle_variable.provoke[i] == true)
                            {
                                opponent_array_order[0] = i;
                                opponent_array_order[1] = i;
                                opponent_array_order[2] = i;
                                opponent_array_order[3] = i;
                                opponent_array_order[4] = i;
                                break;
                            }
                        }
                    }
                }
            }
            else if (target_type == 1 && enemy_distinction == 2)
            {
                if (array_order >= 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        opponent_distance[i - 15] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false)
                        {
                            if (opponent_distance[i - 15] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i - 15] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i - 15] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i - 15] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i - 15] < distance5)
                            {
                                distance5 = opponent_distance[i - 15];
                                opponent_array_order[4] = i;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        opponent_distance[i] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false)
                        {
                            if (opponent_distance[i] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i] < distance5)
                            {
                                distance5 = opponent_distance[i];
                                opponent_array_order[4] = i;
                            }
                        }
                    }
                }
            }
            else if (target_type == 2 && enemy_distinction == 1)
            {
                if (array_order < 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i - 15] = 0;
                        }
                        else
                        {
                            opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i] = 0;
                        }
                        else
                        {
                            opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i] <= range && Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 2 && enemy_distinction == 2)
            {
                if (array_order >= 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i - 15] = 0;
                        }
                        else
                        {
                            opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i] = 0;
                        }
                        else
                        {
                            opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i] <= range && Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 3 && enemy_distinction == 1)
            {
                if (array_order >= 15)// 적군 전체 저장
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 3 && enemy_distinction == 2)
            {
                if (array_order < 15)// 아군 전체 저장
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 1 && enemy_distinction == 3)
            {
                if (array_order >= 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        opponent_distance[i - 15] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            if (opponent_distance[i - 15] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i - 15] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i - 15] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i - 15] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i - 15];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i - 15] < distance5)
                            {
                                distance5 = opponent_distance[i - 15];
                                opponent_array_order[4] = i;
                            }

                            if (Battle_variable.provoke[i] == true)
                            {
                                opponent_array_order[0] = i;
                                opponent_array_order[1] = i;
                                opponent_array_order[2] = i;
                                opponent_array_order[3] = i;
                                opponent_array_order[4] = i;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        opponent_distance[i] = Math.Abs(Battle_variable.position[i] - Battle_variable.position[array_order]);

                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            if (opponent_distance[i] < distance1)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = distance1;
                                distance1 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = opponent_array_order[0];
                                opponent_array_order[0] = i;
                            }
                            else if (opponent_distance[i] < distance2)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = distance2;
                                distance2 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = opponent_array_order[1];
                                opponent_array_order[1] = i;
                            }
                            else if (opponent_distance[i] < distance3)
                            {
                                distance5 = distance4;
                                distance4 = distance3;
                                distance3 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = opponent_array_order[2];
                                opponent_array_order[2] = i;
                            }
                            else if (opponent_distance[i] < distance4)
                            {
                                distance5 = distance4;
                                distance4 = opponent_distance[i];
                                opponent_array_order[4] = opponent_array_order[3];
                                opponent_array_order[3] = i;
                            }
                            else if (opponent_distance[i] < distance5)
                            {
                                distance5 = opponent_distance[i];
                                opponent_array_order[4] = i;
                            }

                            if (Battle_variable.provoke[i] == true)
                            {
                                opponent_array_order[0] = i;
                                opponent_array_order[1] = i;
                                opponent_array_order[2] = i;
                                opponent_array_order[3] = i;
                                opponent_array_order[4] = i;
                                break;
                            }
                        }
                    }
                }
            }
            else if (target_type == 2 && enemy_distinction == 3)
            {
                if (array_order >= 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i - 15] = 0;
                        }
                        else
                        {
                            opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                        {
                            opponent_distance[i] = 0;
                        }
                        else
                        {
                            opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                        }

                        if (opponent_distance[i] <= range && Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 3 && enemy_distinction == 3)
            {
                if (array_order < 15)// 아군 전체 저장
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
                else
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (opponent_array_order[j] != -1)
                            {
                                j++;
                            }
                            opponent_array_order[j] = i;
                        }
                    }
                }
            }
            else if (target_type == 22 && enemy_distinction == 1)
            {
                if (array_order < 15)
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i - 15] = 0;
                            }
                            else
                            {
                                opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i - 15] = 0;
                            }
                            else
                            {
                                opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
                else
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i] = 0;
                            }
                            else
                            {
                                opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i] = 0;
                            }
                            else
                            {
                                opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
            }
            else if (target_type == 22 && enemy_distinction == 3)
            {
                if (array_order >= 15)
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i - 15] = 0;
                            }
                            else
                            {
                                opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i - 15] = 0;
                            }
                            else
                            {
                                opponent_distance[i - 15] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i - 15] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
                else
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i] = 0;
                            }
                            else
                            {
                                opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if ((Battle_variable.position_front[i] < Battle_variable.position[array_order] && Battle_variable.position[array_order] < Battle_variable.position_rear[i]) || (Battle_variable.position_front[i] > Battle_variable.position[array_order] && Battle_variable.position[array_order] > Battle_variable.position_rear[i]))
                            {
                                opponent_distance[i] = 0;
                            }
                            else
                            {
                                opponent_distance[i] = Math.Min(Math.Abs(Battle_variable.position_front[i] - Battle_variable.position[array_order]), Math.Abs(Battle_variable.position_rear[i] - Battle_variable.position[array_order]));
                            }

                            if (opponent_distance[i] <= range && Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
            }
            else if (target_type == 33 && enemy_distinction == 1)
            {
                if (array_order >= 15)
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
                else
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i])
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
            }
            else if (target_type == 33 && enemy_distinction == 3)
            {
                if (array_order < 15)
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 0; i < 15; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
                else
                {
                    target_assign(1, enemy_distinction, 0, array_order, ref opponent_array_order, ref opponent_distance);
                    if (opponent_array_order[0] == -1)
                    {
                        return;
                    }

                    if (Battle_variable.position[array_order] < Battle_variable.position[opponent_array_order[0]])
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] < Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                    else
                    {
                        opponent_array_order = Enumerable.Repeat<int>(-1, 15).ToArray<int>();
                        opponent_distance = Enumerable.Repeat<double>(10000, 15).ToArray<double>();


                        for (int i = 15; i < 30; i++)
                        {
                            if (Battle_variable.death[i] == false && Battle_variable.position[array_order] >= Battle_variable.position[i] && array_order != i)
                            {
                                int j = 0;
                                while (opponent_array_order[j] != -1)
                                {
                                    j++;
                                }
                                opponent_array_order[j] = i;
                            }
                        }
                    }
                }
            }
        }

        public static void damage_step(string attack_type, double damage, double hit, double crit, int my_order, int opponent_order)
        {
            damage = Battle_fomular.direct_damage(attack_type, damage, my_order, opponent_order);
            hit = Battle_fomular.damage_hit(attack_type, hit, my_order, opponent_order);
            if (Battle_variable.clairvoyance[my_order] == true && Battle_variable.clairvoyance_active[my_order] == true && attack_type == "1")
            {
                hit = 0;
            }
            crit = Battle_fomular.critical(attack_type, crit, my_order, opponent_order);

            //명중
            if (MainWindow.rand.NextDouble() < hit)
            {
                //성에루 치에루 스택
                if (Battle_variable.name_eng[my_order] == "chieru_nakayosi2" && ((Character_skill.chieru_nakayosi2_opponent_chieru == true && my_order < 15) || (Character_skill.chieru_nakayosi2_opponent_chieru_est == true && my_order >= 15)))//성에루
                {
                    if (Battle_variable.chieru_nakayosi2_stack[my_order] < 40)
                    {
                        Battle_variable.chieru_nakayosi2_stack[my_order] += 1;
                    }   
                }
                //성로에 스택
                if (Battle_variable.name_eng[my_order] == "chloe_nakayosi2" && ((Character_skill.chloe_nakayosi2_opponent_counter < 1  && my_order < 15) || (Character_skill.chloe_nakayosi2_opponent_counter_est < 1 == true && my_order >= 15)))//성에루
                {
                    if (Battle_variable.chloe_nakayosi2_stack[my_order] < 49)
                    {
                        Battle_variable.chloe_nakayosi2_stack[my_order] += 1;
                    }
                }
                //크리티컬 시
                if (MainWindow.rand.NextDouble() < crit)
                {
                    if (attack_type == "1" || attack_type == "11")
                    {
                        damage = damage * Battle_variable.PCdamage_coef[my_order] * Battle_variable.RCdamage_coef[opponent_order];
                    }
                    else if (attack_type == "2")
                    {
                        damage = damage * Battle_variable.MCdamage_coef[my_order] * Battle_variable.RCdamage_coef[opponent_order];
                    }
                    damage = Battle_fomular.damage_process(attack_type, damage, my_order, opponent_order);
                    //Debug.WriteLine("크리티컬: {3}{0}가 {4}{1}에게 {2} 대미지", Battle_variable.name[my_order], Battle_variable.name[opponent_order], damage, my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} HP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order], opponent_order);

                    if (Battle_variable.name_eng[my_order] == "chieru" && ((Character_skill.chieru_opponent_dance == true && my_order < 15) || (Character_skill.chieru_opponent_dance_est == true && my_order >= 15)))//치에루
                    {
                        if(Level_variable.equip[my_order] == true)
                        {
                            if (Battle_variable.chieru_stack[my_order] < 77)
                            {
                                Battle_variable.chieru_stack[my_order] += 1;
                            }
                        }
                        else
                        {
                            if (Battle_variable.chieru_stack[my_order] < 30)
                            {
                                Battle_variable.chieru_stack[my_order] += 1;
                            }
                        }
                        
                    }
                    if (Battle_variable.name_eng[my_order] == "rino_wonder")
                    {
                        if (my_order < 15)
                        {
                            Character_skill.rino_wonder_opponent_critical = true;
                        }
                        else
                        {
                            Character_skill.rino_wonder_opponent_critical_est = true;
                        }

                    }
                }
                else
                {
                    damage = Battle_fomular.damage_process(attack_type, damage, my_order, opponent_order);
                    //Debug.WriteLine("{3}{0}가 {4}{1}에게 {2} 대미지", Battle_variable.name[my_order], Battle_variable.name[opponent_order], damage, my_order, opponent_order);
                    //Debug.WriteLine("{2}{0} HP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order], opponent_order);
                }
            }
            else
            {
                //Debug.WriteLine("미스: {2}{0}가 {3}{1}에게 0 대미지", Battle_variable.name[my_order], Battle_variable.name[opponent_order], my_order, opponent_order);
                //Debug.WriteLine("{2}{0} HP: {1}\n", Battle_variable.name[opponent_order], Battle_variable.HP[opponent_order], opponent_order);
                Character_skill._damage = 0;
            }
        }

        public static int sort_step(ref int[] array, int array_order, int enemy_distinction, ref double[] info_array)
        {
            array = Enumerable.Repeat<int>(-1, 15).ToArray<int>();

            if (enemy_distinction == 1)
            {
                if (Battle_variable.confuse[array_order] == true || Battle_variable.enchant[array_order] == true)
                {
                    enemy_distinction = 3;
                }
            }

            double[] new_info_array = Enumerable.Repeat<double>(-1, 15).ToArray<double>();
            if (enemy_distinction == 1)
            {
                if (array_order < 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
            }
            else if (enemy_distinction == 2)
            {
                if (array_order >= 15)
                {
                    for (int i = 29; i > 14; i--)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
                else
                {
                    for (int i = 14; i > -1; i--)
                    {
                        if (Battle_variable.death[i] == false)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
            }
            else if (enemy_distinction == 3)
            {
                if (array_order >= 15)
                {
                    for (int i = 15; i < 30; i++)
                    {
                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        if (Battle_variable.death[i] == false && array_order != i)
                        {
                            int j = 0;
                            while (array[j] > -1)
                            {
                                j++;
                            }
                            array[j] = i;
                            new_info_array[j] = info_array[i];
                        }
                    }
                    int count = 0;
                    while (array[count] > -1)
                    {
                        count++;
                    }
                    int l = 0;
                    int r = count - 1;
                    Battle_fomular.quicksort(ref new_info_array, l, r, ref array, enemy_distinction);
                    return r;
                }
            }
            return 0;
        }

        public static void summon_step(string creature, int summoner_order, double creature_position)
        {
            Growth growth_stat = new Growth();
            if (creature == "skull")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("skull_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "skull")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "skull")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "해골";
                Battle_variable.name_eng[i] = "skull";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "sylph_chika")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "실프_치카";
                Battle_variable.name_eng[i] = "sylph_chika";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "sylph_chika_christmas_1")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_1")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_1")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "실프_성치카_1";
                Battle_variable.name_eng[i] = "sylph_chika_christmas_1";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "sylph_chika_christmas_2")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_2")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_2")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "실프_성치카_2";
                Battle_variable.name_eng[i] = "sylph_chika_christmas_2";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "sylph_chika_christmas_3")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_3")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "sylph_chika_christmas_3")
                        {
                            break;
                        }
                    }
                }

                Battle_variable.name[i] = "실프_성치카_3";
                Battle_variable.name_eng[i] = "sylph_chika_christmas_3";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "golem")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "golem")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "golem")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "골렘";
                Battle_variable.name_eng[i] = "golem";

                Battle_variable.HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = array1[0] + array1[1] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PA[i] = array1[2] + array1[3] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MA[i] = array1[4] + array1[5] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PD[i] = array1[6] + array1[7] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.MD[i] = array1[8] + array1[9] * ((double)Level_variable.Lv[summoner_order] + (double)Level_variable.Rank[summoner_order]);
                Battle_variable.PC[i] = array1[10];
                Battle_variable.MC[i] = array1[11];
                Battle_variable.HPauto[i] = 0;
                Battle_variable.TPauto[i] = 0;
                Battle_variable.Dodge[i] = 0;
                Battle_variable.HPabs[i] = array1[12];
                Battle_variable.HPup[i] = array1[13];
                Battle_variable.TPup[i] = array1[14];
                Battle_variable.TPdec[i] = 0;
                Battle_variable.acc[i] = 0;


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Battle_variable.battle_unit_initialize(i);
            }
            else if (creature == "neneka_alter")
            {
                FieldInfo dummy1 = growth_stat.GetType().GetField(string.Format("sylph_chika_{0}", Level_variable.star[summoner_order]), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                double[] array1 = (double[])dummy1.GetValue(growth_stat);

                int i = 0;
                if (summoner_order < 15)//정보를 넣을 위치 선정
                {
                    for (i = 0; i < 15; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "neneka_alter")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (i = 15; i < 30; i++)
                    {
                        if (Battle_variable.name_eng[i] == "" || Battle_variable.name_eng[i] == "neneka_alter")
                        {
                            break;
                        }
                    }
                }


                Battle_variable.name[i] = "네네카_분신";
                Battle_variable.name_eng[i] = "neneka_alter";

                Battle_variable.HP[i] = Stat_variable.HP[summoner_order];
                Battle_variable.TP[i] = 0;

                Battle_variable.max_HP[i] = Stat_variable.HP[summoner_order];
                Battle_variable.PA[i] = Stat_variable.PA[summoner_order];
                Battle_variable.MA[i] = Stat_variable.MA[summoner_order];
                Battle_variable.PD[i] = Stat_variable.PD[summoner_order];
                Battle_variable.MD[i] = Stat_variable.MD[summoner_order];
                Battle_variable.PC[i] = Stat_variable.PC[summoner_order];
                Battle_variable.MC[i] = Stat_variable.MC[summoner_order];
                Battle_variable.HPauto[i] = Stat_variable.HPauto[summoner_order];
                Battle_variable.TPauto[i] = Stat_variable.TPauto[summoner_order];
                Battle_variable.Dodge[i] = Stat_variable.Dodge[summoner_order];
                Battle_variable.HPabs[i] = Stat_variable.HPabs[summoner_order];
                Battle_variable.HPup[i] = Stat_variable.HPup[summoner_order];
                Battle_variable.TPup[i] = Stat_variable.TPup[summoner_order];
                Battle_variable.TPdec[i] = Stat_variable.TPdec[summoner_order];
                Battle_variable.acc[i] = Stat_variable.acc[summoner_order];


                Battle_variable.position[i] = creature_position;
                Battle_variable.death[i] = false;
                Battle_variable.battle_positionset();


                Level_variable.equip[i] = Level_variable.equip[summoner_order];
                Level_variable.star[i] = Level_variable.star[summoner_order];
                Level_variable.Lv[i] = Level_variable.Lv[summoner_order];


                Character_skill.neneka_passive(i); //나중에 등록해야함 무조건


                Battle_variable.battle_unit_initialize(i);
            }
        }
    }

}
