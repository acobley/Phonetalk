﻿#pragma checksum "C:\Users\hacku\Documents\Visual Studio 2010\Projects\PhoneApp1\PhoneApp1\PanoramaPage1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6F20C5DEC41F467AC0C23BDFCEE7E8CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace PhoneApp1 {
    
    
    public partial class PanoramaPage1 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Panorama panoSpeech;
        
        internal System.Windows.Controls.ListBox ListLanguages;
        
        internal System.Windows.Controls.TextBox TextToSpeachText;
        
        internal System.Windows.Controls.Button btnSpeak;
        
        internal System.Windows.Controls.Image image1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/PanoramaPage1.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.panoSpeech = ((Microsoft.Phone.Controls.Panorama)(this.FindName("panoSpeech")));
            this.ListLanguages = ((System.Windows.Controls.ListBox)(this.FindName("ListLanguages")));
            this.TextToSpeachText = ((System.Windows.Controls.TextBox)(this.FindName("TextToSpeachText")));
            this.btnSpeak = ((System.Windows.Controls.Button)(this.FindName("btnSpeak")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
        }
    }
}

