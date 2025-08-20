using System.Runtime.CompilerServices;

namespace InheritanceTask
{
    public abstract class Enemy : Entity
    {
        public int Damage { get; protected set; }

        public Enemy(string newName, int newHP, int newDamage, int x = 0, int y=0)
                  : base(newName, newHP, x, y)
        {
            Damage = newDamage;
        }

        public override void TakeDamage(int damage)
        {
            HP = Math.Min(HP - damage, 0);
        }
    }


    public class Orc : Enemy 
    {
        public int AttackRadius { get; protected set; }

        public Orc(string newName, int newHP, int newDamage, int newRadius, int x=0, int y=0)
             : base(newName, newHP, newDamage, x, y)
        {
            AttackRadius = newRadius;
        }

        public void PowerAttack() 
        { 
            // Some logic to get the closest target, etc
        }
    }


    public class Goblin : Enemy
    {
        public int CrowdSize { get; protected set; }
        public int CurrentHP {  get; protected set; }   // Only one goblin from the crowd is attacked at a time
                                                        // Or all will be attacked when in area damage

        public Goblin(string newName, int newHP, int newDamage, int newCrowdSize, int x=0, int y=0)
             : base(newName, newHP, newDamage, x, y)
        {
            CrowdSize = newCrowdSize;
            CurrentHP = newHP;
        }

        public override void TakeDamage(int damage) 
        {
            CurrentHP -= damage;
            if (CurrentHP <= 0) 
            {
                CurrentHP = HP;
                CrowdSize -= 1;
            }
        }

        public void CrowdAttack(Entity target) 
        {
            if (target == null) throw new NullReferenceException(nameof(target));

            int crowdDamage = Damage * CrowdSize;
            AttackEntity(target, crowdDamage);
        }
    }


    public class Skeleton : Enemy
    {
        public int MinDistance { get; protected set; }
        public int MaxDistance { get; protected set; }

        public Skeleton(string newName, int newHP, int newDamage, int newMinDistance, int newMaxDistance, int x=0, int y=0)
             : base(newName, newHP, newDamage, x, y)
        {
            MinDistance = newMinDistance;
            MaxDistance = newMaxDistance;
        }

        public void DistanceAttack(Entity target) 
        {
            if (target == null) throw new NullReferenceException(nameof(target));

            double damageModifier = 1.0;
            int distance = GameStatus.GetDistanceFrom(target, this.XPosition, this.YPosition);

            // Skeletons shoot arrows
            // If distance from the target too small or too far, reduce the damage
            if (distance < MinDistance)
                damageModifier = (double) distance / MinDistance;
            if (distance > MaxDistance)
                damageModifier = (double) MaxDistance / distance;

            target.TakeDamage((int) (Damage * damageModifier));
        }
    }
}