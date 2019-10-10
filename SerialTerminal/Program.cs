using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;    // SerialPort 클래스 사용을 위해서 추가
using System.Threading;    // Thread 클래스 사용을 위해서 추가

namespace RS232
{
    class Serial
    {
        static void Main(string[] args)
        {
            Serial ps = new Serial(args);    // 해당 객체를 생성하고, start시킵니다.
            ps.Open();
            ps.Start();
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
                Console.Write("COM Port : ");
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
                port = new SerialPort(spPort, spBaudRate, Parity.None, 8);
                /*
                port = new SerialPort();
                port.PortName = spPort;
                port.BaudRate = spBaudRate;
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                */

                port.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        public void Start()
        {
            reader = new Thread(new ThreadStart(Read)); 
            reader.IsBackground = true;    // read는 백그라운드에서 수행하고,
            writer = new Thread(new ThreadStart(Write));    // Write()를 수행하는 스레드 writer 생성
            writer.Start();    // write는 실제적으로 콘솔창에 입력해야 하므로 foreground로 수행하게 합니다.
        }

        // Writer thread for Serial port
        public void Write()
        {
            for (; ; )
            {
                port.WriteLine(Console.ReadLine());  // 계속 반복하면서 입력된 데이터가 있으면 열려잇는 포트로 데이터 전송
                Thread.Sleep(200);    // 200ms마다 스레드를 잠재워서 다른 스레드가 수행가능하게 합니다.(요건 스레드 프로그래밍을 해보셨으면 아시리라 생각...=_=
            }
        }

        // Reader thread for Serial port
        public void Read()
        {
            for (; ; )
            {
                Console.Write(port.ReadExisting());    // 열려있는 포트에서 데이터가 존재하면 읽어봐서 콘솔창에 뿌립니다.
                Thread.Sleep(200);    // 위와 마찬가지 이유로 sleep시킴
            }
        }


    }
}


