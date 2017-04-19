﻿
namespace NomadCode.BotFramework
{
    using Newtonsoft.Json;
    using NomadCode.BotFramework;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A Hero card (card with a single, large image)
    /// </summary>
    public partial class HeroCard
    {
        /// <summary>
        /// Initializes a new instance of the HeroCard class.
        /// </summary>
        public HeroCard()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HeroCard class.
        /// </summary>
        /// <param name="title">Title of the card</param>
        /// <param name="subtitle">Subtitle of the card</param>
        /// <param name="text">Text for the card</param>
        /// <param name="images">Array of images for the card</param>
        /// <param name="buttons">Set of actions applicable to the current
        /// card</param>
        /// <param name="tap">This action will be activated when user taps on
        /// the card itself</param>
        public HeroCard(string title = default(string), string subtitle = default(string), string text = default(string), IList<CardImage> images = default(IList<CardImage>), IList<CardAction> buttons = default(IList<CardAction>), CardAction tap = default(CardAction))
        {
            Title = title;
            Subtitle = subtitle;
            Text = text;
            Images = images;
            Buttons = buttons;
            Tap = tap;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets title of the card
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets subtitle of the card
        /// </summary>
        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets text for the card
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets array of images for the card
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public IList<CardImage> Images { get; set; }

        /// <summary>
        /// Gets or sets set of actions applicable to the current card
        /// </summary>
        [JsonProperty(PropertyName = "buttons")]
        public IList<CardAction> Buttons { get; set; }

        /// <summary>
        /// Gets or sets this action will be activated when user taps on the
        /// card itself
        /// </summary>
        [JsonProperty(PropertyName = "tap")]
        public CardAction Tap { get; set; }

    }
}
