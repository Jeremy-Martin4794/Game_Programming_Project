﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBulletCollisions : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Animator animatorEnemy = collision.gameObject.GetComponent<Animator>();
            collision.gameObject.GetComponent<EnemyMovement>().hurtCount += 1;
            if (collision.gameObject.GetComponent<EnemyMovement>().hurtCount >= 3)
            {
                if (!collision.gameObject.GetComponent<EnemyMovement>().deathSoundPlayed)
                {
                    collision.gameObject.GetComponent<EnemyMovement>().enemyDead.Play();
                    collision.gameObject.GetComponent<EnemyMovement>().deathSoundPlayed = true;
                }
                collision.gameObject.GetComponent<EnemyMovement>().isDead = true;
                animatorEnemy.SetBool("isDead", true);
                Destroy(collision.gameObject, 1);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyMovement>().enemyHurt.Play();
                animatorEnemy.SetBool("isHurt", true);
                collision.gameObject.GetComponent<EnemyMovement>().isHurt = true;
                collision.gameObject.GetComponent<EnemyMovement>().hurtTime = 60;
            }
            Destroy(gameObject);            
        }
    }
}
