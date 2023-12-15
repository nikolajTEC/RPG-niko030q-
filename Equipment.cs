namespace RPG_niko030q_
{
    internal class Equipment
    {
        int _weight;
        int _hpBonus;
        int _attackBonus;
        string _name;

        public Equipment()
        {
        }

        public Equipment(string name, int weight, int hpBonus, int attackBonus)
        {
            Name = name;
            Weight = weight;
            HpBonus = hpBonus;
            StrenghtBonus = attackBonus;
        }

        public int Weight { get => _weight; set => _weight = value; }
        public int HpBonus { get => _hpBonus; set => _hpBonus = value; }
        public int StrenghtBonus { get => _attackBonus; set => _attackBonus = value; }
        public string Name { get => _name; set => _name = value; }
        //list of equipment and their values
        public static List<Equipment> GetDefaultEquipment()
        {
            List<Equipment> defaultEquipment = new List<Equipment>
        {
            new Equipment("Sword of Power", 3, 2, 4),
            new Equipment("Leather Armor", 1, 0, 3),
            new Equipment("Healing Amulet", 5, 5, 1),
            new Equipment("Wooden Shield", 2, 3, 0)
        };

            return defaultEquipment;
        }
        /// <summary>
        /// Generates a random number from the lenght of the list, then returns the object connected to the number.
        /// </summary>
        public void GetRandomEquipment()
        {
            List<Equipment> equipmentList = GetDefaultEquipment();
            Random random = new Random();
            int randomIndex = random.Next(0, equipmentList.Count);
            Equipment randomEquipment = equipmentList[randomIndex];
            this.Name = randomEquipment.Name;
            this.Weight = randomEquipment.Weight;
            this.HpBonus = randomEquipment.HpBonus;
            this.StrenghtBonus = randomEquipment.StrenghtBonus;

        }
        public override string ToString()
        {
            return $"Name: {Name} | HPbonus: {HpBonus} | Strenght: {StrenghtBonus} | Weight: {Weight}";
        }
    }

}
