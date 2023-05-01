using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    BoxCollider2D collider;

    bool isEnabled;

    // Start is called before the first frame update
    void Start()
    {
        DisableShield();
    }

    void EnableShield()
    {
        sprite.enabled = true;
        collider.enabled = true;
        isEnabled = true;
    }

    void DisableShield()
    {
        sprite.enabled = false;
        collider.enabled = false;
        isEnabled = false;
    }

    public void UpdateShield(bool pressed)
    {
        if (pressed && !isEnabled) EnableShield();
        else if (!pressed && isEnabled) DisableShield();
    }
}
