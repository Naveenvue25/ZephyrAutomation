using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class ZephyrUploader
{
    private const string ApiUrl = "https://api.zephyrscale.smartbear.com/v2/automations/executions";
    private const string ApiToken = "<YOUR_TOKEN>";

    public static async Task UploadNunitResultAsync(string filePath)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

        using var multipart = new MultipartFormDataContent();
        var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));

        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/xml");
        multipart.Add(fileContent, "file", "TestResult.xml");

        var response = await client.PostAsync(ApiUrl, multipart);

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Upload Response: {result}");
    }
}
