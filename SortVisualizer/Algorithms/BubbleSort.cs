using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;


namespace SortVisualizer
{
    class BubbleSort : SortInterface
    {
  
        private int[] mainArray;
        private Graphics g;
        private int MaxVal; // Max Val of bar Height
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public BubbleSort(int[] mainArray, Graphics g, int MaxVal)
        {
            this.mainArray = mainArray;
            this.g = g;
            this.MaxVal = MaxVal;
        }


        public void nextStep()
        {
            for (int i = 0; i < mainArray.Count() - 1; i++)
            {
                if (mainArray[i] > mainArray[i + 1])
                {
                    swap(i, i + 1);
                }
            }
        }
          

        private void swap(int i, int v)
        {
            int temp = mainArray[i];
            mainArray[i] = mainArray[i + 1];
            mainArray[i + 1] = temp;

            drawBar(i, mainArray[i]);
            drawBar(v, mainArray[v]);
        }

        private void drawBar(int position, int height)
        {
            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(RedBrush, position, MaxVal - mainArray[position], 1, MaxVal);
        }

        public bool isSorted()
        {
            for (int i = 0; i < mainArray.Count() - 1; i++)
            {
                if(mainArray[i] > mainArray[i + 1])
                {
                    return false;
                } 
            }
            return true;
        }

        public void reDraw()
        {
            for(int i = 0; i < (mainArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), i, MaxVal - mainArray[i], 1, MaxVal);
            }
        }

        public void completeSort()
        {
            for (int i = 0; i < (mainArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), i, MaxVal - mainArray[i], 1, MaxVal);
                System.Threading.Thread.Sleep(1);
            }

        }
    }
}
