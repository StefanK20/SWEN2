   M S B A M L   `   `   `  ����  TourPlanner    TourPlanner.Views.LogList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%�  '��       '  x     ']� D    '�� �    �� 5	   
   " ��6   .�5
      ��  � ��$
 10 0q�6'   66   �� 5       � ��$ 16(�6)   66   5      �� 5   
   "  6   .�5      ��  � ��$ 
10 5 10 10q�6'   6<   �� 5       � ��$
 10 5q�6(   67   �� 5       � ��
 �iii�6>   �� 5       � ��
 �����6;   5      �� 5   
   " ]�6   .�5      ��  � ��$ 0 0 9 0q�6'   69   5      �� 5   
   " ��6   .�5      ��  � ��$	 1 2q�6'   65   �� 5       � ��$ 20��6&   63   �� 5       � ��$ 20��6'   64   �� 5       � ��$ Center=�69   6J   �� 5       � ��$ Center=�6;   6L   5      5      .��5      �  � RowDefinitions 5   
   �� 5       $
��Auto �6   6,   �� 5!      $��* �6   6)   .+�5$   
   ]� $��0��6   .+�5%      �� $
��Left=�6   ��6.   �� *LogListHeading+�� 5&       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5'      �� ��6   �� *AddLogDialogCommand+.��5(      (� $��16��6   $��16��6)   .��5)      �� $��24��6!   $��24��6,   .+�5*      F� 
���   �|������!@]� �@]� @]� �@]� ��!��ا ��!��ا @]� �@KL @]� �@KL �ا ��ا �ا ��ا @KL �@]� @KL �@]� �ا ���!�ا ���!@]� 	60   5+      5,      5-      �� 5.      ��6   �� *DeleteLogCommand+.��5/      (� $��16��6   $��16��6)   .��50      �� $��24��6!   $��24��6,   .+�51      F� 
���   �4������!@]� �@KL @]� �@KL �ا ���!�ا ���!@]� 	60   52      53      54      �� 55      ��6   �� *EditLogDialogCommand+.��56      (� $��16��6   $��16��6)   .��57      �� $��24��6!   $��24��6,   .+�58      F� 
���   ������p< lk ���A�xe ��A��[ p<0�U ��M�32 Ӏ� @, p� @,  ��32 р��   N ���pX� ���- �6���- @o@�0�f @o@�P��� ���� �L^ ���- �6	60   59      5:      5;      5<      5=        5?   
   $��1��6      AutoGenerateColumns$ False��5@      "   VerticalScrollBarVisibility$
 Auto=�6/      CanUserReorderColumns$
 True��5A      	   CanUserSortColumns$
	 True��60   ��5?       �� *Logs+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5B      �� *SelectedLog+$
 TwoWay=�$ PropertyChanged=�   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Start��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 64      
IsReadOnly$
 True��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5E   %   �� *Start+  5F      $ Destination��6%   $	 15* 6:   $
 True��6F    5G   %   �� *Destination+  5H      $ Start Date and Time��6%   $	 25* 6B   $
 True��6N    5I   %   �� *	StartTime+ �� StringFormat$ {0:dd.MM.yyyy hh:mm:ss}��  5J      $ Tour Duration��6%   $	 20* 6<   $
 True��6H    5K   %   �� *DisplayTime+  5L      $ Comment��6%   $	 20* 66   $
 True��6B    5M   %   �� *	Comment+  5N      $ 
Difficulty��6%   $	 10* 69   $
 True��6E    5O   %   �� *
Difficulty+  5P      $ Rating��6%   $	 10* 65   $
 True��6A    5Q   %   �� *Rating+5S      5T      5U      