namespace ClassDesignTask
{
    public class Character2 {
        public static readonly int KNIGHT_ID = 1;
        public static readonly int HUNTER_ID = 2;
        public static readonly int MAGE_ID   = 3;

        // All classes parameters
        private string name;
        private int classID;
        private int hp;
        private int endurance;
        private int force;
        private int dexterity;
        private int intelligence;
        private Inventory inventory;

        // Class specific parameters
        private int attackRadius;   // Knight specific
        private int arrows;         // Hunter cpecific
        private int maxMana;        // Mage specific
        private int currMana;

        public Character2() {
            this.name = "NoName";
            setStats(KNIGHT_ID, 16, 15, 17, 10, 8);     // Knight by defailt
            inventory = new Inventory();
        }

        public Character2(string newName) { 
            name = newName;
            setStats(KNIGHT_ID, 16, 15, 17, 10, 8);     // Knight by default
            inventory = new Inventory();
        }

        public Character2(string newName, int classID) {
            name = newName;
            if (classID == KNIGHT_ID) setStats(KNIGHT_ID, 16, 15, 17, 10, 8);
            if (classID == HUNTER_ID) setStats(HUNTER_ID, 13, 12, 11, 17, 10);
            if (classID == MAGE_ID)   setStats(HUNTER_ID, 10, 10, 8, 12, 18);
            inventory = new Inventory();
        }

        private void setStats(int newClassID, int newHP, int newEnd, int newForce, int newDex, int newInt) {
            classID = newClassID;
            hp = newHP;
            endurance = newEnd;
            force = newForce;
            dexterity = newDex;
            intelligence = newInt;
        }

        public string getName() { return name; }
        public int getClassID() { return classID; }

        public int getHP() { return hp; }
        public void setHP(int newHP) { hp = newHP; }

        public int getEndurance() { return endurance; }
        public void setEndurance(int newEnd) { endurance = newEnd; }

        public int getForce() { return force; }
        public void setForce(int newForce) { force = newForce; }

        public int getDexterity() { return dexterity; }
        public void setDexterity(int newDex) { dexterity = newDex; }

        public int getIntelligence() { return intelligence; }
        public void setIntelligence(int newInt) { intelligence = newInt; }

        public Inventory getInventory() { return inventory; }
    }
}