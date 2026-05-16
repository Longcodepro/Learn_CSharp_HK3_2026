using System;

namespace Lab02
{
    public class Calculator
    {
        // ---- method definitions ----
        private bool TryReadInt(string prompt, out int result)
        {
            Console.Write($"{prompt} \n >");
            string input = Console.ReadLine() ?? "";

            if( !int.TryParse(input, out int number) )
            {
                Console.WriteLine("----- ERROR NHẬP SỐ KHÔNG HỢP LỆ -----");
                result = 0;
                return false;
            }
            else
            {
                result = number;
                return true;
            }
        }

        // ----- method PrintFinalEquation -----
        private void PrintFinalEquation(int n1, int n2, string @operator)
        {
            if( !EqualsCaseInsensitive(@operator) )
            {
                Console.WriteLine("-----ERROR KHÔNG CÓ PHÉP TOÁN NÀY----");
            }
            else
            {
                @operator = @operator.ToUpper();
                double result = 0.0;
                string dau = "";
                switch (@operator)
                {
                    case "A":
                        result = n1 + n2;
                        dau = "+";
                        break;;
                    case "B":
                        result = n1 - n2;
                        dau = "-";
                        break;
                    case "M":
                        result = n1 * n2;
                        dau = "*";
                        break;
                    case "D":
                        if ( n2 == 0)
                        {
                            Console.WriteLine("------ ERROR LỖI KHI CHIA CHO SỐ 0 -------");
                            return;
                        }
                        else
                        {
                            dau = "/";
                            result = (double)n1 / (double)n2;
                        }
                        break;
                    default:
                        Console.WriteLine("---- ERROR CHƯA KIỂM TRA SẠCH -------");
                        break;
                }

                Console.WriteLine($"{n1} {dau} {n2} = {result}");
            }
        }

        // ---- method menu -----
        private void menu()
        {
            Console.WriteLine("[A]-Cộng (Add)\n[B]-Trừ (Subtract)\n[M]-Nhân (Multiply)\n[D]-Chia (Divide)");
        }

        // --- method choose operator -----
        private readonly string[] listOperator = {"A", "B", "M", "D"};
        private string ChooseOperator()
        {
            this.menu();
            Console.Write("Hãy nhập lựa chọn ....  \n >");
            string @operator = Console.ReadLine() ?? "";
            return @operator;
        }

        // ----- method EqualsCaseInsensitive -----
        private bool EqualsCaseInsensitive(string @operator)
        {
            if( listOperator.Any(c => c == @operator.ToUpper() || c == @operator.ToLower()) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // --- method activate -----
        public void Activate()
        {
            Console.Clear();
            if(!TryReadInt("Nhập vào số thứ nhất: ", out int number1)) return;
            if(!TryReadInt("Nhập vào số thứ hai: ", out int number2)) return;

            string @operator = ChooseOperator();

            PrintFinalEquation(number1, number2, @operator);
        }
    }
}