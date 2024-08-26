using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject oopText;
    [SerializeField] private TextMeshProUGUI enterNameText;
    [SerializeField] private float targetYPosition;
    private RectTransform rectPositionTitleText;
    
    private string playerName;
    void Start()
    {
        rectPositionTitleText = titleText.GetComponent<RectTransform>();
    }

    public void AssignName()
    {
        if(String.IsNullOrEmpty(nameInputField.text))
        {
            enterNameText.color = new Color(1,0,0);
        }
        else
        {
            playerName = nameInputField.text;
            Debug.Log(playerName);
            enterNameText.gameObject.SetActive(false);
            StartCoroutine(UpTitleText());
        }
    }

    IEnumerator UpTitleText()
    {
        Vector2 startPosition = rectPositionTitleText.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, targetYPosition);
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            rectPositionTitleText.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rectPositionTitleText.anchoredPosition = targetPosition;
        oopText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
