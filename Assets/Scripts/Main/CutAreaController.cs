using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum areaType
{
    CuttingSection,
    Background
}
public class CutAreaController : MonoBehaviour
{
    public bool canPress;
    private CutOpenController cutOpenController;

    // Start is called before the first frame update
    void Start()
    {
        cutOpenController = transform.parent.GetComponent<CutOpenController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CutAreaClickedOn()
    {
        if (canPress)
        {
            cutOpenController.wasPressed(false);
        }
        else
        {
            cutOpenController.wasPressed(true);
        }

        Destroy(this.gameObject);
    }

    public void BackgroundClicked()
    {
        cutOpenController.wasPressed(true);
    }

}
