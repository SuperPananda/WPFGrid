   M S B A M L   `   `   `  ����D  @Lab_3_wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Lab_3_wpf	Lab_3_wpf  5   	       Lab_3_wpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Lab_3_wpf     5   	   -   5          � Title$  Graphic��5   	   $	��350��6   $	��700��6&   .��5      ]� -   5        $��gridMain��5      $��Stretch=�6    ��.  $��Stretch=�6T   ���	#FF9DEE90.+�5   
   �� -   5        $
��Grid��5      $
��Left=�6   $	��226��68   $��	15,24,0,0q�6E   $	��Top=�6X   $	��331��6p   ���	#FFF7F6F66|   � 5   
   -   5        $��gridManager��5   &   $��Right=�6   $	��Top=�69   $	��214��6Q   $	��309��6]   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridPoints��5         AutoGenerateColumns .  $
��Left=�5      $	��126��62   $��	10,10,0,0q�5      $	��Top=�5      $	��188��6/      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 90 6;      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ X��6)      Width$ 1* 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *X+   ClipboardContentBinding 6K   �� *X+6q     5      $ Y��6)   $ 1* 6p    64   �� *Y+ 6J   �� *Y+6p   5      �� 5      -   5        	 ��Name$	 	combobox1��5      $
��Left=�6N   $��112,149,0,0q�6i   $	��Top=�6~   $��86��6�   �� 5      -   5        
 ��Name$
 
buttonSave��5      $
��Save��6)   $
��Left=�68   $��112,179,0,0q�6S   $	��Top=�6h   $��86��6�   5      �� 5      -   5        $
 
buttonLoad��5      $
��Load��6)   $
��Left=�68   $��112,204,0,0q�6S   $	��Top=�6h   $��86��6�   6�   �� 5      -	   5         ��Name$ labelPosCur��5      $$��Позиция курсора:��6)   $
��Left=�6D   $��
10,249,0,0q�6_   $	��Top=�6s   �� 5      -
   5        $ labelPosValue��5      $��(?;?)��6+   $
��Left=�6;   $��124,249,0,0q�6V   $	��Top=�6k   $��78��6�    J� RenderTransformOrigin$ 0.449,1.885&�6�   �� 5      -   5        $	��Del��5      $
��Left=�6#   $	��Top=�6>   $��86��6V   $��112,229,0,0q�6a   6v   �� 5      $��	Graphic: ��6   $
��Left=�6(   $	��Top=�6C   $��
51,149,0,0q�6[   $��36��6o   $��56��6{   5       �� 5!   
   -   5        $ label1��5!      $��Graphic��6    $��31��62   $��	0,278,0,0q�6>   $	��Top=�6Q   $	��120��6i   $ -2.436,0.433&�6u   5%      5&      