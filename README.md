# grpc-service-demo
A basic test of the gRPC implementation for C# 10 on dotnet6

## Steps

- In Visual Studio creat a gRPC progect

### Server
- add new item > protobuf.proto and write the proto3 interface of the service design
- In `.proj` file add `<Protobuf Include="Protos\pin.proto" GrpcServices="Server" />` to the `ItemGroup`. 
This is how the compiler knows the existence of the `proto` api definition file, 
and thereby using it to generate c# abstraction codes.
- build to generate the abstractions. They can be found in `obj\Debug\net6.0\Protos`
- In Program.cs ensure `services.AddGrpc();` and `endpoints.MapGrpcService<PinService>();`

### Client
- Install the following packages `Grpc.Tools`, `Grpc.Net.Client` and `Google.Protobuf`
- On the client, copy the proto file from the service and rename the namespace according to the client namespace.
- In `.proj` file add `<Protobuf Include="Protos\pin.proto" GrpcServices="Client" />` to the `ItemGroup`. Take note that here the `GrpcServices` value is set to `Client`.
- Below is a sample request with a console app:

```cs
using var channel = GrpcChannel.ForAddress("https://localhost:7063");

var pinService = new PinVending.PinVendingClient(channel);
var response = pinService.GetToken(new ApiClient 
{
    ApiKey = "1254785693254",
    BusinessName = "Infinity Tech"
});

Console.WriteLine("Get Token: " + response.Result);
```

