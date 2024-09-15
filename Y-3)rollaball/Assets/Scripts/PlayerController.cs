using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//by Alex Bowes : SN : C00287604
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;//reference to rigid body in unity

    private int Count;

    private float movementx;
    private float movementy;

    public float Speed = 0;
    public TextMeshProUGUI count_text;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementx = movementVector.x;
        movementy = movementVector.y;

        Debug.Log("Received input: ");
    }

    void SetCountText()
    {
        count_text.text = "Count : " + Count.ToString();
        if (Count >= 19) { 
            winTextObject.SetActive (true);
        }
            

    }

  private void FixedUpdate()
  {
        Vector3 movement = new Vector3 (movementx, 0.0f,movementy);
        Debug.Log("Received speed = " + movement);
        rb.AddForce(movement * Speed);
  }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
     
    }
}
