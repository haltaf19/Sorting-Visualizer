using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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

            
        }
    }
}
