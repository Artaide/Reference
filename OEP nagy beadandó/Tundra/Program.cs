using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using TextFile;

namespace Tundra
{
    internal class Program
    {
        public class NullSpecimensException : Exception { }
        public class ColonyReadException : Exception { }
        public class NullColonyException : Exception { }
        public class NullNumReadException : Exception { }
        static void Main(string[] args)
        {
            /*
             * toString-egeket
             */
            string fname = "input.txt";
            TextFileReader reader = new TextFileReader(fname);

            int? preynum = reader.ReadInt();
            int? prednum = reader.ReadInt();
            if (!(preynum.HasValue && prednum.HasValue))
                throw new NullNumReadException();

            Dictionary<string, int> dic = new Dictionary<string, int>
            {
                { "lemming", 0 },
                { "hare", 0 },
                { "moose", 0 },
                { "owl", 0 },
                { "fox", 0 },
                { "bear", 0 }
            };

            List<Prey> preylist = new List<Prey>();
            List<Predator> predlist = new List<Predator>();
            Prey? inprey = null;
            Predator? inpred = null;

            string nickname;
            char? species;
            int? specimens;

            double initialpredsum = 0;

            for (int i = 0; i < preynum; i++)
            {
                nickname = reader.ReadString();
                species = reader.ReadChar();
                specimens = reader.ReadInt();
                if (specimens.HasValue)
                {
                    switch (species)
                    {
                        case 'l':
                            inprey = new Lemming(nickname, specimens.Value);
                            dic["lemming"] += 1;
                            break;
                        case 'n':
                            inprey = new ArcticHare(nickname, specimens.Value);
                            dic["hare"] += 1;
                            break;
                        case 's':
                            inprey = new Moose(nickname, specimens.Value);
                            dic["moose"] += 1;
                            break;
                        default:
                            throw new ColonyReadException();
                    }
                    if (inprey != null)
                        preylist.Add(inprey);
                    else
                        throw new NullColonyException();
                }
                else throw new NullSpecimensException();
            }
            for (int i = 0; i < prednum; i++)
            {
                nickname = reader.ReadString();
                species = reader.ReadChar();
                specimens = reader.ReadInt();
                if (specimens.HasValue)
                {
                    initialpredsum += specimens.Value;
                    switch (species)
                    {
                        case 'h':
                            inpred = new SnowyOwl(nickname, specimens.Value);
                            dic["owl"] += 1;
                            break;
                        case 's':
                            inpred = new ArcticFox(nickname, specimens.Value);
                            dic["fox"] += 1;
                            break;
                        case 'j':
                            inpred = new PolarBear(nickname, specimens.Value);
                            dic["bear"] += 1;
                            break;
                        default:
                            throw new ColonyReadException();
                    }
                    if (inpred != null)
                        predlist.Add(inpred);
                    else
                        throw new NullColonyException();
                }
                else throw new NullSpecimensException();
            }
            List<string> dicnames = new List<string>();
            foreach (KeyValuePair<string, int> entry in dic)
            {
                if (entry.Value == 0)
                    dicnames.Add(entry.Key);
            }
            foreach (string s in dicnames)
            {
                dic.Remove(s);
                dic.Add(s, -1);
            }


            bool ongoing = true;
            int turn = 0;
            string? userinput = null;
            Random rnd = new Random();
            int randompreyindex;

            Console.WriteLine($"Turn {turn}, colonies' inital states:");
            WriteData(preylist, predlist);

            Console.WriteLine("'x' - next turn");
            while (!UserRead(userinput)) { }

            while (ongoing)
            {
                turn++;
                Console.WriteLine($"Turn {turn}");
                Console.WriteLine("Colonies reproducing...");
                foreach (Prey p in preylist)
                {
                    p.Reproduce(turn);
                }
                foreach (Predator p in predlist)
                {
                    p.Reproduce(turn);
                }
                Console.WriteLine("Colonies after reproduction:\n");
                WriteData(preylist, predlist);
                Console.WriteLine("Predator colonies hunting...");
                foreach (Predator p in predlist)
                {
                    randompreyindex = rnd.Next(preynum.Value);
                    if (!p.Dead)
                        Console.WriteLine($"{p.Nickname} attacking {preylist[randompreyindex].Nickname}");
                    p.Attack(preylist[randompreyindex]);
                }
                Console.WriteLine("Colonies after hunting:\n");
                WriteData(preylist, predlist);

                HandleDeadColony(dic, preylist, predlist);
                if (!AnyPredatorAlive(predlist) || PredatorsDoubled(predlist, initialpredsum))
                    ongoing = false;
                
                Console.WriteLine("'x' - next turn");
                while (!UserRead(userinput)) { }
            }
        }
        public static bool UserRead(string? userinput)
        {
            userinput = Console.ReadLine();
            if (userinput == "x")
                return true;
            return false;
        }
        public static void WriteData(List<Prey> preylist, List<Predator> predlist)
        {
            foreach (Prey p in preylist)
            {
                Console.WriteLine(p);
            }
            foreach (Predator p in predlist)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("\n");
        }
        public static bool AnyPredatorAlive(List<Predator> predlist)
        {
            foreach(Predator p in predlist)
            {
                if (!p.Dead)
                    return true;
            }
            Console.WriteLine("All predator species have died out");
            return false;
        }
        public static bool PredatorsDoubled(List<Predator> predlist, double init)
        {
            double n = 0;
            foreach (Predator p in predlist)
            {
                n += p.Specimens;
            }
            return n > init;
        }
        public static void HandleDeadColony(Dictionary<string, int> dic, List<Prey> preylist, List<Predator> predlist)
        {
            foreach (Prey p in preylist)
            {
                dic.TryGetValue(p.GetDicName(), out int val);
                if (p.Dead && val > 0)
                    dic[p.GetDicName()] -= 1;
            }
            foreach (Predator p in predlist)
            {
                if (p.Dead)
                    dic[p.GetDicName()] -= 1;
            }
            foreach (KeyValuePair<string, int> entry in dic)
            {
                if (entry.Value == 0)
                {
                    Console.WriteLine($"All colonies of species {entry.Key} have died out");
                }
            }
        }
    }
}
