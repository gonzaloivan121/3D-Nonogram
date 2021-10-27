using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00 {
    private static int width = 8;
    private static int height = 8;
    private static int depth = 8;

    private static int[][] shape = new int[][] { };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
