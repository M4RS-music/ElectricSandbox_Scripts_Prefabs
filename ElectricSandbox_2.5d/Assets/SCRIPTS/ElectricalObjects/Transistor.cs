using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transistor : ElectricObject
{
    public bool gate;
    //public new Tags tag = Tags.TRANSISTOR;
    // Start is called before the first frame update
    void Start()
    {
        tags = Tags.TRANSISTOR;
    }
    public void setGateOnTick()
    {
        gate = true;
    }
    public override void showOutput()
    { }
    public override void sendElectricityTick()
    {
        if (!gate)
        {
            setGateOnTick();
        }
        else if (gate)
        {
            gate = false;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
