﻿#pragma checksum "..\..\..\Views\Order.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "259EBE2B70329942359FBEF3F1721FCB7576F000150DB9CBE0A99A1128C0C252"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TNT.Views;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Behaviors;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.LayoutControl;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RadialMenu;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Controls.Wizard;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace TNT.Views {
    
    
    /// <summary>
    /// Order
    /// </summary>
    public partial class Order : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdOrder;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOrderNo;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewNumber;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox cboContact;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadDatePicker dpBillStart;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox cboTowns;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdOrderDetail;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox cboFishTypes;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadMaskedNumericInput txtOrderKg;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox cboStatus;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDel;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpd;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView dgDetail;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 286 "..\..\..\Views\Order.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TNT;component/views/order.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Order.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdOrder = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtOrderNo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnNewNumber = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Views\Order.xaml"
            this.btnNewNumber.Click += new System.Windows.RoutedEventHandler(this.btnNewNumber_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cboContact = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 100 "..\..\..\Views\Order.xaml"
            this.cboContact.DropDownClosed += new System.EventHandler(this.cboContact_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dpBillStart = ((Telerik.Windows.Controls.RadDatePicker)(target));
            return;
            case 6:
            this.cboTowns = ((Telerik.Windows.Controls.RadComboBox)(target));
            return;
            case 7:
            this.grdOrderDetail = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.cboFishTypes = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 158 "..\..\..\Views\Order.xaml"
            this.cboFishTypes.DropDownClosed += new System.EventHandler(this.cboFishTypes_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtOrderKg = ((Telerik.Windows.Controls.RadMaskedNumericInput)(target));
            return;
            case 10:
            this.cboStatus = ((Telerik.Windows.Controls.RadComboBox)(target));
            return;
            case 11:
            this.btnDel = ((System.Windows.Controls.Button)(target));
            
            #line 234 "..\..\..\Views\Order.xaml"
            this.btnDel.Click += new System.Windows.RoutedEventHandler(this.btnDel_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnUpd = ((System.Windows.Controls.Button)(target));
            
            #line 236 "..\..\..\Views\Order.xaml"
            this.btnUpd.Click += new System.Windows.RoutedEventHandler(this.btnUpd_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 238 "..\..\..\Views\Order.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.dgDetail = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 247 "..\..\..\Views\Order.xaml"
            this.dgDetail.SelectionChanged += new System.EventHandler<Telerik.Windows.Controls.SelectionChangeEventArgs>(this.dgDetail_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 284 "..\..\..\Views\Order.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 287 "..\..\..\Views\Order.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

