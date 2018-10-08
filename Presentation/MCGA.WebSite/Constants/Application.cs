using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.WebSite.Constants
{
    public class Application
    {
        public const string Name = "Clinica de embazos";
        public const string ShortName = "Clinica";
        public const int SeoDescriptionLength = 260;
        public const string Email = "info@cardio.com";
        public const string Phone = "(+91 123) 4567 789";
        public const string StreetAddress = "Wakanda 32";
        public const string Locality = "Asgard";
        public const string PostalCode = "1251";
        public const string Country = "Argentina";

        public const double Latitude = -69.667308627965596;
        public const double Longitude = -34.49549933992794;

        public static string Url => HttpContext.Current.Request.Url.AbsoluteUri;
    }
}