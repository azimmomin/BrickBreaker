﻿using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
