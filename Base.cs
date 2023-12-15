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
            
            int hit = Damage(target);
            Console.WriteLine($"You were hit for {hit}");
            target.Hp -= hit;
            return IsDead(target);
        }
        /// <summary>
        /// Calculates damage based on strenght, randomness and speed
        /// </summary>
        /// <param name="target"></param>
        public int Damage(Base target)
        {
            Random random = new Random();
            int damage = this.Strenght + random.Next(-5, 5);

            if (this.Speed >= 2 * target.Speed)
            {
                Console.WriteLine($"You are to slow, and got hit twice!");
                damage = this.Strenght + random.Next(-5, 5);
            }
            return damage;
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
