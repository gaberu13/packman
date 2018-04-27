using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman {

    public class Pacman
    {
        public enum Direction
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        public Point Center { get; set; }
        public Direction direction { get; set; }
        public static readonly int RADIUS = 20;
        private int speed;
        public Color Color { get; set; }
        bool isOpen;
        private int width, height;

        public Pacman(int width, int height)
        {
            Center = new Point(305, 225);
            direction = Direction.RIGHT;
            speed = 20;
            isOpen = true;
            Color = Color.Yellow;
            this.width = width;
            this.height = height;
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public void Move()
        {
            int x = 0;
            int y = 0;
            Point p;

            switch (direction)
            {
                case (Direction.UP):
                    x = 0;
                    y = -speed;
                    break;
                case (Direction.DOWN):
                    x = 0;
                    y = speed;
                    break;
                case (Direction.LEFT):
                    x = -speed;
                    y = 0;
                    break;
                case (Direction.RIGHT):
                    x = speed;
                    y = 0;
                    break;
            }
            if (Center.X + x >= width - RADIUS)
            {
                x -= 590;
            }
            if (Center.X + x <= RADIUS)
            {
                x += 590;
            }
            if (Center.Y <= RADIUS && direction == Direction.UP)
            {
                y = 0;
            }
            if (Center.Y >= height - 3 * RADIUS && direction == Direction.DOWN)
            {
                y = 0;
            }
            p = new Point(Center.X + x, Center.Y + y);
            Center = p;
            isOpen = !isOpen;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            if (!isOpen)
            {
                g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS);
            }
            else
            {
                switch (direction)
                {
                    case (Direction.RIGHT):
                        g.FillPie(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS, 45, 270);
                        return;
                    case (Direction.LEFT):
                        g.FillPie(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS, 228, 270);
                        return;
                    case (Direction.UP):
                        g.FillPie(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS, 320, 260);
                        return;
                    case (Direction.DOWN):
                        g.FillPie(b, Center.X - RADIUS, Center.Y - RADIUS, 2 * RADIUS, 2 * RADIUS, 130, 280);
                        return;
                }
            }
            b.Dispose();
        }

    }
}
