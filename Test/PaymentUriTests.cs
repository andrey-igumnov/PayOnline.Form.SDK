// <copyright file="PaymentUriTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK.Test
{
    using System;
    using System.Collections.Specialized;
    using NUnit.Framework;

    /// <summary>
    /// <see cref="PaymentUri"/> tests
    /// </summary>
    [TestFixture]
    public static class PaymentUriTests
    {
        /// <summary>
        /// Payment URI test
        /// </summary>
        [Test]
        public static void PaymentUriTest()
        {
            var uri = new PaymentUri(
                new Uri("https://secure.payonlinesystem.com"),
                new MerchantSettings(12345, "3844908d-4c2a-42e1-9be0-91bb5d068d22"),
                new OrderInfo("56789", 9.99m, "USD", "Buying phone", new DateTime(2010, 01, 29, 16, 10, 00)),
                PaymentMethod.Select,
                Language.English,
                new RedirectParameters(new Uri("http://merchant-site/return"), new Uri("http://merchant-site/fail")),
                new NameValueCollection { { "email", "test@test.test" } });

            Assert.AreEqual(
                "https://secure.payonlinesystem.com/en/payment/select?MerchantId=12345&OrderId=56789&Amount=9.99&Currency=USD&ValidUntil=2010-01-29+16%3a10%3a00&OrderDescription=Buying+phone&SecurityKey=3a561b5b42069b2432095e08630c3f93&ReturnUrl=http%3a%2f%2fmerchant-site%2freturn&FailUrl=http%3a%2f%2fmerchant-site%2ffail&email=test%40test.test",
                uri.AbsoluteUri);
        }
    }
}
