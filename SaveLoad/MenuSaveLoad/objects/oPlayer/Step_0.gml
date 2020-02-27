/// @description Inserte aquí la descripción
// Puede escribir su código en este editor
key_left = keyboard_check(vk_left);
key_right = keyboard_check(vk_right);
key_jump = keyboard_check_pressed(vk_up);

var move = key_right - key_left;

hsp = move * walksp;

vsp = vsp + grv;

if(place_meeting(x,y+1,oFloorWall))&&(key_jump)
{
	vsp = -12;
}

if(place_meeting(x+hsp,y,oFloorWall))
{
	while(!place_meeting(x+sign(hsp),y,oFloorWall))
	{
		x = x + sign(hsp);
	}
	hsp = 0;
}
x = x + hsp;

if(place_meeting(x,y+vsp,oFloorWall))
{
	while(!place_meeting(x,y+sign(vsp),oFloorWall))
	{
		y = y + sign(vsp);
	}
	vsp = 0;
}

y = y + vsp;