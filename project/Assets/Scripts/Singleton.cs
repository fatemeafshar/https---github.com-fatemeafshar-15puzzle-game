using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Singleton 
{
    private Singleton() { }
    private static Singleton _instance;

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
            _instance.blocks = new List<Drag>();

        }
        return _instance;
    }

    public int[] blockPositionArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
    public Vector3 emptyPos;
    public List<Drag> blocks;
    public int NumberOfMoves=0;
    public bool checkWinCondition()
    {
        int numberOfCorrectCubes = 0;
        //List<Drag> results = new List<Drag>();
        //Drag[] allObjsAry = Resources.FindObjectsOfTypeAll(typeof(Drag)) as Drag[];

        for (var i = 0; i < blocks.Count; ++i)
        {
            int number = blocks[i].number;
            int x = (int)blocks[i].transform.position.x;
            int y = (int)blocks[i].transform.position.z;
            switch (number)
            {
                case 1:
                    if (x == 0 && y == 2) numberOfCorrectCubes++;
                    break;
                case 2:
                    if (x == 1 && y == 2) numberOfCorrectCubes++;
                    break;
                case 3:
                    if (x == 2 && y == 2) numberOfCorrectCubes++;
                    break;
                case 4:
                    if (x == 0 && y == 1) numberOfCorrectCubes++;
                    break;
                case 5:
                    if (x == 1 && y == 1) numberOfCorrectCubes++;
                    break;
                case 6:
                    if (x == 2 && y == 1) numberOfCorrectCubes++;
                    break;
                case 7:
                    if (x == 0 && y == 0) numberOfCorrectCubes++;
                    break;
                case 8:
                    if (x == 1 && y == 0) numberOfCorrectCubes++;
                    break;
                default:
                    break;
            }
        }
        Debug.Log(numberOfCorrectCubes);
        if (numberOfCorrectCubes == 8)
        {
            Debug.Log("win");
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.Win();
        }
        return false;
    }


}
