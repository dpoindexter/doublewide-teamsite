using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doublewide.Domain.Entities;

namespace Doublewide.Domain.Entities.Team
{
    public class Player : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Nickname { get; set; }
        public virtual int JerseyNumber { get; set; }
        public virtual IEnumerable<int> Seasons { get; set; }

        public virtual string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual int YearsPlayed
        {
            get { return Seasons.Count(); }
        }
    }
}