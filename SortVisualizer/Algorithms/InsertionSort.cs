using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class InsertionSort : SortInterface
    {
        private int[] mainArray;
        private Graphics g;
        private int MaxVal; // Max Val of bar Height
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public InsertionSort(int[] mainArray, Graphics g, int MaxVal)
        {
            this.mainArray = mainArray;
            this.g = g;
            this.MaxVal = MaxVal;
        }
        public bool isSorted()
        {
            for (int i = 0; i < mainArray.Count() - 1; i++)
            {
                if (mainArray[i] > mainArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private void drawBar(int position, int height)
        {

            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(RedBrush, position, MaxVal - mainArray[position], 1, MaxVal);
        }

        public void nextStep()
        {
            for (int i = 1; i < mainArray.Count(); i++)
            {
                slide(mainArray, i);
            }
        }

        private void slide(int[] mainArray, int loc)
        {
            int temp = mainArray[loc];
            int j = loc;
            while(j > 0 && mainArray[j-1] > temp)
            {
                mainArray[j] = mainArray[j - 1];
                drawBar(j, mainArray[j-1]);
                j--;
            }
            mainArray[j] = temp;
            drawBar(j, temp);

        }

        public void reDraw()
        {
            for (int i = 0; i < (mainArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Red), i, MaxVal - mainArray[i], 1, MaxVal);
            }
        }
        public void completeSort()
        {
            for (int i = 0; i < (mainArray.Count() - 1); i++)
            {
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Blue), i, MaxVal - mainArray[i], 1, MaxVal);
                System.Threading.Thread.Sleep(1);
            }

        }
    }
}
