using System;

public class Character {
	private string name;
	private int hp;
	private int endurance;
	private int force;
	private int dexterity;
	private int intelligence;
	private Inventory inventory;

	public Character()	{
		name = "NoName";
		inventory = new Inventory();
	}

    public string getName() { return name; }
    public void setName(string newName) { name = newName; }

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
public class Knight : Character
{
    private int attackRadius;

    public Knight()
    {
        base();

        hp = 16;
        endurance = 15;
        force = 17;
        dexterity = 10;
        intelligence = 8;

        attackRadius = 5;
    }

    public Knight(int rad)
    {
        base();
        attackRadius = rad;
    }
}


// Hunter subclass
public class Hunter : Character
{
    private int arrows;

    public Hunter()
    {
        base();

        hp = 13;
        endurance = 12;
        force = 11;
        dexterity = 17;
        intelligence = 10;

        arrows = 20;
    }

    public Hunter(int num)
    {
        base();
        arrows = num;
    }
}


// Mage subclass
public class Mage: Character
{
    private int maxMana;
    private int currMana;

    public Mage()
    {
        base();

        hp = 13;
        endurance = 12;
        force = 11;
        dexterity = 17;
        intelligence = 10;

        arrows = 20;
    }

    public Mage(int num)
    {
        base();
        arrows = num;
    }
}