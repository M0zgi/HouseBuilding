using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    interface IWorker
    {
        bool checkBasement();
        bool checkWalls();
        bool checkDoor();
        bool checkWindow();

        int СonstructionStage { get; set; }


    }

    class Team: IWorker
    {
        public string TeamName { get; set; }
        public int СonstructionStage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool checkBasement()
        {
            throw new NotImplementedException();
        }

        public bool checkDoor()
        {
            throw new NotImplementedException();
        }

        public bool checkWalls()
        {
            throw new NotImplementedException();
        }

        public bool checkWindow()
        {
            throw new NotImplementedException();
        }
    }
    class Worker : Team
    {

    }
    class TeamLeader : Team
    {

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
