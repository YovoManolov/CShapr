   M S B A M L   `   `   `  ����L  HStudentInfoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentInfoSystemStudentInfoSystem  5      (    "StudentInfoSystem.ProffesorSuccess   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:StudentInfoSystem     5        N� Title$  ProffesorSuccess��5	      .��5      � .+�5   
   �� $��Професор��6   $
��Left=�6%   $	��280��6@   $	��380��6N   $��	10,10,0,0q�6Z   $	��Top=�6m   .��5      �  � ColumnDefinitions 5      �� 5      �� 5      $	��170 �6'    � RowDefinitions 5      �� 5      .+�5      � $��0��6   $��0��6$    5      �� 5       5      �� 5      �� 5      $	��210 �6(   .+�5      �� $��0��6   $��Студенти:��6)   $
��Left=�6=   $��	10,15,0,0q�6X   $	��Top=�6k   $��29��6�   $��80��6�   �� 5       -   5        $��
ProfStList��5    ,   $��1��6   $��Right=�6>   $	��188��6Z   $��Center=�6g   $	��190��6�   $��	0,11,8,11q�6�    �� View 5!      �� 5"      .P�5#   "   �� -   5        Student��$
��Name��5#   B    �� CellTemplate 5$   &   �� 5%   *   .R�5&   .   �� 
����  � � Cursor$
 Hand��6`   ��69   �� *ime+6p   5'   +   5)   #   5*      5,      5-      � 5/      $��0��6   $��1��6$    50      �� 51       53      �� 54      $��30 �6(   �� 55      $��30 �6(   �� 56      $��30 �6(   �� 57      $��30 �6(   �� 58      $��30 �6(   .+�5:      �� $��1��6   $��Намери по фн:��6)   $
��Left=�6A   $��2��6\   $	��Top=�6m   �� 5;      -   5         ��Name$
 stFn��5<   &   $��2��6   $
��Left=�66   $��27��6Q   $��2��6]    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��140��6�   ��5;      ��  �� ElementName$ 
ProfStList��	 �� Path$"	 SelectedItem.fakultetenNomer�
 �� Mode$
 OneWay=�5<   �   �� 5=      -   5        $��4��5=      $��Намери��6*   $��1��6;   $��Right=�6K   $��27��6g   $	��Top=�6u   $��80��6�   6�   5>      5@      5A      5B      5C      