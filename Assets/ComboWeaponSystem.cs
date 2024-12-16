using System.Collections;
using UnityEngine;

public class ComboWeaponSystem : MonoBehaviour
{
    [Header("Weapon Configuration")]
    public WeaponConfig[] weaponConfigs;

    [Header("Combo Input")]
    private string currentCombo = "";  // הקומבו הנוכחי של השחקן
    public int maxComboLength = 10;  // אורך מקסימלי של הקומבו

    public Transform weaponSpawnPoint; // נקודת השיגור של הלייזר
    public NumberField scoreField;  // השדה שמציג את הנקודות בשחקן

    private void Update()
    {
        // הוסף את הקלט הנוכחי לצירוף
        if (Input.anyKeyDown)
        {
            currentCombo += Input.inputString.ToLower();

            // חיתוך הקומבו במקרה שהוא ארוך מדי
            if (currentCombo.Length > maxComboLength)
            {
                currentCombo = currentCombo.Substring(currentCombo.Length - maxComboLength);
            }

            // בדוק אם הקומבו הוזן נכון
            foreach (WeaponConfig config in weaponConfigs)
            {
                // אם הקומבו תואם, הפעל את הנשק
                if (currentCombo == config.inputCombo)
                {
                    Debug.Log($"Combo matched! Firing {config.weaponType}.");
                    ActivateWeapon(config);
                    currentCombo = "";  // אפס את הקומבו אחרי שהופעל
                    break;
                }
            }
        }
    }

    private void ActivateWeapon(WeaponConfig config)
    {
        // Instantiate the weapon based on the config
        GameObject newWeapon = Instantiate(config.weaponPrefab, weaponSpawnPoint.position, Quaternion.identity);

        // שינוי גודל הנשק (לפי הצרכים שלך)
        newWeapon.transform.localScale = new Vector3(config.weaponSize, config.weaponSize, config.weaponSize);

        // Ensure the weapon gets the correct scoreAdder component and scoreField is set correctly
        ScoreAdder newWeaponScoreAdder = newWeapon.GetComponent<ScoreAdder>();
        if (newWeaponScoreAdder == null)
        {
            newWeaponScoreAdder = newWeapon.AddComponent<ScoreAdder>(); // Add the ScoreAdder if not present
        }

        // Set the scoreField and pointsToAdd on the new weapon
        newWeaponScoreAdder.SetScoreField(scoreField);
        newWeaponScoreAdder.SetPointsToAdd(config.pointsToAdd);

        // If the weapon is a laser (fires forward), set its velocity
        if (config.weaponType == WeaponType.Laser)
        {
            Rigidbody2D rb = newWeapon.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.linearVelocity = Vector2.up * config.weaponSpeed;  // Fire upwards along the Y-axis
            }
        }
        else if (config.weaponType == WeaponType.Bomb)
        {
            // If the weapon is a bomb (stationary), set its velocity to zero
            Rigidbody2D rb = newWeapon.GetComponent<Rigidbody2D>();
            if (rb)
            {
                rb.linearVelocity = Vector2.zero;  // Stationary bomb
            }
        }
    }
}

[System.Serializable]
public class WeaponConfig
{
    public GameObject weaponPrefab;  // The prefab of the weapon
    public float weaponSize;  // Size of the weapon (for scaling)
    public float weaponSpeed;  // Speed of the projectile (for lasers)
    public WeaponType weaponType;  // Type of weapon (Laser, Bomb)
    public int pointsToAdd;  // Points to add when the weapon hits the target
    public string inputCombo;  // The combo needed to activate this weapon
}

public enum WeaponType
{
    Laser,
    Bomb
}

