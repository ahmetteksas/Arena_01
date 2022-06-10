using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ObstacleDisplay : MonoBehaviour
{
    public bool isRotator;
    public bool isFan;

    [SerializeField] Transform fanPanels;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isFan)
            {
                collision.gameObject.GetComponent<PlayerCharacterControllerMovement>().controller.Move(transform.up * 16f);
                Debug.Log("Crashed !!!");
            }
            //collision.gameObject.GetComponent<PlayerCharacterControllerMovement>().controller.Move(new Vector3(0, 0, -rb.angularVelocity.y) * 2f);
            //Debug.Log(collision.gameObject.name + "Crashed");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isRotator)
        {
            rb.angularVelocity = new Vector3(0, 3f, 0);
        }
        else if (isFan)
        {
            fanPanels.transform.Rotate(0, 4f, 0);
        }
    }
}
