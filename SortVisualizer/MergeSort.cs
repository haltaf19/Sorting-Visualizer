using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizer 
{
    class MergeSort : SortInterface
    {
        private int[] mainArray;
        private Graphics g;
        private int MaxVal; // Max Val of bar Height
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);


        public MergeSort(int[] mainArray, Graphics g, int MaxVal)
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
            mergeSort(mainArray, 0, mainArray.Count() - 1);
        }

        private void mergeSort(int[] mainArray, int lo, int hi)
        {
            if (lo < hi)
            {
                int middle = (lo + hi) / 2;


                mergeSort(mainArray, lo, middle);
                mergeSort(mainArray, middle + 1, hi);

                Merge(mainArray, lo, middle, hi);
            }
        }
    
        

        private void Merge(int[] mainArray, int lo, int middle, int hi)
        {
            int[] leftArray = new int[middle - lo + 1];
            int[] rightArray = new int[hi - middle];

            Array.Copy(mainArray, lo, leftArray, 0, middle - lo + 1);
            Array.Copy(mainArray, middle + 1, rightArray, 0, hi - middle);

            int i = 0;
            int j = 0;
            for (int k = lo; k < hi + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    mainArray[k] = rightArray[j];
                    drawBar(k, mainArray[k]);
                    System.Threading.Thread.Sleep(2);
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    mainArray[k] = leftArray[i];
                    drawBar(k, mainArray[k]);
                    System.Threading.Thread.Sleep(2);
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    mainArray[k] = leftArray[i];
                    drawBar(k, mainArray[k]);
                    System.Threading.Thread.Sleep(2);
                    i++;
                }
                else
                {
                    mainArray[k] = rightArray[j];
                    drawBar(k, mainArray[k]);
                    System.Threading.Thread.Sleep(2);
                    j++;
                }
            }
        }

        /*private void slide(int[] mainArray, int loc)
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

        }*/

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
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Purple), i, MaxVal - mainArray[i], 1, MaxVal);
                System.Threading.Thread.Sleep(1);
            }

        }

    }
}
