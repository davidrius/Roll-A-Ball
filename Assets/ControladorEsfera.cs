using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControladorEsfera : MonoBehaviour
{
    public float speed;
    private int count;
    public Text texto;
    
    public Text winText;

    void Start()
    {
        count = 0;
        counter();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "pickup")
        {
            Destroy(other.gameObject);
            count++;
            counter();
        }

    }

    void counter()
    {

        texto.text = "Puntos: " + count;
        
        int numPickups;

        numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;
        
        if(numPickups == 1){

            winText.text = "!Has ganado!";

        }

    }


}
