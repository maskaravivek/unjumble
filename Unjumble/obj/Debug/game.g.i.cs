﻿#pragma checksum "C:\Users\sony\Documents\Visual Studio 2012\Projects\Unjumble\Unjumble\game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F1656F855C0D469BFCA0262E611B4FFB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Phone.Controls.Toolkit;
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


namespace Unjumble {
    
    
    public partial class game : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Image life1;
        
        internal System.Windows.Controls.Image life3;
        
        internal System.Windows.Controls.Image life2;
        
        internal System.Windows.Controls.Image skip2;
        
        internal System.Windows.Controls.Image skip1;
        
        internal System.Windows.Controls.Image life3_Copy1;
        
        internal System.Windows.Controls.TextBlock user_score;
        
        internal System.Windows.Controls.Image skip;
        
        internal System.Windows.Controls.TextBlock hint;
        
        internal System.Windows.Controls.Image skip2_Copy;
        
        internal System.Windows.Controls.TextBlock lvl;
        
        internal System.Windows.Controls.TextBlock answer;
        
        internal Coding4Fun.Phone.Controls.Toolkit.TimeSpanPicker timeSpan;
        
        internal System.Windows.Controls.TextBlock title;
        
        internal System.Windows.Controls.TextBlock ans;
        
        internal System.Windows.Controls.TextBlock question;
        
        internal System.Windows.Controls.ListBox list1;
        
        internal System.Windows.Controls.TextBlock token_disp;
        
        internal System.Windows.Controls.Canvas canv;
        
        internal System.Windows.Controls.TextBlock txt1;
        
        internal System.Windows.Controls.TextBox name;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Unjumble;component/game.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.life1 = ((System.Windows.Controls.Image)(this.FindName("life1")));
            this.life3 = ((System.Windows.Controls.Image)(this.FindName("life3")));
            this.life2 = ((System.Windows.Controls.Image)(this.FindName("life2")));
            this.skip2 = ((System.Windows.Controls.Image)(this.FindName("skip2")));
            this.skip1 = ((System.Windows.Controls.Image)(this.FindName("skip1")));
            this.life3_Copy1 = ((System.Windows.Controls.Image)(this.FindName("life3_Copy1")));
            this.user_score = ((System.Windows.Controls.TextBlock)(this.FindName("user_score")));
            this.skip = ((System.Windows.Controls.Image)(this.FindName("skip")));
            this.hint = ((System.Windows.Controls.TextBlock)(this.FindName("hint")));
            this.skip2_Copy = ((System.Windows.Controls.Image)(this.FindName("skip2_Copy")));
            this.lvl = ((System.Windows.Controls.TextBlock)(this.FindName("lvl")));
            this.answer = ((System.Windows.Controls.TextBlock)(this.FindName("answer")));
            this.timeSpan = ((Coding4Fun.Phone.Controls.Toolkit.TimeSpanPicker)(this.FindName("timeSpan")));
            this.title = ((System.Windows.Controls.TextBlock)(this.FindName("title")));
            this.ans = ((System.Windows.Controls.TextBlock)(this.FindName("ans")));
            this.question = ((System.Windows.Controls.TextBlock)(this.FindName("question")));
            this.list1 = ((System.Windows.Controls.ListBox)(this.FindName("list1")));
            this.token_disp = ((System.Windows.Controls.TextBlock)(this.FindName("token_disp")));
            this.canv = ((System.Windows.Controls.Canvas)(this.FindName("canv")));
            this.txt1 = ((System.Windows.Controls.TextBlock)(this.FindName("txt1")));
            this.name = ((System.Windows.Controls.TextBox)(this.FindName("name")));
        }
    }
}

