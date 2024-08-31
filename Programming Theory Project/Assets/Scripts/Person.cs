using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Person : MonoBehaviour
{
    public string personName;
    public int age;
    public int money = 1000; // Начальная сумма денег для каждого персонажа
    public event System.Action<Person> OnSelected;
    protected string nick = "Person";
    public string Nick
    {
        get { return nick; }  
        set { nick = value; }  
    }
    public virtual string PerformCleanUp()
    {
        return $"{personName} has cleaned the house";
    }
    public virtual string ReceiveMoney(int amount)
    {
        money += amount;
        return $"{personName} has received {amount}$";
    }
    public virtual string GiveMoney(Person recipient, int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            recipient.ReceiveMoney(amount);
            return $"{personName} has given {amount}$ to {recipient.personName}";
        }
        return $"{personName} doesn't have enough money";
    }

    void OnMouseDown()
    {
        OnSelected?.Invoke(this);
    }
}
