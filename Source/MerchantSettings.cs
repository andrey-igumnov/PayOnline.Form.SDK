// <copyright file="MerchantSettings.cs" company="">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    using System;

    /// <summary>
    /// Represents merchant settings
    /// </summary>
    public sealed class MerchantSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantSettings"/> class
        /// </summary>
        /// <param name="merchantId">Identification code</param>
        /// <param name="key">Payment key</param>
        public MerchantSettings(int merchantId, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            this.MerchantId = merchantId;
            this.Key = key;
        }

        /// <summary>
        /// Gets identification code, assigned by PayOnline
        /// </summary>
        internal int MerchantId { get; }

        /// <summary>
        /// Gets merchant payment key
        /// </summary>
        internal string Key { get; }
    }
}
