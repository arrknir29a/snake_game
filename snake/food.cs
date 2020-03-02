using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Food
    {
       public int x;
      public  int y;
       public int width;
      public  int height;
        Snake sn;
        public Food(Snake sn, int width, int height)
        {
            this.sn = sn;
            this.width = width;
            this.height = height;
            genNew();
        }
        public void genNew() {
            Random rand = new Random();
            bool asd = false;
            do{
            x= rand.Next(0, width);
            y = rand.Next(0, height);
              foreach (snakeElement se in sn.elements){
                  if (x == se.x & y == se.y)
                  {
                      asd = true;
                      Thread.Sleep(new Random(DateTime.Now.Millisecond).Next(0, 100));
                      break;
                  }
                  else {
                      asd = false;
                  }
              }
            }while(asd);
           
        }
    }
}
