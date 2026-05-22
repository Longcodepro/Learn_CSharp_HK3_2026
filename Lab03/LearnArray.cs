using System;
namespace Lab03;
class LearnArray
{
    public static void Main(string[] args)
    {
        // khởi tạo một mảng
        int[] soNguyen = {1, 3, 2, 5, 4, 1};

        // duyệt các phần tử trong mảng
        Console.WriteLine($"Mảng ban đầu: {string.Join(",", soNguyen)}");

        // dùng LastIndexOF
        Console.WriteLine($"Vị trí cuối cùng của số  1 trong mảng là: {Array.LastIndexOf(soNguyen, 1)}");

        // dùng FindAll
        int[] ketQua = Array.FindAll(soNguyen, x => x ==1);
        Console.WriteLine($"{string.Join("-", soNguyen)}");

        // dùng sort
        Array.Sort(soNguyen);
        Console.WriteLine($"Mảng sau khi sort: {string.Join(",", soNguyen)}");

        // lọc số chẵn bằng LAMBDA
        // cách 1
        Func<int[], int[]> soChan1 = mangSoNguyen => mangSoNguyen.Where(x => x%2==0).ToArray();

        int[] result1 = soChan1(soNguyen);

        Console.WriteLine($"{string.Join(",", result1)}");

        // cách 2
        Func<int, bool> soChan2 = x => x%2==0;
        int[] result2 = Array.FindAll(soNguyen, x => soChan2(x));
        Console.WriteLine($"{string.Join(",", result2)}");
    }
}