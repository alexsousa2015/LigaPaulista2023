using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaPaulista.Core.Objects.Facebook
{
    public class Photos
    {
        public class From
        {
            public string category { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }

        public class Image
        {
            public int height { get; set; }
            public int width { get; set; }
            public string source { get; set; }
        }

        public class Location
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string zip { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Place
        {
            public string id { get; set; }
            public string name { get; set; }
            public Location location { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public From from { get; set; }
            public string picture { get; set; }
            public string source { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public List<Image> images { get; set; }
            public string link { get; set; }
            public string icon { get; set; }
            public Place place { get; set; }
            public string created_time { get; set; }
            public string updated_time { get; set; }
        }

        public class Cursors
        {
            public string after { get; set; }
            public string before { get; set; }
        }

        public class Paging
        {
            public Cursors cursors { get; set; }
            public string next { get; set; }
        }

        public class RootObject
        {
            public List<Datum> data { get; set; }
            public Paging paging { get; set; }
        }
    }
}
