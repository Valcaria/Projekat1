   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	       ProjekatTMP.SearchWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   $	��526��5      $	��470��6'     � 
ResizeMode$  CanMinimize=�63   $	��470��6L   $	��526��6[   $	��526��6k   $	��470��6{   ��5      �� 5	   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5
      �  � Color$ 	#FF142C9B��6    � Offset$ 0Q�6-   � 5      $ 	#FF1BBAD3��6   $ 1Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ txtPretraga��5      $��31��6'   $��10,42,157,0q�63    �� TextWrapping$
 Wrap=�6H   $	��Top=�6\   $��14(�6t   $��0��6�   �� 5   
   -   5         ��Name$ btnPretraga��5      $��Pretraga��6&   $��	0,42,76,0q�69   $	��Top=�6L   $��31��6d   $��Right=�6�   $��76��6�   ]� 5   
   -   5         ]�Name$ 	dockPanel��5      $��35��6'   ��.  $	��Top=�6I   .+�5      o� $	��Top=�6   $��35��6(   $	��Top=�64   
�������.@�5      m� -   5        	 m�Name$	 filter��5      $��Filter��6+   $��35��6;   $
��Bold"�6G   $��14(�6Y   6g   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dtgPretraga��5      $	��351��6(   $��
10,88,12,0q�65   $	��Top=�6I      SelectionMode$ Single=�6a      SelectionUnit$ FullRow=�6x      AutoGenerateColumns .   J� IsHitTestVisible .    
IsReadOnly .    RowHeaderWidth$ 0Q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 62      FontSize$ 14Q�6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *IME+6V     5      $ Prezime��6%   $	 100 66   $ 14Q�6^    6B   �� *	PREZIME+6^     5      $ Maticni Broj��6%   $ * 6;   $ 14Q�6f    6E   �� *MATICNI_BROJ+6f   5      �� 5   
   -   5        $ btnDodaj��5      $��Dodaj��6#   $��	0,0,12,10q�63   $��Right=�6]   $��75��6y   $��31��6�   $��Bottom=�6�   5      5      