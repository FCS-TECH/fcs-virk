// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : inno
// Created          : 2022 12 17 13:33
// 
// Last Modified By : inno
// Last Modified On : 2023 03 14 09:16
// ***********************************************************************
// <copyright file="LivsforloebModel.cs" company="FCS">
//     Copyright (C) 2022-2023 FCS Frede's Computer Services.
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
    /// Lifecycle model
    /// </summary>
    public class LivsforloebModel
    {
        /// <summary>
        /// Last registrar update
        /// </summary>
        public string SidstOpdateret { get; set; } = "";

        /// <summary>
        /// Period
        /// </summary>
        /// <see cref="Periode"/>
        public Periode Periode { get; set; } = new();
    }
}