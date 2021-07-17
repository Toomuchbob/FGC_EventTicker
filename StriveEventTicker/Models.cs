using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StriveEventTicker
{
    class Data
    {
        public Tournaments Tournaments { get; set; }
    }

    class Tournaments
    {
        public List<Tournament> Nodes { get; set; }
    }

    class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool IsOnline { get; set; }
        public string Slug { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime? EventRegistrationClosesAt { get; set; }
        public string Hashtag { get; set; }
        public List<Event> Events { get; set; }
        public List<Stream> Streams { get; set; }
    }

    class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isOnline { get; set; }
        public int? NumOfEntrants { get; set; }
        public int? EntrantSizeMax { get; set; }
        public DateTime StartAt { get; set; }
        public Videogame Videogame { get; set; }
    }

    class Videogame
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Stream
    {
        public int Id { get; set; }
        public bool IsOnline { get; set; }
        public string StreamName { get; set; }
        public string StreamSource { get; set; }
    }

}
