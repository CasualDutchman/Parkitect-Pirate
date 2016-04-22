using System.Collections.Generic;
using UnityEngine;

namespace Custom_Scenery.Decorators
{
    class NameDecorator : IDecorator
    {
        private string _name;
        private string _display = "null";

        public NameDecorator(string name)
        {
            _name = name;
            _display = name;
        }
        public NameDecorator(string name, string display)
        {
            _name = name;
            _display = display;
        }

        public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            go.GetComponent<BuildableObject>().setDisplayName(_display);
            go.name = _name;
        }
    }
}
