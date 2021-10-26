using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 {
    private static int width = 5;
    private static int height = 5;
    private static int depth = 3;

    private static int[][] shape = new int[][] {
        new int[] { 1, 4, 1 },
        new int[] { 2, 4, 1 },
        new int[] { 3, 4, 1 },
        new int[] { 1, 3, 1 },
        new int[] { 3, 3, 1 },
        new int[] { 1, 2, 1 },
        new int[] { 2, 2, 1 },
        new int[] { 3, 2, 1 },
        new int[] { 1, 1, 1 },
        new int[] { 3, 1, 1 },
        new int[] { 1, 0, 1 },
        new int[] { 3, 0, 1 }
    };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
