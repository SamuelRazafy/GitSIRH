   M S B A M L   `   `   `  ����N  JInterface_bienvenue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Interface_bienvenueInterface_bienvenue  5   	   #    Interface_bienvenue.essaiConn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Interface_bienvenue     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.2.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aOmaterialDesignMahApps1http://materialdesigninxaml.net/winfx/xaml/themes   5   	     � Title$   ��5
   	   $	��645��6   $	��875��6     � WindowStartupLocation$ CenterScreen=�6,   $��Sego UI)�6Q    � WindowStyle$ 
ToolWindow=�6f   .��5      � $��	0,0,0,-16q�6   .+�5   
   �� $
��Left=�6   $	��641��60   $��	0,-14,0,0q�6=   $	��Top=�6P   $	��422��6h   ���	#FF003F9A.+�5      �� $	��100��6   �� 5      $	��125��6   $	��198��6&   $��Center=�62   ��5      �� 5       �� ImageSource$ Logo de GO.png��6!   5      �� 5      $5��/  SYSTEME D'INFORMATION
DES RESSOURCES HUMAINES��6   
�������$
��Bold"�6e   $��22(�6w   $��20,20,20,20q�6�   $	��109��6�   $	��358��6�   $��Center=�6�   $��	0,125,0,0q�6�   5      �� 5   
   -   5         ��Name$ textMail��5      $
��Left=�6%   $��43��6@   $��522,129,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��318��6�    %  !MaterialDesignFloatingHintTextBox#��[  6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Saisir e-mail��5         FloatingOffset$ 0, -20&�5      ���#c5c8cc$��	0 0 0 1.5q�5      �� 5   
   -   5         ��Name$ butConnection��5      $��SE CONNECTER��6(   $
��Left=�6?   $��580,345,0,0q�6Z   $	��Top=�6o   $	��158��6�   $��14(�6�   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 22��6�   ��5      �� 5      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$
 Blue��6#   � 5      $ 	#FF003F9A��6#    � Offset$ 1Q�65   5       5#      �� 5$   
   -   5        $ 	butGoogle��5$      $�� ��6$   $
��Left=�6/   $��596,484,0,0q�6J   $	��Top=�6_   $��40��6w   $��14(�6�   $	 22��6�   $��43��6�   ��6�   Z� ��5%      �� 5&      $ /google-logo (1).png��6   5(      �� 5)   
   -   5        $ butFace��5)      $�� ��6"   $
��Left=�6-   $��690,484,0,0q�6H   $	��Top=�6]   $��40��6u   $��14(�6�    J� RenderTransformOrigin$ 
0.53,1.219&�6�   $	 22��6�   $��43��6�   ��6	  Z� ��5*      �� 5+      $ /facebook-new.png��6   5-      �� 5.   
   $��SE CONNECTER��6   $
��Left=�6'   $��
572,30,0,0q�6B   $	��Top=�6V   $��22(�6n   $
��Bold"�6|   �� 5/   
   -   5        $ butInsc��5/      $��S'INSCRIRE ��6"   $
��Left=�68   $��580,404,0,0q�6S   $	��Top=�6h   $	��158��6�   
�������$��32��6�   $	 22��6�   ��50      �� 51      $
 0.5,1&�6&   $ 0.5,0&�67   .��52      � $
 Blue��6#   � 53      $ 	#FF003F9A��6#   $ 1Q�65   54      56      �� 57   
   -   5        $ 
butAnnuler��57      $��Annuler��6%   $
��Left=�67   $��933,533,0,0q�6R   $	��Top=�6g   $��99��6   $��42��6�   ���	#FFEBEBEB
�������$	 22��6�   
���   � J� Opacity$	 0.6Q�6"  G� 58   
   -   5         G�Name$ textMdp��58      $
��Left=�6'   $��521,235,0,0q�6B   $	��Top=�6W   $	��317��6o   $ Saisir mot de passe��6�   ��6{   Z� 6�   �� 59   
   $
��Left=�6   $��25��60   $��464,235,0,0q�6<   $	��Top=�6Q   $��30��6i   ��5:      �� 5;      $ lock_26px.png��6   5=      �� 5>   
   $
��Left=�6   $��25��60   $��464,147,0,0q�6<   $	��Top=�6Q   $��26��6i   $ -8.573,0.486&�6t   ��5?      �� 5@      $ mail_50px.png��6   5B      5C      5D      