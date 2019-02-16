using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicPins : MonoBehaviour
{
    private float gravity = 7f;

    public GameObject pin_bar;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0f, 0f, gravity);
        StartCoroutine(myCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }


    IEnumerator myCoroutine()
    {
        while (true)
        {
            Instantiate(pin_bar);
            yield return new WaitForSeconds(1f);
        }
        
    }


}
