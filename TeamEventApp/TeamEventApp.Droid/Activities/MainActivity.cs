using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace TeamEventApp.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Activity
	{
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Set the DB

            initDataBase();

            // Vérification de la connexion
            VerifyConnection();

        }

        // Initialisation de la BDD

        private void initDataBase()
        {

            // Users
            User user1 = new User("Pierre", "Mack", "pierre256", "pierre@yahoo.fr", "pass");
            DataBase.Inscription(user1);

            User user2 = new User("Pierre", "Herpos", "pihops", "pierre_herpos@yahoo.fr", "pass");
            DataBase.Inscription(user2);

            User user3 = new User("Louange", "Bzb", "hesrondev", "mail@yahoo.fr", "pass");
            DataBase.Inscription(user3);

            User user4 = new User("Souad", "Bdi", "souad78", "wanda@yahoo.fr", "pass");
            DataBase.Inscription(user4);

            User user5 = new User("Anthony", "Lammens", "anto88", "anto@yahoo.fr", "pass");
            DataBase.Inscription(user5);

            User user6 = new User("Michel", "LAMMENS", "mimi.lams", "mimi@yahoo.fr", "pass");
            DataBase.Inscription(user6);

            // Groups

            Group group1 = new Group("FRIENDS", user1);
            DataBase.CreateGroup(group1);
            group1.addMember(user2);
            group1.addMember(user3);
            group1.addMember(user4);

            Group group2 = new Group("School Classmates", user1);
            DataBase.CreateGroup(group2);
            group2.addMember(user6);
            group2.addMember(user3);
            group2.addMember(user4);

            Group group3 = new Group("School Classmates", user3);
            DataBase.CreateGroup(group3);
            group3.addMember(user6);
            group3.addMember(user3);
            group3.addMember(user4);

            // Events

            Event ev1 = new Event {
                userAdmin = user3,
                groupId = group1.groupId,
                eventName = "AGAPE",
                description = "Temps de partage",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                address = "Paris, France"
                };
            
            DataBase.CreateEvent(ev1);

            Event ev2 = new Event {
                userAdmin = user1,
                groupId = group1.groupId,
                eventName = "Sortie Bowling",
                description = "Temps de détente",
            startDate = DateTime.Now,
                endDate = DateTime.Now,
                address = "Paris, France"
            };
            DataBase.CreateEvent(ev2);

            Event ev3 = new Event
            {
                userAdmin = user3,
                groupId = group2.groupId,
                eventName = "DEV Cours",
                description = "Cours CM 11",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                address = "Paris, France"
            };
            DataBase.CreateEvent(ev3);

            Event ev4 = new Event {
                userAdmin = user3,
                groupId = group1.groupId,
                eventName = "Soutenance MASTER II",
                description = "Fin d'études",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                address = "Belgique"
            };
            DataBase.CreateEvent(ev4);

            Event ev5 = new Event {
                userAdmin = user3,
                groupId = group3.groupId,
                eventName = "Soirée Ciné",
                description = "Movie with parents... #dontMiss",
                startDate = DateTime.Now,
                endDate = DateTime.Now,
                address = "Saint-Quention en Yvelines, France"
            };
            DataBase.CreateEvent(ev5);



        }

        /*
        protected override void OnStart()
        {
            base.OnStart();
            VerifyConnection();
        }*/

        protected override void OnResume()
        {
            base.OnResume();
            VerifyConnection();
        }


        // On vérifie si l'utilisateur est connecté
        private void VerifyConnection()
        {
            
            if (!DataBase.connected)
                StartActivity(typeof(LoginActivity));
        }
    }
}


