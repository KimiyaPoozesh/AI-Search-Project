
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    
    public Block[] blocks;
    private bool isComplete = false;
    public void ResetBlocks()
    {
        foreach (Block block in blocks)
        {
            block.ResetPosition();
        }
    }
    
    
    public void OnDone(Button button)
    {
        isComplete = true;
        button.GetComponent<Image>().color = Color.green;
    }

}
