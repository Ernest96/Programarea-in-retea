using System;
using System.Net.Http;

class Program
{
    static async Task Main()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            Uri uri = new Uri("http://httpbin.org/ip");

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} { response.ReasonPhrase}");  
            }
        }
    }
}