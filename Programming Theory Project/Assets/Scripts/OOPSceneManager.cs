using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OOPSceneManager : MonoBehaviour
{
    [SerializeField] private Text instructionText;
    // Start is called before the first frame update
    void Start()
    {
        instructionText.text = "Create Parent and Child. If you enter an age under 18, a Child will be created; "+
                                "otherwise, a Parent will be created.";

    }

    // Update is called once per frame
    void Update()
    {
    }
}
