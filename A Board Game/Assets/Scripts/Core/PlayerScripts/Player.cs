using ABoardGame.Scripts.Core.PlayerScripts.Commands;
using ABoardGame.Scripts.Core.PlayerScripts.Data;
using ABoardGame.Scripts.Core.PlayerScripts.Input;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public Command horizontal;
        public Command vertical;
        public Command flip;

        [SerializeField]
        private CharacterInputHandler characterInputHandler;

        [SerializeField]
         private GameObject bottomSphere = null;

        [SerializeField]
        private PlayerData playerData = null;

        private void Start()
        {
            characterInputHandler = GetComponent<CharacterInputHandler>();
        }

        private void Update()
        {
            if (characterInputHandler.IsPressingHorizontalMovement)
            {
                horizontal.Execute(characterInputHandler.horizontalMovement);
                characterInputHandler.UseHorrizontalInput();
            }
            if (characterInputHandler.IsPressingVerticalMovement)
            {
                vertical.Execute(characterInputHandler.verticalMovement);
                characterInputHandler.UseVerticalInput();
            }
        }

        public bool CheckTheBlock(LayerMask layerMask)
        {
            Debug.DrawRay(bottomSphere.transform.position, Vector3.down * playerData.rayCastDistance, Color.black);

            RaycastHit hit;

            if (Physics.Raycast(bottomSphere.transform.position, Vector3.down, out hit, playerData.rayCastDistance, layerMask))
            {
                return true;
            }

            return false;
        }
    }
}