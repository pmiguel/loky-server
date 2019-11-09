namespace LokyClient
{
    using System;
    using System.Threading.Tasks;
    using Grpc.Net.Client;
    using Presentation.gRPC;

    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new LokyService.LokyServiceClient(channel);

            var lockRequest = new LockRequest
            {
                Delay = 3000,
                UniqueIdentifier = Guid.NewGuid().ToString()
            };

            var lockReply = await client.LockWorkstationAsync(lockRequest);
            
            Console.WriteLine($"Workstation lock status: {lockReply.LockSuccess}");
        }
    }
}