﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text score;
    public Text nextLevel;

    private Rigidbody rb;
    private int count;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        nextLevel.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
        }
    }
    void UpdateScore()
    {
        score.text = "Score: " + count.ToString();
    }
}
