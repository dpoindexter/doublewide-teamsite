using System;
using System.Collections.Generic;
using Doublewide.Domain.Entities;
using ServiceStack.DataAnnotations;

namespace Doublewide.Domain.Season
{
    public class Tournament : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Game> Games { get; set; }

        [Ignore]
        public string Dates
        {
            get
            {
                var endDateString = (StartDate.Month == EndDate.Month)
                                        ? EndDate.Day.ToString()
                                        : EndDate.ToString("MMM d");

                return StartDate.ToString("MMM d") + " - " + endDateString;
            }
        }
    }
}