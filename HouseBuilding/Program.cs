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

        House house;

        //public int IWorker.СonstructionStage()
        //{
        //    int count = 0;

        //    if (checkBasement())
        //    {
        //        count++;
        //    }

        //    if(checkWalls())
        //    {
        //        count++;
        //    }

        //    if (checkWalls())
        //    {
        //        count++;
        //    }

        //    if (checkDoor())
        //    {
        //        count++;
        //    }

        //    if (checkWindows())
        //    {
        //        count++;
        //    }

        //    if (chechRoof())
        //    {
        //        count++;
        //    }

        //    return СonstructionStage() = count;
        //}

        public bool checkBasement()
        {
            if(СonstructionStage < 1)
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
        // private string Build;

        //public string BuildStatus { get; set; }

        public string Build(string WhatToBuild)
        {
            if(WhatToBuild == "Basement" && СonstructionStage == 0)
            {
                СonstructionStage = 1;
                return "Строю фундамент";                
            }

            if (WhatToBuild == "Walls" && СonstructionStage == 1)
            {
                СonstructionStage = 2;
                return "Строю стены";
            }

            if (WhatToBuild == "Windows" && СonstructionStage == 2)
            {
                СonstructionStage = 3;
                return "Ставлю окна";
            }

            if (WhatToBuild == "Door" && СonstructionStage == 3)
            {
                СonstructionStage = 4;
                return "Устанавливаю дверь";
            }

            if (WhatToBuild == "Roof" && СonstructionStage == 4)
            {
                СonstructionStage = 5;
                return "Строю крышу";
            }

            if (СonstructionStage == 5)
            {
                return "Дом уже был простроен";
            }

            if (СonstructionStage == 0 && WhatToBuild == "Roof" || WhatToBuild == "Door" || WhatToBuild == "Windows" || WhatToBuild == "Walls")
            {
                return "Начинать нужно строить с фундамента!";
            }

            else
            {
                return "Эта часть дома не предусмотрена в конструкции";
            }
            
        }
        public string WhatToBuild()
        {
            if (this.СonstructionStage == 1)
            {
                return "Строй стены";
            }
            
            if (this.СonstructionStage == 2)
            {
                return "Ставь окна";
            }
            
            if (this.СonstructionStage == 3)
            {
                return "Устанавливай дверь";
            }

            if (this.СonstructionStage == 4)
            {
                return "Последний этап строительства. Делай крышу";
            }

            return "Дом еще не строился. Начинай с фундамента.";
        }


        //имена строителя
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

        // public string reportСonstruction { get; set; }

        private string reportСonstruction = "Дом еще не строился.";

        public void chekResults()
        {
            //if (СonstructionStage == 1)
           // {
                checkBasement();                             
           // }

           // if (СonstructionStage == 2)
           // {
                checkWalls();               
           // }

           // if (СonstructionStage == 3)
           // {             
                checkWindows();               
           // }

           // if (СonstructionStage == 4)
           // {
                checkDoor();
           // }

           // if (СonstructionStage == 5)
           // {
                chechRoof();            
            //}

        }

        public string SetGetСonstruction
        {
            get { return reportСonstruction; }
            set 
            {
                reportСonstruction = "";
                bool check = checkBasement();
                int count = 0;

                if (check)
                {
                    value = "Фундамент готов. ";
                    count++;
                }

                check = checkWalls();

                if (check)
                {
                    value += "Стены построены. ";
                    count++;
                }

                check = checkWindows();

                if (check)
                {
                    value += "Окна установлены. Откосы сделаны. ";
                    count++;
                }

                check = checkDoor();

                if (check)
                {
                    value += "Дверь установлена. ";
                    count++;
                }

                check = chechRoof();

                if (check)
                {
                    value += "Крыша установлена. ";
                    count++;
                }

                if (this.СonstructionStage == 5)
                {
                    value += "Дом полностью построен.";
                }

                if (count > 0)
                {
                    reportСonstruction = value;
                }

                else
                reportСonstruction = "Дом еще не строился.";
            }
        }


        //имя бригадира команды
        public string HumanName { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Бригадир: {HumanName}";
        }

        public void PrintReport()
        {
            Console.WriteLine(this.SetGetСonstruction);
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
            throw new NotImplementedException();
        }

        public bool checkWalls()
        {
            throw new NotImplementedException();
        }

        public bool checkDoor()
        {
            throw new NotImplementedException();
        }

        public bool checkWindows()
        {
            throw new NotImplementedException();
        }

        public bool chechRoof()
        {
            throw new NotImplementedException();
        }
    }

    class Basement : House    {
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
            Team team = new Team("MyTeam");

            Worker builder = new Worker(team.TeamName, "Ivan (строитель)");

            TeamLeader leader = new TeamLeader(team.TeamName, "Sergey (бригадир)");

            Console.WriteLine(builder.WhatToBuild());
            Console.WriteLine(builder.Build("Basement"));
            Console.WriteLine(builder.Build("Walls"));
            Console.WriteLine(builder.WhatToBuild());


            //Console.WriteLine(builder);
            // Console.WriteLine(leader);

            leader.chekResults();

            leader.PrintReport();

            Console.WriteLine("\n\n\n\n");


        }
    }
}
