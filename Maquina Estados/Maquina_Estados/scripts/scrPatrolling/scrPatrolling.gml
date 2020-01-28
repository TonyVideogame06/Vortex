if(oPlayer.myColor == c_blue)
{
	myCurrentState = EnemyStates.Chasing;
}
else if(oPlayer.myColor == c_aqua)
{
	myCurrentState = EnemyStates.Resting;
}


//If they have no path, find one
if(path_index == -1)
{
	move_towards_point(lastPatrolX, lastPatrolY, 5);
	if(point_distance(x, y, lastPatrolX, lastPatrolY)<5)
	{
		path_start(enemyPatrol,5,path_action_continue,1);
		path_position = lastPathPosition;
	}
}
else
{
	lastPatrolX = x;
	lastPatrolY = y;
	lastPathPosition = path_position;
}
