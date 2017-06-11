using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerchara : MonoBehaviour {
    public int _health;
    private float timetake;
    public Text endtext;
    public Text healthtext;
    public Text Killcount;
    public float kills;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip death;
    // Use this for initialization
    void Start () {
        _health = 5;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _health = 0;
        }
        string lives = _health.ToString();
        healthtext.text = lives + ": lives remaining";
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

}

    // Update is called once per frame
    public void Hurt (int damage) {
        _health -= damage;
        Debug.Log(" health: " + _health);
        if (_health <= 0)
        {
            float timetakea = Time.realtimeSinceStartup;
            timetake = Mathf.Round(timetakea);
            GameObject gun = GameObject.Find("Main Camera");
            float tiltAroundZ = Input.GetAxis("Horizontal") * 90;
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
            gunfromcamera guun = gun.GetComponent<gunfromcamera>();
            endtext.text = "YOU DIED!!! you last " + timetake + " seconds and killed " + kills + " ghosts.";
            soundSource.PlayOneShot(death);
            StartCoroutine(Die());
            _health = 0;
            playermove status = GetComponent<playermove>();
            wanderAI behavior = GetComponent<wanderAI>();
            chargerAI behaviora = GetComponent<chargerAI>();
            if (status != null)
            {
                status.SetAlivep(false);
            }
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }
            if (behaviora != null)
            {
                behaviora.SetAlive(false);
            }
        }

    }
    private IEnumerator Die()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("main menu");



    }

}
