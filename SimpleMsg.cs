
using MediatR;

namespace Veronica.Sandbox.WS {

    public class SimpleMsg : INotification {
    
        public string msg;

        public SimpleMsg(string msg) {
            this.msg = msg;
        }

    }

}
