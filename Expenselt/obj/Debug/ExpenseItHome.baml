   M S B A M L   `   `   `  ����D  @Expenselt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Expenselt	Expenselt  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
          Expenselt.ExpenseItHome   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Expenselt     5      6sys&clr-namespace:System;assembly=mscorlib     5
        N� Title$  ExpenseIt-Home��5	       � 	Resources 5         strTitle �� 
TargetType �� Property �� Value��%�   &	        '�� +     ��5   
   View Expense Report��6;   �� 5   
   " ��6   .�5      ��  � ��$ Center=�68   6I   �� 5       � ��$ Trebuchet MS)�61   6H   �� 5       � ��
 �����6A   5      5      .��5      � $��
10,0,10,10q�6    5   
     ExpenseDataSource � XPath��%�  &	       � 5      $ Expenses��68   .��5      ��<Expenses xmlns="">
                        <Person Name="Mike" Department="Legal">
                            <Expense ExpenseType="Lunch" ExpenseAmount="50" />
                            <Expense ExpenseType="Transport" ExpenseAmount="50" />
                        </Person>
                        <Person Name="Lisa" Department="Marketing">
                            <Expense ExpenseType="Magazine Subscription" ExpenseAmount="50" />
                            <Expense ExpenseType="New machine" ExpenseAmount="600" />
                            <Expense ExpenseType="Software" ExpenseAmount="500" />
                        </Person>
                        <Person Name="John" Department="Engeneering">
                            <Expense ExpenseType="Magazine Subscription" ExpenseAmount="50" />
                            <Expense ExpenseType="New machine" ExpenseAmount="600" />
                            <Expense ExpenseType="Software" ExpenseAmount="500" />
                        </Person>
                        <Person Name="Mary" Department="Finance">
                            <Expense ExpenseType="Dinner" ExpenseAmount="100" />
                        </Person>
                        <Person Name="Theo" Department="Marketing">
                            <Expense ExpenseType="Dinner" ExpenseAmount="100" />
                        </Person>
                        <Person Name="James" Department="Engeneering">
                            <Expense ExpenseType="Dinner" ExpenseAmount="100" />
                            <Expense ExpenseType="New machine" ExpenseAmount="1200" />
                        </Person>
                        <Person Name="David" Department="Marketing">
                            <Expense ExpenseType="Dinner" ExpenseAmount="120" />
                            <Expense ExpenseType="Magazine Subscription" ExpenseAmount="30" />
                        </Person>
                    </Expenses>        5:      5;      ��5>   
   �� 5?       �� ImageSource$/ )E:\CSharp\Expenselt\images\watermark.jpeg��6    � ColumnDefinitions 5A   
   �� 5B      �� 5C      $	��230 �6    � RowDefinitions 5E   
   �� 5F      $
��Auto �6   �� 5G      �� 5H      $
��Auto �6   �� 5I      .+�5L   
   �� $��Center=�6   $��Trebuchet MS)�5M      $
��Bold"�5N      $��20(�5O      ���#0066cc$��1��5Q      $��0��6    #��[  6-   6S   � 5T   
   $��1��6   $��2��6    $
��Left=�6-   $
��Auto��6H   $��	10,10,0,0q�6V   $	��Top=�6j   $	��210��6�    5U      �� 5V       5X      �� 5Y      $
��Auto �6    �� 5Z      $
��Auto �6    .+�5\      �� $��0��6   $��35��6#   	 �� Padding$	 5q�6/   ���#4E87D4._�5]      ��   listHeaderTextStyle#��[ 6   .��6F   Names6M   5^      �� 5_      -   5        $��peopleListBox��5_   0   $��1��6   $	��120��6#   $��Visible=�6y   ��5`      �� 
 �� Source#
 [  �� XPath$ Person����5a      �� 5b      .R�5c      �� 
���   ���63   �� $ @Name��6U   5d      5f      5g      � 5h   
   $��1��6   $
��Left=�6   $
��Auto��6:   $��	10,10,0,0q�6H   $��3��6[   $	��Top=�6h   $	��210��6�   .+�5i      �� -   5        $��98��5i   i   $��25��6t   $��Right=�5j      $��0,10,0,0q�6-   ��5i      ��  �� ElementName$ peopleListBox�� �� Path$# SelectedItem.Attributes[Name]�5j   V   �� 5k      -   5        $��Greeting��5k      $
��Left=�6(   $��25��6C   $��0,10,0,0q�6O   $	��Top=�6a   $	��107��6y   6�   5l      �� 5m   
   $��0��6   $��3��6    
���   �$��12(�5n      $
��Left=�6   $��Bottom=�69   $	��120��6T   $��30��6`   ��5m   -   �� $ LastChecked�5n   `   5o      5p      