using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private int width;
    private int height;
    private int depth;

    public GameObject cube;
    public GameObject pivot;

    private GameObject[,,] cubes;
    private int[][] shape;

    [Range(0, 4)] public int life = 4;
    [Range(0, 2)] public int level = 1;
    private int actualLevel = 1;
    private int maxLevels = 3;

    private bool breakMode = true;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Text levelText;

    public bool test = false;

    // Start is called before the first frame update
    void Start() {
        if (test) {
            level = 0;
            actualLevel = 0;
        }
        LoadLevel(level);
    }

    // Update is called once per frame
    void Update() {
        if (level != actualLevel) LoadLevel(level);
    }

    public void PreviousLevel() {
        if (level > 0) level--;
    }

    public void NextLevel() {
        if (level < maxLevels-1) level++;
    }

    public void LooseLife() {
        if (test) return;
        if (life > 1) {
            life--;
            UpdateHearts();
        } else { 
            LooseGame();
        }
    }

    void UpdateHearts() {
        hearts[life].sprite = emptyHeart;
    }

    void LooseGame() {
        print("You Loose!");
        hearts[0].sprite = emptyHeart;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z].GetComponent<Cube>().SetGameOver();
                }
            }
        }
    }

    void LoadLevel(int lvl) {
        actualLevel = lvl;
        levelText.text = actualLevel == 0 ? "Test" : "Level " + lvl;
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
        ResetLevel(_size, _shape);
        Generate();
        CheckIfCubesCanBreak();
        UpdatePivot();
    }

    void ResetLevel(int[] _size, int[][] _shape) {
        if (cubes != null) { Array.Clear(cubes, 0, cubes.Length); }
        GameObject[] _cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject _cube in _cubes) GameObject.Destroy(_cube);
        pivot.transform.position = Vector3.zero;
        SetShapeDimensions(_size);
        cubes = new GameObject[_size[0], _size[1], _size[2]];
        shape = _shape;
        life = 4;
        ResetHearts();
    }

    void ResetHearts() {
        foreach (Image heart in hearts) {
            heart.sprite = fullHeart;
        }
    }

    void SetShapeDimensions(int[] _size) {
        width = _size[0];
        height = _size[1];
        depth = _size[2];
    }

    void UpdatePivot() {
        Vector3 newPosition = new Vector3(-width / 2f + .5f, -height / 2f + .5f, -depth / 2f + .5f);
        pivot.transform.position = newPosition;
    }

    void CheckIfCubesCanBreak() {
        foreach (int[] _cube in shape) {
            cubes[_cube[0], _cube[1], _cube[2]].GetComponent<Cube>().SetCanBreak(false);
        }
    }

    void Generate() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < depth; z++) {
                    cubes[x, y, z] = Instantiate(cube, new Vector3(x, y, z), transform.rotation, pivot.transform);
                }
            }
        }
    }

    public void BreakCube() {
        print("Broken in Game Script");


    }

}
