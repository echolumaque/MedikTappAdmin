#pragma checksum "..\..\Services.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42558C32B89D0A9E483AC2F29881A14ABDDBD0420665AC268962B78987BADA4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MediktapAdmin;
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


namespace MediktapAdmin {
    
    
    /// <summary>
    /// Services
    /// </summary>
    public partial class Services : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 597 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem servicetab;
        
        #line default
        #line hidden
        
        
        #line 602 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstservicelist;
        
        #line default
        #line hidden
        
        
        #line 610 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstservicelistaction;
        
        #line default
        #line hidden
        
        
        #line 636 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnaddnewservice;
        
        #line default
        #line hidden
        
        
        #line 642 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem promotab;
        
        #line default
        #line hidden
        
        
        #line 648 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstpromo;
        
        #line default
        #line hidden
        
        
        #line 657 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstpromoaction;
        
        #line default
        #line hidden
        
        
        #line 688 "..\..\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnpromoadd;
        
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
            System.Uri resourceLocater = new System.Uri("/MediktapAdmin;component/services.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Services.xaml"
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
            this.servicetab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 2:
            this.lstservicelist = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.lstservicelistaction = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.btnaddnewservice = ((System.Windows.Controls.Button)(target));
            
            #line 639 "..\..\Services.xaml"
            this.btnaddnewservice.Click += new System.Windows.RoutedEventHandler(this.btnaddnewservice_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.promotab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 8:
            this.lstpromo = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.lstpromoaction = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            this.btnpromoadd = ((System.Windows.Controls.Button)(target));
            
            #line 696 "..\..\Services.xaml"
            this.btnpromoadd.Click += new System.Windows.RoutedEventHandler(this.btnpromoadd_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 711 "..\..\Services.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 622 "..\..\Services.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Editbtn_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 629 "..\..\Services.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Deletebtn_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 670 "..\..\Services.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditPromobtn_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 680 "..\..\Services.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeletePromobtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

