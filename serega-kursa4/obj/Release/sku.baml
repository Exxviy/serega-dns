   M S B A M L   `   `   `  ���� H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4      serega_kursa4.sku   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:serega_kursa4       � Title$  Товары��.���    BackGroundColor#��[  .+��� $
��Auto=�.���� -    ��Name$ productsList��$��10,150,10,10q� �� SelectionMode$ Single=� �� View �� .P��� $��ID�� �� Width$ 50�� �� DisplayMemberBinding �� *	ProductID+�� $��Название��$	 200�� �� *ProductName+�� $��Категория��$	 200�� �� *CategoryInfo.CategoryName+�� $��Количество��$	 100�� �� *
Quantity+�� $��Цена��$	 200�� �� *Price+�� $,��&Информация о товарах��$��24(�$
��Bold"�  	TextWhite#��[ $��Center=�$��	0,10,0,20q���  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��	0,60,0,10q�.+��� -   $��
backWindow��$��
Назад��  NavigationButtonStyle#��[ $	��150��$��50��$��10,0,0,0q� � Cursor$
 Hand���� -    ��Name$ 
addProduct��$!��Добавить товар��#��[ $	��150��$��50��$
 Hand���� -   $ editProduct��$ ��Редактировать��#��[ $	��150��$��50��$��0,0,0,0q��� -   $ deleteProduct��$��Удалить��#��[ $	��150��$��50��$��10,0,0,0q��� -   $��searchTextBox��$��10q�  inputBox#��[ $	��200��$��10,0,0,0q�$��16(�#��[ $��50��$��Поиск...���� -   $��changeCategory��$��Категории��#��[ $	��150��$��50��$��10,0,0,0q�$
 Hand���� -   	 ��Name$	 categoryFilter��$	��200��$��50��
 �� Text$4
 .Сортировка по категориям��$��10,0,0,0q�