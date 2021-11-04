using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cube : MonoBehaviour {
    private bool canBreak = true;
    private bool isHurt = false;
    private bool gameOver = false;
    private bool breakMode = true;
    private bool frozen = false;

    public float shakeTime = .25f;
    public float shakeForce = .025f;

    AudioSource audioSource;
    public AudioClip breakClip;
    public AudioClip wrongClip;
    public AudioClip freezeClip;
    public AudioClip unfreezeClip;

    public Color failColor;
    public Color frozenColor;
    public Color winColor;

    private Game game;
    private Renderer matRenderer;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private Color originalColor;
    private Explosion explosionManager;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        game = GameObject.Find("Game").GetComponent<Game>();
        matRenderer = gameObject.GetComponent<Renderer>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        explosionManager = gameObject.GetComponent<Explosion>();
        originalColor = matRenderer.material.color;
    }

    public void Break() {
        if (!isHurt) {
            if (canBreak) {
                BreakSequence();
            } else {
                LooseLife();
                Shake(shakeTime, shakeForce);
            }
        } else {
            Shake(shakeTime, shakeForce);
        }
    }

    private void BreakSequence() {
        PlaySound(breakClip);
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        game.BreakCube(this);
        explosionManager.Explode();
    }

    private void PlaySound(AudioClip a) {
        if (audioSource.clip != a) {
            audioSource.clip = a;
        }
        audioSource.Play();
    }

    public void Unbreak() {
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
        isHurt = false;
    }

    void LooseLife() {
        audioSource.clip = wrongClip;
        audioSource.Play();
        ChangeColor(failColor);
        SendLooseLifeToGame();
        isHurt = true;
    }

    void SendLooseLifeToGame() {
        game.LooseLife();
    }

    void ChangeColor(Color color) {
        originalColor = matRenderer.material.color;
        matRenderer.material.color = color;
    }

    void Shake(float duration, float strength) {
        transform.DOShakePosition(duration, strength);
    }

    void Freeze() {
        Shake(shakeTime, shakeForce);
        if (!frozen) {
            PlaySound(freezeClip);
            SetFrozen(true);
            ChangeColor(frozenColor);
        } else {
            PlaySound(unfreezeClip);
            SetFrozen(false);
            ChangeColor(originalColor);
        }
    }

    void OnMouseDown() {
        if (!gameOver && breakMode && !frozen) {
            Break();
        } else if (!gameOver && !breakMode) {
            Freeze();
        }
    }

    public void ChangeGameMode(bool value) { breakMode = value; }
    public void SetGameOver() { gameOver = true; }
    public void SetFrozen(bool b) { frozen = b; }
    public void SetCanBreak(bool b) { canBreak = b; }
    public void Win() { SetGameOver(); ChangeColor(winColor); }
}
