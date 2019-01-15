using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TRPO
{
    [DataContract]
    public class Week
    {
        [DataMember]
        public List<Day> week;
        public static int dayCount = 6;

        public Week(List<Day> week)
        {
            this.week = week;
        }
    }
}