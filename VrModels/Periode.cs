// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="Periode.cs" company="FCS">
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
namespace FCS.Lib.Virk.VrModels
{
    /// <summary>
    /// Class Periode.
    /// </summary>
    public class Periode
    {
        /// <summary>
        /// Gets or sets the gyldig fra.
        /// </summary>
        /// <value>The gyldig fra.</value>
        public string GyldigFra { get; set; } = "";
        /// <summary>
        /// Gets or sets the gyldig til.
        /// </summary>
        /// <value>The gyldig til.</value>
        public string GyldigTil { get; set; } = "";
    }
}