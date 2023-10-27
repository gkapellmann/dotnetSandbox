using MediatR;
using Veronica.Sandbox.WS.Interfaces;

namespace Veronica.Sandbox.WS {

    public class WorkerTwo : BackgroundService, INotificationHandler<SimpleMsg> {

        private readonly ISingletonClass singClass;

        private Guid id;

        public WorkerTwo(ISingletonClass singletonClass) {

            singClass = singletonClass;
            id = Guid.NewGuid();

            Console.WriteLine($"WorkerTwo loaded at: {DateTimeOffset.Now}");
            Console.WriteLine($"Worker Guid:   ---------------    {id}");

        }

        public override Task StartAsync(CancellationToken cancellationToken) {
            Console.WriteLine($"WorkerTwo Started at: {DateTimeOffset.Now}");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

            Console.WriteLine($"WorkerTwo running at: {DateTimeOffset.Now}");
            await Task.Delay(1000, stoppingToken);

            Console.WriteLine("WorkerTwo Execution Ended...", 2, 2);

        }

        public override Task StopAsync(CancellationToken cancellationToken) {
            Console.WriteLine($"WorkerTwo stopped at: {DateTimeOffset.Now}");
            return base.StopAsync(cancellationToken);
        }

        public Task Handle(SimpleMsg notification, CancellationToken cancellationToken) {
            Console.WriteLine($"WorkerTwo received notification {notification.msg} at: {DateTimeOffset.Now}");
            return Task.CompletedTask;
        }
    }
}