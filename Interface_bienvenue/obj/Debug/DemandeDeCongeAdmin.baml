   M S B A M L   `   `   `  ����N  JInterface_bienvenue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Interface_bienvenueInterface_bienvenue  5   	   -    'Interface_bienvenue.DemandeDeCongeAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.2.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aImaterialDesign11http://materialdesigninxaml.net/winfx/xaml/themes   5   
   HmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      /local!clr-namespace:Interface_bienvenue   5   	     � Title$   ��5
   	   $	��900��6   $	��950��6     � 
ResizeMode$ NoResize=�6,    � WindowStyle$ 
ToolWindow=�6B   $��Center=�6[   $	��Top=�6x   .��5      � $��	0,0,0,-40q�6   $��Center=�6    � ColumnDefinitions 5   
   �� 5      $
��109* �6   �� 5      $
��841* �6   .+�5   
   � -   5         �Name$ gridPage��5      $
��Left=�6!   $��0,0,0,10q�6<   $��2��6N   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��
10,45,10,5q�62   $��0��6F   $	��Top=�6S   .+�5      �� -   5         ��Name$ textBlockFicheDePaie��5      $
��Wrap=�6:   $��FICHE DE PAIE ��6N   $	��266��6d   $��20(�6p   $
��Bold"�6~   $��Center=�6�    �� TextAlignment$ Center=�6�   $��250,30,50,0q�6�   $��62��6�   �� 5      -   5         ��Name$ textBlockNumero��5      	 �� TextWrapping$
	 Wrap=�63   $��50��6G   $	��N°��6R   $��18(�6\   $
��Bold"�6j   $��Center=�6|   $��0,15,0,0q�6�   $��30��6�   �� 5      -   5        $ TextBoxNumero��5      $
	 Wrap=�61   $��90��6E   $��23��6P   $��	10,22,0,0q�6\   $��16(�6o   $
��Bold"�6}   5      �� 5      $��36,148,10,0q�6   .+�5      � $	��607��6   $��0,0,0,0q�6$   $
��1086��65    5      �� 5      $
��189* �6+   �� 5      $��8* �6+   �� 5       $��8* �6+   �� 5!      $	��15* �6+   .+�5#      �� -   5        $ textBlocMatricule��5#      $
	 Wrap=�69   $��	Matricule��6M   $��14(�6^   $
��Bold"�6l   $��15,51,829,529q�6~   
 J� RenderTransformOrigin$
 0.575,0.521&�6�   �� 5$      -   5        $ TextBoxMatricule��5$      $
	 Wrap=�68   $��146,51,474,529q�6L   $��14(�6d   $
��Bold"�6r   �� 5%      -   5        $ textBlocNom��5%      $
	 Wrap=�63   $	��Nom��6G   $��14(�6R   $
��Bold"�6`   $��531,51,333,529q�6r   �� 5&      -   5        $ 
TextBoxNom��5&      $
	 Wrap=�62   $��624,51,40,529q�6F   $��14(�6^   $
��Bold"�6l   $��27��6~   �� 5'      -	   5        $ textBlocSalaireBase��5'      $
	 Wrap=�6;   $��Salaire Base��6O   $��14(�6c   $
��Bold"�6q   $��15,118,829,456q�6�   �� 5(      -
   5        $ textBlocIndemnite1��5(      $
	 Wrap=�6:   $��
Indemnite1��6N   $��14(�6`   $��Normal"�6n   $��15,186,829,394q�6�   �� 5)      -   5        $ TextBoxSalaireBase��5)      $
	 Wrap=�6:   $��148,118,416,0q�6N   $��14(�6f   $
��Bold"�6t   $	��Top=�6�   $��27��6�   �� 5*      -   5        $ TextBoxIndemnite1��5*      $
	 Wrap=�69   $��148,186,410,393q�6M   $��14(�6f   $
��Bold"�6t   $��27��6�   �� 5+      -   5        $ textBlocIndemnite2��5+      $
	 Wrap=�6:   $��
Indemnite2��6N   $��14(�6`   $��Normal"�6n   $��13,248,829,334q�6�   �� 5,      -   5        $ TextBoxIndemnite2��5,      $
	 Wrap=�69   $��148,248,412,333q�6M   $��14(�6f   $
��Bold"�6t   $��27��6�   �� 5-      -   5        $ textBlocSalaireBrut��5-      $
	 Wrap=�6;   $��Salaire Brut��6O   $��14(�6c   $
��Bold"�6q   $��15,319,829,262q�6�   �� 5.      -   5        $ TextBoxSalaireBrut��5.      $
	 Wrap=�6:   $��146,304,414,264q�6N   $��14(�6g   $
��Bold"�6u   $��27��6�   �� 5/      -   5        $ textBlockImpot��5/      $
	 Wrap=�66   $��Impôt��6J   $��14(�6W   $
��Bold"�6e   $��15,390,829,187q�6w   �� 50      -   5        $ TextBoxImpot��50      $
	 Wrap=�64   $��148,390,412,188q�6H   $��14(�6a   $
��Bold"�6o   $��27��6�   �� 51      -   5        $ textBlocSalaireNet��51      $
	 Wrap=�6:   $��Salaire Net��6N   $��14(�6a   $
��Bold"�6o   $��15,466,829,110q�6�   �� 52      -   5        $ TextBoxSalaireSalaireNet��52      $
	 Wrap=�6@   $��148,466,412,112q�6T   $��14(�6m   $
��Bold"�6{   $��27��6�   55      58      � 59      -   5        $ gridImprimer��59      $��
0,700,0,50q�6)   $
��Left=�6=   $	��940��6X   .+�5:      �� -   5         ��Name$ 	LabelDate��5:      $��Date : ��6+   $	��131��6=   $��14(�6I   $
��Left=�6W   $��	102,5,0,0q�6r   $��48��6�   $	��Top=�6�   �� 5;      -   5        $ LabelSignature��5;      $��	Signature��60   $��14(�6D   $��102,78,207,22q�6R   $��48��6i   �� 5<      -   5         ��Name$ BtnImprimer��5<      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 14��6.   $��IMPRIMER��6\   $
��Left=�6o   $��
700,80,0,0q�6�   $	��Top=�6�   $��58��6�   $	��163��6�   $��24(�6�   
���������5=      �� 5>       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5?      �  � Color$
 Blue��6+   � 5@      $
 Blue��6+    � Offset$ 1Q�68   5A      5C      5D      �� 5E      $
��Left=�6   $	��113��6/   $��	54,38,0,0q�6<   $	��Top=�6O   $	��135��6g   $��/logoFicheDePaie.png��6s   5F      5I      5J      