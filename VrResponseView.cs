// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrResponseView.cs" company="FCS">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Affero General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Affero General Public License for more details.
//
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Net;

namespace FCS.Lib.Virk
{
    /// <summary>
    /// Class VrResponseView.
    /// </summary>
    public class VrResponseView
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is success status code.
        /// </summary>
        /// <value><c>true</c> if this instance is success status code; otherwise, <c>false</c>.</value>
        public bool IsSuccessStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; } = "";
    }
}