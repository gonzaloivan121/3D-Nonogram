using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level00 {
    private static int width = 10;
    private static int height = 10;
    private static int depth = 10;

    private static int[][] shape = new int[][] { };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
