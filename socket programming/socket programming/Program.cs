using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;

namespace socket_programming
{
    /// <summary>
    /// ////////////////////////////////////////////////////Server!!!!!!!
    /// </summary>
    partial class Program
    {
        static conveters convert = new conveters();
        static void Main(string[] args)
        {
            Console.WriteLine("       _____________________");
            Console.WriteLine("      /____/____/____/____/ |");
            Console.WriteLine("     /    /    /    /    /| |");
            Console.WriteLine("    /____/____/____/____/ |/|");
            Console.WriteLine("   /    /    /    /    /| / |");
            Console.WriteLine("  /____/____/____/____/ |/|/|");
            Console.WriteLine(" /    /    /    /    /| / / |");
            Console.WriteLine("+-------------------+ |/|/|/|");
            Console.WriteLine("|    |    |    |    | / / / /");
            Console.WriteLine("|____|____|____|____|/|/|/|/");
            Console.WriteLine("|    |    |    |    | / / /");
            Console.WriteLine("|____|____|____|____|/|/|/");
            Console.WriteLine("|    |    |    |    | / /");
            Console.WriteLine("|____|____|____|____|/|/");
            Console.WriteLine("|    |    |    |    | /");
            Console.WriteLine("|    |    |    |    |/ ");
            Console.WriteLine("+-------------------+");
            Console.WriteLine("This is the server");
            MyServer();
        }
        public static List<TcpClient> clients = new List<TcpClient>();

        public static void MyServer() 
        {

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 13356;
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            AcceptClients(listener);

            bool isRunning = true;
            while (isRunning)
            {
                //send message
                Console.WriteLine("\n");
                string text = Console.ReadLine();
                string returnedText =  convert.textConverter(text);
                byte[] buffer = Encoding.UTF8.GetBytes(returnedText);

                //stream.Write(buffer, 0 , buffer.Length);
                foreach (TcpClient client in clients)
                {
                    if (client != null) client.GetStream().Write(buffer, 0, buffer.Length);
                }

            }
        }

        public static async void AcceptClients(TcpListener listener)
        {
            bool isRunning = true;
            while (isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);
            }        
        }
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            bool isRunning = true;

            string deCryptedText = "";
            while (isRunning)
            {
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
                string cryptedText = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                deCryptedText = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                string returnedDeCrypteted = convert.textDeConverter(deCryptedText);
                Console.WriteLine(string.Format("crypted Text: {0}", cryptedText));
                Console.WriteLine(string.Format("deCrypted Text: {0}", returnedDeCrypteted));
            }
        }
    }
}
