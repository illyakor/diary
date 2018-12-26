using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TRPO
{
    [DataContract]
    public class Day
    {
        [DataMember]
        public List<string> day = new List<string>(8);

        public Day(List<string> day)
        {
            this.day = day;
        }
    }
}