using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Models
{

    public class Invoice
    {
        public DateTime InvoiceDate { get; private set; }
        public Company Exporter { get; private set; } //alıcı faturayı kesen
        public Company Consignee { get; private set; } // mal hizmet alan firma
        public decimal TotalPrice { get; private set; }
        private List<InvoiceItem> _items = new List<InvoiceItem>();
        //list item readonly olarak işaretlenip sadece bu alanın get edilebileceğini söylemiş olduk.
        public IReadOnlyList<InvoiceItem> Items => _items;
        //public IReadOnlyList<InvoiceItem> Items
        //{
        //      get
        //          {
        //                 return _items;
        //          }
        //}
        public string Id { get; private set; }

        //fatura kesmek için kesen ve kesilen firma bilgilerini bilmemiz yeterlidir.

        public Invoice(Company exporter,Company consignee)
        {
            InvoiceDate = DateTime.Now; //fatura kesim işlem olan tarih olnalıdır bu yüzden dışardan bu bilgiyi almıyoruz.
            Id = Guid.NewGuid().ToString();
            Exporter = exporter;
            Consignee = consignee;
        }

        public void AddInvoiceItem(InvoiceItem item)//faturaya fatura ile alakalı hizmetlerin list eklenen yer
        {
            //item eklemeden önce eimizdeki invoiceıtem count üzerinden kaçıncı sırada old bildiğmiz için +1 arttırarak sequence number güncelleniyor.
            item.SetSequenceNumber(Items.Count+1);
            _items.Add(item);
            //her bir ekleme  sonrası bu iteme ait list pricelerin toplamı
            TotalPrice += item.ListPrice;
        }
    }
}
