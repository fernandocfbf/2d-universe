using UnityEngine;

public class ConditionDistLT : Condition /*Less Than */
{
   Transform agent; /*posições do agente*/
   Transform target; /*posições do alvo*/
   float maxDist; /*distância máxima*/

   public ConditionDistLT(Transform ag, Transform ta, float dist) {
       agent = ag;
       target = ta;
       maxDist = dist;
   }

   public override bool Test()
   {
       if(agent == null || target == null){ //foi atingido
           return false;
       }else{
           return Vector2.Distance(agent.position, target.position) <= maxDist;
       }
       
   }
}