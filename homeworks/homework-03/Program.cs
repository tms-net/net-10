Console.WriteLine("Введи выражение");
var str = Console.ReadLine();
string op1 = "";
string op2 = "";
string oper = "";
double res = 0;
var fl = true;
foreach (char c in str)
{
    if (c >= '0' && c <= '9')
        if (fl)
            op1 += c;
        else
            op2 += c;
    else
    {
        fl = false;
        oper+=c;
    }
}
int opd1 = Int32.Parse(op1);
int opd2 = Int32.Parse(op2);
switch (oper) 
{
    case "+":
        res = opd1 + opd2;
        break;
    case "-":
        res = opd1- opd2;
        break;
    case "*":
        res = opd1 * opd2;
        break;
    case "^":
        res = Math.Pow(opd1, opd2); 
        break;
    case "/":
        res =(double) opd1 / opd2;
        break;
    case " concat ":
        res = Int32.Parse(op1+op2);
        break;
    case " mod ":
        res = opd1 % opd2;
        break;
}
Console.WriteLine(res);
