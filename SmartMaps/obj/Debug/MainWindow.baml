   M S B A M L   `   `   `  ����I  ESmartMaps.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:SmartMaps.Data;assembly=SmartMaps.DataSmartMaps.Data  5   	    	SmartMaps   SmartMaps.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bc4clr-namespace:SmartMaps.Data;assembly=SmartMaps.Data     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��600��6)    � 	Resources 5         SmartMaps.Data.MapProject   myDataSource��%   &	          5   
   6   5       � DataContext 5	      �� 5
   
    �� Source# [  6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   5      �� 5       � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      .+�5   
   o� $��2��6   .@�5      m� -   5         m�Name$ main_mi��5      $��Datei��6(   .@�5      m� $
��_Neu��6   m� 5      $��_Import��6   .@�5      m� -   5        $��Referenzbild��5      65   m� 5      $��
Sounddatei��6   5      m� 5      $��_Export��6   .@�5      m� -   5        $��Schnittmuster��5      66   m� 5      $��TipToi-Programm��6   m� 5       $��TipToi-Code��6   5!      �� 5"      m� 5#      $��_Schließen��6   5$      5%      �� 5&   
   $��1��6   .@�5'      �� $��	Werkzeuge��6   .��5(      �  5)      �� 5*      �� 5+      �� 5,      .+�5.      �� -   5        $��Gebäudeteil��5.      63   �� 5/      -   5        $��1��5/      $��Straße��6*   6;   �� 50      -   5        $��2��50      $��Gehweg��6*   6;   51      52      �� 53      $��Objekte��6   .��54      R� .@�55      Q� $��Gebäude��6#   ��64   ��  �� Path$ Buildingparts�56      Q� 57      $��Straßen��6#   ��64   �� $ Wayparts�58      Q� 59      $��Gehwege��6#   66   5:      5;      5<      �� 5=   
   -   5         ��Name$ main_canvas��5=      $��1��6&   $��1��66   $��Stretch=�6b   $��Stretch=�6�   .+�5?      �� -   5        	 ��Name$	 resource_img��5?      $��Resources/KarteHTW.png��6*   $��Stretch=�6`   $��Stretch=�6~   �� 5A      	
 �� X1$	
 175��6   	 �� X2$	 175��6   	 �� Y1$ 0��6%   	 �� Y2$	 449��6,   
���  ��
���  ��6O   �� 5B      -	   5        $��23��5B      $��74��6$    J� RenderTransformOrigin$ 	0.52,0.47&�6/    �� Left$ 74��6Q   
������ 
 �� Top$ 10��6u   
����  �6�   �� 5C      $
��Z_P1��6   $ 74��6#   $ 10��64   $��23��6D   $��74��6P   6]   �� 5D      -
   5        $	��120��5D      $��36��6%   $ 91��60   $ 33��6A   
����  �
������ 6�   �� 5E      $
��Z_P2��6   $ 0.533,0.462&�6#   $ 91��6G   $	 127��6X   5F      5G      5H      