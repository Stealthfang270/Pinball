using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public int Score;
    public int highScore = 0;
    public List<int> highScores = new List<int>();
    SaveData saveData = new SaveData();
    DataSaver saver;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        saver = gameObject.AddComponent<DataSaver>();
        text = GetComponent<TextMeshProUGUI>();
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Le Scene")
        {
            text.text = "Score: " + Score + "\nHighscore: " + highScore;
        }
        else
        {
            text.text = "HIGHSCORES:\n";
            foreach (int score in highScores)
            {
                text.text += $"{score}\n";
            }
        }
    }

    public void LoadHighScore()
    {
        highScores = saver.Load();
        foreach (int score in highScores)
        {
            if (score > highScore) highScore = score;
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void ResetScore()
    {
        if (highScores.Count < 10)
        {
            highScores.Add(Score);
            highScores.Sort();
            highScores.Reverse();
        }
        else if (Score > highScores[9])
        {
            highScores.Sort();
            highScores.Reverse();
            highScores[9] = Score;
            highScores.Sort();
            highScores.Reverse();
            highScore = highScores[0];
        }
        SaveToFile();
        Score = 0;
        SceneManager.LoadScene("Le Menu");
    }

    public void SaveToFile()
    {
        saveData.HighScores = highScores;
        saver.saveData = this.saveData;
        saver.Save();
    }
}

[Serializable]
public struct SaveData
{
    public List<int> HighScores;
}

public class DataSaver : MonoBehaviour
{
    public string saveName = "scores";
    public string directoryName = "Saves";
    public SaveData saveData = new SaveData();
    public void Save()
    {
        if (!Directory.Exists(directoryName))
        {
            Directory.CreateDirectory(directoryName);
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Create(directoryName + "/" + saveName + ".bin");

        formatter.Serialize(saveFile, saveData);

        saveFile.Close();
    }

    public List<int> Load()
    {
        if (Directory.Exists(directoryName))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream saveFile = File.Open(directoryName + "/" + saveName + ".bin", FileMode.Open);

            SaveData loadedData = (SaveData)formatter.Deserialize(saveFile);

            saveFile.Close();

            if (loadedData.HighScores != null)
            {
                return loadedData.HighScores;
            }
        }
        return new List<int>();
    }
}
