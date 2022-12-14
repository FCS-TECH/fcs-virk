// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrQueryValidator.cs" company="FCS">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the Affero GNU General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    Affero GNU General Public License for more details.
//
//    You should have received a copy of the Affero GNU General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses/agpl-3.0.en.html]
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FCS.Lib.Virk
{
    /// <summary>
    /// Query validator
    /// </summary>
    public static class VrQueryValidator
    {
        /// <summary>
        /// Validate query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>true or false</returns>
        /// <see cref="VrQuery"/>
        public static bool ValidateVrQuery(VrQuery query)
        {
            try
            {
                // Precise lookup
                if (!string.IsNullOrWhiteSpace(query.VatNumber) || !string.IsNullOrWhiteSpace(query.EntityName)) return true;
                // Address lookup
                return !string.IsNullOrWhiteSpace(query.StreetName)
                       && !string.IsNullOrWhiteSpace(query.HouseNumber)
                       && !string.IsNullOrWhiteSpace(query.ZipCode)
                       && int.TryParse(query.HouseNumber, out _);
            }
            catch
            {
                return false;
            }
        }
    }
}