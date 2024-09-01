using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OOPSceneManager : MonoBehaviour
{
    public static OOPSceneManager Instance;
    public OOPSceneStage currentStage;
    private Dictionary<OOPSceneStage, string> instructionDict = new Dictionary<OOPSceneStage, string>();
    [SerializeField] private Text instructionText;
    [SerializeField] private GameObject createPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private GameObject methodPanel;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        instructionDict.Add(OOPSceneStage.Create,"Create Parent and Child. If you enter an age under 18, a Child will be created; otherwise, a Parent will be created."); 
        instructionDict.Add(OOPSceneStage.instructionInheritance,"Inheritance is an OOP principle where a new class (like Parent or Child) derives from an existing base class (Person). This allows the new class to inherit common properties and methods, promoting code reuse and extending functionality without modifying the original class.");
        instructionDict.Add(OOPSceneStage.instructionPolymorphysm,"Polymorphism is an OOP principle that allows objects of different classes to be treated as instances of a common base class. It enables each class to implement the same method in its own way, based on its specific behavior.");
        instructionDict.Add(OOPSceneStage.examplePolymorphism, "Select an object and press the buttons. These methods have been overridden to demonstrate different behaviors for each class.");
        instructionDict.Add(OOPSceneStage.instructionEncapsulation, "Encapsulation protects an object's data by restricting direct access. Only specific methods can modify the internal state, ensuring data integrity.");
        instructionDict.Add(OOPSceneStage.exampleEncapsulation, "In this scene, encapsulation ensures that Name and Age are set once at initialization and cannot be changed. Money is only modified through controlled methods like ReceiveMoney and GiveMoney.");
        instructionDict.Add(OOPSceneStage.instructionAbstraction, "Abstraction is an OOP principle that hides complex details and exposes only what is necessary, allowing you to interact with objects through a simplified interface.");
        instructionDict.Add(OOPSceneStage.exampleAbstraction, "In this scene, abstraction is shown by the Person class defining a general contract. Parent and Child classes implement specific details without exposing their internal complexity.");
                        
        UpdateText();
    }

    public void ChangeStage(OOPSceneStage stage)
    {
        if(stage == OOPSceneStage.instructionInheritance)
        {
            createPanel.SetActive(false);
            nextPanel.SetActive(true);
        }
        if(stage == OOPSceneStage.examplePolymorphism)
        {
            methodPanel.SetActive(true);
            nextPanel.SetActive(false);
        }
        if(stage == OOPSceneStage.instructionAbstraction)
        {
            methodPanel.SetActive(false);
            nextPanel.SetActive(true);
        }
        currentStage = stage;
        UpdateText();
    }

    private void UpdateText()
    {
        instructionText.text = instructionDict[currentStage];
    }
    public void NextButton()
    {
        int nextStage = (int)currentStage + 1;
        if(nextStage>Enum.GetNames(typeof(OOPSceneStage)).Length-1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            ChangeStage((OOPSceneStage)nextStage);
        }
        
    }
}
