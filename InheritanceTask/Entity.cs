namespace InheritanceTask
{
    public abstract class Entity
    {
        public string Name { get; }
        public int HP { get; protected set; }
        public int Order { get; protected set; }
        public int XPosition { get; protected set; }
        public int YPosition { get; protected set; }

        public Entity(string newName, int newHP, int x=0, int y=0)
        {
            Name = newName;
            HP = newHP;
            XPosition = x;
            YPosition = y;
        }

        public abstract void TakeDamage(int damage);    // Implement in subclasses

        public void AttackEntity (Entity target, int damage) 
        {
            if (target.GetType() != typeof(Character) &&
                target.GetType() != typeof(Enemy))
                throw new Exception("Can't attack non-character or non-enemy entities");

            if (target == this) 
                throw new Exception("Can't attack self");

            target.TakeDamage(damage);
        }

        public void MoveBy(int xMove, int yMove) 
        {
            XPosition += xMove;
            YPosition += yMove;
        }
    }
}