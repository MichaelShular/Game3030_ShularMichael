using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [Header("Stuff To Spawn")]
    public bool isBleeding;
    public GameObject _blood;
    public BoxCollider _BloodSpawnLocation;
    public float amountOfBlood;
    public GameObject UIForBlood;

    // Start is called before the first frame update
    void Start()
    {
        int tempNum = Random.Range(0, diseasesNames.Count);
        gameCounter = 0;
        switch (tempNum)
        {
            case 0:
                fillOutPath(tempNum, GameType.BacteriaKiller, GameType.PillMixer, GameType.CutOpen);
                isBleeding = true;
                amountOfBlood = 100;
                break;
            case 1:
                fillOutPath(tempNum, GameType.BoneSort, GameType.CutOpen, GameType.PillMixer);
                isBleeding = true;
                amountOfBlood = 20;

                break;
            case 2:
                fillOutPath(tempNum, GameType.PillMixer, GameType.BacteriaKiller, GameType.BoneSort);
                isBleeding = true;
                amountOfBlood = 50;

                break;
            case 3:
                fillOutPath(tempNum, GameType.CutOpen, GameType.BoneSort, GameType.BacteriaKiller);
                isBleeding = false;

                break;
            default:
                break;
        }

        bloodSpawning();
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
        if (gameOrderNeedToPlay[gameCounter] != currentGame)
        {
            GetComponent<GameControllerScript>().changeHealth(-1);
        }

        gameCounter++;
    }

    private void bloodSpawning()
    {
        if (!isBleeding) return;
        int numberOfGameObjectsToSpawn = Random.Range(1, 6);


        for (int i = 0; i < numberOfGameObjectsToSpawn; i++)
        {


            GameObject temp = Instantiate(_blood);
            temp.transform.position = new Vector3(Random.Range(_BloodSpawnLocation.bounds.min.x, _BloodSpawnLocation.bounds.max.x), 1.019f, Random.Range(_BloodSpawnLocation.bounds.min.z, _BloodSpawnLocation.bounds.max.z));

            float subtractedBloodFromPool = Random.Range(0.1f, amountOfBlood);
            amountOfBlood = amountOfBlood - subtractedBloodFromPool;

            if (i < numberOfGameObjectsToSpawn - 1)
            {
                temp.GetComponent<BloodStats>()._bloodAmount = subtractedBloodFromPool;
            }
            else
            {
                temp.GetComponent<BloodStats>()._bloodAmount = amountOfBlood + subtractedBloodFromPool;
            }


        }



    }
    public void checkToAddedBloodUI()
    {
        if (!isBleeding) return;
        UIForBlood.SetActive(true);
    }

    public void updateBloodAmount(float amountToAdd)
    {
        UIForBlood.GetComponent<Slider>().value += amountToAdd; 
    }

}
