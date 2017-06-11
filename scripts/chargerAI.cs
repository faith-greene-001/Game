using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargerAI : MonoBehaviour {
    private Transform ttarget = null;
    public bool _aalive;
    private float spedd;
    public float obstacleRange = 5.0f;
    public int damage = 1;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private  AudioClip boo;
    // Use this for initialization
    void Start () {
        _aalive = true;
        float spedd = 3 * Time.deltaTime;
}
    void OnTriggerEnter(Collider other)
    {
        if (_aalive)
        {
            playerchara player = other.GetComponent<playerchara>();

            if (player != null)
            {
                player.Hurt(damage);
            }
            ReactiveTarget ttarget = GetComponent<ReactiveTarget>();
            ttarget.ReactToHit();
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (_aalive)
        {
            spedd = 5 * Time.deltaTime;
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, .75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hit.distance < obstacleRange)
                {
                    if (hitObject.GetComponent<playerchara>())
                    {
                        soundSource.PlayOneShot(boo);
                        spedd = 7 * Time.deltaTime;
                    }
                    else
                    {
                        spedd = 5 * Time.deltaTime;
                        float tangle = Random.Range(-110, 110);
                        transform.Rotate(0, tangle, 0);
                    }

                }

            }

            transform.Translate(0, 0, spedd);
            if (transform.position.x > 15 || transform.position.x < -15 || transform.position.z > 15 || transform.position.z < -15)
            {
                Destroy(this.gameObject);
                _aalive = false;
            }
        }
    }
    
public void SetAlive(bool alive)
{
    _aalive = alive;
}
}
    
