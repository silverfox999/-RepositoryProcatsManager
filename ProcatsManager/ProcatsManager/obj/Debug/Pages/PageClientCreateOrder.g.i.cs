﻿#pragma checksum "..\..\..\Pages\PageClientCreateOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "018D6E0825111112FE533B14E359A180C61D9937AC75B9CC9F7D9B52EC98B00E"
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
    /// PageClientCreateOrder
    /// </summary>
    public partial class PageClientCreateOrder : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Pages\PageClientCreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spServices;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\PageClientCreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbService1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\PageClientCreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btPlusServices;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Pages\PageClientCreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTimeRental;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\PageClientCreateOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCreateOrder;
        
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
            System.Uri resourceLocater = new System.Uri("/ProcatsManager;component/pages/pageclientcreateorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageClientCreateOrder.xaml"
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
            this.spServices = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.cbService1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.btPlusServices = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\PageClientCreateOrder.xaml"
            this.btPlusServices.Click += new System.Windows.RoutedEventHandler(this.btPlusServices_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxTimeRental = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btCreateOrder = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Pages\PageClientCreateOrder.xaml"
            this.btCreateOrder.Click += new System.Windows.RoutedEventHandler(this.btCreateOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
