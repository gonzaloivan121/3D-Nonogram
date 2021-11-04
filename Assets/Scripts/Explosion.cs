using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private float cubeSize = 0.2f;
    public int cubesInRow = 5;
    private int _cubesInRow = 5;

    private float cubesPivotDistance;
    private Vector3 cubesPivot;

    public float explosionForce = 1f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public float explosionDuration = 1f;

    public GameObject prefab;

    void Start() {
        CalculatePivotDistance();
    }

    void Update() {
        CalculateDivisions();
    }

    private void CalculateDivisions() {
        if (_cubesInRow != cubesInRow) {
            _cubesInRow = cubesInRow;
            cubeSize = 1f / _cubesInRow;
        }
    }

    private void CalculatePivotDistance() {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    public void Explode() {
        for (int x = 0; x < cubesInRow; x++) {
            for (int y = 0; y < cubesInRow; y++) {
                for (int z = 0; z < cubesInRow; z++) {
                    CreateBrokenPiece(x, y, z);
                }
            }
        }

        EmitExplosion();
    }

    private void CreateBrokenPiece(int x, int y, int z) {
        GameObject piece = Instantiate(prefab, transform);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.transform.rotation = transform.localRotation;

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        piece.GetComponent<Renderer>().material.DOFade(0f, explosionDuration);
        piece.transform.DOScale(0f, explosionDuration);

        Destroy(piece, explosionDuration + .25f);
    }

    private void EmitExplosion() {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward, ForceMode.Impulse);
            }
        }
    }

}
