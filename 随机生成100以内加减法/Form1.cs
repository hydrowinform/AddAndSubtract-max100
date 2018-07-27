using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace 随机生成100以内加减法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Clear();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();

            if (radioButton1.Checked)
            {
                for (int i = 0; i < 100; i++)
                {
                    int rNum1 = r.Next(1, 19);
                    int rNum2 = r.Next(1, 19);
                    AddAndSubtract add20 = new AddAndSubtract(rNum1, rNum2);
                    sb.Append(add20.Expression202() + "=\t\t");
                }
            }
            else if (radioButton2.Checked)
            {
                for (int i = 0; i < 100; i++)
                {
                    int rNum1 = r.Next(1, 99);
                    int rNum2 = r.Next(1, 99);
                    AddAndSubtract add100 = new AddAndSubtract(rNum1, rNum2);
                    sb.Append(add100.Expression1002() + "=\t\t");
                }
            }
            else if (radioButton3.Checked)
            {
                for (int i = 0; i < 102; i++)
                {
                    while (true)
                    {
                        int rNum1 = r.Next(1, 99);
                        int rNum2 = r.Next(1, 99);
                        int rNum3 = r.Next(1, 99);
                        int caseNum1 = r.Next(0, 2);
                        int caseNum2 = r.Next(0, 2);
                        AddAndSubtract addSub100 = new AddAndSubtract(rNum1, rNum2, rNum3, caseNum1, caseNum2);
                        if (string.IsNullOrEmpty(addSub100.Expression1003()))
                        {
                            continue;
                        }
                        else
                        {
                            sb.Append(addSub100.Expression1003() + "=\t\t\t\t\t");
                            break;
                        }
                    }
                }
            }
            textBox1.Text = sb.ToString();
            this.Tag = sb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取计算结果的数据
            string sb = "";
            if (string.IsNullOrEmpty(this.Tag.ToString()))
            {
                MessageBox.Show("请先生成，再出word稿");
            }
            else
            {
                sb = this.Tag.ToString();
            }
            string[] str = sb.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

            #region //动态生成Word文档并填充数据
            Object oMissing = System.Reflection.Missing.Value;
            MSWord.Application WordApp = new MSWord.Application();
            try
            {
                MSWord.Document WordDoc = WordApp.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                WordApp.Visible = true;
                object count = 14;
                object unite = MSWord.WdUnits.wdStory;
                Object Nothing = Missing.Value;
                object oEndOfDoc = "\\endofdoc";
                //开始编辑文档
                WordApp.Selection.Paragraphs.Last.Range.Font.Size = 14;//号字
                WordApp.Selection.Paragraphs.Last.Range.Font.Name = "微软雅黑";
                WordApp.Selection.ParagraphFormat.LineSpacing = 12f;//设置文档的行间距
                WordApp.Selection.ParagraphFormat.SpaceBefore = float.Parse("10");//段前间距
                WordApp.Selection.ParagraphFormat.SpaceBeforeAuto = 0;
                WordApp.Selection.ParagraphFormat.SpaceAfter = float.Parse("10");//段后间距
                WordApp.Selection.ParagraphFormat.SpaceAfterAuto = 0;

                if (radioButton1.Checked)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        String content1 = str[4 * i].Length > 4 ? str[4 * i] + "\t\t\t" : str[4 * i] + "\t\t\t\t";
                        String content2 = str[4 * i + 1].Length > 4 ? str[4 * i + 1] + "\t\t\t" : str[4 * i + 2] + "\t\t\t\t";
                        String content3 = str[4 * i + 2].Length > 4 ? str[4 * i + 2] + "\t\t\t" : str[4 * i + 2] + "\t\t\t\t";
                        WordApp.Selection.Paragraphs.Last.Range.Text = content1 + content2 + content3 + str[4 * i + 3] + "\n";
                        WordApp.Selection.EndKey(ref unite, ref Nothing);
                    }
                }
                else if (radioButton2.Checked)
                {
                    for (int i = 0; i < 25; i++)
                    {
                        String content1 = str[4 * i].Length > 5 ? str[4 * i] + "\t\t\t" : str[4 * i] + "\t\t\t\t";
                        String content2 = str[4 * i + 1].Length > 5 ? str[4 * i + 1] + "\t\t\t" : str[4 * i + 2] + "\t\t\t\t";
                        String content3 = str[4 * i + 2].Length > 5 ? str[4 * i + 2] + "\t\t\t" : str[4 * i + 2] + "\t\t\t\t";
                        WordApp.Selection.Paragraphs.Last.Range.Text = content1 + content2 + content3 + str[4 * i + 3] + "\n";
                        WordApp.Selection.EndKey(ref unite, ref Nothing);
                    }
                }
                else if (radioButton3.Checked)
                {
                    for (int i = 0; i < 34; i++)
                    {
                        string content1 = str[3 * i].Length > 7 ? str[3 * i] + "\t\t\t\t" : str[3 * i] + "\t\t\t\t\t";
                        string content2 = str[3 * i + 1].Length > 7 ? str[3 * i + 1] + "\t\t\t\t" : str[3 * i + 1] + "\t\t\t\t\t";
                        if (i < 33)
                        {
                            WordApp.Selection.Paragraphs.Last.Range.Text = content1 + content2 + str[3 * i + 2] + "\n";
                            WordApp.Selection.EndKey(ref unite, ref Nothing);
                        }
                        else
                        {
                            WordApp.Selection.Paragraphs.Last.Range.Text = content1 + content2 + str[3 * i + 2];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("未找到word程序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
    }
}
