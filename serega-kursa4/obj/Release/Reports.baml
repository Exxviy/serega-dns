   M S B A M L   `   `   `  ���� H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4      serega_kursa4.Reports   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:serega_kursa4       � Title$  Reports��.���    BackGroundColor#��[   � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* �.+��� $��Отчеты��$��24(�$
��Bold"�  	TextWhite#��[ $��Center=�$��Center=�$
��0,10q�$��0���� -    ��Name$ backToMainPage��$��
Назад��  NavigationButtonStyle#��[ $	��150��$
��Left=�$	��Top=� � Cursor$
 Hand����  �� Orientation$ 
Horizontal=�$��Stretch=�$��10q�$��1��.+��� -    ��Name$ ReportTypeComboBox��$	��200��$��5q�$��0,0,10,0q� �� SelectedIndex$ 0��.@��� $&�� Отчет по продажам���� $&�� Отчет по остаткам���� $$��Отчет по прибыли���� $��Период:��$��16(�#��[ $��Center=�$
��10,0q�(  "System.Windows.Controls.DatePicker  -     Name$ StartDatePicker��$	��120��$
��10,0q��� $	��—��$��16(�#��[ $��Center=�$	��5,0q�  -   $ EndDatePicker��$	��120��$��	10,0,10,0q��� -   $ CategoryFilterComboBox��$	��150��$��5q�$��	10,0,10,0q�.@��� $��Все категории���� $��Категория 1���� $��Категория 2����   RoundedStackPanelStyle#��[ $��10,10,10,80q�	 �� Padding$	 10q�$��2��._��� .+��� -   
 ��Name$
 ReportTitle��$ ��Отчет: Продажи��$��20(�$
��Bold"�#��[ $��0,0,0,10q�&   System.Windows.Controls.DataGrid  -     Name$ ReportDataGrid��   AutoGenerateColumns .    CanUserAddRows .  $��	0,10,0,10q�
�������
���   �   HeadersVisibility$ Column=�   SelectionMode$ Single=��� $P��JДиаграмма отчета будет отображена здесь��$��14(�$��Center=�$��Center=�
��������� $ 
Horizontal=�$��Right=�$	��Top=�$��
0,0,120,10q�$��3��.+��� $��Экспорт в PDF��#��[ $	��120��$��10,0,0,0q��� $��Экспорт в Excel��#��[ $	��120��$��10,0,0,0q��� $��Экспорт в CSV��#��[ $	��120��$��10,0,0,0q��� #��[ $	��120��$��55��$��10,0,0,0q�$
 Hand������ $
��Wrap=�$)��#Сформировать отчет�� �� TextAlignment$ Center=�