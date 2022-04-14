using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BacteriaMovement : MonoBehaviour
{
    public bacteriaSquasherController miniGame;
    Rigidbody2D body;
    public bool badBac;
    // Start is called before the first frame update
    void Start()
    {
        //badBac = false;
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(timerForMovement());
        miniGame = GameObject.FindGameObjectWithTag("MiniGameController").GetComponent<bacteriaSquasherController>();
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

    public void OnClick()
    {
        Debug.Log("Enter");
        miniGame.subtractBacteria();
        Destroy(this.gameObject);
        
    }






}
