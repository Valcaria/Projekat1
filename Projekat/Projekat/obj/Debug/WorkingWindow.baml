   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatTMPProjekatTMP  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       ProjekatTMP.WorkingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatTMP     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   $��589.5��5      $��996.5��6)   $��996.5��67   $	��550��6H   ��5	      �� 5
   
     �� EndPoint$  0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF142C9B��6    � Offset$ 0Q�6-   � 5      $ 	#FF1BBAD3��6   $ 1Q�6-   5      .��5      � -   5         �Name$ grdPozadina��5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrdTabela��5         SelectionMode$ Single=�6*   $��
10,50,9,85q�6A    J� IsHitTestVisible .    
IsReadOnly . 	   AutoGenerateColumns	 .  
   RowHeaderWidth$
 0Q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 34 61      FontSize$ 14Q�6S      MinWidth$ 33Q�6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *ID+6a     5      $ Prezime��6%   $ * 66   $ 14Q�6\    6@   �� *	PREZIME+6\     5      $	 Ime��6%   $ * 62   $ 14Q�6T    6<   �� *IME+6T     5      $ Maticni Broj��6%   $ * 6;   $ 14Q�6f    6E   �� *MATICNI_BROJ+6f     5      $ Mjesto Stanovanja��6%   $	 150 6@   $ 14Q�6r    6L   �� *MJESTO_STANOVANJA+6r     5      $ Broj Telefona��6%   $ * 6<   $ 14Q�6h    6F   �� *BROJ_TELEFONA+6h     5      $ Usluga��6%   $ * 65   $ 14Q�6Z    6?   �� *USLUGA+6Z     5      $ Datum Zaduzivanja��6%   $ * 6@   $ 14Q�6p    6J   �� *DATUM_ZADUZIVANJA+6p   5      �� 5   
   -   5         ��Name$ btnDodaj��5      $��Dodaj��6#   $
��Left=�63   $��	10,0,0,23q�6N   $��99��6a   $��18(�6l   $��42��6z   $��Bottom=�6�   $��1��6�   �� 5   
   -   5        $ btnArhiviraj��5      $��	Arhiviraj��6'   $
��Left=�6;   $��
135,0,0,23q�6V   $��99��6j   $��18(�6u   $��42��6�   $��Bottom=�6�   {�.  $��2��6�   �� 5   
   -   5        $ btnIzvjestaj��5      $��
Izvještaj��6'   $��	0,0,10,23q�6;   $��18(�6N   $��42��6\   $��Bottom=�6h   $��Right=�6�   $��98��6�   $��4��6�   �� 5   
   -   5        $ btnIzmijeni��5      $��Izmijeni��6&   $
��Left=�69   $��
261,0,0,23q�6T   $��99��6h   $��18(�6s   $��42��6�   $��Bottom=�6�   {�.  $��3��6�   �� 5    
   -   5        $ btnArhivirajSve��5       $��Arhiviraj Sve��6*   $
��Left=�6B   $��
387,0,0,23q�6]   $	��122��6q   $��18(�6}   $��42��6�   $��Bottom=�6�   $��2��6�   ]� 5!   
   -   5         ]�Name$ 	dockPanel��5!      $��35��6'   ��.  $	��Top=�6I   .+�5"      o� $	��Top=�6   $��35��6(   $	��Top=�64   
�������.@�5#      m� -	   5         m�Name$ arhiva��5#      $��_Arhiva��6+   $��35��6<   $
��Bold"�6H   $��14(�6Z   6h   m� 5$      -
   5        $ filter��5$      $��Filter��6+   $��35��6;   $
��Bold"�6G   $��14(�6Y   6g   5%      5&      5'      5(      