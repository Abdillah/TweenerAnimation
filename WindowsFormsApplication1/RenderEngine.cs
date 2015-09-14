using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweenerStudio
{
    class RenderEngine
    {
        Panel canvas;
        List<Polygon> queue;

        Pen pen;

        /**
         * Yet, we accept panel as canvas.
         */
        public RenderEngine(Panel panel)
        {
            this.canvas = panel;
            this.canvas.Paint += render;

            this.queue = new List<Polygon>();

            this.pen = new Pen(new SolidBrush(Color.Red));
            pen.Width = 2;
        }

        private void render(object sender, PaintEventArgs e)
        {
            foreach (Polygon poly in queue) {
                e.Graphics.DrawPolygon(pen, poly.get_vertices_builtin_point());
            }
        }

        public void render()
        {
            canvas.Invalidate();
            canvas.Refresh();
        }

        public void render(ref Polygon poly)
        {
            if (poly == null)
            {
                return;
            }
            queue.Add(poly);
            render();
        }

        public void remove(Polygon poly)
        {
            if (poly == null)
            {
                return;
            } 
            queue.Remove(poly);
            render();
        }
    }
}
