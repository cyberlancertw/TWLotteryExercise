using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWLotteryExercise
{
    public partial class Form1 : Form
    {
        GroupBox gbxBingo, gbxBingoSpecial, gbxUser, gbxUserSpecial;
        Label[] lblNumber = new Label[38];
        Label[] lblBingoNum = new Label[7];
        Label[] lblNumSpecial = new Label[8];
        bool[] islblNumSelect = new bool[38];
        bool[] isSpeSelect = new bool[8];

        Label[] lblNumChoose = new Label[7];
        int chooseCount, specialCount;
        int[] listChoose = new int[7];
        int[] listBingo = new int[7];

        public Form1()
        {
            InitializeComponent();

            chooseCount = 0;

            for(int i=0; i<38; i++)
            {
                islblNumSelect[i] = false;
            }

            for(int i=0; i<6; i++)
            {
                listChoose[i] = -1;
            }

            gbxBingo = new GroupBox();
            gbxBingo.SetBounds(20, 20, 600, 75);
            gbxBingo.Text = "獎號";
            this.Controls.Add(gbxBingo);

            gbxBingoSpecial = new GroupBox();
            gbxBingoSpecial.SetBounds(640, 20, 80, 75);
            gbxBingoSpecial.Text = "特別號";
            this.Controls.Add(gbxBingoSpecial);

            gbxUser = new GroupBox();
            gbxUser.SetBounds(20, 110, 600, 75);
            gbxUser.Text = "投注號碼";
            this.Controls.Add(gbxUser);

            gbxUserSpecial = new GroupBox();
            gbxUserSpecial.SetBounds(640, 110, 80, 75);
            gbxUserSpecial.Text = "特別號";
            this.Controls.Add(gbxUserSpecial);

            for (int i = 0; i < 38; i++)            // 讓使用者圈選用的1~38號碼
            {
                lblNumber[i] = new Label();
                lblNumber[i].Text = $"{i + 1}";
                lblNumber[i].Font = new Font("Arial", 14);
                lblNumber[i].AutoSize = false;
                lblNumber[i].Width = 40;
                lblNumber[i].Height = 30;
                lblNumber[i].TextAlign = ContentAlignment.MiddleCenter;
                lblNumber[i].BorderStyle = BorderStyle.FixedSingle;
                lblNumber[i].BackColor = Color.White;
                lblNumber[i].ForeColor = Color.Black;
                lblNumber[i].Location = new Point(80 + (i % 10) * 60, 210 + (i / 10) * 40);

                int index = i;      // 功力不足不知道為何下面用 i 會報界限例外，竟然會抓最後一個i=37再++變38爆掉
                lblNumber[i].MouseClick += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
                {
                    if(e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (islblNumSelect[index])
                        {
                            (sender as Label).BackColor = Color.White;      // 高級用法，聽說委派裡面不要用區域變數
                            (sender as Label).ForeColor = Color.Black;      // 要用 sender as Class
                            islblNumSelect[index] = false;                  // 可是我還是需要i.. 然後神奇的
                            chooseCount--;                                  // 前面多 int index=i 就可以了, magic
                            RefreshAll();
                        }
                        else
                        {
                            if(chooseCount < 6)
                            {
                                (sender as Label).BackColor = Color.Black;
                                (sender as Label).ForeColor = Color.White;
                                islblNumSelect[index] = true;
                                chooseCount++;
                            }
                            RefreshAll();
                        }
                    }
                });
                this.Controls.Add(lblNumber[i]);
            }



            for (int i = 0; i < 8; i++)            // 讓使用者圈選的1~8特別號
            {
                lblNumSpecial[i] = new Label();
                lblNumSpecial[i].Text = $"{i + 1}";
                lblNumSpecial[i].Font = new Font("Arial", 14);
                lblNumSpecial[i].AutoSize = false;
                lblNumSpecial[i].Width = 40;
                lblNumSpecial[i].Height = 30;
                lblNumSpecial[i].TextAlign = ContentAlignment.MiddleCenter;
                lblNumSpecial[i].BorderStyle = BorderStyle.FixedSingle;
                lblNumSpecial[i].BackColor = Color.White;
                lblNumSpecial[i].ForeColor = Color.Black;
                lblNumSpecial[i].Location = new Point(80 + (i % 10) * 60, 400);

                int index = i;
                lblNumSpecial[i].MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (isSpeSelect[index])                                 // out of range exception 
                        {
                            (sender as Label).BackColor = Color.White;
                            (sender as Label).ForeColor = Color.Black;
                            lblNumChoose[6].Text = "";
                            isSpeSelect[index] = false;                         // out of range exception 
                            specialCount--;
                            RefreshAll();
                        }
                        else
                        {
                            if (specialCount < 1)
                            {
                                (sender as Label).BackColor = Color.Black;
                                (sender as Label).ForeColor = Color.White;
                                isSpeSelect[index] = true;                      // out of range exception 
                                lblNumChoose[6].Text = $"{index + 1}";          // out of range exception 
                                specialCount++;
                            }
                            RefreshAll();
                        }
                    }
                });
                this.Controls.Add(lblNumSpecial[i]);
            }

            for (int i=0; i<7; i++)                  // 選號結果的label的新增
            {
                lblNumChoose[i] = new Label();
                lblNumChoose[i].Width = 50;
                lblNumChoose[i].Height = 25;
                lblNumChoose[i].AutoSize = false;
                lblNumChoose[i].Font = new Font("Arial", 14);
                lblNumChoose[i].TextAlign = ContentAlignment.MiddleCenter;
                if (i < 6)                                                      // 前六個
                {
                    lblNumChoose[i].Location = new Point(20 + i * 100, 30);
                    gbxUser.Controls.Add(lblNumChoose[i]);
                }
                else
                {
                    lblNumChoose[i].Location = new Point(15, 30);                // 最後一個是特別號
                    gbxUserSpecial.Controls.Add(lblNumChoose[i]);
                }

                //int index = i;            // TextBox TextChanged會連動，放棄
                //lblNumChoose[i].TextChanged += new System.EventHandler(delegate (object sender, EventArgs e)
                //{
                //    if((sender as TextBox).Text.Equals("")){
                //        chooseCount--;
                //        RefreshNumLabel();
                //        return;
                //    }
                //    int inputIndex = 0;
                //    bool isSuccess = int.TryParse(lblNumChoose[index].Text, out inputIndex);
                //    if (isSuccess && inputIndex > 0 && inputIndex < 50)
                //    {
                //        inputIndex--;
                //        islblNumSelect[inputIndex] = true;
                //        RefreshNumLabel();
                //    }
                //});

            }

            for(int i=0; i<7; i++)                      // 產生彩號的 Label
            {
                lblBingoNum[i] = new Label();
                lblBingoNum[i].Text = "";
                lblBingoNum[i].Font = new Font("Arial", 14);
                lblBingoNum[i].Width = 50;
                lblBingoNum[i].Height = 25;
                
                if (i < 6)                              // 前六個
                {
                    lblBingoNum[i].Location = new Point(30 + i * 100, 30);
                    gbxBingo.Controls.Add(lblBingoNum[i]);
                }
                else                                    // 最後一個，特別號
                {
                    lblBingoNum[i].Location = new Point(29, 30);
                    gbxBingoSpecial.Controls.Add(lblBingoNum[i]);
                }
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RefreshAll()
        {
            int posLabelChoose = 0;
            for (int i = 0; i < 38; i++)             
            {
                if (islblNumSelect[i])                       // 選到的數填入lblNumChoose，下方label也顯示
                {
                    lblNumChoose[posLabelChoose].Text = $"{i + 1}";

                    posLabelChoose++;
                    lblNumber[i].BackColor = Color.Black;
                    lblNumber[i].ForeColor = Color.White;
                }
                else
                {
                    lblNumber[i].BackColor = Color.White;
                    lblNumber[i].ForeColor = Color.Black;
                }
            }
            
            for (int i = posLabelChoose; i < 6; i++)         // 剩下填空
            {
                lblNumChoose[i].Text = "";
            }
        }
        private void RefreshTextBox()
        {
            int textBoxPos = 0;
            for(int i=0; i<38; i++)                 // 圈選的填入TextBox
            {
                if (islblNumSelect[i])
                {
                    lblNumChoose[textBoxPos].Text = $"{i + 1}";
                    textBoxPos++;
                }
            }
            for(int i=textBoxPos; i<6; i++)         // 剩下空白
            {
                lblNumChoose[i].Text = "";
            }
        }

        private void RefreshNumLabel()
        {
            for(int i=0; i<38; i++)                 // 重整
            {
                islblNumSelect[i] = false;
                lblNumber[i].BackColor = Color.White;
                lblNumber[i].ForeColor = Color.Black;
            }

            for(int i=0; i<6; i++)
            {
                if(lblNumChoose[i].Text.Length > 0)
                {
                    int numTempIndex;
                    bool isSuccess = int.TryParse(lblNumChoose[i].Text, out numTempIndex);
                    numTempIndex--;
                    if (!isSuccess)
                    {
                        continue;     //使用者輸入非數字
                    }
                    if(numTempIndex > -1 && numTempIndex < 38)
                    {
                        islblNumSelect[numTempIndex] = true;
                        lblNumber[numTempIndex].BackColor = Color.Black;
                        lblNumber[numTempIndex].ForeColor = Color.White;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            chooseCount = 0;
            specialCount = 0;

            for(int i=0; i<38; i++)                             // 選的重置
            {
                lblNumber[i].BackColor = Color.White;
                lblNumber[i].ForeColor = Color.Black;
                islblNumSelect[i] = false;
            }
            for(int i=0; i<8; i++)                              // 第二區重置
            {
                lblNumSpecial[i].BackColor = Color.White;
                lblNumSpecial[i].ForeColor = Color.Black;
                isSpeSelect[i] = false;
            }
            for (int i = 0; i < 7; i++)                         // 結果重置
            {
                lblNumChoose[i].Text = "";
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            for(int i=0; i<7; i++)
            {
                if (lblNumChoose[i].Text.Equals(""))
                {
                    MessageBox.Show("請選6個號碼和1個特別號！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                listChoose[i] = Convert.ToInt32(lblNumChoose[i].Text);
            }

            lblResult.Text = CheckWinning();

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> remain = new List<int>();

            for(int i=0; i<38; i++)
            {
                remain.Add(i + 1);
            }
            for(int i=0; i<6; i++)                              // 產生6個不重覆的號碼
            {
                int rndIndex = rnd.Next(remain.Count);
                listBingo[i] = remain[rndIndex];                // 賦予給listBingo
                remain.RemoveAt(rndIndex);
            }
            listBingo[6] = rnd.Next(8) + 1;
            Array.Sort(listBingo, 0, 6);                        // 只排列前6個，最後index=6的是特別號
            for(int i=0; i<7; i++)
            {
                lblBingoNum[i].Text = $"{listBingo[i]}";
            }
            btnBuy.Enabled = true;                              // 有秀獎號才能兌獎
        }

        private string CheckWinning()
        {
            int matchCount = 0;
            for(int i=0; i<6; i++)                              // 前六個號碼有幾個相同
            {
                int numTemp = listBingo[i];
                if (listChoose.Contains(numTemp))
                {
                    matchCount++;
                }
            }
            bool matchSpecial = listChoose[6] == listBingo[6];  // 特別號是否相同

            if (matchSpecial)
            {
                switch (matchCount)
                {
                    case 6: return "恭\n喜\n中\n頭\n獎\n！";
                    case 5: return "恭\n喜\n中\n參\n獎\n！";
                    case 4: return "恭\n喜\n中\n伍\n獎\n！";
                    case 3: return "恭\n喜\n中\n柒\n獎\n！";
                    case 2: return "恭\n喜\n中\n捌\n獎\n！";
                    case 1: return "恭\n喜\n中\n普\n獎\n！";
                    default: break;
                }
            }
            else
            {
                switch (matchCount)
                {
                    case 6: return "恭\n喜\n中\n貳\n獎\n！";
                    case 5: return "恭\n喜\n中\n肆\n獎\n！";
                    case 4: return "恭\n喜\n中\n陸\n獎\n！";
                    case 3: return "恭\n喜\n中\n玖\n獎\n！";
                    default: break;
                }
            }
            return "抱\n歉\n沒\n中\n獎\n！";
        }
    }
}
