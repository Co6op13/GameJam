using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTileContent : MonoBehaviour
{
    [SerializeField] private GameTileContentType type;

    public GameTileContentType Type => type;

    public GameTileContentFactory factory { get; set; }

    public void Destroy()
    {
        factory.Destroy(this);
    }
}
public enum GameTileContentType
{
    Ggrenadier, 
    Marine,
    Sniper, 
    WolfPit, 
    Thorns, 
    Wall
}

