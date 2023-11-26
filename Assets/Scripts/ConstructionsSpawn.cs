using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ConstructionsSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ConstructionType
    {
        Casa,
        Hospital
    }

    public int maxGridY;
    public int[] minLineX;
    public int[] maxLineX;
    public bool[][] occupied;
    public ConstructionType[][] constructionGrid;
    public int minTimeInterval, maxTimeInterval;
    public Grid grid;
    bool filled = false;

    AudioManager audioManager;

    private ResourceManager resourceManager;

    public int price;

    void Start()
    {
        audioManager = AudioManager.Instance;
        resourceManager = ResourceManager.Instance;

        occupied = new bool[maxGridY][];
        for (int i = 0; i < maxGridY; i++)
        {
            occupied[i] = new bool[maxLineX[0]];
        }

        constructionGrid = new ConstructionType[maxGridY][];
        for (int i = 0; i < maxGridY; i++)
        {
            constructionGrid[i] = new ConstructionType[maxLineX[0]];
        }

        StartCoroutine(spawnCasaTimer());
    }

    public void spawnarHospital()
    {
        /*int[] maxLineXHosp = new int[maxLineX.Length];
        for(int i = 0; i < maxLineX.Length; i++)
        {
            maxLineXHosp[i]--;
        }*/

        int[] coordenadas = calcularCoordenadas(minLineX, maxLineX, casasPorY());

        if (coordenadas[0] > -1 && resourceManager.count >= 5)
        {
           
            resourceManager.RemoveCount(price);
            
            // Logica para criar novo asset de casa no mapa
            grid.spawnHospitalInGrid(coordenadas);
            // Toca musica ao spawnar
            if (audioManager != null)
            {
                audioManager.playSound("const_hospital");
            }
            // Logica para adicionar no sistema
            occupied[coordenadas[1]][coordenadas[0]] = true;
            occupied[coordenadas[1]][coordenadas[0]+1] = true;

            constructionGrid[coordenadas[1]][coordenadas[0]] = ConstructionType.Hospital;
            constructionGrid[coordenadas[1]][coordenadas[0]+1] = ConstructionType.Hospital;
        }
        else
        {
            Debug.Log("Coordenada -1");
        }
    }

    void spawnarCasa(int[] coordenadas)
{
        if (coordenadas[0] > -1)
        {
            // Logica para criar novo asset de casa no mapa
            grid.spawnHouseInGrid(coordenadas);
            // Toca musica ao spawnar
            if (audioManager != null)
            {
                audioManager.playSound("const_casa");
            }
            // Logica para adicionar no sistema
            occupied[coordenadas[1]][coordenadas[0]] = true;
            constructionGrid[coordenadas[1]][coordenadas[0]] = ConstructionType.Casa;
        }
        
}

public int[] casasPorY()
{
    int[] toReturn = new int[maxGridY];
    for (int y = 0; y < maxGridY; y++)
    {
        for (int x = 0; x < occupied[y].Length; x++)
        {
                if (occupied[y][x]) { toReturn[y]++; };
        }
    }
    return toReturn;
}

bool isCasaOcupada(int[] coordinates)
{
        return occupied[coordinates[1]][coordinates[0]];
}

int[] calcularCoordenadas(int[] minX, int[] maxX, int[] cpy)
{
        int[] toReturn = new int[2]; // x,y

        int maxY = cpy.Length;
    // Pega uma array de numeros indicando a quantidade de casas por linha e calcula em qual coordenada X e Y a casa deve surgir
    // Ver qual a ultima linhas que tem casas. As linhas aonde podem spawnar são até 2 acima desta. Ignore linhas que tenham mais casas que o maximo
    // 1 a 50, adiciona uma casa na linha mais baixa. 51 a 75 adiciona na linha acima dessa. 76 à 95 adiciona em alguma linha aleatória que ja tenha casa. 96 a 99 adiciona na linha acima da ultima que tem casas. 
    // 100 adiciona na segunda acima da ultima
    // No primeiro turno, sempre vai ser na primeira linha (y=0)

    // Ultima linha em que pode aparecer casas

        if (cpy[0] == 0)
        {
                toReturn[1] = 0;

        }
        else
        {
            int primeiraLinha = 0;
            int ultimaLinha = 1;
            for (int i = 0; i < maxY; i++)
            {
                // Maximo de casas nessa linha
                if (cpy[i] >= maxX[i])
                { 
                        primeiraLinha = i + 1;
                }
                else if(cpy[i] == 0 && i < maxY - 1)

                {
                    if (cpy[i + 1] == 0)
				    {
                            ultimaLinha = i + 1;

                    }
                }
            }

            if (ultimaLinha >= maxX.Length)
            {
                ultimaLinha = maxX.Length-1;
            }

            int rand = UnityEngine.Random.Range(1, 101);

            if (rand < 51)
            {
                    toReturn[1] = primeiraLinha;

            }
            else if(rand >= 51 && rand <= 75)

            {
                    toReturn[1] = primeiraLinha + 1;

            }
            else if(rand >= 76 && rand <= 95)

            {
                    toReturn[1] = UnityEngine.Random.Range(primeiraLinha, ultimaLinha);

            }
            else if(rand >= 96 && rand <= 99)

            {
                    toReturn[1] = ultimaLinha - 1;

            }

            else
            {
                    toReturn[1] = ultimaLinha;

            }
        }
        if (toReturn[1] >= maxGridY) 
        {
            toReturn[0] = -1;
            toReturn[1] = -1;
            filled = true;
        }
        else { 
            toReturn[0] = UnityEngine.Random.Range(minX[toReturn[1]], minX[toReturn[1]]+maxX[toReturn[1]]);

            while (isCasaOcupada(toReturn)) 
            {
                    if (cpy[toReturn[1]] >= maxX[toReturn[1]])
                    {
                        break;
                    }
                    toReturn[0] = UnityEngine.Random.Range(minX[toReturn[1]], minX[toReturn[1]]+maxX[toReturn[1]]);
            }
        }
        return toReturn;
}

    // Update is called once per frame

    IEnumerator spawnCasaTimer()
    {
        while (!filled)
        {
            int[] coordenadas = calcularCoordenadas(minLineX, maxLineX, casasPorY());
            spawnarCasa(coordenadas);
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeInterval, maxTimeInterval));
        }

    }

    void Update()
    {

        
    }
}
