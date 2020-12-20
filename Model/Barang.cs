using System;
using System.Collections.Generic;
using System.Text;

namespace Bukapediamall.Model
{
    public class Barang : Data
    {
        public Barang(int id, int harga, string nama, int qty) : base(id, harga)
        {
            this.Nama = nama;
            this.Qty = qty;
        }

        public string Nama { get; set; }
        public int Qty { get; set; }
    }
}
