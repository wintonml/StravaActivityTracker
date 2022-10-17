using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StravaActivities
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Enter access token");
            string access_token = Console.ReadLine();
            StravaInformation strava = new StravaInformation(access_token);
            Athlete test = await strava.GetAthlete();
            Console.WriteLine($"This Access Token belongs to: {test.FirstName} {test.LastName}");
        }
    }
}