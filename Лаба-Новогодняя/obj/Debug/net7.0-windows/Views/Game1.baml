   M S B A M L   `   `   `  ����X  TЛаба-Новогодняя, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Лаба_Новогодняя.Views#Лаба_Новогодняя.Views  5   	   1    +Лаба_Новогодняя.Views.Window1   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:Лаба_Новогодняя.Views     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ Game1��5	   	    � SizeToContent$ WidthAndHeight=�6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��Center=�6-   $��Bottom=�6J   $��
Слово��6e   $��36(�6v   �� 5   
   $��1��6   $��0��6    $��Center=�6-   $��Bottom=�6J   $��Перевод��6e   $��36(�6x   �� 5   
   -   5         ��Name$ Word1��5      $��0��6#   $��1��63   $��50��6@   $��24(�6O   ${�False��6]   �� 5   
   -   5        $ 
Translate1��5      $��1��6(   $��1��68   $��50��6E   $��24(�6T   ${�False��6b   �� 5   
   -   5        $��0��5      $��2��6!   $��Правильно��6.   $��24(�6B   
��� �|�6g   �� 5   
   -   5        $��1��5      $��2��6!   $��Неверно��6.   $��24(�6@   
���  ��6_   �� 5   
   $��0��6   $��3��6    $��Время -��6-   $��30(�6?   �� 5   
   -   5        $ Timer��5      $��1��6#   $��3��63   $��30(�6@   $��Center=�6N   �� 5   
   $��0��6   $��4��6    $��
Баллы��6-   $��30(�6=   �� 5    
   -   5        $ Points��5       $��1��6$   $��4��64   $��30(�6A   $��0��6O   $��Center=�6X   5!      5"      