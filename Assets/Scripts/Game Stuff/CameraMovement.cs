using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public Animator anim;
    public CameraReset cameraReset;
    public VectorValue startPos;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = cameraReset.cameraMax;
        minPosition = cameraReset.cameraMin;
        anim = GetComponent<Animator>();
        transform.position = new Vector3(startPos.initialValue.x, startPos.initialValue.y, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); 
        }
    }

    public void BeginKick()
    {
        anim.SetBool("screenKick", true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("screenKick", false);
    }
}
