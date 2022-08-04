using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HolderOfInfo : MonoBehaviour
{
    public static HolderOfInfo instance;

    public string playerName;
    public string bestScoreName;
    public int bestScore;
    public int score;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;        
    }

    public void SaveNameAndScore()
    {       
        SaveData data = new SaveData();
        var MainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        
        if (score > bestScore)
        {
            data.score = MainManager.m_Points;
            data.playerName = playerName;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.score;
            bestScoreName = data.playerName;
        }
    }
}

