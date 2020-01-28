/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
switch(myCurrentState)
{
	case EnemyStates.Patrolling:
		scrPatrolling();
		break;
	case EnemyStates.Resting:
		scrResting();
	break
	case EnemyStates.Chasing:
		scrChasing();
	break
}