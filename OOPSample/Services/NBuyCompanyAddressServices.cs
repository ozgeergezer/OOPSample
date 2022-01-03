using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    //bir şirketin kayıt işlemleri register işlemleri sırasında böyle bir adresin olup olmadığını teit etmek için sorgulama yaapan servis
    //bu sorgulama servisi şu an için bir liste üzerinden kontrol edilecek olup ilerleyen zamanlarda e devlet adres sorgulama sistemine bağlanabilir.
    public class NBuyCompanyAddressServices : ICompanyAddressService
    {
        List<string> companyAddress = new List<string>();

        public NBuyCompanyAddressServices()
        {
            companyAddress.Add("Mecidiye, İskele Sk., 34347 Beşiktaş/İstanbul");
            companyAddress.Add("Teşvikiye, Güzelbahçe Sk. No:20, 34365 Şişli/İstanbul");
            companyAddress.Add("Piri Paşa, Aziz Sk. No:5 D:No:5, 34445 Beyoğlu/İstanbul");
            companyAddress.Add("Örnektepe, İmrahor Cd. No:7, 34445 Beyoğlu/İstanbul");
        }
        public bool CheckAddress(string address)
        {
            return companyAddress.Any(cAddress => cAddress == address); // true / false döner
        }
    }
}
