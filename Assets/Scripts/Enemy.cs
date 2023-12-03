using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Emeny Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;

    [Header("Shoot Settings")]
    [SerializeField] GameObject projectile;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShot = 0.2f;
    [SerializeField] float maxTimeBetweenShot = 3f;
    [SerializeField] float projectileSpeed = 10f;

    [Header("SFX")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 0.5f;

    [SerializeField] AudioClip deathSFX;
    [SerializeField][Range(0, 1)] float deathSFXVolume = 0.7f;

    [SerializeField] AudioClip shootSound;
    [SerializeField][Range(0, 1)] float shootSoundVolume = 0.2f;





    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);
        }
    }
    private void Fire()
    {
        GameObject laser = Instantiate(projectile, transform.position,Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);

    }
}
