using UnityEngine;


namespace Script.C_.Player
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public float chargeSpeed;
        public float maxChargeTime;
        public float minVelocity;
    }
}
