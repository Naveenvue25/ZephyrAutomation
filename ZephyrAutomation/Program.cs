using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    private static readonly string zephyrToken = "ATATT3xFfGF07Ev26C0N0KITZ_xjLlPaR6YDxJvwQfG7b8JOUSukzu0Sb6sZGsuPHIYWZdfn6gn9yl9itEYf3L4RBhLdCHs5IIp5wj86YCk5CewUXNFx0ghR6bg-AitR_5T_WsGLwr9PnCxMggquMumjTZ9s8-aeFFJfWXOK7tyC39s6jLeycPE=7FD35C80";
    private static readonly string projectKey = "SCRUM";

    static async Task Main()
    {
        string trxFile = RunNUnitTests();
        await PublishResultsToZephyr(trxFile);
    }

    static string RunNUnitTests()
    {
        string trxFile = Path.Combine(Directory.GetCurrentDirectory(), "TestResults.trx");

        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"test ../MyTests/MyTests.csproj --logger \"trx;LogFileName={trxFile}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi);
        process.WaitForExit();

        Console.WriteLine(File.ReadAllText(trxFile));
        return trxFile;
    }

    static async Task PublishResultsToZephyr(string trxFile)
    {
        string testExecutionSummary = GenerateSummaryFromTrx(trxFile);

        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.zephyrscale.smartbear.com/v2/");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", zephyrToken);

        var json = JsonSerializer.Serialize(new
        {
            projectKey = projectKey,
            summary = testExecutionSummary
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("testexecutions", content);
        var result = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Zephyr response: {result}");
    }

    static string GenerateSummaryFromTrx(string trxFile)
    {
        // Very basic parsing of TRX file
        var doc = new System.Xml.XmlDocument();
        doc.Load(trxFile);

        var passed = doc.SelectNodes("//UnitTestResult[@outcome='Passed']").Count;
        var failed = doc.SelectNodes("//UnitTestResult[@outcome='Failed']").Count;

        return $"Automated test run: {passed} passed, {failed} failed";
    }
}
