using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SLIDDES.Components
{
    [AddComponentMenu("SLIDDES/Components/Scene Loading")]
    public class SceneLoading : MonoBehaviour
    {
        public bool loadOnAnimate;
        public int sceneIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(loadOnAnimate)
            {
                loadOnAnimate = false;
                Load();
            }
        }

        public void Load()
        {
            SceneManager.LoadScene(sceneIndex);
        }

    }
}
