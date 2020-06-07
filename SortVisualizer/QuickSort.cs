using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class QuickSort : SortInterface
    {
        private int[] mainArray;
        private Graphics g;
        private int MaxVal; // Max Val of bar Height
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        public QuickSort(int[] mainArray, Graphics g, int MaxVal)
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
                quickSort(mainArray, 0, mainArray.Count() - 1);
            }
        }

        private void quickSort(int[] mainArray, int left, int right)
        {
            int i;
            if (left < right)
            {
                i = partition(mainArray, left, right);

                quickSort(mainArray, left, i - 1);
                quickSort(mainArray, i + 1, right);
            }
        }

        private int partition(int[] mainArray, int left, int right)
        {
            int temp;
            int p = mainArray[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (mainArray[j] <= p)
                {
                    i++;
                    temp = mainArray[i];
                    mainArray[i] = mainArray[j];
                    drawBar(i, mainArray[i]);
                    mainArray[j] = temp;
                    drawBar(j, mainArray[j]);
                    System.Threading.Thread.Sleep(1);
                }
            }

            temp = mainArray[i + 1];
            mainArray[i + 1] = mainArray[right];
            drawBar(i+1, mainArray[i+1]);
            mainArray[right] = temp;
            drawBar(right, mainArray[right]);
            System.Threading.Thread.Sleep(1);
            return i + 1;
        }

        private void slide(int[] mainArray, int loc)
        {
            int temp = mainArray[loc];
            int j = loc;
            while (j > 0 && mainArray[j - 1] > temp)
            {
                mainArray[j] = mainArray[j - 1];
                drawBar(j, mainArray[j - 1]);
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
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i, MaxVal - mainArray[i], 1, MaxVal);
                System.Threading.Thread.Sleep(1);
            }

        }
    }
}
