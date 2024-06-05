using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;
    public float flashDuration = 0.1f; // Duration of each flash
    public int numberOfFlashes = 2; // Number of times to flash
    public GameObject consumable;

    private SpriteRenderer playerSpriteRenderer;
    private Consumables consumableScript;

    private void Start()
    {
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        consumableScript = consumable.GetComponent<Consumables>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FlashPlayer());
        }
    }

    private IEnumerator FlashPlayer()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            playerSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            playerSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        player.transform.position = startPoint.transform.position;
        player.GetComponent<Player>().ResetJumpState(); 
      //  player.GetComponent<Player>().PowerUpSpriteRenderer.enabled = true;
       // consumableScript.consumableSpriteRenderer.enabled = true;

    }

}
