using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoadingScreen : AbstractScreen
    {
        public Slider _loadingSlider;
        public TMP_Text _loadingText;
        public AssetReference sceneReference;
        
        private AsyncOperationHandle<SceneInstance> _loadOperation;
        private Coroutine _loadingCoroutine;

        public void LoadScene(string sceneName)
        {
            base.OpenScreen();
            
            if (_loadingCoroutine != null)
                StopCoroutine(_loadingCoroutine);

            _loadingCoroutine = StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1;
            // _loadOperation = sceneReference.LoadSceneAsync(LoadSceneMode.Single, false);
            _loadOperation = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Single, false);
            _loadOperation.Completed += LoadOperation_Completed;
            float progress = 0f;

            while (progress < 0.9f)
            {
                progress = _loadOperation.PercentComplete;
                _loadingSlider.value = progress;

                if (_loadingText != null)
                    _loadingText.text = (progress * 100).ToString("F0") + "%";

                yield return null;
            }
            
            yield return new WaitForSeconds(1f);
            
            progress = 1f;
            _loadingSlider.value = progress;
            _loadingText.text = (progress * 100).ToString("F0") + "%";
            _loadOperation.Result.ActivateAsync();
        }

        private void LoadOperation_Completed(AsyncOperationHandle<SceneInstance> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
                Debug.Log("Scene loaded successfully!");
            else
                Debug.LogError("Scene loading failed!");
        }
    }
}
