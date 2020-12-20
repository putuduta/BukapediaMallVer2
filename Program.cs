using System;

namespace Bukapediamall
{
    class Program
    {

        public Program()
        {

			Console.Clear();
            Console.WriteLine(" Bukapediamal");
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
    }
}
