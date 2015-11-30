﻿/**
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited.
 * Copyright (c) 2015 51Degrees Mobile Experts Limited, 5 Charlotte Close,
 * Caversham, Reading, Berkshire, United Kingdom RG4 7BY
 * 
 * This Source Code Form is the subject of the following patent
 * applications, owned by 51Degrees Mobile Experts Limited of 5 Charlotte
 * Close, Caversham, Reading, Berkshire, United Kingdom RG4 7BY:
 * European Patent Application No. 13192291.6; and
 * United States Patent Application Nos. 14/085,223 and 14/085,301.
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0.
 * 
 * If a copy of the MPL was not distributed with this file, You can obtain
 * one at http://mozilla.org/MPL/2.0/.
 * 
 * This Source Code Form is "Incompatible With Secondary Licenses", as
 * defined by the Mozilla Public License, v. 2.0.
 */

/*
<tutorial>
Stronly typed example of using 51Degrees device detection. 
The example shows how to:
<ol>
<li>Set the data set for the 51Degrees detector
<p><code>
string fileName = args[0];<br>
DataSet dataSet = StreamFactory.Create(fileName, false);
</code></p>
<li>Instantiate the 51Degrees device detection provider
with these settings
<p><code>
Provider provider = new Provider(dataSet);
</code></p>
<li>Produce a match for a single HTTP User-Agent
<p><code>
match = provider.Match(userAgent);
</code></p>
<li>Extract the boolean value of the IsMobile property
<p><code>
if (match["IsMobile"] == "True")<br>
    return true;<br>
else<br>
    return false;
</code></p>
</ol>
This tutorial assumes you are building this from within the
51Degrees Visual Studio solution. Running the executable produced
inside Visual Studio will ensure all the command line arguments
are preset correctly. If you are running outside of Visual Studio,
make sure to add the path to a 51Degrees data file as an argument.
</tutorial>
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiftyOne.Foundation.Mobile.Detection;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using FiftyOne.Foundation.Mobile.Detection.Factories;

namespace FiftyOne.Example.Illustration.StronglyTyped
{
    public class Program
    {
        // Snippet Start
        public static void Run(string fileName)
        {
            Match match;
            bool IsMobileBool;
            DataSet dataSet = StreamFactory.Create(fileName, false);
            Provider provider = new Provider(dataSet);

            // User-Agent string of an iPhone mobile device.
            string mobileUserAgent = ("Mozilla/5.0 (iPhone; CPU iPhone " +
                "OS 7_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like " +
                "Gecko) 'Version/7.0 Mobile/11D167 Safari/9537.53");

            // User-Agent string of Firefox Web browser version 41 on dektop.
            string desktopUserAgent = ("Mozilla/5.0 (Windows NT 6.3; " +
                "WOW64; rv:41.0) Gecko/20100101 Firefox/41.0");

            // User-Agent string of a MediaHub device.
            string mediaHubUserAgent = ("Mozilla/5.0 (Linux; Android " +
                "4.4.2; X7 Quad Core Build/KOT49H) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 " +
                "Safari/537.36");

            Console.WriteLine("Starting Strongly Typed Example.");

            // Carries out a match for a mobile User-Agent.
            Console.WriteLine("\nMobile User-Agent: " + mobileUserAgent);
            match = provider.Match(mobileUserAgent);
            IsMobileBool = getIsMobileBool(match);
            if (IsMobileBool)
                Console.WriteLine("   Mobile");
            else
                Console.WriteLine("   Non-Mobile");

            // Carries out a match for a desktop User-Agent.
            Console.WriteLine("\nDesktop User-Agent: " + desktopUserAgent);
            match = provider.Match(desktopUserAgent);
            IsMobileBool = getIsMobileBool(match);
            if (IsMobileBool)
                Console.WriteLine("   Mobile");
            else
                Console.WriteLine("   Non-Mobile");

            // Carries out a match for a MediaHub User-Agent.
            Console.WriteLine("\nMediaHub User-Agent: " + mediaHubUserAgent);
            match = provider.Match(mediaHubUserAgent);
            IsMobileBool = getIsMobileBool(match);
            if (IsMobileBool)
                Console.WriteLine("   Mobile");
            else
                Console.WriteLine("   Non-Mobile");
        }

        /// <summary>
        /// Returns a boolean representation of the value associated with the 
        /// IsMobile property.
        /// </summary>
        /// <param name="match">a Match object</param>
        /// <returns>
        /// A boolean representation of the value for IsMobile
        /// </returns>        
        public static bool getIsMobileBool(Match match)
        {
            if (match["IsMobile"].ToString() == "True")
                return true;
            else
                return false;
        }

        // Snippet End

        static void Main(string[] args)
        {
            string fileName = args.Length > 0 ? args[0] : "../../../../../data/51Degrees-LiteV3.2.dat";
            Run(fileName);

            // Waits for a character to be pressed.
            Console.ReadKey();
        }
    }
}
