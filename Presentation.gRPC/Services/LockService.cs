namespace Presentation.gRPC.Services
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Grpc.Core;
    using Microsoft.Extensions.Logging;

    public class LockService : LokyService.LokyServiceBase
    {
        [DllImport("user32")]
        private static extern void LockWorkStation();

        private readonly ILogger<LockService> _logger;

        public LockService(ILogger<LockService> logger) => this._logger = logger;

        public override async Task<LockReply> LockWorkstation(LockRequest request, ServerCallContext context)
        {
            this._logger.LogInformation($"Locking request received. Locking in {request.Delay} milliseconds.");
            await Task.Delay(request.Delay);
            try
            {
                LockWorkStation();
                this._logger.LogInformation("Workstation is locked.");
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Unable to lock workstation. {ex.Message}");
                return new LockReply
                {
                    LockSuccess = false
                };
            }
            return new LockReply
            {
                LockSuccess = true
            };
        }
    }
}