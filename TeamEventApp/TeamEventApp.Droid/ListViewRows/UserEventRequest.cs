using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TeamEventApp.Droid.ListViewRows
{
    class UserEventRequest
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Date { get; set; }
    }
}