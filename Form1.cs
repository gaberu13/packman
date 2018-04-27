using Pacman.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman {
    public partial class Form1 : Form {
        Pacman pacman;
        Timer timer;
        static readonly int TIMER_INTERVAL = 250;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        Image foodImage;
        bool[][] foodWorld;

        public Form1() {
            InitializeComponent();
            foodImage = Resources.food;
            DoubleBuffered = true;
            newGame();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++) {
                for (int j = 0; j < foodWorld[i].Length; j++) {
                    if (foodWorld[i][j]) {
                        g.DrawImageUnscaled(foodImage, j * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, i * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2);
                    }
                }
            }
            pacman.Draw(g);
        }

        private void newGame() {
            this.Width = Pacman.RADIUS * 2 * (WORLD_WIDTH + 1);
            this.Height = Pacman.RADIUS * 2 * (WORLD_HEIGHT + 1);
            pacman = new Pacman(this.Width, this.Height);

            foodWorld = new bool[WORLD_HEIGHT][];

            for(int k = 0; k < WORLD_HEIGHT; k++) {
                foodWorld[k] = new bool[WORLD_WIDTH];
            }

            for(int i = 0; i < WORLD_HEIGHT; i++) {
                for(int j = 0; j < WORLD_WIDTH; j++) {
                    foodWorld[i][j] = true;
                }
            }

            timer = new Timer();
            timer.Interval = TIMER_INTERVAL;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {

            for (int i = 0; i < WORLD_HEIGHT; i++) {
                for (int j = 0; j < WORLD_WIDTH; j++) {
                    if ((((pacman.Center.X - 20) / 40) == j) && (((pacman.Center.Y - 20) / 40) == i)) {
                        foodWorld[i][j] = false;
                    }
                }
            }

            pacman.Move();
            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            if (Keys.Up == e.KeyCode) {
                pacman.ChangeDirection(Pacman.Direction.UP);
            }
            if (Keys.Down == e.KeyCode) {
                pacman.ChangeDirection(Pacman.Direction.DOWN);
            }
            if (Keys.Left == e.KeyCode) {
                pacman.ChangeDirection(Pacman.Direction.LEFT);
            }
            if (Keys.Right == e.KeyCode) {
                pacman.ChangeDirection(Pacman.Direction.RIGHT);
            }
            Invalidate();
        }
    }
}
