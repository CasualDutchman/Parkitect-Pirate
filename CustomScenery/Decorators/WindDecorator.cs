using System.Collections.Generic;
using UnityEngine;

namespace Custom_Scenery.Decorators
{
    class WindDecorator : IDecorator
    {
        private bool _wind;
        private Wind_Check_Horizontal hor;

        public WindDecorator(bool wind){ _wind = wind; }

        public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            if (_wind)
                {
                    go.AddComponent<Wind_Check>();
                }
                else
                {
                    hor = go.AddComponent<Wind_Check_Horizontal>();
                    if (options.ContainsKey("mass"))
                    {
                        hor.strength = (float)((double)options["mass"]);
                    }
                    else
                    {
                        hor.strength = 1.0f;
                    }
                }
        }
    }
}
