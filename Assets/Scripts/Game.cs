using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour {

    [Range(1, 10)] public int width;
    [Range(1, 10)] public int height;
    [Range(1, 10)] public int depth;
    public GameObject cube;
    public GameObject pivot;
    private GameObject[,,] cubes;
    private int[][] shape;

    public int life = 3;
    [Range(1, 2)] public int level = 1;
    private int actualLevel = 1;

    public bool test = false;

    // Start is called before the first frame update
    void Start() {
        if (test) {
            LoadLevel(0);
        } else {
            LoadLevel(level);
        }
    }

    // Update is called once per frame
    void Update() {
        if (level != actualLevel) {
            LoadLevel(level);
        }
    }

    public void LooseLife() {
        if (life > 0) { life--; } else { LooseGame(); };
    }

    void LooseGame() {
        print("You Loose!");
        for (var x = 0; x < width; x++) {
            for (var y = 0; y < height; y++) {
                for (var z = 0; z < depth; z++) {
                    cubes[x, y, z].GetComponent<Cube>().SetGameOver();
                }
            }
        }
    }

    void LoadLevel(int lvl) {
        actualLevel = lvl;
        switch (lvl) {
            case 0:
                InitializeLevel(Level00.GetSize(), Level00.GetShape());
                break;
            case 1:
                InitializeLevel(Level01.GetSize(), Level01.GetShape());
                break;
            case 2:
                InitializeLevel(Level02.GetSize(), Level02.GetShape());
                break;
            default:
                break;
        }
    }

    void InitializeLevel(int[] _size, int[][] _shape) {
        ResetLevel();
        SetShapeDimensions(_size);
        cubes = null;
        cubes = new GameObject[_size[0], _size[1], _size[2]];
        shape = _shape;
        Generate();
        SetCubesCanBreak();
        UpdatePivot();
    }

    void SetShapeDimensions(int[] _size) {
        width = _size[0];
        height = _size[1];
        depth = _size[2];
    }

    void ResetLevel() {
        GameObject[] _cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject _cube in _cubes) GameObject.Destroy(_cube);
    }

    void UpdatePivot() {
        pivot.transform.position = new Vector3(0f, 0f, 0f);
        Vector3 newPosition = new Vector3(-width / 2f + .5f, -height / 2f + .5f, -depth / 2f + .5f);
        pivot.transform.position = newPosition;
    }

    void SetCubesCanBreak() {
        foreach (int[] _cube in shape) {
            cubes[_cube[0], _cube[1], _cube[2]].GetComponent<Cube>().SetCanBreak(false);
        }
    }

    void Generate() {
        for (var x = 0; x < width; x++) {
            for (var y = 0; y < height; y++) {
                for (var z = 0; z < depth; z++) {
                    cubes[x, y, z] = Instantiate(cube, new Vector3(x, y, z), transform.rotation);
                    cubes[x, y, z].transform.parent = pivot.transform;
                }
            }
        }
    }

}
