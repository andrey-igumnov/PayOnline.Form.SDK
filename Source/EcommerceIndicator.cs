// <copyright file="EcommerceIndicator.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    /// <summary>
    /// E-Commerce indicator
    /// </summary>
    public enum EcommerceIndicator
    {
        /// <summary>
        /// Default value
        /// </summary>
        None = 0,

        /// <summary>
        /// This value means that the cardholder was authenticated by the issuer by verifying the cardholder's password or identity information.
        /// The value is returned by the ACS in the Payer Authentication Response message when the cardholder successfully passed 3-D Secure payment authentication.
        /// VISA: ECI=05
        /// MasterCard: ECI=02
        /// </summary>
        FullThreeds = 101,

        /// <summary>
        /// This value means that the merchant attempted to authenticate the cardholder, but either the cardholder or issuer was not participating.
        /// The value should be returned by the ACS in the Authentication Response message for an Attempt Response.
        /// Additionally, merchants may use this value in the authorization request when a Verify Enrollment of N is received from the Visa Directory Server.
        /// VISA: ECI=06
        /// MasterCard: ECI=01
        /// </summary>
        IssuerResponsibilityNonFullThreeds = 102,

        /// <summary>
        /// This value is set by the merchant when the payment transaction was conducted over a secure channel (for example, SSL/TLS),
        /// but payment authentication was not performed, or when the issuer responded that authentication could not be performed.
        /// This value applies when either the Verify Enrollment or the Payer Authentication Response contains a U for Unable to Authenticate.
        /// VISA: ECI=07
        /// MasterCard: ECI=00
        /// </summary>
        MerchantResponsibility = 103,
    }
}
