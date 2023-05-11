using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun", order = 1)]
public class GunSO : ScriptableObject
{
    public Sprite sprite;
    public Bullet bullet;

    public string gunName;
    public string description;
    
    public int damage;
    public int fireRate;
}
