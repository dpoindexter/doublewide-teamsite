using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doublewide.Domain.Entities;

namespace Doublewide.Domain.Entities.Team
{
    public class Player : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public Location PlaceOfBirth { get; set; }
        public Location CurrentResidence { get; set; }
        public string College { get; set; }
        public string Occupation { get; set; }
        public string FormerClubTeams { get; set; }
        public string HowIJoinedDoublewide { get; set; }
        public string FavoriteDoublewideMoment { get; set; }
        public string FavoriteActionMovie { get; set; }
        public string FavoriteOffseasonActivities { get; set; }
        public string SomethingUnique { get; set; }
        public string Nicknames { get; set; }
        public IEnumerable<int> Seasons { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int YearsPlayed
        {
            get { return Seasons.Count(); }
        }

        public string FormattedPhone
        {
            get { return String.Format("0:(nnn) nnn-nnnn", Phone); }
        }

        public string FormattedHeight
        {
            get { return String.Format("{0}'{1}", Height / 12, Height % 12); }
        }
    }

    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return City + ", " + State;
        }
    }
}