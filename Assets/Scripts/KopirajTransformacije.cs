using UnityEngine;

public class KopirajTransformacije : MonoBehaviour
{
    public Transform objektB;

    void Start()
    {
        transform.localScale = objektB.localScale;
    }
}
