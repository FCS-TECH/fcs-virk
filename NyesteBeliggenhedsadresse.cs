// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : 
// Created          : 2023-10-02
// 
// Last Modified By : root
// Last Modified On : 2023-10-13 07:33
// ***********************************************************************
// <copyright file="NyesteBeliggenhedsadresse.cs" company="FCS">
//     Copyright (C) 2015 - 2023 FCS Fredes Computer Service.
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
// 
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FCS.Lib.Virk
{
    /// <summary>
    ///     Current address
    /// </summary>
    public class NyesteBeliggenhedsadresse
    {
        /// <summary>
        ///     House number from
        /// </summary>
        public int? HusnummerFra { get; set; }

        /// <summary>
        ///     House number to
        /// </summary>
        public int? HusnummerTil { get; set; }

        /// <summary>
        ///     Zip code
        /// </summary>
        public int? Postnummer { get; set; }

        /// <summary>
        ///     Street name
        /// </summary>
        public string Vejnavn { get; set; } = "";

        /// <summary>
        ///     CO name
        /// </summary>
        public string CoNavn { get; set; } = "";

        /// <summary>
        ///     Mail district name
        /// </summary>
        public string PostDistrikt { get; set; } = "";
    }
}