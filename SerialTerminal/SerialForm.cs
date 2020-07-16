using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
//using OpenAccessRuntime.util;

namespace SerialTerminal
{
    public partial class SerialForm : Form
    {

        bool flagConsoleOpened = false;
        public delegate void OnCloseEventHandler(string _spPort, int _spBaudRate);
        public event OnCloseEventHandler SerialForm_ClosEvent;

        CheckBox[] cbHex = new CheckBox[10];
        TextBox[] tbData = new TextBox[10];
        Button[] btnSend = new Button[10];
        public SerialForm()
        {
            InitializeComponent();
            RefreshCOMPortName();
            CheckForIllegalCrossThreadCalls = false;
            this.Size = new Size(1000, 600);

            string[] strtbText, strcbHex = new String[10];
            strtbText = Properties.Settings.Default.tbText.Split(new char[] { '`' });
            strcbHex = Properties.Settings.Default.cbHex.Split(new char[] { ',' });
            cbPortName.Text = Properties.Settings.Default.serialPortNum;

            for (int i=0; i<10; i++)
            {
                //
                // cbHex
                //
                cbHex[i] = new CheckBox();
                cbHex[i].Text = "";
                cbHex[i].AutoSize = true;
                cbHex[i].Location = new System.Drawing.Point(560, 31 + (i * 28));
                cbHex[i].Name = "cbHex"+i.ToString();
                cbHex[i].Size = new System.Drawing.Size(15, 14);
                cbHex[i].Text = "HEX";
                cbHex[i].TabIndex = 101+3*i;
                cbHex[i].UseVisualStyleBackColor = true;
                if (strcbHex[i] == "true")
                {
                    cbHex[i].Checked = true;
                }
                else
                {
                    cbHex[i].Checked = false;
                }
                cbHex[i].CheckedChanged += new System.EventHandler(this.cbHex_CheckedChanged);
                panel_sendData.Controls.Add(cbHex[i]);

                // 
                // btnSend
                // 
                btnSend[i] = new Button();
                btnSend[i].Location = new System.Drawing.Point(612, 28 + (i * 28));
                btnSend[i].Margin = new System.Windows.Forms.Padding(2);
                btnSend[i].Name = "btnSend" + i.ToString(); ;
                btnSend[i].Size = new System.Drawing.Size(49, 23);
                btnSend[i].TabIndex = 103+3*i;
                btnSend[i].Text = "전송";
                btnSend[i].UseVisualStyleBackColor = true;
                btnSend[i].Click += new System.EventHandler(this.btnSend_Click);
                panel_sendData.Controls.Add(btnSend[i]);
                // 
                // tbData
                // 
                tbData[i] = new TextBox();
                tbData[i].Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tbData[i].Location = new System.Drawing.Point(11, 28 + (i * 28));
                tbData[i].Name = "tbData" + i.ToString(); ;
                tbData[i].Size = new System.Drawing.Size(543, 22);
                tbData[i].TabIndex = 102+3*i;
                try
                {
                    tbData[i].Text = strtbText[i];
                }
                catch { }
                panel_sendData.Controls.Add(tbData[i]);
            }

            
        }

        public SerialForm(string spName, int spBoudrate)
        {
            InitializeComponent();
            RefreshCOMPortName();

            cbPortName.Text = spName;
            tbBoudrate.Text = spBoudrate.ToString();
            flagConsoleOpened = true;
        }

        private void RefreshCOMPortName()
        {
            try
            {
                cbPortName.Items.AddRange(SerialPort.GetPortNames());
            }
            catch { }

            if (cbPortName.Items.Count > 0)
            {
                cbPortName.SelectedIndex = 0;  // 컴포트의 0번째를 표시
            }
        }

        private void OpenSerialPort()
        {
            try
            {
                // sp1 값이 null 일때만 새로운 SerialPort 를 생성
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = cbPortName.Text;
                    serialPort.BaudRate = Convert.ToInt32(tbBoudrate.Text);

                    serialPort.RtsEnable = true;
                    serialPort.Open();
                }
            }
            catch { }
            ChangebtnCOMOpen();
        }
        private void CloseSerialPort()
        {
            if (null != serialPort)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            ChangebtnCOMOpen();
        }
        private void ChangebtnCOMOpen()
        {
            if (serialPort.IsOpen)
            {
                btnCOMOpen.BackgroundImage = Properties.Resources.btnROpen;
                btnCOMOpen.ForeColor = Color.Black;
                btnCOMOpen.Text = "CLOSE";
                Properties.Settings.Default.serialPortNum = cbPortName.Text;
            }
            else
            {
                btnCOMOpen.BackgroundImage = Properties.Resources.btnRClose;
                btnCOMOpen.ForeColor = Color.Black;
                btnCOMOpen.Text = "OPEN";
            }
        }

        private void button_send1_Click(object sender, EventArgs e)
        {
            byte[] tmpPacket = { 0x30, 0x31, 0x32 };
        }

        private void SerialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagConsoleOpened)
            {
                SerialForm_ClosEvent(cbPortName.Text, Convert.ToInt32(tbBoudrate.Text));
            }
            Properties.Settings.Default.Save();
        }

        private void btnCOMOpen_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                CloseSerialPort();
            }
            else
            {
                OpenSerialPort();
            }
        }

        private void cbHex_CheckedChanged(object sender, EventArgs e)
        {
            string scbHex = "";
            for (int i = 0; i < cbHex.Length; i++)
            {
                if (cbHex[i].Checked == true)
                {
                    scbHex = scbHex + "true,";
                }
                else
                {
                    scbHex = scbHex + ",";
                }
            }
            Properties.Settings.Default.cbHex = scbHex;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string saveSettingtbText = "";
            
            for (int i = 0; i < btnSend.Length; i++)
            {
                if (sender.Equals(btnSend[i]))
                {
                    if (cbHex[i].Checked == true)
                    {
                        tbData[i].Text = tbData[i].Text.ToUpper();         // HEX 체크박스 체크되어 있으면 대문자로 변환
                        tbData[i].Text = tbData[i].Text.Replace("0X", ""); //16진수 표시 0x 제거

                        string[] hexValuesSplit = tbData[i].Text.Split(' ');
                        byte[] txBuffer = new byte[500];
                        int dataLength = 0;
                        foreach (string hex in hexValuesSplit)
                        {
                            try
                            {
                                txBuffer[dataLength++] = (byte)Convert.ToInt32(hex, 16);
                            }
                            catch
                            {
                                dataLength--;
                            }
                        }
                        Array.Resize(ref txBuffer, dataLength);

                        tbData[i].Text = BitConverter.ToString(txBuffer).Replace("-", " ");

                        SendData(txBuffer);
                    }
                    else
                    {
                        byte[] txBuffer = new byte[500];
                        int dataLength = 0;
                        foreach (char ch in tbData[i].Text.ToCharArray())
                        {
                            txBuffer[dataLength++] = (byte)Convert.ToInt32(ch);
                        }
                        Array.Resize(ref txBuffer, dataLength);
                        SendData(txBuffer);
                    }

                }
                saveSettingtbText = saveSettingtbText + tbData[i].Text + "`";
            }
            Properties.Settings.Default.tbText = saveSettingtbText;
        }

        private void SendData(byte[] txData)
        {
            try
            {
                serialPort.Write(txData, 0, txData.Length);
                debugHex.AppendText("\r\n" + BitConverter.ToString(txData).Replace("-", " ")+" ");
            }
            catch (System.Exception ex)
            {
                debugText.AppendText(ex.Message + "\r\n");
            }
        }
        private void HexCheck_tbKeyPress(object sender, KeyPressEventArgs e)
        {
            //HEX만 입력 되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == Convert.ToChar(Keys.Space)) || (e.KeyChar == Convert.ToChar(Keys.Back)) || "ABCDEF0123456789abcdefxX".IndexOf(e.KeyChar) != -1))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int iRecivedSize = serialPort.BytesToRead;

                if (iRecivedSize != 0) // 수신 데이터가 있으면
                {
                    byte[] buff = new byte[iRecivedSize];
                    try
                    {
                        serialPort.Read(buff, 0, iRecivedSize);
                        debugHex.AppendText(DateTime.Now.ToString("\r\n[HH:mm:ss] [RX] ") + BitConverter.ToString(buff).Replace("-", " "));
                        debugText.AppendText(Encoding.ASCII.GetString(buff));
                    }
                    catch (System.Exception ex)
                    {
                        this.debugText.AppendText(ex.Message);
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.debugText.AppendText(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.btnLEDGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Properties.Resources.btnLEDRed;
        }

        private void sbOpacity_Scroll(object sender, ScrollEventArgs e)
        {
            double tmpOpacity = (double)(sbOpacity.Value)/200+0.51;
            if(tmpOpacity > 0.96)
            {
                this.Opacity = 1;
            }
            else
            {
                this.Opacity = tmpOpacity;
            }
            //debugText.AppendText(sbOpacity.Value.ToString());
        }

        /// <summary>
        /// 그림파일오픈창을 로드후 해당 파일의 FullPath를 가져온다.
        /// 출처 : https://mirwebma.tistory.com/121
        /// </summary>
        /// <returns>파일의 FullPath 파일이 없거나 선택을 안할경우 ""를 리턴</returns>
        public string ShowFileOpenDialog()
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AutoUpgradeEnabled = false;
            ofd.Title = "전송 할 파일 선택";
            //ofd.FileName = "test";
            ofd.Filter = "그림 파일 (*.png, *.jpg, *.bmp) | *.png; *.jpg; *.bmp; |소리 파일 (*.wav) | *.wav |모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                string filePath = fileFullName.Replace(fileName, "");
            
                //출력 예제용 로직
                //debugText.Text += "File Name  : " + fileName;
                //debugText.Text += "Full Name  : " + fileFullName;
                //debugText.Text += "File Path  : " + filePath;
                //File경로 + 파일명 리턴
                return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }

        private void btnFileSendSend_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(ShowFileOpenDialog(), FileMode.Open, FileAccess.Read);

                if (serialPort.IsOpen)
                {
                    debugText.AppendText("전송 중 ");
                    for (Int32 i = 0; i < 261120; i++)
                    {
                        Byte[] readByte = new Byte[1];
                        readByte[0] = (Byte)fs.ReadByte();
                        serialPort.Write(readByte, 0, 1);
                        if (i % 10000 == 0)
                        {
                            debugText.AppendText(".");
                        }
                    }
                    debugText.AppendText(" 끝\r\n");
                }
                else
                {
                    debugText.AppendText("통신포트를 먼저 연결하세요.\r\n");
                }
            }
            catch { }
        }
    }
}
