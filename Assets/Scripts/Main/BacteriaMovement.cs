using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BacteriaMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(timerForMovement());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator timerForMovement()
    {
        float timer = Random.Range(1.0f, 10.0f);
        body.AddForce(new Vector2(Random.Range(-30, 30), Random.Range(-30, 30)), ForceMode2D.Impulse);
        yield return new WaitForSeconds(timer);
        StartCoroutine(timerForMovement());

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Destroy(this.gameObject);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {


    }
}
