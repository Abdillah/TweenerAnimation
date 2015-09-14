using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweenerStudio
{
    class Point
    {
        int[] positions;

        public int X {
            get {
                return positions[0];
            }
            set {
                positions[0] = value;
            }
        }

        public int Y
        {
            get {
                return positions[1];
            }
            set {
                positions[1] = value;
            }
        }

        public Point(int x, int y) {
            positions = new int[2];

            this.X = x;
            this.Y = y;
        }

        public void translate (int x, int y, bool is_delta) {
            if (is_delta)
            {
                this.X += x;
                this.Y += y;
            }
            else
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}
