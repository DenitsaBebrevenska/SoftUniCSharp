namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainer> trainers = new();
            PopulateTrainersList(trainers);
            PlayTournament(trainers);
            
            foreach (var trainer in trainers.OrderByDescending(trainer => trainer.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        static void PopulateTrainersList(List<Trainer> trainers)
        {
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] entryDetails = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = entryDetails[0];
                string pokemonName = entryDetails[1];
                string pokemonElement = entryDetails[2];
                int pokemonHealth = int.Parse(entryDetails[3]);
                Trainer currentTrainer = trainers.FirstOrDefault(trainer => trainer.Name == trainerName);

                if (currentTrainer == null)
                { 
                    trainers.Add(currentTrainer =new Trainer(trainerName));
                }

                int indexTrainer = trainers.IndexOf(currentTrainer);
                trainers[indexTrainer].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }
        }

        static void PlayTournament(List<Trainer> trainers)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(pokemon => pokemon.Element == command))
                    {
                        trainer.Badges++;
                        continue;
                    }

                    trainer.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
                    trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                }
            }
        }
    }
}
