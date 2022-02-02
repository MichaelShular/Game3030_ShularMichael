using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableObjectsController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Renderer objectRenderer;
    public bool canInterat;
    private GameObject player;

    [SerializeField] public GameObject miniGameCanvas;
    public objectType InteractableObjectType;

    public Material redCivilianJoints;
    public Material redCivilianHighLimbs;
    public Color selectedMaterial;
    private Color redCivilianJointsColor;
    private Color redCivilianHighLimbsColor;


    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        player = GameObject.Find("MainCharacter");
        redCivilianHighLimbsColor = redCivilianHighLimbs.color;
        redCivilianJointsColor = redCivilianJoints.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        switch (InteractableObjectType)
        {
            case objectType.Person:
                redCivilianJoints.color = redCivilianHighLimbs.color = selectedMaterial;
                break;
            case objectType.Object:
                objectRenderer.material.color = Color.red;
                break;
            default:
                break;
        }
        player.GetComponent<PlayerController>().currentInteractableObjects =this.gameObject;
        
        canInterat = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        player.GetComponent<PlayerController>().currentInteractableObjects = null;
        switch (InteractableObjectType)
        {
            case objectType.Person:
                redCivilianJoints.color = redCivilianJointsColor;
                redCivilianHighLimbs.color = redCivilianHighLimbsColor;
                break;
            case objectType.Object:
                objectRenderer.material.color = Color.white;
                break;
            default:
                break;
        }
        
        canInterat = false;

    }
   
    public enum objectType
    {
        Person,
        Object
    }


}
