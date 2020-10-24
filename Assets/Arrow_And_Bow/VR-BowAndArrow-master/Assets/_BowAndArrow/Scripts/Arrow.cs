﻿using UnityEngine;

public class Arrow : MonoBehaviour
{
   public float m_Speed = 2000.0f;
   public Transform m_Tip = null;

   private Rigidbody m_Rigidbody = null;
   private bool m_IsStopped = true;
   private Vector3 m_LastPosition = Vector3.zero;

   private void Awake()
   {
   	m_Rigidbody = GetComponent<Rigidbody>();
   }

   private void Start()
   {
      m_LastPosition = transform.position;
   }

   private void FixedUpdate()
   {
   	if (m_IsStopped)
   		return;

   	// Rotate
   	m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Rigidbody.velocity, transform.up));

   	// Collision
      RaycastHit hit;
   	if(Physics.Linecast(m_LastPosition, m_Tip.position, out hit))
   	{
   		Stop(hit.collider.gameObject);
   	}

   	// Store position
   	m_LastPosition = m_Tip.position;
   }

   private void Stop(GameObject hitObject)
   {
   	m_IsStopped = true;

      transform.parent = hitObject.transform;

   	m_Rigidbody.isKinematic = true;
   	m_Rigidbody.useGravity = false;

      CheckForDamage(hitObject);

   }

   private void CheckForDamage(GameObject hitObject)
   {
      MonoBehaviour[] behaviours = hitObject.GetComponents<MonoBehaviour>();

      foreach(MonoBehaviour behaviour in behaviours)
      {
         if(behaviour is IDamageable)
         {
            IDamageable damageable = (IDamageable)behaviour;
            damageable.Damage(5);

            break;
         }
      }
   }

   public void Fire(float pullValue)
   {
      m_LastPosition = transform.position;

   	m_IsStopped = false;
   	transform.parent = null;

   	m_Rigidbody.isKinematic = false;
   	m_Rigidbody.useGravity = true;
   	m_Rigidbody.AddForce(transform.forward * (pullValue * m_Speed));

   	Destroy(gameObject, 5.0f);

   }
}













