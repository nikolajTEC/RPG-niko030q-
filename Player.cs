namespace RPG_niko030q_
{
    internal class Player : Base
    {
        List<Equipment> _equipment = new List<Equipment>();
        int _xp;
        int _level;

        public int Xp
        {
            get => _xp;
            //sets the xp, checks if it's over 100, if it is, it starts counting again from 0 and adds 1 to level.
            set
            {
                _xp = value;

                if (_xp >= 100)
                {
                    _level += 1;
                    _xp %= 100;
                }
            }
        }
        internal List<Equipment> Equipment { get => _equipment; set => _equipment = value; }
        public int Level { get => _level; set => _level = value; }
        //empty constructor that can set default values.
        public Player()
        {

            Hp = 100;
            Speed = 5;
            Strenght = 20;
        }
        // a constructor that would be used if to load a saved character
        public Player(string name, int xp, List<Equipment> equipment, int level)
        {
            int equipmentHPBonus = 0;
            int equipmentATKBonus = 0;
            int equipmentWeight = 0;
            foreach (var item in equipment)
            {
                equipmentHPBonus += item.HpBonus;
                equipmentATKBonus += item.StrenghtBonus;
                equipmentWeight += item.Weight;
            }
            Hp = 100 + equipmentHPBonus + level * 2;

            Strenght = 20 + equipmentATKBonus + level;
            Xp = xp;
            Equipment = equipment;
            Name = name;
            Level = level;
            Speed = 5 - equipmentWeight + level;
        }

        public Player(string name)
        {
            Name = name;
        }

        public override AttackResult Attack(Base target)
        {
            Console.WriteLine("choose your attack:\n1: stab\n2: Fireball\n3: Punch");

            int choice;
            bool parse = int.TryParse(Console.ReadLine(), out choice);
            if (parse)
            {
                Console.WriteLine($"You chose {(TypeOfAttackEnum)choice}");
            }
            int hit = Damage(target);
            Console.WriteLine($"You did {hit} damage!");
            target.Hp -= hit;
            return IsDead(target);
        }
        public override string ToString()
        {
            string equipmentToString = string.Join(", \n", _equipment);
            return $"Name: {Name} | HP: {Hp} | Strenght: {Strenght} | XP: {Xp} | Level: {Level} | Speed: {Speed} | \nEquipment:\n{equipmentToString} ";
        }
        //resets hp, and re calculates variable values.
        public void ResetPlayer()
        {
            int equipmentHPBonus = 0;
            int equipmentATKBonus = 0;
            int equipmentWeight = 0;
            foreach (var item in Equipment)
            {
                equipmentHPBonus += item.HpBonus;
                equipmentATKBonus += item.StrenghtBonus;
                equipmentWeight += item.Weight;
            }
            Hp = 100 + equipmentHPBonus + Level * 2;
            Strenght = 20 + equipmentATKBonus + Level;
            Speed = 5 - equipmentWeight + Level;
        }
    }
}
