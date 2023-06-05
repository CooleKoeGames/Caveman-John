using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int foodCollected = 0;

    [SerializeField] private Text foodText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            foodCollected++;
            foodText.text = "Food Collected: " + foodCollected + "/10";
        }
    }
}
