using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    private float horizontalInput = 0f;
    private bool isDead = false;

    public float PlayerSpeed = 7.5f;
    public int score = 80;
    public TextMeshProUGUI scoreDisplay;
    public float growth = 1f;
    public GameObject implosionPrefab;
    public GameObject explosionPrefab;
    public GameOver gameOverScript;

    public void MoveLeft() => horizontalInput = -1f;
    public void MoveRight() => horizontalInput = 1f;
    public void MoveStop() => horizontalInput = 0f;

    void Update()
    {
        if (isDead) return;

        float move = horizontalInput;
        if (move == 0) move = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * move * PlayerSpeed * Time.deltaTime);

        if (move > 0)
            transform.localScale = new Vector3(growth, growth, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-growth, growth, 1);

        if (growth > 5)
        {
            Explosion();
        }
        else if (growth < 0.3f)
        {
            Implosion();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("massGrower"))
        {
            score += 10;
            UpdateScoreUI();
            growth += 0.05f;
            growth += 0.05f;
            Spawner.damping += 0.08f;
            
        }
        else if (other.CompareTag("massDegrower"))
        {
            score -= 5;
            UpdateScoreUI();
            growth -= 0.02f;
            growth -= 0.02f;
            Spawner.damping -= 0.05f;

        }
        Destroy(other.gameObject);
    }

    void UpdateScoreUI()
    {
        scoreDisplay.text = "МАССА: " + score + "кг";
    }

    void Explosion()
    {
        if (isDead) return;
        isDead = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Invoke("GEnd", 2f);
    }

    void Implosion()
    {
        if (isDead) return;
        isDead = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Instantiate(implosionPrefab, transform.position, Quaternion.identity);
        Invoke("BEnd", 2f);
    }
    void GEnd()
    {
        gameOverScript.Show("ПОТЯК ЛОПНУЛ!", score);
    }
    void BEnd()
    {
        gameOverScript.Show("ПОТЯК СДУЛСЯ...", score);
    }
}
