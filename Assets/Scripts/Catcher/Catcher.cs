using UnityEngine;

public class Catcher : MonoBehaviour
{
    private string[] _catchableTags = { "Egg", "Carrot" };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsCatchable(collision.gameObject))
        {
            Destroy(collision.gameObject);
        }
    }

    private bool IsCatchable(GameObject gameObject)
    {
        foreach (string tag in _catchableTags)
        {
            if (gameObject.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
