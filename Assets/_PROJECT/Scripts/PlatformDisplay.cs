using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlatformDisplay : NetworkBehaviour
{
    [SerializeField] NetworkManager networkManager;

    [HideInInspector] public List<Player> playerClasses = new List<Player>(); 

    public override void OnStartClient()
    {
        //Debug.Log(FindPlayerClasses().Count);
    }

    public List<Player> FindPlayerClasses()
    {
        List<Player> classes = new List<Player>();
        foreach (GameObject prefab in networkManager.spawnPrefabs)
        {
            Player player = prefab.GetComponent<Player>();
            if (player != null)
                classes.Add(player);
        }
        return classes;
    }

    void Update()
    {
        Debug.Log(Player.onlinePlayers.Count);
    }
}
