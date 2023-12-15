using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    private PlaySounds sm;

    private void Awake() => sm = FindObjectOfType<PlaySounds>();

    private void Update() => transform.position = new Vector3(player.position.x + offset, player.position.y, transform.position.z);

    private void BossMusic()
    {
        sm.ChangeMusic(sm.bossFight);
    }
}
