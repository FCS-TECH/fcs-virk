// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="NyesteBeliggenhedsadresse.cs" company="FCS">
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
namespace FCS.Lib.Virk.VrModels
{
    /// <summary>
    /// Class NyesteBeliggenhedsadresse.
    /// </summary>
    public class NyesteBeliggenhedsadresse
    {
        /// <summary>
        /// Gets or sets the husnummer fra.
        /// </summary>
        /// <value>The husnummer fra.</value>
        public int? HusnummerFra { get; set; }
        /// <summary>
        /// Gets or sets the husnummer til.
        /// </summary>
        /// <value>The husnummer til.</value>
        public int? HusnummerTil { get; set; }
        /// <summary>
        /// Gets or sets the postnummer.
        /// </summary>
        /// <value>The postnummer.</value>
        public int? Postnummer { get; set; }
        /// <summary>
        /// Gets or sets the vejnavn.
        /// </summary>
        /// <value>The vejnavn.</value>
        public string Vejnavn { get; set; } = "";
        /// <summary>
        /// Gets or sets the co navn.
        /// </summary>
        /// <value>The co navn.</value>
        public string CoNavn { get; set; } = "";
        /// <summary>
        /// Gets or sets the post distrikt.
        /// </summary>
        /// <value>The post distrikt.</value>
        public string PostDistrikt { get; set; } = "";
    }
}