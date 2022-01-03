using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    public interface ITaxNumberLookUpService
    {
        //vergi numarası servisi
        //gerçekten böyle bir vergi nujmarası olup olmadığını sorgulamak için yazıldı
        bool Lookup(string txtNumber);

        //bizim bir vergi no soegulama sist olsun bu sorgulama sist nasıl çalıştığını bilmiyoruz y da farklı şekillerde sorgulama olabilir sistemde. bu sebeple işin özetini yazıp detayını ise ilgili 
    }
}
