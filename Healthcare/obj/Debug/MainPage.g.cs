﻿#pragma checksum "D:\Project\C#\test\Healthcare\Healthcare\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BC2812E65159019457F4BF3CF1ABF94B"
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


namespace Healthcare {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.ResourceDictionary rd01;
        
        internal Microsoft.Phone.Controls.Panorama PanoramaMain;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Border BD_TBFrame;
        
        internal System.Windows.Controls.TextBox TBMainSearch;
        
        internal System.Windows.Controls.Button BTNSearch;
        
        internal System.Windows.Controls.Button BTN药品查询;
        
        internal System.Windows.Controls.Button BTN检查项目;
        
        internal System.Windows.Controls.Button BTN手术项目;
        
        internal System.Windows.Documents.Run TBVersion;
        
        internal System.Windows.Controls.ListBox LBInfo;
        
        internal System.Windows.Controls.ListBox LBLore;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Healthcare;component/MainPage.xaml", System.UriKind.Relative));
            this.rd01 = ((System.Windows.ResourceDictionary)(this.FindName("rd01")));
            this.PanoramaMain = ((Microsoft.Phone.Controls.Panorama)(this.FindName("PanoramaMain")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.BD_TBFrame = ((System.Windows.Controls.Border)(this.FindName("BD_TBFrame")));
            this.TBMainSearch = ((System.Windows.Controls.TextBox)(this.FindName("TBMainSearch")));
            this.BTNSearch = ((System.Windows.Controls.Button)(this.FindName("BTNSearch")));
            this.BTN药品查询 = ((System.Windows.Controls.Button)(this.FindName("BTN药品查询")));
            this.BTN检查项目 = ((System.Windows.Controls.Button)(this.FindName("BTN检查项目")));
            this.BTN手术项目 = ((System.Windows.Controls.Button)(this.FindName("BTN手术项目")));
            this.TBVersion = ((System.Windows.Documents.Run)(this.FindName("TBVersion")));
            this.LBInfo = ((System.Windows.Controls.ListBox)(this.FindName("LBInfo")));
            this.LBLore = ((System.Windows.Controls.ListBox)(this.FindName("LBLore")));
        }
    }
}

