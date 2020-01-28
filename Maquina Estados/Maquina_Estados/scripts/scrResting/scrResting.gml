if(oPlayer.myColor == c_red)
	myCurrentState = EnemyStates.Patrolling;
else if(oPlayer.myColor == c_blue)
	myCurrentState = EnemyStates.Chasing;

path_end();
move_towards_point(oPlayer.x,oPlayer.y, 7);