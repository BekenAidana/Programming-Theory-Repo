using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField ageInput;
    [SerializeField] private CharacterFactory characterFactory; 
    [SerializeField] private Transform characterContainer;
    [SerializeField] private Text feedbackText;
    public Parent parentInstance;
    public Child childInstance;
    private Person selectedPerson;

    private bool CheckNotWasCreated(Person person)
    {
        if(person!=null)
        {
            feedbackText.text = "You have already created";
            return false; 
        }
        return true;
    }
    public void CreatePerson()
    {
        string name = nameInput.text;
        int age = int.Parse(ageInput.text);

        if (!int.TryParse(ageInput.text, out age))
        {
            feedbackText.text = "Please enter a valid age (whole number).";
            return;
        }

        if(age<18)
        {
            if(CheckNotWasCreated(childInstance))
            {
                CreateChild(name, age);
            }
        }
        else
        {
            if(CheckNotWasCreated(parentInstance))
            {
                CreateParent(name, age);
            }
        }
    }

    public void CreateParent(string name, int age)
    {
        GameObject parentObject = characterFactory.CreateParent(characterContainer, name, age);
        parentInstance = parentObject.GetComponent<Parent>();
        parentInstance.OnSelected += OnPersonSelected;
        feedbackText.text = $"{parentInstance.Nick} {name}, Age {age}, was created.";
    }
    public void CreateChild(string name, int age)
    {
        GameObject childObject = characterFactory.CreateChild(characterContainer, name, age);
        childInstance = childObject.GetComponent<Child>();
        childInstance.OnSelected += OnPersonSelected;
        feedbackText.text = $"{childInstance.Nick} {name}, age {age}, was created.";
    }

    public void OnPersonSelected(Person selectedPerson)
    {
        this.selectedPerson = selectedPerson;
        feedbackText.text = $"{selectedPerson.personName} {selectedPerson.Nick} is selected.";
    }
}