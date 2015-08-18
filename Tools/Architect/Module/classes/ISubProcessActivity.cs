using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic.Classes.Designer
{
    public interface ISubProcessActivity
    {
        Activity ToActivity();
        SubProcess ToProcess();
    }
}
