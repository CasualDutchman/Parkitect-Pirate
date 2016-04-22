using UnityEngine;
using System.Collections;
namespace Custom_Scenery
{

    public class Wind : MonoBehaviour
    {

        float timer;

        float _dir;

        void Start()
        {
            timer = Random.Range(0, 180);
        }

        void Update()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 136)
            {
                timer = 0;
                ChangeDir();
            }
            transform.rotation = Quaternion.Euler(0, _dir, 0);
        }

        private void ChangeDir()
        {
            if (Random.Range(0, 2) == 0)
            {
                _dir = Random.Range(_dir, _dir + 60);
            }
            else
            {
                _dir = Random.Range(_dir - 60, _dir);
            }
        }
    }
}
