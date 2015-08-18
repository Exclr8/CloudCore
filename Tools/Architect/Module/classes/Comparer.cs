using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic.Classes.Designer
{
    class Comparer : IComparer 
    {
        public int Compare(object proc1, object proc2)
        {
            SubProcess p1 = null;
            Model_BTProcessModel p2 = null;

            if (proc1 is SubProcess)
                p1 = (SubProcess) proc1;
            else if (proc1 is Model_BTProcessModel)
                p2 = (Model_BTProcessModel) proc1;
            else
                throw new Exception("Object is not of type IProcess or Model_BTProcessModel.");

            if (proc2 is SubProcess)
                p1 = (SubProcess)proc2;
            else if (proc2 is Model_BTProcessModel)
                p2 = (Model_BTProcessModel)proc2;
            else
                throw new Exception("Object is not of type IProcess or Model_BTProcessModel.");

            return p1.CompareTo(p2);

        }

    }
}
