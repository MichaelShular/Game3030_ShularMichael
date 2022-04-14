using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniChooseController : MonoBehaviour
{
    [SerializeField] public GameObject miniGameDisinfectantCanvas;
    [SerializeField] public GameObject miniGamePillsCanvas;
    [SerializeField] public GameObject miniGameCutOpenCanvas;
    [SerializeField] public GameObject miniGameBoneSortCanvas;

    public GameObject miniGameResult;

    private DiseaseConstructScript gameChecker;
    // Start is called before the first frame update
    void Start()
    {
        gameChecker = GameObject.Find("GameController").GetComponent<DiseaseConstructScript>();
        miniGameResult = GameObject.Find("GameController");
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMiniGameDisinfectant()
    { 
        miniGameResult.GetComponent<MiniGameResultScript>().wasCorrectMiniGameChoosen = gameChecker.checkIfRightGameWasPlayed(GameType.BacteriaKiller);
        Instantiate(miniGameDisinfectantCanvas);
       
        Destroy(this.gameObject);
    }

    public void OpenMiniGamePills()
    { 
        miniGameResult.GetComponent<MiniGameResultScript>().wasCorrectMiniGameChoosen = gameChecker.checkIfRightGameWasPlayed(GameType.PillMixer);
        Instantiate(miniGamePillsCanvas);
       
        Destroy(this.gameObject);
    }
    public void OpenMiniGameCutOpen()
    {
        miniGameResult.GetComponent<MiniGameResultScript>().wasCorrectMiniGameChoosen = gameChecker.checkIfRightGameWasPlayed(GameType.CutOpen);
        Instantiate(miniGameCutOpenCanvas);
        
        Destroy(this.gameObject);
    }

    public void OpenMiniGameBoneSort()
    {
        miniGameResult.GetComponent<MiniGameResultScript>().wasCorrectMiniGameChoosen = gameChecker.checkIfRightGameWasPlayed(GameType.BoneSort);
        Instantiate(miniGameBoneSortCanvas);
        
        Destroy(this.gameObject);
    }
    public void backButton()
    {
        Destroy(this.gameObject);
    }

}
