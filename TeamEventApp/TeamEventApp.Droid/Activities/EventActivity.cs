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

using TeamEventApp.Droid.Fragments;

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "@string/label_infos_event")]
    public class EventActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventLayout);

            /*View view = RadioGroup.Inflate(this, Resource.Id.event_status_radioGroup, null);

            // Radio buttons

            RadioButton yesRadio = FindViewById<RadioButton>(Resource.Id.event_yes_radio);
            RadioButton noRadio = FindViewById<RadioButton>(Resource.Id.event_no_radio);
            RadioButton maybeRadio = FindViewById<RadioButton>(Resource.Id.event_maybe_radio);

            yesRadio.Click += RadioButtonClick;
            noRadio.Click += RadioButtonClick;
            maybeRadio.Click += RadioButtonClick;*/

        }

        // Event endler
        private void RadioButtonClick (object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }


    }
}