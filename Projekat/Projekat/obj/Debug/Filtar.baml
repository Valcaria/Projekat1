   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatTMPProjekatTMP  5   	       ProjekatTMP.Filtar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatTMP     5   	   -   5          � Title$  Filter��5   	   $	��409��6   $��384.334��6%   $��384.334��65   $��384.334��6H   $	��409��6[   $	��461��6k    � 
ResizeMode$ CanMinimize=�6{   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF142C9B��6    � Offset$ 0Q�6-   � 5      $ 	#FF1BBAD3��6   $ 1Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ chbMjestoStanovanja��5      $��Mjesto Stanovanja��60   $
��Left=�6L   $��	12,53,0,0q�6g   $	��Top=�6z   $��14(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ chbDom��5      $	��Dom��6#   $
��Left=�61   $��	12,89,0,0q�6L   $	��Top=�6_   $��14(�6w   $
��Bold"�6�   6�   �� 5   
   -   5        $ chbPaviljon��5      $��Paviljon��6(   $
��Left=�6;   $��
12,120,0,0q�6V   $	��Top=�6j   $��14(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ 	chbUsluga��5      $��Usluga��6&   $
��Left=�67   $��
12,153,0,0q�6R   $	��Top=�6f   $��14(�6~   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ txtMjestoStanovanja��5      $
��Left=�6/   $��23��6J   $��
197,48,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��169��6�   {�.  6�   �� 5   
   -   5        $ chbFakultet��5      $��Fakultet��6(   $
��Left=�6;   $��
12,229,0,0q�6V   $	��Top=�6j   $��14(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ chbGodinaUpotrebe��5      $��Godina upotrebe��6.   $
��Left=�6H   $��
12,193,0,0q�6c   $	��Top=�6w   $��14(�6�   $
��Bold"�6�   6�   �� 5   
   -	   5        $ chbGodinaFakulteta��5      $��Godina fakulteta��6/   $
��Left=�6J   $��
10,263,0,0q�6e   $	��Top=�6y   $��14(�6�   $
��Bold"�6�   6�   �� 5   
   -
   5        $ txtGodinaUpotrebe��5      $
��Left=�6-   $��23��6H   $��181,193,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��185��6�   {�.  6�   �� 5   
   -   5        	 ��Name$	 cmbFakultet��5      $��181,229,0,0q�6(   $	��Top=�6=   $��23��6U   $��3��6a   $
��Left=�6n   $	��185��6�   {�.  .@�5      �� $	��ETF��6   $��14(�6*   �� 5      $	��MAF��6   $��14(�6*   �� 5      $	��MAK��6   $��14(�6*   �� 5      $	��POF��6   $��14(�6*   5      �� 5   
   -   5        $ txtGodinaFakulteta��5      $
��Left=�6.   $��23��6I   $��181,263,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $	��185��6�   
 J� RenderTransformOrigin$
 0.569,4.304&�6�   {�.  6�   �� 5    
   -   5         ��Name$ btnOK��5       $��OK��6    $
��Left=�6-   $��153,331,0,0q�6H   $	��Top=�6]   $��75��6u   6�   � 5!   
   -   5         �Name$
 wrp1��5!      $
��Left=�6"   $��15��6=   $��
128,89,0,0q�6I   $	��Top=�6]   $	��212��6u   $
 0.542,4.667&�6�   .+�5"      	� -   5         	�Name$ rbtnDom1��5"      $��Dom 1��6,   $
��Left=�6<   $	��Top=�6W   {�.  6o   	� 5#      -   5        $ rbtnDom2��5#      $��Dom 2��6,   $
��Left=�6<   $	��Top=�6W   {�.  $��76,0,0,0q�6�   5$      � 5%   
   -   5        $
 wrp2��5%      $
��Left=�6"   $��15��6=   $��128,122,0,0q�6I   $	��Top=�6^   $	��238��6v   $
 0.542,4.667&�6�   .+�5&      	� -   5        $ rbtnPaviljonM��5&      $��Muski paviljon��61   $
��Left=�6J   $	��Top=�6e   {�.  6}   	� 5'      -   5        $ rbtnPaviljonZ��5'      $��Zenski paviljon��61   $
��Left=�6K   $	��Top=�6f   {�.  $��36,0,0,0q�6�   5(      � 5)   
   -   5        $
 wrp3��5)      $
��Left=�6"   $��15��6=   $��128,155,0,0q�6I   $	��Top=�6^   $	��212��6v   $
 0.542,4.667&�6�   .+�5*      	� -   5        $ rbtnHranaiSoba��5*      $��Hrana i soba��62   $
��Left=�6I   $	��Top=�6d   {�.  6|   	� 5+      -   5        $ 	rbtnHrana��5+      $��Hrana��6-   $
��Left=�6=   $	��Top=�6X   {�.  $��47,0,0,0q�6�   5,      5.      5/      