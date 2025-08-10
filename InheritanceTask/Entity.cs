namespace InheritanceTask
{
    public class Entity
    {
        protected string name;
        protected int hp;
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

        public Entity(string newName, int newHP)
        {
            name = newName;
            hp = newHP;
            mapPosition = [0, 0];
        }

        public Entity(string newName, int newHP, int x, int y)
        {
            name = newName;
            hp = newHP;
            mapPosition = [x, y];
        }

        public string GetName() { return name; }

        public int GetHP() { return hp; }
        public void SetHP(int newHP) { hp = newHP; }

        public void TakeDamage(int damage) { hp = Math.Max(0, hp - damage); }

        public int[] GetMapPosition() { return mapPosition; }
        public void SetMapPosition(int x, int y) 
        {
            mapPosition[0] = x;
            mapPosition[1] = y;
        }
        public int GetXPosition() { return mapPosition[0]; }
        public int GetYPosition() { return mapPosition[1]; }

        public int GetOrder() { return order; }
        public void SetOrder(int newOrder) { order = newOrder; }

        public int AttackEntity (Entity target, int damage) 
        {
            if (target == null) return 1;                           // Can't attack nonexisten target
            if (target.GetType() != typeof(Character) &&
                target.GetType() != typeof(Enemy)) return 2;        // Can't attack non-character or non-enemy entities
            if (target == this) return 3;                           // Can't attack self

            target.TakeDamage(damage);
            return 0;
        }
    }
}