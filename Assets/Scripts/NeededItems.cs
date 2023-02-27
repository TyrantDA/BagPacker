using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeededItems : MonoBehaviour
{
    public Packer Packer;
    public Text needed;
    // Update is called once per frame
    void Update()
    {
        int[] complete = Packer.GetComplete();
        needed.text = " Needed Potion : " + complete[0] + "  Sword : " + complete[1];
    }
}
