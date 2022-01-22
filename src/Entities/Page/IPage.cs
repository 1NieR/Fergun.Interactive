﻿using System.Collections.Generic;
using Discord;

namespace Fergun.Interactive
{
    /// <summary>
    /// Represents a page used in an interactive element.
    /// </summary>
    /// <typeparam name="TEmbed">The type of the embeds.</typeparam>
    public interface IPage<out TEmbed> where TEmbed : IEmbed
    {
        /// <summary>
        /// Gets the text (content) of this page.
        /// </summary>
        string? Text { get; }

        /// <summary>
        /// Gets the embeds of this page.
        /// </summary>
        IReadOnlyCollection<TEmbed> Embeds { get; }
    }

    /// <inheritdoc/>
    public interface IPage : IPage<Embed> // Unfortunately we have to use Embed here because we can't send or modify messages using IEmbed.
    {
        /// <summary>
        /// Gets the array of <see cref="Embed"/> of this page.
        /// </summary>
        /// <remarks>This is used for sending and modifying messages via Discord.Net, since it requires an array of <see cref="Embed"/>.</remarks>
        /// <returns>An <see cref="Embed"/>[].</returns>
        Embed[] GetEmbedArray();
    }
}