using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizer
{
    class SortBubble : iSortInterface
    {
        private bool isSorted = false;
        private int[] mainArray;
        private Graphics g;
        private int MaxVal;
        Brush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);



        public void doSort(int[] mainArray, Graphics g, int MaxVal)
        {
            this.mainArray = mainArray;
            this.g = g;
            this.MaxVal = MaxVal;

            while (!isSorted)
            {
                for(int i = 0; i < mainArray.Count() - 1; i++)
                {
                    if(mainArray[i] > mainArray[i + 1])
                    {
                        swap(i, i + 1);
                    }
                }
                isSorted = Sorted();
            }
            
        }

        private void swap(int i, int v)
        {
            int temp = mainArray[i];
            mainArray[i] = mainArray[i + 1];
            mainArray[i + 1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxVal);
            g.FillRectangle(BlackBrush, v, 0, 1, MaxVal);


            g.FillRectangle(RedBrush, i, MaxVal - mainArray[i], 1, MaxVal);
            g.FillRectangle(RedBrush, v, MaxVal - mainArray[v], 1, MaxVal);
        }

        private bool Sorted()
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
    }
}
