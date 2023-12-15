namespace RPG_niko030q_
{
    internal abstract class Base
    {
        string _name;
        int _hp;
        int _strenght;
        int _speed;

        public int Hp { get => _hp; set => _hp = value; }
        public int Strenght { get => _strenght; set => _strenght = value; }
        public string Name { get => _name; set => _name = value; }
        public int Speed { get => _speed; set => _speed = value; }

        public virtual AttackResult Attack(Base target)
        {
            //calculates damage based on speed and strenght, and adds an element of randomness
            Random random = new Random();
            target.Hp = target.Hp - this.Strenght + random.Next(-5, 5);

            if (this.Speed >= 2 * target.Speed)
            {
                Console.WriteLine($"You are to slow, and got hit twice!");
                target.Hp = target.Hp - this.Strenght + random.Next(-5, 5);
            }
            return IsDead(target);
        }
        //checks if either target died.
        public AttackResult IsDead(Base target)
        {
            if (target.Hp < 1)
            {
                if (target is Player)
                {
                    return AttackResult.PlayerDied;
                }
                if (target is NPC)
                {
                    return AttackResult.NPCKilled;
                }
            }
            return AttackResult.Continue;
        }
    }
}
