using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public interface IMijnService
    {
        string Hello();
    }

    public class MijnService : IMijnService
    {
        public string Hello() { return "world"; }
    }

    public class MijnService2 : IMijnService
    {
        public string Hello()
        {
            return "Something";
        }
    }
}
