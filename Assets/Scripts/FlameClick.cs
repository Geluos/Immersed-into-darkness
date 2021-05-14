using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameClick : MonoBehaviour
{
    public ParticleSystem ps;

    private void OnMouseDown()
    {
        ps.Clear();
        ps.Emit(350);
    }

}
