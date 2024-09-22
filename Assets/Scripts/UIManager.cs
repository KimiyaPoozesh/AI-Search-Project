using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject[] levelObjects; 
    public Button[] levelButtons;      

    void Start()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i;  
            levelButtons[i].onClick.AddListener(() => ShowLevel(levelIndex));
        }
        ShowLevel(0);
    }

    void ShowLevel(int levelIndex)
    {
        for (int i = 0; i < levelObjects.Length; i++)
        {
            //levelObjects[i].GetComponent<StageManager>().ResetBlocks();
            levelObjects[i].SetActive(i == levelIndex);
        }
    }
}