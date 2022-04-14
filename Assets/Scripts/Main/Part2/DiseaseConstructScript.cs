using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public GameObject UIGameObject;
    public TextMeshProUGUI titletext;
    public List<GameType> gameOrderNeedToPlay;
    //public List<GameType> playersGameList;

    private int gameCounter;

    [Header("Stuff To Spawn")]
    public bool isBleeding;
    public GameObject _blood;
    
    public bool _isKnife;
    public GameObject _Knife;

    public bool hitByCar;
    public GameObject _car;

    public bool wasShoot;
    public GameObject _Gun;

    public List<Transform> _itemSpawns;

    public BoxCollider _BloodSpawnLocation;
    public float amountOfBlood;
    public GameObject UIForBlood;

    public Animator animator;
    public int whichGameSet;
    // Start is called before the first frame update
    void Start()
    {
        whichGameSet = Random.Range(0, diseasesNames.Count);
        gameCounter = 0;
        switch (whichGameSet)
        {
            case 0:
                fillOutPath(whichGameSet, GameType.BacteriaKiller, GameType.PillMixer, GameType.CutOpen);
                animator.SetInteger("AnimationPattern", 0);
                
                isBleeding = true;
                _isKnife = false;
                hitByCar = true;
                wasShoot = false;

                break;
            case 1:
                fillOutPath(whichGameSet, GameType.BoneSort, GameType.CutOpen, GameType.PillMixer);
                animator.SetInteger("AnimationPattern", 1);


                isBleeding = true;
                _isKnife = true;
                hitByCar = false;
                wasShoot = false;
                break;
            case 2:
                fillOutPath(whichGameSet, GameType.PillMixer, GameType.BacteriaKiller, GameType.BoneSort);
                animator.SetInteger("AnimationPattern", 2);

                isBleeding = false;
                hitByCar = false;
                _isKnife = false;
                wasShoot = true;
                break;
            case 3:
                fillOutPath(whichGameSet, GameType.CutOpen, GameType.BoneSort, GameType.BacteriaKiller);
                animator.SetInteger("AnimationPattern", 3);

                isBleeding = true;
                hitByCar = false;
                _isKnife = false;
                wasShoot = true;
                break;
            default:
                break;
        }

        bloodSpawning();
        itemSpawning(_itemSpawns[0], _Gun, wasShoot);
        itemSpawning(_itemSpawns[1], _car, hitByCar);
        itemSpawning(_itemSpawns[2], _Knife, _isKnife);

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

    public bool checkIfRightGameWasPlayed(GameType currentGame)
    {
        //if (gameOrderNeedToPlay[gameCounter] != currentGame)
        //{
        //    GetComponent<GameControllerScript>().changeHealth(-1);
        //}

        gameCounter++;
        
        return gameOrderNeedToPlay[gameCounter - 1] == currentGame;
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

    private void itemSpawning(Transform placement, GameObject itemToSpawn, bool check)
    {
        if (!check) return;
        GameObject temp = Instantiate(itemToSpawn);
        temp.transform.position = placement.position;
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
