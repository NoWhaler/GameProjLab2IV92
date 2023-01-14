using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<ICharacter>();
        if (character != null)
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
