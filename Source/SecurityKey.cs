// <copyright file="SecurityKey.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    using System;
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Represents utility class for security key generation
    /// </summary>
    internal sealed class SecurityKey
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityKey"/> class
        /// </summary>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        internal SecurityKey(MerchantSettings merchantSettings, OrderInfo orderInfo)
        {
            if (merchantSettings == null)
            {
                throw new ArgumentNullException(nameof(merchantSettings));
            }

            if (orderInfo == null)
            {
                throw new ArgumentNullException(nameof(orderInfo));
            }

            this.Value = CalculateKey(merchantSettings, orderInfo);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityKey"/> class
        /// </summary>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <param name="transactionId">Transaction unique identifier</param>
        /// <param name="transactionDateTime">Transaction date time</param>
        internal SecurityKey(MerchantSettings merchantSettings, OrderInfo orderInfo, int transactionId, DateTime transactionDateTime)
        {
            if (merchantSettings == null)
            {
                throw new ArgumentNullException(nameof(merchantSettings));
            }

            if (orderInfo == null)
            {
                throw new ArgumentNullException(nameof(orderInfo));
            }

            this.Value = CalculateKey(merchantSettings, orderInfo, transactionId, transactionDateTime);
        }

        /// <summary>
        /// Gets security key
        /// </summary>
        internal string Value { get; }

        /// <summary>
        /// Calculates security key
        /// </summary>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <returns>Security key</returns>
        private static string CalculateKey(MerchantSettings merchantSettings, OrderInfo orderInfo)
        {
            var merchantIdChunk = FormattableString.Invariant($"MerchantId={merchantSettings.MerchantId}");

            var orderIdChunk = FormattableString.Invariant($"&OrderId={orderInfo.OrderId}");

            var amountChunk = FormattableString.Invariant($"&Amount={orderInfo.Amount.ToString("#.00", CultureInfo.InvariantCulture)}");

            var currencyChunk = FormattableString.Invariant($"&Currency={orderInfo.Currency.ToUpperInvariant()}");

            var validUtilChunk = orderInfo.ValidUntil.HasValue
                ? FormattableString.Invariant($"&ValidUntil={orderInfo.ValidUntil.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}")
                : string.Empty;

            var orderDescriptionChunk = string.IsNullOrEmpty(orderInfo.OrderDecription)
                ? string.Empty
                : FormattableString.Invariant($"&OrderDescription={orderInfo.OrderDecription}");

            var keyChunk = FormattableString.Invariant($"&PrivateSecurityKey={merchantSettings.Key}");

            return CalculateMd5Hash(FormattableString.Invariant($"{merchantIdChunk}{orderIdChunk}{amountChunk}{currencyChunk}{validUtilChunk}{orderDescriptionChunk}{keyChunk}"));
        }

        /// <summary>
        /// Calculates security key
        /// </summary>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <param name="transactionId">Transaction unique identifier</param>
        /// <param name="transactionDateTime">Transaction date time</param>
        /// <returns>Security key</returns>
        private static string CalculateKey(MerchantSettings merchantSettings, OrderInfo orderInfo, int transactionId, DateTime transactionDateTime)
        {
            var datetimeChunk = FormattableString.Invariant($"DateTime={transactionDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");

            var transactiondIdChunk = FormattableString.Invariant($"&TransactionID={transactionId}");

            var orderIdChunk = FormattableString.Invariant($"&OrderId={orderInfo.OrderId}");

            var amountChunk = FormattableString.Invariant($"&Amount={orderInfo.Amount.ToString("#.00", CultureInfo.InvariantCulture)}");

            var currencyChunk = FormattableString.Invariant($"&Currency={orderInfo.Currency.ToUpperInvariant()}");

            var keyChunk = FormattableString.Invariant($"&PrivateSecurityKey={merchantSettings.Key}");

            return CalculateMd5Hash(FormattableString.Invariant($"{datetimeChunk}{transactiondIdChunk}{orderIdChunk}{amountChunk}{currencyChunk}{keyChunk}"));
        }

        /// <summary>
        /// Calculates MD5 hash of string
        /// </summary>
        /// <param name="query">Sting to hash</param>
        /// <returns>MD5 hash</returns>
        private static string CalculateMd5Hash(string query)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query));
                var stringBuilder = new StringBuilder();
                foreach (var hashByte in hashBytes)
                {
                    stringBuilder.Append(hashByte.ToString("x2", CultureInfo.InvariantCulture));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
