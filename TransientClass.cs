
using Veronica.Sandbox.WS.Interfaces;

namespace Veronica.Sandbox.WS {
    
    public class TransientClass : ITransientClass {

        private string parent;
        private Guid id;

        public TransientClass() {

            id = Guid.NewGuid();


        }

        public void InitClass(string parent) {
            this.parent = parent;
        }

        public void PrintGuid() {
        }

    }

}
