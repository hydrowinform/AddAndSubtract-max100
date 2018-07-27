using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 随机生成100以内加减法
{

    public class AddAndSubtract
    {
        public int Num1
        {
            get;
            set;
        }

        public int Num2
        {
            get;
            set;
        }

        public int Num3
        {
            get;
            set;
        }


        public int CaseNum1
        {
            get;
            set;
        }

        public int CaseNum2
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化20以内两数字加减法的初始值
        /// </summary>
        /// <param name="num1">num1</param>
        /// <param name="num2">num2</param>
        public AddAndSubtract(int num1, int num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }
        /// <summary>
        /// 初始化100以内三数字加减法的初始值和加减符号
        /// </summary>
        /// <param name="num1">num1</param>
        /// <param name="num2">num2</param>
        /// <param name="num3">num3</param>
        /// <param name="caseNum1">加法为0，减法为1</param>
        /// <param name="caseNum2">加法为0，减法为1</param>
        public AddAndSubtract(int num1, int num2, int num3, int caseNum1, int caseNum2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
            this.Num3 = num3;
            this.CaseNum1 = caseNum1;
            this.CaseNum2 = CaseNum2;
        }
        /// <summary>
        /// 20以内2个数的加减法运算
        /// </summary>
        /// <returns>算式</returns>
        public string Expression202()
        {
            if (this.Num1 + this.Num2 <= 20)
            {
                return Num1.ToString() + "+" + Num2.ToString();
            }
            else if (this.Num1 - this.Num2 >= 0)
            {
                return Num1.ToString() + "-" + Num2.ToString();
            }
            else
            {
                return Num2.ToString() + "-" + Num1.ToString();
            }
        }
        /// <summary>
        /// 100以内2个数的加减法运算
        /// </summary>
        /// <returns>算式</returns>
        public string Expression1002()
        {
            if (this.Num1 + this.Num2 <= 100)
            {
                return Num1.ToString() + "+" + Num2.ToString();
            }
            else if (this.Num1 - this.Num2 >= 0)
            {
                return Num1.ToString() + "-" + Num2.ToString();
            }
            else
            {
                return Num2.ToString() + "-" + Num1.ToString();
            }
        }
        /// <summary>
        /// 100以内3个数的加减法运算
        /// </summary>
        /// <returns>算式</returns>
        public string Expression1003()
        {
            if (CaseNum1 == 0)
            {
                if (CaseNum2 == 0)
                {
                    if (this.Num1 + this.Num2 + this.Num3 <= 100)
                    {
                        return Num1.ToString() + "+" + Num2.ToString() + "+" + Num3.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (this.Num1 + this.Num2 - this.Num3 <= 100 && this.Num1 + this.Num2 - this.Num3 >= 0)
                    {
                        return Num1.ToString() + "+" + Num2.ToString() + "-" + Num3.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                if (CaseNum2 == 0)
                {
                    if (this.Num1 - this.Num2 >= 0 && this.Num1 - this.Num2 + this.Num3 <= 100)
                    {
                        return Num1.ToString() + "-" + Num2.ToString() + "+" + Num3.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (this.Num1 - this.Num2 - this.Num3 >= 0)
                    {
                        return Num1.ToString() + "-" + Num2.ToString() + "-" + Num3.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
