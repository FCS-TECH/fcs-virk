﻿// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Filename         : VrVatInfoMapper.cs
// Author           : Frede Hundewadt
// Created          : 2024 03 29 12:36
// 
// Last Modified By : root
// Last Modified On : 2024 04 11 13:02
// ***********************************************************************
// <copyright company="FCS">
//     Copyright (C) 2024-2024 FCS Frede's Computer Service.
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

using FCS.Lib.Common;


namespace FCS.Lib.Virk
{
    /// <summary>
    ///     Vr Vat Info Mapper
    /// </summary>
    public class VrVatInfoMapper
    {
        /// <summary>
        ///     Vr to CRM mapper
        /// </summary>
        /// <param name="vrVirk"></param>
        /// <returns>Vat Info Data Transfer Object</returns>
        /// <see cref="VatInfoDto" />
        /// <see cref="VrVirksomhed" />
        /// <see cref="VatState" />
        /// <see cref="LifeCycle" />
        /// <see cref="TimeFrame" />
        public VatInfoDto MapVrToCrm(VrVirksomhed vrVirk)
        {
            var c = new VatInfoDto
            {
                Name = vrVirk.VirksomhedMetadata.NyesteNavn.Navn,
                Address =
                    $"{vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Vejnavn} {vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.HusnummerFra}",
                CoName = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.CoNavn,
                ZipCode = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Postnummer.ToString(),
                City = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.PostDistrikt,
                VatNumber = vrVirk.CvrNummer,
                RequestDate = $"{DateTime.Now:yyyy-MM-dd}"
            };

            if (vrVirk.VirksomhedsStatus.Any())
                foreach (var cs in vrVirk.VirksomhedsStatus.Select(vrStatus => new VatState
                         {
                             State = vrStatus.Status,
                             LastUpdate = vrStatus.SidstOpdateret,
                             TimeFrame = new TimeFrame
                             {
                                 StartDate = vrStatus.Periode.GyldigFra,
                                 EndDate = !string.IsNullOrWhiteSpace(vrStatus.Periode.GyldigTil)
                                     ? vrStatus.Periode.GyldigTil
                                     : ""
                             }
                         }))
                    c.States.Add(cs);
            else
                c.States.Add(new VatState());

            if (vrVirk.Livsforloeb.Any())
                foreach (var lc in vrVirk.Livsforloeb.Select(
                             vrCourse => new LifeCycle
                             {
                                 LastUpdate = vrCourse.SidstOpdateret,
                                 TimeFrame = new TimeFrame
                                 {
                                     StartDate = vrCourse.Periode.GyldigFra,
                                     EndDate = !string.IsNullOrWhiteSpace(vrCourse.Periode.GyldigTil)
                                         ? vrCourse.Periode.GyldigTil
                                         : ""
                                 }
                             }
                         ))
                    c.LifeCycles.Add(lc);
            else
                c.LifeCycles.Add(new LifeCycle());

            if (!string.IsNullOrWhiteSpace(c.States[c.States.Count - 1].State)) return c;

            var sc = c.States.Count - 1;
            var lcc = c.LifeCycles.Count - 1;
            c.States[sc].LastUpdate = c.LifeCycles[lcc].LastUpdate;
            c.States[sc].TimeFrame.StartDate = c.LifeCycles[lcc].TimeFrame.StartDate;
            c.States[sc].TimeFrame.EndDate = c.LifeCycles[lcc].TimeFrame.EndDate;
            c.States[sc].State = string.IsNullOrWhiteSpace(c.LifeCycles[c.LifeCycles.Count - 1].TimeFrame.EndDate)
                ? "NORMAL"
                : "LUKKET";
            return c;
        }
    }
}