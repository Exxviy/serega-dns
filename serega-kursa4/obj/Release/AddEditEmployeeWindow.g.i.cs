﻿#pragma checksum "..\..\AddEditEmployeeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B1300284947EDAAED93B0B2C10A451F99DCC6B90DB615C508DE5BA73FC150505"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using serega_kursa4;


namespace serega_kursa4 {
    
    
    /// <summary>
    /// AddEditEmployeeWindow
    /// </summary>
    public partial class AddEditEmployeeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNameField;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstNameField;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox middleNameField;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginField;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox roleField;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneField;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailField;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AddEditEmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/serega-kursa4;component/addeditemployeewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEditEmployeeWindow.xaml"
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
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\AddEditEmployeeWindow.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.BackWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lastNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.firstNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.middleNameField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.loginField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.roleField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.phoneField = ((System.Windows.Controls.TextBox)(target));
            
            #line 38 "..\..\AddEditEmployeeWindow.xaml"
            this.phoneField.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.phoneFieldPreviewText);
            
            #line default
            #line hidden
            
            #line 38 "..\..\AddEditEmployeeWindow.xaml"
            this.phoneField.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.phoneFieldTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.emailField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.saveEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\AddEditEmployeeWindow.xaml"
            this.saveEmployee.LostFocus += new System.Windows.RoutedEventHandler(this.saveEmployeeLostFocus);
            
            #line default
            #line hidden
            
            #line 43 "..\..\AddEditEmployeeWindow.xaml"
            this.saveEmployee.Click += new System.Windows.RoutedEventHandler(this.SaveEmployee);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

