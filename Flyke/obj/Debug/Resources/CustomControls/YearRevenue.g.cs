﻿#pragma checksum "..\..\..\..\Resources\CustomControls\YearRevenue.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9CDDCA9BBCBBCF9D02E57B219D817181CCB9AA5C4C90A36FB0EF32870FEE68F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Flyke.Resources.CustomControls;
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


namespace Flyke.Resources.CustomControls {
    
    
    /// <summary>
    /// YearRevenue
    /// </summary>
    public partial class YearRevenue : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Excel;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid YearRevenueTable;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_total;
        
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
            System.Uri resourceLocater = new System.Uri("/Flyke;component/resources/customcontrols/yearrevenue.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
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
            this.cBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
            this.cBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbox_selectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Excel = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Resources\CustomControls\YearRevenue.xaml"
            this.Excel.Click += new System.Windows.RoutedEventHandler(this.Excel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YearRevenueTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.tb_total = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

