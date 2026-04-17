using UnityEngine;

public class Main : MonoBehaviour
{
    public float PlayerSpeed = 10.0f;
    public int score = 0;

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * moveInput * PlayerSpeed * Time.deltaTime);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
