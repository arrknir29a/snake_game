using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Snake
    {
      public List<snakeElement> elements=null;
      private Engine en;
      public Snake(Engine en) {
          this.en = en;
          this.elements = new List<snakeElement>();
      }
      public void addElement(int x,int y,int d) {
      
      }
      public void addElement()
      {
          int tDirection;
          if (this.elements[this.elements.Count - 1].direction > 3)
          {
              tDirection = (this.elements[this.elements.Count - 1].direction / 2) - 2;
          }
          else
          {
              tDirection = this.elements[this.elements.Count - 1].direction;
          }
          int _x = this.elements[this.elements.Count - 1].x;
          int _y = this.elements[this.elements.Count - 1].y;
          switch (this.elements[this.elements.Count - 1].direction)
          {
              case 0: _y -= 1; break;
              case 1: _x -= 1; break;
              case 2: _y += 1; break;
              case 3: _x += 1; break;
              case 4: _x -= 1; break;
              case 5: _x += 1; break;
              case 6: _y += 1; break;
              case 7: _y -= 1; break;
              case 8: _x += 1; break;
              case 9: _x -= 1; break;
              case 10: _y -= 1; break;
              case 11: _y += 1; break;
          }
          this.addElement(new snakeElement(_x, _y, tDirection));
      }
      internal void addElement(snakeElement snakeElement)
      {
          this.elements.Add(snakeElement);
      }
      public void move()
      {
          bool pickfood = false;
          for (int i = 0; i < this.elements.Count; i++)
          {
              switch (this.elements[i].direction)
              {

                  case 0:
                      this.elements[i].y += 1;
                      break;
                  case 1:
                      this.elements[i].x += 1;
                      break;
                  case 2:
                      this.elements[i].y -= 1;
                      break;
                  case 3:
                      this.elements[i].x -= 1;//<---
                      break;
                  case 4:
                      this.elements[i].y += 1;
                      this.elements[i].direction = 0;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 4;
                          this.elements[i].x += 1;
                      }
                      break;
                  case 5:
                      this.elements[i].y += 1;
                      this.elements[i].direction = 0;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 5;
                          this.elements[i].x -= 1;
                      }
                      break;
                  case 6:
                      this.elements[i].x += 1;
                      this.elements[i].direction = 1;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 6;
                          this.elements[i].y -= 1;
                      }
                      break;
                  case 7:
                      this.elements[i].x += 1;
                      this.elements[i].direction = 1;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 7;
                          this.elements[i].y += 1;
                      }
                      break;
                  case 8:
                      this.elements[i].y -= 1;
                      this.elements[i].direction = 2;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 8;
                          this.elements[i].x -= 1;
                      }
                      break;
                  case 9:
                      this.elements[i].y -= 1;
                      this.elements[i].direction = 2;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 9;
                          this.elements[i].x += 1;
                      }
                      break;
                  case 10:
                      this.elements[i].x -= 1;
                      this.elements[i].direction = 3;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 10;
                          this.elements[i].y += 1;
                      }
                      break;
                  case 11:
                      this.elements[i].x -= 1;
                      this.elements[i].direction = 3;
                      if (i + 1 < this.elements.Count)
                      {
                          i++;
                          this.elements[i].direction = 11;
                          this.elements[i].y -= 1;
                      }
                      break;
                  default:
                      break;
              }
              if (this.elements[0].x == en.food.x & this.elements[0].y == en.food.y)
              {

                  pickfood = true;
              }
              if (this.elements[i].x >= en.width || this.elements[i].y >= en.height || this.elements[i].x < 0 || this.elements[i].y < 0)
              {
                  throw new IndexOutOfRangeException();
              }
          }

          if (pickfood)
          {
              en.food.genNew();
              this.addElement();

          }
      }


    }
}
