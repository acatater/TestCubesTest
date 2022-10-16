using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Xpos" + name) && PlayerPrefs.HasKey("Ypos" + name))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("Xpos" + name), PlayerPrefs.GetFloat("Ypos" + name), 0) ;
        }
    }

    // Update is called once per frame
    public void Save()
    {
        PlayerPrefs.SetFloat("Xpos" + name, transform.position.x);
        PlayerPrefs.SetFloat("Ypos" + name, transform.position.y);
    }
}
