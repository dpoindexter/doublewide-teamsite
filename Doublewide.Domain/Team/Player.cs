using System;
using System.Collections.Generic;
using System.Linq;
using Doublewide.Domain.Entities;
using ServiceStack.DataAnnotations;

namespace Doublewide.Domain.Team
{
    public class Player : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
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
        public bool? IsCaptain { get; set; }

        [Ignore]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [Ignore]
        public string NameForRoute
        {
            get { return String.Format("{0}-{1}", FirstName.ToLowerInvariant(), LastName.ToLowerInvariant()); }
        }

        [Ignore]
        public int YearsPlayed
        {
            get { return Seasons.Count(); }
        }

        [Ignore]
        public string FormattedPhone
        {
            get { return Phone.ToString("(###) ###-####"); }
        }

        [Ignore]
        public string FormattedHeight
        {
            get { return String.Format("{0}'{1}", (Height / 12), (Height % 12)); }
        }

        [Ignore]
        public string Age
        {
            get
            {
                var age = 0;
                if (DateOfBirth.HasValue)
                {
                    var now = DateTime.Now;
                    var dob = DateOfBirth.Value;
                    age = now.Year - dob.Year;
                    if (now.Month < dob.Month || (now.Month == dob.Month && now.Day < dob.Day)) age--;
                }
                return (age == 0) ? age.ToString() : "No one knows";
            }
        }

        [Ignore]
        public string FormattedPlaceOfBirth
        {
            get { return PlaceOfBirth.ToString(); }
        }

        [Ignore]
        public string FormattedCurrentResidence
        {
            get { return CurrentResidence.ToString(); }
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