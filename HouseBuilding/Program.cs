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
        private const string WORKER_FIRST_MESSAGE = "Начинать нужно строить с фундамента!";
        private const string WORKER_BASEMENT_MESSAGE = "Строю фундамент"; 
        private const string WORKER_WALLS_1_MESSAGE = "Строю первую стену";
        private const string WORKER_WALLS_2_MESSAGE = "Строю вторую стену";
        private const string WORKER_WALLS_3_MESSAGE = "Строю третью стену";
        private const string WORKER_WALLS_4_MESSAGE = "Строю четвертую стену";
        private const string WORKER_WINDOWS_1_MESSAGE = "Ставлю первое окно";
        private const string WORKER_WINDOWS_2_MESSAGE = "Ставлю второе окно";
        private const string WORKER_WINDOWS_3_MESSAGE = "Ставлю третье окно";
        private const string WORKER_WINDOWS_4_MESSAGE = "Ставлю четвертое окно";
        private const string WORKER_DOOR_MESSAGE = "Устанавливаю дверь";
        private const string WORKER_ROOF_MESSAGE = "Строю крышу";
        private const string WORKER_FINISH_MESSAGE = "Дом уже был простроен";
        private const string WORKER_ERROR_MESSAGE = "Эта часть дома не предусмотрена в конструкции";

        private const string WHAT_TO_BUILD_BASEMENT_MESSAGE = "Дом еще не строился. Начинай с фундамента.";
        private const string WHAT_TO_BUILD_WALLS_1_MESSAGE = "Строй первую стену";
        private const string WHAT_TO_BUILD_WALLS_2_MESSAGE = "Строй вторую стену";
        private const string WHAT_TO_BUILD_WALLS_3_MESSAGE = "Строй третью стену";
        private const string WHAT_TO_BUILD_WALLS_4_MESSAGE = "Строй четвертую стену";
        private const string WHAT_TO_BUILD_WINDOWS_1_MESSAGE = "Ставь первое окно";
        private const string WHAT_TO_BUILD_WINDOWS_2_MESSAGE = "Ставь второе окно";
        private const string WHAT_TO_BUILD_WINDOWS_3_MESSAGE = "Ставь третье окно";
        private const string WHAT_TO_BUILD_WINDOWS_4_MESSAGE = "Ставь четвертое окно";
        private const string WHAT_TO_BUILD_DOOR_MESSAGE = "Устанавливай дверь";
        private const string WHAT_TO_BUILD_ROOF_MESSAGE = "Последний этап строительства. Делай крышу";
        private const string WHAT_TO_BUILD_FINISH_MESSAGE = "Дом полностью построен! Ура, товарищи!";

        private const int CONSTRUCTION_STAGE_ZERO = 0;
        private const int CONSTRUCTION_STAGE_BASEMENT = 1;
        private const int CONSTRUCTION_STAGE_WALLS_1 = 2;
        private const int CONSTRUCTION_STAGE_WALLS_2 = 3;
        private const int CONSTRUCTION_STAGE_WALLS_3 = 4;
        private const int CONSTRUCTION_STAGE_WALLS_4 = 5;
        private const int CONSTRUCTION_STAGE_WINDOWS_1 = 6;
        private const int CONSTRUCTION_STAGE_WINDOWS_2 = 7;
        private const int CONSTRUCTION_STAGE_WINDOWS_3 = 8;
        private const int CONSTRUCTION_STAGE_WINDOWS_4 = 9;
        private const int CONSTRUCTION_STAGE_DOOR = 10;
        private const int CONSTRUCTION_STAGE_ROOF = 11;
        
        public Worker(string teamname, string humanname) : base(teamname) 
        {
            HumanName = humanname;
        }

        public string Build(string WhatToBuild, House house)
        {
            if(WhatToBuild == Parts.Basement.ToString() && house.СonstructionStage == 0)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_BASEMENT;
                return WORKER_BASEMENT_MESSAGE;                
            }

            if (WhatToBuild == Parts.Walls.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_BASEMENT)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WALLS_1;
                return WORKER_WALLS_1_MESSAGE;
            }

            if (WhatToBuild == Parts.Walls.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_1)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WALLS_2;
                return WORKER_WALLS_2_MESSAGE;
            }

            if (WhatToBuild == Parts.Walls.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_2)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WALLS_3;
                return WORKER_WALLS_3_MESSAGE;
            }

            if (WhatToBuild == Parts.Walls.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_3)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WALLS_4;
                return WORKER_WALLS_4_MESSAGE;
            }

            if (WhatToBuild == Parts.Windows.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_4)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WINDOWS_1;
                return WORKER_WINDOWS_1_MESSAGE;
            }

            if (WhatToBuild == Parts.Windows.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_1)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WINDOWS_2;
                return WORKER_WINDOWS_2_MESSAGE;
            }

            if (WhatToBuild == Parts.Windows.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_2)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WINDOWS_3;
                return WORKER_WINDOWS_3_MESSAGE;
            }

            if (WhatToBuild == Parts.Windows.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_3)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_WINDOWS_4;
                return WORKER_WINDOWS_4_MESSAGE;
            }

            if (WhatToBuild == Parts.Door.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_4)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_DOOR;
                return WORKER_DOOR_MESSAGE;
            }

            if (WhatToBuild == Parts.Roof.ToString() && house.СonstructionStage == CONSTRUCTION_STAGE_DOOR)
            {
                house.СonstructionStage = CONSTRUCTION_STAGE_ROOF;
                return WORKER_ROOF_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_ROOF)
            {
                return WORKER_FINISH_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_ZERO && WhatToBuild == Parts.Roof.ToString() || WhatToBuild == Parts.Door.ToString() || WhatToBuild == Parts.Windows.ToString() || WhatToBuild == Parts.Walls.ToString())
            {
                return WORKER_FIRST_MESSAGE;
            }

            else
            {
                return WORKER_ERROR_MESSAGE;
            }            
        }
        public override string WhatToBuild(House house)
        {
            if (house.СonstructionStage == CONSTRUCTION_STAGE_BASEMENT)
            {
                return WHAT_TO_BUILD_WALLS_1_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_1)
            {
                return WHAT_TO_BUILD_WALLS_2_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_2)
            {
                return WHAT_TO_BUILD_WALLS_3_MESSAGE;

            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_3)
            {
                return WHAT_TO_BUILD_WALLS_4_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WALLS_4)
            {
                return WHAT_TO_BUILD_WINDOWS_1_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_1)
            {
                return WHAT_TO_BUILD_WINDOWS_2_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_2)
            {
                return WHAT_TO_BUILD_WINDOWS_3_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_3)
            {
                return WHAT_TO_BUILD_WINDOWS_4_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_WINDOWS_4)
            {
                return WHAT_TO_BUILD_DOOR_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_DOOR)
            {
                return WHAT_TO_BUILD_ROOF_MESSAGE;
            }

            if (house.СonstructionStage == CONSTRUCTION_STAGE_ROOF)
            {
                return WHAT_TO_BUILD_FINISH_MESSAGE;
            }

            return WHAT_TO_BUILD_BASEMENT_MESSAGE;
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

        private const int STEP_BASEMENT = 1;       
        private const int STEP_WALLS = 4;
        private const int STEP_WINDOWS = 8;
        private const int STEP_DOOR = 9;
        private const int STEP_ROOF = 10;

        private const int CONSTRUCTION_STAGE_FINISH = 11;
        private const int CONSTRUCTION_STAGE_ZERO = 0;
        public bool checkBasement()
        {
            if (СonstructionStage > STEP_BASEMENT)
                return true;

            return false;           
        }

        public bool checkWalls()
        {
            if (СonstructionStage > STEP_WALLS)
                return true;
            
            return false;           
        }

        public bool checkWindows()
        {
            if (СonstructionStage > STEP_WINDOWS)
                return true;

            return false;            
        }

        public bool checkDoor()
        {
            if (СonstructionStage > STEP_DOOR)
                return true;

            return false;            
        }
        public bool checkRoof()
        {
            if (СonstructionStage > STEP_ROOF)
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

            if (СonstructionStage == CONSTRUCTION_STAGE_FINISH)
            {
                reportСonstruction += "Дом полностью построен.";
            }

            if (count == CONSTRUCTION_STAGE_ZERO)
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

            string builderQuestionWhatToBuild = "Cтроитель уточняет, что нужно строить: ";
            string builderRepotr = "Cтроитель отвечает, что начал строить: ";
            

            Console.Write(builderQuestionWhatToBuild);         
            Console.WriteLine(builder.WhatToBuild(house));
            Console.WriteLine("\n");
            Console.Write(builderRepotr);
            Console.WriteLine(builder.Build(Parts.Basement.ToString(), house));
            Console.WriteLine("\n");
            Console.Write(builderRepotr);            

            Console.WriteLine(builder.Build(Parts.Walls.ToString(), house));
            Console.Write(builderRepotr);
            Console.WriteLine(builder.Build(Parts.Walls.ToString(), house));
            Console.Write(builderRepotr);
            Console.WriteLine(builder.Build(Parts.Walls.ToString(), house));


            Console.WriteLine("\n");
            Console.Write(builderQuestionWhatToBuild);
            Console.WriteLine(builder.WhatToBuild(house));

            Console.Write(builderRepotr);
            Console.WriteLine(builder.Build(Parts.Walls.ToString(), house));
            Console.WriteLine("\n");
            Console.Write(builderQuestionWhatToBuild);
            Console.WriteLine(builder.WhatToBuild(house));
            //---------------- Что бы полностью построить дом, раскомментировать ниже код ----------------//

            

            //builder.Build(Parts.Windows.ToString(), house);
            //builder.Build(Parts.Windows.ToString(), house);
            //builder.Build(Parts.Windows.ToString(), house);
            //builder.Build(Parts.Windows.ToString(), house);           
            //builder.Build(Parts.Door.ToString(), house);           
            //builder.Build(Parts.Roof.ToString(), house);

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
