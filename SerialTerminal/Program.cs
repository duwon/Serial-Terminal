/* 참고 : http://hoons.net/Board/cshaptip/Content/5035 */
/* 참고 : http://greenday96.blogspot.com/2016/06/c-simple-c-source-code-for-serial.html */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;     // SerialPort 클래스 사용을 위해서 추가
using System.Threading;    // Thread 클래스 사용을 위해서 추가
using System.Management;

namespace SerialTerminal
{
    class Serial
    {

        static void Main(string[] args)
        {
            Serial sp = new Serial(args);    // 해당 객체를 생성하고, start
            sp.Open();
            sp.Start();
        }

        private SerialPort port;    // 시리얼포트 선언
        private Thread reader, writer;    // 시리얼을 통해서 데이터를 읽고, 쓸 스레드 준비
        private string spPort;
        private int spBaudRate = 0;

        public Serial(string[] args)
        {
            Set(args);
        }

        public void Set(string[] args)
        {
            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (((args[i] == "-p") || (args[i] == "-P")) && ((args.Length - 1) > i))
                    {
                        spPort = "COM" + args[i + 1];
                    }

                    if (((args[i] == "-b") || (args[i] == "-B")) && ((args.Length - 1) > i))
                    {
                        spBaudRate = int.Parse(args[i + 1]);
                    }
                }
            }

            if (spPort == null)
            {
                // Get a list of serial port names.
                string[] ports = SerialPort.GetPortNames();
                Console.WriteLine("COM Port List :");
                // Display each port name to the console.
                foreach (string port in ports)
                {
                    Console.WriteLine(port);
                }

                Console.Write("\r\nCOM Port : ");
                spPort = "COM" + Console.ReadLine();
            }

            if (spBaudRate == 0)
            {
                Console.Write("BaudRate (Default 115200) : ");
                string consoleInput = Console.ReadLine();

                if (consoleInput == "")
                {
                    spBaudRate = 115200;
                }
                else
                {
                    spBaudRate = int.Parse(consoleInput);
                }
            }
        }

        public void Reset()
        {
            Close();
            spPort = null;
            spBaudRate = 0;
        }
    

        public void Open()
        {
            try
            {
                port = new SerialPort(spPort, spBaudRate, Parity.None, 8);
                        /* 
                        port = new SerialPort();
                        port.PortName = "COM1";
                        port.BaudRate = 115200;
                        port.Parity = Parity.None;
                        port.DataBits = 8;
                        port.StopBits = StopBits.One;
                        */

                port.DataReceived += DataReceived; //수신 인터럽트 추가
                port.Open();
                Console.Title = spPort;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Connected.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }

        public void Close()
        {
            if (port.IsOpen)
            {
                port.Close();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\r\nDisconnected.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                int iRecivedSize = port.BytesToRead;

                if (iRecivedSize != 0) // 수신 데이터가 있으면
                { 
                    byte[] buff = new byte[iRecivedSize];
                    try
                    {
                        port.Read(buff, 0, iRecivedSize);

                        if (flag_printHex == true)
                        {
                            Console.Write(BitConverter.ToString(buff).Replace("-", " ") + " ");
                        }
                        else
                        {
                            Console.Write(Encoding.ASCII.GetString(buff));
                        }
                    }
                    catch { }
                }
            }
            catch (System.Exception)
            {
            }


        }

        public void Start()
        {
            reader = new Thread(new ThreadStart(Read));    // Read()를 수행하는 스레드 reader 생성
            reader.IsBackground = true;     // read는 백그라운드에서 수행
            reader.Start();                 // reader 스레드를 실행
            writer = new Thread(new ThreadStart(Write));    // Write()를 수행하는 스레드 writer 생성
            writer.Start();                 // write는 실제적으로 콘솔창에 입력해야 하므로 foreground로 수행

        }

        // Writer thread for Serial port
        bool flag_printHex = false;
        bool flag_portClose = false;
        public void Write()
        {
            for (; ; )
            {
                ConsoleKeyInfo cki = Console.ReadKey();

                if ((cki.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    switch (cki.Key.ToString())
                    {
                        case "H": //print Hex or Text
                            flag_printHex = !flag_printHex;
                            break;
                        case "T": //print Text
                            flag_printHex = false;
                            break;
                        case "D": //port open/close
                            flag_portClose = !flag_portClose;
                            if(flag_portClose == true)
                            {
                                Close();
                            }
                            else
                            {
                                Open();
                            }
                            break;
                        case "X": //port open/close
                            Reset();
                            Set(null);
                            Open();
                            
                            break;

                    }
                }
                else
                {
                    port.Write(cki.Key.ToString());  // 계속 반복하면서 입력된 데이터가 있으면 열려잇는 포트로 데이터 전송
                }
                Thread.Sleep(10);

                

            }
        }

        // Reader thread for Serial port
        public void Read()
        {
            for (; ; )
            {
                //Console.Write(port.ReadExisting());    // 열려있는 포트에서 데이터가 존재하면 콘솔창에 출력
                Thread.Sleep(200);
            }
        }




    }
}