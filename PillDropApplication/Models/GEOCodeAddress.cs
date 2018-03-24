using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;

namespace PillDropApplication.Models
{
    public static class GeoCodeAddress
    {
        public static dynamic CodeAddress(string Address)
        {
            var address = string.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", Address.Replace(" ", "+"));
            var result = new System.Net.WebClient().DownloadString(address);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<dynamic>(result);
        }
        public static string GetLatiLongitude(string address)
        {
            StreamReader reader = null;
            var url = string.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false", address.Replace(" ", "+"));
            var wc = new System.Net.WebClient();
            var latitude = string.Empty;
            var longitude = string.Empty;

            try
            {
                reader = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                var xmlReader = new XmlTextReader(reader);
                var latread = false;
                var longread = false;

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();
                                latitude = xmlReader.Value.ToString();
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                longitude = xmlReader.Value.ToString();
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }

            return latitude;
        }
    }
}