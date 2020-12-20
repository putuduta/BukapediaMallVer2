using System;
using System.Collections.Generic;
using System.Text;

namespace Bukapediamall.Model
{
    public class Pulsa : Data
    {
        public Pulsa(int id, int harga, string nohp) : base(id, harga)
        {
            this.NoHp = nohp;
        }

        public string NoHp { get; set; }
    }
}
