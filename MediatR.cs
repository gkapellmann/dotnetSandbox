using MediatR;

namespace Veronica.Sandbox {
    
    public class MediatR : INotificationHandler<AccidentNotification> {

        private  readonly IMediator _mediator;

        public MediatR(IMediator _mediator) {
            this._mediator = _mediator;
        }

        public async Task Process() {

            await Task.Delay(100);

            Console.ReadLine();

            var accident = new AccidentNotification("Oslo", DateTime.Now);
            await _mediator.Publish(accident);

        }

        public Task Handle(AccidentNotification notification, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }

    }

    public class AccidentNotification : INotification {
        
        public string Location { get; }
        public DateTime Time { get; }

        public AccidentNotification(string location, DateTime time) {
            Location = location;
            Time = time;
        }

    }
}
