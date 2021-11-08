using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    interface IWorker
    {
        //проверка наличия фундамента
        bool checkBasement();
        //проверка наличия стен
        bool checkWalls();
        //проверка наличия дверей
        bool checkDoor();
        //проверка наличия окон
        bool checkWindows();

        bool chechRoof();

        //этап строительсва (0 - ничего не построено, 1 + фундамент, 2 + стены, 3 + окна, 4 + двери

        int СonstructionStage { get; set; }
        
    }

    class Team: IWorker
    {
        //имя бригады
        public string TeamName { get; set; }
        public int СonstructionStage { get; set; }

        protected House house;
       
        public bool checkBasement()
        {
            if(house.СonstructionStage < 1)
            return false;
            
            return true;
        }

        public bool checkWalls()
        {
            if (house.СonstructionStage < 2)
                return false;

            return true;
        }

        public bool checkWindows()
        {
            if (house.СonstructionStage < 3)
                return false;

            return true;
        }

        public bool checkDoor()
        {
            if (house.СonstructionStage < 4)
                return false;

            return true;
        }
        public bool chechRoof()
        {
            if (house.СonstructionStage < 5)
                return false;

            return true;
        }

        public Team(string teamname) 
        {
            TeamName = teamname;            
        }

        public override string ToString()
        {
            return $"Имя бригады: {TeamName}";
        }
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
                return "Строю стены";
            }

            if (WhatToBuild == "Windows" && house.СonstructionStage == 2)
            {
                house.СonstructionStage = 3;
                return "Ставлю окна";
            }

            if (WhatToBuild == "Door" && house.СonstructionStage == 3)
            {
                house.СonstructionStage = 4;
                return "Устанавливаю дверь";
            }

            if (WhatToBuild == "Roof" && house.СonstructionStage == 4)
            {
                house.СonstructionStage = 5;
                return "Строю крышу";
            }

            if (house.СonstructionStage == 5)
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
        public string WhatToBuild(House house)
        {
            if (house.СonstructionStage == 1)
            {
                return "Строй стены";
            }
            
            if (house.СonstructionStage == 2)
            {
                return "Ставь окна";
            }
            
            if (house.СonstructionStage == 3)
            {
                return "Устанавливай дверь";
            }

            if (house.СonstructionStage == 4)
            {
                return "Последний этап строительства. Делай крышу";
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

        public void chekResults(House house)
        { 
            house.SetСonstruction();                       
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

    }
    class House : IWorker
    {
        public string hName { get; set; }
        public int СonstructionStage { get; set; }

        public House(string name)
        {
            hName = name;
        }

        public bool checkBasement()
        {
            if (СonstructionStage < 1)
                return false;

            return true;
        }

        public bool checkWalls()
        {
            if (СonstructionStage < 2)
                return false;

            return true;
        }

        public bool checkWindows()
        {
            if (СonstructionStage < 3)
                return false;

            return true;
        }

        public bool checkDoor()
        {
            if (СonstructionStage < 4)
                return false;

            return true;
        }
        public bool chechRoof()
        {
            if (СonstructionStage < 5)
                return false;

            return true;
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

            check = this.chechRoof();

            if (check)
            {
                reportСonstruction += "Крыша установлена. ";
                count++;
            }

            if (СonstructionStage == 5)
            {
                reportСonstruction += "Дом полностью построен.";
            }

            if (count < 0)
            {
                reportСonstruction = "Дом еще не строился.";
            }             
         
        }
    }

    class Basement : House    
    {
        public Basement(string name) : base(name) { }
    }
    class Walls : House
    {
        public Walls(string name) : base(name) { }
    }
    class Door : House
    {
        public Door(string name) : base(name) { }
    }
    class Windows : House
    {
        public Windows(string name) : base(name) { }
    }
    class Roof : House
    {
        public Roof(string name) : base(name) { }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            //создаем команду
            Team team = new Team("MyTeam");

            //создаем дом
            House house = new House("Первый дом");

            //создаем строителя и закрепляем за ним дом
            Worker builder = new Worker(team.TeamName, "Ivan (строитель)");

            //создаем бригадира и закрепляем за ним дом
            TeamLeader leader = new TeamLeader(team.TeamName, "Sergey (бригадир)");

            Console.Write("Cтроитель уточняет, что нужно строить: ");         
            Console.WriteLine(builder.WhatToBuild(house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Basement", house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель отвечает, что начал строить: ");
            Console.WriteLine(builder.Build("Walls", house));
            Console.WriteLine("\n");
            Console.Write("Cтроитель спрашивает, что дальше строить: ");
            Console.WriteLine(builder.WhatToBuild(house));
            Console.WriteLine("\n");
            Console.WriteLine("Бригадир проверяет что уже построено по указанному дому и заносит в отчет по дому (операция происходит под капотом)");
            Console.WriteLine("\n");
            leader.chekResults(house);
            Console.Write("Бригадир печатает отчет, что уже построено по указанному дому: ");
            leader.PrintReport(house);

            Console.WriteLine("\n\n\n\n");


        }
    }
}
