using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotLastFm.Models
{
    public class TrackSearch
    {
        [DeserializeAs(Name = "trackmatches")]
        public List<TrackSearchDetail> Tracks { get; set; }
    }

    public class TrackSearchDetail: Track
    {
        public String Artist { get; set; }

        public List<Image> Images { get; set; }
    }
}
