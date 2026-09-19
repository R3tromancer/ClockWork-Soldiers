using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    public bool isPlaceable = true;
    public bool isExplored = false;

    const int gridSize = 10;
 
    public Waypoint exploredFrom;
    Vector2Int gridPos;



    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
           Mathf.RoundToInt(transform.position.x / gridSize),
           Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }



    void OnMouseOver()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
           if (isPlaceable)
           {
               FindObjectOfType<TowerFactory>().AddTower(this);
           }
           else
           {
               print("Cant place here");
           }
        }
    }




}
