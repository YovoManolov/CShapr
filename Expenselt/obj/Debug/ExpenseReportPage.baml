   M S B A M L   `   `   `  ����D  @Expenselt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Expenselt	Expenselt  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      !    Expenselt.ExpenseReportPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Expenselt     5      6sys&clr-namespace:System;assembly=mscorlib     5	        N� Title$  ExpenseIt - View Expense��5       � 	Resources 5
         strTitle��%5   &	        ��5   
   Expense Report For:��6;   5      .��5      � $��0,0,0,10q�6   ��5   
   �� 5       �� ImageSource$/ )E:\CSharp\Expenselt\images\watermark.jpeg��6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��230 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Center=�5      $��Trebuchet MS)�5      $
��Bold"�5      $��20(�5      ���#0066cc$��1��5       $��0��6   $��	10,10,0,0q�6*   #��[  6=   � 5!   
   $��1��6   $��1��6    $
��Left=�6-   $
��Auto��6H   $��	10,10,0,0q�6V   $	��Top=�6j   $	��210��6�    5"      �� 5#      �� 5$       5&      �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    .+�5*      �� $��0��6   $��0��6&   $
��Name��63   $
��Bold"�6B   $��14(�6T   $��Center=�6b   
���   �6�   �� 5+      $��1��6   $��0��6&   $
��Bold"�6S   $��14(�6e   $��Center=�6s   
���   ���63   ��  �� XPath$ @Name��6�   �� 5,      $��0��6   $��1��6%   $
��Bold"�62   $��14(�6D   $��Center=�6R   
���   �.��6�   Department:6�   �� 5-      $��1��6   $��1��6%   $
��Bold"�6X   $��14(�6j   $��Center=�6x   
���   ���62   �� $ @Department��6�   5.      &   System.Windows.Controls.DataGrid  50   
   -   5        $��2��50      $��2��6       AutoGenerateColumns .     RowHeaderWidth$ 0Q�6r   ��60   �� $ Expense�� 51      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn	 �� 
TargetType
 �� Property �� Value��%.  '        7 �� 52      8   "	  6Q   .�53      �� 
 � �� �#4E87D463   �� 54      
 � ��$	 Top=�6@   6N   �� 55      
 � ��
 �����6I   �� 56      
 � ��$
 Bold"�63   6B   �� 57      
 � ��$ 13(�61   6>   �� 58      
 � ��$ 45��6/   6<   59      5:         Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6%      Header$ ExpenseType��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� $ @ExpenseType��  5=      $ * 6%   $ Amount��6/    6?   �� $ @ExpenseAmount��5?      � 5A   
   $��1��6   $��2��6    $
��Left=�6-   $
��Auto��6H   $��	10,10,0,0q�6V   $	��Top=�6j   $	��210��6�    5B      �� 5C      �� 5D       5F      �� 5G      $
��Auto �6    �� 5H      $
��Auto �6    5g      5h      5i      