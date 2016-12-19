// <copyright file="RedirectParameters.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    using System;

    /// <summary>
    /// Represents redirect information, such as return URL and fail URL
    /// </summary>
    public sealed class RedirectParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectParameters"/> class
        /// </summary>
        /// <param name="returnUrl">Absolute URL address that will be sent to the payer after completion of payment</param>
        /// <param name="failUrl">Absolute URL address that will be sent to the payer, in case it is impossible to make a payment</param>
        public RedirectParameters(Uri returnUrl = null, Uri failUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.FailUrl = failUrl;
        }

        /// <summary>
        /// Gets absolute URL address that will be sent to the payer after completion of payment
        /// </summary>
        internal Uri ReturnUrl { get; }

        /// <summary>
        /// Gets absolute URL address that will be sent to the payer, in case it is impossible to make a payment
        /// </summary>
        internal Uri FailUrl { get; }
    }
}
