using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class snakeElement
    {
        public int x;
        public int y;
        public int direction;
        [System.Diagnostics.DebuggerHidden]
        public snakeElement(int x, int y, int direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
        [System.Diagnostics.DebuggerHidden]
        public override string ToString()
        {
            return string.Format("x={0};y={1};d={2}", this.x, this.y, this.direction);

        }

    }
}
