using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(EnterLevel1);
    }

    private void EnterLevel1()
    {
        SceneManager.LoadScene("CG");
    }
}
