using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Loader
{
    public class Builder
    {
        public void Step1()
        {
            Thread.Sleep(2000);
        }

        public void Step2()
        {
            Thread.Sleep(2000);
        }

        public void Step3()
        {
            Thread.Sleep(1000);
        }
    }
}
