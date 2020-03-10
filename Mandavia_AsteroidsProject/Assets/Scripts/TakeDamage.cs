using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private float damageTimer;
    private float damageTimerReset;
    public bool isDamaged;
    public Image damageImage;

    // Use this for initialization
    void Start()
    {
        isDamaged = false;
        damageTimer = 0;
        damageTimerReset = .33f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            damageImage.color = new Color(1f, 0f, 0f, 0.4f);

            damageTimer += Time.deltaTime;

            if (damageTimer >= damageTimerReset)
            {
                isDamaged = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                damageImage.color = new Color(1f, 0f, 0f, 0f);
                damageTimer = 0;
            }
        }
    }
}
