using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizer
{
    interface SortInterface
    {
        void nextStep();
        bool isSorted();

        void reDraw();
    }
}
