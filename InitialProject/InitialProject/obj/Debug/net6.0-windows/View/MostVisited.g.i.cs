﻿#pragma checksum "..\..\..\..\View\MostVisited.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB805DFE3F3B5628744C1A8261D14C75C653FA15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InitialProject.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace InitialProject.View {
    
    
    /// <summary>
    /// MostVisited
    /// </summary>
    public partial class MostVisited : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TourDates;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowTours;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel CancelTourStackPannel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TourNameCancel;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListOfTours;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\View\MostVisited.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FreePlacesLabel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InitialProject;V1.0.0.0;component/view/mostvisited.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MostVisited.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TourDates = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\View\MostVisited.xaml"
            this.TourDates.Click += new System.Windows.RoutedEventHandler(this.TourDates_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShowTours = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\View\MostVisited.xaml"
            this.ShowTours.Click += new System.Windows.RoutedEventHandler(this.ShowTour_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CancelTourStackPannel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.TourNameCancel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ListOfTours = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.FreePlacesLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
