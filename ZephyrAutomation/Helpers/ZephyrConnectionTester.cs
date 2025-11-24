using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class ZephyrConnectionTester
{
    public async Task TestConnection()
    {
        string email = "naveenprasad.r@vuedata.in";
        string apiToken = "JTdCJTIyZGVzdGluYXRpb24lMjIlM0ElMjJzdWdnZXN0aW9ucyUyMiUyQyUyMm5hbWUlMjIlM0ElMjJBZGROdW1iZXJzX1JldHVybnNDb3JyZWN0U3VtJTIyJTJDJTIyc3RhcnRpbmdVcmwlMjIlM0ElMjJodHRwcyUzQSUyRiUyRmRlbW9xYS5jb20lMkZhdXRvbWF0aW9uLXByYWN0aWNlLWZvcm0lMjIlMkMlMjJkZXZpY2VQcm9maWxlJTIyJTNBJTIyZGVza3RvcCUyMiUyQyUyMmJyb3dzZXIlMjIlM0ElMjJDaHJvbWUlMjIlMkMlMjJ0ZXN0Q2FzZUlkJTIyJTNBJTIyU0NSVU0tVDElMjIlMkMlMjJyZWZsZWN0Snd0JTIyJTNBJTIyZXlKMGVYQWlPaUpLVjFRaUxDSmhiR2NpT2lKSVV6STFOaUo5LmV5SmhjR2xDWVhObFZYSnNJam9pYUhSMGNITTZMeTlsZFM1aGNHa3VlbVZ3YUhseWMyTmhiR1V1YzIxaGNuUmlaV0Z5TG1OdmJTSXNJbXBwY21GUWNtOXFaV04wU1dRaU9qRXdNREF3TENKcGMzTWlPaUkzTVRJd01qQTZZamsxTlRFM01qQXROemxsTXkwME1EQTVMVGd4TW1VdE9HWXlaVEV6TWpJM1pUUTBJaXdpYVhOR2IzSm5aVXAzZENJNlptRnNjMlVzSW1Gd2NFSmhjMlZWY213aU9pSm9kSFJ3Y3pvdkwyVjFMbUZ3Y0M1MGJUUnFMbk50WVhKMFltVmhjaTVqYjIwaUxDSmhkV1FpT2lKeVpXWnNaV04wSWl3aWRHVnpkRU5oYzJWTFpYa2lPaUpUUTFKVlRTMVVNU0lzSW5ScFpYSWlPaUpGZG1Gc2RXRjBhVzl1SWl3aVkyOXVkR1Y0ZENJNmV5SmlZWE5sVlhKc0lqb2lhSFIwY0hNNkx5OTJkV1ZrWVhSaExYUmxZVzB1WVhSc1lYTnphV0Z1TG01bGRDSjlMQ0p6WTJGc1pVRjFkRzl0WVhSbFUzUmhkSFZ6SWpvaVlXTjBhWFpsSWl3aVpYaHdJam94TnpZek9UazJOamt6TENKcFlYUWlPakUzTmpNNU9UVTNPVE1zSW5SbGJtRnVkQ0k2SWpCbU1UTTJPVGRpTFRSaVpUQXRNemc1TUMxaE1XWTJMVE5sWVRNNFlUazFPVEUyT1NKOS5feUFCVlpaY25MUWdsZXh5NTJTd1BhRHdjSDBwNERzaDg3QUdzYVpIMmNZJTIyJTdE";

        var auth = Convert.ToBase64String(
            Encoding.ASCII.GetBytes($"{email}:{apiToken}")
        );

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", auth);

        var url = "https://api.zephyrscale.smartbear.com/v2/projects";

        var response = await client.GetAsync(url);
        string result = await response.Content.ReadAsStringAsync();

        Console.WriteLine("Status: " + response.StatusCode);
        Console.WriteLine("Result: " + result);
    }


}
