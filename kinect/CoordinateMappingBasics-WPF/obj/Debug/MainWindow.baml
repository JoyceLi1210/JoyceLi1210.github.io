   M S B A M L   `   `   `  ����  CoordinateMappingBasics-WPFA    ;Microsoft.Samples.Kinect.CoordinateMappingBasics.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Coordinate Mapping Basics��5   	   $��783.273��5   	   $��996.727��6    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value  ScreenshotButton �� 
TargetType �� Orientation ��Name	 �� TextAlignment
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%a  &	        &	 #     &	 F     '�� i     &	 �     7  7  �� 5	   
   $ 	#ff6e6e6e��62   �� 5
   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   �� 5   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
Horizontal=�6)   
������ .+�5   "   �� $ ScreenshotText��6,   #��z��6D   $
	 Left=�6e   $��Center=�6{   8��  $��15(�6�   � 5   "   $��9,0,0,0q�6'   .+�5   &   �� $
 ScreenshotNormal��6,   $!��Images\ScreenshotNormal.png��6F   $
��None=�6k   $��Center=�6z   �� 5   &   $
 ScreenshotHover��6,   $ ��Images\ScreenshotHover.png��6E   $
��None=�6i   $��Center=�6x   $y�	Collapsed=�6�   5   #   5      5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ ScreenshotNormal��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5   "   $ ScreenshotHover��6O    � y�$ Visible=�6?   6O   �� 5    "   8  $ ScreenshotText��6h    � ��5!      5#      5%      5&      5'      .��5(      � $��	10 0 10 0q�6    � ColumnDefinitions 5)   
   �� 5*      $	��46* �6   �� 5+      $
��213* �6   �� 5,      $	��78* �6    � RowDefinitions 5.   
   �� 5/      $
��Auto �6   �� 50      $
��Auto �6   �� 51      $
��Auto �6   $	��556��6*   �� 52      $
��Auto �6   $��67��6*   .+�55   
   �� $��0��6   $��Images\Logo.png��6   $
��Left=�66   $
��Fill=�6Q   $��81��6`   $��	0,14,0,10q�6k   �� 56   
   $��0��6   $��0,0,-1,0q�6!   $��Right=�63   $��Bottom=�6O   #��[  6j   $��Segoe UI)�6�   $��18(�6�   $��2��6�   $��24��6�   $	��217��6�   Coordinate Mapping Basics6�   �� 57   
   $��0��6   $��Images\Status.png��6   $
��None=�68   $��Center=�6G   $��313,0,249,5q�6d   $��1��6y   $��50��6�   (� 59   
   $��2��6   $��3��6   $��0q�63   $	��520��6>   $	��800��6K   .��5:      � -   5        $��CompositeImage��5:      $	��520��6)   $	��800��66   .+�5;      �� -   5        $
 
Background��5;      $
��Fill=�6,   �� 5H      $��UniformToFill=�67   ��6   �� *ImageSource+67   �� 5Q      -   5         ��Name$ Tools��5Q      .+�5S      � -   5        $��ClothesImage��5S      .+�5T      �� -   5        $
 Clothes��5T       $	��300��61   $	��300��6>   $��247,24,-247,-24q�6J   5U      � 5W      -   5        $��	ToolImage��5W      .+�5X      �� -   5        $
 Tool_��5X       $	��100��6/   $	��100��6<   $��247,24,-247,-24q�6H   5Y      5Z      5]      5^      (� 5e   
   $��2��6   $��3��6   $	��200��63   $��
0,282,0,74q�6@   .��5f      � -	   5        $��ForegroundImage��5f      .+�5g      �� -
   5        $
 
Foreground��5g      5h      5i      �� 5m   
   -   5        $��	statusBar��5m   ?   $��3��6   $��Stretch=�6!   $��Bottom=�6P   
�������#��[  6~   $��3��6�   $��6��6�   .@�5n      �� ��6   �� *
StatusText+5o      � 5q   
   $��1��6   $��3��6   $
��0,15q�60   .+�5r      �� $��國家:��6   $
��Left=�6"   $��22,0,0,0q�6=   $��1��6O   $	��Top=�6\   $��24(�6t    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��40��6�   $��64��6�   �� 5s      -   5         ��Name$ ComboBoxCountry��5s      $
��Left=�60   $��	101,0,0,0q�6K   $��1��6^   $	��Top=�6k   $	��153��6�   $��40��6�   $��20(�6�   $��2��6�   .@�5t      �� .��6   Japan6&   �� 5u      .��6   Netherlands6,   �� 5v       �� 
IsSelected . .��61   New Zealand6>   5w      �� 5x      $��前景:��6   $
��Left=�6"   $��	279,0,0,0q�6=   $	��Top=�6P   $��24(�6h   $��40��6v   �� 5y      -   5        $ ComboBoxForeground��5y      $
��Left=�63   $��	345,0,0,0q�6N   $	��Top=�6a   $	��120��6y   $��24(�6�   $��40��6�   .@�5z      �� .��6   神社6#   �� 5{      .��6   風車6#   �� 5|      .��6   	羊咩咩6$   �� 5}       . .��61   No65   5~      �� 5      $��道具:��6   $
��Left=�6"   $��	508,0,0,0q�6=   $	��Top=�6P   $��24(�6h   $��40��6v   �� 5�      -   5        $ ComboBoxTool��5�      $
��Left=�6-   $��	573,0,0,0q�6H   $	��Top=�6[   $	��141��6s   $��24(�6   $��40��6�   .@�5�      �� .��6   扇子6#   �� 5�      .��6   	荷蘭旗6$   �� 5�      .��6    牛奶6$   �� 5�       . .��61   No65   5�      �� 5�      $��衣服:��6   $
��Left=�6"   $��	738,0,0,0q�6=   $	��Top=�6P   $��24(�6h   $��40��6v   �� 5�      -   5        $ ComboBoxClothes��5�      $
��Left=�60   $��	803,0,0,0q�6K   $	��Top=�6^   $	��131��6v   $��24(�6�   $��40��6�   .@�5�      �� .��6   和服6#   �� 5�      .��6   	肌肉裝6$   �� 5�      .��6   草裙6#   �� 5�       . .��61   No65   5�      5�      �� 5�   
   -   5         ��Name$ X��5�      $��Label��6   $
��Left=�6+   $��
110,10,0,0q�6F   $	��Top=�6Z   $��2��6r   $��38��6�   $	��136��6�   $��18(�6�   �� 5�   
   -   5        $ Y��5�      $��Label��6   $
��Left=�6+   $��
139,10,0,0q�6F   $	��Top=�6Z   $��38��6r   $	��136��6~   $��1��6�   $��18(�6�   5�      5�      