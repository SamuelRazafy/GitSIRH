   M S B A M L   `   `   `  ����N  JInterface_bienvenue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Interface_bienvenueInterface_bienvenue  5   	   3    -Interface_bienvenue.InterfaceSimpleUilisateur   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Interface_bienvenue     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.2.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aImaterialDesign11http://materialdesigninxaml.net/winfx/xaml/themes   5   	     � Title$  InterfaceSimpleUilisateur��5	   	   $	��800��6+   $
��1293��68    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�6     � WindowStartupLocation$ CenterScreen=�63   .��5      �  J� RenderTransformOrigin$ 0.518,0.041&�6   $��10,0,0,0q�6/    � ColumnDefinitions 5   
   �� 5      $
��270* �6   �� 5      $��1042* �6   �� 5      $��0* �6   .+�5   
   � -   5         �Name$ 	sidePanel��5      ���#003F9A$ 0.504,0.534&�67   $��2��6[   $��-21,0,1013,0q�6o   .+�5      �� -   5         ��Name$ 	logoPanel��5      $��	0,0,0,702q�6,   �� 5      $��	0,191,0,0q�6   .+�5      �� -   5         ��Name$ btTableaudeBordSU��5      $��Segoe UI)�64   $��14(�6J   $��49��6X   $��0,8,0,0q�6d   
�������
������ 
������ $
��Left=�6�   $	��288��6�   .��5      �� 	 �� Orientation$	 
Horizontal=�6!   $	��199��6:   .+�5      �� $��icones/home.png��6    $��35��69   $��Center=�6E   $��35��6`   $��10,0,0,0q�6k   $
��Left=�6}   �� 5      $��15 0 0 0q�6$   $��ACCUEIL��66   $��14(�6E   $��Center=�6S   $	��149��6n   5      5      �� 5!      -   5        $ btGestionCongeSU��5!      $��Segoe UI)�63   $��16(�6I   $��49��6W   
�������
������ 
������ $��0,8,0,0q�6�   .��5#      �� $	 
Horizontal=�6!   $	��221��6:   .+�5$      �� $��icones/conge.png��6    $��31��6:   $��Center=�6F   $��50��6a   $��20,0,0,0q�6l   $
��Left=�6~   �� 5%      $��0,0,0,0q�6$   $��STATUT CONGE��65   $��14(�6I   $��Center=�6W   $��Segoe UI)�6r   5&      5(      �� 5)      -   5        $ btGestionProjetsSU��5)      $��Century Gothic)�65   $��14(�6Q   $��49��6_   $��0,8,0,0q�6k   
�������
������ 
������ $	��288��6�   .��5+      �� $	 
Horizontal=�6!   $	��205��6:   .+�5,      �� $��icones/projets.png��6    $��39��6<   $��Center=�6H   $��54��6c   $��0,0,0,0q�6n   �� 5-      $��5,0,0,0q�6$   $��PROJET��65   $��14(�6C   $��Center=�6Q   $��Segoe UI)�6l   5.      50      �� 51      -   5        $ btDemandeInscriptionSU��51      $��Century Gothic)�69   $��14(�6U   $��49��6c   $��0,8,0,0q�6o   
�������
������ 
������ $	��286��6�   .��53      �� $	 
Horizontal=�6!   $	��215��6:   .+�54      �� $��icones/signing.png��6    $��48��6<   $��Center=�6H   $��35��6c   $��15,0,0,0q�6n   �� 55      $��	10,10,0,0q�6$   $��STATUT INSCRIPTION��67   $��14(�6Q   $��Center=�6_   $	��171��6z   $��Segoe UI)�6�   56      58      �� 5:      -   5        $ btPaieSU��5:      $��Century Gothic)�6,   $��14(�6H   $��49��6V   
�������
������ 
������ $��0,8,0,0q�6�   .��5<      �� $	 
Horizontal=�6!   $	��196��6:   .+�5=      �� $��icones/paye.png��6    $��36��69   $��Center=�6E   $��46��6`   $��0,0,0,0q�6k   $ 	0.609,0.5&�6|   �� 5>      $��5,0,0,0q�6$   $
��PAIE��65   $��14(�6A   $��Center=�6O   $��Segoe UI)�6j   5?      5A      �� 5C      -   5        $ 
btOutilsSU��5C      $��Sego UI)�6.   $��14(�6C   $��48��6Q   
�������
������ 
������ $��0,8,0,0q�6�   .��5E      �� $	 
Horizontal=�6!   $	��196��6:   .+�5F      �� $��icones/outils.png��6    $��36��6;   $��Center=�6G   $��46��6b   $��0,0,0,0q�6m   $ 	0.609,0.5&�6~   �� 5G      $��5,0,0,0q�6$   $��	PARAMETRE��65   $��14(�6F   $��Center=�6T   $��Segoe UI)�6o   5H      5J      5N      �� 5O      -	   5        
 ��Name$

 logo��5O      $	��100��6"   $	��100��6/   $��82,46,85,654q�6;   $#��/MicrosoftTeams-image (3).png��6Q   5P      �� 5T   
   -
   5        $ Accueil��5T      $��3,10,0,0q�6&   $��1��68   .+�5U      �� -   5        $ profil��5U      $��36��6&   
���   �
�������$��0,0,0,0q�6o   $	��177��6�   $��
800,30,0,0q�6�   ��6Y   Z� 6�   �� 5V      -   5         ��Name$ 	Menu_Page��5V      $
��Wrap=�6+   $��BIENVENUE SUR GO��6?   $��54��6W   $	��267��6c   $��24(�6o   ���	#FF003F9A$
��Left=�6�   $��350,40,0,50q�6�   $
��Bold"�6�   #  MaterialDesignThemes.Wpf.Card  5W      $	��140��6#   $	��170��60   .��5X      �� $��0,0,0,86q�6   ���#c0c0c0.+�5Y      �� 
����  �$
��Bold"�62   $��16(�6D   $��Center=�6R   $��0,20,0,0q�6o   A PROPOS DE GO5[      5\      5^      5_      �� 5`   
   -   5        $ close��5`      $��36��6!   
���   �
�������$��0,0,0,0q�6j   $
��Left=�6�   $	��Top=�6�   $	��177��6�   $��
36,683,0,0q�6�   ��6T   Z� ��5a      �� 5b      $	 
Horizontal=�6   $��0,0,20,0q�66   .+�5c      �� $��Center=�6   $��/logout.png��69   $��30��6N   $��30��6Y   $��0,0,20,0q�6e   6y   �� 5d      
�������$��LOGOUT��64   $��66��6B   $��19��6M   6[   5e      5g      �� 5k   
   -   5        $ panelRecherche��5k      $	 
Horizontal=�6-   $��5,10,91,717q�6F   $��1��6[   .+�5l      �� -   5         ��Name$ TextboxRecherche��5l       �� TextWrapping$
 Wrap=�60   $��14(�6E   $	��236��6S   $��40��6_   $��25,0,0,0q�6k   �� 5m      -   5        $ btRecherche��5m      ���#003F9A$��58��6?   $��34��6K   .��5n      �� $��icones/recherche.png��6   $��20��66   $
��Left=�6B   5o      5q      5u      5w      