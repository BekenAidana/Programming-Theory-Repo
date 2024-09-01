using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : Person
{
    private void Awake()
    {
        Nick = "Parent";
    }
    public override string PerformCleanUp()
    {
        return base.PerformCleanUp() + " and washed the dishes";
    }
}
