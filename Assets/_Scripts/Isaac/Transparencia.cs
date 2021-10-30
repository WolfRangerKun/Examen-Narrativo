using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparencia : MonoBehaviour
{
    public static Transparencia intance;
    [Range(0, 1)]
    public float transparencia = 0f, transicionSpeed = 1;
    public Image imageRenderer;

    public enum MODO
    {
        SHOW = 0,
        HIDE = 1,
        NOTHING = -1
    }

    public MODO modo;
    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        modo = MODO.HIDE;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
      


        if (modo.Equals(MODO.HIDE))
        {
            if (transparencia <= 0)
                modo = MODO.NOTHING;

            transparencia -= Time.deltaTime / 2;
                imageRenderer.color = new Color(imageRenderer.color.r, imageRenderer.color.g, imageRenderer.color.b, transparencia);
           

        }
        if (modo.Equals(MODO.SHOW))
        {
            if (transparencia >= .5f)
                modo = MODO.NOTHING;

            transparencia += Time.deltaTime / 2;
                imageRenderer.color = new Color(imageRenderer.color.r, imageRenderer.color.g, imageRenderer.color.b, transparencia);

        }

    }

   
}
