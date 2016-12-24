// <copyright file="CallbackDataTests.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK.Test
{
    using System;
    using System.Net;
    using System.Web;
    using NUnit.Framework;

    /// <summary>
    /// <see cref="CallbackData"/> tests
    /// </summary>
    [TestFixture]
    public static class CallbackDataTests
    {
        /// <summary>
        /// Tests callback query string parsing
        /// </summary>
        [Test]
        public static void ParseCallbackQueryTest()
        {
            const string Query = "DateTime=2016-12-31+23%3a59%3a59&TransactionID=1234567890&OrderId=0987654321qwe" +
                                 "&Amount=123.45&Currency=EUR&SecurityKey=036c0215b7197e33308c2a2cf219fbbf" +
                                 "&RebillAnchor=4587fh8fhYTF5ftfytf%3d&PaymentAmount=123.45" +
                                 "&PaymentCurrency=EUR&CardHolder=TEST+CARDHOLDER&CardNumber=411111******1111" +
                                 "&Country=US&City=New-York&ECI=7&Code=5205&ErrorCode=3&Zip=12700&Address=Test" +
                                 "&Phone=555-444-11-44&Email=test@cardholder.com&BankName=Chase&ThreedsEnrollment=0" +
                                 "&IpCountry=RU&BinCountry=US&AuthCode=666555&GatewayTransactionId=BankTrId1" +
                                 "&IpAddress=127.0.0.1&SpecialConditions=Validation+Required";
            var callbackData = new CallbackData(HttpUtility.ParseQueryString(Query), new MerchantSettings(12345, "3844908d-4c2a-42e1-9be0-91bb5d068d22"));

            Assert.AreEqual(new DateTime(2016, 12, 31, 23, 59, 59), callbackData.TransactionDate);
            Assert.AreEqual(1234567890, callbackData.TransactionId);
            Assert.AreEqual("0987654321qwe", callbackData.OrderInfo.OrderId);
            Assert.AreEqual(123.45m, callbackData.OrderInfo.Amount);
            Assert.AreEqual("EUR", callbackData.OrderInfo.Currency);
            Assert.AreEqual("4587fh8fhYTF5ftfytf=", callbackData.RebillAnchor);
            Assert.AreEqual(123.45, callbackData.PaymentAmount);
            Assert.AreEqual("EUR", callbackData.PaymentCurrency);
            Assert.AreEqual("TEST CARDHOLDER", callbackData.CardholderName);
            Assert.AreEqual("411111******1111", callbackData.MaskedCardNumber);
            Assert.AreEqual("US", callbackData.CountryCode);
            Assert.AreEqual("New-York", callbackData.City);
            Assert.AreEqual(EcommerceIndicator.MerchantResponsibility, callbackData.EcommerceIndicator);
            Assert.AreEqual(5205, callbackData.DeclineCode);
            Assert.AreEqual(3, callbackData.ErrorCode);
            Assert.AreEqual("12700", callbackData.ZipCode);
            Assert.AreEqual("Test", callbackData.StreetAddress);
            Assert.AreEqual("555-444-11-44", callbackData.Phone);
            Assert.AreEqual("test@cardholder.com", callbackData.Email);
            Assert.AreEqual("Chase", callbackData.Issuer);
            Assert.AreEqual(CardEnrollmentStatus.No, callbackData.CardEnrollmentStatus);
            Assert.AreEqual("RU", callbackData.IPCountryCode);
            Assert.AreEqual("US", callbackData.BinCountryCode);
            Assert.AreEqual("666555", callbackData.AuthorizationCode);
            Assert.AreEqual("BankTrId1", callbackData.BankTransactionId);
            Assert.AreEqual(IPAddress.Parse("127.0.0.1"), callbackData.IPAddress);
            Assert.AreEqual("Validation Required", callbackData.SpecialConditions);
        }
    }
}
