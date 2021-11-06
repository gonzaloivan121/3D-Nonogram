using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level05 {
    private static int width = 16;
    private static int height = 16;
    private static int depth = 1;

    private static int[][] shape = new int[][] {
        new int[] {  8, 15, 0 },
        new int[] {  9, 15, 0 },
        new int[] { 10, 15, 0 },
        new int[] { 11, 15, 0 },
        new int[] { 12, 15, 0 },
        new int[] { 13, 15, 0 },
        new int[] { 14, 15, 0 },

        new int[] {  7, 14, 0 },
        new int[] {  8, 14, 0 },
        new int[] { 10, 14, 0 },
        new int[] { 11, 14, 0 },
        new int[] { 12, 14, 0 },
        new int[] { 13, 14, 0 },
        new int[] { 14, 14, 0 },
        new int[] { 15, 14, 0 },

        new int[] {  7, 13, 0 },
        new int[] {  8, 13, 0 },
        new int[] {  9, 13, 0 },
        new int[] { 10, 13, 0 },
        new int[] { 11, 13, 0 },
        new int[] { 12, 13, 0 },
        new int[] { 13, 13, 0 },
        new int[] { 14, 13, 0 },
        new int[] { 15, 13, 0 },

        new int[] {  7, 12, 0 },
        new int[] {  8, 12, 0 },
        new int[] {  9, 12, 0 },
        new int[] { 10, 12, 0 },
        new int[] { 11, 12, 0 },
        new int[] { 12, 12, 0 },
        new int[] { 13, 12, 0 },
        new int[] { 14, 12, 0 },
        new int[] { 15, 12, 0 },

        new int[] {  0, 11, 0 },
        new int[] {  7, 11, 0 },
        new int[] {  8, 11, 0 },
        new int[] {  9, 11, 0 },
        new int[] { 10, 11, 0 },
        new int[] { 11, 11, 0 },

        new int[] {  0, 10, 0 },
        new int[] {  7, 10, 0 },
        new int[] {  8, 10, 0 },
        new int[] {  9, 10, 0 },
        new int[] { 10, 10, 0 },
        new int[] { 11, 10, 0 },
        new int[] { 12, 10, 0 },
        new int[] { 13, 10, 0 },
        new int[] { 14, 10, 0 },

        new int[] {  0,  9, 0 },
        new int[] {  1,  9, 0 },
        new int[] {  6,  9, 0 },
        new int[] {  7,  9, 0 },
        new int[] {  8,  9, 0 },
        new int[] {  9,  9, 0 },
        new int[] { 10,  9, 0 },

        new int[] {  0,  8, 0 },
        new int[] {  1,  8, 0 },
        new int[] {  2,  8, 0 },
        new int[] {  5,  8, 0 },
        new int[] {  6,  8, 0 },
        new int[] {  7,  8, 0 },
        new int[] {  8,  8, 0 },
        new int[] {  9,  8, 0 },
        new int[] { 10,  8, 0 },
        new int[] { 11,  8, 0 },
        new int[] { 12,  8, 0 },

        new int[] {  0,  7, 0 },
        new int[] {  1,  7, 0 },
        new int[] {  2,  7, 0 },
        new int[] {  3,  7, 0 },
        new int[] {  4,  7, 0 },
        new int[] {  5,  7, 0 },
        new int[] {  6,  7, 0 },
        new int[] {  7,  7, 0 },
        new int[] {  8,  7, 0 },
        new int[] {  9,  7, 0 },
        new int[] { 10,  7, 0 },
        new int[] { 12,  7, 0 },

        new int[] {  1,  6, 0 },
        new int[] {  2,  6, 0 },
        new int[] {  3,  6, 0 },
        new int[] {  4,  6, 0 },
        new int[] {  5,  6, 0 },
        new int[] {  6,  6, 0 },
        new int[] {  7,  6, 0 },
        new int[] {  8,  6, 0 },
        new int[] {  9,  6, 0 },
        new int[] { 10,  6, 0 },

        new int[] {  2,  5, 0 },
        new int[] {  3,  5, 0 },
        new int[] {  4,  5, 0 },
        new int[] {  5,  5, 0 },
        new int[] {  6,  5, 0 },
        new int[] {  7,  5, 0 },
        new int[] {  8,  5, 0 },
        new int[] {  9,  5, 0 },

        new int[] {  3,  4, 0 },
        new int[] {  4,  4, 0 },
        new int[] {  5,  4, 0 },
        new int[] {  6,  4, 0 },
        new int[] {  7,  4, 0 },
        new int[] {  8,  4, 0 },

        new int[] {  4,  3, 0 },
        new int[] {  5,  3, 0 },
        new int[] {  6,  3, 0 },
        new int[] {  7,  3, 0 },
        new int[] {  8,  3, 0 },

        new int[] {  4,  2, 0 },
        new int[] {  5,  2, 0 },
        new int[] {  7,  2, 0 },
        new int[] {  8,  2, 0 },

        new int[] {  4,  1, 0 },
        new int[] {  8,  1, 0 },

        new int[] {  4,  0, 0 },
        new int[] {  5,  0, 0 },
        new int[] {  8,  0, 0 },
        new int[] {  9,  0, 0 },
    };

    public static int[][] GetShape() { return shape; }
    public static int[] GetSize() { return new int[] { width, height, depth }; }
}
