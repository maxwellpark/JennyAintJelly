using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        AstarPath.active.logPathResults = Pathfinding.PathLog.None;
    }
}
