using UnityEngine;
using System;
using UnityEngine.UI;


public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;//mouse z coordinate
    public int number;
    public Text numberOnCube;

    Singleton SingletonObject;

    void Start()
    {
        SingletonObject = Singleton.GetInstance();
        int[] arr = SingletonObject.blockPositionArray; //FindObjectOfType<GameManager>().blockPositionArray;


        number = arr[(int)transform.position.x + 3 * (int)transform.position.z];
        numberOnCube.text = number.ToString();

    }
        void OnMouseDown()
    {
        //number = GetComponent<ChangeNumber>().number;

        //mouse doesn't have z so we get the gameobject's z 
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPros();
    }

    private Vector3 GetMouseWorldPros()
    {
        //get position of mouse
        Vector3 mousePoint = Input.mousePosition;
        // give the z of gameobject to mouse point
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        Vector3 FinalPos = GetMouseWorldPros() + mOffset;
        FinalPos.y = 0;
        FinalPos.x = (float)Math.Round(FinalPos.x);
        FinalPos.z = (float)Math.Round(FinalPos.z);
        //GameManager gm = FindObjectOfType<GameManager>();
        

        //check to only move to the empty position
        if (FinalPos == SingletonObject.emptyPos)
        {
            SingletonObject.NumberOfMoves++;
            
            SingletonObject.emptyPos = transform.position;
            transform.position = FinalPos;
            SingletonObject.checkWinCondition();
        }
    }

}
