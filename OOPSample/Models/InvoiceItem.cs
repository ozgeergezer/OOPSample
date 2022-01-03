using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Models
{
    public enum InvoiceUnitType
    {
        Montly = 1,
        Daily = 2,
        Hourly = 3,
        Quantity = 4
    }
    public class InvoiceItem
    {
        public string Description { get; private set; }
        public decimal UnitPrice { get; private set; } // birim fiyat
        public int UnitType { get; private set; } // 3 quantity
        private decimal _listPrice = 0;
        public decimal ListPrice
        {
            get
            {
                return _listPrice;
            }

        } // liste fiyatı hizmet fiyatı buraso 30 olur
        public int SequenceNo { get; private set; } = 1; // sıra no olacak 1,2,3,4,5 ilk sıra no 1 olduğu için default 1 olarak ayarlarız.
        public string Id { get; private set; }
        public int Amount { get; private set; }

        public InvoiceItem(string description, decimal unitPrice, InvoiceUnitType unitType, int amount)
        {
            Id = Guid.NewGuid().ToString();
            UnitType = (int)unitType; //db de int duracağı için int çevirdik
            SetAmount(amount);
            SetDescription(description);
            SetUnitPrice(unitPrice);
            //amount ve unitprice değerlerinin aldıkran sonra listprice hesaplıyoruz
            SetListPrice();
        }
        //listprice değerinin setter yazmadık veri tanabınında bu alanı tutmaya gerek yok fakat program tarafında invoice bir item eklendiğinde toplam fatura tutarını bulmak için tek bir item ait toplam maaliyetin hesaplanmış olması gerekiyor bu sebeple kullandık.
        private void SetListPrice()
        {
            _listPrice = Amount * UnitPrice;
        }
        private void SetAmount(int amount)
        {
            if (amount <= 0)
            {
                throw new Exception("miktar sıfırdan küçük girilemez");
            }
            Amount = amount;
        }
        private void SetUnitPrice(decimal unitPrice)
        {
            if (unitPrice <= 0)
            {
                throw new Exception("birim fiyat 0 ve daha küçük olamaz");
            }
        }
        private void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("mal ve hizmet alanı boş bırakılamaz");
            }
            Description = description.Trim();
        }
        public void SetSequenceNumber(int sequenceNumber) //invoice no 1 arttırır
        {
            SequenceNo = sequenceNumber;
        }
    }
}
