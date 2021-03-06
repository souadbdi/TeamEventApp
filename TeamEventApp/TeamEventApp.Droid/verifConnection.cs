﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TeamEventApp
{
    public class VerifConnection
    {

        public static bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";

            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);

                iNetRequest.Timeout = 5000;

                WebResponse iNetResponse = iNetRequest.GetResponse();

                // Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close();

                return true;

            }
            catch (WebException ex)
            {

                // Console.WriteLine (".....no connection..." + ex.ToString ());

                return false;
            }
        }

    }
}
