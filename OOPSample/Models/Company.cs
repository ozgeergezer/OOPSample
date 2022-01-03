using OOPSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Models
{
    public class Company
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string TaxNumber { get; private set; } //Vergino
        public string PhoneNumber { get; private set; } //şirket hattı
        private ICompanyAddressService _companyAddressService; // adresleri sisteme compnay ile girmeden önce adres sorgulaması yapacağız
        private ITaxNumberLookUpService _taxNumberLookUpService;

        public Company(string name, string address, string taxNumber, ICompanyAddressService companyAddressService, ITaxNumberLookUpService taxNumberLookUpService)
        {
            _companyAddressService = companyAddressService;
            _taxNumberLookUpService = taxNumberLookUpService;
            SetCompanyName(name);
            SetAddress(address);
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new Exception("telefon no boş geçilemez");
            }
            PhoneNumber = phoneNumber;
        }
        private void SetTaxNumber(string taxNumber)
        {
            var result = _taxNumberLookUpService.Lookup(TaxNumber);
            if (!result)
            {
                throw new Exception("böyle bir vergi no sistemde mevcut değildir");
            }
            TaxNumber = taxNumber;
        }
        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Adres alanı boş olamaz");
            }
            if (address.Length < 20)
            {
                throw new Exception("minimum 20 karaketre ulaşmalıdır.");
            }
            //adres service ile bu adresin gerçekte olup olmadığını teyit etmemiz gerelir.

            var result = _companyAddressService.CheckAddress(address);
            if (result == false)
            {
                throw new Exception("böyle bir adres sistemde bulunmamaktadır.");
            }
            Address = address.Trim();
        }
        private void SetCompanyName(string name)//name encapsulation yaptık 
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("şirket adı boş geçilemez");
            }
            Name = name.Trim(); //kullanıcı input içinde name alanını ön arkasında boşluklu girebilir bu boşlukları sisteme girmeden önce kaldırıyoruz.
        }
    }
}
