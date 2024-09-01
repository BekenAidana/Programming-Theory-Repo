using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField ageInput;
    [SerializeField] private InputField moneyInput;
    [SerializeField] private CharacterFactory characterFactory; 
    [SerializeField] private Transform characterContainer;
    [SerializeField] private Text feedbackText;
    [SerializeField] private GameObject selectIndicator;
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
    private bool CheckIntNumber(string text)
    {
        int value;
        if (!int.TryParse(text, out value))
        {
            feedbackText.text = "Please enter a valid age (whole number).";
            return false;
        }
        return true;
    }
    public void CreatePerson()
    {
        string name = nameInput.text;
        if(!CheckIntNumber(ageInput.text)){return;}
        int age = int.Parse(ageInput.text);
        if(age<0){feedbackText.text = "Please enter a possitive number";}

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
        if((childInstance != null) & (parentInstance !=null))
        {
            OOPSceneManager.Instance.ChangeStage(OOPSceneStage.instructionInheritance);
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
    public void CleanUp()
    {
        if (CheckWasSelected())
        {
            feedbackText.text = selectedPerson.PerformCleanUp();
        }
    }
    public void TransferMoney()
    {
        if(!CheckIntNumber(moneyInput.text)){return;}
        int amount = int.Parse(moneyInput.text);
        if (CheckWasSelected())
        {
            Person targetPerson;
            if(selectedPerson==parentInstance){targetPerson = childInstance;}
            else{targetPerson = parentInstance;}
            Debug.Log(targetPerson);
            feedbackText.text = selectedPerson.GiveMoney(targetPerson, amount);
        }
    }
    private bool CheckWasSelected()
    {
        if (selectedPerson==null)
        {   
            feedbackText.text = "Please, Select a person.";
            return false;
        }
        return true;
    }
    public void OnPersonSelected(Person person)
    {
        if (selectIndicator.activeSelf==false)
        {   
            selectIndicator.SetActive(true);
        }
        this.selectedPerson = person;
        selectIndicator.transform.position = selectedPerson.transform.position + new Vector3(0,-2f,0);
        feedbackText.text = $"{selectedPerson.Name} {selectedPerson.Nick} is selected. Money: {selectedPerson.Money}";
    }
}