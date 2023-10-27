
using Veronica.Sandbox.WS.Interfaces;

namespace Veronica.Sandbox.WS {

    public class ScopedClass : IScopedClass {

        private string parent;
        private Guid id;

        public ScopedClass() {

            id = Guid.NewGuid();

            Console.WriteLine($"ScopedClass created at: {DateTimeOffset.Now}");
            Console.WriteLine($"Guid: {id}");

        }

        public void InitClass(string parent) {
            this.parent = parent;
            Console.WriteLine($"ScopedClass from {parent} Init at: {DateTimeOffset.Now}");
        }

        public void PrintGuid() {
            Console.WriteLine($"From {parent} Print Guid: {id}");
        }

    }

}
