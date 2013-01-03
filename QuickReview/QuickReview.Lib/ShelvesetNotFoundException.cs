// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShelvesetNotFoundException.cs">
//   Copyright (c) 2012 All Rights Reserved, Jeremy Bokobza
// </copyright>
// <summary>
//   Defines the ShelvesetNotFoundException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickReview.Lib
{
    using System;

    /// <summary>
    /// An exception thrown if the shelveset is not found.
    /// </summary>
    internal class ShelvesetNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShelvesetNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ShelvesetNotFoundException(string message) : base(message)
        {            
        }
    }
}
