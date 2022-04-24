using ConsoleClient;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7063");

var pinService = new PinVending.PinVendingClient(channel);
var response = pinService.GetToken(new ApiClient 
{
    ApiKey = "1254785693254",
    BusinessName = "Infinity Tech"
});
Console.WriteLine("Get Token: " + response.Result);

//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(new HelloRequest { Name = "Osemeke Anyirah" });
//Console.WriteLine("Greeting: " + reply.Message);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();