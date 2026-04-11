using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPStudio.Core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _curretnScreen;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if (_curretnScreen != null) _curretnScreen.Hide();
            var nextScreen = screenBases.Find(i => i.screenType == type);
            nextScreen.Show();
            _curretnScreen = nextScreen;
        }
        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }
}
