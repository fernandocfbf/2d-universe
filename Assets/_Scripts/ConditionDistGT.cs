using UnityEngine;

public class ConditionDistGT  : Condition /* Distância Maior Que */
{
   Transform agent; /*posições do agente*/
   Transform target; /*posições do alvo*/
   float minDist; /*distância máxima*/

   public ConditionDistGT(Transform ag, Transform ta, float dist) {
       agent = ag;
       target = ta;
       minDist = dist;
   }

   public override bool Test()
   {
        if(agent == null || target == null){ //foi atingido
           return false;
       }else{
           return Vector2.Distance(agent.position, target.position) >= minDist  ;
       }
       
   }
}