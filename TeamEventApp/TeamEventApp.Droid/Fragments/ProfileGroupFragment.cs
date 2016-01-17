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

namespace TeamEventApp.Droid.Fragments
{
    class ProfileGroupFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.ProfileFragment, container, false);
            var sampleText = view.FindViewById<TextView>(Resource.Id.profile_fragmentList);
            sampleText.Text = "Group Sample Text !";

            return View;
        }
    }
}