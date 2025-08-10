namespace InheritanceTask
{
    public class Entity
    {
        protected string name;
        protected int hp;
        protected int force;
        protected int order;
        protected int[] mapPosition;
        
        public Entity()
        {
            name = "NoName";
            mapPosition = [0, 0];
        }

        public Entity(string newName)
        {
            name = newName;
            mapPosition = [0, 0];
        }

        public Entity(string newName, int newHP, int newForce)
        {
            name = newName;
            hp = newHP;
            force = newForce;
            mapPosition = [0, 0];
        }

        public Entity(string newName, int newHP, int newForce, int x, int y)
        {
            name = newName;
            hp = newHP;
            force = newForce;
            mapPosition = [x, y];
        }

        public string GetName() { return name; }

        public int GetHP() { return hp; }
        public void SetHP(int newHP) { hp = newHP; }

        public int GetForce() { return force; }
        public void SetForce(int newForce) { force = newForce; }

        public void TakeDamage(int damage) { hp = Math.Max(0, hp - damage); }

        public int[] GetMapPosition() { return mapPosition; }
        public void SetMapPosition(int x, int y) 
        {
            mapPosition[0] = x;
            mapPosition[1] = y;
        }

        public int GetOrder() { return order; }
        public void SetOrder(int newOrder) { order = newOrder; }

        public int AttackEntity (Entity target) 
        {
            if (target == null) return 1;                           // Can't attack nonexisten target
            if (target.GetType() != typeof(Character)) return 2;    // Can't attack non-character or non-enemy entities
            if (target == this) return 3;                           // Can't attack self

            target.TakeDamage(force);
            return 0;
        }
    }
}