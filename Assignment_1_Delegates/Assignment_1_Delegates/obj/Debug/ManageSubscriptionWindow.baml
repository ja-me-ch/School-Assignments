   M S B A M L   `   `   `  ����Q  MAssignment_1_Delegates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Assignment_1_DelegatesAssignment_1_Delegates  5   	   5    /Assignment_1_Delegates.ManageSubscriptionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Assignment_1_Delegates     5   	     � Title$  ManageSubscriptionWindow��5   	   $	��300��6*   $	��600��67   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��30 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      $��25 �6   �� 5      $��50 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ chbx_EmailNotif��5      $��1��5      $��1��5      $��Center=�5      $��Center=�5      �� 5    
   -   5        $ chbx_MobileNotif��5       $��3��5!      $��1��5"      $��Center=�5#      $��Center=�5$      �� 5%   
   $!��Notification Sent by Email:��6   $��2��5&      $��1��5'      $��20(�5(      $��Center=�5)      $��Center=�5*      �� 5+   
   $��Notification Sent by SMS:��6   $��2��5,      $��3��5-      $��20(�5.      $��Center=�5/      $��Center=�50      �� 51   
   -   5         ��Name$ 
txbx_Email��51      $��1��52      $��3��53      $��24��54      $
��Auto��55      $��Center=�56      �� 57   
   -   5        $ txbx_Mobile��57      $��3��58      $��3��59      $��24��5:      $
��Auto��5;      $��Center=�5<      �� 5=   
   -   5         ��Name$" btn_SaveNotificationSettings��5=      $��4��5>      $��2��5?      $
��Save��5@      $��75��5A      6   �� 5G   
   -   5        $ 
btn_Cancel��5G      $��4��5H      $��3��5I      $��Cancel��5J      $��50��5K      6   5L      5M      