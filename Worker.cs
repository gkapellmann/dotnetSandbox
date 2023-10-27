using MediatR;
using Veronica.Sandbox.WS.Interfaces;

namespace Veronica.Sandbox.WS {

    public class Worker : BackgroundService, INotificationHandler<SimpleMsg> {

        private readonly ILogger<Worker> _logger;   

        private readonly ISingletonClass singClass;

        private Guid id;

        public Worker(ISingletonClass singletonClass, ILogger<Worker> logger) {

            singClass = singletonClass;
            id = Guid.NewGuid();

            _logger = logger;

            _logger.LogDebug($"Worker Init at: {DateTimeOffset.Now}");
            _logger.LogInformation($"Worker loaded at: {DateTimeOffset.Now}");
            _logger.LogInformation($"Worker Guid:   ---------------   {id}");

        }

        public override Task StartAsync(CancellationToken cancellationToken) {
            _logger.LogInformation($"Worker Started at: {DateTimeOffset.Now}");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

            _logger.LogInformation($"Worker Start Execute at: {DateTimeOffset.Now}");

            await Task.Delay(1000, stoppingToken);

            singClass.InitClass("Worker");
            singClass.PrintGuid();

            await Task.Delay(5000, stoppingToken);

            _logger.LogInformation("Worker Execution Ended...");

        }

        public override Task StopAsync(CancellationToken cancellationToken) {
            _logger.LogInformation($"Worker stopped at: {DateTimeOffset.Now}");
            return base.StopAsync(cancellationToken);
        }

        public Task Handle(SimpleMsg notification, CancellationToken cancellationToken) {
            _logger.LogInformation($"Worker received notification {notification.msg} at: {DateTimeOffset.Now} ************************* ");
            return Task.CompletedTask;
        }
    }
}