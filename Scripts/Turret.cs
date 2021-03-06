using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public GameObject bullet;
    GameObject turret;
    private int timer = 100;
    private Vector3 bullet_pos;
    public AudioSource AudioSource;
    public AudioClip fire;
    // Use this for initialization
    void Start () {
        AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer--;
        spawnBullet();

    }
    // spawn the bullet
    void spawnBullet()
    {
        if (timer == 0)
        { 
        bullet_pos = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, 0f);
        Instantiate(bullet, bullet_pos, this.transform.rotation);
            AudioSource.PlayOneShot(fire);
            timer = 100;
        }
    }
}
