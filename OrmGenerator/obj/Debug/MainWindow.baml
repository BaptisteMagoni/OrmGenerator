   M S B A M L   `   `   `  ����G  COrmGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:OrmGeneratorOrmGenerator  5   	       OrmGenerator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:OrmGenerator     5   	     � Title$  
MainWindow��5   	   $	��650��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5	         Button_style �� 
TargetType �� Property �� Value��%�   &	        �� 5
   
   " ��6%   .�5      ��  � ��$ Center=�69   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�64   �� 5       � ��$ 90��6&   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��31* �6   �� 5      $
��120* �6    � RowDefinitions 5   
   �� 5      $	��59* �6   �� 5      $
��541* �6   .+�5   
   � $��2��6   $��0��6    ���	#FF6A6A6A5      � 5   
   $��1��6   ���	#FF6A6A6A5!      � 5"   
   $��1��6   $��1��6    5#      �� 5$      $	��10* �6#   �� 5%      $	��50* �6#    5'      �� 5(      $	��10* �6    �� 5)      $	��10* �6    �� 5*      $	��10* �6    �� 5+      $	��30* �6    .+�56      � $��0��6   $��0��6#   .+�57      �� -   5        $��Button_Depos��57   O   #��[  6   $��Dépos��6?   6c   58      � 5:      $��1��6   $��0��6#   .+�5;      �� -   5        $��TextBox_Depos��5;   m   $��1��6   $
��Left=�6*   $��20��6E   	 �� TextWrapping$
	 Wrap=�6Q   $�� ��6e   $��Center=�6�   $	��510��6�   5<      � 5>      $��0��6   $��1��6#   .+�5?      �� -   5        $��Button_Configuration��5?   W   #��[  6   $��Configuration��6?   6s   5@      � 5A      $��1��6   $��1��6#   .+�5B      �� -   5        $��ComboBox_Database��5B   6   $��Center=�6   $
��Left=�6O   $��25��6j   $	��400��6v   {�.  $��Visible=�6�   5C      � 5D      $��2��6   $��2��6'    5E      �� 5F      $	��10* �6$   �� 5G      $	��10* �6$    5I      �� 5J      $��2* �6'   �� 5K      $	��10* �6'   .+�5M      � $��0��6   $��1��6$   .+�5N      �� -   5        $��ComboBox_Tables��5N   L   {�.  $��Center=�61   $
��Left=�6c   $	��400��6~   $��Visible=�6�   5O      5P      � 5Q      -   5        
 �Name$
 
Grid_Table��5Q   H   $��2��6   $��3��6'   $y�Hidden=�64   .+�5R      &   System.Windows.Controls.DataGrid  -   5        $��Table��5R   7      AutoGenerateColumns .  $��Center=�6D   $��Center=�6a      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 5S         ColumnHeaderHeight$ 50Q�6-      	RowHeight$ 50Q�6E      RowHeaderWidth$	 115Q�6T   $��5q�6i   ���	#FF646464$��18(�5T   3   $��Segoe UI)�6A      CanUserReorderColumns .     CanUserResizeColumns .     CanUserSortColumns .     EnableRowVirtualization .     CanUserResizeRows .  |�.  {�.    
IsReadOnly . $��Center=�5V   P   $��Center=�6r      Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn   MinWidth$ 50Q�6K      Header$
 Name��6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   ��  �� Path$
 Name�6Y     5Y      $ 50Q�6K   $
 Type��6Y    6-   �� $
 Type�6Y     5Z      $ 50Q�6K   $
 Size��6Y    6-   �� $
 Size�6Y     5[      $ 50Q�6N   $ Catalog��6\    6-   �� $ Catalog�6\     5\      $ 50Q�6Q   $ 
IsNullable��6_    6-   �� $ 
IsNullable�6_   5^      5_      5`      5a      5b      