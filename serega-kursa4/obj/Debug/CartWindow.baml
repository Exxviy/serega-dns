   M S B A M L   `   `   `  ����H  Dserega-kursa4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:serega_kursa4serega_kursa4  5   	       serega_kursa4.CartWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:serega_kursa4     5   	     � Title$  
CartWindow��5   	   $	��750��6   $
��1000��6)   .��5	      �    BackGroundColor#��[  6   .+�5
   
   �� $��10q�6   .+�5      ]� .+�5      �� -   5         ��Name$ 
backWindow��5      $
��Left=�6@     NavigationButtonStyle#��[ 6\   $��Bottom=�6�   .��5      �� $��10q�6    
Назад63   5      �� 5      $��Корзина��6   $��24(�6+   $
��Bold"�69   $��0,0,70,0q�6K   
�������$��Center=�6p   $��Center=�6�   5      �� 5      $
��Auto=�6   .��5      �� -   5         ��Name$ CartListView��5      $��Stretch=�61   ��5      �� 5      .R�5      �� $��1q�6%   
������� �� Padding$ 10q�6L   $��5q�6Y   ._�5   "   ]� $��Center=�6-   .+�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   �� $%��Images/productImg/box-close.png��60   $��50��6Y   $��50��6d   $��5q�6p   �� 5   *   .+�5   .   �� $��18(�6U   $
��Bold"�6c   ��68   �� *ProductName+6c   �� 5   .   $��16(�6k   ��68   �� *Price+ �� StringFormat$ Цена: {0:C}��6k   5    +   5!   '   �� 5#   &   $ 
removeCart��6-   -   5        #��[ 5#   j   $��10q�6�   $��Right=�6�   $��Center=�6�   
 � Tag 6X   �� .��5$   *   �� $��10q�64   Удалить6I   5%   '   5&   #   5(      5)      5+      5,      �� 5/      -   5        $��Center=�5/   )   #��[ 6G   $��Bottom=�6v   .��50      �� $��10q�6   Оформить заказ68   51      52      53      54      