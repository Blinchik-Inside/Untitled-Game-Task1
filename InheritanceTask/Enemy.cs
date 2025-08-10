using System.Runtime.CompilerServices;

namespace InheritanceTask
{
    public class Enemy : Entity
    {
        protected int damage;

        public Enemy() : base() { }

        public Enemy(string newName) : base(newName) { }
        public Enemy(string newName, int newHP, int newDamage)
                  : base(newName, newHP)
        {
            damage = newDamage;
        }

        public int GetDamage() { return damage; }
        public void SetDamage(int newDamage) { damage = newDamage; }

        public Entity? GetClosestTarget(Entity[] entities) 
        {
            Entity? target = null;
            foreach (Entity entity in entities) 
            {
                int minDistance = int.MaxValue;
                if (entity == this) continue;
                if (entity.GetType() != typeof(Enemy)) continue;

                int currDistance = GetDistanceFrom(entity);
                if (currDistance < minDistance)
                { 
                    minDistance = currDistance;
                    target = entity;
                }
            }
            return target;
        }
    }


    public class Orc : Enemy 
    {
        private int _attackRadius;

        public Orc() : base()
        {
            _attackRadius = 2;
        }

        public Orc(string newName) : base(newName)
        {
            _attackRadius = 2;
        }

        public Orc (string newName, int newHP, int newDamage, int newRadius)
             : base(newName, newHP, newDamage)
        {
            _attackRadius = newRadius;
        }

        public int GetAttackRadius() { return _attackRadius; }
        public void SetAttackRadius(int newRadius) { _attackRadius = newRadius; }


        public int PowerAttack(Entity[] entities) 
        { 
            Entity? target = GetClosestTarget(entities);
            if (target == null) return 1;               // No valid target available, all Characters are eliminated
            int distance = GetDistanceFrom(target);
            if (distance > _attackRadius) return 2;     // The closest valid target is too far, need to shorten distance

            target.TakeDamage(damage);
            return 0;                                   // Successfully attacked
        }
    }


    public class Goblin : Enemy
    {
        private int _crowdSize;
        private int _currentHP;

        public Goblin() : base()
        {
            _crowdSize = 3;
        }

        public Goblin(string newName) : base(newName)
        {
            _crowdSize = 3;
        }

        public Goblin(string newName, int newHP, int newDamage, int newCrowdSize)
             : base(newName, newHP, newDamage)
        {
            _crowdSize = newCrowdSize;
            _currentHP = newHP;
        }

        public int GetCrowdSize() { return _crowdSize; }
        public void SetCrowdSize(int newCrowdSize) { _crowdSize = newCrowdSize; }

        public override int TakeDamage(int damage) 
        {
            _currentHP -= damage;
            if (_currentHP <= 0) 
            {
                _currentHP = hp;
                _crowdSize -= 1;
            }
            return _currentHP;
        }

        public int TakeAreaDamage(int damage)   // All goblins in the group take the same damage, affecting their "max"
        {
            if (damage >= hp) return 0;         // 0 goblins remained alive
            hp -= damage;
            _currentHP -= damage;
            
            return _crowdSize;                  // All stayed alive, but "max" hp reduced
        }

        public int CrowdAttack(Entity target) 
        { 
            int crowdDamage = damage * _crowdSize;
            return AttackEntity(target, crowdDamage);
        }
    }


    public class Skeleton : Enemy
    {
        private int _safeDistance;
        private int _maxDistance;

        public Skeleton() : base()
        {
            _safeDistance = 10;
            _maxDistance = 25;
        }

        public Skeleton(string newName) : base(newName)
        {
            _safeDistance = 10;
            _maxDistance = 25;
        }

        public Skeleton(string newName, int newHP, int newDamage, int newSafeDistance, int newMaxDistance)
             : base(newName, newHP, newDamage)
        {
            _safeDistance = newSafeDistance;
            _maxDistance = newMaxDistance;
        }

        public int GetSafeDistance() { return _safeDistance; }
        public void SetSafeDistance(int newSafeDistance) { _safeDistance = newSafeDistance; }

        public int GetMaxDistance() { return _maxDistance; }
        public void SetMaxDistance(int newMaxDistance) { _maxDistance = newMaxDistance; }

        public int DistanceAttack(Entity target) 
        {
            if (target == null) return 1;                       // Target doesn't exist
            int targetDistance = GetDistanceFrom(target);

            if (targetDistance < _safeDistance) return 2;       // Skeleton needs to walk away before shooting
            if (targetDistance > _maxDistance) return 3;        // Target too far, damage won't be dealt 

            target.TakeDamage(damage);
            return 0;
        }
    }
}