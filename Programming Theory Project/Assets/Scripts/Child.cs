using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Person
{
    public Child()
    {
        Nick = "Child"; 
    }

    public override string PerformCleanUp()
    {
        return $"{personName} child has put away toys";
    }
    public override string GiveMoney(Person recipient, int amount)
    {
        return $"{personName} child can't give money";
    }
    
    public override string ReceiveMoney(int amount)
    {
        if (amount > 500)
        {
            return $"{personName} child can't receive more than 500$";
        }
        return base.ReceiveMoney(amount);
    }

}
