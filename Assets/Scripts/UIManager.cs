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

    private int levelIndex;
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
    
    public void CalculateResult()
    {
       
    }
}