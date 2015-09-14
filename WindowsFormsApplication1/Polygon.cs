using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweenerStudio
{
    class Polygon
    {
        int counter;
        public delegate void Callback();

        public TweenerStudio.Point[] vertices;

        public Polygon(Point[] points)
        {
            this.vertices = points;
        }

        /**
         * @param points array of triple-integer that represent coordinate {x, y}
         */
        public Polygon(int[,] points) {
            this.vertices = new Point[points.GetLength(0)];
            for (int i = 0; i < points.GetLength(0); i++)
            {
                this.vertices[i] = new Point(points[i, 0], points[i, 1]);
            }
        }

        /**
         * Get vertices in the type of System.Drawing.Point array.
         */
        public System.Drawing.Point[] get_vertices_builtin_point()
        {
            System.Drawing.Point[] p = new System.Drawing.Point[this.vertices.GetLength(0)];
            for (int i = 0; i < this.vertices.GetLength(0); i++)
            {
                p[i] = new System.Drawing.Point(this.vertices[i].X, this.vertices[i].Y);
            }
            return p;
        }

       /**
        * @param target_pos target position for each point in Polygon
        * @param frame_count number of frame that construct the tweening
        */
        public void tweening(int[,] start_pos, int[,] target_pos, double progress, Callback callback)
        {
            if (target_pos.GetLength(0) < this.vertices.GetLength(0) || (progress < 0 || progress > 1))
            {
                Console.WriteLine("[Debug] Tweening failed, new points length not match." + progress);
                return;
            }

            for (int i = 0; i < this.vertices.GetLength(0); i++)
            {
                double x = ((1 - progress) * start_pos[i, 0] + (progress * target_pos[i, 0]));
                double y = ((1 - progress) * start_pos[i, 1] + (progress * target_pos[i, 1]));
                Console.WriteLine("[" + i + "] " + x + ", " + y);

                this.vertices[i].translate((int)x, (int)y, false);
            }

            callback();

            return;
            System.Windows.Forms.Timer timr = new System.Windows.Forms.Timer();
            timr.Tick += (sender, e) =>
            {
                for (int i = 0; i < this.vertices.GetLength(0); i++)
                {
                    int x = (int) ((1 - progress) * target_pos[i, 0] + (progress * start_pos[i, 0]));
                    int y = (int) ((1 - progress) * target_pos[i, 1] + (progress * start_pos[i, 1]));

                    this.vertices[i].translate(x, y, false);
                }
            };
            timr.Interval = 50;
            timr.Start();
        }

        /**
         * @param target_pos target position for each point in Polygon
         * @param frame_count number of frame that construct the tweening
         */
        public void tweening2(int[,] target_pos, int frame_count, Callback callback)
        {
            if (target_pos.GetLength(0) < this.vertices.GetLength(0) || frame_count < 2)
            {
                Console.WriteLine("[Debug] Tweening failed, new points length not match.");
                return;
            }

            TweenerStudio.Point[] start_pos = (TweenerStudio.Point[])this.vertices.Clone();

			System.Windows.Forms.Timer timr = new System.Windows.Forms.Timer();
            timr.Tick += (sender, e) =>
            {
                animate_vertices(sender, e, start_pos, target_pos, frame_count, callback);
            };
            timr.Interval = 50;
            timr.Start();
        }

        private object animate_vertices(object sender, EventArgs e, Point[] start_pos, int[,] target_pos, int frame_count, Callback callback)
        {
			counter++;
			if (counter > frame_count)
			{
				return null;
			}

			for (int i = 0; i < this.vertices.GetLength(0); i++)
			{
				int delta_x = (target_pos[i, 0] - start_pos[i].X) / frame_count;
				int delta_y = (target_pos[i, 1] - start_pos[i].Y) / frame_count;

				this.vertices[i].translate(delta_x, delta_y, true);
			}

            // Call ticking callback
            callback();
            return null;
		}
    }
}
