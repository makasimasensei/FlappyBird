using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird_Control : MonoBehaviour
{
    public TMP_Text text;
    Rigidbody2D rb;
    bool inputEnable = true;
    int score;
    GameObject pipe;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pipe = GameObject.Find("Pipe");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&inputEnable)
        {
            rb.velocity = new Vector2(0, 3f);
            Vector3 angle = transform.eulerAngles;
            angle.z = 25f;
            transform.eulerAngles = angle;
        }
    }

    private void FixedUpdate()
    {
        Vector3 ang = transform.eulerAngles;
        if (ang.z >= 335f || ang.z <= 25f) ang.z -= 1f;
        transform.eulerAngles = ang;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pipe") || collision.collider.CompareTag("Land"))
        {
            inputEnable = false;
            Invoke(nameof(Restart), 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Score_Area"))
        {
            score += 1;
            text.text = "Score:" + score.ToString();
            Pipe_Control pc = pipe.GetComponent<Pipe_Control>();
            pc.score = score;
        }
    }


    private void Restart()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
