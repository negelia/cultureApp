   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Culture Project��5   	   $	��500��6!   $
��1000��6.   ���	#FFF7F7F7.��5	      � .+�5
   
   �� -   5         ��Name$ errorTitle1��5
   3   ���#85c3fe$��30(�6%   $
��Bold"�6H   $��Регистрация��6Z   $��Center=�6p   $��0,23,0,0q�6�   $	��Top=�6�   $	��220��6�   �� 5   
   -   5         ��Name$ login��5   n    �� 	MaxLength$ 10��6   ���#e9e9e9$��3q�67   $��20(�6K   ���#85c3fe$
��Left=�6}   $��
138,96,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��310��6�   G� 5   
   -   5        $��password��5   ;    G� 	MaxLength$ 12��6   ���#e9e9e9$��3q�6K   $��20(�6_   ���#85c3fe$
��Left=�6�   $	��Top=�6�   $	��310��6�   $��138,206,0,0q�6�   �� 5   
   -   5        $ errorTitle1_Copy��5   3   ���#85c3fe$��20(�6%   $��
Логин��6M   $
��Left=�6]   $��
138,59,0,0q�6x   $	��Top=�6�   $	��188��6�   �� 5   
   -   5        $ errorTitle1_Copy1��5   3   ���#85c3fe$��20(�6%   $��Пароль��6N   $
��Left=�6_   $��138,169,0,0q�6z   $	��Top=�6�   $	��188��6�    J� RenderTransformOrigin$ 
0.34,0.706&�6�   �� 5   
   -   5        $ 
errorLogin��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6I   $��138,129,0,0q�6d   $	��Top=�6y   $	��310��6�   $��40��6�   �� 5   
   -   5        $ 	errorPass��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6H   $��138,239,0,0q�6c   $	��Top=�6x   $	��310��6�   $��30��6�   �� 5   
   -   5         ��Name$ 	insertBtn��5   �   ���	#FFF7F7F7$��1q�6)   
�������$
��Bold"�6P   ���	#FFB5D6F6$��20(�6y   $*��$Зарегистрироваться��6�   $��Center=�6�   $��	0,377,0,0q�6�   $	��Top=�6�   $	��264��6  $��38��6  �� 5   
   -	   5        $ errorFam1_Copy��5   3   ���#85c3fe$��20(�6%   $��Фамилия��6K   $��Right=�6]   $��	0,59,56,0q�6y   $	��Top=�6�   $	��188��6�   �� 5   
   -
   5        $	 fam��5   n   $ 30��6   ���#e9e9e9$��3q�67   $��20(�6K   ���#85c3fe$
��Left=�6{   $��
538,96,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��310��6�   �� 5   
   -   5        $ errorName1_Copy��5   3   ���#85c3fe$��20(�6%   $��Имя��6L   $��Right=�6Z   $��
0,169,12,0q�6v   $	��Top=�6�   $	��188��6�   �� 5   
   -   5        $
 name��5   n   $ 30��6   ���#e9e9e9$��3q�67   $��20(�6K   ���#85c3fe$
��Left=�6|   $��538,206,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��310��6�   �� 5   
   -   5        $ errorFam_Copy��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6L   $��538,129,0,0q�6g   $	��Top=�6|   $	��310��6�   $��40��6�   �� 5   
   -   5        $ errorIm_Copy��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6K   $��538,239,0,0q�6f   $	��Top=�6{   $	��310��6�   $��30��6�   �� 5   
   -   5        $ errorName1_Copy1��5   3   ���#85c3fe$��20(�6%   $��Отчество��6M   $��Right=�6`   $��
0,269,62,0q�6|   $	��Top=�6�   $	��188��6�   �� 5   
   -   5        $
 otch��5   n   $ 30��6   ���#e9e9e9$��3q�67   $��20(�6K   ���#85c3fe$
��Left=�6|   $��538,306,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��310��6�   �� 5   
   -   5        $ errorOtch_Copy��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6M   $��538,339,0,0q�6h   $	��Top=�6}   $	��310��6�   $��33��6�   �� 5   
   -   5        $ errorTitle1_Copy2��5   3   ���#85c3fe$��20(�6%   $#��Проверка пароля��6N   $
��Left=�6h   $��138,269,0,0q�6�   $	��Top=�6�   $	��188��6�   $ 
0.34,0.706&�6�   G� 5   
   -   5        $��passwordcopy��5   O   $ 12��6   ���#e9e9e9$��3q�6;   $��20(�6c   ���#85c3fe$
��Left=�6�   $	��Top=�6�   $	��310��6�   $��138,306,0,0q�6�   �� 5   
   -   5        $ errorPass_Copy2��5   5   ���	#FFF93904$��10(�6'   $
��Left=�6N   $��138,339,0,0q�6i   $	��Top=�6~   $	��310��6�   $��33��6�   5      5      