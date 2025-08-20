namespace ClassDesignTask
{
    public abstract class Character
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public int Endurance { get; protected set; }
        public int Force { get; protected set; }
        public int Dexterity { get; protected set; }
        public int Intelligence {  get; protected set; }
        
        public Inventory Storage { get;}

        protected Character(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt) 
        {
            Name = newName;
            HP = newHP;
            Endurance = newEnd;
            Force = newForce;
            Dexterity = newDex;
            Intelligence = newInt;
            Storage = new Inventory();
        }
    }


    // Knight subclass
    public class Knight : Character
    {
        public int AttackRadius { get; protected set; }

        public Knight(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int newRadius) :
              base(newName, newHP, newEnd, newForce, newDex, newInt) 
        { 
            AttackRadius = newRadius;
        }

        public bool Attack(int distance)
        {
            if (distance <= AttackRadius) return true;
            return false;
        }
    }


    // Hunter subclass
    public class Hunter : Character
    {
        public int NumberOfArrows { get; protected set; }

        public Hunter(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int newNumberOfArrows) :
                base(newName, newHP, newEnd, newForce, newDex, newInt)
        {
            NumberOfArrows = newNumberOfArrows;
        }
    }


    // Mage subclass
    public class Mage : Character 
    {
        // Just for now, otherwise would be its separate class storing spell cost and damage
        public enum Spell 
        { 
            Fireball,
            IceShock
        }

        public int MaxMana { get; protected set; }
        public int CurrMana { get; protected set; }

        public Mage(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int mana) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            MaxMana = mana;
            CurrMana = MaxMana;
        }

        public bool Cast(Spell spell) 
        {
            // Some logic in determening if the spell can be cast, returning if it can be cast 
            return false;
        }

        public void RestoreMana(int value)
        {
            CurrMana = Math.Clamp(CurrMana + value, min: 0, MaxMana);
        }
    }
}