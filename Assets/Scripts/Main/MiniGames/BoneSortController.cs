using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSortController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] gameFail;
    public int numberOfBonesToSpawn;

    public BoxCollider2D boneSpawn;

    public GameObject bone;
    public List<string> boneStringCheck;

    public List<GameObject> BoneList;

    public GameObject gameController;
    void Start()
    {
        gameController = GameObject.Find("GameController");
        int tempNum = Random.Range(0, 4);

        switch (tempNum)
        {
            case 0:
                numberOfBonesToSpawn = 4;
                boneStringCheck.Add("A");
                boneStringCheck.Add("B");
                boneStringCheck.Add("D");
                boneStringCheck.Add("F");

                break;
            case 1:
                numberOfBonesToSpawn = 4;
                boneStringCheck.Add("B");
                boneStringCheck.Add("B");
                boneStringCheck.Add("C");
                boneStringCheck.Add("E");

                break;
            case 2:
                numberOfBonesToSpawn = 3;
                boneStringCheck.Add("A");
                boneStringCheck.Add("C");
                boneStringCheck.Add("F");
                break;
            case 3:
                numberOfBonesToSpawn = 3;
                boneStringCheck.Add("B");
                boneStringCheck.Add("C");
                boneStringCheck.Add("D");
                break;
            default:
                break;
        }




        gameFail = new bool[numberOfBonesToSpawn];
        for (int i = 0; i < numberOfBonesToSpawn; i++)
        {
            gameFail[i] = false;
        }
        spawnBones();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void completeGame()
    {
        bool checkIfResultNeedToOpen = true;

        for (int i = 0; i < numberOfBonesToSpawn; i++)
        {
            if (BoneList[i].GetComponent<boneObjectScript>().currentBox != boneStringCheck[i])
            {
                Debug.Log(BoneList[i].GetComponent<boneObjectScript>().currentBox + boneStringCheck[i]);
                //GameObject.Find("GameController").GetComponent<GameControllerScript>().changeHealth(-1);
                gameController.GetComponent<MiniGameResultScript>().OpenResultsUI(false);
                checkIfResultNeedToOpen = false;
                
                break;
            }


        }
        if (checkIfResultNeedToOpen)
        {
            gameController.GetComponent<MiniGameResultScript>().OpenResultsUI(true);
        }

        Destroy(this.gameObject);
    }


    private void spawnBones()
    {
        for (int i = 0; i < numberOfBonesToSpawn; i++)
        {
            GameObject temp = Instantiate(bone, this.transform);
            temp.gameObject.transform.position = new Vector3(Random.Range(boneSpawn.bounds.min.x, boneSpawn.bounds.max.x), Random.Range(boneSpawn.bounds.min.y, boneSpawn.bounds.max.y), 0.0f);
            BoneList.Add(temp);
            temp.GetComponent<boneObjectScript>().changeText((i + 1).ToString());
        }

    }
}
