using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControler : MonoBehaviour {
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private GameObject EnenyPrefab;
    private GameObject _enemy;
    private GameObject _enemy1;
    private GameObject _enemy2;
    private float start;
    private float starta;
    private float startb;

	
	// Update is called once per frame
	void Update () {
        start = Random.Range(0, 6);
        starta = Random.Range(0, 6);
        startb = Random.Range(0, 6);
        if (_enemy== null)
        {
            _enemy = Instantiate(targetPrefab) as GameObject;

            if (start <= 1 && start >= 0)
            {
                _enemy.transform.position = new Vector3(13, 1, 13);
            }
            if (start <= 2 && start > 1)
            {
                _enemy.transform.position = new Vector3(13, 1, -13);
            }
            if (start <= 3 && start > 2)
            {
                _enemy.transform.position = new Vector3(-13, 1, 13);
            }
            if (start <= 4 && start > 3)
            {
                _enemy.transform.position = new Vector3(-13, 1, -13);
            }
            if (start <= 5 && start > 4)
            {
                _enemy.transform.position = new Vector3(1, 1, -13);
            }
            if (start <= 6 && start > 5)
            {
                _enemy.transform.position = new Vector3(-13, 1, 1);
            }
            if (start > 6 || start < 0)
            {
                _enemy.transform.position = new Vector3(13, 1, 13);
            }
        }
        if (_enemy1 == null)
        {
            _enemy1 = Instantiate(EnenyPrefab) as GameObject;
            if (starta <= 1 && starta >= 0)
            {
                _enemy1.transform.position = new Vector3(13, 1, 13);
            }
            if (starta <= 2 && starta > 1)
            {
                _enemy1.transform.position = new Vector3(13, 1, -13);
            }
            if (starta <= 3 && starta > 2)
            {
                _enemy1.transform.position = new Vector3(-13, 1, 13);
            }
            if (starta <= 4 && starta > 3)
            {
                _enemy1.transform.position = new Vector3(-13, 1, -13);
            }
            if (starta <= 5 && starta > 4)
            {
                _enemy1.transform.position = new Vector3(1, 1, -13);
            }
            if (starta <= 6 && starta > 5)
            {
                _enemy1.transform.position = new Vector3(-13, 1, 1);
            }
            if (starta > 6 || starta < 0)
            {
                _enemy1.transform.position = new Vector3(13, 1, 13);
            }
        }
        if (_enemy2 == null)
        {
            _enemy2 = Instantiate(EnenyPrefab) as GameObject;
            if (startb <= 1 && startb >= 0)
            {
                _enemy2.transform.position = new Vector3(13, 1, 13);
            }
            if (startb <= 2 && startb > 1)
            {
                _enemy2.transform.position = new Vector3(13, 1, -13);
            }
            if (startb <= 3 && startb > 2)
            {
                _enemy2.transform.position = new Vector3(-13, 1, 13);
            }
            if (startb <= 4 && startb > 3)
            {
                _enemy2.transform.position = new Vector3(-13, 1, -13);
            }
            if (startb <= 5 && startb > 4)
            {
                _enemy2.transform.position = new Vector3(1, 1, -13);
            }
            if (startb <= 6 && startb > 5)
            {
                _enemy2.transform.position = new Vector3(-13, 1, 1);
            }
            if (startb > 6 || startb < 0)
            {
                _enemy2.transform.position = new Vector3(13, 1, 13);
            }
        }
    }
}
