   M S B A M L   `   `   `  ����e  acursovoi_qiz_wpf_mvvm_data_base_25-05-2023, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:cursovoi_qiz_wpf_mvvm_data_base_25_05_2023*cursovoi_qiz_wpf_mvvm_data_base_25_05_2023  5   	   'clr-namespace:MVVMENTITY
MVVMENTITY  5   	       MVVMENTITY.View   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:cursovoi_qiz_wpf_mvvm_data_base_25_05_2023     5   	   +local1clr-namespace:MVVMENTITY     5   	     � Title$
  View��5
   	   $	��450��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�6/   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.8* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   ��6"   �� *Dogs+ �� SelectedItem 5      �� *SelectedDog+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��18(�6$   ��62   ��  �� Path$ DogName�5      5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5       �� $��91��64   ��6   �� *
AddCommand+.��6?   +6B   �� 5!       J� RenderTransformOrigin$ 0.5,0.5&�6`   $��91��6�   ��6   �� *RemoveCommand+��67   �� *SelectedDog+z�5"      V� 5#      .~�5$      ��  �� ScaleX$ -1Q�6)   �� 5%      T� 5'      5(      .��5*      �� $��-��6   	 �� 	IsDefault$
	 True��6%   5+      �� 5,      $ 0.5,0.5&�60   $��91��6P   ��6   �� *SyncDb+.��6[   synchronize6h   5.      �� 50   
   $��1��6   
 � DataContext
 6%   �� *SelectedDog+ �� UpdateSourceTrigger$ PropertyChanged=�.+�51      �� $'��!Выбранный элемент��6   �� 52      $��Собака��6   �� 53      ��6   �� *	DogName+$ PropertyChanged=��� 54      $��Вопрос��6   �� 55      ��6   �� *
question+$ PropertyChanged=��� 56      $��
Ответ��6   �� 57      ��6   �� *ansver+$ PropertyChanged=��� 58      $��
Номер��6   �� 59      ��6   �� *Id+$ PropertyChanged=�5:      5;      5<      