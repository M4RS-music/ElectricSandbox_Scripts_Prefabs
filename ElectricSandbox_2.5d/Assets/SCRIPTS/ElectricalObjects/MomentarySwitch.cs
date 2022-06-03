using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentarySwitch : ElectricObject
{
    public GameObject buttonTop;

    //public new GameObject[] inputs;
    //public new GameObject[] outputs;
    //public new Tags tag = Tags.MSWITCH;
    // Start is called before the first frame update
    void Start()
    {
        tags = Tags.MSWITCH;
    }
    public override void showOutput()
    { }
    public void toggleState()
    {
        buttonTop.SetActive(!buttonTop.activeSelf);
    }
    public override void sendElectricityTick()
    {
        if (!buttonTop.activeSelf)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
