using UnityEngine;

public class PickupKeyCard : MonoBehaviour
{
    public AudioClip pickUpAudioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER))
        {
            //设置捡到钥匙
            PlayerBag playerBag = other.GetComponent<PlayerBag>();
            playerBag.hasKey = true;
            //音效
            AudioSource.PlayClipAtPoint(pickUpAudioClip, transform.position);
            //销毁
            GameObject.Destroy(gameObject);
        }
    }
}
