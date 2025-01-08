// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VrHttpRequest.cs
//  Created          : 2025-01-03 14:01
//  Last Modified By : dev
//  Last Modified On : 2025-01-04 13:01
//  ***********************************************************************
//  <copyright company="Frede Hundewadt">
//      Copyright (C) 2010-2025 Frede Hundewadt
//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU Affero General Public License as
//      published by the Free Software Foundation, either version 3 of the
//      License, or (at your option) any later version.
// 
//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU Affero General Public License for more details.
// 
//      You should have received a copy of the GNU Affero General Public License
//      along with this program.  If not, see [https://www.gnu.org/licenses]
//  </copyright>
//  <summary></summary>
//  ***********************************************************************

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FCS.Lib.Common;

namespace FCS.Lib.Virk;

/// <summary>
///     Represents an HTTP request handler for interacting with external services.
/// </summary>
/// <remarks>
///     This class provides functionality to send HTTP POST requests with JSON data,
///     authorization headers, and custom user agents. It is designed to handle
///     communication with external APIs and return structured responses.
/// </remarks>
public class VrHttpRequest
{
    /// <summary>
    ///     Sends an HTTP POST request to the specified endpoint with the provided JSON data,
    ///     authorization credentials, and user agent, and returns the response as an <see cref="HttpResponseView" />.
    /// </summary>
    /// <param name="endpoint">The URL of the endpoint to which the request is sent.</param>
    /// <param name="jsonData">The JSON data to include in the request body.</param>
    /// <param name="auth">The authorization credentials to include in the request headers.</param>
    /// <param name="userAgent">The user agent string to include in the request headers.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an
    ///     <see cref="HttpResponseView" /> object with the HTTP response details.
    /// </returns>
    /// <exception cref="HttpRequestException">Thrown if the HTTP request fails.</exception>
    public async Task<HttpResponseView> GetResponseAsync(string endpoint, string jsonData, string auth,
        string userAgent)
    {
        using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        using var vrRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

        vrRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{auth}");
        vrRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        vrRequest.Headers.Add("User-Agent", userAgent);
        vrRequest.Content = content;

        var response = await client.SendAsync(vrRequest).ConfigureAwait(true);
        var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

        return new HttpResponseView
        {
            Code = response.StatusCode,
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            Message = jsonResult
        };
    }
}