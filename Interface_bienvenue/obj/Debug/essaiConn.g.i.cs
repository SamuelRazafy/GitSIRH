﻿#pragma checksum "..\..\essaiConn.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "40E8050AE545139446BE148626E1A6871D8B06BB5C4070B21624B7C7A19B1111"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Interface_bienvenue;
using MaterialDesignThemes.MahApps;
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


namespace Interface_bienvenue {
    
    
    /// <summary>
    /// essaiConn
    /// </summary>
    public partial class essaiConn : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textMail;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butConnection;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butGoogle;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butFace;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butInsc;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button butAnnuler;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\essaiConn.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textMdp;
        
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
            System.Uri resourceLocater = new System.Uri("/Interface_bienvenue;component/essaiconn.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\essaiConn.xaml"
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
            this.textMail = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\essaiConn.xaml"
            this.textMail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textMail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.butConnection = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\essaiConn.xaml"
            this.butConnection.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.butGoogle = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\essaiConn.xaml"
            this.butGoogle.Click += new System.Windows.RoutedEventHandler(this.butGoogle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.butFace = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\essaiConn.xaml"
            this.butFace.Click += new System.Windows.RoutedEventHandler(this.butFace_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.butInsc = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\essaiConn.xaml"
            this.butInsc.Click += new System.Windows.RoutedEventHandler(this.butInsc_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.butAnnuler = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\essaiConn.xaml"
            this.butAnnuler.Click += new System.Windows.RoutedEventHandler(this.butAnnuler_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textMdp = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
