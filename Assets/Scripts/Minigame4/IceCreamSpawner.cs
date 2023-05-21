using UnityEngine;

public class IceCreamSpawner : MonoBehaviour {
    [SerializeField] GameObject[] iceCreamPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start() {
        StartCoroutine(IceCreamSpawn());
    }

    System.Collections.IEnumerator IceCreamSpawn() {
        while (true) {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(iceCreamPrefab[Random.Range(0, iceCreamPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
