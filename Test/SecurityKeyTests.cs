// <copyright file="SecurityKeyTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK.Test
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// <see cref="SecurityKey"/> tests
    /// </summary>
    [TestFixture]
    public static class SecurityKeyTests
    {
        /// <summary>
        /// Calculate key for callback test
        /// </summary>
        [Test(Description = "Calculate key for callback")]
        public static void CalculateKeyForCallbackTest()
        {
            var key = new SecurityKey(
                new MerchantSettings(12345, "3844908d-4c2a-42e1-9be0-91bb5d068d22"),
                new OrderInfo("56789", 9.99m, "USD"),
                123456789,
                new DateTime(2010, 01, 01, 00, 00, 00));

            Assert.AreEqual("9caebdeb8382cece06fd404661bf583b", key.Value);
        }

        /// <summary>
        /// Calculate key for payment request test
        /// </summary>
        [Test(Description = "Calculate key for payment request")]
        public static void CalculateKeyForPaymentRequestTest()
        {
            var key = new SecurityKey(
                new MerchantSettings(12345, "3844908d-4c2a-42e1-9be0-91bb5d068d22"),
                new OrderInfo("56789", 9.99m, "USD", "Buying phone", new DateTime(2010, 01, 29, 16, 10, 00)));

            Assert.AreEqual("3a561b5b42069b2432095e08630c3f93", key.Value);
        }
    }
}
