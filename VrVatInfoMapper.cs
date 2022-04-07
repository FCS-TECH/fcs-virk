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

using System.Globalization;
using FCS.Lib.Common;
using FCS.Lib.Virk.Models;

namespace FCS.Lib.Virk
{
    public class VrVatInfoMapper
    {
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
            {
                foreach (var cs in vrVirk.VirksomhedsStatus.Select(vrStatus => new VatState
                         {
                             State = vrStatus.Status,
                             LastUpdate = vrStatus.SidstOpdateret,
                             TimeFrame = new TimeFrame
                             {
                                 StartDate = vrStatus.Periode.GyldigFra,
                                 EndDate = !string.IsNullOrWhiteSpace(vrStatus.Periode.GyldigTil) ? vrStatus.Periode.GyldigTil : ""
                             }
                         }))
                {
                    c.States.Add(cs);
                }
            }
            else
            {
                c.States.Add(new VatState());
            }

            if (vrVirk.Livsforloeb.Any())
            {
                foreach (var lc in vrVirk.Livsforloeb.Select(
                             vrCourse => new LifeCycle
                             {
                                 LastUpdate = vrCourse.SidstOpdateret,
                                 TimeFrame = new TimeFrame
                                 {
                                     StartDate = vrCourse.Periode.GyldigFra,
                                     EndDate = !string.IsNullOrWhiteSpace(vrCourse.Periode.GyldigTil) ? vrCourse.Periode.GyldigTil : ""
                                 }
                             }
                             ))
                {
                    c.LifeCycles.Add(lc);
                }
            }
            else
            {
                c.LifeCycles.Add(new LifeCycle());
            }

            if (!string.IsNullOrWhiteSpace(c.States[c.States.Count - 1].State)) return c;

            var sc = c.States.Count - 1;
            var lcc = c.LifeCycles.Count - 1;
            c.States[sc].LastUpdate = c.LifeCycles[lcc].LastUpdate;
            c.States[sc].TimeFrame.StartDate = c.LifeCycles[lcc].TimeFrame.StartDate;
            c.States[sc].TimeFrame.EndDate = c.LifeCycles[lcc].TimeFrame.EndDate;
            c.States[sc].State = string.IsNullOrWhiteSpace(c.LifeCycles[c.LifeCycles.Count - 1].TimeFrame.EndDate) ? "NORMAL" : "LUKKET";
            return c;
        }
    }
}