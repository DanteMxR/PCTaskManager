   M S B A M L   `   `   `  ���� H  DTaskManagerPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TaskManagerPCTaskManagerPC      TaskManagerPC.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:TaskManagerPC     -   $
��home��  � Title$  
MainWindow��$	��550��$	��800�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=� � WindowState$ Normal=�.����  �� CornerRadius$ 8��   PrimaryBackgroundColor#���   ._��  � ColumnDefinitions �� $
��Auto ��� .+��� $ 8 0 0 8��  SecundaryBackgroundColor#���  ._�� -    �Name$ gridMenu��$��60��	 � RowDefinitions	 �� $��60 ��� $��80 ��� $
��Auto ��� .+��� $��1��
 �� Orientation$
 
Horizontal=�$	��Top=�.+�F�   logo#���  $��16 0 0 0q� �� Stretch$
 Fill=�  PrimaryBlueColor#���  $��25��$��25��$
��Left=��� $��TaskManager��#���  $
��Bold"�$��20(�$��Center=�$
��Left=�$
��Left=�$��14 0 0 0q�d� -    d�Name$ btnMenu��$��Right=�$��0q�
������ $��Center=�  MenuIconStyle#��[ $��0 0 15 0q� � Triggers :�  :� RoutedEvent$ ToggleButton.Unchecked��.[��� .���� -    ��Name$ HideStackPanel��.��W�  �� 
TargetName$ gridMenu�� �� TargetProperty$ Width� g� 	BeginTime$ 0:0:0X� W� From$	 200X�	 W� To$ 60X� g� Duration$ 0:0:0.3D�:� $ ToggleButton.Checked��.[��� .���� -   $ ShowStackPanel��.��W� $ gridMenu��$ Width�$ 0:0:0X�$ 60X�$	 200X�$ 0:0:0.3D��� $��3��.+�	� -    	�Name$ rdHome�� d� 	IsChecked$
 TrueY�$
��Home��  MenuRadioButtonStyle#���    home
 � Tag# �   � Cursor$
 Hand��	� -   $ rdNotes��$
��Task��#���   	 notes# �  $
 Hand��	� -   $ rdDiscriptionPC��$��YourPC��#���    payment# �  $
 Hand��� $��1��	 �� $��60 ��� .+��� $��0��$��4��$��Right=�$	��Top=�$��0,5,10,0q�$��30��$
 
Horizontal=�$��RightToLeft=�.+��� -	    ��Name$ btnClose�� 	 IconButtonsStyle#��[	  	
 close#��� 
 $ IsCloseButton��$	��0,2q�$
 Hand���� -
   $ 
btnRestore��$	��5,0q�����  �� 
TargetType" �� �� BasedOn# [	 .���  �� Property � ��  maximize �� Value# �   �� Triggers ��   �� Binding  �� *WindowState+! �� ElementName$
! home��" �� Value" 	Maximized.a���  � ��  restore# �  �� -   $ btnMinimize��#��� 	   minimize#���  �� $	��720��$	��460��$��1��$��10q�._� � -   #  �Name$# PagesNavigation��$  � NavigationUIVisibility$$ Hidden=�