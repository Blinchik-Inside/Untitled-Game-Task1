using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

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


    public class Knight : Character 
    {
        public int AttackRadius { get; protected set; }
        
        public Knight(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int rad) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            AttackRadius = rad;
        }
    }


    public class Hunter : Character 
    {
        public int NumberOfArrows { get; protected set; }
        public int MinDistance { get; protected set; }
        public int MaxDistance { get; protected set; }

        public Hunter(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt,
                        int newNumberOfArrows, int newMinDistance, int newMaxDistance, int x=0, int y=0) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt, x, y) 
        {
            NumberOfArrows = newNumberOfArrows;
            MinDistance = newMinDistance;
            MaxDistance = newMaxDistance;
        }

        public void DistanceAttack(Entity target) 
        {
            double damageModifier = 1.0;
            int distance = GameStatus.GetDistanceFrom(target, this.XPosition, this.YPosition);

            // If distance from the target too small or too far, reduce the damage
            if (distance < MinDistance)
                damageModifier = (double)distance / MinDistance;
            if (distance > MaxDistance)
                damageModifier = (double)MaxDistance / distance;

            target.TakeDamage((int)(Force * damageModifier)); 
            NumberOfArrows--;
        }
    }


    public class Mage : Character 
    {
        public enum Spell 
        { 
            Fireball, 
            IceShock
        }

        public int MaxMana { get; protected set; }
        public int CurrMana { get; protected set; }

        public Mage(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int newMana, int x=0, int y=0) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt, x, y) 
        {
            MaxMana = newMana;
            CurrMana = newMana;
        }

        public bool Cast(Spell spell)
        {
            // Some casting logic
            return false;
        }

        public void RestoreMana(int value)
        {
            CurrMana = Math.Clamp(CurrMana + value, min: 0, MaxMana);
        }
    }
}