using System;

namespace Project3_Algorithms
{
    class Program
    {
        public static int[,] PriorityQueue = new int[8, 2] {
                {4,3},
                {5,8},
                {2,4},
                {4,5},
                {2,0},
                {4,1},
                {1,2},
                {0,0 } };
        public static string[] JobDescription = new string[8] 
                {"EEE", 
                 "GGG",
                 "CCC", 
                 "DDD",
                 "BBB",
                 "FFF",
                 "AAA",
                ""};
        static void Main(string[] args)
        {
            int EntryPoint = 6;
            Addition(EntryPoint,1,"WAK");
            EntryPoint = Remove(EntryPoint);
            Addition(EntryPoint, 2, "AAA");
            EntryPoint = Remove(EntryPoint);
            Addition(EntryPoint, 3, "LAP");
            for (int i=0;i!=PriorityQueue.Length/2;i++)
            {
                Console.WriteLine(i + ") " + JobDescription[i] + " - " + PriorityQueue[i, 0] + " - " + PriorityQueue[i, 1]);
            }
            Console.WriteLine(EntryPoint);
            Console.ReadLine();
        }
        static int Traverse(int EntryPoint,int ValueToFind)
        {
            int Next = EntryPoint;
            while(Next!=(PriorityQueue.Length/2))
            {
                if (ValueToFind<=PriorityQueue[Next,1])
                {
                   
                    if (ValueToFind >= PriorityQueue[PriorityQueue[Next, 1], 0])
                    {
                        Next = PriorityQueue[Next, 1];
                    }
                    else if (ValueToFind < PriorityQueue[PriorityQueue[Next, 1], 0])
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }

            }
            return Next;
        }
        static int Addition(int EntryPoint, int ValueToAdd,string DescriptionToAdd)
        {
            int InsertPoint = 0;
            bool IsFull = true;
            int TempPoint = EntryPoint;
            for(int i=0;i!= PriorityQueue.Length / 2;i++)
            {
                if(PriorityQueue[i,0]==0)
                {
                    InsertPoint = i;
                    IsFull = false;
                }    
            }
            if (!IsFull)
            {
                TempPoint = Traverse(EntryPoint, ValueToAdd);
                PriorityQueue[InsertPoint, 1] = PriorityQueue[TempPoint, 1];
                PriorityQueue[TempPoint, 1] = InsertPoint;
                PriorityQueue[InsertPoint, 0] = ValueToAdd;
                JobDescription[InsertPoint] = DescriptionToAdd;
            }
            else
            {
                Console.WriteLine("The Queue is full");
            }
            return EntryPoint;
        }
        static int Remove(int EntryPoint)
        {
            int TempEntry = EntryPoint;
            EntryPoint = PriorityQueue[EntryPoint, 1];
            PriorityQueue[TempEntry, 0] = 0;
            PriorityQueue[TempEntry, 1] = 0;
            JobDescription[TempEntry] = "";
            return EntryPoint;
        }
    }
}
