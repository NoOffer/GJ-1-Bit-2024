using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WitchAI : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserOffset;
    [SerializeField, Min(0)] private float laserLength;
    [SerializeField, Min(0)] private float laserChargeTime;
    [SerializeField, Min(0)] private float laserDuration;
    [SerializeField, Min(0)] private float laserCD;

    private float laserCDTimer;

    private void Awake()
    {
        laserCDTimer = 0f;
    }

    private void Update()
    {
        if (laserCDTimer > laserCD)
        {
            StartCoroutine("LaserAttack");

            laserCDTimer -= laserCD;
        }

        laserCDTimer += Time.deltaTime;
    }

    IEnumerator LaserAttack()
    {
        float laserTimer = 0f;

        Transform laser = Instantiate(laserPrefab).transform;
        LineRenderer beam = laser.GetComponentInChildren<LineRenderer>();

        laser.position = transform.position;
        beam.SetPosition(0, Vector3.zero);
        beam.SetPosition(1, Vector3.zero);

        Vector3 laserPos;
        while (laserTimer < laserChargeTime)
        {
            laserPos = new Vector3(target.position.x - laserOffset, target.position.y, 0f);
            laser.position = Vector3.Lerp(laser.position, laserPos, 5f * Time.deltaTime);
            laserTimer += Time.deltaTime;

            yield return null;
        }

        laserTimer = 0f;

        while (laserTimer < laserDuration)
        {
            beam.SetPosition(1, new Vector3(laserTimer / laserDuration * laserLength, 0f, 0f));
            laserTimer += Time.deltaTime;

            yield return null;
        }

        laserTimer = 0f;

        while (laserTimer < laserDuration)
        {
            beam.SetPosition(0, new Vector3(laserTimer / laserDuration * laserLength, 0f, 0f));
            laserTimer += Time.deltaTime;

            yield return null;
        }
        Destroy(beam.gameObject);

        laserTimer = 0f;

        laserPos = laser.position;
        laserPos.x = -40f;
        while (laserTimer < laserChargeTime)
        {
            laser.position = Vector3.Lerp(laser.position, laserPos, 5f * Time.deltaTime);
            laserTimer += Time.deltaTime;

            yield return null;
        }

        Destroy(laser.gameObject);

        yield return null;
    }
}
