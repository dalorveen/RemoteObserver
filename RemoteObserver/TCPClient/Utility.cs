using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    public class Utility
    {
        private static Socket _clientSocket;

        public static void Connect(IPAddress ip, int port)
        {
            try
            {
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _clientSocket.Connect(ip, port);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Disconnect()
        {
            try
            {
                _clientSocket.Disconnect(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static object Dialogue(string request)
        {
            ResetReceiveBuffer();
            Send(request);
            return Receive();
        }

        private static void ResetReceiveBuffer()
        {
            byte[] buffer = new byte[512];
            while (_clientSocket.Available > 0)
            {
                _clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
            }
        }

        private static void Send(string request)
        {
            try
            {
                byte[] data = Encoding.BigEndianUnicode.GetBytes(request);
                _clientSocket.Send(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string Status(int size_of_object_data)
        {
            string data = string.Empty;
            try
            {
                while (size_of_object_data > 0)
                {
                    byte[] buffer = new byte[512];
                    int length = _clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    size_of_object_data -= length;
                    data += Encoding.BigEndianUnicode.GetString(buffer, 0, length);
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string[] Titles(int size_of_object_data)
        {
            string data = string.Empty;
            try
            {
                while (size_of_object_data > 0)
                {
                    byte[] buffer = new byte[512];
                    int length = _clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    size_of_object_data -= length;
                    data += Encoding.BigEndianUnicode.GetString(buffer, 0, length);
                }
                string[] separator = new string[] { "<gap>" };
                return data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static Image Snapshot(int size_of_object_data)
        {
            byte[] data = new byte[size_of_object_data];
            try
            {
                int index = 0;
                while (size_of_object_data > 0)
                {
                    byte[] buffer = new byte[512];
                    int length = _clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    size_of_object_data -= length;
                    Array.Copy(buffer, 0, data, index, length);
                    index += length;
                }
                MemoryStream memoryStream = new MemoryStream(data, 0, data.Length);
                return Image.FromStream(memoryStream);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static object Receive()
        {
            try
            {
                // PROTOCOL:
                // HEADER|OBJECT_ID|SIZE_OF_OBJECT_DATA|OBJECT_DATA = 6(bytes)|1(bytes)|4(bytes)|X(bytes)
                byte[] buffer = new byte[11];
                _clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                if (Encoding.ASCII.GetString(buffer, 0, 6).IndexOf("HEADER") == 0)
                {
                    if (buffer[6] == 48)
                    {
                        return Status(BitConverter.ToInt32(buffer, 7));
                    }
                    else if (buffer[6] == 49)
                    {
                        return Titles(BitConverter.ToInt32(buffer, 7));
                    }
                    else if (buffer[6] == 50)
                    {
                        return Snapshot(BitConverter.ToInt32(buffer, 7));
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
