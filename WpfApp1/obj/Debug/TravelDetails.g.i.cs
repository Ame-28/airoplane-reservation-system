﻿#pragma checksum "..\..\TravelDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55D74C07B429B495F141B2A3E9DE5CBD1E6EDA425CE8851D417FEAE294B9D2E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ARS;
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


namespace ARS {
    
    
    /// <summary>
    /// TravelDetails
    /// </summary>
    public partial class TravelDetails : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton OneWay;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RoundTrip;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FromTextBox;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ToTextBox;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DepartDatePicker;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ReturnDatePicker;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassengersTextBox;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\TravelDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchFlightsButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/traveldetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TravelDetails.xaml"
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
            this.OneWay = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.RoundTrip = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.FromTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ToTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 121 "..\..\TravelDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Swap);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DepartDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.ReturnDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.PassengersTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.SearchFlightsButton = ((System.Windows.Controls.Button)(target));
            
            #line 171 "..\..\TravelDetails.xaml"
            this.SearchFlightsButton.Click += new System.Windows.RoutedEventHandler(this.SearchFlights_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

