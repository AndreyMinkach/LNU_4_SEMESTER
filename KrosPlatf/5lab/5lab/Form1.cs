using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XIO_Demo_Indexer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        public class CaseTransistors
        {
            public string transType { get; set; } // Тип транзистора 
            public string transName {get;set;}	// Назва транзистора
            public string trsnsModelName { get; set; } // Назва мат. моделі транзистораж

            transPrefixName[] Prefixs; // Масив для зберігання валідних префіксів імен транзисторів
            CaseTransistors[] transistors;  // Оголосили масив для зберігання транзисторів з модифікатором доступу private (по замовчуванню)
            public int Length;  // Кількість транзисторів у масиві
            public int ErrorKod;    // Код завершення операції записування або зчитуваня. 0 - все добре, 1 - поганий індекс, 2 - поганий префікс імені
                                    // Це конструктор класу CaseTransistors

            public CaseTransistors(int size, string type, string tname, string modelName)
            {
                // У конструкторі класу створюємо масив для зберігання транзисторів - екземплярів класу CaseTransistors
                transistors = new CaseTransistors[size]; // Створюємо масив	заданого у параметрі size розміру
                Length = size;
                setPrefixName(); // Заповнимо масив структур префіксів імен транзисторів можливими значеннями
                transType = type; transName = tname;
                trsnsModelName = modelName;
            } // Кінець конструктора
            struct transPrefixName // Структура для опису префіксів імен транзисторів
            {
                public string PrefixName; // Ім'я префікса
                public string PrefixText; // Пояснення значення префікса
            }

            // Перевизначений метод для видруку інформації про транзистор
            public override string ToString()
{
return " Транзистор " + transName + " Тип- " + transType + " модель- " + trsnsModelName;
}

        void setPrefixName()
        {
            Prefixs = new transPrefixName[14]; // Масив структур для зберігання вірних префіксів імен транзисторів
                                               // Ця довідкова інформація реальна, взята на http://en.wikipedia.org/wiki/Transistor 
                Prefixs[0].PrefixName="AC";	Prefixs[0].PrefixText="Germanium small-signal AFtransistor AC126";
        Prefixs[1].PrefixName = "AD"; Prefixs[0].PrefixText = " Germanium AF power transistor AD133";
            Prefixs[2].PrefixName = "AF"; Prefixs[0].PrefixText = " Germanium small-signal RF transistor AF117";
            Prefixs[3].PrefixName = "AL"; Prefixs[0].PrefixText = " Germanium RF power transistor ALZ10";
            Prefixs[4].PrefixName = "AS"; Prefixs[0].PrefixText = " Germanium switching transistor ASY28";
            Prefixs[5].PrefixName = "AU"; Prefixs[0].PrefixText = " Germanium power switching transistor AU103";
            Prefixs[6].PrefixName = "BC"; Prefixs[0].PrefixText = " Silicon, small signal transistor	BC548B";
            Prefixs[7].PrefixName = "BD"; Prefixs[0].PrefixText = " Silicon, power transistorBD139";
        Prefixs[8].PrefixName = "BF"; Prefixs[0].PrefixText = " Silicon, RF (high frequency)BJT or FET BF245";
        Prefixs[9].PrefixName = "BS"; Prefixs[0].PrefixText = " Silicon, switching transistor (BJT or MOSFET) BS170";
            Prefixs[10].PrefixName = "BL"; Prefixs[0].PrefixText = " Silicon, high frequency, high power (for transmitters) BLW34";
            Prefixs[11].PrefixName = "BU"; Prefixs[0].PrefixText = " Silicon, high voltage (for CRT horizontal deflection circuits) BU508";
            Prefixs[12].PrefixName = "CF"; Prefixs[0].PrefixText = " Gallium Arsenide small- signal Microwave transistor (MESFET)	CF300";
            Prefixs[13].PrefixName = "CL"; Prefixs[0].PrefixText = " Gallium Arsenide Microwave power transistor (FET) CLY10";
        }
            // Метод для визначення правильності префікса імені тразистора 
            bool OkPrefixName(string prefix)
{
for(int i=0 ;i<14;i++ )
{
if (Prefixs[i].PrefixName == prefix) return true;
}
return false;
}
bool OkIndex(int i) // Метод для визначення правильності індекса
{

    if (i >= 0 && i < Length) return true; else return false;
}

// Це індексатор для класу CaseTransistors по полю Transistors 
public CaseTransistors this[int index]
{
get // вибрати об'єкт типу транзистор з індексом index
{
 
if (OkIndex(index)) // Якщо добрий індекс, то повертаємо елемент масиву і

{
ErrorKod = 0;
return transistors[index];
 
}
else
{
ErrorKod = 1; // Якщо індекс поганий, то повертаємо null і код завершення 1 
                        return null;
}
}
set	// Записати транзистор у масив транзисторів у елемент з індексом index
{
// Перед засиланням транзистора у масив перевіряємо індекс
if (! OkIndex(index)) {ErrorKod =1; return;}
// а також перевіряємо, чи належати 2 перших символи імені до таблиці префіксів імен транзисторів
// Якщо префікс невірний, то повертаємо код завершення =2 і транзистор у бібліотеку не записуємо
if (!OkPrefixName(value.transName.Substring (0,2))) {ErrorKod =2; return;} transistors[index]=value; // Якщо індекс і ім'я добрі, то записуємо
ErrorKod = 0; // і встановлюємо код завершення 0
}
}

}

private void button1_Click(object sender, EventArgs e)
{


            // Створюємо екземпляри класу CaseTransistors з допомогою конструктора з параметрами
            // (Тут типи транзисторів вибрано навмання, вони не відповідають своїм іменам)
            CaseTransistors MyTr = new CaseTransistors(5,"Bipolar","AC126",	"EbbersMoll");
            CaseTransistors MyTr1 = new CaseTransistors(1, "Field-effet", "AC126", "Gummel-Poon");
            CaseTransistors MyTr2 = new CaseTransistors(1, "Field-effet", "AD133", "Gummel-Poon");
            CaseTransistors MyTr3 = new CaseTransistors(1, "Schottky", "BD139", "Gummel-Poon");
            CaseTransistors MyTr4 = new CaseTransistors(1, "Avalanche", "OO117", "EbbersMoll");
            CaseTransistors MyTr5 = new CaseTransistors(1, "Darlington", "BLW34", "EbbersMoll");
            CaseTransistors MyTr6 = new CaseTransistors(1, "Photo", "BU508", "EbbersMoll");
            CaseTransistors MyTr7 = new CaseTransistors(1, "Bipolar", "CLY10", "EbbersMoll");

            // Поміщаємо створені транзистори у масив транзисторів з допомогою індексатора. Перевіряємо код завершення після кожної операції
            // Накопичуємо інформацію про хід роботи програми у змінній sMessage 
            string sMessage = " ";
    MyTr[0] = MyTr1;
    if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 1 Транзистор не додано " + MyTr1.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n1  Транзистор додано " + MyTr1.transType + " "; MyTr[1] = MyTr2;
if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 2 Транзистор не додано " + MyTr2.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n2   Транзистор додано " + MyTr2.transType + " "; MyTr[2] = MyTr3;
if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 3 Транзистор не додано " + MyTr3.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n3   Транзистор додано " + MyTr3.transType + " "; MyTr[3] = MyTr4;


if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 4 Транзистор не додано " + MyTr4.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n4   Транзистор додано " + MyTr4.transType + " "; MyTr[4] = MyTr5;
if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 5 Транзистор не додано " + MyTr5.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n5   Транзистор додано " + MyTr5.transType + " "; MyTr[5] = MyTr6;
if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 6 Транзистор не додано " + MyTr6.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n6   Транзистор додано " + MyTr6.transType + " "; MyTr[6] = MyTr7;
if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 7 Транзистор не додано " + MyTr7.transType + " код помилки -" + MyTr.ErrorKod.ToString();
    else sMessage = sMessage + "\n7   Транзистор додано " + MyTr7.transType + " ";
    label1.Text = sMessage; // Виведемо інформацію про додані (чи не додані) транзистори у мітку label1.
                        // Сформуємо інформацію про поміщені у масив транзистори з допомогою перевизначеного нами методу ToString у змінній sMessage .
    sMessage = "";
    for (int i = 0; i < MyTr.Length; i++)
    {
        if (MyTr[i] != null) sMessage = sMessage + "\n " + MyTr[i].ToString();
    }
    label2.Text = sMessage;
}

    }
}
