﻿
namespace NomadCode.BotFramework
{
    using Newtonsoft.Json;
    using NomadCode.BotFramework;
    using System.Linq;

    /// <summary>
    /// GeoCoordinates (entity type: "https://schema.org/GeoCoordinates")
    /// </summary>
    public partial class GeoCoordinates
    {
        /// <summary>
        /// Initializes a new instance of the GeoCoordinates class.
        /// </summary>
        public GeoCoordinates()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GeoCoordinates class.
        /// </summary>
        /// <param name="elevation">Elevation of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)</param>
        /// <param name="latitude">Latitude of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)</param>
        /// <param name="longitude">Longitude of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)</param>
        /// <param name="type">The type of the thing</param>
        /// <param name="name">The name of the thing</param>
        public GeoCoordinates(double? elevation = default(double?), double? latitude = default(double?), double? longitude = default(double?), string type = default(string), string name = default(string))
        {
            Elevation = elevation;
            Latitude = latitude;
            Longitude = longitude;
            Type = type;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets elevation of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)
        /// </summary>
        [JsonProperty(PropertyName = "elevation")]
        public double? Elevation { get; set; }

        /// <summary>
        /// Gets or sets latitude of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude of the location [WGS
        /// 84](https://en.wikipedia.org/wiki/World_Geodetic_System)
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the type of the thing
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the thing
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
