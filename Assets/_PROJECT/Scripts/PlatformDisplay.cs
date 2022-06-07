using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using DG.Tweening;

public class PlatformDisplay : NetworkBehaviour
{
    [SerializeField] NetworkManager networkManager;

    [HideInInspector] public List<Player> playerClasses = new List<Player>();

    //[SyncVar] 
    [SerializeField] Transform finalPos;

    private bool moveUp;

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
        if (Player.onlinePlayers.Count == 3)
        {
            if (!moveUp)
            {
                StartCoroutine(GoUp());
                moveUp = true;
            }
        }
    }

    IEnumerator GoUp()
    {
        yield return new WaitForFixedUpdate();
        transform.DOMove(finalPos.position, 2f);
    }
}
