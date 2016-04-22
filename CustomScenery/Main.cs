using CustomShops;
using UnityEngine;

namespace Custom_Scenery
{
    public class Main : IMod
    {
        private GameObject _scenery;
        private GameObject _shop;
        private GameObject _wind;

        public void onEnabled()
        {
            _scenery = new GameObject();
            _shop = new GameObject();
            _wind = new GameObject("cdwind");

            _scenery.AddComponent<SceneryLoader>();
            _shop.AddComponent<CustomShopLoader>();
            _wind.AddComponent<Wind>();

            _scenery.GetComponent<SceneryLoader>().Path = Path;
            _shop.GetComponent<CustomShopLoader>().Path = Path;

            _scenery.GetComponent<SceneryLoader>().Identifier = Identifier;

            _scenery.GetComponent<SceneryLoader>().LoadScenery();
            _shop.GetComponent<CustomShopLoader>().LoadShop();
        }

        public void onDisabled()
        {
            _scenery.GetComponent<SceneryLoader>().UnloadScenery();
            _shop.GetComponent<CustomShopLoader>().UnloadShops();

            Object.Destroy(_scenery);
            Object.Destroy(_shop);
            Object.Destroy(_wind);
        }

        public string Name { get { return "Pirate Theme Scenery"; } }
        public string Description { get { return "Decorate your park with these new Pirate themed objects"; } }
        public string Path { get; set; }
        public string Identifier { get; set; }
    }
}
