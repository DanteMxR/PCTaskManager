   M S B A M L   `   `   `  ���� H  DTaskManagerPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TaskManagerPC.PagesTaskManagerPC.Pages  #    TaskManagerPC.Pages.NotesPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:TaskManagerPC.Pages       N� Title$  	NotesPage��.����  �� CornerRadius$ 5��   SecundaryBackgroundColor#���   ._��  � ColumnDefinitions �� $	��381 ��� $	��135 ��� $��9 ��� $��35 �.+��� -    ��Name$ ProcessesListView��
��� ���$	��380��$	��500��$��34,13,26,57q�$��4�����	#FF0C0C0C$��11(�$��Normal"�$��Segoe UI)�z�V� .~��� ��  �� AngleY$ -0.152Q��� T�  T� Y$ -0.664Q� �� View �� .P��� $��Имя�� �� Width$	 200�� �� CellTemplate �� .R��� 	 �� TextAlignment$	 Center=�$��20(�$
��Auto��$��Segoe UI)����� *ProcessName+�� $��ID��$	 100�� �� .R��� $	 Center=�$��20(�$
��Auto������ *Id+�� $��Потоки��$	 100�� �� .R��� $	 Center=�$��20(�$
��Auto������ *Threads.Count+�� $��Descriptors��$	 100�� �� .R��� $	 Center=�$��20(�$
��Auto������ *HandleCount+�� -   
 ��Name$
 FindTextBox��$��Segoe UI)�
��� ���$��24��$	��312��$��34,402,35,24q��� -    ��Name$ 
ButtonKill��
������ $��0q�$��Снять задачу��$��90��$��25��$��2��$��352,401,74,24q�$��Segoe UI)��� -   $ 
ButtonOpen��
������ $��0q�$��Открыть...��$��85��$��25��$��1��$��66,401,28,24q�$��3��$��Segoe UI)�