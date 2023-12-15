namespace RPG_niko030q_
{
    internal class NPC : Base
    {
        TypeOfNPCEnum type;

        internal TypeOfNPCEnum Type { get => type; set => type = value; }
        public NPC()
        {
            //sets default values
            Hp = 100;
            Strenght = 5;
            Speed = 5;
            Array values = Enum.GetValues(typeof(TypeOfNPCEnum));
            Random random = new Random();
            //sets a random type
            Type = (TypeOfNPCEnum)values.GetValue(random.Next(values.Length));
            AdjustForNpcType();

        }
        /// <summary>
        /// sets attributes depending on the type of npc
        /// </summary>
        private void AdjustForNpcType()
        {
            switch (Type)
            {
                case TypeOfNPCEnum.Human:
                    Hp += 10;
                    Strenght += 2;
                    break;

                case TypeOfNPCEnum.Orc:
                    Hp += 30;
                    Strenght += 4;
                    Speed -= 5;
                    break;

                case TypeOfNPCEnum.Elf:
                    Hp += 5;
                    Strenght += 1;
                    Speed += 10;
                    break;

                case TypeOfNPCEnum.Viking:
                    Hp += 5;
                    Strenght += 5;
                    Speed += 5;
                    break;

                default:

                    break;
            }
        }
    }
}
