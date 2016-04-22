using UnityEngine;
using System.Collections;

namespace Custom_Scenery
{

    public class Wind_Check : MonoBehaviour
    {

        private string code = "cdwind";

        GameObject wind;
        float timer;
        float noise;

        void Start()
        {
            if (GameObject.Find(code) == null)
            {
                wind = new GameObject(code);
                wind.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 359.9f), 0.0f);
            }
            else
            {
                wind = GameObject.Find(code);
            }
            timer = Random.Range(10, 100);
        }

        void Update()
        {
            timer += 0.01f;
            noise = Mathf.PerlinNoise(timer, timer) * 12;
            transform.GetChild(0).gameObject.transform.rotation = Quaternion.RotateTowards(transform.GetChild(0).gameObject.transform.rotation, Quaternion.Euler(0, wind.transform.rotation.eulerAngles.y + noise, 0), 0.2f);
        }
    }
}
