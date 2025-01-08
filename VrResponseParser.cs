// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Virk
// // Filename         : VrResponseParser.cs
// // Created          : 2025-01-03 14:01
// // Last Modified By : dev
// // Last Modified On : 2025-01-04 13:01
// // ***********************************************************************
// // <copyright company="Frede Hundewadt">
// //     Copyright (C) 2010-2025 Frede Hundewadt
// //     This program is free software: you can redistribute it and/or modify
// //     it under the terms of the GNU Affero General Public License as
// //     published by the Free Software Foundation, either version 3 of the
// //     License, or (at your option) any later version.
// //
// //     This program is distributed in the hope that it will be useful,
// //     but WITHOUT ANY WARRANTY; without even the implied warranty of
// //     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// //     GNU Affero General Public License for more details.
// //
// //     You should have received a copy of the GNU Affero General Public License
// //     along with this program.  If not, see [https://www.gnu.org/licenses]
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FCS.Lib.Virk;

/// <summary>
///     Provides functionality to parse VR response data and extract relevant business information.
/// </summary>
/// <remarks>
///     This class is designed to handle JSON-formatted VR response data, typically returned from external services.
///     It parses the data to extract a collection of <see cref="VrVirksomhed" /> objects, which represent business
///     entities.
/// </remarks>
public class VrResponseParser
{
    /// <summary>
    ///     Parses the VR response data and extracts a list of <see cref="VrVirksomhed" /> objects.
    /// </summary>
    /// <param name="responseData">
    ///     A JSON-formatted string containing the VR response data.
    /// </param>
    /// <returns>
    ///     A list of <see cref="VrVirksomhed" /> objects extracted from the response data.
    ///     If no valid data is found, an empty list is returned.
    /// </returns>
    /// <exception cref="JsonReaderException">
    ///     Thrown if the provided <paramref name="responseData" /> is not a valid JSON string.
    /// </exception>
    /// <exception cref="JsonSerializationException">
    ///     Thrown if the deserialization of a <see cref="VrVirksomhed" /> object fails.
    /// </exception>
    public List<VrVirksomhed> ParseVrResponse(string responseData)
    {
        var result = new List<VrVirksomhed>();

        var cvrObject = JObject.Parse(responseData);

        var numHits = (int)cvrObject.SelectToken("hits")?.SelectToken("total")!;

        if (numHits == 0)
            return result;

        var cvrHits = cvrObject.SelectToken("hits")?.SelectToken("hits");

        for (var i = 0; i < numHits; i++)
            try
            {
                var cObject = cvrHits?[i]?["_source"] != null
                    ? (JObject?)cvrHits[i]?["_source"]?["Vrvirksomhed"]
                    : null;

                var jsonString = JsonConvert.SerializeObject(cObject);

                var o = JsonConvert.DeserializeObject<VrVirksomhed>(jsonString);
                if (o != null)
                    result.Add(o);
            }
            catch
            {
                return result;
            }

        return result;
    }
}