using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;  

    public GameObject backgroundPlane;  
    public int gridSizeX = 6;  
    public int gridSizeY = 6;
    private GameObject[,] gridTiles;

    void Start()
    {
        GenerateGrid();
    }
    
    void GenerateGrid()
    {
        Renderer backgroundRenderer = backgroundPlane.GetComponent<Renderer>();
        if (backgroundRenderer == null)
        {
            Debug.LogError("Background Plane must have a Renderer component!");
            return;
        }

        Vector3 backgroundSize = backgroundRenderer.bounds.size;
        Vector3 backgroundPosition = backgroundRenderer.bounds.center;

        float tileSizeX = backgroundSize.x / gridSizeX;
        float tileSizeY = backgroundSize.z / gridSizeY;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GameObject tile = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
                tile.transform.localScale = new Vector3(tileSizeX/10.52631578947368421052631578947f, 1, tileSizeY/10.52631578947368421052631578947f);

                tile.transform.position = new Vector3(
                    backgroundPosition.x + (x + 0.5f) * tileSizeX - (backgroundSize.x / 2), 
                    backgroundPosition.y, 
                    backgroundPosition.z + (y + 0.5f) * tileSizeY - (backgroundSize.z / 2)
                );

                tile.transform.SetParent(transform);
            }
        }
    }
    
    
    
    
}
