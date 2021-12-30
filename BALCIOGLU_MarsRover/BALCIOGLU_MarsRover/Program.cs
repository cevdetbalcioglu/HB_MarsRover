using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BALCIOGLU_MarsRover.Constant;

namespace BALCIOGLU_MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Gezici Adedini Girin : ");
                int roverCount = Convert.ToInt16(Console.ReadLine());

                //Plato Bilgilerini Al.
                plato:
                Console.Clear();
                Console.Write("Plato Ebatlarını Girin : ");

                List<int> platoSizes = new List<int>();
                try
                {
                    string platoInfo = Console.ReadLine().Trim();
                    platoSizes = platoInfo.Split(' ').Select(int.Parse).ToList();
                }
                catch 
                {
                    Console.Write("Plato Ebatlarını Doğru Giriniz (Örn; 5 5)");
                    Console.ReadLine();
                    goto plato;
                }


                if (platoSizes.Count != 2)
                {
                    Console.Write("Plato Ebatlarını Doğru Giriniz (Örn; 5 5)");
                    Console.ReadLine();
                    goto plato;
                }

                List<RoverInfo> roverList = new List<RoverInfo>();
                for (int i = 1; i <= roverCount; i++)
                {
                    RoverInfo roverInfo = new RoverInfo() { RoverId = i };

                    try
                    {
                        Console.Write($"{i}. Gezici Kordinatlarını Girin : ");
                        var roverPositions = Console.ReadLine().Trim().Split(' ');

                        if (roverPositions.Length == 3)
                        {
                            roverInfo.X = Convert.ToInt16(roverPositions[0]);
                            roverInfo.Y = Convert.ToInt16(roverPositions[1]);
                            roverInfo.Direction = (Directions)Enum.Parse(typeof(Directions), roverPositions[2]);

                            Console.Write($"{i}. Gezici Talimatlarını Girin : ");
                            roverInfo.RoverMoves = Console.ReadLine().ToString().ToUpper();
                        }
                        else
                        {
                            roverInfo.ErrorMessage = $"{i}. Gezici eksik/fazla pozisyon bilgisi : {roverPositions}";
                            roverInfo.Success = false;
                        }
                    }
                    catch
                    {
                        roverInfo.ErrorMessage = $"{i}. Gezici hatalı pozisyon bilgisi";
                        roverInfo.Success = false;
                    }

                    roverList.Add(roverInfo);
                }

                Console.WriteLine(""); Console.WriteLine("<<<<<<< >>>>>>>"); Console.WriteLine("");

                foreach (var rover in roverList)
                {
                    if (rover.Success)
                    {
                        rover.RoverMovingStart(platoSizes);
                        if(rover.Success)
                            Console.WriteLine($"{rover.RoverMovesOut} {(rover.ErrorMessage.Length > 0 ? $" --> {rover.ErrorMessage}" : "")}");
                        else Console.WriteLine(rover.ErrorMessage);
                    }
                    else Console.WriteLine(rover.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
