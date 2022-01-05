using System;
using System.Threading.Tasks;
using Dapr.Client;
using System.Threading;

namespace ClientGRPC
{
    class Program
    {
        class ResultMessage
        {
            public string Result { get; set; }
        }

        static async Task Main(string[] args)
        {
            var client = new DaprClientBuilder()
                .Build();

            var data = new { Name = "Reader" };

            for(int x=0; x<10; x++)
            {
                var output = await client.InvokeMethodAsync<object, ResultMessage>("greetinggrpc", "SayHello", data);
                Console.WriteLine(output.Result);            
            }
        }
    }
}
