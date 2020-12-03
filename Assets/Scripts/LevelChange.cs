using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter(Collider other)
    {
        Menu.ChangeScene(level);
    }
}
