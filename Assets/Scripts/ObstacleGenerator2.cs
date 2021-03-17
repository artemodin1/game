using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator2 : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 3f)]
    private float _period = 3f;

    [SerializeField]
    private Obstacle[] _obstaclePrefabs;

    [SerializeField]
    private Transform _obstacles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateRoutine());
        StartCoroutine(PeriodRoutine());
    }
    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GenerateRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            var obstacle = Instantiate(_obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)], _obstacles);

            var position = obstacle.transform.position;
            position.x = transform.position.x;
            obstacle.transform.position = position;

            obstacle.Speed = 8;

            yield return new WaitForSeconds(Random.Range(1, _period));
        }
    }

    private IEnumerator PeriodRoutine()
    {
        while (_period > 1.5f)
        {
            _period -= 0.3f;


            yield return new WaitForSeconds(30f);
        }
    }
}
