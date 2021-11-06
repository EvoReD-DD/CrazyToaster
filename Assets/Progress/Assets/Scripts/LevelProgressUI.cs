using UnityEngine ;
using UnityEngine.UI ;

public class LevelProgressUI : MonoBehaviour {

   [Header ("UI references :")]
   [SerializeField] private Image uiFillImage ;
   [SerializeField] private Text uiStartText ;
   [SerializeField] private Text uiEndText ;

   public void SetLevelTexts (int level) {
      uiStartText.text = level.ToString () ;
      uiEndText.text = (level + 1).ToString () ;
   }
   private void UpdateProgressFill (float value) {
      uiFillImage.fillAmount = value ;
   }


   private void Update () {
      // check if the player doesn't pass the End Line
      /*if (playerTransform.position.z <= endLinePosition.z) {
         float newDistance = GetDistance () ;
         float progressValue = Mathf.InverseLerp (fullDistance, 0f, newDistance) ;

         UpdateProgressFill (progressValue) ;
      }*/
   }
}
