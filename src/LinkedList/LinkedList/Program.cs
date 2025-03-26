namespace LinkedList;
using LinkedList.Perpustakaan;
using LinkedList.ManajemenKaryawan;
using LinkedList.Inventori;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        KoleksiPerpustakaan koleksi = new KoleksiPerpustakaan();
            
        koleksi.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        koleksi.TambahBuku(new Buku("1984", "George Orwell", 1949));
        koleksi.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));

        Console.WriteLine("Daftar Buku Perpustakaan:");
        koleksi.TampilkanKoleksi();

        Console.WriteLine("\nCari Buku dengan kata kunci 'The':");
        Buku[] hasilCariBuku = koleksi.CariBuku("The");
        foreach (var buku in hasilCariBuku)
        {
            Console.WriteLine($"\"{buku.Judul}\"; {buku.Penulis}; {buku.Tahun}");
        }

        Console.WriteLine("\nMenghapus Buku '1984':");
        bool berhasilHapusBuku = koleksi.HapusBuku("1984");
        Console.WriteLine(berhasilHapusBuku ? "Buku berhasil dihapus" : "Buku tidak ditemukan");

        Console.WriteLine("\nDaftar Buku Perpustakaan setelah penghapusan:");
        koleksi.TampilkanKoleksi();

        Console.WriteLine();
        
        // Soal ManajemenKaryawan
        DaftarKaryawan daftarKaryawan = new DaftarKaryawan();
            
        daftarKaryawan.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftarKaryawan.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
        daftarKaryawan.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));

        Console.WriteLine("Daftar Karyawan:");
        daftarKaryawan.TampilkanDaftar();

        Console.WriteLine("\nCari Karyawan dengan kata kunci 'Jane':");
        Karyawan[] hasilCariKaryawan = daftarKaryawan.CariKaryawan("Jane");
        foreach (var karyawan in hasilCariKaryawan)
        {
            Console.WriteLine($"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}");
        }

        Console.WriteLine("\nMenghapus Karyawan '002':");
        bool berhasilHapusKaryawan = daftarKaryawan.HapusKaryawan("002");
        Console.WriteLine(berhasilHapusKaryawan ? "Karyawan berhasil dihapus" : "Karyawan tidak ditemukan");

        Console.WriteLine("\nDaftar Karyawan setelah penghapusan:");
        daftarKaryawan.TampilkanDaftar();

        Console.WriteLine();

        // Soal Inventori
        ManajemenInventori inventori = new ManajemenInventori();
            
        inventori.TambahItem(new Item("Apple", 50));
        inventori.TambahItem(new Item("Orange", 30));
        inventori.TambahItem(new Item("Banana", 20));

        Console.WriteLine("Inventori:");
        inventori.TampilkanInventori();

        Console.WriteLine("\nMenghapus Item 'Orange':");
        bool berhasilHapusItem = inventori.HapusItem("Orange");
        Console.WriteLine(berhasilHapusItem ? "Item berhasil dihapus" : "Item tidak ditemukan");

        Console.WriteLine("\nInventori setelah penghapusan:");
        inventori.TampilkanInventori();
    }
}