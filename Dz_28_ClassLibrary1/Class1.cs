using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Reflection;

namespace Dz_28_ClassLibrary1
{
    public class Info
    {
        public string proizvod { get; set; }
        public string model { get; set; }
        public double emkost { get; set; }
        public int kolvo { get; set; }

        public Info() { }
        public virtual void Init()
        {
            Write("Производитель ");
            proizvod = ReadLine();
            Write("Модель ");
            model = ReadLine();
            Write("Емкость ");
            emkost = Convert.ToDouble(ReadLine());
            kolvo++;
        }

        public virtual void Print()
        {
            WriteLine($"Производитель - {proizvod}\nМодель - {model}\nЕмкость - {emkost}\nКоличество - {kolvo}");
        }

        public virtual void SaveInFile(Type t)
        {
            WriteLine("Введите любой текст.");
            StreamWriter sw = new StreamWriter("User.log", true);
            string line;

            line = "Класс - " + t.FullName + "\nБазовый класс - " + t.BaseType + "\n";
            line += "Члены класса:\n ";
            int i = 1;
            foreach (MemberInfo mi in t.GetMembers())
            {
                line += i + ") " + mi.DeclaringType + " " + mi.MemberType + " " + mi.Name + "\n";
                i++;
            }
            i = 1;
            int j = 1;
            MethodInfo[] met = t.GetMethods();
            foreach (MethodInfo m in met)
            {
                line += i + ") Метод: " + m + "\n";
                ParameterInfo[] pi = m.GetParameters();
                if (pi.Length > 0)
                    line += "\tПараметры: \n";
                foreach (ParameterInfo p in pi)
                    line += j + ") " + p + "\n";
            }

            sw.WriteLine(line);
            sw.Close();
        }
    }

    class Flesh : Info
    {
        public double speedUSB { get; set; }

        public override void Init()
        {
            base.Init();
            Write("Скорость ЮСБ ");
            speedUSB = Convert.ToDouble(ReadLine());
        }

        public override void Print()
        {
            base.Print();
            WriteLine($"Скорость ЮСБ - {speedUSB}");
        }

        public override void SaveInFile(Type t)
        {
            base.SaveInFile(t);
        }
    }

    class DVD : Info
    {
        public double speedUSB { get; set; }

        public override void Init()
        {
            base.Init();
        }

        public override void Print()
        {
            base.Print();
        }

        public override void SaveInFile(Type t)
        {
            base.SaveInFile(t);
        }
    }

    class HDD : Info
    {
        public double speed { get; set; }

        public override void Init()
        {
            base.Init();
            Write("Скорость шпинделя ");
            speed = Convert.ToDouble(ReadLine());
        }

        public override void Print()
        {
            base.Print();
            WriteLine($"Скорость шпинделя - {speed}");
        }

        public override void SaveInFile(Type t)
        {
            base.SaveInFile(t);
        }
    }
}
