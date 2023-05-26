using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LigaPaulista.Core.Objects.Facebook
{
    public class Albuns
{
    public class From
    {
        public string category { get; set; }
        public string name { get; set; }
        public string id { get; set; }
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

    public class Datum2
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Cursors
    {
        public string after { get; set; }
        public string before { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class Likes
    {
        public List<Datum2> data { get; set; }
        public Paging paging { get; set; }
    }

    public class From2
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Datum3
    {
        public string id { get; set; }
        public From2 from { get; set; }
        public string message { get; set; }
        public bool can_remove { get; set; }
        public string created_time { get; set; }
        public int like_count { get; set; }
        public bool user_likes { get; set; }
    }

    public class Cursors2
    {
        public string after { get; set; }
        public string before { get; set; }
    }

    public class Paging2
    {
        public Cursors2 cursors { get; set; }
    }

    public class Comments
    {
        public List<Datum3> data { get; set; }
        public Paging2 paging { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public From from { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public Place place { get; set; }
        public string link { get; set; }
        public string cover_photo { get; set; }
        public string privacy { get; set; }
        public int count { get; set; }
        public string type { get; set; }
        public string created_time { get; set; }
        public string updated_time { get; set; }
        public bool can_upload { get; set; }
        public Likes likes { get; set; }
        public Comments comments { get; set; }
    }

    public class Cursors3
    {
        public string after { get; set; }
        public string before { get; set; }
    }

    public class Paging3
    {
        public Cursors3 cursors { get; set; }
    }

    public class RootObject
    {
        public List<Datum> data { get; set; }
        //public Paging3 paging { get; set; }
    }
}
}
