using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PillController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image pillImage;
    public Color pillColor;

    // Start is called before the first frame update
    void Start()
    {
        pillImage = this.GetComponent<Image>();
        pillImage.color = pillColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {


    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {

        Destroy(this.gameObject);
    }
}
