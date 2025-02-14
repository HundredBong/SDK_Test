using UnityEngine;

public class RayGun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public GameObject ratImpactPrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 5f;
    public float lineShotTimer = 0.3f;
    public LayerMask layerMask;

    private AudioSource audioSource;
    public AudioClip shootClip;
    //d
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("葛贰馆瘤户具户具");

        audioSource.PlayOneShot(shootClip);

        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance, layerMask);

        Vector3 endPoint = Vector3.zero;

        if (hasHit)
        {
            endPoint = hit.point;

            //过?急
            Quaternion rayImpactRotation = Quaternion.LookRotation(-hit.normal);
            GameObject rayImpact = Instantiate(ratImpactPrefab, hit.point, rayImpactRotation);
            Destroy(rayImpact,1f);
        }
        else
        {
             endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        }

        LineRenderer line = Instantiate(linePrefab);

        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
       
        line.SetPosition(1, endPoint);  

        Destroy(line.gameObject, lineShotTimer);
    }
}
