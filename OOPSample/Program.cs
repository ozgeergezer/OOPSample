using OOPSample.Models;
using OOPSample.Services;
using System;

namespace OOPSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //not : company adress service ve TaxNumberLookUpService farklı şekillerde sorgulama yapabilme kaabiletine sahip olsunlar diye company constructor içerisinde interfaceler üzerinden bağlantı kuruldu bu sayede company constractor içine gönderilen classlar ile adepte bir şelilde çalışması sağlandı. polimorfizm ve interface vasıtası ile gerçekleştirildi
            //constructor with interfaces
       
            var company1 = new Company(name: "NBuy LTD ŞTİ",
                address: "Örnektepe, İmrahor Cd. No:7, 34445 Beyoğlu/İstanbul",
                taxNumber: "78945623",
                companyAddressService: new NBuyCompanyAddressServices(),
                taxNumberLookUpService: new NBuyTaxNumberLookUpService()
                );
            var company2 = new Company(name: "NBuy İzmir LTD ŞTİ",
                address: "Piri Paşa, Aziz Sk. No:5 D:No:5, 34445 Beyoğlu/İstanbul",
                taxNumber: "987654321",
                companyAddressService: new NBuyCompanyAddressServices(),
                taxNumberLookUpService: new NBuyTaxNumberLookUpService()
                );

            var invoice = new Invoice(exporter: company1, consignee: company2);
            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Tasarım Bedeli",
                    unitPrice: 1000,
                    unitType: InvoiceUnitType.Hourly,
                    amount: 5
                    ));
            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Yazılım Bedeli",
                    unitPrice: 100,
                    unitType: InvoiceUnitType.Hourly,
                    amount: 8
                    ));
            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Sosyal medya hizmet Bedeli",
                    unitPrice: 5000,
                    unitType: InvoiceUnitType.Hourly,
                    amount: 1
                    ));



            Console.WriteLine("Hello World!");
        }
    }
}
