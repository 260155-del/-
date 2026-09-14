using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class playerhitjudment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("‚±‚Ì”»’è‚Ì•ûŒü‚ğİ’è")]
    public Direction direction;

    private playerController parentPlayer;

    void Start()
    {
        parentPlayer = GetComponentInParent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // •Ç‚ÉG‚ê‚½uŠÔ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            parentPlayer?.SetWallTouch(direction, true);
            //Debug.Log(" anko (true)");
        }
    }

    // •Ç‚©‚ç—£‚ê‚½uŠÔ
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            parentPlayer?.SetWallTouch(direction, false);
        }
    }
}