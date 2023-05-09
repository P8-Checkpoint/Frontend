using CompOff_App.DTOs;
using CompOff_App.Models;
using CompOff_App.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace CompOff_App.Services.Impl;

public class ConnectionService : IConnectionService
{
    private readonly string baseUri = "http://192.168.0.100:5000/api/"; 
    private readonly HttpClient _httpClient = new();

    public ConnectionService()
    {
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public async Task LoginAsync(string username, string password)
    {
        await GetToken(username, password);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync(StorageKeys.AuthTokenKey));
        await GetUser();
    }

    private async Task GetToken(string username, string password)
    {
        try
        {
            var logindto = new LoginInfoDto(username, password);
            var loginInfoJson = JsonSerializer.Serialize(logindto);
            var uri = baseUri + "auth/createtoken";
            StringContent content = new(loginInfoJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync();
            await SecureStorage.SetAsync(StorageKeys.AuthTokenKey, token);
        }
        catch (Exception e)
        {
        }
    }

    private async Task GetUser()
    {
        try
        {
            var uri = baseUri + "Client/GetClient";
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadAsStringAsync();
            await SecureStorage.SetAsync(StorageKeys.UserKey, user);
        }
        catch (Exception e)
        {
        }
    }
}
