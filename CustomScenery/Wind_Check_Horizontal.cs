using UnityEngine;
using System.Collections;

namespace Custom_Scenery
{

    public class Wind_Check_Horizontal : MonoBehaviour
    {

        private string code = "cdwind";

        GameObject wind;

        public float strength = 1;

        int dir;

        float timer;
        float noise;

        float X;
        float Z;

        void Start()
        {
            if (GameObject.Find(code) == null)
            {
                wind = new GameObject(code);
                wind.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 359.9f), 0.0f);
                wind.AddComponent<Wind>();
            }
            else
            {
                wind = GameObject.Find(code);
            }
            timer = Random.Range(10, 100);

            dir = (int)(transform.rotation.eulerAngles.y) / 90;
            Z = transform.GetChild(0).gameObject.transform.rotation.eulerAngles.x;
        }

        void Update()
        {
            timer += 0.01f;
            noise = Mathf.PerlinNoise(timer, timer) * 9;

            if (dir == 1)
            {
                if (wind.transform.rotation.eulerAngles.y >= 45 && wind.transform.rotation.eulerAngles.y < 135) { X = -1; }
                else if (wind.transform.rotation.eulerAngles.y >= 225 && wind.transform.rotation.eulerAngles.y < 315) { X = 1; }
                else { X = 0; }
            }
            if (dir == 3)
            {
                if (wind.transform.rotation.eulerAngles.y >= 45 && wind.transform.rotation.eulerAngles.y < 135) { X = 1; }
                else if (wind.transform.rotation.eulerAngles.y >= 225 && wind.transform.rotation.eulerAngles.y < 315) { X = -1; }
                else { X = 0; }
            }
            if (dir == 2)
            {
                if (wind.transform.rotation.eulerAngles.y >= 135 && wind.transform.rotation.eulerAngles.y < 225) { X = -1; }
                else if (wind.transform.rotation.eulerAngles.y >= 315 && wind.transform.rotation.eulerAngles.y < 360) { X = 1; }
                else if (wind.transform.rotation.eulerAngles.y >= 0 && wind.transform.rotation.eulerAngles.y < 45) { X = 1; }
                else { X = 0; }
            }
            if (dir == 0)
            {
                if (wind.transform.rotation.eulerAngles.y >= 135 && wind.transform.rotation.eulerAngles.y < 225) { X = 1; }
                else if (wind.transform.rotation.eulerAngles.y >= 315 && wind.transform.rotation.eulerAngles.y < 360) { X = -1; }
                else if (wind.transform.rotation.eulerAngles.y >= 0 && wind.transform.rotation.eulerAngles.y < 45) { X = -1; }
                else { X = 0; }
            }

            X = X * 22;

            //transform.GetChild(0).gameObject.transform.rotation = Quaternion.RotateTowards(transform.GetChild(0).gameObject.transform.rotation, Quaternion.Euler(0, dir * 90, 0), 0.2f);
            transform.GetChild(0).gameObject.transform.localRotation = Quaternion.RotateTowards(transform.GetChild(0).gameObject.transform.localRotation, Quaternion.Euler(Z, 0, -3 + ((X + noise) * strength)), 0.2f);
        }
    }
}