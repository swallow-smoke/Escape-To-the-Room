using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class StatusEffectController : MonoBehaviour
    {
        public List<StatusEffect> activeStatusEffects = new List<StatusEffect>();

        public void AddStatusEffect(StatusEffectType type, float duration, float amount)
        {
            activeStatusEffects.Add(new StatusEffect(type, duration, amount));
        }

        void Update()
        {
            for (int i = activeStatusEffects.Count - 1; i >= 0; i--)
            {
                activeStatusEffects[i].Tick(this, Time.deltaTime);
            }
        }

        public void RemoveStatusEffect(StatusEffect effect)
        {
            activeStatusEffects.Remove(effect);
        }
    }

    public class StatusEffect
    {
        public StatusEffectType type;
        public float duration;
        public float amount;

        float tickTimer = 0f;
        float tickInterval = 1f; // 1초마다 tick

        public StatusEffect(StatusEffectType type, float duration, float amount)
        {
            this.type = type;
            this.duration = duration;
            this.amount = amount;
        }

        public void Tick(StatusEffectController controller, float deltaTime)
        {
            duration -= deltaTime;

            tickTimer += deltaTime;

            if (tickTimer >= tickInterval)
            {
                tickTimer = 0f;
                ApplyEffect(controller);
            }

            if (duration <= 0)
            {
                controller.RemoveStatusEffect(this);
            }
        }

        void ApplyEffect(StatusEffectController controller)
        {
            switch (type)
            {
                case StatusEffectType.Burn:
                    Debug.Log("Burn damage: " + amount);
                    break;

                case StatusEffectType.Poison:
                    Debug.Log("Poison damage: " + amount);
                    break;

                case StatusEffectType.Regeneration:
                    Debug.Log("Heal: " + amount);
                    break;
            }
        }
    }
    
    public enum StatusEffectType
    {
        Burn,
        Freeze,
        Poison,
        Stun,
        HealOverTime,
        Shield,
        SpeedBoost,
        Slow,
        Regeneration,
        Curse
    }
}