// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrResponseParser.cs" company="FCS">
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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FCS.Lib.Virk
{
    /// <summary>
    /// VrResponseParser
    /// </summary>
    public class VrResponseParser
    {
        /// <summary>
        /// Registrar response parser
        /// </summary>
        /// <param name="responseData"></param>
        /// <returns>List of VrVirksomhed models</returns>
        /// <see cref="VrVirksomhed"/>
        public List<VrVirksomhed> ParseVrResponse(string responseData)
        {
            var result = new List<VrVirksomhed>();
            
            var cvrObject = JObject.Parse(responseData);
            
            var numHits = (int) cvrObject.SelectToken("hits")?.SelectToken("total")!;
            
            if (numHits == 0)
                return result;
            
            var cvrHits = cvrObject.SelectToken("hits")?.SelectToken("hits");
            
            for (var i = 0; i < numHits; i++)
            {
                try
                {
                    var cObject = cvrHits?[i]?["_source"] != null ? (JObject?)cvrHits[i]?["_source"]?["Vrvirksomhed"] : null;

                    var jsonString = JsonConvert.SerializeObject(cObject);

                    var o = JsonConvert.DeserializeObject<VrVirksomhed>(jsonString);
                    if(o != null)
                        result.Add(o);
                }
                catch
                {
                    return result;
                }
            }

            return result;
        }
    }
}