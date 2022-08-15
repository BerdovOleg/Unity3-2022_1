using System.IO;
using UnityEngine;

public class AutoCreatedLevel : MonoBehaviour
{
    string path = "Assets/Data/Level ";
    [SerializeField] GameObject StartPlatform;
    [SerializeField] GameObject Platform;
    [SerializeField] GameObject FinishPlatform;
    [SerializeField] Vector3 DistanceBetweenPlatforms;
    [SerializeField] Transform Anchor;
    public GameObject[] _platforms;

    public bool CreatedLevelReady = false;
    int linesCount;

    public void CollectingLevel(int level)
    {
        var _path = path;
        _path += level + ".txt";
        //Ставим Старт
        Instantiate(StartPlatform, Anchor);
        var _distanceBetweenPlatforms = DistanceBetweenPlatforms;
        //Считатем количество строк

        //Работаем с файлом
        StreamReader reader = new StreamReader(_path);
        linesCount = 1;
        int nextLine = '\n';
        //считаем строки
        while (!reader.EndOfStream)
        {
            if (reader.Read() == nextLine) linesCount++;
        }
        _platforms = new GameObject[linesCount];

        //Генерим все платформы
        for (int i = 0; i < linesCount; i++)
        {
            _platforms[i] = Instantiate(Platform, Anchor);
            _platforms[i].transform.position += _distanceBetweenPlatforms;
            _distanceBetweenPlatforms += DistanceBetweenPlatforms;
        }
        //Ставим финиш
        var finish = Instantiate(FinishPlatform, Anchor);
        finish.transform.position += _distanceBetweenPlatforms;
        reader.Close();
        reader = new StreamReader(_path);
        for (int i = 0; i < linesCount; i++)
        {
            var text = reader.ReadLine();
            var count = _platforms[i].GetComponent<Platform>().Sectors.Length;
            for (int j = 0; j < count; j++)
            {
                if (text[j] == '*') { }
                else if (text[j] == '.') _platforms[i].GetComponent<Platform>().Sectors[j].Deactive();
                else if (text[j] == '#') _platforms[i].GetComponent<Platform>().Sectors[j].PlatformSetGood(false);
            }
        }
        CreatedLevelReady = true;
    }
}
