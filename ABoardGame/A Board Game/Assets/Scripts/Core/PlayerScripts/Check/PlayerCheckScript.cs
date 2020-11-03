using ABoardGame.Scripts.Core.PlayerScripts.Data;
using UnityEngine;

namespace ABoardGame.Scripts.Core.PlayerScripts
{
    public class PlayerCheckScript : MonoBehaviour
    {
        private CapsuleCollider capsuleCollider;

        [SerializeField]
        private PlayerCheckData playerCheckData = null;

        private GameObject bottomSphere { get; set; }
        private GameObject leftSphere { get; set; }
        private GameObject rightSphere { get; set; }
        private GameObject frontSphere { get; set; }
        private GameObject backSphere { get; set; }

        private bool flipTrigger { get; set; }

        public bool boundaryTriggerLeft { get; private set; }
        public bool boundaryTriggerRight { get; private set; }
        public bool boundaryTriggerFront { get; private set; }
        public bool boundaryTriggerBack { get; private set; }

        private void Awake()
        {
            flipTrigger = false;
           

            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            SummonDetectionSphere();
        }

        private void Update()
        {
            CheckForBoundary();
        }

        public bool UniCheckIfHittingBoundary(GameObject gameObject, Vector3 pos)
        {
            Debug.DrawRay(gameObject.transform.position, pos * playerCheckData.rayCastDistance, Color.black);

            RaycastHit hitBoundary;

            if (Physics.Raycast(gameObject.transform.position, pos, out hitBoundary, playerCheckData.rayCastDistance, playerCheckData.boundary))
            {
                return true;
            }

            return false;
        }

        public void CheckForFlipTriggers()
        {
            flipTrigger = CheckTheBlock(playerCheckData.flipBlock);
        }

        public void CheckForBoundary()
        {
            boundaryTriggerFront = UniCheckIfHittingBoundary(frontSphere, Vector3.forward);
            boundaryTriggerBack = UniCheckIfHittingBoundary(backSphere, Vector3.back);
            boundaryTriggerLeft = UniCheckIfHittingBoundary(leftSphere, Vector3.left);
            boundaryTriggerRight = UniCheckIfHittingBoundary(rightSphere, Vector3.right);
        }

        public bool CheckTheBlock(LayerMask layerMask)
        {
            Debug.DrawRay(bottomSphere.transform.position, Vector3.down * playerCheckData.rayCastDistance, Color.black);

            RaycastHit hit;

            if (Physics.Raycast(bottomSphere.transform.position, Vector3.down, out hit, playerCheckData.rayCastDistance, layerMask))
            {
                Debug.Log("Hit Block");

                return true;
            }

            return false;
        }

        public GameObject CreateDetectionSphere(Vector3 pos)
        {
            GameObject obj = Instantiate(playerCheckData.detectionSphere, pos, Quaternion.identity);
            obj.transform.parent = this.transform;
            return obj;
        }

        public void SummonDetectionSphere()
        {
            Vector3 pos = new Vector3(capsuleCollider.center.x + playerCheckData.OfsetFromCenter, capsuleCollider.height, capsuleCollider.center.z);

            rightSphere = CreateDetectionSphere(pos);

            pos = new Vector3(capsuleCollider.center.x - playerCheckData.OfsetFromCenter, capsuleCollider.height, capsuleCollider.center.z);

            leftSphere = CreateDetectionSphere(pos);

            pos = new Vector3(capsuleCollider.center.x, capsuleCollider.height, capsuleCollider.center.z + playerCheckData.OfsetFromCenter);

            frontSphere = CreateDetectionSphere(pos);

            pos = new Vector3(capsuleCollider.center.x, capsuleCollider.height, capsuleCollider.center.z - playerCheckData.OfsetFromCenter);

            backSphere = CreateDetectionSphere(pos);

            pos = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y + (capsuleCollider.height / 2) + playerCheckData.OfsetFromCenterY, capsuleCollider.center.z);

            bottomSphere = CreateDetectionSphere(pos);
        }
    }
}