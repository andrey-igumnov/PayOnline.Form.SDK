// <copyright file="PaymentUri.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Web;

    /// <summary>
    /// Represents PayOnline payment form URI
    /// </summary>
    [Serializable]
    public sealed class PaymentUri : Uri
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentUri"/> class
        /// </summary>
        /// <param name="processingUri">Base processing URI</param>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <param name="paymentMethod">Payment method</param>
        /// <param name="language">Form language</param>
        /// <param name="redirectParameters">Redirect parameters</param>
        /// <param name="customData">Additional custom data</param>
        public PaymentUri(
            Uri processingUri,
            MerchantSettings merchantSettings,
            OrderInfo orderInfo,
            PaymentMethod paymentMethod = PaymentMethod.Card,
            Language language = Language.Russian,
            RedirectParameters redirectParameters = null,
            NameValueCollection customData = null)
            : base(BuildUri(processingUri, paymentMethod, language, merchantSettings, orderInfo, redirectParameters, customData))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentUri"/> class
        /// </summary>
        /// <param name="serializationInfo">Serialization Info</param>
        /// <param name="streamingContext">Streaming Context</param>
        private PaymentUri(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Builds payment URI
        /// </summary>
        /// <param name="processingUri">Base processing URI</param>
        /// <param name="paymentMethod">Payment method</param>
        /// <param name="language">Payment form language</param>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <param name="redirectParameters">Redirect parameters</param>
        /// <param name="customData">Custom data parameters</param>
        /// <returns>Payment form URI</returns>
        private static string BuildUri(
            Uri processingUri,
            PaymentMethod paymentMethod,
            Language language,
            MerchantSettings merchantSettings,
            OrderInfo orderInfo,
            RedirectParameters redirectParameters,
            NameValueCollection customData)
        {
            if (processingUri == null)
            {
                throw new ArgumentNullException(nameof(processingUri));
            }

            if (merchantSettings == null)
            {
                throw new ArgumentNullException(nameof(merchantSettings));
            }

            if (orderInfo == null)
            {
                throw new ArgumentNullException(nameof(orderInfo));
            }

            var uriBuilder = new UriBuilder(processingUri)
            {
                Path = GetLanguagePath(language) + GetPaymentMethodPath(paymentMethod),
                Query = GetQuery(merchantSettings, orderInfo, redirectParameters, customData),
            };

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Gets payment form language path
        /// </summary>
        /// <param name="language">Payment form language</param>
        /// <returns>URI path</returns>
        private static string GetLanguagePath(Language language)
        {
            switch (language)
            {
                case Language.Russian:
                    return string.Empty;
                case Language.English:
                    return "en";
                default:
                    throw new NotImplementedException(FormattableString.Invariant($"Language: '{language}' is not implemented"));
            }
        }

        /// <summary>
        /// Gets payment method URI path
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        /// <returns>Uri path</returns>
        private static string GetPaymentMethodPath(PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.Card:
                    return "/payment";
                case PaymentMethod.Qiwi:
                    return "/payment/select/qiwi";
                case PaymentMethod.PayMaster:
                    return "/payment/select/paymaster";
                case PaymentMethod.YandexMoney:
                    return "/payment/select/yandexmoney";
                case PaymentMethod.Select:
                    return "/payment/select";
                default:
                    throw new NotImplementedException(FormattableString.Invariant($"Payment method: '{paymentMethod}' is not implemented"));
            }
        }

        /// <summary>
        /// Creates payment form query
        /// </summary>
        /// <param name="merchantSettings">Merchant settings</param>
        /// <param name="orderInfo">Order information</param>
        /// <param name="redirectParameters">Redirect parameters</param>
        /// <param name="customData">Custom data</param>
        /// <returns>Query string</returns>
        private static string GetQuery(MerchantSettings merchantSettings, OrderInfo orderInfo, RedirectParameters redirectParameters, NameValueCollection customData)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["MerchantId"] = merchantSettings.MerchantId.ToString(CultureInfo.InvariantCulture);
            queryString["OrderId"] = orderInfo.OrderId;
            queryString["Amount"] = orderInfo.Amount.ToString("#.00", CultureInfo.InvariantCulture);
            queryString["Currency"] = orderInfo.Currency.ToUpperInvariant();

            if (orderInfo.ValidUntil.HasValue)
            {
                queryString["ValidUntil"] = orderInfo.ValidUntil.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }

            if (!string.IsNullOrEmpty(orderInfo.OrderDecription))
            {
                queryString["OrderDescription"] = orderInfo.OrderDecription;
            }

            queryString["SecurityKey"] = new SecurityKey(merchantSettings, orderInfo).Value;

            if (redirectParameters?.ReturnUrl != null)
            {
                queryString["ReturnUrl"] = redirectParameters.ReturnUrl.ToString();
            }

            if (redirectParameters?.FailUrl != null)
            {
                queryString["FailUrl"] = redirectParameters.FailUrl.ToString();
            }

            if (customData != null)
            {
                queryString.Add(customData);
            }

            return queryString.ToString();
        }
    }
}
