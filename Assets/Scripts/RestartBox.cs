using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
