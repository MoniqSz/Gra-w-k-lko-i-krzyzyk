using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static char[,] board = new char[3, 3]; // Tablica 3x3 do planszy gry
    static int ruchRow, ruchCol; // Wiersz i kolumna dla ruchu

    static void Main()
    {
        for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) board[i, j] = ' ';
        TcpListener server = new TcpListener(IPAddress.Any, 12345);
        server.Start();
        Console.WriteLine("Serwer nasłuchuje...");
        TcpClient client = server.AcceptTcpClient();
        NetworkStream stream = client.GetStream();

        while (true)
        {
            WyswietlPlansze();
            WykonajRuch('X');
            if (CzyWygrana('X') || CzyRemis()) break;
            string wiadomosc = $"{ruchRow},{ruchCol}";
            stream.Write(Encoding.ASCII.GetBytes(wiadomosc));

            byte[] buffer = new byte[256];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            string odpowiedz = Encoding.ASCII.GetString(buffer, 0, bytes);
            string[] parts = odpowiedz.Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);
            board[row, col] = 'O';
            if (CzyWygrana('O') || CzyRemis()) break;
        }
        Console.WriteLine("Koniec gry.");
    }

    static void WykonajRuch(char znak)
    {
        Console.WriteLine($"Ruch gracza {znak}: Podaj wiersz i kolumnę (np. 0 1)");
        string[] input = Console.ReadLine().Split();
        ruchRow = int.Parse(input[0]);
        ruchCol = int.Parse(input[1]);
        board[ruchRow, ruchCol] = znak;
    }

    static void WyswietlPlansze()
    {
        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{board[i, 0]}|{board[i, 1]}|{board[i, 2]}");
            if (i < 2) Console.WriteLine("-+-+-");
        }
    }

    static bool CzyWygrana(char z) =>
        (board[0, 0] == z && board[0, 1] == z && board[0, 2] == z) ||
        (board[1, 0] == z && board[1, 1] == z && board[1, 2] == z) ||
        (board[2, 0] == z && board[2, 1] == z && board[2, 2] == z) ||
        (board[0, 0] == z && board[1, 0] == z && board[2, 0] == z) ||
        (board[0, 1] == z && board[1, 1] == z && board[2, 1] == z) ||
        (board[0, 2] == z && board[1, 2] == z && board[2, 2] == z) ||
        (board[0, 0] == z && board[1, 1] == z && board[2, 2] == z) ||
        (board[0, 2] == z && board[1, 1] == z && board[2, 0] == z);

    static bool CzyRemis()
    {
        foreach (char c in board)
            if (c == ' ') return false;
        return true;
    }
}
