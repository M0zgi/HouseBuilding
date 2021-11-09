using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{

    enum Parts
    { 
        Basement, 
        Walls,
        Door,
        Windows,
        Roof
    }
    interface IWorker
    {
        string WhatToBuild(House house);
    }

    abstract class Team: IWorker
    {
        //имя бригады
        public string TeamName { get; set; }

        protected House house;  

        public Team(string teamname) 
        {
            TeamName = teamname;            
        }

        public override string ToString()
        {
            return $"Имя бригады: {TeamName}";
        }

        public abstract string WhatToBuild(House house);
      
    }
    class Worker : Team
    {
        public Worker(string teamname, string humanname) : base(teamname) 
        {
            HumanName = humanname;
        }

        public string Build(string WhatToBuild, House house)
        {
            if(WhatToBuild == "Basement" && house.СonstructionStage == 0)
            {
                house.СonstructionStage = 1;
                return "Строю фундамент";                
            }

            if (WhatToBuild == "Walls" && house.СonstructionStage == 1)
            {
                house.СonstructionStage = 2;
                return "Строю первую стену";
            }

            if (WhatToBuild == "Walls" && house.СonstructionStage == 2)
            {
                house.СonstructionStage = 3;
                return "Строю вторую стену";
            }

            if (WhatToBuild == "Walls" && house.СonstructionStage == 3)
            {
                house.СonstructionStage = 4;
                return "Строю третью стену";
            }

            if (WhatToBuild == "Walls" && house.СonstructionStage == 4)
            {
                house.СonstructionStage = 5;
                return "Строю четвертую стену";
            }

            if (WhatToBuild == "Windows" && house.СonstructionStage == 5)
            {
                house.СonstructionStage = 6;
                return "Ставлю первое окно";
            }

            if (WhatToBuild == "Windows" && house.СonstructionStage == 6)
            {
                house.СonstructionStage = 7;
                return "Ставлю второе окно";
            }

            if (WhatToBuild == "Windows" && house.СonstructionStage == 7)
            {
                house.СonstructionStage = 8;
                return "Ставлю третье окно";
            }

            if (WhatToBuild == "Windows" && house.СonstructionStage == 8)
            {
                house.СonstructionStage = 9;
                return "Ставлю четвертое окно";
            }

            if (WhatToBuild == "Door" && house.СonstructionStage == 9)
            {
                house.СonstructionStage = 10;
                return "Устанавливаю дверь";
            }

            if (WhatToBuild == "Roof" && house.СonstructionStage == 10)
            {
                house.СonstructionStage = 11;
                return "Строю крышу";
            }

            if (house.СonstructionStage == 11)
            {
                return "Дом уже был простроен";
            }

            if (house.СonstructionStage == 0 && WhatToBuild == "Roof" || WhatToBuild == "Door" || WhatToBuild == "Windows" || WhatToBuild == "Walls")
            {
                return "Начинать нужно строить с фундамента!";
            }

            else
            {
                return "Эта часть дома не предусмотрена в конструкции";
            }            
        }
        public override string WhatToBuild(House house)
        {
            if (house.СonstructionStage == 1)
            {
                return "Строй первую стену";
            }

            if (house.СonstructionStage == 2)
            {
                return "Строй вторую стену";
            }

            if (house.СonstructionStage == 3)
            {
                return "Строй третью стену";

            }

            if (house.СonstructionStage == 4)
            {
                return "Строй четвертую стену";
            }

            if (house.СonstructionStage == 5)
            {
                return "Ставь первое окно";
            }

            if (house.СonstructionStage == 6)
            {
                return "Ставь второе окно";
            }

            if (house.СonstructionStage == 7)
            {
                return "Ставь третье окно";
            }

            if (house.СonstructionStage == 8)
            {
                return "Ставь четвертое окно";
            }

            if (house.СonstructionStage == 9)
            {
                return "Устанавливай дверь";
            }

            if (house.СonstructionStage == 10)
            {
                return "Последний этап строительства. Делай крышу";
            }

            if (house.СonstructionStage == 11)
            {
                return "Дом полностью построен! Ура, товарищи!";
            }

            return "Дом еще не строился. Начинай с фундамента.";
        }

        //имя строителя
        public string HumanName { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Рабочий: {HumanName}";
        }
    }
    class TeamLeader : Team
    {
        public TeamLeader(string teamname, string humanname) : base(teamname)         
        {
            HumanName = humanname;
        }       

        public override string WhatToBuild (House house)
        { 
            house.SetСonstruction();

            return "Отчет сформирован";
        }

        //имя бригадира команды
        public string HumanName { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Бригадир: {HumanName}";
        }

        public void PrintReport(House house)
        {
            Console.WriteLine(house.reportСonstruction);
        }
    }

    interface IPart
    {
        //проверка наличия фундамента
        bool checkBasement();
        //проверка наличия стен
        bool checkWalls();
        //проверка наличия дверей
        bool checkDoor();
        //проверка наличия окон
        bool checkWindows();
        //проверка наличия крыши
        bool checkRoof();

        //этап строительсва (0 - ничего не построено, 1 + фундамент, 2 + стены, 3 + окна, 4 + двери

        int СonstructionStage { get; set; }
    }
    class House : IPart
    {
        public string hName { get; set; }
        public int СonstructionStage { get; set; }
        public House(){}
        public House(string name)
        {
            hName = name;
        }

        public bool checkBasement()
        {
            if (СonstructionStage > 0)
                return true;

            return false;           
        }

        public bool checkWalls()
        {
            if (СonstructionStage > 4)
                return true;
            
            return false;           
        }

        public bool checkWindows()
        {
            if (СonstructionStage > 8)
                return true;

            return false;            
        }

        public bool checkDoor()
        {
            if (СonstructionStage > 9)
                return true;

            return false;            
        }
        public bool checkRoof()
        {
            if (СonstructionStage > 10)
                return true;

            return false;            
        }

        public string reportСonstruction { get; set; }
        public void SetСonstruction()
        {
            
            reportСonstruction = "";
            bool check = this.checkBasement();
            int count = 0;

            if (check)
            {
                reportСonstruction = "Фундамент готов. ";
                count++;
            }

            check = this.checkWalls();

            if (check)
            {
                reportСonstruction += "Стены построены. ";
                count++;
            }

            check = this.checkWindows();

            if (check)
            {
                reportСonstruction += "Окна установлены. Откосы сделаны. ";
                count++;
            }

            check = this.checkDoor();

            if (check)
            {
                reportСonstruction += "Дверь установлена. ";
                count++;
            }

            check = this.checkRoof();

            if (check)
            {
                reportСonstruction += "Крыша установлена. ";
                count++;
            }

            if (СonstructionStage == 11)
            {
                reportСonstruction += "Дом полностью построен.";
            }

            if (count < 0)
            {
                reportСonstruction = "Дом еще не строился.";
            }          
        }

        public override string ToString()
        {
            return $"Название дома: {hName} ";
        }

        public void Print(House h) { Console.WriteLine(h.hName); }
    }

    class Basement : House    
    {
        public Basement(string name) : base(name) { }

        public Basement() { }


        public new void Print(House h)
        {
            if (h.checkBasement())
                Console.WriteLine("Рисую фундамент");

            else
                Console.WriteLine("Фундамент не могу нарисовать(его нет)");
        }
    }
    class Walls : House
    {
        
        public Walls(string name) : base(name) { }

        public Walls() { }

        public new void Print(House h)
        {
            if (h.checkWalls())
                Console.WriteLine("Рисую стены");

            else
                Console.WriteLine("Стены не могу нарисовать(их нет)");
        }
    }
    class Door : House
    {
        public Door(string name) : base(name) { }
        public Door() { }
       

        public new void Print(House h)
        {
            if (h.checkDoor())
                Console.WriteLine("Рисую двери"); 

            else
                Console.WriteLine("Двери не могу нарисовать(их нет)");
        }
    }
    class Windows : House
    {
        public Windows(string name) : base(name) { }
        public Windows() { }
    

        public new void Print(House h)
        {
            if (h.checkWindows())
                Console.WriteLine("Рисую окна");

            else
                Console.WriteLine("Окна не могу нарисовать(их нет)");
        }
    }
    class Roof : House
    {
        public Roof(string name) : base(name) { }
        public Roof() { }

        public new void Print(House h)
        {
            if (h.checkRoof())
                Console.WriteLine("Рисую крышу");

            else
                Console.WriteLine("Крышу не могу нарисовать(ее нет)");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            //создаем команду
            //Team team = new Team("MyTeam");

            string MyTeam = "MyTeam";

            //создаем дом
            House house = new House("Первый дом");

            //создаем строителя и закрепляем за ним дом
            Worker builder = new Worker(MyTeam, "Ivan (строитель)");

            //создаем бригадира и закрепляем за ним дом
            TeamLeader leader = new TeamLeader(MyTeam, "Sergey (бригадир)");

            Console.Write("Cтроитель уточняет, что нужно строить: ");         
            Console.WriteLine(builder.WhatToBuild(house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Basement", house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Walls", house));
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Walls", house));
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Walls", house));


            Console.WriteLine("\n");
            Console.Write("Cтроитель спрашивает, что дальше строить: ");
            Console.WriteLine(builder.WhatToBuild(house));

            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Walls", house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель спрашивает, что дальше строить: ");
            Console.WriteLine(builder.WhatToBuild(house));
            //---------------- Что бы полностью построить дом, раскомментировать ниже код ----------------//

            //string myParts = Parts.Walls.ToString();

            //builder.Build(myParts, house);

            //myParts = Parts.Windows.ToString();
            //builder.Build(myParts, house);
            //builder.Build(myParts, house);
            //builder.Build(myParts, house);
            //builder.Build(myParts, house);

            //myParts = Parts.Door.ToString();
            //builder.Build(myParts, house);

            //myParts = Parts.Roof.ToString();
            //builder.Build(myParts, house);

            //-------------------------------------------------------------------------------------------//

            Console.WriteLine("\n");
            Console.WriteLine("Бригадир проверяет что уже построено по указанному дому и заносит в отчет по дому");
            Console.WriteLine(leader.WhatToBuild(house));
            Console.WriteLine("\n");
            Console.WriteLine("Бригадир печатает отчет, что уже построено по указанному дому: ");
            leader.PrintReport(house);
            Console.WriteLine("\n\n");       
            
            Console.WriteLine(house);

            House[] housePrint = new House[] { new Basement(), new Walls(), new Windows(), new Door(), new Roof() };

            foreach (var item in housePrint)
            {
                if (item is Basement)
                {
                    (item as Basement).Print(house);
                }

                if (item is Walls)
                {
                    (item as Walls).Print(house);
                }

                if (item is Windows)
                {
                    (item as Windows).Print(house);
                }

                if (item is Door)
                {
                    (item as Door).Print(house);
                }

                if (item is Roof)
                {
                    (item as Roof).Print(house);
                }
            }

            //Basement basement = new Basement();
            //Walls walls = new Walls();
            //Windows windows = new Windows();
            //Door door = new Door();            
            //Roof roof = new Roof();

            //basement.Print(house);
            //walls.Print(house);
            //windows.Print(house);
            //door.Print(house);
            //roof.Print(house);            

            Console.WriteLine("\n\n\n\n");
        }
    }
}
