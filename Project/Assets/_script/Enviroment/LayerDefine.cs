using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDefine
{
    public const int Terrain = 8;
    public const int TerrainMask = 1 << 8;
    public static int EvrMask = LayerMask.GetMask("Terrain", "Trap");
}
