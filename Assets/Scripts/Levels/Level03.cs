using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03 {
    private static int width = 5;
    private static int height = 6;
    private static int depth = 5;

    private static int[][] shape = new int[][] {
        new int[] { 2, 5, 2 },
        new int[] { 1, 4, 1 },
        new int[] { 2, 4, 1 },
        new int[] { 3, 4, 1 },
        new int[] { 1, 4, 2 },
        new int[] { 2, 4, 2 },
        new int[] { 3, 4, 2 },
        new int[] { 1, 4, 3 },
        new int[] { 2, 4, 3 },
        new int[] { 3, 4, 3 },
        new int[] { 0, 3, 0 },
        new int[] { 1, 3, 0 },
        new int[] { 2, 3, 0 },
        new int[] { 3, 3, 0 },
        new int[] { 4, 3, 0 },
        new int[] { 0, 3, 1 },
        new int[] { 1, 3, 1 },
        new int[] { 2, 3, 1 },
        new int[] { 3, 3, 1 },
        new int[] { 4, 3, 1 },
        new int[] { 0, 3, 2 },
        new int[] { 1, 3, 2 },
        new int[] { 2, 3, 2 },
        new int[] { 3, 3, 2 },
        new int[] { 4, 3, 2 },
        new int[] { 0, 3, 3 },
        new int[] { 1, 3, 3 },
        new int[] { 2, 3, 3 },
        new int[] { 3, 3, 3 },
        new int[] { 4, 3, 3 },
        new int[] { 0, 3, 4 },
        new int[] { 1, 3, 4 },
        new int[] { 2, 3, 4 },
        new int[] { 3, 3, 4 },
        new int[] { 4, 3, 4 },
        new int[] { 2, 2, 2 },
        new int[] { 2, 1, 2 },
        new int[] { 2, 0, 2 },
    };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
