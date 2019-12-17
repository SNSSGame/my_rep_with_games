using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        // Курс в деньгах
        static double TGold = 1000; // +-100
        static double TGround = 200; // +-50
        static double TFood = 10; // +-3
        static double TMen = 50; // +-10
        static double TArmy = 10;
       // курс в %
        static double CGold = 100;
        static double CGround = 100;
        static double CFood = 100;
        static double CMen = 100;
        static double CArmy = 100;
        // Ресурсы в наличии
        static double Money = 3000;
        static double Gold = 0;
        static int Ground = 30;
        static double Food = 300;
        static double Men = 100;  
        static int Army = 5;

        static string selection;

        static double coof;
        static int RFood;
        static int FFood;

        static Random rnd = new Random();

        static void CheckResources()
        {
             Console.Clear();
             Console.WriteLine("У вас " + Money + " Монет ");
             Console.WriteLine("У вас " + Gold + " Золота ");
             Console.WriteLine("У вас " + Ground + " Земли ");
             Console.WriteLine("У вас " + Food + " Еды ");
             Console.WriteLine("У вас " + Men + " Людей ");
             Console.WriteLine("У вас " + Army + " Бойцов ");
        }

        static void EventFood()
        {
            Console.Clear();
            Console.WriteLine("Пришло время кормить народ");
          //  Console.WriteLine("1. Напомнить кол-во ресурсов");
            Console.WriteLine("1. Выбрать кол-во еды на питание и посев");

            selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    CheckResources();

                    Console.WriteLine("   ");
                    Console.WriteLine("Чтобы все были сыты нужно " + Men + " еды, сколько дадите?");
                    RFood = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Чтобы засеять всё, нужно " + Ground + " еды, сколько дадите?");
                    FFood = Convert.ToInt32(Console.ReadLine());
                    Food = Food - (RFood + FFood);



                    if (RFood <= Men / 2)
                    {
                        // Game Over
                        Console.WriteLine("Game Over");
                    }

                    break;

                default:
                    Console.WriteLine("Вы нажали неизвестную букву");

                    break;
                                       

            }
        }

        static void Menu()
        {
            Console.WriteLine("1. Посмотреть кол-во ресурсов");
            Console.WriteLine("2. Открыть рынок");
            Console.WriteLine("3. Завершить ход");
           
            selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    CheckResources();

                    break;
                case "2":
                    Console.Clear();
                    Market();
                    break;

                case "3": // Завершение хода
                    Console.Clear();
                    Console.WriteLine("Вы завершили ход");
                    TGold = TGold + rnd.Next(-99, 100);
                    CGold = (TGold / 1000) * 100;
                    TGround = TGround + rnd.Next(-49, 50);
                    CGround = (TGround / 200) * 100;
                    TFood = TFood + rnd.Next(-2, 3);
                    CFood = (TFood / 10) * 100;
                    TMen = TMen + rnd.Next(-9, 10);
                    CMen = (TMen / 50) * 100;
                    TArmy = TArmy + rnd.Next(-2, 3);
                    CArmy = (TArmy / 10) * 100;
                    Men = Men + ((Math.Round((Men / 100), 0)) * rnd.Next(4, 20));
                    Money = Money - (10 * Army);

                    switch (rnd.Next(1, 9))
                    {
                        case 1:
                            coof = 0.5; // Страшная засуха (1\2 еды)
                            break;
                        case 2:
                        case 3:
                            coof = 1; // Засуха (1\1 еды)
                            break;
                        case 4:
                        case 5:
                        case 6:
                            coof = 1.5; // Норма (1.5\1 еды)
                            break;
                        case 7:
                        case 8:
                            coof = 2; // Хорошая погода (2\1 еды)
                            break;
                        case 9:
                            coof = 4; // Отличная погода (4\1 еды)
                            break;
                        

                    }
                   // float coofs[9] = { 0.5, // Страшная засуха (1\2 еды)
                   //                    1, 1, // Засуха (1\1 еды)
                   // };
                 //   coof = coofs[rnd.Next(0, 8)];

                    Food = Math.Round((Food + (FFood * coof)), 0);

                    EventFood();

                    break;
                default:
                    Console.WriteLine("Вы нажали неизвестную букву");
                    
                    break;
            }
        }









            static void Market()
            {

            Console.WriteLine("Курс золота "+ Math.Round(CGold, 1) + " %, цена " + TGold);
            Console.WriteLine("Курс земли " + Math.Round(CGround, 1) + " %, цена " + TGround);
            Console.WriteLine("Курс еды " + Math.Round(CFood, 1) + " %, цена " + TFood);
            Console.WriteLine("Курс крестьянина " + Math.Round(CMen, 1) + " %, цена " + TMen);
            Console.WriteLine("Курс гвардейца " + Math.Round(CArmy, 1) + " %, цена " + TArmy);



            }





        static void Main(string[] args)
        {
  

            for (; ; )
            {
                Menu();


               

            }



        }




    }
}

