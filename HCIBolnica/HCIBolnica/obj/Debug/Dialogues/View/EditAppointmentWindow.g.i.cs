#pragma checksum "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0894E3ABC42A25EE44AFE3A38C01741ED7DC8E01675EF9FF26CA77761A0896F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCIBolnica.Dialogues.View;
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


namespace HCIBolnica.Dialogues.View {
    
    
    /// <summary>
    /// EditAppointmentWindow
    /// </summary>
    public partial class EditAppointmentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPatientName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbExaminationType;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbOperationRoom;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbAppointmetnTime;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerDateOfAppointment;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAppointementDuration;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAccept;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/HCIBolnica;component/dialogues/view/editappointmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dialogues\View\EditAppointmentWindow.xaml"
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
            this.cmbPatientName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cmbExaminationType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cmbOperationRoom = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cmbAppointmetnTime = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.datePickerDateOfAppointment = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtAppointementDuration = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnAccept = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

