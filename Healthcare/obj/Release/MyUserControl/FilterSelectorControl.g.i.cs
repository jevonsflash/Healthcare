﻿#pragma checksum "D:\Project\C#\test\Healthcare\Healthcare\MyUserControl\FilterSelectorControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "080FAB39F4D563A8B096526CE790CE80"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Healthcare.MyUserControl {
    
    
    public partial class FilterSelectorControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock Title;
        
        internal System.Windows.Controls.ListBox LBSelector1;
        
        internal System.Windows.Controls.ListBox LBSelector2;
        
        internal System.Windows.Controls.Button BTNMore;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Healthcare;component/MyUserControl/FilterSelectorControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Title = ((System.Windows.Controls.TextBlock)(this.FindName("Title")));
            this.LBSelector1 = ((System.Windows.Controls.ListBox)(this.FindName("LBSelector1")));
            this.LBSelector2 = ((System.Windows.Controls.ListBox)(this.FindName("LBSelector2")));
            this.BTNMore = ((System.Windows.Controls.Button)(this.FindName("BTNMore")));
        }
    }
}
