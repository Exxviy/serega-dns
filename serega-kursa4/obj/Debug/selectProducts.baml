   M S B A M L   `   `   `  ����H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4  5   	   "    serega_kursa4.selectProducts   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:serega_kursa4     5   	     � Title$  selectProducts��5   	   $
��1080��6    $
��1200��6.   .��5	      �    BackGroundColor#��[  6    � RowDefinitions 5
      �� 5      $
��Auto �6   �� 5      �� 5      $��50 �6   .+�5   
   �� $��1��6   $��10q�6$   $
��Auto=�60   .��5      �� -   5         ��Name$ ProductsListView��5      $��Stretch=�61   ��5      �� 5      .R�5      �� $��1q�6!   
������� �� Padding$ 10q�6H   $��5q�6U   ._�5      ]� .+�5    "   �� $%��Images/productImg/box-close.png��6(   $	��100��6Q   $	��100��6]   $��5q�6j   �� 5!   "   $��10,0,0,0q�6-   .+�5"   &   �� $��18(�6M   $
��Bold"�6[   $��10q�6m   ��60   �� *ProductName+6m   �� 5#   &   $��14(�6j   $
��Wrap=�6x   $	��300��6�   $��10q�6�   ��60   �� *
Quantity+ �� StringFormat$ Количество: {0}��6�   �� 5$   &   $��16(�6c   $
��Bold"�6r   $��10q�6�   ��60   �� *Price+$ Цена: {0:C}��6�   5&   #   �� 5'   "    ��Name$ 	addToCart��6F   -   5        $��Right=�5'   *     NavigationButtonStyle#��[ 6{   
 � Tag 6k   �� .��5(   &   �� $��10q�60   $"Добавить в корзину6P   5)   #   5*      5+      5,      5.      5/      �� 52   
   -   5        $
 cart��53   9   $��0��52      $��40��6   $	��120��6+   $��Right=�53      $��10q�6-   #��[ 6Y   .��54      ]� .+�55      �� $��Images/cart.png��6   $��30��61   $��0,0,10,0q�6<   �� 56      $��Center=�6   Корзина6@   57      58      �� 59   
   -   5         ��Name$ CartItemCount��59      $��0��6+   $��24(�64   $
��Bold"�6B   
�������
������  �� Padding$ 5q�5:   8   $��Right=�5;      $��Center=�6(   $��	0,0,140,0q�5<      5?      5@      