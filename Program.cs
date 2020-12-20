using Bukapediamall.Model;
using Bukapediamall.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bukapediamall
{
    class Program
    {
		public static BarangRepository barangRepository = new BarangRepository();
		public static PulsaRepository pulsaRepository = new PulsaRepository();

        public Program()
        {

			Console.Clear();
            Console.WriteLine(" BukapediaMall");
			Console.WriteLine("--------------");

			int pilih = 0;
			do
			{

				Console.WriteLine("1. Beli Pulsa");
				Console.WriteLine("2. Beli Barang");
				Console.WriteLine("3. Exit");
				Console.Write(">> ");
				pilih = int.Parse(Console.ReadLine());

				Console.Clear();

				if (pilih == 1)
				{
					beliPulsa();
					Console.Clear();
				}
				else if (pilih == 2)
				{
					beliBarang();
					Console.Clear();
				}
				else if (pilih == 3)
				{
					Console.WriteLine("Terima kasih sudah menggunakan Bukapediamall!!");
					Console.WriteLine("");
				}

			} while (pilih != 3);
		}


        static void Main(string[] args)
        {
            new Program();
        }


		public void beliPulsa()
        {
			int pilih = 0;
			do
			{
				Console.WriteLine("1. Add Item");
				Console.WriteLine("2. Lihat Keranjang");
				Console.WriteLine("3. Update Keranjang");
				Console.WriteLine("4. Hapus Pulsa dari Keranjang");
				Console.WriteLine("5. Checkout");
				Console.Write(">> ");
				pilih = int.Parse(Console.ReadLine());
				Console.Clear();

				if (pilih == 1)
				{
					AddPulsa();
					Console.Clear();
				}
				else if (pilih == 2)
				{
					ViewPulsa();
					Console.Clear();
				}
				else if (pilih == 3)
				{
					UpdatePulsa();
					Console.Clear();
				}
				else if (pilih == 4)
				{
					DeletePulsa();
					Console.Clear();
				}
				else if (pilih == 5)
				{
					Console.WriteLine("Terima kasih sudah menggunakan Bukapediamall!!");
					Console.WriteLine("");
					Console.ReadKey();
				}

			} while (pilih != 5);
		}

		public void beliBarang ()
        {
			int pilih = 0;
			do
			{
				Console.WriteLine("1. Add Item");
				Console.WriteLine("2. Lihat Keranjang");
				Console.WriteLine("3. Update Keranjang");
				Console.WriteLine("4. Hapus Barang dari Keranjang");
				Console.WriteLine("5. Checkout");
				Console.Write(">> ");
				pilih = int.Parse(Console.ReadLine());
				Console.Clear();

				if (pilih == 1)
				{
					AddBarang();
					Console.Clear();
				}
				else if (pilih == 2)
				{
					ViewBarang();
					Console.Clear();
				}
				else if (pilih == 3)
				{
					UpdateBarang();
					Console.Clear();
				}
				else if (pilih == 4)
				{
					DeleteBarang();
					Console.Clear();
				}
				else if (pilih == 5)
				{
					Console.WriteLine("Terima kasih sudah menggunakan Bukapediamall!!");
					Console.WriteLine("");
					Console.ReadKey();
				}

			} while (pilih != 5);
		}

		//Pulsa Section
		public void AddPulsa ()
        {
			int id = 0;
			string nohp = "";
			int harga;

			do
			{
				Console.Write("Input NoHp: ");
				nohp = Console.ReadLine();
			} while (nohp.Equals(""));

			do
			{
				Console.Write("Input Harga Pulsa: ");
				harga = Convert.ToInt32(Console.ReadLine());
			} while (harga < 0);


			Pulsa pulsa = new Pulsa(id, harga, nohp);
			pulsaRepository.Insert(pulsa);

			Console.WriteLine("Insert Data Success!");
			Console.ReadKey();
		}

		public void ViewPulsa()
		{
			List<Pulsa> listPulsa = pulsaRepository.View();

			if (listPulsa.Count == 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("There is no data here ....");
			}
			else
			{
				int i = 1;
				foreach (var item in listPulsa)
				{
					Console.WriteLine("");
					Console.WriteLine("Pulsa {0}", i++);
					Console.WriteLine("================");
					Console.WriteLine("Nama : " + item.NoHp);
					Console.WriteLine("Harga : " + item.Harga);
					Console.WriteLine();
				}
			}

			Console.ReadKey();
		}

		public void UpdatePulsa()
		{
			List<Pulsa> listPulsa = pulsaRepository.View();

			if (listPulsa.Count == 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("There is no data here ....");
			}
			else
			{
				int i = 1;
				foreach (var item in listPulsa)
				{
					Console.WriteLine("");
					Console.WriteLine("Pulsa {0}", i++);
					Console.WriteLine("================");
					Console.WriteLine("Nama : " + item.NoHp);
					Console.WriteLine("Harga : " + item.Harga);
					Console.WriteLine();
				}

				int idx = -1;
				do
				{
					Console.Write("Barang Index [1-{0}] [type `0` to exit]: ", listPulsa.Count);
					idx = int.Parse(Console.ReadLine());
				} while (idx < 0 || idx > listPulsa.Count);
				if (idx != 0)
				{
					int id = listPulsa.ElementAt(idx - 1).Id;
					string newnohp = "";
					int newharga;

					do
					{
						Console.Write("Input NoHp: ");
						newnohp = Console.ReadLine();
					} while (newnohp.Equals(""));

					do
					{
						Console.Write("Input Harga Pulsa: ");
						newharga = Convert.ToInt32(Console.ReadLine());
					} while (newharga < 0);


					Pulsa pulsa = new Pulsa(id, newharga, newnohp);
					pulsaRepository.Update(pulsa);

					Console.WriteLine("Update Data Success!");
					Console.ReadKey();
				}
			}
		}

		public void DeletePulsa()
		{
			List<Pulsa> listPulsa = pulsaRepository.View();

			if (listPulsa.Count == 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("There is no data here ....");
			}
			else
			{
				int i = 1;
				foreach (var item in listPulsa)
				{
					Console.WriteLine("");
					Console.WriteLine("Pulsa {0}", i++);
					Console.WriteLine("================");
					Console.WriteLine("Nama : " + item.NoHp);
					Console.WriteLine("Harga : " + item.Harga);
					Console.WriteLine();
				}

				int idx = -1;
				do
				{
					Console.Write("Pulsa Index [1-{0}] [type `0` to exit]: ", listPulsa.Count);
					idx = int.Parse(Console.ReadLine());
				} while (idx < 0 || idx > listPulsa.Count);
				if (idx != 0)
				{
					int id = listPulsa.ElementAt(idx - 1).Id;

					pulsaRepository.Delete(id);
					Console.WriteLine("Delete Success!!");
					Console.ReadKey();
				}
			}
		}

		//Barang Section
		public void AddBarang()
		{
			int id = 0;
			string name = "";
			int qty;
			int harga;

            do
            {
                Console.Write("Input Nama Barang: ");
				name = Console.ReadLine();
            } while (name.Equals(""));

			do
			{
				Console.Write("Input Harga Barang: ");
				harga = Convert.ToInt32(Console.ReadLine());
			} while (harga < 0);


			do
			{
				Console.Write("Input Barang Qty: ");
				qty = Convert.ToInt32(Console.ReadLine());
			} while (qty < 0);

			Barang barang = new Barang(id, harga, name, qty);
			barangRepository.Insert(barang);

            Console.WriteLine("Insert Data Success!");
			Console.ReadKey();

		}

		public void ViewBarang()
		{
            List<Barang> listBarang = barangRepository.View();

            if (listBarang.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("There is no data here ....");
            }
            else
            {
				int i = 1;
                foreach (var item in listBarang)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Barang {0}", i++);
                    Console.WriteLine("================");
                    Console.WriteLine("Nama : " + item.Nama);
                    Console.WriteLine("Harga : " + item.Harga);
                    Console.WriteLine("Qty : " + item.Qty);
                    Console.WriteLine();
                }
            }

			Console.ReadKey();
		}

		public void UpdateBarang()
		{
			List<Barang> listBarang = barangRepository.View();

			if (listBarang.Count == 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("There is no data here ....");
			}
			else
			{
				int i = 1;
				foreach (var item in listBarang)
				{
					Console.WriteLine("");
					Console.WriteLine("Barang {0}", i++);
					Console.WriteLine("================");
					Console.WriteLine("Nama : " + item.Nama);
					Console.WriteLine("Harga : " + item.Harga);
					Console.WriteLine("Qty : " + item.Qty);
					Console.WriteLine();
				}

				int idx = -1;
                do
                {
                    Console.Write("Barang Index [1-{0}] [type `0` to exit]: ", listBarang.Count);
					idx = int.Parse(Console.ReadLine());
                } while (idx < 0 || idx > listBarang.Count);
                if (idx != 0)
                {
					int id = listBarang.ElementAt(idx - 1).Id;
					string newname = "";
					int newqty;
					int newharga;

					do
					{
						Console.Write("Input Nama Barang: ");
						newname = Console.ReadLine();
					} while (newname.Equals(""));

					do
					{
						Console.Write("Input Harga Barang: ");
						newharga = Convert.ToInt32(Console.ReadLine());
					} while (newharga < 0);


					do
					{
						Console.Write("Input Barang Qty: ");
						newqty = Convert.ToInt32(Console.ReadLine());
					} while (newqty < 0);

					Barang barang = new Barang(id, newharga, newname, newqty);
					barangRepository.Update(barang);
                    Console.WriteLine("Update Success!!");
					Console.ReadKey();
				}
			}
		}

		public void DeleteBarang()
		{
			List<Barang> listBarang = barangRepository.View();

			if (listBarang.Count == 0)
			{
				Console.WriteLine(" ");
				Console.WriteLine("There is no data here ....");
			}
			else
			{
				int i = 1;
				foreach (var item in listBarang)
				{
					Console.WriteLine("");
					Console.WriteLine("Barang {0}", i++);
					Console.WriteLine("================");
					Console.WriteLine("Nama : " + item.Nama);
					Console.WriteLine("Harga : " + item.Harga);
					Console.WriteLine("Qty : " + item.Qty);
					Console.WriteLine();
				}

				int idx = -1;
				do
				{
					Console.Write("Barang Index [1-{0}] [type `0` to exit]: ", listBarang.Count);
					idx = int.Parse(Console.ReadLine());
				} while (idx < 0 || idx > listBarang.Count);
				if (idx != 0)
				{
					int id = listBarang.ElementAt(idx - 1).Id;

					barangRepository.Delete(id);
					Console.WriteLine("Delete Success!!");
					Console.ReadKey();
				}
			}
		}
	}
}
