using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace snake
{
    class Engine
    {
        public Snake sn;
        public Food food;
       
        public Engine(int height,int width,int updateInterval,Size gSize) {
            this.height = height;
            this.width = width;
            this.updateInterval = updateInterval;
            this.graphic = new Graphic(this,gSize);
            

        }
        Graphic graphic=null;
        public void setGraphic(Graphic g) {
            this.graphic = g;
        }
        public Graphic getGraphic() {
            return graphic;
        }
        public void start()
        {
            Random rand = new Random();
           
            int direction = rand.Next(0, 3);
            sn = new Snake(this);
            
            //WindowState = FormWindowState.Maximized;
            sn.addElement(new snakeElement(width / 2, height / 2, rand.Next(0, 3)));
            
            food = new Food(sn, this.width, this.height);
            
        }
        private int updateCount = 0;
        private int direction = -1;
        public void update()
        {
            if (direction != -1)
            {
                if (sn.elements.Count > 1)
                {
                    if (sn.elements[0].direction != this.direction)
                    {
                        int tDirection;
                        if (sn.elements[1].direction > 3)
                        {
                            tDirection = (sn.elements[1].direction / 2) - 2;
                        }
                        else
                        {
                            tDirection = sn.elements[1].direction;
                        }
                        switch (this.direction)//sn.elements[1].direction-((sn.elements[1].direction / 4) * 4)
                        {
                            case 0:
                                switch (tDirection)
                                {
                                    case 1:
                                        sn.elements[0].direction = 4;
                                        break;
                                    case 3:
                                        sn.elements[0].direction = 5;
                                        break;
                                }
                                break;
                            case 1:
                                switch (tDirection)
                                {
                                    case 0:
                                        sn.elements[0].direction = 7;
                                        break;
                                    case 2:
                                        sn.elements[0].direction = 6;
                                        break;
                                }
                                break;
                            case 2:
                                switch (tDirection)
                                {
                                    case 1:
                                        sn.elements[0].direction = 9;
                                        break;
                                    case 3:
                                        sn.elements[0].direction = 8;
                                        break;
                                }
                                break;
                            case 3:
                                switch (tDirection)
                                {
                                    case 0:
                                        sn.elements[0].direction = 10;
                                        break;
                                    case 2:
                                        sn.elements[0].direction = 11;
                                        break;
                                }
                                break;
                        }
                    }

                }
                else
                {
                    sn.elements[0].direction = this.direction;
                }
            }
            direction = -1;
            sn.move();

            if (this.updateCount > 10)
            {
                this.updateCount = 0;

               // GC.Collect();
            }
            else
            {
                this.updateCount++;
            }
        }
        
        internal void setDirection(int p)
        {
            this.direction = p;
        }



        public int height { get; set; }
        public int width { get; set; }
        public int updateInterval { get; set; }

        
    }
}
