﻿//-----------------------------------------------------------------------
// <copyright file="RestWrapperTest.cs" company="IxoneCz">
//  Copyright (c) 2011 Tomas Pastorek, www.Ixone.Cz. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotLastFm.IntegrationTests
{
    using System.Net;
    using DotLastFm.Api;
    using DotLastFm.Api.Rest;
    using DotLastFm.Models.Wrappers;
    using Moq;
    using Xunit;

    /// <summary>
    /// Rest wrapper test
    /// </summary>
    public class RestWrapperTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestWrapperTest"/> class.
        /// </summary>
        public RestWrapperTest()
        {
            this.Wrapper = new RestWrapper(new TestLastFmConfig());
        }

        /// <summary>
        /// Gets or sets the wrapper.
        /// </summary>
        /// <value>
        /// The wrapper.
        /// </value>
        private RestWrapper Wrapper
        {
            get;
            set;
        }

        /// <summary>
        /// Rest wrapper's the success call.
        /// </summary>
        [Fact]
        public void RestSuccessCall()
        {
            var result = this.Wrapper.Method("track.getTopTags")
                            .AddParam("artist", "Moby")
                            .AddParam("track", "Porcelain")
                            .AddParam("autocorrect", "0").Execute<TopTagListWrapper>();

            Assert.NotNull(result);
            Assert.NotNull(result.Tags);
            Assert.True(result.Tags.Count > 0);
        }

        /// <summary>
        /// Rests the last fm exception.
        /// </summary>
        [Fact]
        public void RestLastFmException()
        {
            Assert.Throws<LastFmApiException>(() => this.Wrapper.Method("track.non-existing-method").Execute<TopTagListWrapper>());
        }

        /// <summary>
        /// Rest wrapper throws the WebException.
        /// </summary>
        [Fact]
        public void RestWebException()
        {
            var configMock = new Mock<ILastFmConfig>();
            configMock.Setup(a => a.BaseUrl).Returns("http://blablainvalidtotalerrorurl.last.fm");
            configMock.Setup(a => a.ApiKey).Returns("somekey");
            configMock.Setup(a => a.Secret).Returns("somesecret");

            var w = new RestWrapper(configMock.Object);

            Assert.Throws<WebException>(() => w.Method("track.getTopTags").Execute<TopTagListWrapper>());
        }
    }
}
