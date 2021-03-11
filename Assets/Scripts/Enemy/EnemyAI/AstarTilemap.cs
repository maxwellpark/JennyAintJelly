using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AstarTilemap : MonoBehaviour
{
    public Grid grid;
    public Tilemap floorLayer; // Walkable 
    public List<Tilemap> obstacleLayers;

    public GameObject nodePrefab;
    public List<GameObject> unsortedNodes;
    public GameObject[,] sortedNodes;
    public int gridRowCount, gridColumnCount;
    public int gridBoundX, gridBoundY;

    public SearchBounds searchBounds = new SearchBounds()
    {
        startX = -250,
        startY = -250,
        endX = 250,
        endY = 250
    };

    public struct SearchBounds
    {
        public int startX;
        public int startY;
        public int endX;
        public int endY;
    }

    private void Awake()
    {
        unsortedNodes = new List<GameObject>();
    }

    public void CreateNodes()
    {
        // The A* grid indices 
        int gridX = 0;
        int gridY = 0;

        bool tileFound;

        for (int x = searchBounds.startX; x < searchBounds.endX; x++)
        {
            for (int y = searchBounds.startY; y < searchBounds.endY; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);

                // Get the tile at the current coordinates in the world 
                TileBase floorTile = floorLayer.GetTile(cellPosition);

                if (floorTile != null)
                {
                    GameObject node = Instantiate(nodePrefab, new Vector3(
                        x + 0.5f + grid.transform.position.x,
                        y + 0.5f + grid.transform.position.y, 0),
                        Quaternion.Euler(0, 0, 0));

                    if (!IsObstacleAtCell(cellPosition))
                    {
                        // Create a walkable node 


                        // Set A* node coordinates and other state here

                        tileFound = true;
                    }
                    else
                    {
                        // Create an obstacle node 
                        // Set walkable to false on A* node 

                        node.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    unsortedNodes.Add(node);

                    gridY++;

                    if (gridX > gridBoundX)
                    {
                        gridBoundX = gridX;
                    }
                    if (gridY > gridBoundY)
                    {
                        gridBoundY = gridY; // Find out the full size of the 2d array to init it later on
                    }
                }
                gridX++;
                gridY = 0;
                tileFound = false;
            }
        }

        sortedNodes = new GameObject[gridBoundX, gridBoundY];
        foreach (GameObject node in sortedNodes)
        {
            // Get A* node and add to array

            //sortedNodes[astar.x, astar.y] = node;
        }

        // Neighbours
        for (int x = 0; x < sortedNodes.GetLength(0); x++)
        {
            for (int y = 0; y < sortedNodes.GetLength(1); y++)
            {
                if (sortedNodes[x, y] != null)
                {
                    // Set the A* node's neighbours 

                    //AstarNode astarNode = sortedNodes[x, y].GetComponent<ASTARNODE>();
                    //astarNode.neighbours = GetNeighbours(x, y, gridBoundX, gridBoundY); // Or do GetLength(0,1)
                }
            }
        }


    }

    //public List<ASTARNODE> GetNeighbours(int x, int y, int width, int height) 
    //{
    //    var neighbours = new List<ASTARNODE>();

    //    // Check if tiles are present on both left and right sides 
    //    if (x > 0 && x < width - 1)
    //    {
    //        // Check if tiles are present on both top and bottom sides 
    //        if (y > 0 && y < height - 1)
    //        {
    //            if (sortedNodes[x + 1, y] != null)
    //            {
    //                AstarNode astarNode = sortedNodes[x + 1, y].GetComponent<ASTARNODE>();
    //                if (astarNode != null)
    //                {
    //                    neighbours.Add(astarNode);
    //                }
    //            }

    //        }
    //    }

    //    // Repeat for all neighbours 
    //}
    public bool IsObstacleAtCell(Vector3Int cellPosition)
    {
        for (int i = 0; i < obstacleLayers.Count; i++)
        {
            if (obstacleLayers[i].GetTile(cellPosition) != null)
            {
                return true;
            }
        }
        return false; 
    }
}
