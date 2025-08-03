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
            name = "NoName";
            inventory = new Inventory();
        }

        public Character2(string newName) { 
            name = newName;
            inventory = new Inventory();
        }

        public Character2(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt) {
            name = newName;
            hp = newHP;
            endurance = newEnd;
            force = newForce;
            dexterity = newDex;
            intelligence = newInt;
            inventory = new Inventory();
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