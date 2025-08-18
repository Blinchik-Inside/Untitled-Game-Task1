namespace InheritanceTask
{
    internal class GameStatus
    {
        private readonly List<Entity> entities;

        public GameStatus() 
        {
            entities = [];
        } 

        public void AddEntity(Entity entity) 
        { 
            entities.Add(entity);
        }

        public void RemoveEntity(Entity entity) 
        { 
            entities.Remove(entity);
        }

        public bool EnemiesWin() 
        {
            foreach (Entity entity in entities)
            {
                // If at least one Character object is still on the board, Enemies don't win yet
                if (entity.GetType() == typeof(Character)) return false;
            }
            return true;
        }

        public bool CharactersWin()
        {
            foreach (Entity entity in entities)
            {
                // If at least one Enemy object is still on the board, Characters don't win yet
                if (entity.GetType() == typeof(Enemy)) return false;
            }
            return true;
        }

        public static int GetDistanceFrom(Entity target, int Xsource, int Ysource)
        {
            int xDistance = Math.Abs(Xsource - target.XPosition);
            int yDistance = Math.Abs(Ysource - target.YPosition);
            return (int)Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }

        public Entity GetClosestTargetFrom(Entity source)
        {
            Entity? closest = null;
            foreach (Entity entity in entities)
            {
                int minDistance = int.MaxValue;
                if (entity == source) continue;

                // Only consider Enemy class as potential target for Characters
                // Only consider Character class as potential target for Enemies
                if ((source.GetType() != typeof(Character) && entity.GetType() != typeof(Enemy)) ||
                    (source.GetType() != typeof(Enemy) && entity.GetType() != typeof(Character)))
                    continue;

                int currDistance = GetDistanceFrom(entity, source.XPosition, source.YPosition);
                if (currDistance < minDistance)
                {
                    minDistance = currDistance;
                    closest = entity;
                }
            }

            if (closest == null) throw new Exception("No valid targets found");
            return closest;
        }

        public void AttackAllInArea(int x, int y, int radius, int damage) 
        {
            foreach (Entity entity in entities) 
            {
                if (GetDistanceFrom(entity, x, y) > radius) continue;
                entity.TakeDamage(damage);
            }
        }
    }
}
