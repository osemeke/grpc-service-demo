using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class PinVendingService : PinVending.PinVendingBase
    {
        public override Task<ResponseModel> GetToken(ApiClient request, ServerCallContext context)
        {
            return GetToken(request);
        }

        public override Task<Pin> GetPin(RequestModel request, ServerCallContext context)
        {
            return Task.FromResult(new Pin
            {
                // TODO:
            });
        }

        private Task<ResponseModel> GetToken(ApiClient request)
        {
            return Task.FromResult(new ResponseModel
            {
                Result = "rtyuo90p0o9i8u7y6tyuiopoiuytyu78io9p00oi9u7y6"
            });
        }
    }
}
