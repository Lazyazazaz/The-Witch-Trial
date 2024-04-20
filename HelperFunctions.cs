using UnityEngine;

namespace Platformer.Utils
{
    public static class HelperFunctions
    {
        public static Vector3 GenerateRandomDirection()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}