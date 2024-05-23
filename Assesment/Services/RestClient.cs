using System.Net.Http.Headers;
using System.Text.Json;
using Assesment.Models;

namespace Assesment.Services;

public class RestClient : IRestClient
{
    private readonly HttpClient _client;

    public RestClient()
    {
        HttpClient _client = new HttpClient();
    }

    public string GetImageURL(string imageAPIURL)
    {
        string retval = string.Empty;
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            HttpResponseMessage response = client.GetAsync(imageAPIURL).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;

                AvatarImageURL? imageURL = JsonSerializer.Deserialize<AvatarImageURL>(responseBody);

                retval = imageURL.url;
            }
        }
        catch (Exception)
        {
            // Log exception
        }

        return retval;
    }
}
