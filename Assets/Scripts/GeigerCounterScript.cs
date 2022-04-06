using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeigerCounterScript : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public AudioSource m_AudioSource2;
    public AudioSource m_AudioSource3;
    public AudioSource m_AudioSource4;
    public AudioSource m_AudioSource5;


    public float distanc = 100f;
    public float range = 100f;
    int layerMask = 1 << 8;
    Vector3 box = new Vector3(1f, 3f, 1f);
    public Camera fpsCam;

    void Start()
    {

    }
    void OnEnable()
    {
        m_AudioSource.Play();
        m_AudioSource2.Play();
        m_AudioSource3.Play();
        m_AudioSource4.Play();
        m_AudioSource5.Play();
    }
        // Update is called once per frame
        void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        measure();
        //}
    }

    void measure()
    {
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        /*if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range,layerMask))
        {
            Debug.Log(hit.transform);
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.yellow);
            Debug.DrawLine(ray.origin, hit.point);
            Debug.Log(hit.distance);
        }*/

        if (Physics.BoxCast(fpsCam.transform.position, box, fpsCam.transform.forward, out hit, transform.rotation, range, layerMask))
        {
            Debug.Log(hit.transform);
            //Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.yellow);
            //Debug.DrawLine(ray.origin, hit.point);
            Debug.Log(hit.distance);


            if (hit.distance > 25)
            {
                m_AudioSource.pitch = 1;
                m_AudioSource.volume = 0.2f;
                m_AudioSource2.volume = 0.0f;
                m_AudioSource3.volume = 0.0f;
                m_AudioSource4.volume = 0.0f;
            }
            else if(hit.distance <= 25 && hit.distance > 21)
            {
                m_AudioSource.pitch = 1.25f;
                m_AudioSource.volume = 0.4f;
                m_AudioSource2.volume = 0.0f;
                m_AudioSource3.volume = 0.0f;
                m_AudioSource4.volume = 0.0f;
            }
            else if (hit.distance <= 21 && hit.distance > 16)
            {
                m_AudioSource.pitch = 1.5f;
                m_AudioSource.volume = 0.6f;
                m_AudioSource2.volume = 0.5f;
                m_AudioSource3.volume = 0.0f;
                m_AudioSource4.volume = 0.0f;
            }
            else if (hit.distance <= 16 && hit.distance > 11)
            {
                m_AudioSource.pitch = 1.75f;
                m_AudioSource.volume = 0.8f;
                m_AudioSource2.volume = 0.7f;
                m_AudioSource3.volume = 0.5f;
                m_AudioSource4.volume = 0.0f;
            }
            else 
            {
                m_AudioSource.pitch = 2f;
                m_AudioSource.volume = 1f;
                m_AudioSource2.volume = 0.7f;
                m_AudioSource3.volume = 0.7f;
                m_AudioSource4.volume = 0.5f;
            }
        }
        else
        {
            GameObject Enemy = GameObject.Find("Ghost");
            float dist = Vector3.Distance(this.transform.position, Enemy.transform.position);
            float multiplier = (float) ((100 - 5* dist) * 0.01);
            m_AudioSource.volume = multiplier;
            m_AudioSource2.volume = 0.0f;
            m_AudioSource3.volume = 0.0f;
            m_AudioSource4.volume = 0.0f;
            if (dist <= 10) 
            {
                m_AudioSource5.volume = multiplier;
            }
            else m_AudioSource5.volume = 0.0f;


            /*m_AudioSource.pitch = 1;
            m_AudioSource.volume = 0.5f;
            m_AudioSource2.volume = 0.0f;
            m_AudioSource3.volume = 0.0f;
            m_AudioSource4.volume = 0.0f;*/
        }
    }

    /*void OnDrawGizmos()
    {
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //(Vector3 center, Vector3 halfExtents, Vector3 direction, out RaycastHit hitInfo, Quaternion orientation, float maxDistance, int layerMask);
        if (Physics.BoxCast(fpsCam.transform.position, box, fpsCam.transform.forward, out hit, transform.rotation, range, layerMask))
        {
            Debug.Log(hit.transform);
            //Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.yellow);
            //Debug.DrawLine(ray.origin, hit.point);
            Debug.Log(hit.distance);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * hit.distance);
            Gizmos.DrawWireCube(fpsCam.transform.position + fpsCam.transform.forward* hit.distance, box);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range);
        }
    }*/
}
