using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public Transform mainCam;
    public Transform firePosition;
    public GameObject bullet;

    public Text stateText;
    public int HP;
    public int score;

    public AudioClip fireSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        HP = 50;
        score = 0;
        UpdateState();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        firePosition.rotation = mainCam.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (HP <= 0)
        {
            StartCoroutine(RestartGame());
        }
    }

    void Fire()
    {
        Instantiate(bullet, firePosition.position, firePosition.rotation);
        audioSource.PlayOneShot(fireSound);
    }

    public void UpdateState()
    {
        stateText.text = "Score\n" + score + "\nHP\n" + HP;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
