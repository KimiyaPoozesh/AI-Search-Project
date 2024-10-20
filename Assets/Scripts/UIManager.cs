using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] levelObjects; 
    public Button[] levelButtons;  
    [SerializeField] private GameObject levelsButton;
    [SerializeField] private GameObject WelcomeText;
    public int levelIndex;
    //add two virtual camera
    [SerializeField] private CinemachineVirtualCamera menucam;
    [SerializeField] private CinemachineVirtualCamera gamecam;

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;  
            levelButtons[i].onClick.AddListener(() => ShowLevel(levelIndex));
        }
        
    }

    private void Update()
    {
        //when space is pressed it shows level
        if (Input.GetKeyDown(KeyCode.Space))
        {
            levelsButton.SetActive(true);
            WelcomeText.SetActive(false);
            ShowLevel(0);
            GridManager.instance.GenerateGrid();
            menucam.Priority = 0;   
        }
    }

    void ShowLevel(int levelIndex)
    {
        for (int i = 0; i < levelObjects.Length; i++)
        {
            
            levelObjects[i].SetActive(i == levelIndex);
            this.levelIndex = levelIndex;
        }
    }


    public void ResetLevel()
    {
        levelObjects[levelIndex].GetComponent<StageManager>().ResetBlocks();
    }
    
    public void ExecuteMove(int blockId, string direction)
    {
        Block blockToMove = null;
        
        
        foreach (var block in levelObjects[levelIndex].GetComponent<StageManager>().blocks)
        {
            if (block.id == blockId)
            {
                blockToMove = block;
                break;
            }
        }
        
        if (blockToMove != null)
        {
            switch (direction.ToLower())
            {
                case "up":
                    blockToMove.MoveUp();
                    break;
                case "down":
                    blockToMove.MoveDown();
                    break;
                case "left":
                    blockToMove.MoveLeft();
                    break;
                case "right":
                    blockToMove.MoveRight();
                    break;
                default:
                    Debug.LogWarning("Invalid direction: " + direction);
                    break;
            }
            Debug.Log($"Piece {blockId} moved {direction}");
        }
        else
        {
            Debug.LogWarning("Block with ID " + blockId + " not found.");
        }
    }

    public void CompleteState()
    {
        levelObjects[levelIndex].GetComponent<StageManager>().OnDone(levelButtons[levelIndex]);
        for (int i=0 ; i<levelObjects.Length ; i++)
        {
            if (!levelObjects[i].GetComponent<StageManager>().isComplete)
            {
                ShowLevel(i);
                return;
            }
        }
        
        //if no level is left to be shown
        gamecam.Priority = 0;

    }
}