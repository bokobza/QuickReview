// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserNotFoundException.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   The user not found exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    using System;

    /// <summary>
    /// An exception thrown if the user was not found.
    /// </summary>
    internal class UserNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UserNotFoundException(string message)
            : base(message)
        {
        }
    }
}
