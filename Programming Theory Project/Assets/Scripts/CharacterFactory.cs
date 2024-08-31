using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public GameObject parentPrefab; // Префаб Мамы
    public GameObject childPrefab;  // Префаб Ребенка
    public GameObject CreateParent(Transform transform, string name, int age)
    {
        GameObject parentObject = Instantiate(parentPrefab, transform);
        Parent parent = parentObject.GetComponent<Parent>();
        parent.personName = name;
        parent.age = age;
        return parentObject;
    }

    public GameObject CreateChild(Transform parent, string name, int age)
    {
        GameObject childObject = Instantiate(childPrefab, parent);
        Child child = childObject.GetComponent<Child>();
        child.personName = name;
        child.age = age;
        return childObject;
    }
}
