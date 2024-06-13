using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour
{
    public GameObject player;
    public GameObject cloud;
    public ParticleSystem particleSystemFog;
    public string saveFile;
    public GameData gameData = new GameData();

    private void Awake()
    {
        saveFile = Application.dataPath + "/gameData.json";
        player = GameObject.FindGameObjectWithTag("Player");
        cloud = GameObject.Find("Cloud");
        particleSystemFog = GameObject.Find("ParticleSystemFog").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadData();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SaveData();
        }
    }

    private void LoadData()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            gameData = JsonUtility.FromJson<GameData>(content);

            // Actualiza la posición del jugador y la nube

            player.transform.position = gameData.positionPlayer;
            cloud.transform.position = gameData.positionCloud;

            // Itera sobre todas las instancias de ParticleSystemFog
            ParticleSystem[] particleSystems = FindObjectsOfType<ParticleSystem>();
            foreach (var ps in particleSystems)
            {
                if (ps.gameObject.name.StartsWith("ParticleSystemFog"))
                {
                    var mainParticle = ps.main;
                    mainParticle.startSize = gameData.sizeParticleFog;
                }
            }

            Debug.Log("Archivo cargado.");
        }
        else
        {
            Debug.Log("El archivo no existe.");
        }
    }

    private void SaveData()
    {
        GameData newData = new GameData()
        {
            positionPlayer = player.transform.position,
            positionCloud = cloud.transform.position,
            sizeParticleFog = particleSystemFog.main.startSizeMultiplier
        };

        string cadenaJson = JsonUtility.ToJson(newData);

        File.WriteAllText(saveFile, cadenaJson);

        Debug.Log("Archivo guardado.");
    }
}
