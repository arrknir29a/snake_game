using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        Engine engine=null;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine(20, 20, 150,grahpicsPanel.Size);

            engine.start();
            Render();
            Tupdate = new Thread(update_thread);
            Tupdate.IsBackground = true;
            Tupdate.Start();
            
            
        }


        private void update_thread(object obj)
        {
           while(true){
               try
               {
                   engine.update();
                   Render();
                   Thread.Sleep(100);
               }
               catch (ObjectDisposedException)
               {
                   return;
               }
               catch(IndexOutOfRangeException) {
                   engine.getGraphic().fail = true;
                   Render();
                   Thread.Sleep(1000);
                   engine.getGraphic().fail = false;
                   engine.start();
               }


           }
        }
        private Thread Tupdate;


        private void button1_Click(object sender, EventArgs e)
        {
            engine.update();
        }
        
        private void Render()
        {
            if (!this.InvokeRequired)
            {

                textBox1.Text = engine.sn.elements.Count + "\r\n";

                foreach (snakeElement se in engine.sn.elements)
                {
                    textBox1.Text += se.ToString() + "\r\n";
                }
                if(pictureBox1.Image!=null) pictureBox1.Image.Dispose();
                pictureBox1.Image = engine.getGraphic().Render();
            }
            else {

                this.Invoke(new _render(Render));
            }
        }
        private delegate void _render();
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
                case Keys.W:
                    engine.setDirection(2);
                    e.Handled = true;
                    break;
                case Keys.S:
                    engine.setDirection(0);
                    e.Handled = true;
                    break;
                case Keys.D:
                    engine.setDirection(1);
                    e.Handled = true;
                    break;
                case Keys.A:
                    engine.setDirection(3);
                    e.Handled = true;
                    break;
                case Keys.Up:
                    engine.setDirection(2);
                    e.Handled = true;
                    break;
                case Keys.Down:
                    engine.setDirection(0);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    engine.setDirection(1);
                    e.Handled = true;
                    break;
                case Keys.Left:
                    engine.setDirection(3);
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.grahpicsPanel.Size = this.grahpicsPanel.oldSize;
                    e.Handled = true;
                    break;
            }
            
           // update();
            
        }
       
        private void grahpicsPanel_Resize(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Size = this.grahpicsPanel.Size;
                engine.getGraphic().setSize(pictureBox1.Size);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.grahpicsPanel.oldSize = this.grahpicsPanel.Size;
            this.grahpicsPanel.Size = Screen.FromControl(this).WorkingArea.Size;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
