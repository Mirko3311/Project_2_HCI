   M S B A M L   `   `   `  ����S  ODrugiProjektniZadatakHCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DrugiProjektniZadatakHCIDrugiProjektniZadatakHCI  5   	   )    #DrugiProjektniZadatakHCI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DrugiProjektniZadatakHCI     5   	     � Icon$  Images/memoryGames.png��5   	    � WindowState$ 	Maximized=�5	   	    � Title$ Memory Game��5
   	   .��5      � ��5   
   �� 5       �� ImageSource$ Images/background.png��6   5      .+�5   
   o� $	��Top=�6   
����ح�.@�5      m�  � ToolTip$
 Igra��6   $	��100��6&   ��5      �� 5      $��Images/game.png��6   $��55��65   $��60��6@   $��	0,0,30,30q�6M   .@�5      m� -   5        $��	Nova igra��5      
�������6D   m� 5      -   5        $��Resetuj igru��5      61   m� 5      -   5        $��Izlaz��5      6*   5      m� 5      $ Podešavanja��6   $��77��6-   ��5      �� 5      $��Images/settings.png��6   $��45��69   $��60��6D   $��	0,0,30,30q�6Q   .@�5      m� $��Težina��6   .@�5      m� -   5        $
��Laki��5      
������6C   m� 5       -   5        $��Srednji��5       
��� ���6H   m� 5!      -   5        $��Teški��5!      
�������6D   5"      m� 5$      $��
Kategorija��6   .@�5%      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5&      �� $��Izaberi kategoriju: ��6$   $��Center=�6@   �� 5'      -   5        $	��120��5'   #   .@�5(      �� $��
Životinje��6+   �� 5)      $��Voće��6+   5*      5+      5,      5.      m� 5/      -   5        $ 	Rezultati��5/      ��50      �� 51      $��Images/result.png��6   $��45��67   $��60��6B   $��	0,0,30,30q�6O   53      m� 54      $ Timer��6   ��55      �� 56      $ 
Horizontal=�6!   $��600,15,-20,20q�6:   $��Center=�6Q   $��57��6l   .+�5:      �� 
������ $��0q�6:   .��5<      �� $��Images/counter.png��6$   $��50��6@   $��60��6K   5>      �� 5@      -	   5        $��AttemptsText��5@   $   $��14(�68   $��	40,0,10,0q�6G   $��Center=�6Z   $	��100��6u   �� 5C      
������ $��0q�6;   $��14(�6O   $��10,-10,25,0q�6]   $��Center=�6r   $��61��6�   $��59��6�   .��5D      �� $��Images/clock.png��6$   $��48��6>   5E      �� 5F      -
   5        $��TimeText��5F   $   $��14(�64   $��Center=�6B   5G      5I      5K      �� 5M   
   
���**��$��10q�6%    �� CornerRadius$ 10��6:    �� Padding$ 5q�6L   $��61,100,60,85q�6X   ._�5N      � -   5        $��	GameBoard��5N      $��8,11,0,0q�6$   5P      5Q      �� 5R   
   $ 
Horizontal=�6   $��Bottom=�6.   $
��Left=�6I   $��
400,10,0,4q�6d   $	��240��6x   .+�5S      � .+�5V      �� -   5        
������ $��
30,1,100,0q�5V   G   .��5W      �� $��Images/start.png��6   $	��100��66   $��77��6B   5X      �� 5Y      -   5        
������ $��0q�5Y   F   $��160,0,-50,0q�6Z   .��5Z      �� $��Images/pause.png��6   $��75��66   $��75��6A   5[      5]      5^      5_      5`      