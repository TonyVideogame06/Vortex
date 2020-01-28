/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
enum EnemyStates 
{
	Patrolling,
	Chasing,
	Resting
}

myCurrentState = EnemyStates.Patrolling;

lastPatrolX = path_get_point_x(enemyPatrol,0);
lastPatrolY = path_get_point_y(enemyPatrol,0);
lastPathPosition = path_position;