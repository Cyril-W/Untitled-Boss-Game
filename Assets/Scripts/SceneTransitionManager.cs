using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void ReloadScene() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
