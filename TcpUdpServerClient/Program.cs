using System;
using System.ComponentModel.Design;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static TcpListener tcpListener = new TcpListener(IPAddress.Parse("20.119.8.43"), 3389);
    static UdpClient udpListener = new UdpClient(7024);

    static bool tcpServer = true;
    static bool udpServer = true;

    static string tcpServerStopStart = "OFF";
    static string udpServerStopStart = "OFF";

    static void Main()
    {


        while (true)
        {
            Console.WriteLine($"TCP server {tcpServerStopStart}");
            Console.WriteLine($"UDP server {udpServerStopStart}");
            Console.WriteLine($"Enter 1 to start or stop the TCP server");
            Console.WriteLine("Enter 2 to start or stopthe UDP server");
            Console.WriteLine("Enter 3 to send message to the TCP server");
            Console.WriteLine("Enter 4 to send message to the UDP server");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (!tcpServer)
                    {
                        Task.Run(() => { StartTcpServer(); });
                        tcpServer = true;
                        tcpServerStopStart = "ON";
                    }
                    else if (tcpServer)
                    {
                        Task.Run(() => { StopTcpServer(); });
                        tcpServer = false;
                        tcpServerStopStart = "OFF";
                    }
                    Console.Clear();
                    break;

                case "2":
                    if (!udpServer)
                    {
                        Task.Run(() => { StartUdpServer(); });
                        udpServer = true;
                        udpServerStopStart = "ON";
                    }
                    else if (udpServer)
                    {
                        Task.Run(() => { StopUdpServer(); });
                        udpServer = false;
                        udpServerStopStart = "OFF";
                    }
                    Console.Clear();
                    break;

                case "3":
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect("20.119.8.43", 3389);
                    NetworkStream stream = tcpClient.GetStream();
                    string startServerMessage = "From TCP Client";
                    byte[] data = Encoding.ASCII.GetBytes(startServerMessage);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("TCP Message sent: " + startServerMessage);
                    stream.Close();
                    tcpClient.Close();
                    ClearConsoleWithPause(3000);
                    break;

                case "4":
                    UdpClient udpClient = new UdpClient();
                    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("20.119.8.43"), 7024);
                    string message = "from UDP CLient ";
                    byte[] data1 = Encoding.ASCII.GetBytes(message);
                    udpClient.Send(data1, data1.Length, serverEndPoint);
                    Console.WriteLine("UDP Message sent: " + message);
                    udpClient.Close();
                    ClearConsoleWithPause(3000);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }


        }
    }

    static void StartTcpServer()
    {
        try
        {
            tcpListener.Start();
            Console.WriteLine("TCP Server started. Waiting for connections...");
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Console.WriteLine("TCP Client connected.");
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("TCP Message received: " + message);
                stream.Close();
                client.Close();
            }
        }
        catch (Exception)
        {
            Console.Clear();
            Main();
        }
    }

    static void StopTcpServer()
    {
        tcpListener.Stop();

    }

    static void StartUdpServer()
    {
        try
        {
            Console.WriteLine("UDP Server started. Waiting for connections...");
            while (true)
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse("20.119.8.43"), 7024);
                byte[] buffer = udpListener.Receive(ref clientEndPoint);
                string messageEncode = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("UDP Message received: " + messageEncode);
            }
        }
        catch (Exception)
        {
            Console.Clear();
            Main();
        }

    }
    static void StopUdpServer()
    {
        udpListener.Close();
    }
    static void ClearConsoleWithPause(int milliseconds)
    {

        Thread.Sleep(milliseconds); // Pause for the specified duration
        Console.Clear();
    }
}
