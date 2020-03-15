﻿#pragma checksum "..\..\Configuration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A2913D50496C75A37F85CF69719DD1DA5672E69F1E3C81B082E4C99C4D885434"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using OrmGenerator;
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


namespace OrmGenerator {
    
    
    /// <summary>
    /// Configuration
    /// </summary>
    public partial class Configuration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_Connection_Save;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_IP;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_TypeBDD;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_SqlType;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox_Authentification;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Username;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Username;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_Password;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Password;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Finish;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Save_Configuration;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Delete_Configuration;
        
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
            System.Uri resourceLocater = new System.Uri("/OrmGenerator;component/configuration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Configuration.xaml"
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
            this.ComboBox_Connection_Save = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\Configuration.xaml"
            this.ComboBox_Connection_Save.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_Connection_Save_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox_IP = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\Configuration.xaml"
            this.TextBox_IP.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Database_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Label_TypeBDD = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.ComboBox_SqlType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\Configuration.xaml"
            this.ComboBox_SqlType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SqlType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CheckBox_Authentification = ((System.Windows.Controls.CheckBox)(target));
            
            #line 82 "..\..\Configuration.xaml"
            this.CheckBox_Authentification.Click += new System.Windows.RoutedEventHandler(this.CheckBox_Authentification_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Label_Username = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.TextBox_Username = ((System.Windows.Controls.TextBox)(target));
            
            #line 91 "..\..\Configuration.xaml"
            this.TextBox_Username.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Username_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Label_Password = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.TextBox_Password = ((System.Windows.Controls.TextBox)(target));
            
            #line 97 "..\..\Configuration.xaml"
            this.TextBox_Password.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Password_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Button_Finish = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\Configuration.xaml"
            this.Button_Finish.Click += new System.Windows.RoutedEventHandler(this.Button_Finish_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Button_Save_Configuration = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\Configuration.xaml"
            this.Button_Save_Configuration.Click += new System.Windows.RoutedEventHandler(this.Button_Save_Configuration_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Button_Delete_Configuration = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\Configuration.xaml"
            this.Button_Delete_Configuration.Click += new System.Windows.RoutedEventHandler(this.Button_Delete_Configuration_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

