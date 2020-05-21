using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SelectionSort : SortInterface
    {
        private int[] mainArray;
        private Graphics g;
        private int MaxVal; // Max Val of bar Height
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlueBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public SelectionSort(int[] mainArray, Graphics g, int MaxVal)
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

        public void nextStep()
        {
            for (int i = 0; i < mainArray.Count(); i++)
            {
                int min = FindMin(mainArray, i);
                int temp = mainArray[i];
                mainArray[i] = mainArray[min];
                drawBar(i, mainArray[min]);
                System.Threading.Thread.Sleep(5);
                mainArray[min] = temp;
                drawBar(min, temp);
                System.Threading.Thread.Sleep(5);
            }
        }

        private void drawBar(int position, int height)
        {

            g.FillRectangle(BlackBrush, position, 0, 1, MaxVal);
            g.FillRectangle(BlueBrush, position, MaxVal - mainArray[position], 1, MaxVal);
            g.FillRectangle(RedBrush, position, MaxVal - mainArray[position], 1, MaxVal);
        }

        private int FindMin(int[] mainArray, int a)
        {
            int retloc = a;
            int voi = mainArray[a];
            for (int i = a + 1; i < mainArray.Count(); i++)
            {
                if (mainArray[i] < voi)
                {
                    retloc = i;
                    voi = mainArray[i];
                }
                
            }
            return retloc;
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
                g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Green), i, MaxVal - mainArray[i], 1, MaxVal);
                System.Threading.Thread.Sleep(1);
            }

        }
    }
}
