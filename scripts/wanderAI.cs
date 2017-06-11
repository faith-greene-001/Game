using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderAI : MonoBehaviour {
    [SerializeField] private GameObject firebalPrefab;
    private GameObject _fireball;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip die;
    public float speed = 5.0f;
    public float obstacleRange = 5.0f;
    // Use this for initialization
    public bool _alive;
    void Start()
    {
        _alive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, .75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hit.distance < obstacleRange)
                {
                    if (hitObject.GetComponent<playerchara>())
                    {
                        if (_fireball == null)
                        {
                            soundSource.PlayOneShot(die);
                            _fireball = Instantiate(firebalPrefab) as GameObject;
                            _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            _fireball.transform.rotation = transform.rotation;
                        }
                    }
                    else
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }


            }
            if (transform.position.x > 15 || transform.position.x < -15 || transform.position.z > 15 || transform.position.z < -15)
            {
                Destroy(this.gameObject);
                _alive = false;
            }
        }
    }
        
    
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
