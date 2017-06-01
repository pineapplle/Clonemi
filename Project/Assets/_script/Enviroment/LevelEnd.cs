using UnityEngine.SceneManagement;

public class LevelEnd : TriggerObject
{
    public string NextLevel;
    protected override void OnTriggerPlayer(Player player)
    {
        SceneManager.LoadScene(NextLevel);
    }
}
