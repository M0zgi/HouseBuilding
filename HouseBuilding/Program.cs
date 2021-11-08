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
        bool checkWindow();

        //этап строительсва (0 - ничего не построено, 1 + фундамент, 2 + стены, 3 + окна, 4 + двери
        int СonstructionStage { get; set; }
    }

    class Team: IWorker
    {
        //имя бригады
        public string TeamName { get; set; }

        //имена строителя, бригадира команды
        public string HumanName { get; set; }

        public int СonstructionStage { get; set; }

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

        public bool checkWindow()
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

        public Team(string teamname, string humanname) 
        {
            TeamName = teamname;
            HumanName = humanname;
        }
    }
    class Worker : Team
    {
        public Worker(string teamname, string humanname) : base(teamname, humanname) { }
        public string Build { get; set; }
    }
    class TeamLeader : Team
    {
        public TeamLeader(string teamname, string humanname) : base(teamname, humanname) { }

        public string reportСonstruction { get; set; }
    }

    interface IPart
    {

    }
    class House
    {

    }

    class Basement : House
    {

    }
    class Walls : House
    {

    }
    class Door : House
    {

    }
    class Window : House
    {

    }
    class Roof : House
    {

    }
    

    class Program
    {
        static void Main(string[] args)
        {





        }
    }
}
