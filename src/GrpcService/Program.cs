using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<PinVendingService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

// Configure the HTTP request pipeline. [CLASSIC WAY]
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGrpcService<GreeterService>();
//    endpoints.MapGrpcService<PinVendingService>();
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
//    });
//});

app.Run();
