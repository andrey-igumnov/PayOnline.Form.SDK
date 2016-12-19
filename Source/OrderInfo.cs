// <copyright file="OrderInfo.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    using System;

    /// <summary>
    /// Represents order information
    /// </summary>
    public sealed class OrderInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class
        /// </summary>
        /// <param name="orderId">Identification code of the order</param>
        /// <param name="amount">Payment amount</param>
        /// <param name="currency">Payment currency</param>
        /// <param name="orderDescription">Order description</param>
        /// <param name="validUntil">"Pay before" period</param>
        public OrderInfo(string orderId, decimal amount, string currency, string orderDescription = null, DateTime? validUntil = null)
        {
            this.OrderId = orderId;
            this.Amount = amount;
            this.Currency = currency;
            this.OrderDecription = orderDescription;
            this.ValidUntil = validUntil;
        }

        /// <summary>
        /// Gets identification code of the order in the merchant system
        /// </summary>
        internal string OrderId { get; }

        /// <summary>
        /// Gets total amount of the order
        /// </summary>
        internal decimal Amount { get; }

        /// <summary>
        /// Gets currency of the order in ISO 4217 format (e.g. USD, EUR)
        /// </summary>
        internal string Currency { get; }

        /// <summary>
        /// Gets comment to the order, which will be displayed to the payer under order number on payment forms and in the notification on e-mail
        /// </summary>
        internal string OrderDecription { get; }

        /// <summary>
        /// Gets period "pay before", time zone UTC(GMT+0)
        /// </summary>
        internal DateTime? ValidUntil { get; }
    }
}
