using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeTry
{
    public partial class Form1 : Form     
    {
        Map arr;
        Graphics gr1;
        
        Point start;
        Brush brush;
        float cellwidth;
        float cellheight;
        public Form1()
        {
            InitializeComponent();
            start = new Point(45, 50);
            arr = new Map(panel1.Height, panel1.Width, start);
            gr1 = panel1.CreateGraphics();
            brush = new SolidBrush(Color.Black);
            cellwidth = panel1.Width / arr.Mymap.GetLength(0);
            cellheight = panel1.Height / arr.Mymap.GetLength(1);
            arr.initialisation();
            timer1.Start();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gr1.Clear(Color.White);
            arr.DrawHorisontalLines(gr1);
            arr.DrawVerticalLines(gr1);
            Drawmap(arr.Mymap);
            label2.Text = arr.Phase.ToString();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            arr.nextsec();
            panel1.Refresh();
            arr.Phase++;
            label2.Text = arr.Phase.ToString();



        }


        void Drawmap(int[,] a)
        {

            Pen pen = new Pen(brush);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == 1)
                        gr1.FillRectangle(brush, j * cellwidth, i * cellheight, cellwidth, cellheight);
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Stop();
                arr.nextsec();
                panel1.Refresh();
                arr.Phase++;
                label2.Text = arr.Phase.ToString();

            }
            if (e.KeyCode == Keys.Space)
            {
                timer1.Start();
            }
        }
    }
}
