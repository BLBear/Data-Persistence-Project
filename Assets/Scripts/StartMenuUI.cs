using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hiScoreNameText;
    [SerializeField] private TextMeshProUGUI hiScoreValueText;
    [SerializeField] private TextMeshProUGUI nameInputText;
    [SerializeField] private Button startButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hiScoreNameText.text = DataManager.Instance.hiScoreName;
        hiScoreValueText.text = DataManager.Instance.hiScoreValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (nameInputText.textInfo.characterCount > 3 && nameInputText.textInfo.characterCount <= 9)
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }
    
    public void StartButtonClick()
    {
        DataManager.Instance.playerName = nameInputText.text;
        SceneManager.LoadScene(1);
    }
}
