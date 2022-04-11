using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniChooseController : MonoBehaviour
{
    [SerializeField] public GameObject miniGameDisinfectantCanvas;
    [SerializeField] public GameObject miniGamePillsCanvas;
    [SerializeField] public GameObject miniGameCutOpenCanvas;
    [SerializeField] public GameObject miniGameBoneSortCanvas;

    private DiseaseConstructScript gameChecker;
    // Start is called before the first frame update
    void Start()
    {
        gameChecker = GameObject.Find("GameController").GetComponent<DiseaseConstructScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMiniGameDisinfectant()
    {
        Instantiate(miniGameDisinfectantCanvas);
        gameChecker.checkIfRightGameWasPlayed(GameType.BacteriaKiller);
        Destroy(this.gameObject);
    }

    public void OpenMiniGamePills()
    {
        Instantiate(miniGamePillsCanvas);
        gameChecker.checkIfRightGameWasPlayed(GameType.PillMixer);
        Destroy(this.gameObject);
    }
    public void OpenMiniGameCutOpen()
    {
        Instantiate(miniGameCutOpenCanvas);
        gameChecker.checkIfRightGameWasPlayed(GameType.CutOpen);
        Destroy(this.gameObject);
    }

    public void OpenMiniGameBoneSort()
    {
        Instantiate(miniGameBoneSortCanvas);
        gameChecker.checkIfRightGameWasPlayed(GameType.BoneSort);
        Destroy(this.gameObject);
    }
    public void backButton()
    {
        Destroy(this.gameObject);
    }

}
