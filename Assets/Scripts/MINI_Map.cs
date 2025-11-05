using UnityEngine;

public class MINI_Map : MonoBehaviour
{
    public Transform player;
    private void LateUpdate()
    {
        Vector3 newposition = player.position;
        newposition.y = transform.position.y;  //Need to be static in the 'Y' Direction.
        transform.position = newposition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
