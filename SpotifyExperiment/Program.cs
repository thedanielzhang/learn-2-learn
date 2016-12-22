using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Auth; //All Authentication-related classes
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses
using System.Windows.Forms;

namespace SpotifyExperiment
{

    class Program
    {
        private static SpotifyWebAPI _spotify;

        static void Main(string[] args)
        {
            initialSetup();
            if (_spotify == null)
                return;
            FullTrack track = _spotify.GetTrack("3Hvu1pq89D4R0lyPBoujSv");
            Console.WriteLine(track.Name);
            Console.ReadKey();
        }

        public static async void initialSetup()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
            "http://google.com",
            80,
            "e8fa55dbd4f74d68802fb6c67ab04105",
            Scope.UserReadPrivate,
            TimeSpan.FromSeconds(20)
            );

            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
