﻿#pragma checksum "D:\Project\C#\test\Healthcare\Healthcare\MyUserControl\ItemControlHttp.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "30332245458B08A105BF49FDCAF15409"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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
    
    
    public partial class ItemControlHttp : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid ItemBlock;
        
        internal System.Windows.Controls.TextBlock TBTitle;
        
        internal System.Windows.Controls.Primitives.ToggleButton BTNFlip;
        
        internal Microsoft.Phone.Controls.WebBrowser WBCon;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Healthcare;component/MyUserControl/ItemControlHttp.xaml", System.UriKind.Relative));
            this.ItemBlock = ((System.Windows.Controls.Grid)(this.FindName("ItemBlock")));
            this.TBTitle = ((System.Windows.Controls.TextBlock)(this.FindName("TBTitle")));
            this.BTNFlip = ((System.Windows.Controls.Primitives.ToggleButton)(this.FindName("BTNFlip")));
            this.WBCon = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("WBCon")));
        }
    }
}

