using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    public static string playerName;
    public static string hiScoreName;
    public static int hiScoreValue;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private TextMeshProUGUI inputField;
    [SerializeField]
    private TextMeshProUGUI hiScoreNameText;
    [SerializeField]
    private TextMeshProUGUI hiScoreValueText;

    void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Disable start button unless 3 - 8 chars in text input field
        if (inputField.textInfo.characterCount > 3 && inputField.textInfo.characterCount <= 9)
        {
            startButton.interactable = true;
            
        }
        else
        {
            startButton.interactable = false;
        }
    }

    public void StartClick()
    {
        playerName = inputField.text;
        hiScoreName = hiScoreNameText.text;
        hiScoreValue = Convert.ToInt32(hiScoreValueText.text);
        // Debug.Log("Player " + playerName + " Hi Score Player " + hiScoreName + " Hi Score " + hiScoreValue);
        SceneManager.LoadScene(1);
    }
}
