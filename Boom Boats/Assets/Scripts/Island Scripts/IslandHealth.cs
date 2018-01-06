using UnityEngine;

public class IslandHealth : MonoBehaviour {

    public int initialHealth;
    public MasterManager masterManager;
    public GameObject Rock;
    public GameObject PalmTree;
    public GameObject background;

    private int islandHealth;

    private void Start()
    {
        islandHealth = initialHealth;
        background.GetComponent<IslandBackground>().ChangeSprite(islandHealth);
    }

    public void ReduceIslandHealth()
    {
        islandHealth--;

        int islandIndex = GetComponent<IslandCannonRelation>().cannon.CannonIndex;

        if (islandHealth > 0)
        {
            masterManager.soundManager.PlayIslandHitButNotDeadSound(islandIndex);
        }
        else
        {
            masterManager.soundManager.PlayIslandDeadSound(islandIndex);
            islandDied();
        }

        background.GetComponent<IslandBackground>().ChangeSprite(islandHealth);


        
    }

    public void IncreaseIslandHealth()
    {
        if (islandHealth < 3)
        {
            islandHealth++;
            background.GetComponent<IslandBackground>().ChangeSprite(islandHealth);
        }

    }

    public void endGame()
    {
        Rock.gameObject.SetActive(false);
        PalmTree.gameObject.SetActive(false);
    }

    private void islandDied()
    {
        Rock.gameObject.SetActive(false);
        PalmTree.gameObject.SetActive(false);
        masterManager.waveManager.IncreaseWave(true);
        masterManager.spawnManager.OnIslandDeath(gameObject.GetComponent<IslandCannonRelation>().cannon.CannonIndex);
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ResetIsland()
    {
        islandHealth = initialHealth;
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(true);
        Rock.gameObject.SetActive(true);
        PalmTree.gameObject.SetActive(true);
        background.GetComponent<IslandBackground>().ChangeSprite(islandHealth);
        gameObject.SetActive(true);
    }


}
