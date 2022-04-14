using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class boneObjectScript : MonoBehaviour, IDragHandler 
{
    // Start is called before the first frame update
    public int boneID;
    public bool moveWithMouse;

    public float speedDamp = 0.05f;
    private RectTransform draggingObjectRectTrans;
    private Vector3 vel = Vector3.zero;

    public string currentBox;

    private void Awake()
    {
        draggingObjectRectTrans = transform as RectTransform;
    }

    void Start()
    {
        moveWithMouse = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTrans, eventData.position,
            eventData.pressEventCamera, out var globalMousePosition))
        {
            draggingObjectRectTrans.position = Vector3.SmoothDamp(draggingObjectRectTrans.position, globalMousePosition, ref vel, speedDamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(true);
        currentBox = collision.gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void changeText(string text)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

}
