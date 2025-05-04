using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_spaceInvaders
{
    internal class UIController
    {
        public event EventHandler OnAPressed;
        public event EventHandler OnDPressed;
        public event EventHandler OnSpacePressed;

        public void StartListen()
        {
            while (true) {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.A)) {
                    if (OnAPressed != null) {
                        OnAPressed(this, EventArgs.Empty);
                    }
                }

                if (key.Key.Equals(ConsoleKey.D)) {
                    if (OnDPressed != null) {
                        OnDPressed(this, EventArgs.Empty);
                    }
                }

                if (key.Key.Equals(ConsoleKey.Spacebar)) {
                    if (OnSpacePressed != null) {
                        OnSpacePressed(this, EventArgs.Empty);
                    }
                }
            }
        }
    }
}