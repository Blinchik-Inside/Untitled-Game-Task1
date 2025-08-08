namespace ClassDesignTask
{
    public class Character2 
    {
        public static readonly int KnightID = 1;
        public static readonly int HunterID = 2;
        public static readonly int MageID   = 3;

        // All classes parameters
        private readonly string _name;
        private int _classID;
        private int _hp;
        private int _endurance;
        private int _force;
        private int _dexterity;
        private int _intelligence;
        private readonly Inventory _inventory;

        // Class specific parameters
        private int _attackRadius;   // Knight specific
        private int _arrows;         // Hunter cpecific
        private int _maxMana;        // Mage specific
        private int _currMana;

        public Character2() 
        {
            _name = "NoName";
            SetStats(KnightID, newHP: 16, newEnd: 15, newForce: 17, newDex: 10, newInt: 8);     // Knight by defailt
            _attackRadius = 5;
            _inventory = new Inventory();
        }

        public Character2(string newName) 
        { 
            _name = newName;
            SetStats(KnightID, newHP: 16, newEnd: 15, newForce: 17, newDex: 10, newInt: 8);     // Knight by default
            _attackRadius = 5; 
            _inventory = new Inventory();
        }

        public Character2(string newName, int classID) 
        {
            _name = newName;
            if (classID == KnightID)
            {
                SetStats(KnightID, newHP: 16, newEnd: 15, newForce: 17, newDex: 10, newInt: 8);
                _attackRadius = 5;
            }
            if (classID == HunterID)
            {
                SetStats(HunterID, newHP: 13, newEnd: 12, newForce: 11, newDex: 17, newInt: 10);
                _arrows = 20;
            }
            if (classID == MageID) 
            { 
                SetStats(MageID,   newHP: 10, newEnd: 10, newForce: 8, newDex: 12, newInt: 18); 
                _maxMana = 10;
                _currMana = _maxMana;
            }
            _inventory = new Inventory();
        }

        private void SetStats(int newClassID, int newHP, int newEnd, int newForce, int newDex, int newInt) 
        {
            _classID = newClassID;
            _hp = newHP;
            _endurance = newEnd;
            _force = newForce;
            _dexterity = newDex;
            _intelligence = newInt;
        }

        public string GetName() { return _name; }
        public int GetClassID() { return _classID; }

        public int GetHP() { return _hp; }
        public void SetHP(int newHP) { _hp = newHP; }

        public int GetEndurance() { return _endurance; }
        public void SetEndurance(int newEnd) { _endurance = newEnd; }

        public int GetForce() { return _force; }
        public void SetForce(int newForce) { _force = newForce; }

        public int GetDexterity() { return _dexterity; }
        public void SetDexterity(int newDex) { _dexterity = newDex; }

        public int GetIntelligence() { return _intelligence; }
        public void SetIntelligence(int newInt) { _intelligence = newInt; }

        public Inventory GetInventory() { return _inventory; }

        // Knight specific 
        public int GetAttackRadius() { return _attackRadius; }
        public int Attack(int distance)
        {
            if (distance <= _attackRadius) return 0;
            return 1;
        }
        public void ChangeAttackRadius(int newRadius)
        {
            _attackRadius = newRadius;
        }

        // Hunter specific
        public int GetNumberOfArrows() { return _arrows; }
        public void ChangeNumberOfArrows(int newValue) { _arrows = newValue; }

        // Mage specific
        public int UseMana(int cost)
        {
            if (cost > _currMana) return 1;
            _currMana -= cost;
            return 0;
        }
        public void RestoreMana(int value)
        {
            _currMana += value;
            _currMana = Math.Min(_currMana, _maxMana);
        }
        public void ChangeMaxMana(int newValue)
        {
            _maxMana = newValue;
        }
    }
}