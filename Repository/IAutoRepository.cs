using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    using Model;
    public interface IAutoRepository
    {



        IEnumerable<Auto> GetAll();
        void Add(Auto auto);
        void Remove(string name);
        Auto GetAutoByName(string name);



    }
}
