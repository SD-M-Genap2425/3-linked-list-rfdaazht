namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;

        public DaftarKaryawan()
        {
            head = null;
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            if (head == null) {
                head = newNode;
            } else {
                KaryawanNode current = head;
                while (current.Next != null) {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Prev = current;
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            if (head == null) {
                return false;
            }

            if (head.Karyawan.NomorKaryawan == nomorKaryawan) {
                head = head.Next;
                if (head != null) {
                    head.Prev = null;
                }
                return true;
            }

            KaryawanNode current = head;
            while (current != null && current.Karyawan.NomorKaryawan != nomorKaryawan) {
                current = current.Next;
            }

            if (current != null) {
                if (current.Next != null) {
                    current.Next.Prev = current.Prev;
                }
                if (current.Prev != null) {
                    current.Prev.Next = current.Next;
                }
                return true;
            }

            return false;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode current = head;
            while (current != null) {
                if (current.Karyawan.Nama.Contains(kataKunci) || current.Karyawan.Posisi.Contains(kataKunci)) {
                    hasil.Add(current.Karyawan);
                }
                current = current.Next;
            }
            return hasil.ToArray();
        }

        public string TampilkanDaftar()
        {
            List<Karyawan> daftarKaryawan = new List<Karyawan>();
            KaryawanNode current = head;

            while (current != null) {
                daftarKaryawan.Add(current.Karyawan);
                current = current.Next;
            }

            daftarKaryawan.Reverse();

            string hasil = "";
            foreach (var karyawan in daftarKaryawan) {
                hasil += $"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}\n";
            }
            return hasil.TrimEnd();
        }
    }
}
