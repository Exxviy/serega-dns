   M S B A M L   `   `   `  ���� H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4  "    serega_kursa4.selectProducts   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:serega_kursa4       � Title$  selectProducts��$
��1080��$
��1200��.���    BackGroundColor#��[   � RowDefinitions �� $
��Auto ��� �� $��50 �.+��� $��1��$��10q�$
��Auto=�.���� -    ��Name$ ProductsListView��$��Stretch=����� .R��� $��1q�
������� �� Padding$ 10q�$��5q�._�]� .+��� $%��Images/productImg/box-close.png��$	��100��$	��100��$��5q��� $��10,0,0,0q�.+��� $��18(�$
��Bold"�$��10q����� *ProductName+�� $��14(�$
��Wrap=�$	��300��$��10q����� *
Quantity+ �� StringFormat$ Количество: {0}���� $��16(�$
��Bold"�$��10q����� *Price+$ Цена: {0:C}����  ��Name$ 	addToCart��-   $��Right=�  NavigationButtonStyle#��[ 
 � Tag �� .���� $��10q�$"Добавить в корзину�� -   $
 cart��$��0��$��40��$	��120��$��Right=�$��10q�#��[ .��]� .+��� $��Images/cart.png��$��30��$��0,0,10,0q��� $��Center=�Корзина�� -    ��Name$ CartItemCount��$��0��$��24(�$
��Bold"�
�������
������  �� Padding$ 5q�$��Right=�$��Center=�$��	0,0,140,0q�