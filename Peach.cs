using Pacman.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman {
    public class Peach {
        private Point center;
        private static readonly int RADIUS = 20;
        private static readonly Image foodImage = Resources.food;
        public bool IsAlive { get; set; }

        public Peach (Point center) {
            this.center = center;
            IsAlive = true;
        }

        public void Draw (Graphics g) {

        }
    }
}
