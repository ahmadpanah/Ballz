
using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteReneder {get; private set;}
    public Sprite[] states = new Sprite[0];
    public int health {get; private set;}
    public bool unbreakable;

    public int points = 100;

    private void Awake(){
        this.spriteReneder = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (!this.unbreakable) {
            health = states.Length;
            this.spriteReneder.sprite = this.states[this.health - 1];
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name == "Ball") {
            Hit();
        }
    }

    private void Hit()
    {
        if (this.unbreakable){
            return;
        }

        health--;
        if (this.health <= 0) {
            this.gameObject.SetActive(false);
        } else {
            this.spriteReneder.sprite = this.states[this.health - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);
    }
}
