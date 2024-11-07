using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemGypsophila3D : MonoBehaviour
{
    private string axiom = "X"; 
    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private string currentString;

    // Parameter yang dapat diubah
    public int iterations = 5;
    public float angle = 25.0f;
    public float length = 0.5f;
    
    // Prefab references
    public GameObject stemPrefab;
    public GameObject leafPrefab;
    public GameObject stamenPrefab;

    private List<GameObject> createdPrefabs = new List<GameObject>(); // Menyimpan prefab yang dibuat

    void Start()
    {
        // Aturan untuk L-System
        rules.Add('X', "F[?L][+XY]F[-XY][^XY][&XY]");
        rules.Add('F', "FF");
        rules.Add('Y', "F[?S]");

        // Generate L-System berdasarkan iterasi awal
        RegenerateLSystem();
    }

    void Update()
    {
        // Mengubah sudut (angle) dengan tombol panah kiri dan kanan
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle -= 1f; // Kurangi sudut
            RegenerateLSystem();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle += 1f; // Tambah sudut
            RegenerateLSystem();
        }

        // Mengubah panjang cabang (length) dengan tombol panah atas dan bawah
        if (Input.GetKey(KeyCode.UpArrow))
        {   
            if (length < 1f)
            {
            length += 0.01f; // Tambah panjang
            RegenerateLSystem();
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (length > 0.1f)
            {
            length -= 0.01f; // Tambah panjang
            RegenerateLSystem();
            }
        }

        // Membatasi agar panjang cabang tidak negatif
        length = Mathf.Max(0.1f, length);

        // Mengubah jumlah iterasi dengan tombol '+' dan '-'
        if (Input.GetKeyDown(KeyCode.Equals)) // Tombol '=' untuk menambah iterasi
        {   
            if (iterations < 6)
            {
            iterations++;
            RegenerateLSystem(); // Regenerate jika iterasi berubah
            }
        }
        if (Input.GetKeyDown(KeyCode.Minus)) // Tombol '-' untuk mengurangi iterasi
        {
            if (iterations > 1)
            {
                iterations--;
                RegenerateLSystem(); // Regenerate jika iterasi berubah
            }
        }
    }

    void RegenerateLSystem()
    {
        ClearCreatedPrefabs(); // Hapus prefab yang telah dibuat sebelumnya
        GenerateLSystem(); // Regenerasi string L-System baru
        transform.position = Vector3.zero; // Reset posisi ke titik awal
        DrawLSystem(); // Mulai menggambar kembali tanpa coroutine
    }

    void ClearCreatedPrefabs()
    {
        foreach (var prefab in createdPrefabs)
        {
            Destroy(prefab);
        }
        createdPrefabs.Clear();
    }

    void GenerateLSystem()
    {
        currentString = axiom;
        for (int i = 0; i < iterations; i++)
        {
            currentString = ApplyRules(currentString);
        }
    }

    string ApplyRules(string input)
    {
        string output = "";
        foreach (char c in input)
        {
            output += rules.ContainsKey(c) ? rules[c] : c.ToString();
        }
        return output;
    }

    void DrawLSystem()
    {
        Stack<TransformInfo> transformStack = new Stack<TransformInfo>();
        foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F': CreateStem(); break;
                case 'L': CreateLeaf(); break;
                case 'S': CreateStamen(); break;
                case '+': Rotate(Vector3.forward, angle); break;
                case '-': Rotate(Vector3.forward, -angle); break;
                case '^': Rotate(Vector3.right, angle); break;
                case '&': Rotate(Vector3.right, -angle); break;
                case '>': Rotate(new Vector3(-0.5f, 0, 0), angle); break;
                case '<': Rotate(new Vector3(-0.5f, 0, 0), -angle); break;
                case ',': Rotate(new Vector3(0, 0, -0.5f), angle); break;
                case '.': Rotate(new Vector3(0, 0, -0.5f), -angle); break;
                case '?': RotateRandom(); break;
                case '[': SaveTransform(transformStack); break;
                case ']': RestoreTransform(transformStack); break;
            }
        }
    }

    void CreateStem()
    {
        GameObject stem = Instantiate(stemPrefab, transform.position, transform.rotation);
        createdPrefabs.Add(stem);
        transform.Translate(Vector3.up * length);
    }

    void CreateLeaf()
    {
        GameObject leaf = Instantiate(leafPrefab, transform.position, transform.rotation);
        createdPrefabs.Add(leaf);
        transform.Translate(Vector3.up * length);
        Rotate(new Vector3(Random.Range(-0.5f, 0), 0, Random.Range(-0.5f, 0)), angle);
    }

    void CreateStamen()
    {
        GameObject stamen = Instantiate(stamenPrefab, transform.position, transform.rotation);
        createdPrefabs.Add(stamen);
        transform.Translate(Vector3.up * length);
    }

    void Rotate(Vector3 axis, float angle)
    {
        transform.Rotate(axis * angle);
    }

    void RotateRandom()
    {
        float randomX = Random.Range(-0.5f, 0.5f);
        float randomZ = Random.Range(-0.5f, 0.5f);
        Rotate(new Vector3(randomX, 0, randomZ), -angle);
    }

    void SaveTransform(Stack<TransformInfo> transformStack)
    {
        transformStack.Push(new TransformInfo()
        {
            position = transform.position,
            rotation = transform.rotation
        });
    }

    void RestoreTransform(Stack<TransformInfo> transformStack)
    {
        if (transformStack.Count > 0)
        {
            var ti = transformStack.Pop();
            transform.position = ti.position;
            transform.rotation = ti.rotation;
        }
    }

    private struct TransformInfo
    {
        public Vector3 position;
        public Quaternion rotation;
    }
}
