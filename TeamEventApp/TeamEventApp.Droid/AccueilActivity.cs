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

namespace TeamEventApp.Droid
{
    [Activity(Label = "Accueil")]
    public class AccueilActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "accueil" layout resource
            SetContentView(Resource.Layout.Accueil);

            // Create your application here

            Button agbutton = FindViewById<Button>(Resource.Id.addGroupButton);

            agbutton.Click += delegate {
                Intent intent = new Intent(this.ApplicationContext, typeof(AddGroupActivity));
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            };
        }
    }
}