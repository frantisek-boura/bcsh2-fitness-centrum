   M S B A M L   `   `   `  ����E  AFitnessApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FitnessApp.ViewFitnessApp.View  5      =#clr-namespace:FitnessApp.ConvertersFitnessApp.Converters  5      !    FitnessApp.View.LessonsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:FitnessApp.View     5      :
converters#clr-namespace:FitnessApp.Converters     5        � 	Resources  5
      <   6FitnessApp.Converters.LessonReservationsCountConverter $   LessonReservationsCountConverter��%   &	          5   
   66   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��370 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5       $��0��6   $��10q�6P      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��6*      
IsReadOnly$ False��6D      AlternatingRowBackground �#F7F7F7   RowBackground
 �����   HorizontalGridLinesBrush �#DDDDDD	   VerticalGridLinesBrush	 �#DDDDDD��5   0   �� *	Lessons+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Name+6R     5      $ 	Last Name��6%   $ * 6Q    68   �� *Type+6Q     5      $ Capacity��6%   $ * 6T    67   �� *
Capacity+6T     5      $ Number of Reservations��6%   $ 2* 6�      
IsReadOnly$
 True��6�    6E   �� *Reservations+ �� 	Converter# [     ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property �@�ToolTip �� Value$&  The total number of reservations��68   5      5!      4  .System.Windows.Controls.DataGridTemplateColumn  5"      $
 Date��6)   $ 2* 67      CellTemplate 5#      �� 5$      .R�5%      �� ��6(   �� *Date+ �� StringFormat$ 
MM/dd/yyyy��5&         CellEditingTemplate 5(      �� 5)      .R�5*      (  "System.Windows.Controls.DatePicker     SelectedDate 6)   �� *Date+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5+      5-      5/      �� 50   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�51      �� -   5        $��
Add Lesson��51      $��10q�6*   $	��100��66   6B   �� 52      -   5        $��removeButton��52      $��Remove��6)   $��10q�6:   $	��100��6F   ${�False��6i   53      54      55      