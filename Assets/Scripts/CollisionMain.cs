using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public class CollisionMain : MonoBehaviour
{


    
    public MeshRenderer mesh;
    private Material material;
    private Color colorBuffer;
    private GameObject temp;
    private bool con;
    public GameObject start;
    public GameObject finish;



    // Start is called before the first frame update
    void Start()
    {

        mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
        con = true;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Stick 1" && con)
        {
            SoundController t = GameObject.Find("SoundController").GetComponent<SoundController>();
            t.PlaySound(1);
            start.SetActive(true);
            finish.SetActive(false);
            con = false;
            colorBuffer = material.color;
            temp = collision.gameObject;
            material.EnableKeyword("_EMISSION");
            material.color = material.color * 3.0f;
            Color a = material.color; 
            a.a = 1.0f;
        }
    }
        

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Stick 1" && !con)
        {
            SoundController t = GameObject.Find("SoundController").GetComponent<SoundController>();
            t.StopSound();
            con = true;
            material.DisableKeyword("_EMISSION");
            material.color = colorBuffer;
            Color a = material.color;
            a.a = 1.0f;
        }
        
    }

    

}
