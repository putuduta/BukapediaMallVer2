using System;
using System.Collections.Generic;
using System.Text;

namespace Bukapediamall.Model
{
    public abstract class Data
    {
        public int Id { get; set; }
        public int Harga { get; set; }

        public Data(int id, int harga)
        {
            this.Id = id;
            this.Harga = harga;
        }
    }
}
