using UnityEngine;

public class IslandBackground : MonoBehaviour {

    public Sprite ThreeHealthSprite;
    public Sprite TwoHealthSprite;
    public Sprite OneHealthSprite;
    public Sprite ZeroHealthSprite;

    void Start ()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ThreeHealthSprite;
	}

    public void ChangeSprite(int health)
    {
        switch (health)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = ZeroHealthSprite;
                break;

            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = OneHealthSprite;
                break;

            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = TwoHealthSprite;
                break;

            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = ThreeHealthSprite;
                break;

            default:
                break;
        }
    }
	
	
}
