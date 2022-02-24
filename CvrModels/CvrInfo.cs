// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 01-01-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="CvrInfo.cs" company="FCS">
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
//    along with this program.  If not, see [https://www.gnu.org/licenses/agpl-3.0.en.html]
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FCS.Lib.Virk.CvrModels
{
    /// <summary>
    /// Class CvrCompany.
    /// </summary>
    public class CvrInfo
    {
        /// <summary>
        /// Gets or sets the vat number.
        /// </summary>
        /// <value>The vat number.</value>
        public string VatNumber { get; set; } = "";
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = "";
        /// <summary>
        /// Gets or sets the name of the co.
        /// </summary>
        /// <value>The name of the co.</value>
        public string CoName { get; set; } = "";
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; } = "";
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; } = "";
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode { get; set; } = "";
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public List<CvrState> States { get; set; } = new();
    }
}