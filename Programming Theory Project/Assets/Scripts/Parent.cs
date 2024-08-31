using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : Person
{
    public Parent()
    {
        Nick = "Parent"; 
    }
    public override string PerformCleanUp()
    {
        return base.PerformCleanUp() + " and washes the dishes";
    }
    public override string GiveMoney(Person recipient, int amount)
    {
        if (recipient is Child child && money >= amount)
        { 
            money -= amount;
            return $"{personName} parent gives {amount}$ to {child.personName} child";
        }
        return base.GiveMoney(recipient,amount);
    }
}
