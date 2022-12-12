# fcs-virk

Sample controller action

```
public async Task<IHttpActionResult> GetCvrData([FromUri] VrQuery query)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    if (!VrQueryValidator.ValidateVrQuery(query))
        return BadRequest($"invalid request");

    // cvr endpoint
    var cvrLookupUrl = $"{Settings.CvrLookupUrl}";

    // auth
    var auth = $"{Settings.CvrCredentials}";

    // initialize result object
    var result = new List<CvrInfo>();

    // map query to json object
    var queryMapper = new VrQueryMapper();
    var queryObject = queryMapper.VrMapQuery(query);

    // execute request
    var vrReqest = new VrHttpRequest();
    var vrResponseView = await vrReqest.GetResponseAsync(cvrLookupUrl,
        JsonConvert.SerializeObject(queryObject, Formatting.None), auth);

    // intermediate parser
    var vrParser = new VrResponseParser();
    var vrVirksomheder = vrParser.ParseVrResponse(vrResponseView.Message);

    // validate wheter to continue or return empty result
    var found = vrVirksomheder.Any();
    if (!found)
        return Ok(result);

    // final mapping
    var cvrMapper = new VrCvrMapper();
    result = vrVirksomheder.Select(c => cvrMapper.MapVrToCvr(c)).ToList();

    // return result
    return Ok(result);
}
```