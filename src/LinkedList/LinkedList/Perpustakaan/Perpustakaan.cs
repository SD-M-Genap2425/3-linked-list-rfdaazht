namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Buku { get; set; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Buku = buku;
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public KoleksiPerpustakaan()
        {
            head = null;
        }

        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);
            if (head == null) {
                head = newNode;
            } else {
                BukuNode current = head;
                while (current.Next != null) {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool HapusBuku(string judul)
        {
            if (head == null) {
                return false;
            }

            if (head.Buku.Judul == judul) {
                head = head.Next;
                return true;
            }

            BukuNode current = head;
            while (current.Next != null && current.Next.Buku.Judul != judul) {
                current = current.Next;
            }

            if (current.Next != null) {
                current.Next = current.Next.Next;
                return true;
            }

            return false;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasil = new List<Buku>();
            BukuNode current = head;
            while (current != null) {
                if (current.Buku.Judul.Contains(kataKunci)) {
                    hasil.Add(current.Buku);
                }
                current = current.Next;
            }
            return hasil.ToArray();
        }

        public string TampilkanKoleksi()
        {
            if (head == null) {
                return string.Empty;
            }

            string hasil = "";
            BukuNode current = head;

            while (current != null) {
                hasil += $"\"{current.Buku.Judul}\"; {current.Buku.Penulis}; {current.Buku.Tahun}\n";
                current = current.Next;
            }

            return hasil.TrimEnd();
        }
    }
}
