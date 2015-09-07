using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text score;
    public Text nextLevel;
    public GameObject door;

    private Rigidbody rb;
    private int count;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        nextLevel.text = "";
        UpdateScore();
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
            UpdateScore();
        } else if (other.gameObject.CompareTag ("Button"))
        {
            door.gameObject.SetActive(false);
        }
    }
    void UpdateScore()
    {
        score.text = "Score: " + count.ToString();
        if (count >= 4)
        {
            nextLevel.text = "You have beaten this level!";
        }
    }
}
