using UnityEngine;

public class PhysicsPointer : MonoBehaviour {
    

    public float defaultLength = 3.0f;

    private LineRenderer lineRenderer = null;
    public void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Update(){
        UpdateLength();

    }

    private void UpdateLength(){
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());

    }

    private Vector3 CalculateEnd(){
        RaycastHit hit = CreateFowardRayCast();
        Vector3 endPosition = DeafultEnd(defaultLength);

        if(hit.collider)
            endPosition = hit.point;

        return endPosition;
    }
    

    private RaycastHit CreateFowardRayCast(){
         RaycastHit hit;

         Ray ray = new Ray(transform.position, transform.forward);

         Physics.Raycast(ray, out hit, defaultLength);

         return hit;
    }

    private Vector3 DeafultEnd(float length){
        return transform.position = (transform.forward * length);
    }



}
