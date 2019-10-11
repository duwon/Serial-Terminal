/* 출처 : 네이트 통 - ryu0423님 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;    // SerialPort 클래스 사용을 위해서 추가
using System.Threading;    // Thread 클래스 사용을 위해서 추가
using System.Management;

namespace SerialTerminal
{
    class Serial
    {

        static void Main(string[] args)
        {
            Serial sp = new Serial(args);    // 해당 객체를 생성하고, start시킵니다.
            sp.Open();
            sp.Start();
        }

        private SerialPort port;    // 시리얼포트 선언
        private Thread reader, writer;    // 시리얼을 통해서 데이터를 읽고, 쓸 스레드 준비
        private string spPort;
        private int spBaudRate = 0;
        public Serial(string[] args)
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

        public void Open()
        {
            try
            {
                port = new SerialPort(spPort, spBaudRate, Parity.None, 8);    // 이건 제 설정에 맞춰서 함
                                                                          /*  아래처럼 개별적으로 설정가능합니다.(UI구성시 입력폼으로 받아서 설정하면 되겠지요)
                                                                          port = new SerialPort();
                                                                          port.PortName = "COM1";
                                                                          port.BaudRate = 115200;
                                                                          port.Parity = Parity.None;
                                                                          port.DataBits = 8;
                                                                          port.StopBits = StopBits.One;
                                                                          */
                port.Open();  // 설정된 포트를 엽니다.
                Console.Title = spPort;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Start()
        {
            reader = new Thread(new ThreadStart(Read));    // Read()를 수행하는 스레드 reader 생성
            reader.IsBackground = true;    // read는 백그라운드에서 수행하고,
            reader.Start();  // reader 스레드를 실행
            writer = new Thread(new ThreadStart(Write));    // Write()를 수행하는 스레드 writer 생성
            writer.Start();    // write는 실제적으로 콘솔창에 입력해야 하므로 foreground로 수행하게 합니다.
        }

        // Writer thread for Serial port
        public void Write()
        {
            for (; ; )
            {
                port.WriteLine(Console.ReadLine());  // 계속 반복하면서 입력된 데이터가 있으면 열려잇는 포트로 데이터 전송
                Thread.Sleep(200);
            }
        }

        // Reader thread for Serial port
        public void Read()
        {
            for (; ; )
            {
                Console.Write(port.ReadExisting());    // 열려있는 포트에서 데이터가 존재하면 읽어봐서 콘솔창에 뿌립니다.
                Thread.Sleep(200);
            }
        }

    }
}