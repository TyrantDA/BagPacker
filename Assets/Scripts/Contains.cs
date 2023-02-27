using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contains : MonoBehaviour
{

    public Packer Packer;

    public Text contained;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        int[] points = Packer.GetPoints();
        contained.text = "Potion : " + points[0] + " Sword : " + points[1];
    }
}
