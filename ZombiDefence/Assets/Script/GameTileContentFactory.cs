using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameTileContentFactory : ScriptableObject
{
    [SerializeField] private GameTileContent grenadierPrefab;
    [SerializeField] private GameTileContent marinePrefab;
    [SerializeField] private GameTileContent sniperPrefab;
    [SerializeField] private GameTileContent wolfPitPrefab;
    [SerializeField] private GameTileContent wallPrefab;
    [SerializeField] private GameTileContent thornsPrefab;

    public void Destroy(GameTileContent content)
    {
        Destroy(content.gameObject);
    }


    public GameTileContent Get(GameTileContentType type)
    {
        switch (type)
        {
            case GameTileContentType.Ggrenadier:
                return Get(grenadierPrefab);
            case GameTileContentType.Marine:
                return (marinePrefab);
            case GameTileContentType.Sniper:
                return Get(sniperPrefab);
            case GameTileContentType.WolfPit:
                return (wolfPitPrefab);
            case GameTileContentType.Wall:
                return Get(wallPrefab);
            case GameTileContentType.Thorns:
                return (thornsPrefab);
        }
        return null;
    }

    private GameTileContent Get(GameTileContent prefab)
    {
        GameTileContent newPrefab = Instantiate(prefab);
        newPrefab.factory = this;
        MoveToFactoryScene(newPrefab.gameObject);
        return newPrefab;
    }

    private Scene contentScene;

    private void MoveToFactoryScene(GameObject obj)
    {
        if (!contentScene.isLoaded)
        {
            if (Application.isEditor)
            {
                contentScene = SceneManager.GetSceneByName(name);
                if (!contentScene.isLoaded)
                {
                    contentScene = SceneManager.CreateScene(name);
                }
            }
            else
            {
                contentScene = SceneManager.CreateScene(name);
            }
        }
        SceneManager.MoveGameObjectToScene(obj, contentScene);
    }
}
