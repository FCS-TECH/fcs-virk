// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrCvrMapper.cs" company="FCS">
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

using FCS.Lib.Virk.CvrModels;
using FCS.Lib.Virk.VrModels;

namespace FCS.Lib.Virk
{
    /// <summary>
    /// Class VrCvrMapper.
    /// </summary>
    public class VrCvrMapper
    {
        /// <summary>
        /// Maps the vr to CVR.
        /// </summary>
        /// <param name="vrVirk">The vr virk.</param>
        /// <returns>CvrInfo.</returns>
        public CvrInfo MapVrToCvr(VrVirksomhed vrVirk)
        {
            var c = new CvrInfo
            {
                Name = vrVirk.VirksomhedMetadata.NyesteNavn.Navn,
                Address =
                    $"{vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Vejnavn} {vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.HusnummerFra}",
                CoName = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.CoNavn,
                ZipCode = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Postnummer.ToString(),
                City = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.PostDistrikt,
                VatNumber = vrVirk.CvrNummer
            };

            if (vrVirk.VirksomhedsStatus.Any())
            {
                foreach (var cs in vrVirk.VirksomhedsStatus.Select(vrStatus => new CvrState
                         {
                             State = vrStatus.Status,
                             LastUpdate = vrStatus.SidstOpdateret,
                             TimeFrame = new TimeFrame
                             {
                                 StartDate = vrStatus.Periode.GyldigFra,
                                 EndDate = vrStatus.Periode.GyldigTil
                             }
                         }))
                {
                    c.States.Add(cs);
                }
            }
            else
            {
                c.States.Add(new CvrState());
            }

            return c;
        }
    }
}