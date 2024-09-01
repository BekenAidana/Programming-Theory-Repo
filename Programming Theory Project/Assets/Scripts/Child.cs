using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Person
{
    private void Awake()
    {
        Nick = "Child";
        money = 500;
    }
    public override string PerformCleanUp()
    {
        return $"{Name} {Nick} has put away toys";
    }
    public override string GiveMoney(Person recipient, int amount)
    {
        return $"{Name} {Nick} can't give money";
    }
    
    public override bool ReceiveMoney(int amount)
    {
        if (amount > 500)
        {
            return false;
        }
        return base.ReceiveMoney(amount);
    }
    public override string ReasonCannotReceiveMoney()
    {
        return $"{Name} {Nick} can't receive more than 500$";
    }

}
