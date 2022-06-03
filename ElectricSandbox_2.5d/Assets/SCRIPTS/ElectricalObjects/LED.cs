using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : ElectricObject
{
    public GameObject cube;

    //public new GameObject[] inputs;
    //public new GameObject[] outputs;
    public bool sent = false;
    //public new Tags tag = Tags.LED;
    // Start is called before the first frame update
    void Start()
    {
        tags = Tags.LED;

        cube.GetComponent<Renderer>().material.color = Color.black;
    }
    public override void sendElectricityTick()
    {
        Debug.Log("LED TICK");
        sent = true;
        for (int i = 0; i < outputs.Count; i++)
        {
            ElectricObject e = outputs[i].GetComponent<ElectricObject>();
            if (e != null)
            {
                e.sendElectricityTick();
            }
        }
    }

    public void turnOn()
    {
        cube.GetComponent<Renderer>().material.color = Color.white;
    }
    public void turnOff()
    {
        cube.GetComponent<Renderer>().material.color = Color.black;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void showOutput()
    {
        if (sent)
        {
            turnOn();
        }
        else { turnOff(); }

        sent = false;

        Debug.Log("show output");
    }

    private void LateUpdate()
    {
       // sent = false;
    }
}
