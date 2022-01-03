using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    class GoogleAddressServices : ICompanyAddressService
    {
        public bool CheckAddress(string address)
        {
            return false;
            //google maps api kullanılarak adres sorgulaması yapılacak
        }
    }
}
