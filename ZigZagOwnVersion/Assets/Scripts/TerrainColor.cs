using UnityEngine;

public class TerrainColor : MonoBehaviour
{

    
        public int materialIndex = 0;
        public string textureName = "_MainTex";

        Vector2 uvRandom = Vector2.zero;

        void Start()
        {
            uvRandom = new Vector2(Random.value, Random.value);

            if (GetComponent<Renderer>().enabled)
            {
                GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, uvRandom);
            }
        }
    }