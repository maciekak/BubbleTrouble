using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;

namespace BubbleTrouble
{
    static class Program
    {
        static void Main()
        {
            var window = new RenderWindow(new VideoMode(1280, 720), "Bubble Trouble");
            window.SetKeyRepeatEnabled(false);

            window.Closed += (sender, args) =>
            {
                window.Close();
            };
            window.SetActive();
            while (window.IsOpen)
            {
                window.Clear();
                window.DispatchEvents();
                window.Display();
            }
        }
    }
}
