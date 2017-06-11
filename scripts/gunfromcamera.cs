using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class gunfromcamera : MonoBehaviour {
    private Camera _camera;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip laser;
    LineRenderer laserline;
    Light gunlight;
    Ray ray;
    GameObject hitObject;
    public float obstacleRange = 8.0f;
    public Text Killtext;
    public int killcount = 0;
    public float timer;

    // Use this for initialization
    void Start () {
        _camera = GetComponent<Camera>();
        laserline = GetComponent<LineRenderer>();
        gunlight = GetComponent<Light>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
        if (timer >= .1f)
        {
           
            gunlight.enabled = false;
            laserline.enabled = false;
        }
        Killtext.text = "Kill Count: " + killcount;
    }

    private void shoot()
    {
  //      Ray ray = _camera.ScreenPointToRay(point);
        timer = 0f;
        ray.origin = transform.position;
        ray.direction = transform.forward;
        laserline.enabled = true;
        laserline.SetPosition(0, transform.position);
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, obstacleRange))
        {
            GameObject hitObject = hit.transform.gameObject;
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                soundSource.PlayOneShot(laser);
            
            laserline.SetPosition(1, hit.point);
            if (target != null)
            {
                target.ReactToHit();
                killcount += 1;
            }
        }
    }

private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(0.2f);
        Destroy(sphere);
    }
}
