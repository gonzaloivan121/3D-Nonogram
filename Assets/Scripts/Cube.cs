using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cube : MonoBehaviour {
    private bool canBreak = true;
    private bool isHurt = false;
    private bool gameOver = false;

    AudioSource audioSource;
    public AudioClip breakClip;
    public AudioClip wrongClip;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Break() {
        if (!isHurt) {
            if (canBreak) {
                audioSource.Play();
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            } else {
                LooseLife();
                Shake(1f, .025f);
            }
        } else {
            Shake(1f, .025f);
        }
    }

    void LooseLife() {
        audioSource.clip = wrongClip;
        audioSource.Play();
        ChangeColor(Color.red);
        SendLooseLifeToGame();
        isHurt = true;
    }

    void SendLooseLifeToGame() {
        GameObject go = GameObject.Find("Game");
        Game game = go.GetComponent<Game>();
        game.LooseLife();
    }

    void ChangeColor(Color color) {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Shake(float duration, float strength) {
        transform.DOShakePosition(duration, strength);
    }

    void OnMouseDown() {
        if (!gameOver) {
            Break();
        }
    }

    public void SetGameOver() {
        gameOver = true;
    }

    public void SetCanBreak(bool b) {
        canBreak = b;
    }

}
