﻿#pragma checksum "..\..\..\..\MVVM\View\SendCodeForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F77F778BB318F6A635243BFDF58121B1744A11ADB3B1564CB4011DDC8A151E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Flyke.MVVM.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Flyke.MVVM.View {
    
    
    /// <summary>
    /// SendCodeForm
    /// </summary>
    public partial class SendCodeForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Errortxt;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone verifyCode;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCode;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone email;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbEmail;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnsendcode;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnverifycode;
        
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
            System.Uri resourceLocater = new System.Uri("/Flyke;component/mvvm/view/sendcodeform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
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
            
            #line 14 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Errortxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.verifyCode = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 5:
            this.txbCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.email = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 7:
            this.txbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnsendcode = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
            this.btnsendcode.Click += new System.Windows.RoutedEventHandler(this.SendCode_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnverifycode = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\MVVM\View\SendCodeForm.xaml"
            this.btnverifycode.Click += new System.Windows.RoutedEventHandler(this.VerifyCode_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

