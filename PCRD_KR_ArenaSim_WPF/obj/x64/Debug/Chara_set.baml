   M S B A M L   `   `   `  ����K  GPCRD_KR_ArenaSim, Version=1.4.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PCRD_KR_ArenaSimPCRD_KR_ArenaSim  5   	        PCRD_KR_ArenaSim.Chara_set   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PCRD_KR_ArenaSim     5   	   -   5          � Title$  캐릭터 설정��5   	   $	��440��6   $	��410��6%    � WindowStyle$
 None=�61    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterOwner=�6Z   .��5      �� -   5         ��Name$ 
tabControl��5      $��0,0,0,0q�6%   ���	#FFB3FFE7$��0q�5      ��6)   Z� .@�5   
   �� $��캐릭터 설정��6   $��0q�6"   ���	#FFFF5FDB$��70��5   -   $��0,0,0,0q�6;      GG#���   6M   $��30��6j   ��6   Z� .��5      � #���   6   .+�5      �� -   5         ��Name$ cb_enable_set��5      $��사용��62   $
��Left=�6?   $��	10,29,0,0q�6Z   $	��Top=�6m   $��17��6�   $��83��6�   $��14(�6�   5   4   � 5      -   5        $��Chara_set_grid��5      .+�5      �� -   5        $��bt_item1��5       � ToolTip$ Item1��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��250,60,100,290q�5   �   $��Center=�5      $��Center=�62   ��5   o   Z� .��5      �� -   5        $��	img_item1��5       $#��res\icon_equipment\101011.png��61   $
��Fill=�6Y   $��48��6j   $��48��6v   5      �� 5      -   5        $��bt_item2��5      $ Item2��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��288,142,62,208q�5   �   ��6o   Z� .��5      �� -   5        $��	img_item2��5       $#��res/icon_equipment/101071.png��62   $
��Fill=�6Z   $��48��6k   $��48��6w   5      �� 5      -	   5        $��bt_item3��5      $ Item3��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��250,224,100,126q�5    �   ��6o   Z� .��5!      �� -
   5        $��	img_item3��5!       $#��res\icon_equipment\101101.png��62   $
��Fill=�6Z   $��48��6k   $��48��6w   5"      �� 5#      -   5        $��bt_item4��5#      $ Item4��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��100,224,250,126q�5$   �   ��6o   Z� .��5%      �� -   5        $��	img_item4��5%       $#��res\icon_equipment\101131.png��62   $
��Fill=�6Z   $��48��6j   $��48��6v   5&      �� 5'      -   5        $��bt_item5��5'      $ Item5��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��62,142,288,208q�5(   �   ��6o   Z� .��5)      �� -   5        $��	img_item5��5)       $#��res\icon_equipment\101161.png��62   $
��Fill=�6Z   $��48��6k   $��48��6w   5*      �� 5+      -   5        $��bt_item6��5+      $ Item6��6-   $��0q�6?   
������ $��50��6n   $��50��6y   $��100,60,250,290q�5,   �   ��6o   Z� .��5-      �� -   5        $��	img_item6��5-       $#��res\icon_equipment\101191.png��62   $
��Fill=�6Z   $��48��6k   $��48��6w   5.      �� 52      -   5        $ Item_Unique��52      $��0q�65   
������ $��50��6d   $��50��6o   $��178,257,178,97q�53   a    J� RenderTransformOrigin$ 0.491,1.018&�6y   ��6J   Z� .��54      �� -   5        $��img_item_unique��54       $#��res/icon_equipment/999999.png��67   $
��Fill=�6_   $��48��6p   $��48��6|   56      �� 59      -   5         ��Name$ cB_set_rank��59      $��159,70,159,0q�64   $	��Top=�6J   ���	#FFF48D8D
���   �$��82��6�   $��25��6�   $��Center=�5:      $��Center=�6;   ��59   b   Z� .@�5;      �� $��Rank11��6'   $
��Left=�68   $��80��6T   ���	#FFC585FF6_   �� 5<      $��Rank12��6'   $
��Left=�68   $��80��6T   ���	#FFC585FF6_   �� 5=      $��Rank13��6'   $
��Left=�68   $��80��6T   ���	#FFC07BFF6_   �� 5>      $��Rank14��6'   $
��Left=�68   $��80��6T   ���	#FFBD74FF6_   �� 5?      $��Rank15��6'   $
��Left=�68   $��80��6T   ���	#FFBD72FF6_   �� 5@      $��Rank16��6'   $
��Left=�68   $��80��6T   ���	#FFAE58FB6_   �� 5A      $��Rank17��6'   $
��Left=�68   $��80��6T   ���	#FFA94EFA6_   �� 5B      $��Rank18��6'   $
��Left=�68   $��80��6T   ���	#FFE338536_   �� 5C      $��Rank19��6'   $
��Left=�68   $��80��6T   ���	#FFE229466_   �� 5D      $��Rank20��6'   $
��Left=�68   $��80��6T   ���	#FF3C966D6_   �� 5E      $��Rank21��6'   $
��Left=�68   $��80��6T   ���	#FF3291666_   �� 5F      $��Rank22��6'   $
��Left=�68   $��80��6T   ���	#FF227A526_   �� 5G      $��Rank23��6'   $
��Left=�68   $��80��6T   ���	#FF1F6C496_   �� 5H      $��Rank24��6'   $
��Left=�68   $��80��6T   ���	#FFFF62186_   �� 5I      $��Rank25��6'   $
��Left=�68   $��80��6T   ���	#FFE75B196_   5K      �� 5M      -   5        $��	Chara_sel��5M      $��res\icon_unit\000001.png��6-   $
��Fill=�6P   $��168,133,168,207q�6a   $��64��6z   �� 5N      $��자동강화��6   $��331,244,17,136q�6+   $��12(�6C   �� 5O      -   5        $ 공덱��5O      $��0q�6,   ���	#FFEDD4D4$��공덱으로 저장��5P      $��17,370,288,10q�6q   ��6Z   Z� 6q   �� 5Q      -   5        $ 방덱��5Q      $��0q�6,   ���	#FFD4EDD9$��방덱으로 저장��5R      $��288,370,17,10q�6R   	 �� 	IsDefault	 . ��6;   Z� 5S      �� 5U      -   5        $# 종료하기 전에 저장해��5U      $��0q�65   
�������$��종료��5V      $��163,361,163,-2q�6l   $��80��6�   $��45��6�   ��6U   Z� 6�   �� 5X      -   5        
 ��Name$
 img_star_item6_rf1��5X      $��res/star_item.png��68   $
��Left=�6S   $��104,112,0,0q�6n   $	��Top=�6�   $��9��5Y      $��9��6#   �� 5Z      -   5        $
 img_star_item6_rf2��5Z      $��res/star_item.png��69   $
��Left=�6T   $��113,112,0,0q�6o   $	��Top=�6�   $��9��5[      $��9��6#   �� 5\      -   5        $
 img_star_item6_rf3��5\      $��res/star_item.png��69   $
��Left=�6T   $��122,112,0,0q�6o   $	��Top=�6�   $��9��5]      $��9��6#   �� 5^      -   5        $
 img_star_item6_rf4��5^      $��res/star_item.png��69   $
��Left=�6T   $��131,112,0,0q�6o   $	��Top=�6�   $��9��5_      $��9��6#   �� 5`      -   5        $
 img_star_item6_rf5��5`      $��res/star_item.png��68   $
��Left=�6S   $��140,112,0,0q�6n   $	��Top=�6�   $��9��5a      $��9��6#   �� 5c      -   5        $
 img_star_item5_rf1��5c      $��res/star_item.png��68   $
��Left=�6S   $��
67,194,0,0q�6n   $	��Top=�6�   $��9��5d      $��9��6&   �� 5e      -   5        $
 img_star_item5_rf2��5e      $��res/star_item.png��68   $
��Left=�6S   $��
76,194,0,0q�6n   $	��Top=�6�   $��9��5f      $��9��6#   �� 5g      -   5        $
 img_star_item5_rf3��5g      $��res/star_item.png��68   $
��Left=�6S   $��
85,194,0,0q�6n   $	��Top=�6�   $��9��5h      $��9��6#   �� 5i      -    5        $
 img_star_item5_rf4��5i      $��res/star_item.png��68   $
��Left=�6S   $��
94,194,0,0q�6n   $	��Top=�6�   $��9��5j      $��9��6#   �� 5k      -!   5        $
 img_star_item5_rf5��5k      $��res/star_item.png��68   $
��Left=�6S   $��103,194,0,0q�6n   $	��Top=�6�   $��9��5l      $��9��6#   �� 5n      -"   5        $
 img_star_item4_rf1��5n      $��res/star_item.png��68   $
��Left=�6S   $��104,276,0,0q�6n   $	��Top=�6�   $��9��5o      $��9��6#   �� 5p      -#   5        $
 img_star_item4_rf2��5p      $��res/star_item.png��68   $
��Left=�6S   $��113,276,0,0q�6n   $	��Top=�6�   $��9��5q      $��9��6#   �� 5r      -$   5        $
 img_star_item4_rf3��5r      $��res/star_item.png��68   $
��Left=�6S   $��122,276,0,0q�6n   $	��Top=�6�   $��9��5s      $��9��6#   �� 5t      -%   5        $
 img_star_item4_rf4��5t      $��res/star_item.png��68   $
��Left=�6S   $��131,276,0,0q�6n   $	��Top=�6�   $��9��5u      $��9��6#   �� 5v      -&   5        $
 img_star_item4_rf5��5v      $��res/star_item.png��68   $
��Left=�6S   $��140,276,0,0q�6n   $	��Top=�6�   $��9��5w      $��9��6#   �� 5y      -'   5        $
 img_star_item3_rf1��5y      $��res/star_item.png��68   $
��Left=�6S   $��255,276,0,0q�6n   $	��Top=�6�   $��9��5z      $��9��6#   �� 5{      -(   5        $
 img_star_item3_rf2��5{      $��res/star_item.png��68   $
��Left=�6S   $��264,276,0,0q�6n   $	��Top=�6�   $��9��5|      $��9��6#   �� 5}      -)   5        $
 img_star_item3_rf3��5}      $��res/star_item.png��68   $
��Left=�6S   $��273,276,0,0q�6n   $	��Top=�6�   $��9��5~      $��9��6#   �� 5      -*   5        $
 img_star_item3_rf4��5      $��res/star_item.png��68   $
��Left=�6S   $��282,276,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -+   5        $
 img_star_item3_rf5��5�      $��res/star_item.png��68   $
��Left=�6S   $��291,276,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -,   5        $
 img_star_item2_rf1��5�      $��res/star_item.png��68   $
��Left=�6S   $��293,194,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      --   5        $
 img_star_item2_rf2��5�      $��res/star_item.png��68   $
��Left=�6S   $��302,194,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -.   5        $
 img_star_item2_rf3��5�      $��res/star_item.png��68   $
��Left=�6S   $��311,194,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -/   5        $
 img_star_item2_rf4��5�      $��res/star_item.png��68   $
��Left=�6S   $��320,194,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -0   5        $
 img_star_item2_rf5��5�      $��res/star_item.png��68   $
��Left=�6S   $��329,194,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -1   5        $
 img_star_item1_rf1��5�      $��res/star_item.png��68   $
��Left=�6S   $��255,112,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -2   5        $
 img_star_item1_rf2��5�      $��res/star_item.png��68   $
��Left=�6S   $��264,112,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -3   5        $
 img_star_item1_rf3��5�      $��res/star_item.png��68   $
��Left=�6S   $��273,112,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -4   5        $
 img_star_item1_rf4��5�      $��res/star_item.png��68   $
��Left=�6S   $��282,112,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -5   5        $
 img_star_item1_rf5��5�      $��res/star_item.png��68   $
��Left=�6S   $��291,112,0,0q�6n   $	��Top=�6�   $��9��5�      $��9��6#   �� 5�      -6   5        $
 img_star_chara1��5�      $��res/star_chara.png��65   $
��Left=�6Q   $��
147,25,0,0q�6l   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -7   5        $
 img_star_chara2��5�      $��res/star_chara.png��65   $
��Left=�6Q   $��
167,25,0,0q�6l   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -8   5        $
 img_star_chara3��5�      $��res/star_chara.png��65   $
��Left=�6Q   $��
187,25,0,0q�6l   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -9   5        $
 img_star_chara4��5�      $��res/star_chara.png��65   $
��Left=�6Q   $��
207,25,0,0q�6l   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -:   5        $
 img_star_chara5��5�      $��res/star_chara.png��65   $
��Left=�6Q   $��
227,25,0,0q�6l   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -;   5        $
 img_star_chara6��5�      $��res/star_chara_6.png��65   $
��Left=�6S   $��
247,25,0,0q�6n   $	��Top=�6�   $��20��5�      $��20��6$   �� 5�      -<   5         ��Name$ set_star��5�        MouseOverTransparent#��[ 6/   $
��Left=�6^   $��
147,25,0,0q�6y   $	��Top=�6�   $	��120��6�   $
 star��5�      $��0q�6.   
������ $��20��6^   ��5�   I   Z� �� 5�      -=   5         ��Name$ tB_chara_level��5�      $
��Left=�66   $��25��6Q   $��175,202,0,0q�6]    �� TextWrapping$
 Wrap=�6r   $	��157��6�   $	��Top=�6�   $��57��5�      $��Center=�6@   $��Center=�6b   ���	#FFFFECCD��6)   Z� 6�   �� 5�      ->   5        $ tB_unique_level��5�      $
��Left=�67   $��25��6R   $��183,312,0,0q�6^   $
 Wrap=�6s   $��0��6�   $	��Top=�6�   $��40��5�      ���	#FFFFF0F0$��Center=�6W   $��Center=�6y   ��6)   Z� 6�   �� 5�      -?   5        $  ��5�      $��0q�6*   ���	#FF5DDEFB$��최고레벨��5�      $��329,269,17,111q�6O   	 . ��68   Z� 5�      �� 5�      -@   5        $  ��5�      $��0q�6*   ���	#FF4DFF70$��최고랭크��5�      $��329,303,17,77q�6Q   	 . ��6:   Z� 5�      �� 5�      -A   5        $  ��5�      $��0q�6*   ���	#FFF1ACFF$��전용장비��5�      $��329,337,17,43q�6Q   	 . ��6:   Z� 5�      5�      5�      5�      �� 5�   
   $��스텟 확인��6   $��0q�6!   ���	#FFC7F7F1$��70��5�   -   $��0,0,0,0q�6;   #���   6M   $��30��6j   ��6   Z� .��5�      � #���   6   $��0,0,0,79q�61    � ColumnDefinitions 5�      �� 5�      6)   �� 5�      6)    � RowDefinitions 5�      �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��1* �6$   62   �� 5�      $��2* �6$   62   .+�5�      � $��1��6   $��0��6$   .+�5�      �� -B   5        $ textBox_Copy15��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6^   $��HP��6r   $	��Top=�6|   $	��100��6�   $��10,0,0,0q�6�    �� 
IsReadOnly . ��6�   Z� ��6�   Z� 6�   �� 5�      -C   5        $ tB_HP��5�      $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��2��6   $��0��6$   .+�5�      �� -D   5        $ textBox_Copy16��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6^   $��물리 공격력��6r   $	��Top=�6�   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -E   5        $ tB_PA��5�      $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��3��6   $��0��6$   .+�5�      �� -F   5        $ textBox_Copy17��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6]   $��물리 방어력��6q   $	��Top=�6   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -G   5        $ tB_PD��5�      $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��4��6   $��0��6$   .+�5�      �� -H   5        $ textBox_Copy18��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6]   $��물리 크리티컬��6q   $	��Top=�6�   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -I   5        $ tB_PC��5�      $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��5��6   $��0��6$   .+�5�      �� -J   5        $ textBox_Copy19��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6^   $��회피��6r   $	��Top=�6|   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -K   5        $ tB_Dodge��5�      $
��Left=�60   $��20��6K   $
 Wrap=�6X   $�� ��6l   $	��Top=�6u   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��6��6   $��0��6$   .+�5�      �� -L   5        $ textBox_Copy20��5�      $
��Left=�66   $��20��6Q   $
 Wrap=�6^   $��HP 자동 회복��6r   $	��Top=�6�   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -M   5        $ 	tB_HPauto��5�      $
��Left=�61   $��20��6L   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6v   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��7��6   $��0��6$   .+�5�      �� -N   5        $ textBox_Copy270��5�      $
��Left=�67   $��20��6R   $
 Wrap=�6_   $��	HP 흡수��6s   $	��Top=�6�   $	��100��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -O   5        $ tB_HPabs��5�      $
��Left=�60   $��20��6K   $
 Wrap=�6X   $�� ��6l   $	��Top=�6u   $��70��5�      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5�      � 5�      $��8��6   $��0��6$   .+�5�      �� -P   5        $ textBox_Copy120��5�      $
��Left=�67   $��20��6R   $
 Wrap=�6_   $��	TP 상승��6s   $	��Top=�6�   $��70��6�   $��10,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5�      -Q   5        $ tB_TPup��5�      $
��Left=�6/   $��20��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6t   $��70��5      $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5     � 5     $��1��6   $��1��6$   .+�5     �� -R   5        $ textBox_Copy5��5     $
��Left=�65   $��20��6P   $
 Wrap=�6]   $��	전투력��6q   $	��Top=�6|   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5     -S   5        $ tB_Power��5     $
��Left=�60   $��20��6K   $
 Wrap=�6X   $�� ��6l   $	��Top=�6u   $��70��5     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5	     � 5
     $��2��6   $��1��6$   .+�5     �� -T   5        $ textBox_Copy6��5     $
��Left=�65   $��20��6P   $
 Wrap=�6]   $��마법 공격력��6q   $	��Top=�6   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5     -U   5        $ tB_MA��5     $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5     � 5     $��3��6   $��1��6$   .+�5     �� -V   5        $ textBox_Copy7��5     $
��Left=�65   $��20��6P   $
 Wrap=�6\   $��마법 방어력��6p   $	��Top=�6~   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5     -W   5        $ tB_MD��5     $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5     � 5     $��4��6   $��1��6$   .+�5     �� -X   5        $ textBox_Copy8��5     $
��Left=�65   $��20��6P   $
 Wrap=�6\   $��마법 크리티컬��6p   $	��Top=�6   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5     -Y   5        $ tB_MC��5     $
��Left=�6-   $��20��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6r   $��70��5     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5     � 5     $��5��6   $��1��6$   .+�5     �� -Z   5        $ textBox_Copy9��5     $
��Left=�65   $��20��6P   $
 Wrap=�6]   $��명중��6q   $	��Top=�6{   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5     -[   5        $ tB_Acc��5     $
��Left=�6.   $��20��6I   $
 Wrap=�6V   $�� ��6j   $	��Top=�6s   $��70��5     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5!     � 5"     $��6��6   $��1��6$   .+�5#     �� -\   5        $ textBox_Copy10��5#     $
��Left=�66   $��20��6Q   $
 Wrap=�6^   $��TP 자동 회복��6r   $	��Top=�6�   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5$     -]   5        $ 	tB_TPauto��5$     $
��Left=�61   $��20��6L   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6v   $��70��5%     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5'     � 5(     $��7��6   $��1��6$   .+�5)     �� -^   5        $ textBox_Copy210��5)     $
��Left=�67   $��20��6R   $
 Wrap=�6_   $��회복량 상승��6s   $	��Top=�6�   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 5*     -_   5        $ tB_HPup��5*     $
��Left=�6/   $��20��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6t   $��70��5+     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   5-     � 5.     $��8��6   $��1��6$   .+�5/     �� -`   5        $ textBox_Copy310��5/     $
��Left=�67   $��20��6R   $
 Wrap=�6_   $��TP 소비 감소��6s   $	��Top=�6�   $	��100��6�   $��5,0,0,0q�6�    . ��6�   Z� ��6�   Z� 6�   �� 50     -a   5        $ tB_TPdec��50     $
��Left=�60   $��20��6K   $
 Wrap=�6X   $�� ��6l   $	��Top=�6u   $��70��51     $��	125,0,0,0q�6?    . ��6)   Z� ��6R   Z� 6i   53     �� 54     -b   5        $# 종료하기 전에 저장해��54     $��0q�61   
�������$��종료��55     $��80��56     $��45��6)   $��2��65   $��163,94,163,-81q�6I   $��9��6b   ��55  D   Z� 56  b   57     5:     5<     5?     