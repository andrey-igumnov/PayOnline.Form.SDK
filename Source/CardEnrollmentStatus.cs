// <copyright file="CardEnrollmentStatus.cs">
//     Copyright (c) Andrey Igumnov. All rights reserved.
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace PayOnline.Form.SDK
{
    /// <summary>
    /// Bank card 3D-secure enrollment status
    /// </summary>
    public enum CardEnrollmentStatus
    {
        /// <summary>
        /// No information
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Card enrolled
        /// </summary>
        Yes = 1,

        /// <summary>
        /// Card not enrolled
        /// </summary>
        No = 2,

        /// <summary>
        /// Unable to verify enrollment
        /// </summary>
        Unavailable = 3,
    }
}
