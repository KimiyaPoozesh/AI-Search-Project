using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    
}
