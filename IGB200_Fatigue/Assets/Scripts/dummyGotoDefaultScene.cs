using UnityEngine;
using UnityEngine.SceneManagement;

public class dummyGotoDefaultScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(1);
    }
}
