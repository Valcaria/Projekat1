﻿#pragma checksum "..\..\..\Sobe\Sobe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7AA43CB41B9B1FC8960C693D67458F59B05ECE7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekat;
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


namespace ProjekatTMP {
    
    
    /// <summary>
    /// Sobe
    /// </summary>
    public partial class Sobe : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Sobe\Sobe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDom;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Sobe\Sobe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPaviljon;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Sobe\Sobe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid ugrdPanel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Sobe\Sobe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stpStudentInfo;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekat;component/sobe/sobe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Sobe\Sobe.xaml"
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
            this.cmbDom = ((System.Windows.Controls.ComboBox)(target));
            
            #line 10 "..\..\..\Sobe\Sobe.xaml"
            this.cmbDom.DropDownClosed += new System.EventHandler(this.cmbDom_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbPaviljon = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\Sobe\Sobe.xaml"
            this.cmbPaviljon.DropDownClosed += new System.EventHandler(this.cmbPaviljon_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 18 "..\..\..\Sobe\Sobe.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ScrollViewer_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ugrdPanel = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 5:
            this.stpStudentInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
