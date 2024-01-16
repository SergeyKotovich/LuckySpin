using JetBrains.Annotations;
using UnityEngine;

public class Token : MonoBehaviour
{
    [UsedImplicitly]
    public void DestroyToken()
    {
        Destroy(gameObject);
    }
}
