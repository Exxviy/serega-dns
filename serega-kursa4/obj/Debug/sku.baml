   M S B A M L   `   `   `  ����H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4  5          serega_kursa4.sku   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:serega_kursa4     5        � Title$  Товары��5	      .��5      �    BackGroundColor#��[  6   .+�5   
   �� $
��Auto=�6   .��5   
   �� -   5         ��Name$ productsList��5      $��10,150,10,10q�6)    �� SelectionMode$ Single=�6@    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6\    �� DisplayMemberBinding 61   �� *	ProductID+6\   �� 5      $��Название��6%   $	 200��6d    67   �� *ProductName+6d   �� 5      $��Категория��6%   $	 200��6s    68   �� *CategoryInfo.CategoryName+6s   �� 5      $��Количество��6%   $	 100��6c    69   �� *
Quantity+6c   �� 5      $��Цена��6%   $	 200��6Z    63   �� *Price+6Z   5      5      5      �� 5   
   $,��&Информация о товарах��6   $��24(�60   $
��Bold"�6>     	TextWhite#��[ 6P   $��Center=�5      $��	0,10,0,20q�61   �� 5!   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��Top=�6K   $��	0,60,0,10q�6c   .+�5"      �� -   5        $��
backWindow��5"   %   $��
Назад��6     NavigationButtonStyle#��[ 6K   $	��150��6z   $��50��6�   $��10,0,0,0q�6�    � Cursor$
 Hand��6�   �� 5#      -   5         ��Name$ 
addProduct��5#      $!��Добавить товар��6=   #��[ 6V   $	��150��6�   $��50��6�   $
 Hand��6�   �� 5$      -   5        $ editProduct��5$      $ ��Редактировать��6>   #��[ 6V   $	��150��6�   $��50��6�   $��0,0,0,0q�6�   �� 5%      -   5        $ deleteProduct��5%      $��Удалить��6B   #��[ 6T   $	��150��6�   $��50��6�   $��10,0,0,0q�6�   �� 5&      -   5        $��searchTextBox��5&   F   $��10q�6     inputBox#��[ 6$   $	��200��6[   $��10,0,0,0q�6g   $��16(�6y   #��[ 6�   $��50��6�   $��Поиск...��6�   6�   �� 5'      -   5        $��changeCategory��5'   )   $��Категории��6   #��[ 6V   $	��150��6�   $��50��6�   $��10,0,0,0q�6�   $
 Hand��6�   �� 5(      -   5        	 ��Name$	 categoryFilter��5(      $	��200��6/   $��50��6;   
 �� Text$4
 .Сортировка по категориям��6y   $��10,0,0,0q�6�   5)      5+      5,      