﻿#pragma checksum "..\..\..\Pages\PageViewOrderClients.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93C1C90F59EC2083F9607A6643EA13925A953BBA0B57DA6761784917DB33D4D6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProcatsManager.Pages;
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


namespace ProcatsManager.Pages {
    
    
    /// <summary>
    /// PageViewOrderClients
    /// </summary>
    public partial class PageViewOrderClients : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgOrders;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCreateOrder;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCloseOrder;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spActionAdmin;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btNotAcceptedOrders;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCloseOrders;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\PageViewOrderClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOrdersInRental;
        
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
            System.Uri resourceLocater = new System.Uri("/ProcatsManager;component/pages/pagevieworderclients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageViewOrderClients.xaml"
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
            this.dgOrders = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btCreateOrder = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Pages\PageViewOrderClients.xaml"
            this.btCreateOrder.Click += new System.Windows.RoutedEventHandler(this.btCreateOrder_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btCloseOrder = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Pages\PageViewOrderClients.xaml"
            this.btCloseOrder.Click += new System.Windows.RoutedEventHandler(this.btCloseOrder_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.spActionAdmin = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.btNotAcceptedOrders = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Pages\PageViewOrderClients.xaml"
            this.btNotAcceptedOrders.Click += new System.Windows.RoutedEventHandler(this.btNotAcceptedOrders_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btCloseOrders = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Pages\PageViewOrderClients.xaml"
            this.btCloseOrders.Click += new System.Windows.RoutedEventHandler(this.btCloseOrders_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btOrdersInRental = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Pages\PageViewOrderClients.xaml"
            this.btOrdersInRental.Click += new System.Windows.RoutedEventHandler(this.btOrdersInRental_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
