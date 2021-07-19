///-----------------------------------------------------------------------------
///
/// RNG
/// 
/// Random Number Generator
///
///-----------------------------------------------------------------------------

using UnityEngine;


public class RNG
{
    public RNG()
    {
        SetSeed(128);
    }


    public int RandomInt(int start, int end)
    {
        return Random.Range(start, end);
    }


    public float RandomFloat(float start, float end)
    {
        return Random.Range(start, end);
    }


    public void SetSeed(int newSeed)
    {
        Random.InitState(newSeed);
    }
}

//2do
// Seeds
// recreate same level based on seed
// Noise : Perlin, Voronoi
// 

