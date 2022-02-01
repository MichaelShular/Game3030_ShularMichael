using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObjectsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Renderer objectRenderer;
    public bool canInterat;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        player = GameObject.Find("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        player.GetComponent<PlayerController>().currentInteractableObjects =this.gameObject;
        objectRenderer.material.color = Color.red;
        canInterat = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        player.GetComponent<PlayerController>().currentInteractableObjects = null;
        objectRenderer.material.color = Color.white;
        canInterat = false;

    }
   
}
