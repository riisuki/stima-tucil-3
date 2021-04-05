
| Tugas Kecil Strategi Algoritma 3
| Shortest Path A*

>> Cara Menjalankan
   Buka file .exe dalam folder /bin

>> Cara Menggunakan
   1. Gunakan 'Browse' untuk memilih file input.
      Contoh format file input:

      3
      0 1 1
      1 0 0
      1 0 0
      -6.894916 107.608823
      -6.894789 107.610150
      -6.894738 107.611758
      Simpul A*
      Simpul B*
      Simpul C*

      (Keterangan: Baris pertama berisi jumlah simpul dalam graf (n).
                   N baris berikutnya berisi matriks ketetanggaan.
                   Nilai 1 menyatakan bahwa simpul i,j terhubung,
                   sedangkan nilai 0 menyatakan bahwa simpul i,j
                   tidak terhubung. N baris berikutnya menyatakan
                   nilai latitude dan longitude tiap simpul secara
                   berurutan yang dipisah oleh satu spasi. N baris
                   berikutnya menyatakan nama simpul secara berurutan*.)

       * = Opsional. Jika tidak ditulis, simpul akan bernama 1, 2, dst.

   2. Pilih simpul awal dan simpul tujuan pada menu dropdown. Kedua simpul
      harus berbeda, jika sama akan muncul error message.
   3. Klik tombol 'Search' yang berada di bagian bawah window.
   4. Jika ada jalur, akan ditampilkan rute jalur terpendek pada textbox
      dan graf sebagai garis tebal berwarna merah, berikut dengan jarak
      terdekat tersebut. Semua satuan dinyatakan dalam meter (m). Jika
      tidak ada, textbox akan menuliskan bahwa tidak ada jalur antara
      kedua simpul.

>> Author
   13519063 Melita
   13519171 Fauzan Yubairi Indrayadi