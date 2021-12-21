
using UnityEngine;
using UnityEngine.UI;

namespace InfoText
{
    public class WeaponInfo : MonoBehaviour
    {
        [SerializeField] private Text nameText;
        [SerializeField] private Text bulletCountText;
        
        public void OnWeaponChanged(NewWeapon newWeapon)
        {
            SetInfo(newWeapon);
        }
        private void SetInfo(NewWeapon newWeapon)
        {
            nameText.text = $"weapon: {newWeapon.Name}";
            bulletCountText.text = $"Bullets: {newWeapon.Ammo}";
        }
    }
}
