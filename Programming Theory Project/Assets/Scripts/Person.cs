using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Person : MonoBehaviour
{
    public string Name {get; private set;}
    public int Age {get; private set;}
    protected int money = 1000;
    private string nick = "Person";
    public event System.Action<Person> OnSelected;
    public void Initialize(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public int Money
    {
        get { return money; } 
    }
    public string Nick
    {
        get { return nick; }  
        set { nick = value; }  
    }
    public virtual string PerformCleanUp()
    {
        return $"{Name} {Nick} has cleaned the house";
    }
    public virtual bool ReceiveMoney(int amount)
    {
        money += amount;
        return true;
    }
    public virtual string ReasonCannotReceiveMoney()
    {
        return "";
    }
    public virtual string GiveMoney(Person recipient, int amount)
    {
        if (money >= amount)
        {
            if(recipient.ReceiveMoney(amount))
            {
                money -= amount;
                return $"{Name} {Nick} has given {amount}$ to {recipient.Name} {recipient.Nick}";
            }
            return recipient.ReasonCannotReceiveMoney();
        }
        return $"{Name} {Nick} doesn't have enough money";
    }
    void OnMouseDown()
    {
        OnSelected?.Invoke(this);
    }
}
