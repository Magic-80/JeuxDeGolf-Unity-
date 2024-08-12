using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.C_.UI
{
    public class UIManager : MonoBehaviour
    {
        
        public void PlayGame(int sceneIndex)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }

        public void QuiGame()
        {
            Application.Quit();
        }
    }
}
