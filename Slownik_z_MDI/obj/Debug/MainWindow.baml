   M S B A M L   `   `   `  ����H  DSlownik_z_MDI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Slownik_z_MDISlownik_z_MDI  5   	   C&clr-namespace:Slownik_z_MDI.ViewModelsSlownik_z_MDI.ViewModels  5   	   9!clr-namespace:Slownik_z_MDI.ViewsSlownik_z_MDI.Views  5   	       Slownik_z_MDI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Slownik_z_MDI     5   	   =
viewmodels&clr-namespace:Slownik_z_MDI.ViewModels     5   	   3views!clr-namespace:Slownik_z_MDI.Views     5   	     � Title$  
MainWindow��5
   	   $	��400��6   $	��700��6)    � 	Resources 5       �� DataType.   (Slownik_z_MDI.ViewModels.DodajSlowoModel$   Slownik_z_MDI.Views.DodajSlowo � DataContext-   'Slownik_z_MDI.ViewModels.UsunSlowoModel#   Slownik_z_MDI.Views.UsunSlowo1   +Slownik_z_MDI.ViewModels.WyszukajSlowoModel'   !Slownik_z_MDI.Views.WyszukajSlowo/   )Slownik_z_MDI.ViewModels.PrzetlumaczModel%   Slownik_z_MDI.Views.Przetlumacz(	   "Slownik_z_MDI.ViewModels.QuizModel
   Slownik_z_MDI.Views.Quiz��%-  (��       5   3   *, +)(�� W     5   2   *, +)(�� �     5   6   *, +)(��     5   4   *, +)(�� _    5   -   *,	 +)�� 5   
   DodajSlowoTemplate��"  63   .R�5         6   �� 5      �� 5   
   UsunSlowoTemplate��"  62   .R�5         6   �� 5      �� 5   
   WyszukajSlowoTemplate��"  66   .R�5         6"   �� 5      �� 5   
   PrzetlumaczTemplate��"  64   .R�5         6    �� 5      �� 5   
   QuizTemplate��" 	 6-   .R�5      
   6   �� 5       5"      .��5$      � $��0q�6    � ColumnDefinitions 5&   
   �� 5'      �� 5(      �� 5)       � RowDefinitions 5,   
   �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      .+�57   
   ]� 
����  �$��0��6*   $��0��67   $��3��6G   .+�58      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�59      �� -   5        $��Dodaj słowo��59      $	��120��6/   $��Segoe UI Emoji)�6;   $��13(�6W   
����������#000369
�������6�   �� 5:      -   5        $��Usuń słowo��5:      $	��120��6.   $��Segoe UI Emoji)�6:   $��13(�6V   
����������#000369
�������6�   �� 5;      -   5        $��Tłumacz (NO-PL)��5;      $	��120��63   $��Segoe UI Emoji)�6?   $��13(�6[   
����������#000369
�������6�   �� 5<      -   5        $��Tłumacz (PL-NO)��5<      $	��120��63   $��Segoe UI Emoji)�6?   $��13(�6[   
����������#000369
�������6�   �� 5=      -   5        $
��Quiz��5=      $	��120��6(   $��Segoe UI Emoji)�64   $��13(�6P   
����������#000369
�������6�   5>      5?      �� 5B   
   $��1��6   $��0��6&   $��3��66   $��7��6J   ��6[   �� ��5C   
   �� 5D       �� ImageSource$9 3C:\Users\Sikma\source\repos\Slownik_z_MDI\flaga.jpg��6    j� 
AlignmentY$	 Top=�6[   	 j� 
AlignmentX$	 Center=�6l   5E      5H      5I      