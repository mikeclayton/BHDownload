﻿using BHBackup.Client.Core;

namespace BHBackup.Client.ApiV2;

internal sealed partial class ApiV2Client : CoreApiClient
{

    public ApiV2Client(HttpClient httpClient, CoreApiCredentials? apiCredentials = null)
        : base(httpClient, apiCredentials)
    {
    }

    public async Task<string> ExecuteApiV2Request(string requestUrl, Dictionary<string, string>? querystring, HttpMethod method, string? requestBody, bool roundtrip)
    {

        return await base.ExecuteTextRequestAsync(
            CoreApiClient.JoinUrl(CoreApiClient.FamilyAppUri, requestUrl), querystring, method, requestBody
        ) ?? throw new InvalidOperationException();
    }

    public async Task<TResponse> ExecuteApiV2Request<TResponse>(string requestUrl, Dictionary<string, string>? querystring, HttpMethod method, object? requestBody, bool roundtrip)
    {

        return await base.ExecuteJsonRequestAsync<TResponse>(
            CoreApiClient.JoinUrl(CoreApiClient.FamilyAppUri, requestUrl), querystring, method, requestBody, roundtrip
        ) ?? throw new InvalidOperationException();
    }

}
