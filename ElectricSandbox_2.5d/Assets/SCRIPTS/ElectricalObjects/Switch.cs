using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : ElectricObject
{
    public GameObject onLever;
    public GameObject offLever;
    //public new GameObject[] inputs;
    //public new GameObject[] outputs;
    //public new Tags tag = Tags.SWITCH;

    private bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        tags = Tags.SWITCH;
        toggleState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void showOutput()
    { }
    public override void sendElectricityTick()
    {
        if (state)
        {
            for (int i = 0; i < outputs.Count; i++)
            {
                ElectricObject e = outputs[i].GetComponent<ElectricObject>();
                if (e != null)
                {
                    e.sendElectricityTick();
                }
            }
        }
    }

    public void toggleState()
    {
        if (state)
        {
            onLever.SetActive(false);
            offLever.SetActive(true);
            state = false;
        }
        else
        {
            onLever.SetActive(true);
            offLever.SetActive(false);
            state = true;
        }
    }
}
