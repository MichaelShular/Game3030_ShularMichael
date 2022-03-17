using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniChooseController : MonoBehaviour
{
    [SerializeField] public GameObject miniGameDisinfectantCanvas;
    [SerializeField] public GameObject miniGamePillsCanvas;
    [SerializeField] public GameObject miniGameCutOpenCanvas;
    [SerializeField] public GameObject miniGameBoneSortCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMiniGameDisinfectant()
    {
        Instantiate(miniGameDisinfectantCanvas);
        Destroy(this.gameObject);
    }

    public void OpenMiniGamePills()
    {
        Instantiate(miniGamePillsCanvas);
        Destroy(this.gameObject);
    }
    public void OpenMiniGameCutOpen()
    {
        Instantiate(miniGameCutOpenCanvas);
        Destroy(this.gameObject);
    }

    public void OpenMiniGameBoneSort()
    {
        Instantiate(miniGameBoneSortCanvas);
        Destroy(this.gameObject);
    }
    public void backButton()
    {
        Destroy(this.gameObject);
    }

}
