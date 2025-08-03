namespace ClassDesignTask
{
    public class Character {
        protected string name;
        protected int hp;
        protected int endurance;
        protected int force;
        protected int dexterity;
        protected int intelligence;
        protected Inventory inventory;

        public Character() {
            name = "NoName";
            inventory = new Inventory();
        }

        public Character(string newName) { 
            name = newName;
            inventory = new Inventory();
        }

        public string getName() { return name; }

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


    // Knight subclass
    public class Knight : Character {
        private int attackRadius;
        
        private void setBaseStats() {
            hp = 16;
            endurance = 15;
            force = 17;
            dexterity = 10;
            intelligence = 8;
        }
        
        public Knight() : base() {
            setBaseStats();
            attackRadius = 5;
        }

        public Knight(int rad) : base() {
            setBaseStats();
            attackRadius = rad;
        }
    }


    // Hunter subclass
    public class Hunter : Character {
        private int arrows;

        private void setBaseStats() { 
            hp = 13;
            endurance = 12;
            force = 11;
            dexterity = 17;
            intelligence = 10;
        }

        public Hunter() : base() {
            setBaseStats();
            arrows = 20;
        }

        public Hunter(int num) : base() {
            setBaseStats();
            arrows = num;
        }
        public Hunter(string newName, int num) : base(newName){
            setBaseStats();
            arrows = num;
        }
    }


    // Mage subclass
    public class Mage : Character {
        private int maxMana;
        private int currMana;

        private void setBaseStats() { 
            hp = 13;
            endurance = 12;
            force = 11;
            dexterity = 17;
            intelligence = 10;
        }

        public Mage() : base() {
            setBaseStats();
            maxMana = 10;
            currMana = maxMana;
        }

        public Mage(int num) : base() { 
            setBaseStats();
            maxMana = num;
            currMana = maxMana;
        }
        public Mage(string newName, int num) : base(newName) {
            setBaseStats();
            maxMana = num;
            currMana = maxMana;
        }
    }
}