using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleController : MonoBehaviour
{
    public Camera theCam;
    private GameObject temp;
    private GameObject box1, box2, box3;
    public Sprite face1, face2, face3, face4, face5, face6, face7;
    private bool controler;
    private GameObject newObj;

    // Billboard
    void Start()
    {
        controler = true;
        box1 = GameObject.Find("box1");
        box2 = GameObject.Find("box2");
        box3 = GameObject.Find("box3");
        //box4 = GameObject.Find("box4");

        box1.SetActive(false);
        box2.SetActive(false);
        box3.SetActive(false);
        //box4.SetActive(false);


        //mad(1);
        //surprised(2);
        //happy(3);
        //pokerFace(4);
        //randomMad();





    }

    public void randomMad()
    {
        int temp = Random.Range(0, 2);
        for(int x = 1; x < 4; x++)
        {
            if (temp == 1)
            {
                mad(x);
            }
            temp = Random.Range(0, 2);
        }
    }
    public void randomSurprised()
    {
        int temp = Random.Range(0, 2);
        for (int x = 1; x < 4; x++)
        {
            if (temp == 1)
            {
                surprised(x);
            }
            temp = Random.Range(0, 2);
        }
    }
    public void randomHappy()
    {
        int temp = Random.Range(0, 2);
        for (int x = 1; x < 4; x++)
        {
            if (temp == 1)
            {
                happy(x);
            }
            temp = Random.Range(0, 2);
        }
    }
    public void randomPokerFace()
    {
        int temp = Random.Range(0, 2);
        for (int x = 1; x < 4; x++)
        {
            if (temp == 1)
            {
                pokerFace(x);
            }
            temp = Random.Range(0, 2);
        }
    }

    public void mad(int bb)
    {
        creatBuble(bb,4);
    }
    public void surprised(int bb)
    {
        creatBuble(bb, 1); 
    }
    public void happy(int bb)
    {
        creatBuble(bb, 2); 
    }
    public void pokerFace(int bb)
    {
        creatBuble(bb, 6); 
    }





    public void creatBuble(int local, int tipo)
    {
        if (controler)
        {
            //controler = false;
            Sprite temp = face1; 

            if (tipo == 1)
            {
                temp = face1;
            }
            else if (tipo == 2)
            {
                temp = face2;
            }
            else if (tipo == 3)
            {
                temp = face3;
            }
            else if (tipo == 4)
            {
                temp = face4;
            }
            else if (tipo == 5)
            {
                temp = face5;
            }
            else if (tipo == 6)
            {
                temp = face6;
            }
            else if (tipo == 7)
            {
                temp = face7;
            }

            newObj = new GameObject("face");
            SpriteRenderer renderer = newObj.AddComponent<SpriteRenderer>();
            renderer.sprite = temp;
            newObj.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);

            if (local == 1)
            {
                box1.SetActive(true);
                newObj.transform.SetParent(box1.transform);
                newObj.transform.position = box1.transform.position;
                newObj.transform.rotation = box1.transform.rotation;

            }
            else if (local == 2)
            {
                box2.SetActive(true);
                newObj.transform.SetParent(box2.transform);
                newObj.transform.position = box2.transform.position;
                newObj.transform.rotation = box2.transform.rotation;
            }
            else if (local == 3)
            {
                box3.SetActive(true);
                newObj.transform.SetParent(box3.transform);
                newObj.transform.position = box3.transform.position;
                newObj.transform.rotation = box3.transform.rotation;
            }


            float delay = 5f;
            //SoundController t = GameObject.Find("SoundController").GetComponent<SoundController>();
            //t.PlaySound(11);
            Invoke("Endbuble", delay);
        }
        
    }

    private void Endbuble()
    {
        Destroy(newObj,0.0F);
        try
        {
            box1.SetActive(false);
            
        }
        catch
        {

        }
        try
        {
            box2.SetActive(false);

        }
        catch
        {

        }
        try
        {
            box3.SetActive(false);

        }
        catch
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        box1.GetComponent<Transform>().LookAt(theCam.transform);
        box2.GetComponent<Transform>().LookAt(theCam.transform);
        box3.GetComponent<Transform>().LookAt(theCam.transform);

    }
}
