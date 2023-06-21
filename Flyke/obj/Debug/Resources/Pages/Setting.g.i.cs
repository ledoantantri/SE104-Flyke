﻿#pragma checksum "..\..\..\..\Resources\Pages\Setting.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "063C48F98DA080D019F94021CEEEA05941C8ED3F44AA943EBF9685ED56693A43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Flyke.Pages;
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


namespace Flyke.Pages {
    
    
    /// <summary>
    /// Setting
    /// </summary>
    public partial class Setting : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Uname;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelDName;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panelEmail;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Resources\Pages\Setting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txblError;
        
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
            System.Uri resourceLocater = new System.Uri("/Flyke;component/resources/pages/setting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Resources\Pages\Setting.xaml"
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
            this.Uname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 33 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editDname_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.panelDName = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            
            #line 38 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkDnameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 39 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelDnameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 47 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editEmail_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.panelEmail = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.txblError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 53 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkEmailBtn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 54 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelEmailBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 62 "..\..\..\..\Resources\Pages\Setting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editPassword_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

