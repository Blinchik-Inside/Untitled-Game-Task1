namespace InheritanceTask
{
    internal class GameStatus
    {
        private readonly List<Entity> entities;

        public GameStatus() 
        {
            entities = [];
        } 

        // Add entity to the "board"
        public void AddEntity(Entity entity) 
        {
            if (entity == null) throw new NullReferenceException(nameof(entity));
            entities.Add(entity);
        }

        // Delete entity from the board
        public void RemoveEntity(Entity entity) 
        {
            if (entity == null) throw new NullReferenceException(nameof(entity));
            entities.Remove(entity);
        }

        // Check if enemies win
        public bool EnemiesWin() 
        {
            foreach (Entity entity in entities)
            {
                // If at least one Character object is still on the board, Enemies don't win yet
                if (entity.GetType() == typeof(Character)) return false;
            }
            return true;
        }

        // Check if characters win
        public bool CharactersWin()
        {
            foreach (Entity entity in entities)
            {
                // If at least one Enemy object is still on the board, Characters don't win yet
                if (entity.GetType() == typeof(Enemy)) return false;
            }
            return true;
        }

        // Finds distance between a given point and a target entity 
        // Source is given through coordinates on the map instead of an entity
        public static int GetDistanceFrom(Entity target, int Xsource, int Ysource)
        {
            if (target == null) throw new NullReferenceException(nameof(target));

            int xDistance = Math.Abs(Xsource - target.XPosition);
            int yDistance = Math.Abs(Ysource - target.YPosition);
            return (int)Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }

        // Finds the closest valid to attack entity from the map
        public Entity GetClosestTargetFrom(Entity source)
        {
            if (source == null) throw new NullReferenceException(nameof(source));

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

        // Area attack
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
