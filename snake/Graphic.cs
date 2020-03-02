using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace snake
{
    class Graphic
    {
        private Engine engine;

        public Graphic(Engine engine,Size gSize)
        {
            // TODO: Complete member initialization
            this.engine = engine;
            setSize(gSize.Width,gSize.Height);
        }
        private Dictionary<int, Bitmap> textures;
        public Dictionary<int, Bitmap> loadTextures(Size tSize)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            Dictionary<int, Bitmap> textures = new Dictionary<int, Bitmap>();
            int t_width = tSize.Width;
            int t_height = tSize.Height;
            Bitmap b = new Bitmap(t_width, t_height);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            g.DrawRectangle(new Pen(Color.Purple), new Rectangle(0, 0, t_width - 1, t_height - 1));
            textures.Add(25, b);

            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Blue);
            textures.Add(2, b);

            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Green);
            textures.Add(0, b);

            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Yellow);
            textures.Add(3, b);

            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Red);
            textures.Add(1, b);
            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Purple);
            textures.Add(4, b);

            textures.Add(5, b);
            textures.Add(6, b);
            textures.Add(7, b);
            textures.Add(8, b);
            textures.Add(9, b);
            textures.Add(10, b);
            textures.Add(11, b);
            textures.Add(12, b);
            textures.Add(13, b);
            textures.Add(14, b);
            textures.Add(15, b);
            textures.Add(16, b);
            textures.Add(17, b);
            textures.Add(18, b);
            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.Aqua);
            textures.Add(30, b);//food

            b = new Bitmap(t_width, t_height);
            g = Graphics.FromImage(b);
            g.Clear(Color.FromArgb(255, 165, 2, 250));
            textures.Add(42, b);//head

            Stream file = thisAssembly.GetManifestResourceStream("snake.textures.fail.png");
            b = (Bitmap)Bitmap.FromStream(file);
            textures.Add(666, b);//fail
            return textures;
        }
        public void setSize(int width, int height) {
            this.width = width;
            this.height=height;
            tWidth=width/engine.width;
            tHeight=height/engine.height;
            textures = loadTextures(new Size(tWidth,tHeight ));
        }
        public void setSize(Size s)
        {
            setSize(s.Width, s.Height);
        }
        int tWidth = 0;
        int tHeight = 0;
        public Bitmap Render()
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(b);
            for (int i = 0; i < engine.width; i++)
            {
                for (int i1 = 0; i1 < engine.height; i1++)
                {
                    g.DrawImage(textures[25], new Point(i * tWidth, i1 * tHeight));

                }
            }
            g.DrawImage(textures[30], new Point(engine.food.x * tWidth, engine.food.y * tHeight));//food
            foreach (snakeElement se in engine.sn.elements)
            {
                g.DrawImage(textures[se.direction], new Point(se.x * tWidth, se.y * tHeight));

            }
            g.DrawImage(textures[42], new Point(engine.sn.elements[0].x * tWidth, engine.sn.elements[0].y * tHeight));//head
            if (this.fail)
            {
                Bitmap bFail = textures[666];
                Point pFail = new Point((b.Width / 2) - (bFail.Width / 2), (b.Height / 2) - (bFail.Height / 2));
                g.DrawImage(bFail, pFail);

            }
            return b;
        }

        public int width { get; private set; }
        public int height { get; private set; }
        public bool fail { get; set; }
    }
}
