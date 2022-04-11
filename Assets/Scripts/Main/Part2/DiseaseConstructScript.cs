using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType
{
    BacteriaKiller,
    PillMixer,
    CutOpen,
    BoneSort
}

public class DiseaseConstructScript : MonoBehaviour
{
    [Header("List of Diseases")]
    public List<string> diseasesNames;
    public string winningDiseaseName;


    public List<GameType> gameOrderNeedToPlay;
    //public List<GameType> playersGameList;

    private int gameCounter;
    // Start is called before the first frame update
    void Start()
    {
        int tempNum = Random.Range(0, diseasesNames.Count);
        gameCounter = 0;
        switch (tempNum)
        {
            case 0:
                fillOutPath(tempNum, GameType.BacteriaKiller, GameType.PillMixer, GameType.CutOpen);
                break;
            case 1:
                fillOutPath(tempNum, GameType.BoneSort, GameType.CutOpen, GameType.PillMixer);

                break;
            case 2:
                fillOutPath(tempNum, GameType.PillMixer, GameType.BacteriaKiller, GameType.BoneSort);

                break;
            case 3:
                fillOutPath(tempNum, GameType.CutOpen, GameType.BoneSort, GameType.BacteriaKiller);
                break;
            default:
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void fillOutPath(int num, GameType gameOne, GameType gameTwo, GameType gameThree)
    {
        winningDiseaseName = diseasesNames[num];
        gameOrderNeedToPlay.Add(gameOne);
        gameOrderNeedToPlay.Add(gameTwo);
        gameOrderNeedToPlay.Add(gameThree);
    }

    //public void addedToPlayersGameList(GameType gamePlayed)
    //{
    //    playersGameList.Add(gamePlayed);
    //}

    public void checkIfRightGameWasPlayed(GameType currentGame)
    {
        if(gameOrderNeedToPlay[gameCounter] != currentGame)
        {
            GetComponent<GameControllerScript>().changeHealth(-1);
        }
         
        gameCounter++;
    }

}
