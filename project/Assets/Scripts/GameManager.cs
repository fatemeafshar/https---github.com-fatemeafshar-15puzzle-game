using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject complete;
    public Button RestartButton;
    public float Delay = 0.001f;
    Singleton SingletonObject;
    public int blockNumber=3;

    void Start()
    {
        SingletonObject = Singleton.GetInstance(); 
        
        InitializeBlocks();
        ShuffleBlocks();
        complete.SetActive(false);
        Button btn = RestartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Invoke("Restart", Delay);
        
    }


    void InitializeBlocks()
    {
        SingletonObject.blocks.Clear();
        for (int y = 0; y < blockNumber; ++y)
        {
            for (int x = 0; x < blockNumber; ++x)
            {
                if(x!=2 || y!=2)
                {
                    var newBlock = Instantiate(blockPrefab, new Vector3(x , 0 , y), Quaternion.identity);
                    SingletonObject.blocks.Add(newBlock.GetComponent<Drag>());
                }
            }
        }

        SingletonObject.emptyPos = new Vector3(2.0f, 0.0f, 2.0f);
    }

    void ShuffleBlocks()
    {
        int n = SingletonObject.blockPositionArray.Length;
        System.Random r = new System.Random();

        for (int i = n - 1; i > 0; i--)
        {

            int j = r.Next(0, i + 1);

            // Swap arr[i] with the
            // element at random index
            int temp = SingletonObject.blockPositionArray[i];
            SingletonObject.blockPositionArray[i] = SingletonObject.blockPositionArray[j];
            SingletonObject.blockPositionArray[j] = temp;
        }
    }

    
    public void Win()
    {
        Debug.Log("win");
        complete.SetActive(true);
       // Invoke("Restart", 3f);// restartDelay);
    }
    void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
