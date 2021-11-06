using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level99 {
    private static int width = 28;
    private static int height = 25;
    private static int depth = 1;

    private static int[] s = new int[] { };

    private static int[][] shape = new int[][] {
        new int[] { 18, 24, 0 },
        new int[] { 19, 24, 0 },
        new int[] { 20, 24, 0 },
        new int[] { 21, 24, 0 },
        new int[] { 22, 24, 0 },
        new int[] { 23, 24, 0 },
        new int[] { 24, 24, 0 },

        new int[] { 17, 23, 0 },
        new int[] { 18, 23, 0 },
        new int[] { 19, 23, 0 },
        new int[] { 20, 23, 0 },
        new int[] { 21, 23, 0 },
        new int[] { 22, 23, 0 },
        new int[] { 23, 23, 0 },
        new int[] { 24, 23, 0 },
        new int[] { 25, 23, 0 },

        new int[] { 16, 22, 0 },
        new int[] { 17, 22, 0 },
        new int[] { 18, 22, 0 },
        new int[] { 19, 22, 0 },
        new int[] { 20, 22, 0 },
        new int[] { 21, 22, 0 },
        new int[] { 22, 22, 0 },
        new int[] { 23, 22, 0 },
        new int[] { 24, 22, 0 },
        new int[] { 25, 22, 0 },
        new int[] { 26, 22, 0 },

        new int[] { 16, 21, 0 },
        new int[] { 17, 21, 0 },
        new int[] { 18, 21, 0 },
        new int[] { 19, 21, 0 },
        new int[] { 20, 21, 0 },
        new int[] { 21, 21, 0 },
        new int[] { 22, 21, 0 },
        new int[] { 23, 21, 0 },
        new int[] { 24, 21, 0 },
        new int[] { 25, 21, 0 },
        new int[] { 26, 21, 0 },
        new int[] { 27, 21, 0 },

        new int[] {  2, 20, 0 },
        new int[] {  3, 20, 0 },
        new int[] {  4, 20, 0 },
        new int[] { 16, 20, 0 },
        new int[] { 17, 20, 0 },
        new int[] { 18, 20, 0 },
        new int[] { 19, 20, 0 },
        new int[] { 20, 20, 0 },
        new int[] { 21, 20, 0 },
        new int[] { 22, 20, 0 },
        new int[] { 23, 20, 0 },
        new int[] { 24, 20, 0 },
        new int[] { 25, 20, 0 },
        new int[] { 26, 20, 0 },
        new int[] { 27, 20, 0 },

        new int[] {  1, 19, 0 },
        new int[] {  2, 19, 0 },
        new int[] {  3, 19, 0 },
        new int[] {  4, 19, 0 },
        new int[] { 16, 19, 0 },
        new int[] { 17, 19, 0 },
        new int[] { 18, 19, 0 },
        new int[] { 19, 19, 0 },
        new int[] { 20, 19, 0 },
        new int[] { 21, 19, 0 },
        new int[] { 22, 19, 0 },
        new int[] { 23, 19, 0 },
        new int[] { 24, 19, 0 },
        new int[] { 25, 19, 0 },
        new int[] { 26, 19, 0 },

        new int[] {  0, 18, 0 },
        new int[] {  1, 18, 0 },
        new int[] {  2, 18, 0 },
        new int[] {  3, 18, 0 },
        new int[] { 14, 18, 0 },
        new int[] { 15, 18, 0 },
        new int[] { 16, 18, 0 },
        new int[] { 17, 18, 0 },
        new int[] { 18, 18, 0 },
        new int[] { 19, 18, 0 },
        new int[] { 20, 18, 0 },
        new int[] { 21, 18, 0 },
        new int[] { 22, 18, 0 },
        new int[] { 23, 18, 0 },
        new int[] { 24, 18, 0 },
        new int[] { 25, 18, 0 },
        new int[] { 26, 18, 0 },
    };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
