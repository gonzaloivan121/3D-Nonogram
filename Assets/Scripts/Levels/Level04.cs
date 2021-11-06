using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level04 {
    private static int width = 4;
    private static int height = 8;
    private static int depth = 4;

    private static int[][] shape = new int[][] {
        new int[] { 0, 7, 3 },
        new int[] { 1, 7, 3 },
        new int[] { 2, 7, 3 },
        new int[] { 3, 7, 3 },

        new int[] { 0, 6, 3 },
        new int[] { 1, 6, 3 },
        new int[] { 2, 6, 3 },
        new int[] { 3, 6, 3 },

        new int[] { 0, 5, 3 },
        new int[] { 1, 5, 3 },
        new int[] { 2, 5, 3 },
        new int[] { 3, 5, 3 },

        new int[] { 0, 4, 3 },
        new int[] { 1, 4, 3 },
        new int[] { 2, 4, 3 },
        new int[] { 3, 4, 3 },

        new int[] { 0, 3, 3 },
        new int[] { 1, 3, 3 },
        new int[] { 2, 3, 3 },
        new int[] { 3, 3, 3 },

        new int[] { 0, 3, 2 },
        new int[] { 1, 3, 2 },
        new int[] { 2, 3, 2 },
        new int[] { 3, 3, 2 },

        new int[] { 0, 3, 1 },
        new int[] { 1, 3, 1 },
        new int[] { 2, 3, 1 },
        new int[] { 3, 3, 1 },

        new int[] { 0, 3, 0 },
        new int[] { 1, 3, 0 },
        new int[] { 2, 3, 0 },
        new int[] { 3, 3, 0 },

        new int[] { 0, 2, 0 },
        new int[] { 0, 1, 0 },
        new int[] { 0, 0, 0 },

        new int[] { 0, 2, 3 },
        new int[] { 0, 1, 3 },
        new int[] { 0, 0, 3 },

        new int[] { 3, 2, 0 },
        new int[] { 3, 1, 0 },
        new int[] { 3, 0, 0 },

        new int[] { 3, 2, 3 },
        new int[] { 3, 1, 3 },
        new int[] { 3, 0, 3 },
    };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
