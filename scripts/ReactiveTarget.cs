using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private AudioClip death;
    // Use this for initialization
    public void ReactToHit() {
        wanderAI behavior = GetComponent<wanderAI>();
        chargerAI behaviora = GetComponent<chargerAI>();
        playerchara player = GetComponent<playerchara>();
        StartCoroutine(Die());
        soundSource.PlayOneShot(death);
        if (behavior!= null)
        {
            behavior.SetAlive(false);
            if (behavior._alive)
            {
                player.kills += 1;
            }
        }
        if (behaviora != null)
        {
            behaviora.SetAlive(false);
            if (behaviora._aalive) {
                player.kills += 1;
        }

        }
    }
    // Update is called once per frame
    private IEnumerator Die() {
        this.transform.Rotate(-90, -0.5f, 0);
        Vector3 position = this.transform.position;
        position.y -= 4;
        this.transform.position = position;
        yield return new WaitForSeconds(1.1f);
        Destroy(this.gameObject);
  

	}
    public void Update()
    {

    }
}
