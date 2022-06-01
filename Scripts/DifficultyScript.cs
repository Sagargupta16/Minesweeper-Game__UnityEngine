using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    public static bool a ;
    public static bool b ;
    public static bool c ;

    // Start is called before the first frame update
    void Start()
    {
        a = false;
        b = false;
        c = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HardButton()
    {
        a = true ;
    }
    public void MediumButton()
    {
        b = true;
    }
    public void EasyButton()
    {
        c = true;
    }

}
