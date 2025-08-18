namespace InheritanceTask
{
    public abstract class Character : Entity
    {
        public int Endurance { get; protected set; }
        public int Force { get; protected set; }
        public int Dexterity { get; protected set; }
        public int Intelligence { get; protected set; }

        public Character(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int x=0, int y=0) 
                  : base(newName, newHP, x, y)
        {
            Endurance = newEnd;
            Force = newForce;
            Dexterity = newDex;
            Intelligence = newInt;
        }

        public override void TakeDamage(int damage) 
        {
            HP = Math.Min(HP - damage, 0);
        }
    }


    // Knight subclass
    public class Knight : Character 
    {
        public int AttackRadius { get; protected set; }
        
        public Knight(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int rad) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            AttackRadius = rad;
        }
    }


    // Hunter subclass
    public class Hunter : Character 
    {
        public int NumberOfArrows { get; protected set; }

        public Hunter(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int newNumberOfArrows=10, int x=0, int y=0) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt, x, y) 
        {
            NumberOfArrows = newNumberOfArrows;
        }

        public void ShootOneArrow() 
        { 
            NumberOfArrows--;
        }
    }


    // Mage subclass
    public class Mage : Character 
    {
        public int MaxMana { get; protected set; }
        public int CurrMana { get; protected set; }

        public Mage(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int newMana=10, int x=0, int y=0) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt, x, y) 
        {
            MaxMana = newMana;
            CurrMana = newMana;
        }

        public bool CanCastFireball()
        {
            if (3 > CurrMana)
                return false;
            // Let the cost for fireball be 3 for now
            CurrMana -= 3;
            return true;
        }

        public void RestoreMana(int value)
        {
            CurrMana = Math.Clamp(CurrMana + value, min: 0, MaxMana);
        }
    }
}