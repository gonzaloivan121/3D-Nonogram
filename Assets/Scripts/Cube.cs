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

    private Game game;
    private Renderer matRenderer;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        game = GameObject.Find("Game").GetComponent<Game>();
        matRenderer = gameObject.GetComponent<Renderer>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    public void Break() {
        if (!isHurt) {
            if (canBreak) {
                audioSource.Play();
                meshRenderer.enabled = false;
                boxCollider.enabled = false;
                game.BreakCube();
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
        game.LooseLife();
    }

    void ChangeColor(Color color) {
        matRenderer.material.color = color;
    }

    void Shake(float duration, float strength) {
        transform.DOShakePosition(duration, strength);
    }

    void OnMouseDown() { if (!gameOver) Break(); }
    public void SetGameOver() { gameOver = true; }
    public void SetCanBreak(bool b) { canBreak = b; }
    public void Win() { SetGameOver(); ChangeColor(Color.green); }
}
