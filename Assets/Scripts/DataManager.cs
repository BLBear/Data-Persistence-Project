using System;
using System.IO;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance {get; private set; }
    public int currentScore;
    public int hiScore;
    public string playerName;
    public string hiScoreName;
    public string hiScoreValue;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            LoadHiScore();
        }
        else
        {
            hiScoreName = "ZZZ";
            hiScoreValue = "1";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveHiScore()
    {
        SaveDataObj toSave = new SaveDataObj();
        toSave.saveHiScorePlayer = playerName;
        toSave.saveHiScoreValue = hiScoreValue;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(toSave));
    }
    private void LoadHiScore()
    {
        SaveDataObj fromSave = JsonUtility.FromJson<SaveDataObj>(File.ReadAllText(Application.persistentDataPath + "/savefile.json"));
        hiScoreName = fromSave.saveHiScorePlayer != null ? fromSave.saveHiScorePlayer : "AAA";
        hiScoreValue = fromSave.saveHiScoreValue != null? fromSave.saveHiScoreValue : "0";
    }

    [Serializable]
    public class SaveDataObj
    {
        public string saveHiScorePlayer;
        public string saveHiScoreValue;
    }
}
