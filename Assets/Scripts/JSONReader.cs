using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public string jsonFilePath = "Python Part/test1.json"; // JSON file path
    public UIManager uiManager; // Reference to UIManager to execute the moves
    
    public TMP_Text nameText; // UI Text for the test case name
    public TMP_Text durationText; // UI Text for the duration
    public TMP_Text statusText; // UI Text for the status of is_done
    

    public void ReadAndHandleJson()
    {
        // Read the JSON file
        string jsonContent = File.ReadAllText(jsonFilePath);
        
        // Parse the JSON content into a C# object
        JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(jsonContent);
        
        nameText.text = "Name: " + jsonData.algorithm;
        durationText.text = "Time: " + jsonData.duration;
        statusText.text = jsonData.is_done ? "Status: Completed" : "Status: Incomplete";

        // If is_done is true, execute the moves, otherwise, just display the info
        if (jsonData.is_done)
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
            yield return new WaitForSeconds(2f); // Wait 1 second between moves (can be adjusted)
        }
        uiManager.CompleteState();
    }
}

// Data structure matching the JSON structure
[System.Serializable]
public class JsonData
{
    public string algorithm;
    public string test_case; // This will be used as the "name"
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