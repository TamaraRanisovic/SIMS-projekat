﻿#pragma checksum "..\..\..\..\View\TourStat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87DDDE52E2755EFB4A0673A32743A788B5C63EC8"
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
    /// TourStat
    /// </summary>
    public partial class TourStat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MostVisited;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FinishedTours;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestStat;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowReview;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel CancelTourStackPannel;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateToReview;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\TourStat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListOfTours;
        
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
            System.Uri resourceLocater = new System.Uri("/InitialProject;component/view/tourstat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\TourStat.xaml"
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
            this.MostVisited = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\View\TourStat.xaml"
            this.MostVisited.Click += new System.Windows.RoutedEventHandler(this.MostVisited_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FinishedTours = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\View\TourStat.xaml"
            this.FinishedTours.Click += new System.Windows.RoutedEventHandler(this.FinishedTours_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GuestStat = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\View\TourStat.xaml"
            this.GuestStat.Click += new System.Windows.RoutedEventHandler(this.GuestStat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ShowReview = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\View\TourStat.xaml"
            this.ShowReview.Click += new System.Windows.RoutedEventHandler(this.ShowReview_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelTourStackPannel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.DateToReview = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ListOfTours = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

