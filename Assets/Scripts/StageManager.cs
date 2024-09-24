
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    
    public Block[] blocks;
    public bool isComplete = false;
    [SerializeField] private Light m_Light;
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
        m_Light.color = Color.green;
    }

}
