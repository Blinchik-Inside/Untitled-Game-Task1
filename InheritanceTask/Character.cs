namespace InheritanceTask
{
    public class Character : Entity
    {
        protected int endurance;
        protected int dexterity;
        protected int intelligence;

        public Character() : base() { }

        public Character(string newName) : base(newName) { }

        public Character(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt) 
                  : base(newName, newHP, newForce)
        {
            endurance = newEnd;
            dexterity = newDex;
            intelligence = newInt;
        }

        public int GetEndurance() { return endurance; }
        public void SetEndurance(int newEnd) { endurance = newEnd; }

        public int GetDexterity() { return dexterity; }
        public void SetDexterity(int newDex) { dexterity = newDex; }

        public int GetIntelligence() { return intelligence; }
        public void SetIntelligence(int newInt) { intelligence = newInt; }
    }


    // Knight subclass
    public class Knight : Character 
    {
        private int _attackRadius;
        
        private void SetBaseStats() 
        {
            hp = 16;
            endurance = 15;
            force = 17;
            dexterity = 10;
            intelligence = 8;
        }
        
        public Knight() : base() 
        {
            SetBaseStats();
            _attackRadius = 5;
        }

        public Knight(int rad) : base() 
        {
            SetBaseStats();
            _attackRadius = rad;
        }

        public Knight(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int rad) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            _attackRadius = rad;
        }

        public int GetAttackRadius() {  return _attackRadius; }

        public int Attack(int distance)
        {
            if (distance <= _attackRadius) return 0;
            return 1;
        }

        public void ChangeAttackRadius(int newRadius) 
        {
            _attackRadius = newRadius;
        }
    }


    // Hunter subclass
    public class Hunter : Character 
    {
        private int _arrows;

        private void SetBaseStats() 
        { 
            hp = 13;
            endurance = 12;
            force = 11;
            dexterity = 17;
            intelligence = 10;
        }

        public Hunter() : base() 
        {
            SetBaseStats();
            _arrows = 20;
        }

        public Hunter(int num) : base() 
        {
            SetBaseStats();
            _arrows = num;
        }
        public Hunter(string newName, int num) : base(newName)
        {
            SetBaseStats();
            _arrows = num;
        }

        public Hunter(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int num) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            _arrows = num;
        }

        public int GetNumberOfArrows() { return _arrows; }

        public void ChangeNumberOfArrows(int newValue) { _arrows = newValue; }
    }


    // Mage subclass
    public class Mage : Character 
    {
        private int _maxMana;
        private int _currMana;

        private void SetBaseStats() 
        { 
            hp = 13;
            endurance = 12;
            force = 11;
            dexterity = 17;
            intelligence = 10;
        }

        public Mage() : base() 
        {
            SetBaseStats();
            _maxMana = 10;
            _currMana = _maxMana;
        }

        public Mage(int num) : base() 
        { 
            SetBaseStats();
            _maxMana = num;
            _currMana = _maxMana;
        }
        public Mage(string newName, int num) : base(newName) 
        {
            SetBaseStats();
            _maxMana = num;
            _currMana = _maxMana;
        }

        public Mage(string newName, int newHP, int newEnd, int newForce, int newDex, int newInt, int num) :
                 base(newName, newHP, newEnd, newForce, newDex, newInt) 
        {
            _maxMana = num;
            _currMana = _maxMana;
        }

        /*
         * Returns an int code depending on succes of the operation:
         *  - 0 when spell was cast succesfully and mana was used
         *  - 1 when character doesn't have enough mana
         */
        public int UseMana(int cost) 
        {
            if (cost > _currMana) return 1;
            _currMana -= cost;
            return 0;
        }

        public void RestoreMana(int value)
        {
            _currMana += value;
            _currMana = Math.Min( _currMana, _maxMana);
        }

        public void ChangeMaxMana(int newValue) 
        {
            _maxMana = newValue;
        }
    }
}