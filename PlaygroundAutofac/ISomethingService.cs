using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundAutofac
{
    public interface ISomethingService
    {
        void DoSomething();
    }

    public class SomethingService : ISomethingService
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
