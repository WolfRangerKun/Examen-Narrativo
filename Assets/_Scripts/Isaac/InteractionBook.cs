using UnityEngine;

public class InteractionBook : MonoBehaviour
{
    public AutoFlip book;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            book.FlipLeftPage();

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            book.FlipRightPage();

        }

    }


}
