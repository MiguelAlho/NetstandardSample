using System;
using System.Net.Http;
using System.Reflection;

namespace MultitargetLibWithDependencies
{
    public static class PrintRequest
    {
        private const string RequestUri = "http://www.google.com";

        public static string RequestSomething()
        {
            Console.WriteLine($"\t\tWebrequest using {typeof(HttpClient).GetTypeInfo().Assembly.Location} ");
            Console.WriteLine($"\t\tin {typeof(HttpClient).GetTypeInfo().AssemblyQualifiedName} ");

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Head, RequestUri);
                var response = client.SendAsync(request).Result;
                return response.StatusCode.ToString();
            }
        }
    }
}
