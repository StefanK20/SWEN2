   M S B A M L   `   `   `  ����  TourPlanner!    TourPlanner.Views.LogDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$	  Log��5   	    � 
ResizeMode$ 	CanResize=�5	   	   $	��450��5
   	   $	��500��6    � 	Resources 5         HeadingStyle �� 
TargetType �� Property �� Value  CommentStyle  FormTextBlockStyle&   Xceed.Wpf.Toolkit.DateTimePicker,  &Xceed.Wpf.Toolkit.Primitives.InputBase%  Xceed.Wpf.Toolkit.IntegerUpDown��%[  &	        &	 �     '�� �    &	 �    '�� c    '      '  �    �� 5   
   " ��6%   .�5      ��  � ��$ Center=�62   6C   �� 5       � ��$ Center=�64   6E   �� 5       � ��$ 20(�6)   66   �� 5       � ��$ Medium"�6+   6<   5      �� 5   
   " ��6%   .�5      ��  � ��$
 15 5q�6'   66   �� 5       � ��$	 Top=�69   6G   �� 5       � ��$ 10 10q�6(   68   �� 5       �@��TextWrapping$
 Wrap=�6-   6<   �� 5       �@��AcceptsReturn$
 True��6.   6=   5      �� 5   
   " ��6   .�5      ��  � ��$
 15 5q�6'   66   �� 5       � ��$ Center=�69   6J   �� 5       � ��$
 10 0q�6(   67   5      �� 5   
   " ��6+   .�5      ��  � ��$
 15 0q�6'   66   �� 5        � ��$ Center=�62   6C   �� 5!       � ��$ 15(�6)   66   �� 5"       � ��$ Medium"�6+   6<   5#      �� 5$   
   " ��6   .�5%      ��  � ��$ 5q�6'   63   �� 5&       � ��$ 30��6'   64   �� 5'       � ��$ Bottom=�62   6C   5(      �� 5)   
   "  6   .�5*      ��  � ��$
 15 5q�6'   66   �� 5+       �@ TextAlignment$
 Left=�6.   6=   5,      �� 5-   
   "  6   .�5.      ��  � ��$
 15 5q�6'   66   �� 5/       �@ TextAlignment$
 Left=�6.   6=   50      51      .��52      �  � RowDefinitions 53   
   �� 54      $	��10* �6   6+   �� 55      $	��80* �6   6+   �� 56      $	��20* �6   6+   .+�59   
   �� $��0��6   #��[  6!   ��5:      �� *LogDialogHeading+� 5<   
   $��1��6    � ColumnDefinitions 5=      �� 5>      $	��30* �6#   61   �� 5?      $	��70* �6#   61    5A      �� 5B      $��* �6    6-   �� 5C      $��* �6    6-   �� 5D      $��* �6    6-   �� 5E      $��* �6    6-   �� 5F      $��* �6    6-   �� 5G      $��* �6    6-   .+�5J      �� $��0��6   $��0��6%   $��Start Date/Time*:��65   #��[ 6N     5K      $��0��6"   $��1��6/   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ FullDateTime=�6?   	   Text	 5L   "   �� *LogDialogStartDateTime+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5M      $��1��6   $��0��6%   $��End Date/Time*:��65   #��[ 6L     5N      $��1��6"   $��1��6/   $ FullDateTime=�6?   	 5O   "   �� *LogDialogEndDateTime+$
 TwoWay=�$ PropertyChanged=��� 5P      $��2��6   $��0��6%   $��	Comment*:��65   #��[ 6F   �� 5Q      $��2��6   $��1��6#   $��2��63   #��[ 6D   ��5R      �� *LogDialogComment+$
 TwoWay=�$ PropertyChanged=��� 5S      $��4��6   $��0��6%   $��Difficulty*:��65   #��[ 6I     5T      $��4��6!      	Watermark$ 0 (easy) - 10 (hard)��6.   $��1��6O   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum 06_      Maximum 106k   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16x   	 5U   !   �� *LogDialogDifficulty+$
 TwoWay=�$ PropertyChanged=��� 5V      $��5��6   $��0��6%   $��Rating*:��65   #��[ 6E     5W      $��5��6!   $# 0 (horrible) - 10 (excellent)��6.   $��1��6X    06h    106t    16�   	 5X   !   �� *LogDialogRating+$
 TwoWay=�$ PropertyChanged=�5Y      � 5[   
   $��2��6    5\      �� 5]      $��* �6#   6/   �� 5^      $��* �6#   6/   .+�5`      �� -   5         ��Name$ CancelNewLogButton��5`   %   $��0��6   $��Cancel��6A    �� IsCancel$
 True��5a      �� 5b      -   5        $ SubmitNewLogButton��5b   %   $��1��6   $��Submit��6A    �� 	IsDefault$
 True��6R   ��5c      �� *SubmitCommand+5d      5e      5f      