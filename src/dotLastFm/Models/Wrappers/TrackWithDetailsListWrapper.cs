//-----------------------------------------------------------------------
// <copyright file="TopTagListWrapper.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotLastFm.Models.Wrappers
{
    using System.Collections.Generic;
    using RestSharp.Deserializers;

    /// <summary>
    /// Wrapper for Top Tags
    /// </summary>
    public class TrackWithDetailsListWrapper
    {
        /// <summary>
        /// Gets or sets the list of the tags.
        /// </summary>
        /// <value>
        /// The list of the tags.
        /// </value>
        [DeserializeAs(Name = "Results")]
        public TrackSearch TrackSearch
        {
            get;
            set;
        } 
    }
}
