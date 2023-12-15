namespace RPG_niko030q_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = CreateNewPlayer();

            bool continueLoop = true;
            while (continueLoop == true)
            {
                player.ResetPlayer();
                //player = new Player(player.Name, player.Xp, player.Equipment, player.Level);
                UserMenu(player);
            }
        }
        /// <summary>
        /// lets the user choose a name, and creates first instance of the player object
        /// </summary>
        /// <returns></returns>
        private static Player CreateNewPlayer()
        {
            Console.WriteLine("Choose your name:");
            string name = Console.ReadLine();
            Player player = new Player(name);
            return player;
        }
        /// <summary>
        /// gives the user first choice of what to do
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private static bool UserMenu(Player player)
        {

            NPC npc = new NPC();
            bool continueFighting = true;
            Console.WriteLine("Would you like to \n1: Fight a new enemy\n2: Inspect your character\n3: Discard gear\n5: Exit game");
            //gets user choice input, and validates it
            int choice;
            bool parse = int.TryParse(Console.ReadLine(), out choice);
            if (!parse || choice > 5)
            {
                Console.WriteLine("invalid input, try AGAIN");
                return true;
            }
            if (choice == 1)
            {
                while (continueFighting)
                {
                    continueFighting = Round(player, npc);
                }
                return true;
            }
            if (choice == 2)
            {
                InspectCharacter(player);
            }
            if (choice == 3)
                DiscardGear(player);
            if (choice == 5)
            {
                return false;
            }
            else return true;
        }
        /// <summary>
        /// displays gear with a numeric value displayed, and gives the user the option to discard one from their list.
        /// </summary>
        /// <param name="player"></param>
        private static void DiscardGear(Player player)
        {
            int counter = 0;
            int choice = 0;
            Console.WriteLine("choose which gear to remove:");
            foreach (Equipment equipment in player.Equipment)
            {
                counter++;
                Console.WriteLine($"{counter}: {equipment}");
            }
            //lavet som en try catch for memes
            try
            {
                choice = int.Parse(Console.ReadLine());

                if (choice <= 0 || choice > player.Equipment.Count)
                {
                    throw new Exception();
                }
            player.Equipment.RemoveAt(choice - 1);
            }
            catch
            {
                Console.WriteLine("Invalid input format, back to menu");
                return;
            }

        }

        private static void InspectCharacter(Player player)
        {
            Console.WriteLine(player);
        }
        /// <summary>
        /// starts the combat round, ends when either player or npc is dead
        /// </summary>
        /// <param name="player"></param>
        /// <param name="npc"></param>
        /// <returns></returns>
        public static bool Round(Player player, NPC npc)
        {
            Console.Clear();
            Console.WriteLine($"You encountered a {npc.Type}");
            Console.WriteLine($"Your health: {player.Hp}\nEnemy Health: {npc.Hp} ");
            //decides who goes first based on their speed
            AttackResult result = default;
            if (player.Speed >= npc.Speed)
            {
                result = player.Attack(npc);
                if (result == AttackResult.Continue)
                {
                    result = npc.Attack(player);
                }
            }
            if (npc.Speed >= player.Speed)
            {
                result = npc.Attack(player);
                if (result == AttackResult.Continue)
                {
                    result = player.Attack(npc);
                }
            }
            //Checks if either entity died, and either continues or gives feedback according to what entity died.
            switch (result)
            {
                case AttackResult.PlayerDied:
                    Console.WriteLine("You died");
                    return false;

                case AttackResult.NPCKilled:
                    Console.Clear();
                    Console.WriteLine("You killed the NPC");
                    Equipment randomEquipment = new();
                    randomEquipment.GetRandomEquipment();

                    Console.WriteLine($"The mob dropped: {randomEquipment.Name}");
                    player.Equipment.Add(randomEquipment);
                    player.Xp += 20;
                    return false;


                case AttackResult.Continue:
                    return true;

                default: return false;
            }
        }
    }
}
