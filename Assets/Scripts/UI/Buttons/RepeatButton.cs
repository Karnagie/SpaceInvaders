using UI.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    [RequireComponent(typeof(CanvasGroup))]
    public class RepeatButton : UIButton
    {
        [SerializeField] private float _fadeSpeed = 0.5f;
        
        protected override void OnClick()
        {
            ReloadLevel();
        }

        public void Show()
        {
            CanvasGroup group = GetComponent<CanvasGroup>();
            IUIAnimation fade = new ButtonAnimation(group, _fadeSpeed);
            fade.TurnOn();
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}