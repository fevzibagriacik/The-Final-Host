using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardSelfUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UIObject;
    private void Start()
    {
        UIObject.gameObject.transform.position=gameObject.GetComponentInChildren<referance>().positionn;
    }
    public void makeInvisible()
    {
        UIObject.SetActive(false);
        
    }
    public void makeVisible()
    {
        UIObject.SetActive(true);
        Debug.Log("worked");
    }
}
