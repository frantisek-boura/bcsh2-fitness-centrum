   M S B A M L   `   `   `  ����E  AFitnessApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FitnessApp.ViewFitnessApp.View  5      ;"clr-namespace:FitnessApp.ViewModelFitnessApp.ViewModel  5      &     FitnessApp.View.ReservationsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FitnessApp.View     5      8	viewmodel"clr-namespace:FitnessApp.ViewModel     5        � DataContext  5
      0   *FitnessApp.ViewModel.ReservationsViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��320 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5      �� -   5        $��filterMemberFirstName��5      $	��100��63   $��5q�6?   �� 5      -   5        $��filterMemberLastName��5      $	��100��62   $��5q�6>   �� 5      -   5        $��filterLessonType��5      $	��100��6.   $��5q�6:   (  "System.Windows.Controls.DatePicker  5      -   5        $��filterReservationDate��5      $	��100��66   $��5q�6B   �� 5      -   5        $��Filter��5      $��80��6&   $��5q�61   $��Center=�6W   �� 5      -   5        $��X��5      $��20��6!   $��5q�6,   $��Center=�6W   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5       $��1��6   $��10q�6U      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��6#      
IsReadOnly$ False��6=      AlternatingRowBackground �#F7F7F7   RowBackground
 �����	   HorizontalGridLinesBrush	 �#DDDDDD
   VerticalGridLinesBrush
 �#DDDDDD��5   0   �� *Reservations+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Member��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U      
IsReadOnly$
 True��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ��  �� Path$ Member�6_     5"      $ Lesson��6%   $ 2* 6U   $
 True��6`    65   �� $ Lesson�6`     5#      $ Reservation created on��6%   $ 2* 6�   $
 True��6�    6E   �� $ 	CreatedOn� �� StringFormat$ 
MM/dd/yyyy��6�   5%      �� 5&   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5'      �� -   5        $��Add Reservation��5'      $��10q�6/   $	��120��6;   6G   �� 5(      -	   5        $��removeButton��5(      $��Remove Reservation��6)   $��10q�6F   $	��120��6R   ${�False��6�   �� 5)      -
   5        $��
editButton��5)      $��Edit Reservation��6'   $��10q�6B   $	��120��6N   ${�False��6z   5*      5+      5,      