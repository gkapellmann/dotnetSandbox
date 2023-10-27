
using MediatR;
using Veronica.Sandbox.WS.Interfaces;

namespace Veronica.Sandbox.WS {

    public class SingletonClass : ISingletonClass {

        private readonly ILogger<SingletonClass> _logger;
        private readonly IMediator mediator;
        private string parent;
        private Guid id;

        public SingletonClass(IMediator mediator, ILogger<SingletonClass> logger) {

            _logger = logger;
            this.mediator = mediator;
            id = Guid.NewGuid();

            _logger.LogInformation($"SingletonClass created at: {DateTimeOffset.Now}");
            _logger.LogInformation($"Guid:    ---------------   {id}");

            Task.Run(async () => {
                _logger.LogInformation($"SingletonClass Task started at: {DateTimeOffset.Now}");
                await Task.Delay(10000);
                await mediator.Publish(new SimpleMsg("SingletonClass middle..."));
                _logger.LogInformation($"SingletonClass Task middle at: {DateTimeOffset.Now}");
            });
            
        }

        public void InitClass(string parent) {
            this.parent = parent;
            _logger.LogInformation($"   >>>>>   SingletonClass from {parent} Init at: {DateTimeOffset.Now}");
        }   

        public void PrintGuid() {
            _logger.LogInformation($"   >>>>>   From {parent} Print Guid: {id}");
        }

    }

}
