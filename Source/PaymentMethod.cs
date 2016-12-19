// <copyright file="PaymentMethod.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    /// <summary>
    /// Payment method
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Payment by bank card
        /// </summary>
        Card,

        /// <summary>
        /// Payment by <see href="https://qiwi.ru"/>
        /// </summary>
        Qiwi,

        /// <summary>
        /// Payment by <see href="http://info.paymaster.ru"/>
        /// </summary>
        PayMaster,

        /// <summary>
        /// Payment by <see href="https://money.yandex.ru"/>
        /// </summary>
        YandexMoney,

        /// <summary>
        /// Form of choosing payment method links to all possible payment methods
        /// </summary>
        Select,
    }
}
