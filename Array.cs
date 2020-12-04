using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameOfLifeTry
{
    class Map
    {

        int phase;
        static int n = 15;
        static int m = 15;
        int[,] newmap;
        int[,] t;
        int Width;
        int Height;
        Point Start;
        Pen curpen;
        int[,] mymap;



        public Map( int height, int width, Point start)
        {
            Start = start;
            newmap = new int[n, m];
            t = new int[n, m];
            phase = 4;
            mymap = new int[n, m];
            Width = width;
            Height = height;
            

            curpen = new Pen(Color.Green, 3);



        }
        public int Phase
        {
            get { return phase; }
            set { phase = Math.Abs(value) % 8; }
        }
        public int[,] Mymap
        {
            get { return mymap; }

        }
        
        int [,]clean(int[,] arr)
        {
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    arr[i, j] = 0;
                }
            }
            return arr;
        }


        public void nextsec()
        {
            nextGeneration(mymap, newmap);
            arrrewrite(mymap, newmap);

        }

        public void initialisation()
        {

            int i = 3;
            for(int l = 0; l < 6; l++)
            {
                mymap[i, l + i] = 1;
                mymap[i + 1, l + i] = 1;
                mymap[l + i, mymap.GetLength(1) - i - 1] = 1;
                mymap[l + i, mymap.GetLength(1) - i - 2] = 1;
            }
            for (int l = mymap.GetLength(1); l > mymap.GetLength(1)-6;l--)
            {
                mymap[mymap.GetLength(1) - i - 1, l - i - 1] = 1;
                mymap[mymap.GetLength(1) - i - 2, l - i - 1] = 1;
                mymap[l - i - 1, i] = 1;
                mymap[l - i - 1, i + 1] = 1;
            }

        }

        int func(int [,] map, int i, int j) 
        {
           int neighbours = 0;

            for (int k = -1; k < 2; k++) //просмотр и подсчет всех соседей ячейки 
            {
                for (int l = -1; l < 2; l++)
                {
                    if (i + k >= 0 && i + k < mymap.GetLength(0) && j + l >= 0 && j + l < mymap.GetLength(1)) 
                    {

                        neighbours += mymap[i + k, j + l];
                    }
                }
            }

            neighbours -= mymap[i, j];
            if (neighbours == 3 || neighbours == 2 && mymap[i, j] == 1)
                return 1;
            else if (neighbours > 3 && mymap[i, j] == 1)
                return 0;
            else if (neighbours == 3 && mymap[i, j] == 0)
                return 1;
            else return 0;

        }

        void nextGeneration(int[,] mymap, int[,]newmap)
        {

            int neighbours = 0;

            for (int i = 0; i < mymap.GetLength(0); i++)
            {
                for (int j = 0; j < mymap.GetLength(1); j++)
                    //{
                    //    neighbours = 0;

                    //    for (int k = -1; k < 2; k++)
                    //    {
                    //        for (int l = -1; l < 2; l++)
                    //        {
                    //            if (i + k >= 0 && i + k < mymap.GetLength(0) && j + l >= 0 && j + l < mymap.GetLength(1))
                    //            {

                    //                    neighbours+= mymap[i + k,j + l];
                    //            }
                    //        }
                    //    }
                    //    neighbours -= mymap[i, j];
                    //    if (neighbours < 2 && mymap[i, j] == 1)
                    //        newmap[i, j] = 0;
                    //    else if (neighbours > 3 && mymap[i, j] == 1)
                    //        newmap[i, j] = 0;
                    //    else if (neighbours == 3 && mymap[i, j] == 0)
                    //        newmap[i, j] = 1;
                    //    else if (neighbours == 3 || neighbours == 2 && mymap[i, j] == 1)
                    //        newmap[i, j] = 1;
                    //}
                    newmap[i,j] = func(mymap, i, j);

            }

            
            //return newmap;
        }

        public void DrawVerticalLines(Graphics gr)
        {
            Pen p1 = new Pen(Color.AliceBlue, 1);
            double step = Width / mymap.GetLength(1);
            PointF begin;
            PointF end;
            for (double i = 0; i <= Width; i += step)
            {
                begin = new PointF((float)i, 0);
                end = new PointF((float)i, Height);
                gr.DrawLine(p1, begin, end);
            }
        }

        public void DrawHorisontalLines(Graphics gr)
        {
            Pen p1 = new Pen(Color.AliceBlue, 1);
            double step = Height / mymap.GetLength(0); 
            PointF begin;
            PointF end;
            for (double i = 0; i <= Height; i += step)
            {
                begin = new PointF(0, (float)i);
                end = new PointF(Width, (float)i);
                gr.DrawLine(p1, begin, end);
            }
        }

        void arrrewrite(int[,] ar1, int[,] ar2)
        {
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar2.GetLength(1); j++)
                {
                    ar1[i, j] = ar2[i, j];
                }
            }

            for (int i = 0; i< ar1.GetLength(0);i++)
            {
                for (int j = 0; j < ar2.GetLength(1);j++)
                {
                    ar1[i, j] = ar2[i,j];
                }
            } 
        }
       

    }
}
