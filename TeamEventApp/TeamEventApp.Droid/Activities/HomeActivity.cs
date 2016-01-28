
using Android.App;
using Android.OS;
using Android.Views;
using TeamEventApp.Droid.Activities;

namespace TeamEventApp.Droid
{
    [Activity(Label ="")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

        }

        // Adding the menu

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_home:
                    StartActivity(typeof(HomeActivity));
                    return true;

                case Resource.Id.action_profile:
                    StartActivity(typeof(ProfileActivity));
                    return true;

                case Resource.Id.action_event_manager:
                    StartActivity(typeof(EventManagerActivity));
                    return true;

                case Resource.Id.action_group_manager:
                    StartActivity(typeof(GroupManagerActivity));
                    return true;

                case Resource.Id.action_about:
                    StartActivity(typeof(EventActivity));
                    return true;

                case Resource.Id.action_settings:
                    StartActivity(typeof(SettingsActivity));
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}