using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    public class NBuyTaxNumberLookUpService : ITaxNumberLookUpService
    {
        public List<string> _taxtNumber
        {
            get
            {
                return new List<string> { "78945623", "987654321", "741852963", "147258369","852741963" };
            }
        }
        public bool Lookup(string txtNumber)
        {
            throw new NotImplementedException();
        }
    }
}
