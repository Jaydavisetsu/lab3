using System.Security.Authentication.ExtendedProtection;

namespace Lab_3_Jayden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            var dbPath = root + $"{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}data.db";
            var filePath = root + Path.DirectorySeparatorChar + "AllPokemon.csv";
            var filePathBan = root + Path.DirectorySeparatorChar + "BannedGames.csv";


            using (var q = new QueryBuilder(dbPath))
            {
                List<Pokemon> pokemons = new List<Pokemon>();
                List<BannedGame> bans = new List<BannedGame>();
                int pkCounter = 0;
                int bgCounter = 0;

                try
                {
                    using (var read = new StreamReader(filePath))
                    {
                        read.ReadLine();

                        while (!read.EndOfStream)
                        {
                            string? line = read.ReadLine();
                            string[] fields = line.Split(",");

                            Pokemon p = new Pokemon()
                            {
                                Id = pkCounter,
                                DexNumber = Int32.Parse(fields[0].Trim()),
                                Name = fields[1].Trim(),
                                Form = fields[2].Trim(),
                                Type1 = fields[3].Trim(),
                                Type2 = fields[4].Trim(),
                                Total = Int32.Parse(fields[5].Trim()),
                                HP = Int32.Parse(fields[6].Trim()),
                                Attack = Int32.Parse(fields[7].Trim()),
                                Defense = Int32.Parse(fields[8].Trim()),
                                SpecialAttack = Int32.Parse(fields[9].Trim()),
                                SpecialDefense = Int32.Parse(fields[10].Trim()),
                                Speed = Int32.Parse(fields[11].Trim()),
                                Generation = Int32.Parse(fields[12].Trim())
                            };
                            pokemons.Add(p);
                            pkCounter++;
                        }
                    }
                    Console.WriteLine("Success!");
                }
                catch ( Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    using (var reader = new StreamReader(filePathBan))
                    {
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            string? line = reader.ReadLine();
                            string[] fields = line.Split(",");

                            BannedGame b = new BannedGame()
                            {
                                Id = bgCounter,
                                Title = fields[0].Trim(),
                                Series = fields[1].Trim(),
                                Country = fields[2].Trim(),
                                Details = fields[3].Trim(),
                            };

                            bans.Add(b);
                            bgCounter++;
                        }
                    }
                    Console.WriteLine("Success!");
                }
                catch ( Exception ex )
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    q.DeleteAll<Pokemon>();
                    q.DeleteAll<BannedGame>();
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                try
                {
                    
                    foreach (var pokemon in pokemons)
                    {
                        q.Create(pokemon);
                    }
                    Pokemon poke = new Pokemon(1111, 1111, "Test", "Test", "Test", "Test", 0, 0, 0, 0, 0, 0, 0, 0);
                    q.Create(poke);

                    foreach (var b in bans)
                    {
                        q.Create(b);
                    }
                    Console.WriteLine("Success!");
                    BannedGame bGame = new BannedGame(137, "Fake", "Terrible", "Mumbai", "DogShit");
                    q.Create(bGame);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                try
                {
                    var readPoke = q.ReadAll<Pokemon>();
                    var readBans = q.ReadAll<BannedGame>();
                    Console.WriteLine(readPoke);
                    Console.WriteLine(readBans);
                    Console.WriteLine("Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}