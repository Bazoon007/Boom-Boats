using UnityEngine;

public class IslandHealth : MonoBehaviour {

    public int initialHealth;
    public MasterManager masterManager;
    public GameObject OneHealthRemainingFlag;
    public GameObject TwoHealthRemainingFlag;
    public GameObject ThreeHealthRemainingFlag;
    public GameObject Rock;
    public GameObject PalmTree;

    private int islandHealth;

    private void Start()
    {
        islandHealth = initialHealth;
        activateHealthFlags();
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
        }

        if (islandHealth == 2)
        {
            ThreeHealthRemainingFlag.SetActive(false);
        }
        else if (islandHealth == 1)
        {
            TwoHealthRemainingFlag.SetActive(false);
        }
        else if (islandHealth == 0)
        {
            islandDied();
        }

        
    }

    public void IncreaseIslandHealth()
    {
        if (islandHealth < 3)
        {
            islandHealth++;
        }

        if (islandHealth == 2)
        {
            TwoHealthRemainingFlag.SetActive(true);
        }
        else if (islandHealth == 3)
        {
            ThreeHealthRemainingFlag.SetActive(true);
        }
    }

    public void endGame()
    {
        OneHealthRemainingFlag.gameObject.SetActive(false);
        TwoHealthRemainingFlag.gameObject.SetActive(false);
        ThreeHealthRemainingFlag.gameObject.SetActive(false);
        Rock.gameObject.SetActive(false);
        PalmTree.gameObject.SetActive(false);
    }

    private void islandDied()
    {
        OneHealthRemainingFlag.SetActive(false);
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
        activateHealthFlags();
        gameObject.GetComponent<IslandCannonRelation>().cannon.gameObject.SetActive(true);
        Rock.gameObject.SetActive(true);
        PalmTree.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    private void activateHealthFlags()
    {
        OneHealthRemainingFlag.SetActive(true);
        TwoHealthRemainingFlag.SetActive(true);
        ThreeHealthRemainingFlag.SetActive(true);
    }

}
