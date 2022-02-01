using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    public bool canInterat;
    // Start is called before the first frame update
    void Start()
    {
        canInterat = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerInteration();
    }

    private void playerInteration()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        canInterat = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInterat = false;
    }
}
