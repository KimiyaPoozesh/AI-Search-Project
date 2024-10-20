using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public string jsonFilePath; // JSON file path
    public UIManager uiManager; 
    
    public TMP_Text nameText;
    public TMP_Text durationText; 
    public TMP_Text statusText;
    public TMP_Text path;
    void Start()
    {
        jsonFilePath = Path.Combine(Application.persistentDataPath, "solution.json");
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);
       path.text="Use this path in your python: " + jsonFilePath;
    }

    public void ReadAndHandleJson()
    {
        // Read the JSON file
        string jsonContent = File.ReadAllText(jsonFilePath);
        
        JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(jsonContent);
        
        nameText.text = "Name: " + jsonData.algorithm;
        durationText.text = "Time: " + jsonData.duration;
        statusText.text = jsonData.is_done ? "Status: Completed" : "Status: Incomplete";
        int testCaseNumber = ExtractTestCaseNumber(jsonData.test_case);
        Debug.Log(testCaseNumber);
        

        if (jsonData.is_done && testCaseNumber == uiManager.levelIndex +1)
        {
            StartCoroutine(ExecuteMovesSequentially(jsonData.moves));
           
        }
        else
        {
            Debug.Log("Moves are not executed since the task is incomplete.");
        }
    }
    private IEnumerator ExecuteMovesSequentially(List<Move> moves)
    {
        foreach (var move in moves)
        {
            uiManager.ExecuteMove(move.piece, move.direction);
            yield return new WaitForSeconds(2f); 
        }
        uiManager.CompleteState();
    }
    
    private int ExtractTestCaseNumber(string testCase)
    {
        string numberPart = testCase.Split('.')[0]; 
        return int.Parse(numberPart);
    }
}

[System.Serializable]
public class JsonData
{
    public string algorithm;
    public string test_case;
    public string duration;
    public List<Move> moves;
    public bool is_done;
}

[System.Serializable]
public class Move
{
    public int piece;
    public string direction;
}