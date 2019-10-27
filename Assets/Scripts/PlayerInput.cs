using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player = null;

    private void Awake() 
    {
        player = GetComponent<Player>();    
    }

    private void Update() {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 50f, LayerMask.GetMask("Ground")))
            {
                Vector3 destination = new Vector3(hit.point.x, hit.point.y + transform.position.y, hit.point.z);
                player.SetDestination(destination);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Item i = ItemPool.Instance.GetRandomItem();
            print(i.Name);
        }
    }
}