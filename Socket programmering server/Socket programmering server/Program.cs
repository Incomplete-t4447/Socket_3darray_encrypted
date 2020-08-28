using System;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;

namespace Socket_programmering_server
{
    partial class Program
    {
        static conveters convert = new conveters();
        /// <summary>
        /// /////////////////////////////////////////////Client
        /// </summary>
        /// <param name="args"></param>
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
            Console.WriteLine("This is the Client");
            Console.WriteLine();
            Client();

        }

        public static void Client()
        {
            TcpClient client = new TcpClient();
            int port = 13356;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            client.Connect(endPoint);

            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);
            bool isRuninng = true; 
            while (isRuninng)
            {
                Console.WriteLine("\n");
                string text = Console.ReadLine();
                string returnedText = convert.textConverter(text);
                byte[] buffer = Encoding.UTF8.GetBytes(returnedText);
                stream.Write(buffer, 0, buffer.Length);
                if (text == "exit")
                {
                    isRuninng = false; 
                }
            }
           

            client.Close();
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
                Console.WriteLine(string.Format("crypted Text: {0}" , cryptedText));
                Console.WriteLine(string.Format("deCrypted Text: {0}", returnedDeCrypteted));
            }

            
        }
    }
}
