   M S B A M L   `   `   `  ���� C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatTMPProjekatTMP  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     ProjekatTMP.WorkingWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:ProjekatTMP     9System&clr-namespace:System;assembly=mscorlib     $��589.5��$��996.5��$��996.5��$	��550������   �� EndPoint$  0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF142C9B�� � Offset$ 0Q�� $ 	#FF1BBAD3��$ 1Q�.��� -    �Name$ grdPozadina��.+�&   System.Windows.Controls.DataGrid  -     Name$ datagrdTabela��$��
10,50,9,85q� J� IsHitTestVisible .    
IsReadOnly .    AutoGenerateColumns .  	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 
   RowHeaderWidth$
 0Q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width$ 34    FontSize$ 14Q�   MinWidth$ 33Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID+  $	 Ime��$ * $ 14Q� �� *IME+  $ Prezime��$ * $ 14Q� �� *	PREZIME+  $ Maticni Broj��$ * $ 14Q� �� *MATICNI_BROJ+  $ Mjesto Stanovanja��$	 150 $ 14Q� �� *MJESTO_STANOVANJA+  $ Broj Telefona��$ * $ 14Q� �� *BROJ_TELEFONA+  $ Usluga��$ * $ 14Q� �� *USLUGA+  $ Datum Zaduzivanja��$ * $ 14Q� �� *DATUM_ZADUZIVANJA+�� -    ��Name$ btnDodaj��$��Dodaj��$
��Left=�$��	10,0,0,23q�$��99��$��18(�$��42��$��Bottom=�$��1���� -   $ btnArhiviraj��$��	Arhiviraj��$
��Left=�$��
135,0,0,23q�$��99��$��18(�$��42��$��Bottom=�{�.  $��2���� -   $ btnIzvjestaj��$��
Izvještaj��$��	0,0,10,23q�$��18(�$��42��$��Bottom=�$��Right=�$��98��$��4���� -   $ btnIzmijeni��$��Izmijeni��$
��Left=�$��
261,0,0,23q�$��99��$��18(�$��42��$��Bottom=�{�.  $��3���� -   $ btnArhivirajSve��$��Arhiviraj Sve��$
��Left=�$��
387,0,0,23q�$	��122��$��18(�$��42��$��Bottom=�$��2��]� -    ]�Name$ 	dockPanel��$��35����.  $	��Top=�.+�o� $	��Top=�$��35��$	��Top=�
�������.@�m� -	    m�Name$ arhiva��$��_Arhiva��$��35��$
��Bold"�$��14(�m� -
   $ filter��$��Filter��$��35��$
��Bold"�$��14(�