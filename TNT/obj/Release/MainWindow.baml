   M S B A M L   `   `   `  ���� >  :TNT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TNTTNT  b ^Telerik.Windows.Data, Version=2016.3.1024.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Y@clr-namespace:Telerik.Windows.Data;assembly=Telerik.Windows.DataTelerik.Windows.Data     TNT.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:TNT     l hTelerik.Windows.Controls.Input, Version=2016.3.1024.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2016.3.1024.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2016.3.1024.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q	 mTelerik.Windows.Controls.Navigation, Version=2016.3.1024.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Gtelerik1http://schemas.telerik.com/2008/xaml/presentation     	 ZtelerikData@clr-namespace:Telerik.Windows.Data;assembly=Telerik.Windows.Data     	 Z
 VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/ 
   � Title$  TNT Preduzeće�� � WindowState$ 	Maximized=� � 	Resources    SelectionBoxContact  ComboContactTemplate � ColumnDefinitions��%  &	        &	 2     �� .R�� .+��� $
��Bold"����� *Name+�� .R�� $	��0 3q� �� $��2* ��� $��* ��� $
��Auto �.+��� ���#003366$
��Bold"����� *Person.Name+�� $��1������ *Person.Town+�� $��2������ *Contact.ContactValue+.��� .+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� �� .+��� -    ��Name$ LinksBorder��  NavLinksBorderStyle2#��[ $��5q�._��  � Cursor$
 Hand�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��	btnMnuOpt��  GreenButton#��[ $��5q�.��]� .+��� $��24��$��24��$��Styles/report.png�� ^� ToolTip$ Unosenje podataka���� $��Poruđžbina��$��5,0,0,0q�$��Center=�- 	 'Telerik.Windows.Controls.RadContextMenu   ContextMenu   -   	  Name$	 OptOrderMenu��$
 Hand��@�* 	 $Telerik.Windows.Controls.RadMenuItem  -   $��rmiNewOrder��$��Nova Poruđžbina��  -   $��rmiUpdOrder��$��Azuriraj Poruđžbinu��{�.  3 	 -Telerik.Windows.Controls.RadMenuSeparatorItem    -   $��rmiDelOrder��$��Izbrisi Poruđžbinu��{�.  �� -   $��
btnOptions��$��1��#��[ $��5q�.��]� .+��� $��24��$��24��$��Styles/Gear.png��$ OdŠtampaj izveštaj���� $��Opcije��$��5,0,0,0q�$��Center=�   -   $	 OptMenu��$
 Hand��@�  -	   $��rmiNewAccount��$��	Cena Ribe��  -
   $��rmiStatusChange��$��Promeni Status��.@�  -   $��rmiIspo��$��Isporučeno��  -   $��rmiIspoPaid��$��Isporučeno - Plaćeno��  -   $��	rmiCancel��$��Otkazano��    -   $��
rmiReports��$��Izvestaj��.@�  $��Poruđžbine��.@��� 
 �� Orientation$
 
Horizontal=�.+��� $��0,0,5,0q�.+�  $��Vreme��,  &Telerik.Windows.Controls.RadTimePicker  -   $��dpTime��0  *Telerik.Windows.Controls.RadDateTimePicker   DateTimeWatermarkContent$ Unesi vreme��   Culture$ sr-Latn���� .+�  $��Datum Isporuke��,  &Telerik.Windows.Controls.RadDatePicker  -   $
��dpTo��$ Unesi datum��$ sr-Latn��  $��Isporučeno��.@��� $
 
Horizontal=�.+��� $��0,0,5,0q�.+�  $��Vreme��  -   $��	dpDetTime��$ Unesi vreme��$ sr-Latn���� .+�  $��Datum Isporuke��  -   $��	dpDetDate��$ Unesi datum��$ sr-Latn��    -   $��	rmiBackup��$��Kopiraj Bazu Podataka���� -   $��btnMnuClose��$��2��#��[ $��5q�.��]� .+��� $��24��$��24��$��Styles/exit.png��$ Zatvori aplikaciju���� $��Zatvori��$��5,0,0,0q�$��Center=���   ChildBorderStyle#��[ $	��5,0q�$��1��._��  �� ��  �� $��* ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$��5q�.+��� $��Broj Poruđžbine��$��Center=�
���   ��� -   $��txtAccountNo�� �� 	MaxLength$	 100��$��20���� $��1��$��3��$��5q�.+��� $	��Ime��$��Center=�
���   �*  $Telerik.Windows.Controls.RadComboBox  -   $��
cboContact��   
IsEditable . $
 Hand�� �� SelectedValuePath$ Person.Name��)  #Telerik.Windows.Controls.TextSearch   TextPath$ Person.Name��#��[    SelectionBoxTemplate# [     Text �� *Name+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . �� $��4��$��3��$��5q�.+��� $��Mesto��$��Center=�
���   �  -   $��cboTowns�� .  �� DisplayMemberPath$ TownName��$
 Hand��$ TownId��$��7�� �� *Town+$ TwoWay=� .  . �� -   $��	btnSearch��$��Pretraga��$��5��$��1��$��Right=�$��5,5,5,0q�$��75��$��25��#��[ $
 Hand���� -   $��btnClear��$��Izbriši��$��6��$��1��$��Right=�$��5,5,5,0q�$��75��$��25��#��[ $
 Hand���� $��1��$��5q�.+��� $��Pocetni��$��Center=�
���   �  -   $��dpOrderStart��$ sr-Latn��$ Unesi datum���� $��1��$��1��$��5q�.+��� $��Zavrsni��$��Center=�
���   �  -   $��
dpOrderEnd��$��3��$ sr-Latn��$ Unesi datum���� $��2��$��1��$��2��$��5q�.+��� $��Status��$��Center=�
���   �  -   $��	cboStatus�� .    
IsReadOnly . $ Description��$
 Hand��$ Description�� �� *Status+$ TwoWay=� .  . *	  $Telerik.Windows.Controls.RadGridView	  -   $��dgPerson��;
  5Telerik.Windows.Controls.GridView.GridViewDataControl 
  AutoGenerateColumns .   
  ShowGroupPanel .  $��Stretch=�$��2��$��5q� 
  IsFilteringAllowed .  
  CanUserDeleteRows .  $
 Hand��*  $Telerik.Windows.Controls.DataControl$   IsSynchronizedWithCurrentItem$ FalseY� 
  ShowColumnFooters . $��Disabled=� 
  RowIndicatorVisibility$ 	Collapsed=� 
  CanUserFreezeColumns .      ItemsSource  ��  ! �� 
TargetType��%   '��       �� "! ��" 
  Columns" -  'Telerik.Windows.Controls.GridViewColumn  #   
UniqueName$# tbSwitch��$   CellTemplate$ �� .R�d� $��tbOrder��-   $��+��$��0q�$��Center=�$	��Top=�1  +Telerik.Windows.Controls.GridViewDataColumn  6  0Telerik.Windows.Controls.GridViewBoundColumnBase%   Header$	% Ime��&   
IsReadOnly& . '   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$' 2* (   DataMemberBinding( �� *Person.Name+  $% Mesto��& . $
' 1.5* ( �� *Person.Town+  $% Mobilni��& . $' * ( �� *Person.CellPhone+  $% Br.Poruđžbina��)   HeaderTextAlignment$) Right=�*   TextAlignment$* Right=�+   FooterTextAlignment$+ Right=�& . $
' Auto ( �� *	TotalNo+,   AggregateFunctions, &   Telerik.Windows.Data.SumFunction  >  8Telerik.Windows.Data.EnumerableSelectorAggregateFunction-   SourceField$- TotalNo��.   Footer. �� $
��Bold"�
���  ��/ �� TextAlignment$/ Right=����� *FormattedValue+  $% Duguje��0   DataFormatString$0 {0:N2}��$) Right=�$* Right=�$+ Right=�$' * ( �� *Due+,   $	- Due��. �� $
��Bold"�
���  ��$/ Right=����� *FormattedValue+   $
 Hand��@�  -   $��Nova Poruđžbina��  -    $��Azuriraj Poruđžbinu��  $��Promeni Status��.@�  -!   $��Isporučeno��  -"   $��Isporučeno - Plaćeno��  -#   $��Otkazano��    -$   $��Izbrisi Poruđžbinu��1 
  RowDetailsTemplate1 �� .R�	  $��dgOrder��-%    .   .  $
��Auto��$	��Top=�$��15,5,0,5q� .  .  $
 Hand��$ FalseY�  �� *Person.Orders+2 
  FilterDescriptors2 +  %Telerik.Windows.Data.FilterDescriptor  3   Member$3 Action��<  6Telerik.Windows.Data.OperatorValueFilterDescriptorBase4   Operator$4 DoesNotContain=�5   Value$5 D��6   IsCaseSensitive6 .   ��%   '��       �� "! ��"   $% Broj Poruđžbine��& . $' * ( �� *OrderNumber+  $% Datum Isporuke��& . $' * ( �� *DeliveryDate+  $% Vreme Isporuke��& . $' * ( �� *DeliveryTime+  $% Datum Poruđžbine��& . $' * ( �� *	OrderDate+  $% Vreme Poruđžbine��& . $' * ( �� *	OrderTime+, 	 &Telerik.Windows.Controls.RadTabControl  $��3��$��5,0,5,5q�$
 Hand��.@�) 	 #Telerik.Windows.Controls.RadTabItem  -&   7  Name$7 tbOrderDetails��$��Poruđžbine��$	��150��.���  �� $
��407* ��� $
��339* ����� 8 �� ImageSource$8 Styles/background.jpg��.+�	  -'   $��	dgDetails�� .   .  $��Stretch=�9 
  
IsReadOnly9 . $��5q� .  .  $
 Hand��$ FalseY� . $��Disabled=�$��2��  ��  ��%   '��       �� "! ��"   $% Poručeno KG��$0 {0:N2}��$) Right=�$* Right=�$+ Right=�& . $' * ( �� *	OrderKg+,   $- OrderKg��. �� $
��Bold"�
���  ��$/ Right=����� *FormattedValue+  $% 	Cena 1 KG��$0 {0:N2}��$) Right=�$* Right=�& . $' * ( �� *
PricePerKg+  $% Poručeno RSD��$0 {0:N2}��$) Right=�$* Right=�$+ Right=�& . $' * ( �� *	AmountDue+,   $- 	AmountDue��. �� $
��Bold"�
���  ������ *FormattedValue+  $% Isporučeno KG��$0 {0:N2}��$) Right=�$* Right=�$+ Right=�& . $' * ( �� *DeliveredKg+,   $- DeliveredKg��. �� $
��Bold"�
���  ������ *FormattedValue+  $% Isporučeno RSD��$0 {0:N2}��$) Right=�$* Right=�$+ Right=�& . $' * ( �� *
AmountPaid+,   $- 
AmountPaid��. �� $
��Bold"�
���  ������ *FormattedValue+  $% 
Vrsta Ribe��& . $' * ( �� *FishType.Description+  $% Priprema��& . $' * ( �� *FishType.PrepSelected+  $% Status��& . $' * ( �� *Status.Description+" 
 FontAwesome.WPF.ImageAwesome  -(   :  Name$: spinner��;   Icon$; Refresh=�<   Spin< . $��48��$��48��$y�Hidden=�