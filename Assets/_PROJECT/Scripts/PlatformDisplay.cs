using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using DG.Tweening;

public class PlatformDisplay : NetworkBehaviour
{
    [SerializeField] NetworkManager networkManager;
    [SerializeField] Transform sphere;

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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Adjusting());
        }
    }

    void Update()
    {
        Debug.Log(Player.onlinePlayers.Count);
        if (Player.onlinePlayers.Count == 1)
        {
            if (!moveUp)
            {
                StartCoroutine(GoUp());
                moveUp = true;
            }
        }
        foreach (var item in FindObjectsOfType<Health>())
        {
            if (item == FindObjectOfType<Health>().health)
            {
                Debug.Log(item.current);
            }
        }
    }

    IEnumerator Adjusting()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1f);
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator GoUp()
    {
        transform.DOScale(new Vector3(.8f, .8f, .8f), .1f);
        yield return new WaitForFixedUpdate();
        yield return transform.DOMove(finalPos.position, 2f).WaitForCompletion();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //sphere.SetParent(null, true);
        //transform.DOPause();
    }
}
