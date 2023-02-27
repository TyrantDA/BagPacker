using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class Packer : MonoBehaviour
    {
        [SerializeField] private GameObject[] items;
        private float[] xpos = { -3.03f, -6.17f };
        private float[] ypos = { -1.45f, -1.99f };
        int numOfItems;
        private int[] points;
        private int[] complete;
        Stack<string> inBag = new Stack<string>();

        private List<GameObject> onScreen = new List<GameObject>();
        private List<string> type = new List<string>();
        // Start is called before the first frame update
        void Start()
        {
            points = new int[items.Length];
            complete = new int[items.Length];

            numOfItems = items.Length;


            Spawning("potion", xpos[0], ypos[0]);
            Spawning("sword", xpos[1], ypos[1]);
            

            ToFillBag();
        }

        void Spawning(string num, float x, float y)
        {
            if (num.CompareTo("potion") == 0)
            {
                onScreen.Add((GameObject)Instantiate(items[0], new Vector3(x, y, 0f), transform.rotation));
                type.Add("potion");
            }
            else if(num.CompareTo("sword") == 0)
            {
                onScreen.Add((GameObject)Instantiate(items[1], new Vector3(x, y, 0f), transform.rotation));
                type.Add("sword");
            }
        }

        void ToFillBag()
        {
            System.Random r = new System.Random();
            int hold;

            for (int x = 0; x < numOfItems; x++)
            {
                hold = r.Next(1, 5);
                complete[x] = hold;
                Debug.Log(complete[x] + " ");
            }
        }

        public int[] GetPoints()
        {
            return points;
        }

        public int[] GetComplete()
        {
            return complete;
        }

        void Points(string t, bool posNeg)
        {
            if (t.CompareTo("potion") == 0)
            {
                if (posNeg)
                {
                    points[0]++;
                }
                else
                {
                    points[0]--;
                }
            }
            else if (t.CompareTo("sword") == 0)
            {
                if (posNeg)
                {
                    points[1]++;
                }
                else
                {
                    points[1]--;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            int done = 0;
            int p = 0;
            int s = 0;
            for (int x = 0; x < onScreen.Count; x++)
            {
                Placeable hold = onScreen[x].GetComponent<Placeable>();
                if(hold.bagged)
                {
                    Destroy(onScreen[x]);
                    onScreen.RemoveAt(x);
                    inBag.Push(type[x]);
                    Points(type[x], true);
                    type.RemoveAt(x);
                    
                    //Debug.Log("bagged");
                }
            }

            for(int z = 0; z < type.Count; z++)
            {
                if(type[z].CompareTo("potion") == 0)
                {
                    p++;
                }
                else if(type[z].CompareTo("sword") == 0)
                {
                    s++;
                }
            }

            if(s < 1)
            {
                Spawning("sword", xpos[1], ypos[1]);
            }
            else if(p < 1)
            {
                Spawning("potion", xpos[0], ypos[0]);
            }

            for(int x = 0; x < numOfItems; x++)
            {
                if(points[x] == complete[x])
                {
                    done++;
                }
            }
            try
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    //Debug.Log("pressed r");
                    string h = inBag.Pop();
                    Spawning(h, 2.21f, -0.3797f);
                    Points(h, false);

                }
            }
            catch(Exception ex)
            {
                Debug.Log("empty");
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log(points[0] + " " + points[1]);
            }

            if (done == numOfItems)
            {
                Debug.Log("done");
                SceneManager.LoadScene("SampleScene");
            }

           
            
        }
    }
