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

namespace TeamEventApp.Droid.Activities
{
    [Activity(Label = "CreateEventActivity")]
    public class CreateEventActivity : Activity
    {
        private DateTime _date;
        private DateTime _time;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private TextView startDate;
        private TextView startHour;
        private TextView endDate;
        private TextView endHour;

        // Listes
        private List<string> groupList;

        private const int DATE_DIALOG_ID = 0;
        private const int TIME_DIALOG_ID = 1;

        //
        private bool isStartDateClicked = true;
        private bool isStartTimeClicked = true;

        private string _dateFormat = "dd MMM yyyy";
        private string _timeFormat = "H:mm";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EventCreationForm);

            // Set views
            startDate = FindViewById<TextView>(Resource.Id.event_startDate_text);
            startHour = FindViewById<TextView>(Resource.Id.event_startHour_text);
            endDate = FindViewById<TextView>(Resource.Id.event_endDate_text);
            endHour = FindViewById<TextView>(Resource.Id.event_endHour_text);


            Spinner groupSpinner = FindViewById<Spinner>(Resource.Id.event_group_spinner);

            // Groupe liste
            groupList = new List<string>();
            groupList.Add("Friends");
            groupList.Add("School classmates");
            groupList.Add("Family");
            groupList.Add("Les potos du 78");

            // Set the adapter
            ArrayAdapter<string> spinnerAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, groupList);

            if (groupSpinner != null)
                groupSpinner.Adapter = spinnerAdapter;

            // Connecting the action of the fragment datepicker
            if (startDate != null)
                startDate.Click += delegate
                {
                    isStartDateClicked = true;
                    ShowDialog(DATE_DIALOG_ID);
                };

            if (endDate != null)
                endDate.Click += delegate
                {
                    isStartDateClicked = false;
                    ShowDialog(DATE_DIALOG_ID);
                };

            // Connectiong action of the fragment timepicker

            if (startHour != null)
                startHour.Click += delegate
                {
                    isStartTimeClicked = true;
                    ShowDialog(TIME_DIALOG_ID);
                };

            if (endHour != null)
                endHour.Click += delegate
                {
                    isStartTimeClicked = false;
                    ShowDialog(TIME_DIALOG_ID);
                };

            // Setting today's date and time
            _date = DateTime.Today;
            _time = DateTime.Today;

            // On stocke les heure du d�but et de fin
            startDateTime = DateTime.Today;
            endDateTime = DateTime.Today;

            startDate.Text = _date.ToString(_dateFormat);
            startHour.Text = _time.ToString(_timeFormat);

        }


        // Fonction OnCreateDialog
        protected override Dialog OnCreateDialog(int id)
        {

            switch(id)
            {
                case DATE_DIALOG_ID:
                    return new DatePickerDialog(this, HandleDateSet, this._date.Year,
                   this._date.Month - 1, this._date.Day);

                case TIME_DIALOG_ID:
                    return new TimePickerDialog(this, HandleTimeSet, this._time.Hour,
                   this._time.Minute - 1, false);

                default:
                    return null;
            }

            
        }

        // Action date handler
        private void HandleDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            this. _date = e.Date;


            // Si on a cliqu� sur la date de d�but
            if (isStartDateClicked)
            {
                var textView = FindViewById<TextView>(Resource.Id.event_startDate_text);
                textView.Text = this._date.ToString(_dateFormat);

                // le changement de l'heure du d�but met � jour celui de la fin
                var textView2 = FindViewById<TextView>(Resource.Id.event_endDate_text);
                textView2.Text = this._date.ToString(_dateFormat);

                // On r�initialise les dates de d�but et de fin
                startDateTime = new DateTime(_date.Year, _date.Month, _date.Day, _date.Hour, _date.Minute, 0);
                endDateTime = new DateTime(_date.Year, _date.Month, _date.Day, _date.Hour, _date.Minute, 0);
            }

            // Si on a cliqu� sur la date de fin
            else
            {
                var textView = FindViewById<TextView>(Resource.Id.event_endDate_text);
                textView.Text = this._date.ToString(_dateFormat);

                // On r�initialise la date de fin
                endDateTime = new DateTime(_date.Year, _date.Month, _date.Day, _date.Hour, _date.Minute, 0);
            }
        }

        // Action time handler
        private void HandleTimeSet(object sender, TimePickerDialog.TimeSetEventArgs e)
        {

            // Si on a cliqu� sur l'heure de d�but
            if (isStartTimeClicked)
            {
                // On r�initialise l'heure du d�but dans la date de d�but
                startDateTime = new DateTime(startDateTime.Year, startDateTime.Month,
                    startDateTime.Day, e.HourOfDay, e.Minute, 0);

                var textView = FindViewById<TextView>(Resource.Id.event_startHour_text);
                textView.Text = this.startDateTime.ToString(_timeFormat);
            }

            else
            {
                endDateTime = new DateTime(endDateTime.Year, endDateTime.Month,
                    endDateTime.Day, e.HourOfDay, e.Minute, 0);

                var textView = FindViewById<TextView>(Resource.Id.event_endHour_text);
                textView.Text = this.endDateTime.ToString(_timeFormat);
            }

        }

    }
}